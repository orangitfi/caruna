Imports appSopimusrekisteri.DTO

Public Class Poimintajoukko
    Inherits BasePage

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            phSopimukset.Visible = False
            phKiinteistot.Visible = False
            phTahot.Visible = False

            AsetaPoiminnat()
        End If

        If Not Session("poimintaEhdot") Is Nothing Then
            NaytaPoimintaEhdot()
        End If

    End Sub

    Private Sub NaytaPoimintaEhdot()
        Dim ehdotLista As New List(Of String)
        Dim tallennetutEhdot As IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto) = CType(Session("poimintaEhdot"), IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto))
        ehdotLista.AddRange(tallennetutEhdot.Where(Function(x) x.TPEEOperaattori <> DTO.Hakuoperaattori.Tyhja.ToString() AndAlso x.TPEEOperaattori <> DTO.Hakuoperaattori.EiTyhja.ToString()).Select(Function(x) x.TPEEKenttaNaytolle & x.TPEEOperaattoriNaytolle & x.TPEEArvoNaytolle))
        ehdotLista.AddRange(tallennetutEhdot.Where(Function(x) x.TPEEOperaattori = DTO.Hakuoperaattori.Tyhja.ToString()).Select(Function(x) x.TPEEKenttaNaytolle & " " & x.TPEEOperaattoriNaytolle))
        ehdotLista.AddRange(tallennetutEhdot.Where(Function(x) x.TPEEOperaattori = DTO.Hakuoperaattori.EiTyhja.ToString()).Select(Function(x) x.TPEEKenttaNaytolle & " " & x.TPEEOperaattoriNaytolle))
        Dim ehdot As String = String.Join("; ", ehdotLista)
        lblPoimintaehdotNaytolle.Text = ehdot
        lblPoimintaehdotNaytolle.Visible = True
    End Sub

    Protected Sub btnUusiPoiminta_Click(sender As Object, e As EventArgs) Handles btnUusiPoiminta.Click

        Dim tietokanta As New BLL.Poiminta()

        tietokanta.TyhjennaPoiminta(Session.SessionID)

        Response.Redirect("Poimintalomake.aspx")

    End Sub

    Private Sub AsetaKiinteistoPoiminta(Optional sorttaus As String = Nothing)

        Dim tietokanta As New BLL.Poiminta()

        Dim kiinteistot As DTO.Kiinteisto()

        kiinteistot = tietokanta.HaePoimintaJoukkoKiinteistot(Session.SessionID)

        If Not IsNothing(sorttaus) Then
            Dim sorttausProperty = GetType(DTO.Kiinteisto).GetProperty(sorttaus)
            kiinteistot = kiinteistot.OrderBy(Function(x) sorttausProperty.GetValue(x)).ToArray()
        End If

        If Not kiinteistot Is Nothing AndAlso kiinteistot.Length > 0 Then

            If Not Sessio.PoiminnanSarakkeetKiinteistolle(Session) Is Nothing Then

                Me.TeeDynaamisetSarakkeetKiinteistoille(Sessio.PoiminnanSarakkeetKiinteistolle(Session))

                gvPoimitutKiinteistot.Visible = True
                lvPoimintaKiinteistot.Visible = False

                gvPoimitutKiinteistot.DataSource = kiinteistot
                gvPoimitutKiinteistot.DataBind()

                dpPoimintaKiinteistot.Visible = False

            Else
                lvPoimintaKiinteistot.Visible = True
                gvPoimitutKiinteistot.Visible = False

                lvPoimintaKiinteistot.DataSource = kiinteistot
                lvPoimintaKiinteistot.DataBind()

                dpPoimintaKiinteistot.Visible = True

            End If

            TeeExcelKiinteistoille(kiinteistot)

            lblInfo.Text = "Poimittuja kiinteistöjä " & kiinteistot.Length & " kpl"

        End If

    End Sub

    Private Sub AsetaTahoPoiminta(Optional sorttaus As String = Nothing)

        Dim tietokanta As New BLL.Poiminta()

        Dim tahot As DTO.Taho()

        tahot = tietokanta.HaePoimintaJoukkoTahot(Session.SessionID)

        If Not IsNothing(sorttaus) Then
            Dim sorttausProperty = GetType(DTO.Taho).GetProperty(sorttaus)
            tahot = tahot.OrderBy(Function(x) sorttausProperty.GetValue(x)).ToArray()
        End If

        If Not tahot Is Nothing AndAlso tahot.Length > 0 Then

            If Not Sessio.PoiminnanSarakkeetTaholle(Session) Is Nothing Then

                Me.TeeDynaamisetSarakkeetTahoille(Sessio.PoiminnanSarakkeetTaholle(Session))

                gvPoimitutTahot.Visible = True
                lvPoimintaTahot.Visible = False

                gvPoimitutTahot.DataSource = tahot
                gvPoimitutTahot.DataBind()

                dpPoimintaTahot.Visible = False

            Else
                lvPoimintaTahot.Visible = True
                gvPoimitutTahot.Visible = False

                lvPoimintaTahot.DataSource = tahot
                lvPoimintaTahot.DataBind()

                dpPoimintaTahot.Visible = True

            End If

            TeeExcelTahoille(tahot)

            lblInfo.Text = "Poimittuja tahoja " & tahot.Length & " kpl"

        End If

    End Sub

    Private Sub AsetaSopimusPoiminta(Optional sorttaus As String = Nothing)

        Dim tietokanta As New BLL.Poiminta()

        Dim sopimukset As DTO.Sopimus()

        sopimukset = tietokanta.HaePoimintaJoukkoSopimukset(Session.SessionID)

        If Not IsNothing(sorttaus) Then
            Dim sorttausProperty = GetType(DTO.Sopimus).GetProperty(sorttaus)
            sopimukset = sopimukset.OrderBy(Function(x) sorttausProperty.GetValue(x)).ToArray()
        End If

        If Not sopimukset Is Nothing AndAlso sopimukset.Length > 0 Then

            If Not Sessio.PoiminnanSarakkeetSopimukselle(Session) Is Nothing Then

                Me.TeeDynaamisetSarakkeetSopimuksille(Sessio.PoiminnanSarakkeetSopimukselle(Session))

                gvPoimitutSopimukset.Visible = True
                lvPoimintaSopimukset.Visible = False

                gvPoimitutSopimukset.DataSource = sopimukset
                gvPoimitutSopimukset.DataBind()

                dpPoimintaSopimukset.Visible = False

            Else

                lvPoimintaSopimukset.Visible = True
                gvPoimitutSopimukset.Visible = False

                lvPoimintaSopimukset.DataSource = sopimukset
                lvPoimintaSopimukset.DataBind()

                dpPoimintaSopimukset.Visible = True

            End If

            TeeExcelSopimuksille(sopimukset)

            lblInfo.Text = "Poimittuja sopimuksia " & sopimukset.Length & " kpl"

        End If

    End Sub

    Private Sub AsetaPoiminnat()

        Dim tietokanta As New BLL.Poiminta()

        If tietokanta.HaePoimintaLkm(Session.SessionID) Then

            Dim tyyppi As String = tietokanta.HaePoiminnanTyyppi(Session.SessionID)

            Select Case tyyppi
                Case "sopimus"
                    AsetaSopimusPoiminta()
                    phSopimukset.Visible = True
                Case "kiinteisto"
                    AsetaKiinteistoPoiminta()
                    phKiinteistot.Visible = True
                Case "taho"
                    AsetaTahoPoiminta()
                    phTahot.Visible = True
            End Select

            NaytaKontrollit(True)

        Else

            lblInfo.Text = "Ei poimittuja."

            NaytaKontrollit(False)

        End If

    End Sub

    Private Sub NaytaKontrollit(nayta As Boolean)

        btnLisaaPoimintaan.Visible = nayta
        btnPoistaPoiminnasta.Visible = nayta
        btnNollaa.Visible = nayta
        hlExcel.Visible = nayta

    End Sub

    Private Sub TeeDynaamisetSarakkeet(Of T)(gridview As GridView, sarakkeet As Dictionary(Of String, String), pAvustaja As Common.PropertyAvustaja(Of T))
        Dim bf As BoundField

        gridview.Columns.Clear()

        'käydään datasetin sarakkeet läpi
        For Each sarake As KeyValuePair(Of String, String) In sarakkeet

            bf = New BoundField

            bf.DataField = sarake.Key
            bf.HeaderText = sarake.Value
            bf.SortExpression = sarake.Key

            Select Case pAvustaja.HaeTietotyyppi(sarake.Key)
                Case GetType(Date)
                    bf.DataFormatString = "{0:dd.MM.yyyy}"
                Case GetType(Decimal)
                    bf.DataFormatString = "{0:F}"
                Case Else
            End Select

            gridview.Columns.Add(bf)

        Next

    End Sub

    Private Sub TeeDynaamisetSarakkeetSopimuksille(sarakkeet As Dictionary(Of String, String))

        TeeDynaamisetSarakkeet(gvPoimitutSopimukset, sarakkeet, New Common.PropertyAvustaja(Of DTO.Sopimus)())

    End Sub

    Private Sub TeeDynaamisetSarakkeetKiinteistoille(sarakkeet As Dictionary(Of String, String))

        TeeDynaamisetSarakkeet(gvPoimitutKiinteistot, sarakkeet, New Common.PropertyAvustaja(Of DTO.Kiinteisto)())

    End Sub

    Private Sub TeeDynaamisetSarakkeetTahoille(sarakkeet As Dictionary(Of String, String))

        TeeDynaamisetSarakkeet(gvPoimitutTahot, sarakkeet, New Common.PropertyAvustaja(Of DTO.Taho)())

    End Sub

    Private Sub TeeExcelSopimuksille(data As DTO.Sopimus())

        Dim ncSarakkeet As New NameValueCollection()

        If Not Sessio.PoiminnanSarakkeetSopimukselle(Session) Is Nothing Then

            For Each kv As KeyValuePair(Of String, String) In Sessio.PoiminnanSarakkeetSopimukselle(Session)

                ncSarakkeet.Add(kv.Key, kv.Value)

            Next

        Else
            ncSarakkeet.Add("Nimi", "Nimi")
            ncSarakkeet.Add("Sopimustyyppi", "Sopimustyyppi")
            ncSarakkeet.Add("Sopimusvuosi", "Sopimusvuosi")
        End If

        Dim strExcel As String = Context.User.Identity.Name.Replace("\", "") & "_sopimus.xlsx"

        BLL.ExcelHelper.TeeExcelListasta(Of DTO.Sopimus)(data.ToList(), ncSarakkeet, Hakemistot.TemplateHakemisto & Tiedostot.Excelpohja, Hakemistot.ExcelHakemisto & strExcel)

        hlExcel.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcel

    End Sub

    Private Sub TeeExcelKiinteistoille(data As DTO.Kiinteisto())

        Dim ncSarakkeet As New NameValueCollection()

        If Not Sessio.PoiminnanSarakkeetKiinteistolle(Session) Is Nothing Then

            For Each kv As KeyValuePair(Of String, String) In Sessio.PoiminnanSarakkeetKiinteistolle(Session)

                ncSarakkeet.Add(kv.Key, kv.Value)

            Next

        Else
            ncSarakkeet.Add("Nimi", "Nimi")
            ncSarakkeet.Add("LyhytKiinteistotunnus", "Kiinteistötunnus")
            ncSarakkeet.Add("Osoite", "Osoite")
            ncSarakkeet.Add("Postinumero", "Postinumero")
            ncSarakkeet.Add("Postitoimipaikka", "Postitoimipaikka")
        End If

        Dim strExcel As String = Context.User.Identity.Name.Replace("\", "") & "_kiinteisto.xlsx"

        BLL.ExcelHelper.TeeExcelListasta(Of DTO.Kiinteisto)(data.ToList(), ncSarakkeet, Hakemistot.TemplateHakemisto & Tiedostot.Excelpohja, Hakemistot.ExcelHakemisto & strExcel)

        hlExcel.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcel

    End Sub

    Private Sub TeeExcelTahoille(data As DTO.Taho())

        Dim ncSarakkeet As New NameValueCollection()

        If Not Sessio.PoiminnanSarakkeetTaholle(Session) Is Nothing Then

            For Each kv As KeyValuePair(Of String, String) In Sessio.PoiminnanSarakkeetTaholle(Session)

                ncSarakkeet.Add(kv.Key, kv.Value)

            Next

        Else
            ncSarakkeet.Add("Nimi", "Nimi")
            ncSarakkeet.Add("Tyyppi", "Tyyppi")
            ncSarakkeet.Add("Osoite", "Osoite")
            ncSarakkeet.Add("Postinumero", "Postinumero")
            ncSarakkeet.Add("Postitoimipaikka", "Postitoimipaikka")
        End If

        Dim strExcel As String = Context.User.Identity.Name.Replace("\", "") & "_taho.xlsx"

        BLL.ExcelHelper.TeeExcelListasta(Of DTO.Taho)(data.ToList(), ncSarakkeet, Hakemistot.TemplateHakemisto & Tiedostot.Excelpohja, Hakemistot.ExcelHakemisto & strExcel)

        hlExcel.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcel

    End Sub

    Private Sub lvPoimintaSopimukset_ItemDataBound(sender As Object, e As Web.UI.WebControls.ListViewItemEventArgs) Handles lvPoimintaSopimukset.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim sopimus As DTO.Sopimus = CType(e.Item.DataItem, DTO.Sopimus)

            CType(e.Item.FindControl("hlLinkki"), HyperLink).Text = sopimus.Nimi
            CType(e.Item.FindControl("hlLinkki"), HyperLink).NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", sopimus.Id)

            If sopimus.SopimustyyppiId.HasValue AndAlso sopimus.SopimustyyppiId.Value = CInt(Enumeraattorit.Sopimustyyppi.Sopimuspohja) Then
                CType(e.Item.FindControl("hlLinkki"), HyperLink).Enabled = False
            Else
                CType(e.Item.FindControl("hlLinkki"), HyperLink).Enabled = True
            End If

        End If

    End Sub

    Private Sub lvPoimintaKiinteistot_ItemDataBound(sender As Object, e As Web.UI.WebControls.ListViewItemEventArgs) Handles lvPoimintaKiinteistot.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim kiinteisto As DTO.Kiinteisto = CType(e.Item.DataItem, DTO.Kiinteisto)

            CType(e.Item.FindControl("hlLinkki"), HyperLink).Text = kiinteisto.Nimi
            CType(e.Item.FindControl("hlLinkki"), HyperLink).NavigateUrl = String.Format("~/Kiinteisto/Tiedot.aspx?id={0}", kiinteisto.Id)

        End If

    End Sub

    Private Sub lvPoimintaTahot_ItemDataBound(sender As Object, e As Web.UI.WebControls.ListViewItemEventArgs) Handles lvPoimintaTahot.ItemDataBound

        If e.Item.ItemType = ListViewItemType.DataItem Then

            Dim taho As DTO.Taho = CType(e.Item.DataItem, DTO.Taho)

            CType(e.Item.FindControl("hlLinkki"), HyperLink).Text = taho.Nimi
            If taho.TahoTyyppiId = DTO.Enumeraattorit.TahoTyyppi.Henkilo Then
                CType(e.Item.FindControl("hlLinkki"), HyperLink).NavigateUrl = String.Format("~/Taho/Henkilo/Tiedot.aspx?id={0}", taho.Id)
            Else
                'organisaatio
                CType(e.Item.FindControl("hlLinkki"), HyperLink).NavigateUrl = String.Format("~/Taho/Organisaatio/Tiedot.aspx?id={0}", taho.Id)
            End If

        End If

    End Sub

    Protected Sub btnLisaaPoimintaan_Click(sender As Object, e As EventArgs) Handles btnLisaaPoimintaan.Click

        Response.Redirect("Poimintalomake.aspx")

    End Sub

    Protected Sub btnNollaa_Click(sender As Object, e As EventArgs) Handles btnNollaa.Click

        Dim tietokanta As New BLL.Poiminta()

        tietokanta.TyhjennaPoiminta(Session.SessionID)

        AsetaPoiminnat()

    End Sub

    Private Sub lvPoimintaSopimukset_PagePropertiesChanging(sender As Object, e As Web.UI.WebControls.PagePropertiesChangingEventArgs) Handles lvPoimintaSopimukset.PagePropertiesChanging

        dpPoimintaSopimukset.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)

        AsetaPoiminnat()

    End Sub

    Private Sub lvPoimintaKiinteistot_PagePropertiesChanging(sender As Object, e As Web.UI.WebControls.PagePropertiesChangingEventArgs) Handles lvPoimintaKiinteistot.PagePropertiesChanging

        dpPoimintaKiinteistot.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)

        AsetaPoiminnat()

    End Sub

    Private Sub lvPoimintaTahot_PagePropertiesChanging(sender As Object, e As Web.UI.WebControls.PagePropertiesChangingEventArgs) Handles lvPoimintaTahot.PagePropertiesChanging

        dpPoimintaTahot.SetPageProperties(e.StartRowIndex, e.MaximumRows, False)

        AsetaPoiminnat()

    End Sub

    Protected Sub btnPoistaPoiminnasta_Click(sender As Object, e As EventArgs) Handles btnPoistaPoiminnasta.Click

        Response.Redirect("Poimintalomake.aspx?poisto=true")

    End Sub

    Private Sub gvPoimitutSopimukset_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPoimitutSopimukset.PageIndexChanging

        gvPoimitutSopimukset.PageIndex = e.NewPageIndex

        AsetaPoiminnat()

    End Sub

    Protected Sub gvPoimitutSopimukset_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvPoimitutSopimukset.Sorting
        AsetaSopimusPoiminta(e.SortExpression)
    End Sub

    Private Sub gvPoimitutKiinteistot_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPoimitutKiinteistot.PageIndexChanging

        gvPoimitutKiinteistot.PageIndex = e.NewPageIndex

        AsetaPoiminnat()

    End Sub

    Protected Sub gvPoimitutKiinteistot_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvPoimitutKiinteistot.Sorting
        AsetaKiinteistoPoiminta(e.SortExpression)
    End Sub

    Private Sub gvPoimitutTahot_PageIndexChanging(sender As Object, e As Web.UI.WebControls.GridViewPageEventArgs) Handles gvPoimitutTahot.PageIndexChanging

        gvPoimitutTahot.PageIndex = e.NewPageIndex

        AsetaPoiminnat()

    End Sub

    Protected Sub gvPoimitutTahot_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvPoimitutTahot.Sorting
        AsetaTahoPoiminta(e.SortExpression)
    End Sub

    Protected Sub lbJarjestaSopimusNimi_Click(sender As Object, e As EventArgs)
        AsetaSopimusPoiminta("Nimi")
    End Sub

    Protected Sub lbJarjestaSopimusTyyppi_Click(sender As Object, e As EventArgs)
        AsetaSopimusPoiminta("Sopimustyyppi")
    End Sub

    Protected Sub lbJarjestaSopimusVuosi_Click(sender As Object, e As EventArgs)
        AsetaSopimusPoiminta("Sopimusvuosi")
    End Sub

    Protected Sub lbJarjestaKiinteistoNimi_Click(sender As Object, e As EventArgs)
        AsetaKiinteistoPoiminta("Nimi")
    End Sub

    Protected Sub lbJarjestaKiinteistoTunnus_Click(sender As Object, e As EventArgs)
        AsetaKiinteistoPoiminta("LyhytKiinteistotunnus")
    End Sub

    Protected Sub lbJarjestaKiinteistoOsoite_Click(sender As Object, e As EventArgs)
        AsetaKiinteistoPoiminta("Osoite")
    End Sub

    Protected Sub lbJarjestaKiinteistoPostinumero_Click(sender As Object, e As EventArgs)
        AsetaKiinteistoPoiminta("Postinumero")
    End Sub

    Protected Sub lbJarjestaKiinteistoPostitoimipaikka_Click(sender As Object, e As EventArgs)
        AsetaKiinteistoPoiminta("Postitoimipaikka")
    End Sub

    Protected Sub lbJarjestaTahoNimi_Click(sender As Object, e As EventArgs)
        AsetaTahoPoiminta("Nimi")
    End Sub

    Protected Sub lbJarjestaTahoTyyppi_Click(sender As Object, e As EventArgs)
        AsetaTahoPoiminta("Tyyppi")
    End Sub

    Protected Sub lbJarjestaTahoOsoite_Click(sender As Object, e As EventArgs)
        AsetaTahoPoiminta("Osoite")
    End Sub

    Protected Sub lbJarjestaTahoPostinumero_Click(sender As Object, e As EventArgs)
        AsetaTahoPoiminta("Postinumero")
    End Sub

    Protected Sub lbJarjestaTahoPostitoimipaikka_Click(sender As Object, e As EventArgs)
        AsetaTahoPoiminta("Postitoimipaikka")
    End Sub
End Class