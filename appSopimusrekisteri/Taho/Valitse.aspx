<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Valitse.aspx.vb" Inherits="appSopimusrekisteri.Valitse" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <h1>VALITSE ASIAKAS</h1>
  <div class="list">
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20">
      <Columns>

        <asp:BoundField DataField="Etunimi" HeaderText="Etunimi" />
        <asp:BoundField DataField="Sukunimi" HeaderText="Sukunimi/Yritys" />
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataTextField="Id" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Taho/TYYPPI/Tiedot.aspx?id={0}" />
        <asp:BoundField DataField="Tyyppi" SortExpression="Tyyppi" HeaderText="Tyyppi" Visible="false" />
        <asp:BoundField DataField="Osoite" HeaderText="Osoite" />
        <asp:BoundField DataField="Postinumero" HeaderText="Postinumero" />
        <asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" />
        <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:HyperLink ID="hlValitseKorvauslaskelmalle" Text="Valitse korvauslaskelmalle" runat="server" Visible="false"></asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnPeruuta" runat="server" Text="Palaa edelliselle sivulle" />
    <div class="footerBarInfo">
      <asp:Label ID="lblLukumaara" runat="server"></asp:Label>
    </div>
  </div>

</asp:Content>

