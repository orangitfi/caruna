<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.VuokratyypinMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

    <h1>Vuokratyypin tiedot</h1>
    <div class="form" runat="server" id="form">
        <div class="formValidationInfo">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <div class="formDateInfo">
            <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
                <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblPaivittaja" runat="server"></asp:Label>)
            <br />
                <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblLuoja" runat="server"></asp:Label>)
            </asp:PlaceHolder>
        </div>
        <table class="form">
            <tr>
                <td class="formHeader">* Nimi</td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvNimi" ErrorMessage="Nimi on pakollinen tieto" ControlToValidate="Nimi" Display="None"></asp:RequiredFieldValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="Nimi" runat="server" MaxLength="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Button ID="btTallenna" runat="server" Text='Tallenna' CausesValidation="True" />
                    <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
