<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Tyokalut.ascx.vb" Inherits="appSopimusrekisteri.Tyokalut" %>

<h2>Työkalut</h2>
<div class="toolbar">
  <ul>
      <li><asp:Button ID="btnHenkilo" runat="server" Text="Lisää henkilö" CausesValidation="false"/></li>
      <li><asp:Button ID="btnOrganisaatio" runat="server" Text="Lisää organisaatio" CausesValidation="false"/></li>
      <li><asp:Button ID="btnKiinteisto" runat="server" Text="Lisää kiinteistö" CausesValidation="false"/></li>
      <li><asp:Button ID="btnSopimus" runat="server" Text="Lisää sopimus" CausesValidation="false"/></li>
  </ul>
</div>