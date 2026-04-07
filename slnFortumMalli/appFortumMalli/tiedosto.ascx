<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="tiedosto.ascx.vb" Inherits="appFortumMalli.tiedosto" %>

<div class="headerBar">
  <h1>
    Tiedostot</h1>
</div>
<div class="list">
  <table class="listGridview" cellpadding="0" cellspacing="0">
        <tr class="listGridviewHeader">
          <th>
            Tiedoston nimi
          </th>
          <th>
            Selite/Tarkenne
          </th>
          <th>
            Sopimuksen tuoja
          </th>
          <th>
            Luotu
          </th>
          <th>
            Päivitetty
          </th>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            <asp:HyperLink runat="server" Text="24082009-0377511.pdf" ></asp:HyperLink>
          </td>
          <td>
            Karttaliite
          </td>
          <td>
            SharePoint/Sopimusarkisto
          </td>
          <td>
            24.8.2009
          </td>
          <td>
              25.8.2009
          </td>
        </tr>
        <tr class="listGridviewItem">
          <td class="listGridviewAction">
            <asp:HyperLink ID="HyperLink1" runat="server" Text="13042011-0312438.pdf" ></asp:HyperLink>
          </td>
          <td>
            Muuntamosopimus
          </td>
          <td>
            SharePoint/Sopimusarkisto
          </td>
          <td>
            13.4.2011
          </td>
          <td>
              14.4.2011
          </td>
        </tr>
  </table>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää tiedosto" CausesValidation="False" ID="btnLisaa" runat="server">
  </asp:Button>
  <div class="footerBarInfo">
    <asp:Label ID="lblInfo" runat="server"></asp:Label></div>
</div>