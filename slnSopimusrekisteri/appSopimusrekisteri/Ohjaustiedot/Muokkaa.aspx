<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.Ohjaustiedot.Muokkaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
  <h1>
    <asp:Label ID="lblOtsikko" runat="server"></asp:Label></h1>
  <div id="formData" class="form" runat="server">
    <asp:HiddenField ID="hdnTyyppi" runat="server" />
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
      * merkityt tiedot ovat pakollisia
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
        <td class="formHeader">Nimi *</td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ID="ReqValNimi" runat="server" ErrorMessage="Nimi on pakollinen tieto" ControlToValidate="Nimi"></asp:RequiredFieldValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Nimi" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formDescription"></td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btnTallenna" runat="server" Text="Tallenna" CausesValidation="True" />
          <asp:Button ID="btnPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
