<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="kiinteistot.ascx.vb" Inherits="appFortumMalli.kiinteistot" %>

<div class="headerBar">
  <h1>
    Kiinteistöt</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Kiinteistön nimi
          </th>
          <th>
            Rekisterinumero
          </th>
          <th>
              Kiinteistön osoite
          </th>
          <th>
            Kiinteistötunnus
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            <asp:HyperLink ID="hlKiinteisto" runat="server" NavigateUrl="~/perusnaytto_tontti.aspx" Text="Kiinteistö eka"></asp:HyperLink>
          </td>
          <td>
            12
          </td>
          <td>
              Esimerkkitie 12
          </td>
          <td>
            09160012
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
    <asp:Button ID="btnLisaa" runat="server" Text="Lisää kiinteistö" CausesValidation="False" />
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>