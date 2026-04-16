<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tuonti.aspx.vb" Inherits="appSopimusrekisteri.SopimusExcelTuonti" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">

    <div class="bar barExtensionGray" style="margin-bottom: 0;">
        <h1>Sopimusten tietojen tuonti</h1>
        <div class="barAction">
            <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
        </div>
    </div>

    <div class="form formExtensionAccordion" style="border-top: none;">
        <table class="form">
            <tr>
                <td colspan="3" class="formValidationInfo">
                    <asp:ValidationSummary runat="server" ID="VSTuonti" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">* Excel tiedosto:
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvTiedosto" Display="None" ErrorMessage="Valitse tiedosto ensin." ControlToValidate="fuTiedosto"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="cvTiedosto" Display="None" OnServerValidate="cvTiedosto_ServerValidate"></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:FileUpload runat="server" ID="fuTiedosto" AllowMultiple="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Button runat="server" ID="btnEsikatsele" Text="Esikatsele tuotavia tietoja" OnClick="btnEsikatsele_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Label runat="server" ID="lblOnnistunut" ForeColor="Green" Visible="false">Tiedot tuotiin onnistuneesti!</asp:Label>
                    <asp:Label runat="server" ID="lblTuntematonVirhe" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    
    <asp:PlaceHolder runat="server" ID="phTulokset" Visible="false">
        <br />
        <br />
        <div class="list" runat="server" id="tblTiedot">
            <div class="bar barExtensionGray" style="margin-bottom: 0;">
                <h1>Tuotavat tiedot</h1>
                <div class="barAction" style="margin-top: 0;">
                    <asp:Button runat="server" ID="btnTuo" Text="Tuo tiedot" Style="margin-top: 0;" OnClick="btnTuo_Click" CausesValidation="false" OnClientClick="return confirm('Sopimuksista ylikirjoitetaan tiedot Excelin tiedoilla. Haluatko varmasti jatkaa?')" />
                </div>
            </div>
            <table class="listGridview" style="border-collapse: collapse;">
                <thead>
                    <tr class="listGridviewHeader">
                        <th>Seloste</th>
                        <th>Kpl määrä / Sopimusnumero -> Virheellisen tiedon arvo</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="listGridviewItem">
                        <td>Tuotavia sopimuksia (kpl)</td>
                        <td>
                            <asp:Label runat="server" ID="lblSopimuksia"></asp:Label>
                        </td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Päivitettäviä tahoja (kpl)</td>
                        <td><asp:Label runat="server" ID="lblPaivitettaviaTahoja"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Päivitettäviä kiinteistöjä (kpl)</td>
                        <td><asp:Label runat="server" ID="lblPaivitettaviaKiinteistoja"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Uusia tahoja (kpl)</td>
                        <td><asp:Label runat="server" ID="lblUusiaTahoja"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Uusia kiinteistöjä (kpl)</td>
                        <td><asp:Label runat="server" ID="lblUusiaKiinteistoja"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Sopimukset, joilla on virheellinen sopimustyyppi tai se puuttuu (Sopimustyyppiä ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenSopimustyyppi" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Sopimukset, joilla on virheellinen juridinen yhtiö (Yhtiötä ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenJuridinenYhtio" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Sopimukset, joilla on virheellinen kieli (Kieltä ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenKieli" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Sopimukset, joilla on virheellinen tila (Tilaa ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenTila" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Asiakkaat, joilla on virheellinen asiakastyyppi (Asiakastyyppiä ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenAsiakastyyppi" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Asiakkaat, joilla on virheellinen tahotyyppi tai se puuttuu (Tahon tyyppiä ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenTahoTyyppi" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Asiakkaat, joilla on virheellinen rooli (Roolia ei tunnistettu tai löydetty rekisteristä)</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenRooli" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Kiinteistöt, joiden kuntaa ei tunnistettu tai löydetty rekisteristä</td>
                        <td><asp:Label runat="server" ID="lblVirheellinenKunta"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:PlaceHolder>
</asp:Content>
