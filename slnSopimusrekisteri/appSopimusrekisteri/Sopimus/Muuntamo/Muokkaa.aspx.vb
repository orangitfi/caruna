Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils

Namespace Sopimus.Muuntamo

    Public Class Muokkaa
        Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Sopimus)

        Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then

                Me.AsetaNakyvyydet()
                Me.AlustaSivu()
                Me.AsetaValidaatiot()

                If Not Me.IsNewEntity Then

                    Me.TaytaLomake()

                Else

                    Me.AsetaOletustiedot()

                End If

            End If

        End Sub

        Private Sub AsetaValidaatiot()

            rvPCSNumero.Enabled = IsNewEntity
            rvJuridinenyhtio.Enabled = IsNewEntity
            rvSopimuksenLaatija.Enabled = IsNewEntity

            cvSopimuksenTilaTilinumerot.Enabled = IsNewEntity
            cvSopimuksenTilaId.Enabled = IsNewEntity

        End Sub

        Private Sub AsetaNakyvyydet()

            phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.SopimusLaaja)
            phIFRS.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.IFRS)

        End Sub

        Private Sub AlustaSivu()

            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.Taho)(AlkuperainenYhtioId, Me.Handlers.Tahot.GetYhtiot(), AddressOf UiHelper.LuoListItemTaho, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of DFRooli)(DFRooliId, Me.Handlers.DFRoolit.GetAll(), AddressOf UiHelper.LuoListItemDFRooli, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.Taho)(JuridinenYhtioId, Me.Handlers.Tahot.GetJuridisetYhtiot(), AddressOf UiHelper.LuoListItemTaho, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Julkisuusaste)(JulkisuusasteId, Me.Handlers.Julkisuusasteet.GetAll(), AddressOf UiHelper.LuoListItemJulkisuusaste, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Kieli)(KieliId, Me.Handlers.Kielet.GetAll(), AddressOf UiHelper.LuoListItemKieli, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Kohdekategoria)(KohdekategoriaId, Me.Handlers.Kohdekategoriat.GetAll(), AddressOf UiHelper.LuoListItemKohdekategoria, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of SopimuksenAlaluokka)(SopimuksenAlaluokkaId, Me.Handlers.SopimuksenAlaluokat.GetAll(), AddressOf UiHelper.LuoListItemSopimuksenAlaluokka, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of SopimuksenEhtoversio)(SopimuksenEhtoversioId, Me.Handlers.SopimuksenEhtoversiot.GetAll(), AddressOf UiHelper.LuoListItemSopimuksenEhtoversio, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of SopimuksenTila)(SopimuksenTilaId, Me.Handlers.SopimuksenTilat.GetAll(), AddressOf UiHelper.LuoListItemSopimuksenTila, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Sopimustyyppi)(SopimustyyppiId, Me.Handlers.Sopimustyypit.GetAll(), AddressOf UiHelper.LuoListItemSopimustyyppi, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of SiirtoOikeus)(VastaosapuoliSiirtoOikeusId, Me.Handlers.SiirtoOikeudet.GetAll(), AddressOf UiHelper.LuoListItemSiirtoOikeus, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of SiirtoOikeus)(VerkonhaltijaSiirtoOikeusId, Me.Handlers.SiirtoOikeudet.GetAll(), AddressOf UiHelper.LuoListItemSiirtoOikeus, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of YlasopimuksenTyyppi)(YlasopimuksenTyyppiId, Me.Handlers.YlasopimuksenTyypit.GetAll(), AddressOf UiHelper.LuoListItemYlasopimuksenTyyppi, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Vuokratyyppi)(VuokratyyppiId, Me.Handlers.Vuokratyypit.GetAll(), AddressOf UiHelper.LuoListItemVuokratyyppi, AddressOf UiHelper.LuoTyhjaListItem)

            Select Case Me.Tyyppi
                Case Sopimustyypit.Muuntamosopimus
                    lblOtsikko.Text = "Muuntamosopimuksen tiedot"
                Case Sopimustyypit.Kiinteistomuuntamosopimus
                    lblOtsikko.Text = "Kiinteistömuuntamosopimuksen tiedot"
            End Select

            Infopallurat.AsetaInfopallurat(Me)

            PaasopimusId.Enabled = False

            If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Admin) Or Me.IsNewEntity Then
                SopimustyyppiId.Enabled = False
            End If

        End Sub

        Private Sub AsetaOletustiedot()

            KieliId.SelectedValue = Kielet.Suomi.ToString()
            SopimuksenTilaId.SelectedValue = SopimusTilat.Luonnos.ToString()

            SopimustyyppiId.SelectedValue = Me.Tyyppi.ToString()

            If Me.KopioId.HasValue Then
                Me.FormMapper.FillForm(Me.formData, Me.Handlers.Sopimukset.CopyEntity(Me.KopioId.Value))

                Luotu.Text = String.Empty

            End If

            Select Case Me.Tyyppi
                Case Sopimustyypit.Muuntamosopimus
                    lblSopimusnro.Text = "Uusi muuntamosopimus"
                Case Sopimustyypit.Kiinteistomuuntamosopimus
                    lblSopimusnro.Text = "Uusi kiinteistömuuntamosopimus"
            End Select

            If Me.YlasopimusId.HasValue Then
                Me.AsetaYlasopimus(Me.YlasopimusId.Value)

                PaasopimusId.SelectedValue = Me.YlasopimusId.Value
            End If

        End Sub

        Private Sub AsetaYlasopimus(ylasopimusId As Integer)

            YlasopimuksenTyyppiId.Enabled = False

            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.Sopimus)(PaasopimusId, {Me.Handlers.Sopimukset.LoadEntity(ylasopimusId)}, AddressOf UiHelper.LuoListItemSopimus, AddressOf UiHelper.LuoTyhjaListItem)

        End Sub

        Private Sub TaytaLomake()

            If Me.Entity.PaasopimusId.HasValue Then
                Me.AsetaYlasopimus(Me.Entity.PaasopimusId.Value)
            End If

            Me.FormMapper.FillForm(Me.formData, Me.Entity)

            Korkoprosentti.Text = Entity.Korkoprosentti?.ToString("0.000000")
            lblSopimusnro.Text = Me.Entity.Id.ToString()

        End Sub

        Private Sub Tallenna()

            Me.FormMapper.FillObject(formData, Me.Entity, String.Empty)

            Me.EntityHandler.SaveEntity(Me.Entity)

            If Me.KiinteistoId.HasValue Then
                Me.Handlers.SopimusKiinteistot.LisaaKiinteistoSopimukselle(Me.Entity.Id, Me.KiinteistoId)
            End If

        End Sub

        Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

            If Page.IsValid() Then

                Me.Tallenna()

                Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.Entity.Id.ToString()))

            End If

        End Sub

        Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

            If Not Me.IsNewEntity Then
                Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.EntityId.ToString()))
            ElseIf Me.KopioId.HasValue Then
                Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.KopioId.ToString()))
            ElseIf Me.KiinteistoId.HasValue Then
                Response.Redirect(String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", Me.KiinteistoId.ToString()))
            Else
                Response.Redirect("~/Etusivu.aspx")
            End If

        End Sub

        Protected ReadOnly Property KiinteistoId As Integer?
            Get

                Return DataUtils.ParseValue(Of Integer?)(Request.Params("kiinteistoId"))

            End Get
        End Property

        Protected ReadOnly Property KopioId As Integer?
            Get

                If Me.YlasopimusId.HasValue Then
                    Return Me.YlasopimusId
                End If

                Return DataUtils.ParseValue(Of Integer?)(Request.Params("kopioId"))

            End Get
        End Property

        Protected ReadOnly Property Tyyppi As Sopimustyypit
            Get

                If Not Me.IsNewEntity Then
                    Return Me.Entity.SopimustyyppiId
                End If

                Return DataUtils.ParseEnum(Of Sopimustyypit)(Request.Params("tyyppi"))

            End Get
        End Property

        Protected ReadOnly Property YlasopimusId As Integer?
            Get

                Return DataUtils.ParseValue(Of Integer?)(Request.Params("ylasopimusId"))

            End Get
        End Property

        Protected Sub cvSopimuksenTilaId_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvSopimuksenTilaId.ServerValidate

            Dim isValid As Boolean = True

            If DataUtils.ParseEnum(Of SopimusTilat)(Me.SopimuksenTilaId.SelectedValue) = SopimusTilat.Voimassa Then

                If Not Me.AsiakkaanAllekirjoitusPvm.DateValue.HasValue Or Not Me.VerkonhaltijanAllekirjoitusPvm.DateValue.HasValue Then
                    isValid = False
                End If

            End If

            args.IsValid = isValid

        End Sub

        Protected Sub cvSopimuksenTilaTilinumerot_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvSopimuksenTilaTilinumerot.ServerValidate
            Dim isValid As Boolean = True
            If DataUtils.ParseEnum(Of SopimusTilat)(Me.SopimuksenTilaId.SelectedValue) = SopimusTilat.Voimassa Then
                If Not Entity.Korvauslaskelmat Is Nothing AndAlso Entity.Korvauslaskelmat.Any(Function(x) x.Saaja Is Nothing OrElse (x.Saaja.Tilinumero = "" And x.Saaja.TyyppiId <> TahoTyypit.Organisaatio)) Then
                    isValid = False
                End If
            End If

            args.IsValid = isValid
        End Sub

        Protected Sub cvPylvasvali_ServerValidate(source As Object, args As ServerValidateEventArgs)
            args.IsValid = True

            Dim splitted As String() = Pylvasvali.Text.Split("-")
            If Not String.IsNullOrEmpty(Pylvasvali.Text) AndAlso (splitted.Length = 1 Or splitted.Length = 2) Then
                Dim first, second As Integer
                If Not Integer.TryParse(splitted(0).Trim(), first) Then
                    args.IsValid = False
                End If

                If splitted.Length = 2 AndAlso Not Integer.TryParse(splitted(1).Trim(), second) Then
                    args.IsValid = False
                End If
            ElseIf Not String.IsNullOrEmpty(Pylvasvali.Text) Then
                args.IsValid = False
            End If
        End Sub

        Protected Sub cusKorkoprosentti_ServerValidate(source As Object, args As ServerValidateEventArgs)

            Dim luku = DataUtils.ParseDecimal(Korkoprosentti.Text, 0)

            args.IsValid = luku >= 0 AndAlso luku <= 100

        End Sub

        Protected Sub btnLaskeKorkoprosentti_Click(sender As Object, e As EventArgs)

            Dim korko = Handlers.Korkoprosentit.HaeKorkoprosentti(Alkaa.DateValue, Paattyy.DateValue)

            If Not korko Is Nothing Then

                Korkoprosentti.Text = korko.Prosentti.ToString("0.000000")

            End If

        End Sub

    End Class

End Namespace