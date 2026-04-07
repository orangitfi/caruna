<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Haku.ascx.vb" Inherits="appFortumMalli.Haku" %>
<h2>Hae kiinteistöjä tai sopimuksia</h2>

<table class="search" cellpadding="0" cellspacing="0">
  <tr>
    <td colspan="2">
      <asp:TextBox ID="txtHaku" runat="server" SkinID="SearchShort"></asp:TextBox>&nbsp;<asp:Button 
        ID="btnHae" runat="server" Text="Hae" ValidationGroup="Haku" 
        CausesValidation="False"></asp:Button>
    </td>
  </tr>
  <tr>
    <td colspan="2"><asp:RadioButton ID="rbTontti" runat="server" Text="Kiinteistö" AutoPostBack="true" /> <asp:RadioButton ID="rbSopimus" runat="server" Text="Sopimus" AutoPostBack="true" /></td>
  </tr>
  <tr>
    <td class="advancedSearch"><asp:Image ID="imgNuoli" runat="server" ImageUrl="~/App_Themes/Default/Images/Nuoli.png" /></td>
    <td class="advancedSearch"><asp:HyperLink ID="hlTarkennettuhaku" runat="server" NavigateUrl="default2.aspx">Laajennettu haku</asp:HyperLink></td>
  </tr>
  <tr>
    <td colspan="2">
      <ul>
        <%--<asp:ListView ID="lstwHaku" runat="server">
          <ItemTemplate>
            <li>
              <asp:HyperLink runat="server" ID="hlLinkki"></asp:HyperLink>
            </li>
          </ItemTemplate>
        </asp:ListView>--%>
        <li>
            <asp:HyperLink runat="server" ID="hlTontti" Text="Kiinteistö eka" NavigateUrl="~/perusnaytto_tontti.aspx"  Visible="false" ></asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink runat="server" ID="hlSopimus" Text="Sopimus 534526" NavigateUrl="~/perusnaytto_sopimus.aspx" Visible="false" ></asp:HyperLink>
        </li>
      </ul>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblLkm" runat="server"></asp:Label>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:HyperLink ID="hlLisaHakutulokset" runat="server" Visible="False">Lisää hakutuloksia...</asp:HyperLink>
    </td>
  </tr>
</table>