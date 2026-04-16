Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils
Imports Sopimusrekisteri.DAL_CF

Namespace Taho.Organisaatio

    Public Class Muokkaa
        Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Taho)

        Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not IsPostBack Then

                Me.AlustaSivu()
                AsetaValidaatiot()

                If Not Me.IsNewEntity Then

                    Me.TaytaLomake()

                Else

                    Me.AsetaOletustiedot()

                End If

            End If

        End Sub

        Private Sub AsetaValidaatiot()

            rvSukunimi.Enabled = IsNewEntity
            rvPuhelin.Enabled = IsNewEntity
            rvPostituspostitmp.Enabled = IsNewEntity
            rvPostituspostinro.Enabled = IsNewEntity
            rvPostitusosoite.Enabled = IsNewEntity

        End Sub

        Private Sub AlustaSivu()

            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.Maa)(MaaId, Me.Handlers.Maat.GetAll(), AddressOf UiHelper.LuoListItemMaa, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.Kunta)(KuntaId, Me.Handlers.Kunnat.GetAll(), AddressOf UiHelper.LuoListItemKunta, AddressOf UiHelper.LuoTyhjaListItem)
            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.BicKoodi)(BicKoodiId, Me.Handlers.BicKoodit.GetAll(), AddressOf UiHelper.LuoListItemBicKoodi, AddressOf UiHelper.LuoTyhjaListItem)

            Dim tyypit As IEnumerable(Of OrganisaationTyyppi)

            'ihme kikkailua, teen joskus paremmin, terv. JH
            If Not Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasLaaja) Then

                If Not Me.IsNewEntity AndAlso Me.Entity.OrganisaationTyyppiId = Organisaatiotyypit.JuridinenYhtio Then
                    tyypit = Me.Handlers.OrganisaationTyypit.GetAll()
                    OrganisaationTyyppiId.Enabled = False
                Else
                    tyypit = Me.Handlers.OrganisaationTyypit.GetAllFiltered()
                End If
            Else
                tyypit = Me.Handlers.OrganisaationTyypit.GetAll()
            End If

            WebUtils.DataBindList(Of Sopimusrekisteri.BLL_CF.OrganisaationTyyppi)(OrganisaationTyyppiId, tyypit, AddressOf UiHelper.LuoListItemOrganisaationTyyppi, AddressOf UiHelper.LuoTyhjaListItem)

            Infopallurat.AsetaInfopallurat(Me)

        End Sub

        Private Sub AsetaOletustiedot()


        End Sub

        Private Sub TaytaLomake()

            Me.FormMapper.FillForm(Me.formData, Me.Entity)

        End Sub

        Private Sub Tallenna()

            Me.FormMapper.FillObject(formData, Me.Entity, String.Empty)

            If Me.IsNewEntity Then
                Me.Entity.TyyppiId = TahoTyypit.Organisaatio
            End If

            Me.EntityHandler.SaveEntity(Me.Entity)

        End Sub

        Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

            If Page.IsValid() Then

                Me.Tallenna()

                If Me.SopimusId.HasValue Then
                    If Me.IsNewEntity Then
                        Response.Redirect(String.Format("~/Taho/Sopimustaho.aspx?sopimusId={0}&tahoId={1}", Me.SopimusId.ToString(), Me.Entity.Id.ToString()))
                    Else
                        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}&asiakasid={1}", Me.SopimusId.ToString(), Me.Entity.Id.ToString()))
                    End If
                Else
                    Response.Redirect(String.Format("~/Taho/Organisaatio/Tiedot.aspx?id={0}", Me.Entity.Id.ToString()))
                End If

            End If

        End Sub

        Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

            If Not Me.IsNewEntity Then
                Response.Redirect(String.Format("~/Taho/Organisaatio/Tiedot.aspx?id={0}", Me.EntityId.ToString()))
            ElseIf Me.SopimusId.HasValue Then
                Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.ToString()))
            Else
                Response.Redirect("~/Etusivu.aspx")
            End If

        End Sub

        Protected Sub btnHaePostitoimipaikka_Click(sender As Object, e As EventArgs) Handles btnHaePostitoimipaikka.Click

            If Not String.IsNullOrWhiteSpace(Postituspostinro.Text) Then

                Dim postitiedot As Postitiedot = Me.Handlers.Postitiedot.LoadEntity(Postituspostinro.Text.Trim())

                If Not postitiedot Is Nothing Then

                    Postituspostitmp.Text = postitiedot.Postitoimipaikka

                    If postitiedot.Kuntaid.HasValue Then
                        KuntaId.SelectedValue = postitiedot.Kuntaid.ToString()
                    End If

                End If

            End If

        End Sub

        Protected Sub Tilinumero_TextChanged(sender As Object, e As EventArgs) Handles Tilinumero.TextChanged

            If Not String.IsNullOrEmpty(Tilinumero.Text) Then

                Tilinumero.Text = Common.StringTyokalut.PoistaValilyonnit(Tilinumero.Text)

                If Not Common.Tilinumerot.OnIbanTilinumero(Tilinumero.Text) Then

                    Dim strIban As String = Common.Tilinumerot.MuunnaIBANMuotoon(Tilinumero.Text)

                    If Not String.IsNullOrEmpty(strIban) Then
                        Tilinumero.Text = strIban
                    End If

                End If

                If Common.Tilinumerot.OnValidiIbanTilinumero(Tilinumero.Text) AndAlso Common.Tilinumerot.OnSuomalainenIbanTilinumero(Tilinumero.Text) Then

                    Dim tietokanta As New BLL.Haku()
                    Dim strRahalaitostunnus As String = tietokanta.HaeRahalaitosTunnus(Tilinumero.Text)
                    Dim bicKoodi As appSopimusrekisteri.DTO.iHakutulos = tietokanta.HaeBicKoodi(strRahalaitostunnus)

                    If Not bicKoodi Is Nothing Then
                        BicKoodiId.SelectedValue = bicKoodi.ID
                    End If

                Else

                    BicKoodiId.SelectedValue = String.Empty

                End If

            Else

                BicKoodiId.SelectedValue = String.Empty

            End If

        End Sub

        Protected Sub CusValTAHTilinumero_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CusValTilinumero.ServerValidate

            Dim boo As Boolean = True

            If Not String.IsNullOrEmpty(Tilinumero.Text) Then

                boo = Common.Tilinumerot.OnValidiIbanTilinumero(Tilinumero.Text)

            End If

            args.IsValid = boo

        End Sub

        Protected ReadOnly Property SopimusId As Integer?
            Get

                Return DataUtils.ParseValue(Of Integer?)(Request.Params("sopimusid"))

            End Get
        End Property

        Protected Overrides Function CreateDataContext() As KiltaDataContext
            If Roles.IsUserInRole(Konfiguraatio.Roolit.AsiakasLaaja) Then
                Return New KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Context.User.Identity.Name) With {.Taso = KayttooikeusTaso.Laaja})
            Else
                Return New KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Context.User.Identity.Name) With {.Taso = KayttooikeusTaso.Suppea})
            End If
        End Function

    End Class

End Namespace