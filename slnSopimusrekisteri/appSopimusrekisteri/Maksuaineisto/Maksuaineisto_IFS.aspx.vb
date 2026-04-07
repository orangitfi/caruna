Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports Sopimusrekisteri.BLL_CF
Imports appSopimusrekisteri.Liittymat.Maksuaineisto
Imports System.Transactions
Imports System.IO
Imports KT.Utils


Public Class Maksuaineisto_IFS
  Inherits BasePage2

  Private _korvauslaskelmaHander As KorvauslaskelmaHandler
  Private _maksuHandler As MaksuHandler

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Page.IsPostBack Then

      txtMaksupvm.Text = Paivaykset.PalautaPaivays(Date.Now)

      ValitseValilehti()
      NaytaMaksuaineisto()

    End If

    If gvVirheellinenAineisto.Rows.Count > 0 Then

      btnTeeMaksuaineisto.Attributes.Add("onclick", " return confirm('Haluatko jatkaa maksuaineiston luomista? Virheellinen aineisto jää sen ulkopuolelle.');")

    End If

  End Sub

  Private Sub ValitseValilehti()

    If Request.Params("valinta") <> "" Then
      If Request.Params("valinta") = "Virheelliset" Then
        TabAineisto.ActiveTabIndex = 0
      ElseIf Request.Params("valinta") = "Tarkistettavat" Then
        TabAineisto.ActiveTabIndex = 1
      ElseIf Request.Params("valinta") = "Maksettavat" Then
        TabAineisto.ActiveTabIndex = 2
      End If
    End If

  End Sub

  Private Sub NaytaMaksuaineisto()

    Dim maksuaineisto As Liittymat.Maksuaineisto.Maksuaineisto = Me.HaeMaksuaineisto()

    gvVirheellinenAineisto.DataSource = maksuaineisto.VirheellinenAineisto
    gvVirheellinenAineisto.DataBind()
    TabVirheellinenAineisto.HeaderText = String.Format("Virheellinen aineisto ({0})", maksuaineisto.VirheellinenAineisto.Count().ToString())
    gvTarkistettavaAineisto.DataSource = maksuaineisto.TarkistettavaAineisto
    gvTarkistettavaAineisto.DataBind()
    TabTarkistettavaAineisto.HeaderText = String.Format("Tarkistettava aineisto ({0})", maksuaineisto.TarkistettavaAineisto.Count().ToString())
    gvMaksettavaAineisto.DataSource = maksuaineisto.MaksettavaAineisto
    gvMaksettavaAineisto.DataBind()
    TabMaksettavaAineisto.HeaderText = String.Format("Maksettava aineisto ({0})", maksuaineisto.MaksettavaAineisto.Count().ToString())

    TeeExcelit(maksuaineisto)

    If maksuaineisto.Maksut.Count > 0 Then
      btnTeeMaksuaineisto.Visible = RooliAvustaja.OnMaksujenHyvaksymisOikeus(maksuaineisto.Maksut.Sum(Function(x) x.Summa.GetValueOrDefault(0)))
    Else
      btnTeeMaksuaineisto.Visible = False
    End If

  End Sub

  Private Sub TeeExcelit(maksuaineisto As Liittymat.Maksuaineisto.Maksuaineisto)

    Dim strExcelPohja As String = Hakemistot.TemplateHakemisto & Tiedostot.Excelpohja

    Dim ncSarakkeet As New NameValueCollection()

    ncSarakkeet.Add("SopimuksenNimi", "Sopimus")
    ncSarakkeet.Add("Projektinumero", "Projekti")
    ncSarakkeet.Add("KorvauksenProjektinumero", "Korvauksen projektinumero")
    ncSarakkeet.Add("KorvauslaskelmaId", "KL")
    ncSarakkeet.Add("SopimusId", "Sopimusnumero")
    ncSarakkeet.Add("Kirjanpidontunniste", "Yhtiön kirjanpidon tunniste")
    ncSarakkeet.Add("SaajaId", "Asiakastunniste")
    ncSarakkeet.Add("Saaja", "Saaja")
    ncSarakkeet.Add("BicKoodi", "BIC")
    ncSarakkeet.Add("Tilinumero", "Tilinumero")
    ncSarakkeet.Add("Viite", "Viite")
    ncSarakkeet.Add("Viesti", "Viesti")
    ncSarakkeet.Add("KorvauksienMaara", "Korvauksia")
    ncSarakkeet.Add("KorvauksienSummaIlmanAlv", "Korvaus")
    ncSarakkeet.Add("KorvauksienAlv", "Alv")
    ncSarakkeet.Add("KorvauksienSumma", "Korvaus yht")
    ncSarakkeet.Add("OnIndeksi", "Sopimuksella indeksi")
    ncSarakkeet.Add("Indeksityyppi", "Indeksityyppi")
    ncSarakkeet.Add("Indeksikuukausi", "Indeksikuukausi")
    ncSarakkeet.Add("Indeksi", "Indeksin arvo")
    ncSarakkeet.Add("Sopimustyyppi", "Sopimustyyppi")
    ncSarakkeet.Add("Korvaustyyppi", "Korvaustyyppi")
    ncSarakkeet.Add("MaksunSuoritus", "Maksun suoritus")
    ncSarakkeet.Add("MaksajanTilinro", "Yhtiön tilinumero")
    ncSarakkeet.Add("MaksajanBicKoodi", "Yhtiön BIC")
    ncSarakkeet.Add("Palvelutunnus", "Yhtiön palvelutunnus")
    ncSarakkeet.Add("JuridinenYhtioConcession", "Yhtiön concession")
    ncSarakkeet.Add("TypeOfProject", "Type of Project")
    ncSarakkeet.Add("Type", "Type")
    ncSarakkeet.Add("Owner", "Owner")
    ncSarakkeet.Add("Concession", "Concession")
    ncSarakkeet.Add("CertDate", "Cert. Date")
    ncSarakkeet.Add("FieldWorkStartedA", "Field Work Started A")
    ncSarakkeet.Add("ProjectClosedA", "Project Closed A")
    ncSarakkeet.Add("Kustannuspaikka", "RESPONS")
    ncSarakkeet.Add("Kirjanpidontili", "ACCOUNT")
    ncSarakkeet.Add("InvCost", "INVCOST")
    ncSarakkeet.Add("Country", "Country")
    ncSarakkeet.Add("Category", "CATEGORY")

    Dim strExcelVirheellinen As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_VirheellinenAineisto.xlsx"
    Dim strExcelTarkistettava As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_TarkistettavaAineisto.xlsx"
    Dim strExcelMaksettava As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_MaksettavaAineisto.xlsx"


    BLL.ExcelHelper.TeeExcelListasta(Of Maksuraportti)(maksuaineisto.VirheellinenAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelVirheellinen)

    hlExcelVirheellinenAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelVirheellinen

    BLL.ExcelHelper.TeeExcelListasta(Of Maksuraportti)(maksuaineisto.TarkistettavaAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelTarkistettava)

    hlExcelTarkistettavaAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelTarkistettava

    BLL.ExcelHelper.TeeExcelListasta(Of Maksuraportti)(maksuaineisto.MaksettavaAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelMaksettava)

    hlExcelMaksettavaAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelMaksettava

  End Sub

  Private Function HaeMaksuaineisto() As Liittymat.Maksuaineisto.Maksuaineisto

    Dim maksupvm As Date = Date.Now

    If IsDate(txtMaksupvm.Text) Then
      maksupvm = CDate(txtMaksupvm.Text)
    End If

    Dim korvauslaskelmat As IEnumerable(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma) = Me.KorvauslaskelmaHandler.HaeMaksettavatKorvauslaskelmat(Date.Now.Month)

    Dim maksut As IEnumerable(Of Maksu) = Me.MaksuHander.LuoMaksut(korvauslaskelmat, maksupvm, New MaksuaineistoOletustiedot() With {.VuokraCategory = Konfiguraatiot.MaksuaineistoVuokraCategory})

    Dim maksuaineisto As Liittymat.Maksuaineisto.Maksuaineisto = MaksuaineistoHelper.HaeMaksuaineisto(maksut)

    Return maksuaineisto

  End Function

  Protected Sub btnTeeMaksuaineisto_Click(sender As Object, e As EventArgs) Handles btnTeeMaksuaineisto.Click

    Dim maksuaineisto As Liittymat.Maksuaineisto.Maksuaineisto = Me.HaeMaksuaineisto()

    Dim lstPalautteet As New List(Of MaksuaineistoPalaute)()
    Dim palaute As MaksuaineistoPalaute

    Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 10, 0))

      Me.MaksuHander.SaveEntityRange(maksuaineisto.Maksut)

      palaute = MaksuaineistoHelper.LuoMaksuaineistot(maksuaineisto.Maksut, Hakemistot.MaksuaineistoHakemisto)

      If palaute.Ok Then
        scope.Complete()
      Else
        LomakeVirhe.LisaaVirhe(palaute.Virheilmoitus)
      End If

    End Using

    If palaute.Ok Then

      lblTiedot.Text = String.Format("Maksuaineistoja luotu {0} kpl.", palaute.Tiedostot.Count())

      For Each tiedosto As MaksuaineistoTiedosto In palaute.Tiedostot
        lblTiedot.Text &= String.Format("<br>{0}: Maksurivejä yhteensä {1} kpl. Yhteissumma {2} €.", tiedosto.YhtioNimi, tiedosto.Maara.ToString(), Luvut.EsitaNullableDecimal(tiedosto.Summa))
      Next

      Dim naytaMaksuaineistot As Boolean = False

      If Konfiguraatiot.KopioiMaksuaineistoPalvelimelle Then

        For Each tiedosto As MaksuaineistoTiedosto In palaute.Tiedostot

          tiedosto.KopioTiedosto = String.Format(Tiedostot.IfsMaksuTiedostonimiTemplate, tiedosto.YhtioTunnus)

          Try
            File.Copy(tiedosto.Tiedosto, IOUtils.CombinePaths(Konfiguraatiot.MaksuaineistonPolku, tiedosto.KopioTiedosto), False)
          Catch ex As Exception

            naytaMaksuaineistot = True

            LomakeVirhe.LisaaVirhe(String.Format("Tiedostoa {0} ({1}) ei voitu kopioida palvelimelle: {2} Siirrä tiedosto tarvittaessa käsin.", tiedosto.Tiedostonimi, tiedosto.KopioTiedosto, ex.Message))

          End Try

        Next

      End If

      If Konfiguraatiot.NaytaMaksuaineistoKayttajalle Or naytaMaksuaineistot Then
        Me.NaytaMaksuaineistot(palaute.Tiedostot.Select(Function(x) x.Tiedostonimi))
      End If

      If Konfiguraatiot.LahetaSahkopostiMaksuaineistoista Then
        LahetaSahkopostiMaksuaineistosta(palaute)
      End If

    End If

    ' Päivitetään sivuilla oleva maksuaineisto.
    NaytaMaksuaineisto()

  End Sub

  Private Sub NaytaMaksuaineistot(tiedostot As IEnumerable(Of String))

    lvMaksuaineistot.DataSource = tiedostot
    lvMaksuaineistot.DataBind()

  End Sub

  Private Sub lvMaksuaineistot_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvMaksuaineistot.ItemDataBound

    If e.Item.ItemType = ListViewItemType.DataItem Then

      CType(e.Item.FindControl("hlMaksuaineisto"), HyperLink).Text = "Lataa maksuaineisto (" & e.Item.DataItem & ")"
      CType(e.Item.FindControl("hlMaksuaineisto"), HyperLink).NavigateUrl = Hakemistot.MaksuaineistoHakemistoRelatiivinen & e.Item.DataItem

    End If

  End Sub

  Private Sub LahetaSahkopostiMaksuaineistosta(palaute As MaksuaineistoPalaute)

    Dim viesti As String = String.Format("Sopimusrekisterin maksuaineisto on luotu. Yhteensä {1} €.", Luvut.EsitaNullableDecimal(palaute.Tiedostot.Sum(Function(x) x.Summa.GetValueOrDefault(0))))

    viesti &= vbCrLf & vbCrLf

    For Each tiedosto As MaksuaineistoTiedosto In palaute.Tiedostot

      viesti &= tiedosto.KopioTiedosto & " = " & Luvut.EsitaNullableDecimal(tiedosto.Summa) & " €" & vbCrLf

    Next

    Dim emailPalaute As DTO.Palautusarvo

    emailPalaute = Email.Laheta(Konfiguraatiot.MaksuaineistoOsoite, "Sopimusrekisterin maksuaineisto on luotu", viesti)

    If Not emailPalaute.Ok Then
      LomakeVirhe.LisaaVirhe("Sähköpostin lähettäminen osoitteeseen " & Konfiguraatiot.MaksuaineistoOsoite & " epäonnistui")
    End If

  End Sub

  Private Sub gvMaksettavaAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMaksettavaAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    'EstaLinewrap(sender)

  End Sub

  Private Sub gvTarkistettavaAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTarkistettavaAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    'EstaLinewrap(sender)

  End Sub

  Private Sub gvVirheellinenAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvVirheellinenAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    'EstaLinewrap(sender)

  End Sub

  Private Sub EstaLinewrap(taulukko As GridView)
    For Each rivi In taulukko.Rows
      For Each sarake In rivi.Cells
        sarake.Attributes.Add("style", "white-space: nowrap;")
      Next
    Next
  End Sub

  Private Sub MuokkaaTaulukonLinkkeja(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

    If e.Row.RowType = DataControlRowType.DataRow Then

      Dim rivi = DirectCast(e.Row.DataItem, Maksuraportti)

      CType(e.Row.FindControl("hlSopimus"), HyperLink).NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.SopimusId)
      CType(e.Row.FindControl("hlKorvauslaskelma"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", rivi.KorvauslaskelmaId, rivi.SopimusId)

    End If

  End Sub

  Protected Sub btnPaivitaMaksuaineisto_Click(sender As Object, e As EventArgs) Handles btnPaivitaMaksuaineisto.Click

    NaytaMaksuaineisto()

  End Sub

  Public ReadOnly Property KorvauslaskelmaHandler As KorvauslaskelmaHandler
    Get
      If Me._korvauslaskelmaHander Is Nothing Then
        Me._korvauslaskelmaHander = New KorvauslaskelmaHandler(Me.DataContext)
      End If

      Return Me._korvauslaskelmaHander
    End Get
  End Property

  Public ReadOnly Property MaksuHander As MaksuHandler
    Get
      If Me._maksuHandler Is Nothing Then
        Me._maksuHandler = New MaksuHandler(Me.DataContext)
      End If

      Return Me._maksuHandler
    End Get
  End Property

End Class