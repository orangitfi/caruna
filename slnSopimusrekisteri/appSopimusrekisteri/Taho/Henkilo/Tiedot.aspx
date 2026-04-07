<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.HenkilonTiedot" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Taho/Sopimukset.ascx" TagName="Sopimukset" TagPrefix="uc" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <!-- Yläosan tiedot -->
  <h3>
    <asp:Label ID="lblNimi" runat="server" Font-Bold="true"></asp:Label></h3>
  <div class="viewInfo">
    <table>
      <tr>
        <td class="viewInfoContentElement" rowspan="2">
          <asp:Label ID="lblPostiosoite" runat="server"></asp:Label></td>
        <td class="viewInfoContentElement">
          <asp:Label ID="lblPuhelin" runat="server"></asp:Label><br />
          <asp:Label ID="lblEmail" runat="server"></asp:Label>
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
      <asp:HyperLink ID="hlPrintHenkilo" Target="_blank" runat="server"><asp:Image SkinID="PrintImage" AlternateText="Avaa tulostusnäkymä" runat="server"/></asp:HyperLink>
    </div>
  </div>
  <div class="view2columns">
    <table>
      <tr>
        <td class="view2columnsHeader1">Postiosoite</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHPostitusosoite" runat="server"></asp:Label></td>
        <td class="view2columnsHeader1">Nimen jatke</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHNimitarkenne" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Maa</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHMaaId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kunta</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblTAHKuntaId" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Sähköposti</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHEmail" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Matkapuhelin</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHPuhelin" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Tilinumero</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHTilinumero" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">BIC</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTAHBic" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Lisätietoa</td>
        <td class="view2columnsContentElement1" colspan="3">
          <asp:Label ID="lblTAHinfo" runat="server"></asp:Label></td>
      </tr>
    </table>
    <div class="view2columnsClearElement"></div>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
  </div>

  <div class="headerBar">
    <h1>Henkilöön liittyvät kiinteistöt</h1>
  </div>
  <div class="list">
    <asp:PlaceHolder ID="phKiinteistot" runat="server" Visible="false">

      <asp:GridView ID="gwKiinteistot" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Id" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Kiinteisto/Tiedot.aspx?id={0}" />
          <asp:BoundField DataField="Nimi" HeaderText="Nimi" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Osoite" HeaderText="Osoite" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Postinumero" HeaderText="Postinumero" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" ItemStyle-VerticalAlign="Top" />
          <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
            <ItemTemplate>
              <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server" Visible="False"></asp:LinkButton>
              <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" Visible="False" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän kiinteistön henkilöltä?');"></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </asp:PlaceHolder>
  </div>
  <div class="footerBar">
    <asp:Button Text="Lisää kiinteistö" CausesValidation="False" ID="btLisaaKiinteisto" runat="server" Visible="False"></asp:Button>
  </div>

  <uc:Sopimukset ID="Sopimukset1" runat="server" />

</asp:Content>
