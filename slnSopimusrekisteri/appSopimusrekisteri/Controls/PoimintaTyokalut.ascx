<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PoimintaTyokalut.ascx.vb" Inherits="appSopimusrekisteri.PoimintaTyokalut" %>
<h2>TYÖKALUT</h2>
<div class="toolbar">
  <h5>Sarakevalinta</h5>
  <ul>
    <li>
      <asp:HyperLink ID="hlSarakevalintaSopimus" runat="server" NavigateUrl="~/Poiminta/Poiminta_sarakkeet_sopimus.aspx">Valitse sopimusten sarakkeet</asp:HyperLink></li>
    <li>
      <asp:HyperLink ID="hlSarakevalintaKiinteisto" runat="server" NavigateUrl="~/Poiminta/Poiminta_sarakkeet_kiinteisto.aspx">Valitse kiinteistöjen sarakkeet</asp:HyperLink></li>
    <li>
      <asp:HyperLink ID="hlSarakevalintaTaho" runat="server" NavigateUrl="~/Poiminta/Poiminta_sarakkeet_taho.aspx">Valitse tahojen sarakkeet</asp:HyperLink></li>
    <li>
      <asp:LinkButton ID="lbNollaaSarakkeet" runat="server">Nollaa sarakevalinta</asp:LinkButton></li>
  </ul>
  <asp:PlaceHolder ID="phJoukkolisays" runat="server" Visible="false">
    <h5>Joukkolisäys</h5>
    <ul>
      <li>
        <asp:HyperLink ID="hlLisaaAktiviteetti" runat="server" NavigateUrl="~/Aktiviteetti/Muokkaa.aspx?joukko=k">Lisää aktiviteeteja poimintajoukolle</asp:HyperLink>
      </li>
    </ul>
  </asp:PlaceHolder>
  <h5>Tallennetut joukot</h5>
    <ul>
      <li>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Poiminta/Poiminta_Tallenna_Lataa.aspx">Tallennetut poimintajoukot</asp:HyperLink>
      </li>
      <li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Poiminta/Poimintaehdot_Tallenna_Lataa.aspx">Tallennetut poimintaehdot</asp:HyperLink>
      </li>
    </ul>
</div>
