<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="aktiviteetti.ascx.vb" Inherits="appFortumMalli.aktiviteetti" %>

<div class="headerBar">
  <h1>
    Aktiviteetit</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Pvm
          </th>
          <th>
            Tekijä
          </th>
          <th>
            Tyyppi
          </th>
          <th>
            Sop.nro
          </th>
          <th>
            Asia
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            20.7.2011
          </td>
          <td>
              Timo Testi
          </td>
          <td>
            Soitto
          </td>
          <td>
            037751
          </td>
          <td>
            Asiakkaalla vaihtunut tilinumero ja siksi maksatus epäonnistui. Tilinumero päivitetty ja maksatus laitettu manuaalisesti.
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää aktiviteetti" CausesValidation="False" ID="btnLisaa" runat="server">
  </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>