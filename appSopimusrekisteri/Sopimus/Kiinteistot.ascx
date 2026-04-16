<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Kiinteistot.ascx.vb" Inherits="appSopimusrekisteri.Kiinteistot" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät kiinteistöt</h1>
</div>
<div class="list">

  <asp:GridView ID="gvKiinteistot" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitse" Text='<%# Bind("ID") %>' runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Nimi" HeaderText="Nimi" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Kunta" HeaderText="Kunta" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Kyla" HeaderText="Kylä" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="LyhytKiinteistotunnus" HeaderText="Kiinteistötunnus, lyhyt" ItemStyle-VerticalAlign="Top" />
      <%--<asp:BoundField DataField="Osoite" HeaderText="Osoite" ItemStyle-VerticalAlign="Top" />--%>
      <%--<asp:BoundField DataField="Postinumero" HeaderText="Postinumero" ItemStyle-VerticalAlign="Top" />--%>
      <%--<asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" ItemStyle-VerticalAlign="Top" />--%>
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>&nbsp;<asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän kiinteistön?');"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää kiinteistö" CausesValidation="False" ID="btLisaaKiinteisto" runat="server"></asp:Button>
  <asp:Button Text="Lisää olemassaoleva kiinteistö" CausesValidation="False" ID="btLisaaOlemassaolevaKiinteisto" runat="server"></asp:Button>
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
</div>
