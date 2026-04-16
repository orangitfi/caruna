Imports System.IO
Imports Sopimusrekisteri.DAL_CF.Repositories

Public Class TiedostoExcelTuonti
    Inherits BasePage2

#Region "Propertyt"

    Private _repo As TiedostoTuontiRepository

    Private ReadOnly Property AllowedEndings As String() = New String() {
        ".xlsx"
    }

    Private ReadOnly Property Repository As TiedostoTuontiRepository
        Get
            If _repo Is Nothing Then
                _repo = New TiedostoTuontiRepository(Konfiguraatiot.ConnectionString)
            End If
            Return _repo
        End Get
    End Property

    Private ReadOnly Property Sessio As String
        Get
            Return Request.QueryString("guid")
        End Get
    End Property

#End Region

#Region "Sivun alustus"

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Ohjaustiedot) Then
            Response.Redirect("~/Ohjaustiedot/Ohjaustiedot.aspx")
            Return
        End If

        JavascriptAvustaja.LisaaTuplaklikinEsto(btnEsikatsele, Me)
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnTuo, Me)

        If Not Page.IsPostBack() Then
            AlustaSivu()
        End If

    End Sub

    Private Sub AlustaSivu()

        If Not String.IsNullOrEmpty(Sessio) Then
            NaytaTiedot(Sessio)
        End If

    End Sub

#End Region

#Region "Tuonti"

    Private Function InsertTiedot() As String

        Dim path = Server.MapPath(TallennaTiedosto())
        Dim ds As DataSet = ExcelReader.ExcelToDatasetClosedXML(path)
        Dim guid = System.Guid.NewGuid().ToString()

        Repository.TuoValitauluun(ds.Tables(0), guid, User.Identity.Name)

        Return guid

    End Function

    Private Sub PaivitaTiedot()

        If String.IsNullOrEmpty(Sessio) Then
            Throw New Exception("Guidia ei annettu.")
        End If

        Repository.TuoTiedot(Sessio, User.Identity.Name)

        lblOnnistunut.Visible = True
        phTulokset.Visible = False
        lblTuntematonVirhe.Visible = False

    End Sub

    Private Sub NaytaTiedot(strGuid As String)

        phTulokset.Visible = True

        Dim lisattavia = Repository.HaeLisattavienLkm(strGuid)
        Dim paivitettavia = Repository.HaePaivitettavienLkm(strGuid)

        lblUusia.Text = lisattavia
        lblPaivitettavia.Text = paivitettavia
        lblYhteensa.Text = lisattavia + paivitettavia

    End Sub

#End Region

#Region "Apufunktiot"

    Private Function TallennaTiedosto() As String

        Dim virtualPath = "~/Import/Excel/Tiedostot/"
        Dim fullPath = virtualPath + fuTiedosto.FileName

        Dim absolutePath = Server.MapPath(virtualPath)

        If Not Directory.Exists(absolutePath) Then
            Directory.CreateDirectory(absolutePath)
        End If

        File.WriteAllBytes(Server.MapPath(fullPath), fuTiedosto.FileBytes)

        Return fullPath

    End Function

    Private Sub KasitteleException(ex As Exception)

        phTulokset.Visible = False
        lblOnnistunut.Visible = False
        lblTuntematonVirhe.Visible = True
        lblTuntematonVirhe.Text = "Sovelluksessa tapahtui tuntematon virhe. Tarkista että kaikilla riveillä Vault ja Object on annettu ja ne on GUID/UUID muodossa. Virheen tiedot: " & ex.Message

    End Sub

    Private Sub KasitteleExceptionViallinen(ex As Exception)

        phTulokset.Visible = False
        lblOnnistunut.Visible = False
        lblTuntematonVirhe.Visible = True
        lblTuntematonVirhe.Text = "Antamasi excelistä voi puuttua tiettyjä metadatoja. Avaa excel tiedosto, tallenna se kerran ja yritä uudelleen. Virheen tarkemmat tiedot: " & ex.Message

    End Sub

#End Region

#Region "Tapahtumakäsittelijät"

    Protected Sub btnEsikatsele_Click(sender As Object, e As EventArgs)

        Try

            Page.Validate()

            If Page.IsValid Then
                Dim guid = InsertTiedot()
                Response.Redirect(Request.Url.GetLeftPart(UriPartial.Path) & "?guid=" & guid)
            End If

        Catch ex As Exception

            KasitteleExceptionViallinen(ex)

        End Try

    End Sub

    Protected Sub btnTuo_Click(sender As Object, e As EventArgs)

        Try

            PaivitaTiedot()

        Catch ex As Exception

            KasitteleException(ex)

        End Try

    End Sub

    Protected Sub cvTiedosto_ServerValidate(source As Object, args As ServerValidateEventArgs)

        ' Tarkistetaan että tiedosto on excel
        If fuTiedosto.HasFile Then
            Dim ending = Path.GetExtension(fuTiedosto.FileName)
            args.IsValid = AllowedEndings.Contains(ending)
        Else
            args.IsValid = False
        End If

    End Sub

#End Region

End Class