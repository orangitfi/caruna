<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Kayttaja.aspx.vb" Inherits="appSopimusrekisteri.Kayttaja" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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


    <h1>Käyttäjätilin tiedot</h1>

    <div class="form">
        <div class="formValidationInfo">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

        <table class="form">
            <tr>
                <td class="formHeader">Käyttäjätunnus</td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator ID="ReqValtxtKayttajatunnus" runat="server" ControlToValidate="txtKayttajatunnus" ErrorMessage="Käyttäjätunnus on pakollinen tieto"></asp:RequiredFieldValidator>

                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="txtKayttajatunnus" runat="server" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sähköposti</td>
                <td class="formValidation">
                    <asp:RegularExpressionValidator ID="regSahkoposti" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtSahkoposti" ErrorMessage="Sähköpostiosoite on väärässä muodossa"></asp:RegularExpressionValidator>

                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="txtSahkoposti" runat="server" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Etunimi</td>
                <td class="formValidation">&nbsp;
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="txtEtunimi" runat="server" MaxLength="100"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    <td class="formHeader">Sukunimi</td>
                    <td class="formValidation">&nbsp;
                    </td>
                    <td class="formInputElement">
                        <asp:TextBox ID="txtSukunimi" runat="server" MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Salasana</td>
                    <td class="formValidation">&nbsp;<asp:RequiredFieldValidator ID="ReqValtxtSalasana" runat="server" ControlToValidate="txtSalasana" ErrorMessage="Salasana on pakollinen tieto"></asp:RequiredFieldValidator>
&nbsp;</td>
                    <td class="formInputElement">
                        <asp:TextBox ID="txtSalasana" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td class="formActions">
                        <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="true"></asp:Button>
                        <asp:Button ID="btPeruuta" PostBackUrl="~/Yllapito/Kayttajat.aspx" runat="server" CausesValidation="False" Text="Peruuta"></asp:Button>
                    </td>
                </tr>
        </table>
    </div>

</asp:Content>
