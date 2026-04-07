<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="maksu.ascx.vb" Inherits="appFortumMalli.maksu" %>

<div class="headerBar">
  <h1>
    Maksut</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Vuosi
          </th>
          <th>
            Ajopvm
          </th>
          <th>
            Tila/Status
          </th>
          <th>
            Summa €
          </th>
          <th>
            Index
          </th>
          <th>
            Indeksikuukausi
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            2009
          </td>
          <td>
            9.7.2009
          </td>
          <td>
            Maksatus
          </td>
          <td>
            215,53
          </td>
          <td>
            0,45
          </td>
          <td>
            Tammikuu
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää maksu" CausesValidation="False" ID="btnLisaa" runat="server">
  </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>