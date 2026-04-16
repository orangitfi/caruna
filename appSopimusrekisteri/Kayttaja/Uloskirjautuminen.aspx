<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Uloskirjautuminen.aspx.vb" Inherits="appSopimusrekisteri.Uloskirjautuminen" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">     
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
 
  <h1>Uloskirjautuminen</h1>
  <div class="form">
    <div class="formValidationInfo"><asp:validationsummary ID="ValidationSummary1" runat="server" /></div>
    
    <div class="formInfo">
      Olet kirjautunut ulos ja voit sulkea selaimen ikkunan.<br />Jos haluat kirjautua sisään uudestaan klikkaa <a href="Kirjautuminen.aspx">tästä</a>.
    </div>
  </div>

</asp:Content>
