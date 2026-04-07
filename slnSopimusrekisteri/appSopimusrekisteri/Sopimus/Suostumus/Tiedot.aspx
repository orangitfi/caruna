<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.Sopimus.Suostumus.Tiedot" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Sopimus/Tunnisteyksikot.ascx" TagName="Tunnisteyksikot" TagPrefix="uc" %>
<%@ Register Src="~/Sopimus/Asiakkaat.ascx" TagName="Asiakkaat" TagPrefix="uc" %>
<%@ Register Src="~/Sopimus/Kiinteistot.ascx" TagName="Kiinteistot" TagPrefix="uc" %>
<%@ Register Src="~/Sopimus/Tiedostot.ascx" TagName="Tiedostot" TagPrefix="uc" %>
<%@ Register Src="~/Sopimus/Aktiviteetit.ascx" TagName="Aktiviteetit" TagPrefix="uc" %>
<%@ Register Src="~/Sopimus/Alasopimukset.ascx" TagName="Alasopimukset" TagPrefix="uc" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <div id="headerData" runat="server">
        <h2>
            <asp:Label ID="hSopimustyypinNimi" runat="server"></asp:Label>
            <asp:Label ID="hNimi" runat="server"></asp:Label></h2>
        <div class="viewInfo">
            <table>
                <tr>
                    <td class="viewInfoContentElement" width="300px" valign="top">Projektinumero:
            <asp:Label ID="hPCSNumero" runat="server"></asp:Label></td>
                    <td class="viewInfoContentElement" width="300px" valign="top">Alkamispvm:
            <asp:Label ID="hAlkaa" runat="server"></asp:Label><br />
                        Päättymispvm:
            <asp:Label ID="hPaattyy" runat="server"></asp:Label><br />
                        Irtisanomispvm:
            <asp:Label ID="hIrtisanomispvm" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="viewInfoClearElement"></div>
        </div>
    </div>
    <div id="formData" runat="server">
        <div class="headerBar">
            <h1>
                <asp:Label ID="Nimi" runat="server"></asp:Label></h1>
            <div class="headerBarActionImgLink">
                <asp:Image ID="imgPrint" SkinID="PrintImage" AlternateText="Avaa tulostusnäkymä" runat="server" />
            </div>
        </div>
        <div class="view2columns">
            <table>
                <tr>
                    <td class="view2columnsHeader1">Sopimusnumero</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Id" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Muu tunniste</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="MuuTunniste" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Sopimuslaji</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Sopimustyyppi_SopimustyyppiNimi" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Sopimuksen laatija</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="SopimuksenLaatija" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Korvaukseton</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Korvaukseton" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Karttaliite</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Karttaliite" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Juridinen yhtiö</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="JuridinenYhtio_Nimi" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Projektivalvoja</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Projektinvalvoja" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Projektinumero</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="PCSNumero" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Korvaa sopimuksen</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Korvaa" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">CaCe-tehtävä</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="CaceTehtava" runat="server"></asp:Label>
                    </td>
                    <td class="view2columnsHeader2">Puuston omistajuus</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="PuustonOmistajuus_Nimi" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Verkkoyhtiön rooli sopimuksessa</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="DFRooli_Nimi" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Puuston poisto</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="PuustonPoisto_Nimi" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Asiakkaan allekirjoituspäivämäärä</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="AsiakkaanAllekirjoitusPvm" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Alkupvm</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Alkaa" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Verkonhaltijan allekirjoituspäivämäärä</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="VerkonhaltijanAllekirjoitusPvm" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Päättymispvm</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Paattyy" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Sopimuksen jatkoaika (kk)</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Jatkoaika" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Sopimuksen laskettu päättymispvm</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="LaskennallinenPaattymispvm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Sopimusvuosi</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Sopimusvuosi" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Kieli</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Kieli_Nimi" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Sopimuksen irtisanomisaika</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="SopimuksenIrtisanomisaika" runat="server"></asp:Label>
                    </td>
                    <td class="view2columnsHeader2"></td>
                    <td class="view2columnsContentElement2"></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Sopimuksen irtisanomistoimet</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="SopimuksenIrtisanomistoimet" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Erityisehdot</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="Erityisehdot" runat="server"></asp:Label></td>
                </tr>
                <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
                    <tr>
                        <td class="view2columnsHeader1">Alkuperäinen yhtiö</td>
                        <td class="view2columnsContentElement1">
                            <asp:Label ID="AlkuperainenYhtio_Nimi" runat="server"></asp:Label></td>
                        <td class="view2columnsHeader2">Julkisuusaste</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="Julkisuusaste_Nimi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="view2columnsHeader1">Ylätason sopimus</td>
                        <td class="view2columnsContentElement1">
                            <asp:HyperLink ID="Paasopimus_Nimi" runat="server"></asp:HyperLink>
                        </td>
                        <td class="view2columnsHeader2">Yläsopimuksen tyyppi</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="YlasopimuksenTyyppi_Nimi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="view2columnsHeader1">Sopimuksen alaluokka</td>
                        <td class="view2columnsContentElement1">
                            <asp:Label ID="SopimuksenAlaluokka_Nimi" runat="server"></asp:Label></td>
                        <td class="view2columnsHeader2">Mappitunniste</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="Mappitunniste" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="view2columnsHeader1">Sopimuksen ehtoversio</td>
                        <td class="view2columnsContentElement1">
                            <asp:Label ID="SopimuksenEhtoversio_Nimi" runat="server"></asp:Label></td>
                        <td class="view2columnsHeader2">Sisällön yleiskuvaus</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="Kuvaus" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="view2columnsHeader1">Sopimuksen siirto-oikeus vastaosapuoli</td>
                        <td class="view2columnsContentElement1">
                            <asp:Label ID="VastaosapuoliSiirtoOikeus_Nimi" runat="server"></asp:Label></td>
                        <td class="view2columnsHeader2">Sopimuksen kohdekategoria</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="Kohdekategoria_Nimi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="view2columnsHeader1">Sopimuksen siirto-oikeus verkonhaltija</td>
                        <td class="view2columnsContentElement1">
                            <asp:Label ID="VerkonhaltijaSiirtoOikeus_Nimi" runat="server"></asp:Label></td>
                        <td class="view2columnsHeader2">Sopimuksen irtisanomispvm</td>
                        <td class="view2columnsContentElement2">
                            <asp:Label ID="Irtisanomispvm" runat="server"></asp:Label></td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phIFRS" Visible="false">
                    <tr>
                        <td class="view2columnsHeader1">FAS/IFRS</td>
                        <td class="view2columnsContentElement1" colspan="3">
                            <asp:Label ID="lblIFRS" runat="server"></asp:Label></td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td class="view2columnsHeader1">Luovutettujen pylväiden määrä</td>
                    <td class="view2columnsContentElement1">
                        <asp:Label ID="Pylvasvali" runat="server"></asp:Label></td>
                    <td class="view2columnsHeader2">Tila</td>
                    <td class="view2columnsContentElement2">
                        <asp:Label ID="SopimuksenTila_Nimi" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="view2columnsHeader1">Lisätietoja</td>
                    <td class="view2columnsContentElement1" colspan="3">
                        <asp:Label ID="Info" runat="server"></asp:Label></td>
                </tr>
            </table>

            <div class="view2columnsClearElement"></div>
        </div>
        <div class="footerBar">
            <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
            <asp:Button ID="btnLisaaAlasopimus" runat="server" Text="Lisää alasopimus" />
            <asp:Button ID="btnKopioi" runat="server" Text="Kopioi" />
            <asp:Button ID="btnPoista" runat="server" Text="Poista lopullisesti" style="filter: hue-rotate(135deg)" Visible="false" OnClick="btnPoista_Click" />
            <asp:Label runat="server" ID="lblPoistoVirhe" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </div>
    <uc:Tunnisteyksikot ID="Tunnisteyksikot1" runat="server" />
    <uc:Asiakkaat ID="Asiakkaat1" runat="server" />
    <uc:Kiinteistot ID="Kiinteistot1" runat="server" />
    <uc:Tiedostot ID="Tiedostot1" runat="server" />
    <uc:Aktiviteetit ID="Aktiviteetit1" runat="server" />
    <uc:Alasopimukset ID="Alasopimukset" runat="server" />

</asp:Content>
