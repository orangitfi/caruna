<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Maksut.ascx.vb" Inherits="appSopimusrekisteri.Maksut" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät maksut</h1>
</div>
<div class="list">
  <asp:GridView ID="gvMaksut" runat="server" AutoGenerateColumns="False" ShowFooter="true">
    <Columns>
      <asp:TemplateField HeaderText="Korvauslaskelma" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitseKorvauslaskelma" Text='<%# Bind("MAKKorvauslaskelmaId") %>' runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Maksuaineisto" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitseMaksuaineisto" Text="Valitse" runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="MAKMaksupaiva" HeaderText="Maksupäivä" DataFormatString="{0:dd.MM.yyyy}"/>
      <asp:BoundField DataField="MAKBic" HeaderText="BIC" />
      <asp:BoundField DataField="MAKTilinumero" HeaderText="Tilinumero" />
      <asp:TemplateField HeaderText="Summa">
        <ItemTemplate>
          <asp:Label ID="lblMaksuaineistonSumma" runat="server" />
        </ItemTemplate>
        <FooterTemplate>
          <b>
            <asp:Label ID="lblMaksuaineistojenSumma" runat="server" /></b>
        </FooterTemplate>
      </asp:TemplateField>
      <asp:TemplateField ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="lbPassivoi" runat="server" CommandName="passivoi" CommandArgument='<%# Bind("MAKId")%>'>Poista</asp:LinkButton>
        </ItemTemplate>
        <FooterTemplate>
          <asp:Label ID="lblYhteensa" runat="server" Text="Kokonaissumma"></asp:Label>
        </FooterTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
</div>
<div class="footerBar">
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
</div>
