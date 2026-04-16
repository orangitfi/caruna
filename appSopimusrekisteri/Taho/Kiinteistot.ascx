<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Kiinteistot.ascx.vb" Inherits="appSopimusrekisteri.Taho.Kiinteistot" %>
<div class="headerBar">
  <h1>Organisaatioon liittyvät kiinteistöt</h1>
</div>
<div class="list">
  <asp:GridView ID="gvKiinteistot" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
    <Columns>
      <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Id" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Kiinteisto/Tiedot.aspx?id={0}" />
      <asp:BoundField DataField="KiinteistoNimi" HeaderText="Nimi" />
      <asp:BoundField DataField="Katuosoite" HeaderText="Osoite" />
      <asp:BoundField DataField="Postinumero" HeaderText="Postinumero" />
      <asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" />
      <asp:TemplateField HeaderText="" ControlStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server" Visible="False"></asp:LinkButton>
          <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" Visible="False" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän kiinteistön organisaatiolta?');"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää kiinteistö" CausesValidation="False" ID="btLisaaKiinteisto" runat="server" Visible="False"></asp:Button>
</div>
