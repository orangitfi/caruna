<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Aktiviteetit.ascx.vb" Inherits="appSopimusrekisteri.Aktiviteetit" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät aktiviteetit</h1>
</div>
<div class="list">
  <asp:GridView ID="gvAktiviteetit" runat="server" AutoGenerateColumns="False">
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
      <asp:TemplateField HeaderText="Kontaktoija" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Label ID="lblKontaktoija" runat="server"></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Yhteydenottotapa" HeaderText="Toimenpide" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-VerticalAlign="Top" />
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää uusi aktiviteetti" CausesValidation="False" ID="btnLisaaAktiviteetti" runat="server"></asp:Button>
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
</div>
