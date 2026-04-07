<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="yhteystiedot.ascx.vb" Inherits="appFortumMalli.yhteystiedot" %>

<div class="headerBar">
  <h1>
    Sopimusosapuolet</h1>
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
          <th>
            Email
          </th>
          <th>
            Tilinro
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
          <td>
            esa@esimerkki.com
          </td>
          <td>
              123456-7890
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää sopimusosapuoli" CausesValidation="False" ID="btnLisaa" runat="server">
  </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>