<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="muuntamon_tiedot.ascx.vb" Inherits="appFortumMalli.muuntajatiedot" %>

<div class="headerBar">
  <h1>
    Muuntamon tiedot</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Muuntamotunnus
          </th>
          <th>
            Muuntamon nimi
          </th>
          <th>
            Muuntamon osoite
          </th>
          <th>
            Muuntamon pinta-ala
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            AS765V
          </td>
          <td>
            MNTJA345
          </td>
          <td>
            Esimerkkitie 12
          </td>
          <td>
            3
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
    <asp:Button ID="btnLisaa" runat="server" Text="Lisää muuntamo" CausesValidation="False" />
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>