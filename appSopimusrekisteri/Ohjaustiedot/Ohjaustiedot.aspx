<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Ohjaustiedot.aspx.vb" Inherits="appSopimusrekisteri.Ohjaustietolista" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Import Namespace="Sopimusrekisteri.BLL_CF" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

    <div class="headerBar">
        <h1>OHJAUSTIEDOT</h1>
    </div>
    <div class="view">
        <div class="viewInfoFull">
            Voit lisätä, muokata ja poistaa ohjaustietoja. Jos ohjaustieto on käytössä, sitä ei voi poistaa. Tekemäsi muutokset näkyvät heti rekisterin alasvetovalikoissa.
        </div>
        <ul class="viewLinkElement">
            <li>
                <asp:HyperLink ID="hlKorvaushinnasto" NavigateUrl="~/Ohjaustiedot/Korvaushinnasto/Tiedot.aspx" runat="server">Korvaushinnastot</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Ohjaustiedot/AktiviteetinLaji/Tiedot.aspx" runat="server">Aktiviteetin lajit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Ohjaustiedot/AktiviteetinStatus/Tiedot.aspx" runat="server">Aktiviteetin statukset</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink4" NavigateUrl="~/Ohjaustiedot/AktiviteettienYhteystapa/Tiedot.aspx" runat="server">Aktiviteetin yhteystavat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink5" NavigateUrl="~/Ohjaustiedot/ArkistonSijainti/Tiedot.aspx" runat="server">Arkiston sijainnit</asp:HyperLink></li>
            <li>
                <a href="Tiedot.aspx?tyyppi=<%= Sopimusrekisteri.BLL_CF.Ohjaustiedot.Asiakastyyppi.ToString()%>">Asiakasroolit</a></li>
            <li>
                <asp:HyperLink ID="HyperLink7" NavigateUrl="~/Ohjaustiedot/AsiakirjojenTarkenne/Tiedot.aspx" runat="server">Asiakirjojen tarkenteet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink8" NavigateUrl="~/Ohjaustiedot/DFRooli/Tiedot.aspx" runat="server">DF-roolit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink35" NavigateUrl="~/Ohjaustiedot/HinnastonKategoria/Tiedot.aspx" runat="server">Hinnaston kategoriat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink9" NavigateUrl="~/Ohjaustiedot/HinnastonAlakategoria/Tiedot.aspx" runat="server">Hinnaston alakategoriat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Ohjaustiedot/Indeksi/Tiedot.aspx" runat="server">Indeksit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink10" NavigateUrl="~/Ohjaustiedot/Indeksityyppi/Tiedot.aspx" runat="server">Indeksityypit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink39" NavigateUrl="~/Ohjaustiedot/InvCost/Tiedot.aspx" runat="server">Inv/Costit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink11" NavigateUrl="~/Ohjaustiedot/Julkisuusaste/Tiedot.aspx" runat="server">Julkisuusasteet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink13" NavigateUrl="~/Ohjaustiedot/KirjanpidonTili/Tiedot.aspx" runat="server">Kirjanpidon tilit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink36" NavigateUrl="~/Ohjaustiedot/KirjanpidonKustannuspaikka/Tiedot.aspx" runat="server">Kirjanpidon kustannuspaikat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink42" NavigateUrl="~/Ohjaustiedot/Korkoprosentti/Tiedot.aspx" runat="server">Korkoprosentit (IFRS)</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink14" NavigateUrl="~/Ohjaustiedot/Kunta/Tiedot.aspx" runat="server">Kunnat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink15" NavigateUrl="~/Ohjaustiedot/Kyla/Tiedot.aspx" runat="server">Kylät</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink16" NavigateUrl="~/Ohjaustiedot/LiiketoiminnanTarve/Tiedot.aspx" runat="server">Liiketoiminnan tarpeet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink38" NavigateUrl="~/Ohjaustiedot/Local1/Tiedot.aspx" runat="server">Local1:t</asp:HyperLink></li>
            <li>
                <a href="Tiedot.aspx?tyyppi=<%= Sopimusrekisteri.BLL_CF.Ohjaustiedot.Lupataho.ToString()%>">Lupatahot</a></li>
            <li>
                <asp:HyperLink ID="HyperLink17" NavigateUrl="~/Ohjaustiedot/Maa/Tiedot.aspx" runat="server">Maat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink18" NavigateUrl="~/Ohjaustiedot/Maaraalatarkenne/Tiedot.aspx" runat="server">Määräalan tarkenteet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink19" NavigateUrl="~/Ohjaustiedot/Maksualue/Tiedot.aspx" runat="server">Maksualueet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink20" NavigateUrl="~/Ohjaustiedot/MaksunSuoritus/Tiedot.aspx" runat="server">Maksun suoritukset</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink21" NavigateUrl="~/Ohjaustiedot/Metsatyyppi/Tiedot.aspx" runat="server">Metsätyypit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink22" NavigateUrl="~/Ohjaustiedot/PassivoinninSyy/Tiedot.aspx" runat="server">Passivoinnin syyt</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink23" NavigateUrl="~/Ohjaustiedot/Postitiedot/Tiedot.aspx" runat="server">Postitiedot</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink12" NavigateUrl="~/Ohjaustiedot/Purpose/Tiedot.aspx" runat="server">Purposet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink24" NavigateUrl="~/Ohjaustiedot/Puustolaji/Tiedot.aspx" runat="server">Puustolajit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink25" NavigateUrl="~/Ohjaustiedot/PuustonOmistajuus/Tiedot.aspx" runat="server">Puuston omistajuudet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink26" NavigateUrl="~/Ohjaustiedot/PuustonPoisto/Tiedot.aspx" runat="server">Puuston poistotavat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink37" NavigateUrl="~/Ohjaustiedot/Regulation/Tiedot.aspx" runat="server">Regulationit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink27" NavigateUrl="~/Ohjaustiedot/Saanto/Tiedot.aspx" runat="server">Säännöt</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink28" NavigateUrl="~/Ohjaustiedot/Siirtooikeus/Tiedot.aspx" runat="server">Siirto-oikeudet</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink29" NavigateUrl="~/Ohjaustiedot/SopimuksenAlaluokka/Tiedot.aspx" runat="server">Sopimuksen alaluokat</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink30" NavigateUrl="~/Ohjaustiedot/SopimuksenEhtoversio/Tiedot.aspx" runat="server">Sopimuksen ehtoversiot</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink31" NavigateUrl="~/Ohjaustiedot/SopimuksenKesto/Tiedot.aspx" runat="server">Sopimuksen kestot</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink32" NavigateUrl="~/Ohjaustiedot/Sopimusformaatti/Tiedot.aspx" runat="server">Sopimusformaatit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink33" NavigateUrl="~/Ohjaustiedot/Tunnisteyksikko/Tiedot.aspx" runat="server">Tunnisteyksiköt</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink34" NavigateUrl="~/Ohjaustiedot/TunnisteyksikonTyyppi/Tiedot.aspx" runat="server">Tunnisteyksikön tyypit</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink43" NavigateUrl="~/Ohjaustiedot/Vuokratyyppi/Tiedot.aspx" runat="server">Vuokratyypit (IFRS)</asp:HyperLink></li>
        </ul>
    </div>
    <div class="headerBar">
        <h1>YLLÄPITOTOIMINNOT</h1>
    </div>
    <div class="view">


        <div class="viewInfoFull">
        </div>
        <ul class="viewLinkElement">
            <li>
                <asp:HyperLink ID="HyperLink40" NavigateUrl="~/Ohjaustiedot/Korvaushinnasto/Tuonti.aspx" runat="server">Korvaushinnastojen tuonti</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Ohjaustiedot/SopimusExcel/Vienti.aspx" runat="server">Sopimustietojen vienti Killasta Exceliin (Sopimuspohjien luonti / sopimusnumeroiden varaus)</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink41" NavigateUrl="~/Ohjaustiedot/SopimusExcel/Tuonti.aspx" runat="server">Sopimustietojen tuonti Excelistä Kiltaan</asp:HyperLink></li>
            <li>
                <asp:HyperLink ID="HyperLink44" NavigateUrl="~/Ohjaustiedot/TiedostoExcel/Tuonti.aspx" runat="server">M-Files tiedostolinkkien tuonti Excelistä Kiltaan</asp:HyperLink></li>
        </ul>
    </div>

</asp:Content>
