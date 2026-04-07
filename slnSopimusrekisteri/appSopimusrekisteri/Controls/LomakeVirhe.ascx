<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LomakeVirhe.ascx.vb" Inherits="appSopimusrekisteri.LomakeVirhe" %>
<asp:Panel ID="pnlVirhe" runat="server" Visible="false">
  <asp:ListView ID="lvVirheet" runat="server">
    <LayoutTemplate>
      <ul>
        <li runat="server" id="itemPlaceHolder" />
      </ul>
    </LayoutTemplate>
    <ItemTemplate>
      <li><%# Container.DataItem%></li>
    </ItemTemplate>
  </asp:ListView>
</asp:Panel>
