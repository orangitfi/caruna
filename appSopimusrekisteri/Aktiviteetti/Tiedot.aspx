<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.AktiviteetinTiedot" Theme="Default" StylesheetTheme="Default" %>

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
    <h1>
      Aktiviteetin tiedot</h1>
  </div>
  <div class="view2columns">
    <table>
      <tr>
        <td class="view2columnsHeader1">Keneen aktiviteetti kohdistuu</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAKTahoId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kontaktoija</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblAKKontaktoijaId" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Sopimus</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAKSopimusId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Status</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblAKStatusId" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Toimenpide</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAKYhteystapaId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Aktiviteetin laji</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblAKAktiviteetinLajiId" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Päivämäärä</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAKPaivamaara" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Jatkopäivämäärä</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblAKSeuraavaYhteyspaiva" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Kuvaus</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAKKuvaus" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2"></td>
        <td class="view2columnsContentElement2"></td>
      </tr>
    </table>
    <div class="view2columnsClearElement"></div>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" /> 
    <asp:Button ID="btnTakaisin" runat="server" Text="Takaisin sopimukseen" visible="false" />
  </div>

</asp:Content>
