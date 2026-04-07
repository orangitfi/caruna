<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Poimintajoukko_testi.aspx.vb" Inherits="appSopimusrekisteri.Poimintajoukko_testi" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/PoimintaTyokalut.ascx" TagName="PoimintaTyokalut" TagPrefix="uc3" %>
<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc3:PoimintaTyokalut ID="PoimintaTyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div class="bar barExtensionGray">
    <h1>POIMINTA</h1>
  </div>
  <div class="info">
    <asp:Label ID="lblPoimintaehdotNaytolle" runat="server" Visible="False"></asp:Label>
  </div>
  <div class="bar">
    <div class="barText">
      <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </div>
    <div class="barAction">
      <asp:HyperLink ID="hlExcel" runat="server" Target="_blank" Visible="False">Lataa Excel-tiedosto</asp:HyperLink>
    </div>
  </div>
  <div class="headerBarWhite">
    <asp:Button ID="btnUusiPoiminta" runat="server" Text="Uusi poiminta" />
    <asp:Button ID="btnLisaaPoimintaan" runat="server" Text="Lisää poimintaan" Visible="False" />
    <asp:Button ID="btnPoistaPoiminnasta" runat="server" Text="Poista poiminnasta" Visible="False" />
    <asp:Button ID="btnNollaa" runat="server" Text="Nollaa poiminta" Visible="False" />
  </div>
  <div class="list">
    <asp:GridView ID="gvPoimitut" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="true">
      <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Label ID="lblPageCount" runat="server" Visible="False"></asp:Label>
  </div>
</asp:Content>
