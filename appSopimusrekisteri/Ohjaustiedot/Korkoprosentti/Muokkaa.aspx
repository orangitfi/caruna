<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.KorkoprosentinMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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

    <h1>Korkoprosentin tiedot</h1>
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
                <td class="formHeader">* Jäljellä oleva vuokra-aika vuosissa</td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvVuodet" ErrorMessage="Jäljellä oleva vuokra-aika vuosissa on pakollinen tieto" ControlToValidate="Vuodet" Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" ID="cvVuodet" ErrorMessage="Anna vuodet kokonaislukuna" Operator="DataTypeCheck" ControlToValidate="Vuodet" Type="Integer" Display="None"></asp:CompareValidator>
                    <asp:CustomValidator runat="server" ID="cusVuodet" ErrorMessage="Annetulle vuodelle löytyy jo toinen korkoprosentti" OnServerValidate="cusVuodet_ServerValidate" Display="None"></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="Vuodet" runat="server" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">* Korkoprosentti (%)</td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvProsentti" ErrorMessage="Korkoprosentti on pakollinen tieto" ControlToValidate="Prosentti" Display="None"></asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" ID="cvProsentti" ErrorMessage="Anna prosentti kokonaislukuna tai desimaalina" Operator="DataTypeCheck" Display="None" ControlToValidate="Prosentti" Type="Double"></asp:CompareValidator>
                    <asp:CustomValidator runat="server" ID="cusProsentti" ErrorMessage="Anne prosenttiluku välillä 0-100." OnServerValidate="cusProsentti_ServerValidate" Display="None"></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="Prosentti" runat="server" MaxLength="5"></asp:TextBox>
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
