<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Tunnisteyksikot.ascx.vb" Inherits="appSopimusrekisteri.Tunnisteyksikot" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät tunnisteyksiköt</h1>
</div>
<div class="list">
  <asp:GridView ID="gvTunnisteyksikot" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitse" Text='<%# Bind("ID") %>' runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Tyyppi" HeaderText="Tyyppi" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="PGTunnus" HeaderText="NIS-tunnus" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Nimi" HeaderText="Nimi/Linja osa" ItemStyle-VerticalAlign="Top" />
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>&nbsp;<asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän tunnisteyksikön?');"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää tunnisteyksikkö" CausesValidation="False" ID="btnLisaaTunnisteyksikko" runat="server"></asp:Button>
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
</div>
