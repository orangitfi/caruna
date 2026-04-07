<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Korvauslaskelmat.ascx.vb" Inherits="appSopimusrekisteri.Korvauslaskelmat" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät korvauslaskelmat</h1>
</div>
<div class="list">
  <asp:GridView ID="gvKorvauslaskelma" runat="server" AutoGenerateColumns="False" ShowFooter="true" DataKeyNames="Id">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlValitse" runat="server"></asp:HyperLink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Saaja.Nimi" HeaderText="Asiakas" />
      <asp:BoundField DataField="Summa" HeaderText="Veroton summa" DataFormatString="{0:F}" />
      <asp:BoundField DataField="AlvSumma" HeaderText="Alv" DataFormatString="{0:F}" />
      <asp:TemplateField HeaderText="Verollinen summa">
        <ItemTemplate>
          <asp:Label ID="lblKorvauslaskelmanSumma" runat="server" />
        </ItemTemplate>
        <FooterTemplate>
          <b>
            <asp:Label ID="lblKorvauslaskelmienSumma" runat="server" /></b>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:HyperLink ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:HyperLink>&nbsp;<asp:LinkButton ID="lbPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän korvauslaskelman?');"></asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate>
          <asp:Label ID="lblYhteensa" runat="server" Text="Kokonaissumma"></asp:Label>
        </FooterTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää korvauslaskelma" CausesValidation="False" ID="btLisaaKorvauslaskelma" runat="server"></asp:Button>
</div>
