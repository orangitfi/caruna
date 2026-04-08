<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Haku.ascx.vb" Inherits="appSopimusrekisteri.Hakualue" %>
<h2>Hae tietokannasta</h2>
<asp:Panel ID="Panel1" runat="server" DefaultButton="btnHae">
<table class="search">
  <tr>
    <td colspan="2">
      <asp:TextBox ID="txtHaku" runat="server" SkinID="SearchShort"></asp:TextBox>&nbsp;
        <asp:Button ID="btnHae" runat="server" Text="Hae" ValidationGroup="Haku" CausesValidation="False"></asp:Button>
        <asp:RadioButtonList ID="rblHakutyyppi" runat="server" >
            <asp:ListItem Text="Taho" Value="1"></asp:ListItem>
            <asp:ListItem Text="Kiinteistö" Value="2"></asp:ListItem>
            <asp:ListItem Text="Sopimus" Value="3" Selected="True" ></asp:ListItem>
        </asp:RadioButtonList>
    </td>
  </tr>  
  <tr>
    <td colspan="2">
      <ul>
        <asp:ListView ID="lstwHaku" runat="server">
          <ItemTemplate>
            <li>
              <asp:HyperLink runat="server" ID="hlLinkki"></asp:HyperLink>
            </li>
          </ItemTemplate>
        </asp:ListView>
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
</asp:Panel>
<h2>Laajennettu haku</h2>
<div class="toolbar">
    <ul>
        <li><asp:Button ID="btnHaeTahoja" runat="server" Text="Hae tahoja" CausesValidation="false" /></li>
        <li><asp:Button ID="btnHaeKiinteistoja" runat="server" Text="Hae kiinteistöjä" CausesValidation="false" /></li>
        <li><asp:Button ID="btnHaeSopimuksia" runat="server" Text="Hae sopimuksia" CausesValidation="false" /></li>
    </ul>
</div>
