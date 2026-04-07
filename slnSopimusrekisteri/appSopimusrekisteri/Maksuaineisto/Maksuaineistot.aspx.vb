Imports System.IO
Imports appSopimusrekisteri.Entities

Public Class MaksuaineistojenTiedot

    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            TaytaPudotusvalikot()
            HaeMaksuaineisto()

        End If

    End Sub

    Private Sub TaytaPudotusvalikot()

        Dim tietokanta = New BLL.Haku()
        ddKORKorvauslaskelmaStatusId.DataSource = tietokanta.HaeKorvauslaskelmanStatukset()
        ddKORKorvauslaskelmaStatusId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos("-- Valitse status --"))
        ddKORKorvauslaskelmaStatusId.DataBind()
        Pudotusvalikko.Valitse(ddKORKorvauslaskelmaStatusId, 2)
        ddKORKorvaustyyppiId.DataSource = tietokanta.HaeKorvaustyypit()
        ddKORKorvaustyyppiId.DataSource.Insert(0, Pudotusvalikko.LuoTyhjaHakutulos("-- Valitse korvaustyyppi --"))
        ddKORKorvaustyyppiId.DataBind()
        Pudotusvalikko.Valitse(ddKORKorvaustyyppiId, Request.Params("tyyppi"))

    End Sub

    Private Sub HaeMaksuaineisto()

        If (ddKORKorvauslaskelmaStatusId.SelectedValue <> 0) Then
            Dim tietokanta = New BLL.Maksuaineisto()
            gwTulokset.DataSource = tietokanta.HaeMaksuaineistot(Pudotusvalikko.HaeValittuArvo(ddKORKorvaustyyppiId), Pudotusvalikko.HaeValittuArvo(ddKORKorvauslaskelmaStatusId))
            gwTulokset.DataBind()
        End If

    End Sub

    Protected Sub ddKORKorvauslaskelmaStatusId_Selected(sender As Object, e As EventArgs) Handles ddKORKorvauslaskelmaStatusId.SelectedIndexChanged

        HaeMaksuaineisto()
        If Pudotusvalikko.HaeValittuArvo(ddKORKorvauslaskelmaStatusId) = 2 Then
            btnTeeEsikatseluaineisto.Visible = True
            btnTeeMaksuaineisto.Visible = True
        Else
            btnTeeEsikatseluaineisto.Visible = False
            btnTeeMaksuaineisto.Visible = True
        End If

    End Sub

    Protected Sub ddKORKorvaustyyppiId_Selected(sender As Object, e As EventArgs) Handles ddKORKorvaustyyppiId.SelectedIndexChanged

        HaeMaksuaineisto()

    End Sub


    Protected Sub btnTeeMaksuaineisto_Click(sender As Object, e As EventArgs) Handles btnTeeMaksuaineisto.Click

        Dim tietokanta = New BLL.Maksuaineisto()
        Dim validointitulos = tietokanta.ValidoiMaksuaineisto(Pudotusvalikko.HaeValittuArvo(ddKORKorvaustyyppiId))

        If validointitulos = String.Empty Then

            Dim maksajanNimi = ConfigurationManager.AppSettings("MaksajanNimi").ToString()
            Dim maksajanTilinumero = ConfigurationManager.AppSettings("MaksajanTilinumero").ToString()
            Dim maksajanBic = ConfigurationManager.AppSettings("MaksajanBic").ToString()
            Dim maksajanTunnus = ConfigurationManager.AppSettings("MaksajanTunnus").ToString()
            Dim maksuhakemisto = ConfigurationManager.AppSettings("Maksuhakemisto").ToString()

            ' Haetaan maksuaineisto.
            Dim maksuaineisto = tietokanta.LuoMaksuaineisto(Pudotusvalikko.HaeValittuArvo(ddKORKorvaustyyppiId))

            If maksuaineisto.Any() Then

                ' Luodaan tarvittavat hakemistot erälle.
                Dim eratunniste = maksuaineisto.First().Eratunniste
                Dim erahakemisto = Server.MapPath("~/" + maksuhakemisto + eratunniste.ToString())

                If Not System.IO.Directory.Exists(Server.MapPath(maksuhakemisto)) Then
                    System.IO.Directory.CreateDirectory(Server.MapPath(maksuhakemisto))
                End If

                If Not System.IO.Directory.Exists(erahakemisto) Then
                    System.IO.Directory.CreateDirectory(erahakemisto)
                End If

                ' Luodaan XML-aineisto levypinnalle maksuaineistosta. Käyttäjä ei pääse tähän käsiksi.
                Dim cPayments As New BLL.CorporatePaymentsV02.CorporatePaymentsV02Factory(maksajanNimi, maksajanTunnus)

                ' Luodaan maksuaineistomateriaali levypinnalle.
                For Each rivi As DTO.Maksuaineisto In maksuaineisto

                    If Not String.IsNullOrEmpty(rivi.Viite) Then
                        cPayments.AddSEPATransferWithReferencenumber(rivi.Eratunniste, maksajanTilinumero, maksajanBic, Date.Now.Date, rivi.KorvauslaskelmienSumma, rivi.Saaja, rivi.Tilinumero, rivi.Viite)
                    Else
                        cPayments.AddSEPATransferWithMessage(rivi.Eratunniste, maksajanTilinumero, maksajanBic, Date.Now.Date, rivi.KorvauslaskelmienSumma, rivi.Saaja, rivi.Tilinumero, rivi.Viesti)
                    End If

                    cPayments.CreateFile(String.Format("{0}\{1}.xml", erahakemisto, Guid.NewGuid().ToString()))

                Next

                'Response.Write("<p style='color:red;font-size:12px;'>Tämä on testiä varten luotu kertakäyttöinen linkki maksuaineistokansioon:</p> <a href='" + New UriBuilder(Request.Url.Host + "/Dokumentit/Maksuaineisto/" + eratunniste.ToString() + "/").ToString() + "' style='font-weight:bold;color:black;'>LINKKI</a>")

            End If

        Else

            Page.ClientScript.RegisterStartupScript(Me.GetType, "Ilmoitus", "<script type='text/javascript'>alert('" + validointitulos + "');</script>")

        End If

    End Sub

    Protected Sub btnTeeEsikatseluaineisto_Click(sender As Object, e As EventArgs) Handles btnTeeEsikatseluaineisto.Click

        Response.Redirect("Esikatselu.aspx?tyyppi=" + Pudotusvalikko.HaeValittuTeksti(ddKORKorvaustyyppiId), True)

    End Sub

End Class