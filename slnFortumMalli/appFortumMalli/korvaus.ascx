<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="korvaus.ascx.vb" Inherits="appFortumMalli.korvaus" %>

<div class="headerBar">
  <h1>
    Korvaus</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Korvauksen tyyppi
          </th>
          <th>
            Summa
          </th>
          <th>
            Alv-velvollinen
          </th>
          <th>
            Viimeisin indeksi
          </th>
          <th>
            Viimeisin maksupäivä
          </th>
          <th>
              Status
          </th>
          <th>
              Lisätietoja
          </th>
          <th>

          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            Vuosimaksu
          </td>
          <td>
            900
          </td>
          <td>
            Kyllä
          </td>
          <td>
            0,3
          </td>
          <td>
              12.12.2012
          </td>
          <td>
              Hyväksytty
          </td>
          <td>
              Tässä täsmentäviä tietoja muutoksesta
          </td>
          <td>
              <asp:HyperLink ID="hlMuokkaa" runat="server" NavigateUrl="~/perusnaytto_sopimus.aspx" Text="Muokkaa"></asp:HyperLink>
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
    <asp:Button Text="Lisää korvaus" CausesValidation="False" ID="btnLisaa" runat="server" />
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>