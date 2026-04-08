<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Raportit.aspx.vb" Inherits="appSopimusrekisteri.Raportit" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/PoimintaTyokalut.ascx" TagName="PoimintaTyokalut" TagPrefix="uc3" %>
<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div class="bar barExtensionGray">
    <h1>RAPORTIT</h1>
  </div>
  <div class="info">
  </div>
  <ul runat="server" id="ulKorvauslaskelma" visible="false">
    <li>
      <asp:HyperLink ID="hlKorvauslaskelma" runat="server" NavigateUrl="~/Raportit/Raportti.aspx?reportControl=RaporttiKontrollit/Korvauslaskelma.ascx">Korvauslaskelmat</asp:HyperLink>
    </li>
  </ul>

  <ul runat="server" id="ulVuokrat" visible="false">
    <li>
      <asp:HyperLink ID="hlVuokrat" runat="server" NavigateUrl="~/Raportit/Raportti.aspx?reportControl=RaporttiKontrollit/Vuokrat.ascx">Vuokrat</asp:HyperLink>
    </li>
  </ul>
    
  <ul runat="server" id="ulIFRS" visible="false">
    <li>
      <asp:HyperLink ID="hlIFRS" runat="server" NavigateUrl="~/Raportit/IFRS.aspx">IFRS- ja FAS-Vuokrat ja maturiteetti</asp:HyperLink>
    </li>
  </ul>
</asp:Content>

