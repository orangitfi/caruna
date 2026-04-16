<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.Taho.Organisaatio.Tiedot" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Taho/Kiinteistot.ascx" TagName="Kiinteistot" TagPrefix="uc" %>
<%@ Register Src="~/Taho/Sopimukset.ascx" TagName="Sopimukset" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
  <div id="headerData" runat="server">
    <h3>
      <asp:Label ID="hNimi" runat="server" Font-Bold="true"></asp:Label>
    </h3>
    <div class="viewInfo">
      <table>
        <tr>
          <td class="viewInfoContentElement" rowspan="2">
            <asp:Label ID="lblPostiosoite" runat="server"></asp:Label></td>
          <td class="viewInfoContentElement">
            <asp:Label ID="hPuhelin" runat="server"></asp:Label><br />
            <asp:Label ID="hEmail" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td class="viewInfoContentElement"></td>
        </tr>
      </table>
      <div class="viewInfoClearElement"></div>
    </div>
  </div>
  <div id="formData" runat="server">
    <div class="headerBar">
      <h1>
        <asp:Label ID="lblNimi" runat="server"></asp:Label></h1>
      <div class="headerBarActionImgLink">
      </div>
    </div>
    <div class="view2columns">
      <table>
        <tr>
          <td class="view2columnsHeader1">Organisaation tyyppi</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="OrganisaationTyyppi_Tyyppi" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Postiosoite</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblPostitusosoite" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Maa</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Maa_NimiSuomi" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Kunta</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="Kunta_KuntaNimi" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Sähköposti</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Email" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Matkapuhelin</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Puhelin" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Tilinumero</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Tilinumero" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">BIC</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Bic" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Nimen jatke</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Nimitarkenne" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">ALV-velvollinen</td>
          <td class="view2columnsContentElement2">
            <asp:Label runat="server" ID="AlvVelvollinen" /></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Kirjanpidon yritystunniste</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="KirjanpidonYritystunniste" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Kirjanpidon projektitunniste</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="KirjanpidonProjektitunniste" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">PCS-Concession</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Concession" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2"></td>
          <td class="view2columnsContentElement2"></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Lisätietoa</td>
          <td class="view2columnsContentElement1" colspan="3">
            <asp:Label ID="Info" runat="server"></asp:Label></td>
        </tr>
      </table>
      <div class="view2columnsClearElement"></div>
    </div>
    <div class="footerBar">
      <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
    </div>
  </div>

  <uc:Kiinteistot ID="Kiinteistot1" runat="server" />
  <uc:Sopimukset ID="Sopimukset1" runat="server" />

</asp:Content>


