<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.KiinteistonTiedot" Theme="Default" StylesheetTheme="Default" %>

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
  <!-- Yläosan tiedot -->
  <h3>
    <asp:Label ID="lblNimi" runat="server" Font-Bold="true"></asp:Label></h3>
  <div class="viewInfo">
    <table>
      <tr>
        <td class="viewInfoContentElement">
          <asp:Label ID="lblPostiosoite" runat="server"></asp:Label><br />
          <br />
          <asp:Button ID="btLisaaOmistaja" runat="server" Visible="false" Text="Lisää kiinteiston omistaja"></asp:Button>
          <asp:Button ID="btPoistaOmistaja" runat="server" Visible="false" Text="Poista kiinteiston omistaja" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa kiinteistön omistajan?');"></asp:Button>
        </td>
        <td class="viewInfoContentElement">
          <asp:PlaceHolder ID="phOmistaja" runat="server" Visible="false">
            <b>Kiinteistön omistaja</b><br />
            <br />
            <asp:Label ID="lblOmistajanPostiosoite" runat="server"></asp:Label><br />
            <br />
            <asp:Label ID="lblOmistajanEmail" runat="server"></asp:Label><br />
            <asp:Label ID="lblOmistajanPuhelin" runat="server"></asp:Label>
          </asp:PlaceHolder>
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
      <asp:Label ID="lblKIIKiinteisto" runat="server"></asp:Label></h1>
    <div class="headerBarActionImgLink">
      <asp:HyperLink ID="hlPrintHenkilo" Target="_blank" runat="server">
        <asp:Image ID="Image1" SkinID="PrintImage" AlternateText="Avaa tulostusnäkymä" runat="server" />
      </asp:HyperLink>
    </div>
  </div>
  <div class="view2columns">
    <table>
      <tr>
        <td class="view2columnsHeader1">Postiosoite</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIPostitusosoite" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kylän numero</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIKylanumero" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Kylä</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIKyla" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kuntanumero</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIKuntanumero" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Kunta</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIKuntaId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kortteli</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIKortteli" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Maa</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIMaaId" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Tontti</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIITontti" runat="server"></asp:Label></td>
      </tr>

      <tr>
        <td class="view2columnsHeader1">Määräala</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIMaaraAla" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Rekisterinumero</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIRekisterinumero" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">Aluetarkenne</td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblKIIAlueTarkenne" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kiinteistötunnus</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIKiinteistotunnus" runat="server"></asp:Label></td>
      </tr>
      <tr>
          <td class="view2columnsHeader1">Maapinta-ala (m2)</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIIMaapintaAla" runat="server"></asp:Label></td>
        <td class="view2columnsHeader2">Kiinteistötunnus lyhyt</td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKIIKiinteistotunnusLyhyt" runat="server"></asp:Label></td>
      </tr>
        <tr>
          <td class="view2columnsHeader1">Kokonaispinta-ala (m2)</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIIPintaAla" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Vesipinta-ala (m2)</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblKIIVesipintaAla" runat="server"></asp:Label></td>
        </tr>
      <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
        <tr>
          <td class="view2columnsHeader1">Kiinnitykset</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIIKiinnitykset" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Rasitteet</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblKIIRasitteet" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Kiinteistöverotettu</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIIKiinteistoverotettuVuosi" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Asset id in Fixed Asset Register</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblKIIAssetTunniste" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Omistusosuus</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIIOmistusosuus" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Omistusosuus total</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblKIIOmistusosuusTotal" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Tarpeellisuus liiketoiminnalle</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="lblKIILiiketoiminnanTarveId" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Sääntö</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="lblKIISaantoId" runat="server"></asp:Label></td>
        </tr>
      </asp:PlaceHolder>
      <tr>
        <td class="view2columnsHeader1">Lisätietoja</td>
        <td class="view2columnsContentElement1" colspan="3">
          <asp:Label ID="lblKIIInfo" runat="server"></asp:Label></td>
      </tr>
    </table>
    <div class="view2columnsClearElement"></div>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
    <asp:Button ID="btnTakaisin" runat="server" Text="Palaa takaisin" Visible="False" />
  </div>

  <div class="headerBar">
    <h1>Kiinteistöön liittyvät sopimukset</h1>
  </div>
  <div class="list">
    <asp:PlaceHolder ID="phSopimukset" runat="server" Visible="false">
      <asp:GridView ID="gwSopimukset" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
            <ItemTemplate>
              <asp:LinkButton ID="hlValitse" Text="Valitse" runat="server"></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Sopimustyyppi" HeaderText="Sopimustyyppi" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Alkaa" HeaderText="Alkaa" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Paattyy" HeaderText="Päättyy" ItemStyle-VerticalAlign="Top" />
          <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
            <ItemTemplate>
              <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän sopimuksen tältä kiinteistöltä?');"></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </asp:PlaceHolder>
  </div>
  <div class="footerBar">
    <asp:Button Text="Lisää sopimus kiinteistölle" CausesValidation="False" ID="btLisaaSopimusKiinteistölle" runat="server"></asp:Button>
  </div>


</asp:Content>
