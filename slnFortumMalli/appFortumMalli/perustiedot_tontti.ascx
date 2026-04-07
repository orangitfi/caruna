<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="perustiedot_tontti.ascx.vb" Inherits="appFortumMalli.perustiedot_tontti" %>


<asp:PlaceHolder ID="phTontti" Visible="True" runat="server">
  <div class="headerBar">
    <h1>
      <asp:Label ID="lblPerustiedot" runat="server" Text="Kiinteistön tiedot"></asp:Label></h1>
     <div class="headerBarActionImgLink"><asp:HyperLink ID="hlPrintHenkilo" runat="server" Target="_blank">Tulosta <img src="pics/print.gif" alt="Tulosta rekisteriote" title="Tulosta rekisteriote" /></asp:HyperLink></div>
  </div>
  <div class="view2columns">
    <asp:HiddenField ID="TAHTahoId" runat="server" />
    <table cellpadding="0" cellspacing="0" border="0">
      <tr>
        <td class="view2columnsHeader1">
          Kiinteistön nimi
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblNimi" runat="server" Text="Kiinteistö eka"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          Rekisterinumero
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblNumero" runat="server" Text="12"></asp:Label>
        </td>
      </tr>
      <tr>
          <td class="view2columnsHeader1">
              Katuosoite
          </td>
          <td class="view2columnsContentElement1">
          <asp:Label ID="lblKatuosoite" runat="server" Text="Esimerkkitie 12"></asp:Label>
        </td>
          <td class="view2columnsHeader2">
              Kylä
          </td>
          <td class="view2columnsContentElement2">
          <asp:Label ID="lblKyla" runat="server" Text="Oulunkylä"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">
            Postinumero
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblpostinumero" runat="server" Text="00600"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          <asp:Label ID="lblKuntaOtsikko" runat="server" Text="Kunta"></asp:Label>
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKunta" runat="server" Text="Helsinki"></asp:Label>
        </td>
      </tr>
      <tr>
          <td class="view2columnsHeader1">
          Postitoimipaikka
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblPostitmp" runat="server" Text="Helsinki"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
            Kiinteistötunnus
        </td>
        <td class="view2columnsContentElement2">
            <asp:Label ID="lblKiinteistoTunnus" runat="server" Text="09160012"></asp:Label>
        </td>
      </tr>
    </table>
    <div class="view2columnsClearElement">
    </div>
  </div>
  <div class="footerBar">
      <asp:Button ID="btnMuokkaus" runat="server" Text="Muokkaa tietoja" CausesValidation="False" />
  </div>
</asp:PlaceHolder>
