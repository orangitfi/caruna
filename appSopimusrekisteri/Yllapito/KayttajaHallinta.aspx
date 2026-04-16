<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KayttajaHallinta.aspx.vb" Inherits="appSopimusrekisteri.KayttajaHallinta" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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
    <h1>KÄYTTÄJIEN HALLINTA</h1>
  </div>
  <div class="view">
    <div class="viewInfoFull">
    </div>
    <ul class="viewLinkElement">
      <li>
        <asp:HyperLink ID="hlKayttajat" NavigateUrl="~/Yllapito/Kayttajat.aspx" runat="server">Käyttäjät</asp:HyperLink></li>
      <li>
        <asp:HyperLink ID="hlRyhmat" NavigateUrl="~/Yllapito/Ryhmat.aspx" runat="server">Ryhmät</asp:HyperLink></li>
    </ul>
  </div>

</asp:Content>
