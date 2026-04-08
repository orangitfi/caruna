<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.MaksunTiedot" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <asp:HiddenField ID="hdnId" runat="server" />

  <div class="headerBar">
    <h1>MAKSU</h1>
    <div class="headerBarActionImgLink">
    </div>
  </div>
  <asp:Panel ID="pnlLomake" runat="server">
    <div class="view2columns">
      <div class="viewInfo">
      </div>
      <div class="viewDateInfo">
        <b>Luotu:</b>&nbsp;
      <asp:Label ID="Luotu" runat="server"></asp:Label>&nbsp;
      (<asp:Label ID="Luoja" runat="server"></asp:Label>)
      </div>
      <table>
        <tr>
          <td class="view2columnsHeader1">Maksun tunniste</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Id" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Maksupäivä</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="Maksupaiva" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Tilinumero</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Tilinumero" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Oikea maksupäivä</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="IfsMaksupvm" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">BIC</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Bic" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Alv:n osuus</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="AlvOsuus" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Summa</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Summa" runat="server"></asp:Label></td>
          <td class="view2columnsHeader1">Indeksi</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Indeksi" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Viite</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Viite" runat="server"></asp:Label></td>
          <td class="view2columnsHeader1">IFS-Laskunro</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="IfsLaskunro" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Viesti</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Viesti" runat="server"></asp:Label></td>
          <td class="view2columnsHeader1">Lisätietoja</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Info" runat="server"></asp:Label></td>

        </tr>
      </table>
      <div class="view2columnsClearElement"></div>
    </div>
  </asp:Panel>
  <div class="footerBar">
    <asp:Button ID="btnTakaisin" runat="server" Text="Palaa takaisin" Visible="False" />
  </div>

</asp:Content>
