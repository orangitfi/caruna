<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.TunnisteyksikonTiedot" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
  <!-- Yläosan tiedot -->
  <h3>
    <asp:Label ID="lblNimi" runat="server" Font-Bold="true"></asp:Label></h3>
  <div class="viewInfo">
    <table>
      <tr>
        <td class="viewInfoContentElement" rowspan="2">
          <b>Tunnisteyksikön sopimus</b><br />
          <br />
          <asp:Label ID="lblSopimus" runat="server"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="viewInfoContentElement"></td>
      </tr>
    </table>
    <div class="viewInfoClearElement"></div>
  </div>

  <div class="headerBar">
    <h1>
      <asp:Label ID="lblNimiOtsikko" runat="server"></asp:Label></h1>
    <div class="headerBarActionImgLink">
      <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server">
        <asp:Image ID="imgPrint" SkinID="PrintImage" AlternateText="Avaa tulostusnäkymä" runat="server" />
      </asp:HyperLink>
    </div>
  </div>
  <div class="view2columns">
    <table>

      <tr>
        <td class="view2columnsHeader1">Tunnisteyksikön tyyppi</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTUYTunnisteyksikkoTyyppiId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Muu tunniste</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblTUYTunnus" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">NIS-tunnus</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTUYPGTunnus" runat="server"></asp:Label></td>
      </tr>
      <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
        <tr>
          <td class="view2columnsHeader1">Verkkotietojärjestelmäid-tunniste</td>
          <td class="view2columnsContentElement1">
            <asp:Label runat="server" ID="lblTUYPGTunniste" /></td>
          <td class="view2columnsHeader2">Verkkotietojärjestelmä-koordinaatti 1</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblTUYPGKoordinaatti1" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader2">Verkkotietojärjestelmä-koordinaatti 2</td>
          <td class="view2columnsContentElement2">
            <asp:Label runat="server" ID="lblTUYPGKoordinaatti2" /></td>
        </tr>
      </asp:PlaceHolder>
      <tr>
        <td class="view2columnsHeader1">Lisätietoa</td>
        <td class="view2columnsContentElement1" colspan="3">
          <asp:Label ID="lblTUYInfo" runat="server"></asp:Label>&nbsp;</td>
      </tr>
    </table>
    <div class="view2columnsClearElement"></div>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
    <asp:Button ID="btnTakaisin" runat="server" Text="Palaa takaisin" Visible="False" />
  </div>

</asp:Content>


