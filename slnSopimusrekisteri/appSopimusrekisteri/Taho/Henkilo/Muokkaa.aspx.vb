Imports appSopimusrekisteri.DTO

Public Class HenkilonMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            TaytaPudotusvalikot()
            Infopallurat.AsetaInfopallurat(Me)
            AsetaValidaatiot()

            Dim id As String = Request.Params("id")

            If IsNumeric(id) Then

                Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo(_konteksti)
                Dim henkilo = tietokanta.HaeHenkilo(id)
                If Not henkilo Is Nothing Then
                    If henkilo.TAHTyyppiId = Enumeraattorit.TahoTyyppi.Henkilo Then
                        TaytaLomake(henkilo)
                        TaytaMuokkaustiedot(henkilo)
                    Else
                        ' TODO: Virheilmoitus!
                    End If
                Else
                    ' TODO: Virheilmoitus!
                End If
            Else
                Pudotusvalikko.ValitseTekstinPerusteella(ddTAHMaaId, "Suomi")
            End If

        End If

    End Sub

    Private Sub AsetaValidaatiot()

        Dim id = Request.Params("id")
        Dim isNewEntity = Not (Not String.IsNullOrEmpty(id) And IsNumeric(id))

        rvtxtTAHEtunimi.Enabled = isNewEntity
        rvtxtTAHSukunimi.Enabled = isNewEntity
        rvtxtTAHPostituspostitmp.Enabled = isNewEntity
        rvtxtTAHPostituspostinro.Enabled = isNewEntity
        rvtxtTAHPostitusosoite.Enabled = isNewEntity
        rvtxtTAHPuhelin.Enabled = isNewEntity

    End Sub

    Private Sub TaytaMuokkaustiedot(henkilo As Entities.Taho)

        lblTAHPaivitetty.Text = Paivaykset.PalautaPaivays(henkilo.TAHPaivitetty)
        lblTAHPaivittaja.Text = henkilo.TAHPaivittaja
        lblTAHLuotu.Text = Paivaykset.PalautaPaivays(henkilo.TAHLuotu)
        lblTAHLuoja.Text = henkilo.TAHLuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaPudotusvalikot()

        Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
        ddTAHMaaId.DataSource = tietokanta.HaeMaat()
        ddTAHMaaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddTAHMaaId.DataBind()
        ddTAHKuntaId.DataSource = tietokanta.HaeKunnat()
        ddTAHKuntaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddTAHKuntaId.DataBind()
        ddTAHBicKoodiId.DataSource = tietokanta.HaeBicKoodit()
        ddTAHBicKoodiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddTAHBicKoodiId.DataBind()

    End Sub

    Private Sub TaytaLomake(henkilo As Entities.Taho)

        lblAsiakastyyppi.Text = "Henkilö"
        txtTAHEtunimi.Text = henkilo.TAHEtunimi
        txtTAHSukunimi.Text = henkilo.TAHSukunimi
        txtTAHEmail.Text = henkilo.TAHEmail
        txtTAHPostitusosoite.Text = henkilo.TAHPostitusosoite
        txtTAHPostituspostinro.Text = henkilo.TAHPostituspostinro
        txtTAHPostituspostitmp.Text = henkilo.TAHPostituspostitmp
        txtTAHPuhelin.Text = henkilo.TAHPuhelin
        txtTAHTilinumero.Text = henkilo.TAHTilinumero
        txtTAHBic.Text = henkilo.TAHBic
        txtTAHNimitarkenne.Text = henkilo.TAHNimitarkenne

        txtTAHInfo.Text = henkilo.TAHInfo

        Pudotusvalikko.Valitse(ddTAHKuntaId, henkilo.TAHKuntaId)
        If henkilo.TAHMaaId Is Nothing Then
            Pudotusvalikko.ValitseTekstinPerusteella(ddTAHMaaId, "Suomi")
        Else
            Pudotusvalikko.Valitse(ddTAHMaaId, henkilo.TAHMaaId)
        End If
        Pudotusvalikko.Valitse(ddTAHBicKoodiId, henkilo.TAHBicKoodiId)

    End Sub

    Private Function LuoHenkilo() As Entities.Taho

        Dim henkilo = New Entities.Taho()
        henkilo.TAHTyyppiId = Enumeraattorit.TahoTyyppi.Henkilo
        henkilo.TAHEtunimi = txtTAHEtunimi.Text
        henkilo.TAHSukunimi = txtTAHSukunimi.Text
        henkilo.TAHAlvVelvollinen = False
        henkilo.TAHEmail = txtTAHEmail.Text
        henkilo.TAHPostitusosoite = txtTAHPostitusosoite.Text
        henkilo.TAHPostituspostinro = txtTAHPostituspostinro.Text
        henkilo.TAHPostituspostitmp = txtTAHPostituspostitmp.Text
        henkilo.TAHPuhelin = txtTAHPuhelin.Text
        henkilo.TAHTilinumero = txtTAHTilinumero.Text
        henkilo.TAHYtunnus = String.Empty
        henkilo.TAHMaaId = Pudotusvalikko.HaeValittuArvo(ddTAHMaaId)
        henkilo.TAHKuntaId = Pudotusvalikko.HaeValittuArvo(ddTAHKuntaId)
        henkilo.TAHBic = txtTAHBic.Text
        henkilo.TAHNimitarkenne = txtTAHNimitarkenne.Text
        henkilo.TAHInfo = txtTAHInfo.Text
        henkilo.TAHBicKoodiId = Pudotusvalikko.HaeValittuArvo(ddTAHBicKoodiId)
        Return henkilo

    End Function

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo(_konteksti)
            Dim henkilo = LuoHenkilo()

            ' Hae URL:ista henkilön tunniste, jonka pohjalta päätämme 
            ' lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                henkilo.TAHTahoId = Request.Params("id")
                henkilo = tietokanta.MuokkaaHenkiloa(henkilo)
                If Not henkilo Is Nothing Then
                    If IsNumeric(Request.Params("sopimusid")) Then
                        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}&asiakasid={1}", Request.Params("sopimusid"), henkilo.TAHTahoId))
                    Else
                        Response.Redirect(String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}", henkilo.TAHTahoId))
                    End If
                End If
            Else
                henkilo = tietokanta.LisaaHenkilo(henkilo)
                If Not henkilo Is Nothing Then
                    If IsNumeric(Request.Params("sopimusid")) Then
                        Response.Redirect(String.Format("~/Taho/Sopimustaho.aspx?sopimusId={0}&tahoId={1}", Request.Params("sopimusid"), henkilo.TAHTahoId))
                    Else
                        Response.Redirect(String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}", henkilo.TAHTahoId))
                    End If
                End If
            End If

        Else
            'TODO: Error message.
        End If

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

        If IsNumeric(Request.Params("sopimusid")) Then
            Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Request.Params("sopimusid")), True)
        End If

        If IsNumeric(Request.Params("id")) Then
            Response.Redirect(String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}", Request.Params("id")), True)
        End If

        Response.Redirect("~/Etusivu.aspx", True)

    End Sub

    Protected Sub btnHaePostitoimipaikka_Click(sender As Object, e As EventArgs) Handles btnHaePostitoimipaikka.Click

        If Not String.IsNullOrWhiteSpace(txtTAHPostituspostinro.Text) Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
            Dim postitiedot = tietokanta.HaePostitiedot(txtTAHPostituspostinro.Text.Trim())

            If Not postitiedot Is Nothing Then

                txtTAHPostituspostitmp.Text = postitiedot.Postitoimipaikka
                Pudotusvalikko.Valitse(ddTAHKuntaId, postitiedot.KuntaId)

            End If
        Else
            ' TODO: Virheilmoitus.
        End If

    End Sub

    Protected Sub txtTAHTilinumero_TextChanged(sender As Object, e As EventArgs) Handles txtTAHTilinumero.TextChanged

        If Not String.IsNullOrEmpty(txtTAHTilinumero.Text) Then

            txtTAHTilinumero.Text = Common.StringTyokalut.PoistaValilyonnit(txtTAHTilinumero.Text)

            If Not Common.Tilinumerot.OnIbanTilinumero(txtTAHTilinumero.Text) Then

                Dim strIban As String = Common.Tilinumerot.MuunnaIBANMuotoon(txtTAHTilinumero.Text)

                If Not String.IsNullOrEmpty(strIban) Then
                    txtTAHTilinumero.Text = strIban
                End If

            End If

            If Common.Tilinumerot.OnValidiIbanTilinumero(txtTAHTilinumero.Text) AndAlso Common.Tilinumerot.OnSuomalainenIbanTilinumero(txtTAHTilinumero.Text) Then

                Dim tietokanta As New BLL.Haku()
                Dim strRahalaitostunnus As String = tietokanta.HaeRahalaitosTunnus(txtTAHTilinumero.Text)
                Dim bicKoodi As iHakutulos = tietokanta.HaeBicKoodi(strRahalaitostunnus)

                If Not bicKoodi Is Nothing Then
                    ddTAHBicKoodiId.SelectedValue = bicKoodi.ID
                End If

            Else

                Pudotusvalikko.Valitse(ddTAHBicKoodiId, -1)

            End If

        Else

            Pudotusvalikko.Valitse(ddTAHBicKoodiId, -1)

        End If

    End Sub

    Protected Sub CusValTAHTilinumero_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles CusValTAHTilinumero.ServerValidate

        Dim boo As Boolean = True

        If Not String.IsNullOrEmpty(txtTAHTilinumero.Text) Then

            boo = Common.Tilinumerot.OnValidiIbanTilinumero(txtTAHTilinumero.Text)

        End If

        args.IsValid = boo

    End Sub

End Class