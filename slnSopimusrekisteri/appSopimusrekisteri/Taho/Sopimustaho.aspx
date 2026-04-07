<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Sopimustaho.aspx.vb" Inherits="appSopimusrekisteri.Taho.Sopimustaho" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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

  <h1>Osapuolten roolit</h1>
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
        <td class="formHeader">Rooli</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="AsiakastyyppiId" runat="server"></asp:DropDownList></td>
      </tr>
      <tr>
        <td class="formHeader"></td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:CheckBox ID="TulostetaanSopimukseen" runat="server" Text="Tulostetaan sopimukseen" Checked="true" />
      </tr>
      <tr>
        <td class="formHeader">Verkkoyhtiön rooli</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="DFRooliId" runat="server"></asp:DropDownList></td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formDescription"></td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
