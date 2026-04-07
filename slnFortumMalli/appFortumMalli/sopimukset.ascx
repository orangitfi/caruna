<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="sopimukset.ascx.vb" Inherits="appFortumMalli.sopimukset" %>

<div class="headerBar">
  <h1>
    Sopimukset</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Sopimusnro
          </th>
          <th>
            Alkupvm
          </th>
          <th>
            Loppupvm
          </th>
          <th>
              Kesto
          </th>
          <th>
              Sopimustyyppi
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            <asp:HyperLink ID="hlSopimusnro" runat="server" Text="534526" NavigateUrl="~/perusnaytto_sopimus.aspx"></asp:HyperLink>
          </td>
          <td>
            04.03.1999
          </td>
          <td>
            04.03.2029
          </td>
          <td>
            30v
          </td>
          <td>
              Muuntamosopimus
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää sopimus" CausesValidation="False" ID="btnLisaa" runat="server">
  </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>
