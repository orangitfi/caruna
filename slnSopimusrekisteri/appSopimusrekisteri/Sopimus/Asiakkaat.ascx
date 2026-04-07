<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Asiakkaat.ascx.vb" Inherits="appSopimusrekisteri.Asiakkaat" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät asiakkaat</h1>
</div>
<div class="list">
  <asp:GridView ID="gvAsiakkaat" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlValitse" runat="server"></asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Taho.Nimi" HeaderText="Nimi" />
      <asp:BoundField DataField="Asiakastyyppi.Nimi" HeaderText="Rooli" />
      <asp:BoundField DataField="Taho.Postituspostinro" HeaderText="Postinumero" />
      <asp:BoundField DataField="Taho.Postituspostitmp" HeaderText="Postitoimipaikka" />
      <asp:TemplateField HeaderText="" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:HyperLink>&nbsp;<asp:LinkButton ID="lbPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän asiakkaan?');"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää uusi henkilöasiakas" CausesValidation="False" ID="btLisaaHenkiloasiakas" runat="server"></asp:Button>
  <asp:Button Text="Lisää uusi yritysasiakas" CausesValidation="False" ID="btLisaaYritysasiakas" runat="server"></asp:Button>
  <asp:Button Text="Lisää olemassaoleva asiakas" CausesValidation="False" ID="btLisaaOlemassaolevaAsiakas" runat="server"></asp:Button>
</div>
