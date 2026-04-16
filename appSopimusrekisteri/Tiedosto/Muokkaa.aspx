<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.NSTiedosto.Muokkaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>
<%@ Register Assembly="Sopimusrekisteri.Controls" Namespace="Sopimusrekisteri.Controls" TagPrefix="controls" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Label ID="lblOtsikko" runat="server"></asp:Label></h1>
    <div class="form" id="formData" runat="server">
        <div class="formValidationInfo">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <div class="formInfo">
        </div>
        <div class="formDateInfo">
            <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="Paivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="Paivittaja" runat="server"></asp:Label>)
            <br />
            <b>Luotu:</b>&nbsp;
            <asp:Label ID="Luotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="Luoja" runat="server"></asp:Label>)
        </div>
        <table class="form">
            <tr>
                <td class="formHeader">* Tiedoston nimi
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvTiedostoNimi" ErrorMessage="Tiedoston nimi on pakollinen tieto" Display="None" ControlToValidate="TiedostoNimi"></asp:RequiredFieldValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="TiedostoNimi" MaxLength="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">* M-Files linkki
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvMFilesLinkki" ErrorMessage="M-Files linkki on pakollinen tieto" Display="None" ControlToValidate="txtMFilesLinkki"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="cvMFilesLinkki" ErrorMessage="Tarkista M-Files linkin muoto. Linkin tulee sisältää m-files:// polun skeema." OnServerValidate="cvMFilesLinkki_ServerValidate" Display="None"></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="txtMFilesLinkki" MaxLength="3000"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Asiakirjatarkenne
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="Asiakirjatarkenne" MaxLength="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Arkistoviite
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="ArkistointiTunniste" MaxLength="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Button ID="btTallenna" runat="server" Text="Tallenna" />
                    <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
