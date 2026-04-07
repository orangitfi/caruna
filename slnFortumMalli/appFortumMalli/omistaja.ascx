<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="omistaja.ascx.vb" Inherits="appFortumMalli.omistaja" %>

<div class="headerBar">
  <h1>
    Omistaja</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Nimi
          </th>
          <th>
            Osoite
          </th>
          <th>
            Puh
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            Esa Esimerkki
          </td>
          <td>
            Esimerkkitie 12
          </td>
          <td>
            0400-123456
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
    <asp:Button Text="Muokkaa omistajaa" CausesValidation="False" ID="btnMuokkaa" runat="server">
    </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>