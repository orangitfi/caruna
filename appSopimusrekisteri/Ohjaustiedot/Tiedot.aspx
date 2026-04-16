<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.Ohjaustiedot.Tiedot" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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
  <div class="bar barExtensionGray">
    <h1>
      <asp:Label ID="lblOtsikko" runat="server"></asp:Label></h1>
    <asp:HiddenField ID="hdnTyyppi" runat="server" />
    <div class="barAction">
      <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
    </div>
  </div>
  <div class="bar">
    <asp:Button Text="Lisää" CausesValidation="False" ID="btnLisaa" runat="server"></asp:Button>
    <div class="barInfo">
      <asp:Label ID="lblTiedot" runat="server"></asp:Label>
    </div>
  </div>
  <div class="list">
    <asp:GridView ID="gvData" DataKeyNames="Id" runat="server" AutoGenerateColumns="False">
      <Columns>
        <asp:BoundField DataField="Nimi" HeaderText="Nimi" />
        <asp:TemplateField ItemStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:HyperLink ID="hlMuokkaa" runat="server">Muokkaa</asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:LinkButton ID="lbPoista" CommandName="Delete" runat="server" OnClientClick="return confirm('Oletko varma, että haluat poistaa tämän tiedon?')">Poista</asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
</asp:Content>
