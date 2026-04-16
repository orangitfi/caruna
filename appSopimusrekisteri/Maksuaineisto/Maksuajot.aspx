<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Maksuajot.aspx.vb" Inherits="appSopimusrekisteri.Maksuajot" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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

  <div class="headerBar">
    <h1>MAKSUAJOT</h1>
  </div>
  <div class="view">
    <div class="viewInfoFull">
    </div>
    <ul class="viewLinkElement">
      <li>
        <asp:HyperLink ID="hlMaksuaineisto" NavigateUrl="Maksuaineisto_IFS.aspx" runat="server">Maksuaineiston teko</asp:HyperLink></li>
    </ul>
    <div class="viewInfoFull">
    </div>
    <ul class="viewLinkElement">
      <li>
        <asp:HyperLink ID="hlPcsTuonti" NavigateUrl="Pcs_Tuonti.aspx" runat="server">PCS-aineiston tuonti</asp:HyperLink></li>
    </ul>
  </div>

</asp:Content>
