Public Class KiinteistonMuokkaus
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            TaytaPudotusvalikot()

            AsetaOikeudet()
            Infopallurat.AsetaInfopallurat(Me)
            AsetaValidaatiot()

            Dim id As String = Request.Params("id")

            If IsNumeric(id) Then
                Dim tietokanta = New appSopimusrekisteri.BLL.Kiinteisto(_konteksti)
                Dim kiinteisto = tietokanta.HaeKiinteisto(id)
                If Not kiinteisto Is Nothing Then
                    TaytaLomake(kiinteisto)
                    TaytaMuokkaustiedot(kiinteisto)
                Else
                    'TODO: Virheilmoitus!
                End If
            Else
                Pudotusvalikko.ValitseTekstinPerusteella(ddKIIMaaId, "Suomi")
            End If

        End If

    End Sub

    Private Sub AsetaValidaatiot()

        Dim id = Request.Params("id")
        Dim isNewEntity = Not (Not String.IsNullOrEmpty(id) And IsNumeric(id))

        rvtxtKIIKiinteistotunnus.Enabled = isNewEntity

    End Sub

    Private Sub AsetaOikeudet()

        phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KiinteistoLaaja)

    End Sub

    Private Sub TaytaMuokkaustiedot(kiinteisto As Entities.Kiinteisto)

        lblKIIPaivitetty.Text = Paivaykset.PalautaPaivays(kiinteisto.KIIPaivitetty)
        lblKIIPaivittaja.Text = kiinteisto.KIIPaivittaja
        lblKIILuotu.Text = Paivaykset.PalautaPaivays(kiinteisto.KIILuotu)
        lblKIILuoja.Text = kiinteisto.KIILuoja
        phPaivitystiedot.Visible = True

    End Sub

    Private Sub TaytaPudotusvalikot()

        Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
        ddKIIMaaId.DataSource = tietokanta.HaeMaat()
        ddKIIMaaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddKIIMaaId.DataBind()
        ddKIIKuntaId.DataSource = tietokanta.HaeKunnat()
        ddKIIKuntaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddKIIKuntaId.DataBind()
        'ddKIIKylaId.DataSource = tietokanta.HaeKylat()
        'ddKIIKylaId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        'ddKIIKylaId.DataBind()
        ddKIISaantoId.DataSource = tietokanta.HaeSaannot()
        ddKIISaantoId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddKIISaantoId.DataBind()
        ddKIILiiketoiminnanTarveId.DataSource = tietokanta.HaeLiiketoiminnanTarpeet()
        ddKIILiiketoiminnanTarveId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos())
        ddKIILiiketoiminnanTarveId.DataBind()

    End Sub

    Private Sub TaytaLomake(kiinteisto As Entities.Kiinteisto)

        txtKIIKortteli.Text = kiinteisto.KIIKortteli
        txtKIITontti.Text = kiinteisto.KIITontti
        txtKIIMaaraAla.Text = kiinteisto.KIIMaaraAla
        txtKIIKatuosoite.Text = kiinteisto.KIIKatuosoite
        txtKIIPostinumero.Text = kiinteisto.KIIPostinumero
        txtKIIPostitoimipaikka.Text = kiinteisto.KIIPostitoimipaikka
        txtKIIMaapintaAla.Text = Luvut.EsitaNullableDecimal(kiinteisto.KIIMaapintaAla)
        txtKIIVesipintaAla.Text = Luvut.EsitaNullableDecimal(kiinteisto.KIIVesipintaAla)
        txtKIIPintaAla.Text = Luvut.EsitaNullableDecimal(kiinteisto.KIIPintaAla)
        txtKIIKiinteistoverotettuVuosi.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIKiinteistoverotettuVuosi)
        txtKIIAssetTunniste.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIAssetTunniste)
        txtKIIOmistusosuus.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIOmistusosuus)
        txtKIIRasitteet.Text = kiinteisto.KIIRasitteet
        txtKIIKiinnitykset.Text = kiinteisto.KIIKiinnitykset
        txtKIIInfo.Text = kiinteisto.KIIInfo
        txtKIIKiinteisto.Text = kiinteisto.KIIKiinteisto
        'txtKIIRekisterinumero.Text = kiinteisto.KIIRekisterinumero
        txtKIIKiinteistotunnus.Text = kiinteisto.KIIKiinteistotunnus
        'txtKIIKiinteistotunnusLyhyt.Text = kiinteisto.KIIKiinteistotunnusLyhyt
        txtKIIKyla.Text = kiinteisto.KIIKyla
        txtKIIKylanumero.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIKylanumero)
        txtKIIKuntanumero.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIKuntanumero)
        txtKIIOmistusosuusTotal.Text = Luvut.EsitaNullableInteger(kiinteisto.KIIOmistusosuusTotal)
        txtKIIAlueTarkenne.Text = kiinteisto.KIIAlueTarkenne

        Pudotusvalikko.Valitse(ddKIIKuntaId, kiinteisto.KIIKuntaId)
        'Pudotusvalikko.Valitse(ddKIIKylaId, kiinteisto.KIIKylaId)
        Pudotusvalikko.Valitse(ddKIISaantoId, kiinteisto.KIISaantoId)
        Pudotusvalikko.Valitse(ddKIILiiketoiminnanTarveId, kiinteisto.KIILiiketoiminnanTarveId)
        If kiinteisto.KIIMaaId Is Nothing Then
            Pudotusvalikko.ValitseTekstinPerusteella(ddKIIMaaId, "Suomi")
        Else
            Pudotusvalikko.Valitse(ddKIIMaaId, kiinteisto.KIIMaaId)
        End If
    End Sub

    Private Function LuoKiinteisto() As Entities.Kiinteisto

        Dim kiinteisto = New Entities.Kiinteisto()
        kiinteisto.KIIKortteli = txtKIIKortteli.Text
        kiinteisto.KIITontti = txtKIITontti.Text
        kiinteisto.KIIMaaraAla = txtKIIMaaraAla.Text
        kiinteisto.KIIKatuosoite = txtKIIKatuosoite.Text
        kiinteisto.KIIPostinumero = txtKIIPostinumero.Text
        kiinteisto.KIIPostitoimipaikka = txtKIIPostitoimipaikka.Text
        kiinteisto.KIIMaapintaAla = Luvut.HaeNullableDecimal(txtKIIMaapintaAla.Text)
        kiinteisto.KIIVesipintaAla = Luvut.HaeNullableDecimal(txtKIIVesipintaAla.Text)
        kiinteisto.KIIPintaAla = Luvut.HaeNullableDecimal(txtKIIPintaAla.Text)
        kiinteisto.KIIKiinteistoverotettuVuosi = Luvut.HaeNullableInteger(txtKIIKiinteistoverotettuVuosi.Text)
        kiinteisto.KIIAssetTunniste = Luvut.HaeNullableInteger(txtKIIAssetTunniste.Text)
        kiinteisto.KIIOmistusosuus = Luvut.HaeNullableInteger(txtKIIOmistusosuus.Text)
        kiinteisto.KIIRasitteet = txtKIIRasitteet.Text
        kiinteisto.KIIKiinnitykset = txtKIIKiinnitykset.Text
        kiinteisto.KIISaantoId = Pudotusvalikko.HaeValittuArvo(ddKIISaantoId)
        kiinteisto.KIIAlueTarkenne = txtKIIAlueTarkenne.Text
        kiinteisto.KIILiiketoiminnanTarveId = Pudotusvalikko.HaeValittuArvo(ddKIILiiketoiminnanTarveId)
        kiinteisto.KIIMaaId = Pudotusvalikko.HaeValittuArvo(ddKIIMaaId)
        kiinteisto.KIIKuntaId = Pudotusvalikko.HaeValittuArvo(ddKIIKuntaId)
        'kiinteisto.KIIKylaId = Pudotusvalikko.HaeValittuArvo(ddKIIKylaId)
        kiinteisto.KIIInfo = txtKIIInfo.Text
        kiinteisto.KIIKiinteisto = txtKIIKiinteisto.Text
        'kiinteisto.KIIRekisterinumero = txtKIIRekisterinumero.Text
        kiinteisto.KIIKiinteistotunnus = txtKIIKiinteistotunnus.Text
        'kiinteisto.KIIKiinteistotunnusLyhyt = txtKIIKiinteistotunnusLyhyt.Text
        kiinteisto.KIIKyla = txtKIIKyla.Text
        kiinteisto.KIIKylanumero = Luvut.HaeNullableInteger(txtKIIKylanumero.Text)
        kiinteisto.KIIKuntanumero = Luvut.HaeNullableInteger(txtKIIKuntanumero.Text)
        kiinteisto.KIIOmistusosuusTotal = Luvut.HaeNullableInteger(txtKIIOmistusosuusTotal.Text)

        Return kiinteisto

    End Function

    Protected Sub btnHaePostitoimipaikka_Click(sender As Object, e As EventArgs) Handles btnHaePostitoimipaikka.Click

        If Not String.IsNullOrWhiteSpace(txtKIIPostinumero.Text) Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Haku()
            Dim postitiedot = tietokanta.HaePostitiedot(txtKIIPostinumero.Text.Trim())

            If Not postitiedot Is Nothing Then

                txtKIIPostitoimipaikka.Text = postitiedot.Postitoimipaikka

            End If
        Else
            ' TODO: Virheilmoitus.
        End If

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

        If Page.IsValid() Then

            Dim tietokanta = New appSopimusrekisteri.BLL.Kiinteisto(_konteksti)
            Dim kiinteisto = LuoKiinteisto()

            ' Hae URL:ista kiinteistön tunniste, jonka pohjalta päätämme 
            ' lisäämmekö sen tietokantaan vai muokkaammeko sitä.
            If IsNumeric(Request.Params("id")) Then
                kiinteisto.KIIId = Request.Params("id")
                kiinteisto = tietokanta.MuokkaaKiinteistoa(kiinteisto)
                If Not kiinteisto Is Nothing Then
                    If IsNumeric(Request.Params("sopimusid")) Then
                        Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}&kiinteistoid={1}", Request.Params("sopimusid"), kiinteisto.KIIId))
                    Else
                        Response.Redirect(String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", kiinteisto.KIIId))
                    End If
                End If
            Else
                kiinteisto = tietokanta.LisaaKiinteisto(kiinteisto)
                If Not kiinteisto Is Nothing Then
                    If IsNumeric(Request.Params("sopimusid")) Then
                        Response.Redirect(String.Format("~/Kiinteisto/LiitaSopimukselle.ashx?sopimusId={0}&kiinteistoId={1}", Request.Params("sopimusid"), kiinteisto.KIIId))
                    Else
                        Response.Redirect(String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", kiinteisto.KIIId))
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
            Response.Redirect(String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", Request.Params("id")), True)
        End If

        Response.Redirect("~/Etusivu.aspx", True)

    End Sub

    Protected Sub txtKIIKuntanumero_TextChanged(sender As Object, e As EventArgs) Handles txtKIIKuntanumero.TextChanged

        Me.PaivitaKunta()

    End Sub

    Protected Sub txtKIIKiinteistotunnus_TextChanged(sender As Object, e As EventArgs) Handles txtKIIKiinteistotunnus.TextChanged

        Me.PaivitaKunta()

    End Sub

    Private Sub PaivitaKunta()

        Dim tietokanta As New BLL.Haku()

        If IsNumeric(txtKIIKuntanumero.Text) Then

            Dim kunta As DTO.iHakutulos = tietokanta.HaeKunta(txtKIIKuntanumero.Text)

            If Not kunta Is Nothing Then

                Pudotusvalikko.Valitse(ddKIIKuntaId, kunta.ID)

            End If

        End If

    End Sub

End Class