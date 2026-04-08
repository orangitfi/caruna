<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Rooli.aspx.vb" Inherits="appSopimusrekisteri.Rooli" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">        
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
     <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
 
  <h1>Roolin tiedot</h1>
  <div class="form">
    <div class="formValidationInfo"><asp:validationsummary ID="ValidationSummary1" runat="server" /></div>
    
    <div class="formInfo">
      <%--Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident. --%>
    </div>
  
    <table class="form">
      <tr>
        <td class="formHeader">Nimi</td>
        <td class="formValidation">&nbsp;
        </td>
          <td class="formInputElement">
              <asp:TextBox ID="txtNimi" runat="server" Text='' MaxLength="300"></asp:TextBox></td>
        </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:button ID="btTallenna" runat="server" Text='Tallenna' CausesValidation="True" />
          <asp:button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
