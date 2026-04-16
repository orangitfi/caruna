<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Tehtavalista.ascx.vb" Inherits="appSopimusrekisteri.Tehtavalista" %>
<div class="headerBar">
  <h1>Tehtävälista</h1>
  <asp:HyperLink ID="hlKaikki" runat="server" align="right">Kaikki tehtävät</asp:HyperLink>
</div>
<div class="list">
  <asp:GridView ID="gvTehtavalista" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitse" Text='<%# Bind("ID") %>' runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Päivämäärä" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Label ID="lblPaivamaara" runat="server"></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlSopimus" runat="server"></asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Keneen otetaan yhteyttä" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlTaho" runat="server"></asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Yhteydenottotapa" HeaderText="Toimenpide" ItemStyle-VerticalAlign="Top" />
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>