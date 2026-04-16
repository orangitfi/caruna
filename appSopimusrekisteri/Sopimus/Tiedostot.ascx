<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Tiedostot.ascx.vb" Inherits="appSopimusrekisteri.Tiedostot1" %>
<div class="headerBar">
    <h1>Sopimukseen liittyvät tiedostot</h1>
</div>
<div class="list">
    <asp:GridView ID="gvTiedostot" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="DocumentId" HeaderText="Dokumentti ID" />
            <asp:BoundField DataField="Asiakirjatarkenne" HeaderText="Asiakirjatarkenne" />
            <asp:BoundField DataField="ArkistointiTunniste" HeaderText="Arkistoviite" />
            <asp:TemplateField HeaderText="Tiedosto">
                <ItemTemplate>
                    <asp:HyperLink ID="hlTiedosto" runat="server" Text='<%# Bind("Nimi") %>' Target="_blank"></asp:HyperLink>&nbsp;
                    <asp:HyperLink ID="hlVanha" runat="server" Target="_blank" Visible="false" Font-Size="XX-Small">(sharepoint)</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                    <asp:LinkButton ID="lbMuokkaa" Text="Muokkaa" CommandName="Edit" runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lbPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän tiedoston?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<div class="footerBar">
    <asp:HiddenField ID="hdnSopimusId" runat="server" />
    <asp:Button Text="Lisää tiedosto" CausesValidation="False" ID="btnLisaaTiedosto" runat="server" OnClick="btnLisaaTiedosto_Click"></asp:Button>
</div>
