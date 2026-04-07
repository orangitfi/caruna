<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="perustiedot_sopimus.ascx.vb" Inherits="appFortumMalli.perustiedot_sopimus" %>

<asp:PlaceHolder ID="phSopimus" Visible="True" runat="server">
  <div class="headerBar">
    <h1>
      <asp:Label ID="lblPerustiedot" runat="server" Text="Muuntamosopimus"></asp:Label></h1>
     <div class="headerBarActionImgLink"><asp:HyperLink ID="hlPrintHenkilo" runat="server" Target="_blank">Tulosta <img src="pics/print.gif" alt="Tulosta rekisteriote" title="Tulosta rekisteriote" /></asp:HyperLink></div>
  </div>
  <div class="view2columns">
    <asp:HiddenField ID="TAHTahoId" runat="server" />
    <table cellpadding="0" cellspacing="0" border="0">
      <tr>
        <td class="view2columnsHeader1">
          Sopimusnro
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblSopimusnro" runat="server" Text="534526"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          Kesto
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblKesto" runat="server" Text="30v"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">
          Alkupvm
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblAlkupvm" runat="server" Text="04.03.1999"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          Yhtiö
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblYhtio" runat="server" Text="Fortum sähkönsiirto"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">
          Loppupvm
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblLoppupvm" runat="server" Text="04.03.2029"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          Sopimuksen solmija
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblSopimuksenSolmija" runat="server" Text="Teppo Testaaja"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">
          Muu tunniste
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblMuuTunniste" runat="server" Text="QWERTYASD"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
          PCS-numero
        </td>
        <td class="view2columnsContentElement2">
          <asp:Label ID="lblPCS" runat="server" Text="123123"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="view2columnsHeader1">
          Tilinumero
        </td>
        <td class="view2columnsContentElement1">
          <asp:Label ID="lblTilinro" runat="server" Text="123456-7890"></asp:Label>
        </td>
        <td class="view2columnsHeader2">
            Sopimushetken indeksi
        </td>
        <td class="view2columnsContentElement2">
            <asp:Label ID="lblSophetkenIndeksi" runat="server" Text="0,17"></asp:Label>
        </td>
      </tr>
    </table>
    <div class="view2columnsClearElement">
    </div>
  </div>
  <div class="footerBar">
      <asp:Button ID="btnMuokkaus" runat="server" Text="Muokkaa tietoja" CausesValidation="False" />
  </div>
</asp:PlaceHolder>
