Imports System.IO
Imports appSopimusrekisteri.Entities

Public Class MaksuaineistonLuominen

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Page.IsPostBack Then

      JavascriptAvustaja.LisaaTuplaklikinEstoVarmistuksella(btnTeeMaksuaineisto, Me, "Haluatko jatkaa maksuaineiston luomista? Virheellinen aineisto jää sen ulkopuolelle.")

      txtMaksupvm.Text = Paivaykset.PalautaPaivays(Date.Now)

      ValitseValilehti()
      HaeMaksuaineisto()

    End If

    If gvVirheellinenAineisto.Rows.Count > 0 Then

      'btnTeeMaksuaineisto.Attributes.Add("onclick", " return confirm('Haluatko jatkaa maksuaineiston luomista? Virheellinen aineisto jää sen ulkopuolelle.');")

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

  Private Sub HaeMaksuaineisto()

    Dim tietokanta = New BLL.Maksu(_konteksti)

    Dim maksuaineisto As DTO.Maksuaineisto = tietokanta.HaeMaksuaineisto()

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

  Private Sub TeeExcelit(maksuaineisto As DTO.Maksuaineisto)

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
    ncSarakkeet.Add("Regulation", "REGULATION")
    ncSarakkeet.Add("Purpose", "PURPOSE")
    ncSarakkeet.Add("Local1", "LOCAL1")

    Dim strExcelVirheellinen As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_VirheellinenAineisto.xlsx"
    Dim strExcelTarkistettava As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_TarkistettavaAineisto.xlsx"
    Dim strExcelMaksettava As String = Context.User.Identity.Name.Replace("\", "") & Date.Now.Ticks & "_MaksettavaAineisto.xlsx"


    BLL.ExcelHelper.TeeExcelListasta(Of DTO.Maksuraportti)(maksuaineisto.VirheellinenAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelVirheellinen)

    hlExcelVirheellinenAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelVirheellinen

    BLL.ExcelHelper.TeeExcelListasta(Of DTO.Maksuraportti)(maksuaineisto.TarkistettavaAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelTarkistettava)

    hlExcelTarkistettavaAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelTarkistettava

    BLL.ExcelHelper.TeeExcelListasta(Of DTO.Maksuraportti)(maksuaineisto.MaksettavaAineisto, ncSarakkeet, strExcelPohja, Hakemistot.ExcelHakemisto & strExcelMaksettava)

    hlExcelMaksettavaAineisto.NavigateUrl = Hakemistot.ExcelHakemistoRelatiivinen & strExcelMaksettava

  End Sub

  Protected Sub btnTeeMaksuaineisto_Click(sender As Object, e As EventArgs) Handles btnTeeMaksuaineisto.Click

    Dim tietokanta = New BLL.Maksu(_konteksti)

    Dim maksuaineisto = tietokanta.HaeMaksuaineisto()

    Dim objKirjanpitoTiedot As New DTO.KirjanpitoTiedot()

    objKirjanpitoTiedot.OhjelmistoTunniste = Konfiguraatiot.KirjanpitoOhjelmistotunniste
    objKirjanpitoTiedot.Kategoria = Konfiguraatiot.KirjanpitoKategoria
    objKirjanpitoTiedot.ClearingTili = Konfiguraatiot.KirjanpitoClearingTili
    objKirjanpitoTiedot.ClearingKustannuspaikkaPrefix = Konfiguraatiot.KirjanpitoClearingKustannuspaikkaPrefix

    Dim maksupvm As Date = Date.Now

    If IsDate(txtMaksupvm.Text) Then
      maksupvm = CDate(txtMaksupvm.Text)
    End If

    Dim objPalautusarvoMaksuaineisto As DTO.Palautusarvo
    Dim objPalautusarvoKirjanpidonaineisto As DTO.Palautusarvo

    maksuaineisto.Maksut = tietokanta.LisaaMaksut(maksuaineisto.Maksut, maksupvm)

    objPalautusarvoMaksuaineisto = tietokanta.TeeMaksuaineistot(maksuaineisto.Maksut, Hakemistot.MaksuaineistoHakemisto)

    objPalautusarvoKirjanpidonaineisto = tietokanta.TeeKirjanpidonaineistot(maksuaineisto.Maksut, objKirjanpitoTiedot, Hakemistot.KirjanpidonaineistoHakemisto)

    ' Päivitetään sivuilla oleva maksuaineisto.
    HaeMaksuaineisto()

    If objPalautusarvoMaksuaineisto.Ok Then

      Dim lstMaksuaineistot As List(Of DTO.MaksuaineistoPalaute) = CType(objPalautusarvoMaksuaineisto.Tiedot, List(Of DTO.MaksuaineistoPalaute))

      lblTiedot.Text = String.Format("Maksuaineistoja luotu {0} kpl.", lstMaksuaineistot.Count())

      For Each objMaksuaineistopalaute As DTO.MaksuaineistoPalaute In lstMaksuaineistot
        lblTiedot.Text &= String.Format("<br>{0}: Maksurivejä yhteensä {1} kpl. Yhteissumma {2} €.", objMaksuaineistopalaute.Yhtio, objMaksuaineistopalaute.Maara, Luvut.EsitaNullableDecimal(objMaksuaineistopalaute.Summa))
      Next

      If Konfiguraatiot.NaytaMaksuaineistoKayttajalle Then
        Me.NaytaMaksuaineistot(lstMaksuaineistot.Select(Function(x) x.Tiedosto).ToArray())
      End If

      If Konfiguraatiot.KopioiMaksuaineistoPalvelimelle Then
        For Each palaute As DTO.MaksuaineistoPalaute In lstMaksuaineistot

          palaute.KopioTiedostonimi = String.Format("AMDSOPREK_{0}.xml", palaute.Yritystunniste)

          If Konfiguraatiot.MaksuaineistoVaatiiServiceTunnukset Then
            Common.Tiedostot.Kopioi(Hakemistot.MaksuaineistoHakemisto & palaute.Tiedosto, Konfiguraatiot.MaksuaineistonPolku & palaute.KopioTiedostonimi, Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.ServiceTunnusDomain)
          Else
            File.Copy(Hakemistot.MaksuaineistoHakemisto & palaute.Tiedosto, Konfiguraatiot.MaksuaineistonPolku & palaute.KopioTiedostonimi, True)
          End If
        Next
      End If

      If Konfiguraatiot.LahetaSahkopostiMaksuaineistoista Then
        LahetaSahkopostiMaksuaineistosta(maksuaineisto, maksuaineisto.Maksut.First().MaksuEraTunniste, lstMaksuaineistot)
      End If

    Else

      LomakeVirhe.LisaaVirhe(String.Format("Maksuaineiston luomisessa tapahtui virhe. {0}", objPalautusarvoMaksuaineisto.Virheet.First().Data))

    End If

    If objPalautusarvoKirjanpidonaineisto.Ok Then

      Dim lstKirjanpidonaineistot As List(Of DTO.MaksuaineistoPalaute) = CType(objPalautusarvoKirjanpidonaineisto.Tiedot, List(Of DTO.MaksuaineistoPalaute))

      lblTiedot.Text &= String.Format("<br /><br />Kirjanpitoaineistoja luotu {0} kpl.", lstKirjanpidonaineistot.Count())

      For Each objMaksuaineistopalaute As DTO.MaksuaineistoPalaute In lstKirjanpidonaineistot
        lblTiedot.Text &= String.Format("<br>{0}: Maksurivejä yhteensä {1} kpl. Yhteissumma {2} €.", objMaksuaineistopalaute.Yhtio, objMaksuaineistopalaute.Maara, Luvut.EsitaNullableDecimal(objMaksuaineistopalaute.Summa))
      Next

      If Konfiguraatiot.NaytaKirjanpidonAineistoKayttajalle Then
        Me.NaytaKirjanpidonAineistot(lstKirjanpidonaineistot.Select(Function(x) x.Tiedosto).ToArray())
      End If

      If Konfiguraatiot.KopioiKirjanpidonAineistoPalvelimelle Then
        For Each palaute As DTO.MaksuaineistoPalaute In lstKirjanpidonaineistot
          If Konfiguraatiot.KirjanpidonAineistoVaatiiServiceTunnukset Then
            Common.Tiedostot.Kopioi(Hakemistot.KirjanpidonaineistoHakemisto & palaute.Tiedosto, Konfiguraatiot.KirjanpidonAineistonPolku & palaute.Tiedosto, Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.ServiceTunnusDomain)
          Else
            File.Copy(Hakemistot.KirjanpidonaineistoHakemisto & palaute.Tiedosto, Konfiguraatiot.KirjanpidonAineistonPolku & palaute.Tiedosto, True)
          End If
        Next
      End If

      If Konfiguraatiot.LahetaSahkopostiKirjanpitoaineistosta Then
        LahetaSahkopostiKirjanpidonAineistosta(maksuaineisto, maksuaineisto.Maksut.First().MaksuEraTunniste, lstKirjanpidonaineistot)
      End If

    Else

      LomakeVirhe.LisaaVirhe(String.Format("Kirjanpidon aineiston luomisessa tapahtui virhe. {0}", objPalautusarvoKirjanpidonaineisto.Virheet.First().Data))

    End If

  End Sub

  Private Sub NaytaMaksuaineistot(tiedostot As String())

    lvMaksuaineistot.DataSource = tiedostot
    lvMaksuaineistot.DataBind()

  End Sub

  Private Sub NaytaKirjanpidonAineistot(tiedostot As String())

    lvKirjanpidonAineistot.DataSource = tiedostot
    lvKirjanpidonAineistot.DataBind()

  End Sub

  Private Sub lvMaksuaineistot_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvMaksuaineistot.ItemDataBound

    If e.Item.ItemType = ListViewItemType.DataItem Then

      CType(e.Item.FindControl("hlMaksuaineisto"), HyperLink).Text = "Lataa maksuaineisto (" & e.Item.DataItem & ")"
      CType(e.Item.FindControl("hlMaksuaineisto"), HyperLink).NavigateUrl = Hakemistot.MaksuaineistoHakemistoRelatiivinen & e.Item.DataItem

    End If

  End Sub

  Private Sub lvKirjanpidonAineistot_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvKirjanpidonAineistot.ItemDataBound

    If e.Item.ItemType = ListViewItemType.DataItem Then

      CType(e.Item.FindControl("hlKirjanpidonAineisto"), HyperLink).Text = "Lataa kirjanpitoaineisto (" & e.Item.DataItem & ")"
      CType(e.Item.FindControl("hlKirjanpidonAineisto"), HyperLink).NavigateUrl = Hakemistot.KirjanpidonaineistoHakemistoRelatiivinen & e.Item.DataItem

    End If

  End Sub

  Private Sub LahetaSahkopostiMaksuaineistosta(maksuaineisto As DTO.Maksuaineisto, tunniste As String, aineistot As List(Of DTO.MaksuaineistoPalaute))

    Dim objPalautusarvo As DTO.Palautusarvo

    Dim strViesti As String = String.Format("Sopimusrekisterin maksuaineisto on luotu. Tunniste {0}. Yhteensä {1} €.", tunniste, Luvut.EsitaNullableDecimal(maksuaineisto.Maksut.Sum(Function(x) x.Summa.GetValueOrDefault(0))))

    strViesti &= vbCrLf & vbCrLf

    For Each aineisto As DTO.MaksuaineistoPalaute In aineistot

      strViesti &= aineisto.KopioTiedostonimi & " = " & Luvut.EsitaNullableDecimal(aineisto.Summa) & " €" & vbCrLf

    Next

    objPalautusarvo = Email.Laheta(Konfiguraatiot.MaksuaineistoOsoite, "Sopimusrekisterin maksuaineisto on luotu", strViesti)

    If Not objPalautusarvo.Ok Then
      LomakeVirhe.LisaaVirhe("Sähköpostin lähettäminen osoitteeseen " & Konfiguraatiot.MaksuaineistoOsoite & " epäonnistui")
    End If

  End Sub

  Private Sub LahetaSahkopostiKirjanpidonAineistosta(maksuaineisto As DTO.Maksuaineisto, tunniste As String, aineistot As List(Of DTO.MaksuaineistoPalaute))

    Dim objPalautusarvo As DTO.Palautusarvo

    Dim strViesti As String = String.Format("Sopimusrekisterin kirjanpitoaineisto on luotu. Tunniste {0}. Yhteensä {1} €.", tunniste, Luvut.EsitaNullableDecimal(maksuaineisto.Maksut.Sum(Function(x) x.Summa.GetValueOrDefault(0))))

    strViesti &= vbCrLf & vbCrLf

    For Each aineisto As DTO.MaksuaineistoPalaute In aineistot

      strViesti &= aineisto.Tiedosto & " = " & Luvut.EsitaNullableDecimal(aineisto.Summa) & " €" & vbCrLf

    Next

    objPalautusarvo = Email.Laheta(Konfiguraatiot.KirjanpitoaineistoOsoite, "Sopimusrekisterin kirjanpitoaineisto on luotu", strViesti)

    If Not objPalautusarvo.Ok Then
      LomakeVirhe.LisaaVirhe("Sähköpostin lähettäminen osoitteeseen " & Konfiguraatiot.KirjanpitoaineistoOsoite & " epäonnistui")
    End If

  End Sub

  Private Sub gvMaksettavaAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMaksettavaAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    EstaLinewrap(sender)

  End Sub

  Private Sub gvTarkistettavaAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTarkistettavaAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    EstaLinewrap(sender)

  End Sub

  Private Sub gvVirheellinenAineisto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvVirheellinenAineisto.RowDataBound

    MuokkaaTaulukonLinkkeja(e)
    EstaLinewrap(sender)

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

      Dim rivi = DirectCast(e.Row.DataItem, DTO.Maksuraportti)

      CType(e.Row.FindControl("hlSopimus"), HyperLink).NavigateUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", rivi.SopimusId)
      CType(e.Row.FindControl("hlKorvauslaskelma"), HyperLink).NavigateUrl = String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", rivi.KorvauslaskelmaId, rivi.SopimusId)

    End If

  End Sub

  Protected Sub btnPaivitaMaksuaineisto_Click(sender As Object, e As EventArgs) Handles btnPaivitaMaksuaineisto.Click

    HaeMaksuaineisto()

  End Sub

End Class