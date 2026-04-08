<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HenkiloTyokalut.ascx.vb" Inherits="appFortumMalli.HenkiloTyokalut" %>
<%@ register Assembly="appFortumMalli" Namespace="appFortumMalli" TagPrefix="cc1" %>
<asp:PlaceHolder runat="server" Visible="true" ID="phLisays">
<h2>Työkalut</h2>
<div class="toolbar">
  <ul>
      <li><asp:Button ID="btnHenkilo" runat="server" Text="Lisää kiinteistö" CausesValidation="false"/></li>
      <li><asp:Button ID="btnOrganisaatio" runat="server" Text="Lisää sopimus" CausesValidation="false"/></li>
  </ul>
</div>
</asp:PlaceHolder>