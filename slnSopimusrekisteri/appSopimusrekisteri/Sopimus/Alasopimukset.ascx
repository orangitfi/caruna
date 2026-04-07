<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Alasopimukset.ascx.vb" Inherits="appSopimusrekisteri.Alasopimukset" %>
<div class="headerBar">
  <h1>Sopimukseen liittyvät alasopimukset</h1>
</div>
<div class="list">
    <asp:GridView ID="gvAlasopimukset" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="gvAlasopimukset_RowDataBound" OnRowCommand="gvAlasopimukset_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Sopimusnumero" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <asp:HyperLink ID="hlSopimusnumero" runat="server"><%#: Eval("Id") %></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="MuuTunniste" HeaderText="Muu tunniste" ItemStyle-VerticalAlign="Top" />
            <asp:BoundField DataField="Sopimustyyppi.SopimustyyppiNimi" HeaderText="Sopimustyyppi" ItemStyle-VerticalAlign="Top" />
            <asp:BoundField DataField="Alkaa" HeaderText="Alkaa" ItemStyle-VerticalAlign="Top" DataFormatString="{0:d.M.yyyy}" />
            <asp:BoundField DataField="Paattyy" HeaderText="Päättyy" ItemStyle-VerticalAlign="Top" DataFormatString="{0:d.M.yyyy}" />
            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                    <asp:LinkButton ID="hlPoista" CommandName="Poista" runat="server" OnClientClick="javascript:return confirm('Haluatko varmasti poistaa sopimuksen linkityksen tähän sopimukseen? Itse sopimusta ei poisteta.');">Poista</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="footerBar">
  <asp:Button Text="Lisää alasopimus" CausesValidation="False" ID="btnLisaaAlasopimus" OnClick="btnLisaaAlasopimus_Click" runat="server"></asp:Button>
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
</div>
