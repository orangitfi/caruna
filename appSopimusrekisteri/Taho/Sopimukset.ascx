<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Sopimukset.ascx.vb" Inherits="appSopimusrekisteri.Sopimukset" %>
<div class="headerBar">
  <h1>Sopimukset</h1>
</div>
<div class="list">
  <asp:GridView ID="gvSopimukset" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Id" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Sopimus/Sopimus.ashx?id={0}" />
      <asp:BoundField DataField="Sopimustyyppi" HeaderText="Sopimustyyppi" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Alkaa" HeaderText="Alkaa" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Paattyy" HeaderText="Päättyy" ItemStyle-VerticalAlign="Top" />
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server" Visible="False"></asp:LinkButton>
          <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" Visible="False" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän sopimuksen tältä organisaatiolta?');"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää sopimus" CausesValidation="False" ID="btLisaaSopimus" runat="server" Visible="False"></asp:Button>
  <asp:HiddenField ID="hdnTahoId" runat="server" />
</div>
