Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF.Models
Imports Sopimusrekisteri.DAL_CF.Repositories

Public Class IFRS1
    Inherits BasePage2

#Region "Sivun alustus"

    Public Const ExcelPolku = "~/Export/IFRS/"

    ' IFRS laskenta alkoi 1.1.2019, mutta tilastollisesti ensimmäinen laskenta alkaa 31.12.2018 klo 23:59:59
    ' Laskentaan on aina pakko hakea kaikki datat alusta lähtien koska uudet datat perustuu aina edelliseen dataan
    Private Const IFRS_AloitusVuosi = 2018

    Private _katselupvm As Date?
    Private _inflaatio As Decimal?
    Private _repo As IFRSRepository = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS) Then
            Response.Redirect("~/")
        End If

        If Not Page.IsPostBack Then

            AlustaSivu()

        End If

    End Sub

    Private Sub AlustaSivu()

        AlustaListat()
        HaeHistorioidutExcelit()

        cOletettuInflaatio.Text = 2.ToString("0.00")
        cKatselupvm.DateValue = Date.Now
        phTulokset.Visible = False

    End Sub

    Private Sub AlustaListat()


    End Sub

#End Region

#Region "Propertyt"

    Private ReadOnly Property Repository As IFRSRepository
        Get
            If _repo Is Nothing Then
                _repo = New IFRSRepository(Konfiguraatiot.ConnectionString)
            End If

            Return _repo
        End Get
    End Property

    Private Property Nykyhetki As IFRSKausi
        Get
            Return CType(ViewState("Nykyhetki"), IFRSKausi)
        End Get
        Set(value As IFRSKausi)
            ViewState("Nykyhetki") = value
        End Set
    End Property

    Private Property Data As List(Of IFRSKausi)
        Get
            Return CType(ViewState("Data"), List(Of IFRSKausi))
        End Get
        Set(value As List(Of IFRSKausi))
            ViewState("Data") = value
        End Set
    End Property

    Private ReadOnly Property Katselupvm As Date
        Get
            If _katselupvm Is Nothing Then
                _katselupvm = cKatselupvm.DateValue.Value.Date + New TimeSpan(0, 23, 59, 59, 59)
            End If
            Return _katselupvm
        End Get
    End Property

    Private ReadOnly Property Inflaatio As Decimal
        Get
            If _inflaatio Is Nothing Then
                _inflaatio = DataUtils.ParseDecimal(cOletettuInflaatio.Text, 0)
            End If
            Return _inflaatio
        End Get
    End Property

#End Region

#Region "Tietojen haku ja täyttö"

    Private Sub HaeHistorioidutExcelit()

        Dim excelit = Handlers.IFRSHistoriaExcel.HaeExcelit().ToList()

        lstHistoria.DataSource = excelit
        lstHistoria.DataBind()

    End Sub

    Private Function MuodostaData() As IEnumerable(Of IFRSKausi)

        Nykyhetki = Nothing

        Dim vuodet = Enumerable.Range(IFRS_AloitusVuosi, Katselupvm.Year - IFRS_AloitusVuosi + 1)
        Dim tulokset = New List(Of IFRSKausi)
        Dim edellinen As IFRSKausi = Nothing
        Dim i = 0

        For Each v In vuodet

            Dim pvm = New DateTime(v, 12, 31, 23, 59, 59, 59)

            ' Jos katselupäivän, vuosi katsotaan kyseistä päivää
            If pvm.Year = Katselupvm.Date.Year Then
                pvm = Katselupvm
            End If

            Dim data = Repository.HaeKausiMenneisyys(pvm)
            Dim kausi As IFRSKausi = Nothing

            If data.Rows.Count > 0 Then ' Menneisyys

                ' Historiatiedot, haetaan sieltä
                kausi = Repository.MuodostaKausi(data, edellinen, pvm)
                kausi.Lahde = "Historioitu tilanne (" & kausi.Pvm.ToShortDateString() & " klo " & kausi.Pvm.ToShortTimeString() & ")"

            ElseIf Nykyhetki Is Nothing Then ' Nykyhetki

                ' On nykyhetki, haetaan nykyhetki
                kausi = Repository.MuodostaKausi(Repository.HaeKausiNykyhetki(pvm), edellinen, pvm)
                kausi.Lahde = "Nykyhetken tilanne (" & pvm.ToShortDateString() & " klo " & pvm.ToShortTimeString() & ")"

                Nykyhetki = kausi

            ElseIf edellinen IsNot Nothing Then ' Tulevaisuus

                ' On tulevaisuus, lasketaan tulevaisuus
                kausi = Repository.LaskeKausiTulevaisuus(edellinen, pvm)
                kausi.Lahde = "Laskettu nykyhetken tilanteeseen verrattuna"

            End If

            If kausi IsNot Nothing Then

                kausi.HaettuKausi = kausi.Pvm.Year = Katselupvm.Year

                tulokset.Add(kausi)

                edellinen = kausi

            End If

        Next

        ' Jos jostain syystä haettu kausi puuttuu, asetetaan ensimmäinen
        If tulokset.Any() AndAlso Not tulokset.Any(Function(x) x.HaettuKausi) Then
            tulokset.First().HaettuKausi = True
        End If

        Data = tulokset

        Return tulokset

    End Function

    Private Sub TaytaTiedot()

        Dim data = MuodostaData()

        lstTabContent.DataSource = data
        lstTabContent.DataBind()

        lstTabHeader.DataSource = data
        lstTabHeader.DataBind()

        phTulokset.Visible = data.Any()
        phMaturiteettiContent.Visible = phTulokset.Visible
        phMaturiteettiHeader.Visible = phTulokset.Visible

        lstMaturiteettiFAS.TaytaTiedot(Repository.LaskeMaturiteettiFAS(data, Inflaatio))
        lstMaturiteettiIFRS.TaytaTiedot(Repository.LaskeMaturiteettiIFRS(data, Inflaatio))

        lblMaturiteettiVuosi.Text = Katselupvm.Year
        lblMaturiteettiInflaatio.Text = Inflaatio.ToString("0.00####")

        ' Voidaan historioida vaan jos Katselupvm on menneisyydessä ja ei ole historiaa vielä kyseiselle päivälle.
        btnTallennaHistoria.Visible = Katselupvm.Date <= Date.Now.Date AndAlso Not Repository.OnHistoriaPaivalle(Katselupvm)

    End Sub

#End Region

#Region "Excel-lataus ja muodostus"

    Private Function MuodostaExcel(data As IEnumerable(Of IFRSKausi)) As String

        Dim asetukset = New IFRSExcelAsetukset With
        {
            .Katselupvm = Katselupvm,
            .OletettuInflaatio = Inflaatio,
            .Data = data,
            .Vuokratyypit = DataContext.Vuokratyypit.ToList()
        }

        Using excel = New IFRSExcel(asetukset)

            Return excel.MuodostaExcel()

        End Using

    End Function

#End Region

#Region "Tietojen historiointi"

    Public Sub HistorioiNykytilanne()

        If Nykyhetki IsNot Nothing Then

            Dim excel = MuodostaExcel(Data)

            ' Tallennetaan excel ja sitten raaka data
            If Handlers.IFRSHistoriaExcel.TallennaExcel(Server.MapPath(excel), Nykyhetki.Pvm) Then
                Repository.Historioi(Nykyhetki, Context.User.Identity.Name)
            End If

            Response.Redirect("~/Raportit/IFRS.aspx")

        End If

    End Sub

#End Region

#Region "Tapahtumakäsittelijät"

    Protected Sub btnHae_Click(sender As Object, e As EventArgs)

        If Page.IsValid Then

            TaytaTiedot()

        End If

    End Sub

    Protected Sub lstTabContent_ItemDataBound(sender As Object, e As ListViewItemEventArgs)

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim kausi = CType(e.Item.DataItem, IFRSKausi)
            Dim cKausi = CType(e.Item.FindControl("cKausi"), IFRS_Kausi)

            cKausi.TaytaTiedot(kausi)

        End If

    End Sub

    Protected Sub btnLataaExcel_Click(sender As Object, e As EventArgs)

        Page.Validate()

        If Page.IsValid AndAlso Data IsNot Nothing Then

            Dim polku = MuodostaExcel(Data)
            Response.Redirect(polku)

        End If

    End Sub

    Protected Sub btnTallennaHistoria_Click(sender As Object, e As EventArgs)

        Page.Validate()

        If Page.IsValid AndAlso Data IsNot Nothing AndAlso Nykyhetki IsNot Nothing Then

            HistorioiNykytilanne()

        End If

    End Sub

    Protected Sub cvKatselupvm_ServerValidate(source As Object, args As ServerValidateEventArgs)

        args.IsValid = cKatselupvm.DateValue.HasValue

    End Sub

    Protected Sub lstHistoria_ItemDataBound(sender As Object, e As ListViewItemEventArgs)

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim item = CType(e.Item.DataItem, IFRSHistoriaExcelModel)
            Dim hlExcel = CType(e.Item.FindControl("hlExcel"), HyperLink)

            hlExcel.NavigateUrl = "~/Tiedosto/IFRS.ashx?id=" & item.Id
            hlExcel.ToolTip = item.Nimi
            hlExcel.Text = item.Pvm.ToString("dd.MM.yyyy")

        End If

    End Sub

    Protected Sub cusOletettuInflaatio_ServerValidate(source As Object, args As ServerValidateEventArgs)

        Dim luku = DataUtils.ParseDecimal(cOletettuInflaatio.Text, 0)

        args.IsValid = luku >= 0 AndAlso luku <= 100

    End Sub

#End Region

End Class