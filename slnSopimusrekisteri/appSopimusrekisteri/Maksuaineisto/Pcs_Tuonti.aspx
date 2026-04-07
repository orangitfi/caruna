<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Pcs_Tuonti.aspx.vb" Inherits="appSopimusrekisteri.Pcs_Tuonti" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LomakeVirhe.ascx" TagName="LomakeVirhe" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <h1>PCS-AINEISTON TUONTI</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
      <uc1:LomakeVirhe ID="LomakeVirhe" runat="server" />
    </div>
    <div class="formInfo">
      Voit tuoda PCS-aineiston järjestelmään. Tekemäsi muutokset näkyvät heti maksuaineistoa koskevien sopimusten maksuajoja tehtäessä.
    </div>
    <table class="form" cellpadding="0" cellspacing="0">
      <tr>
        <td class="formHeader">Tiedosto</td>
        <td class="formValidation">
          <asp:CustomValidator ID="cvTiedosto" runat="server"></asp:CustomValidator></td>
        <td class="formInputElement">
          <asp:FileUpload ID="FileUpload1" runat="server" /></td>
      </tr>
      <tr>
        <td colspan="2"></td>
        <td class="formActions">
          <asp:Button ID="btnLataa" runat="server" Text="Lataa tiedosto" />
          <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
