<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Kayttajat.aspx.vb" Inherits="appSopimusrekisteri.Kayttajat" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <!-- Yläosan tiedot -->
  <h3>Käyttäjien ylläpito</h3>
  <div class="bar">
      <asp:DropDownList ID="ddRooli" runat="server"></asp:DropDownList>
      <asp:Button Text="Lisää oikeus valituille käyttäjille" CausesValidation="False" ID="btLisaaValitutKayttajatRooliin" runat="server"></asp:Button>
      <asp:Button Text="Poista oikeus valituilta käyttäjiltä" CausesValidation="False" ID="btPoistaValitutKayttajatRoolista" runat="server"></asp:Button>
    </div>
  <div class="bar">
      <asp:DropDownList ID="ddRyhma" runat="server"></asp:DropDownList>
      <asp:Button Text="Lisää valitut käyttäjät ryhmään" CausesValidation="False" ID="btLisaaValitutKayttajatRyhmaan" runat="server"></asp:Button>
      <asp:Button Text="Poista valitut käyttäjät ryhmästä" CausesValidation="False" ID="btPoistaValitutKayttajatRyhmasta" runat="server"></asp:Button>
  </div>
  <div class="bar">
    <asp:Button Text="Lisää käyttäjä" CausesValidation="False" ID="btLisaaKayttaja" runat="server" PostBackUrl="~/Yllapito/Kayttaja.aspx"></asp:Button>
  </div>
  <div class="headerBar">
    <h1>Järjestelmässä olevat käyttäjät ja käyttäjien oikeudet</h1>
  </div>

  <div class="list">

    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False">
      <Columns>
        <asp:TemplateField HeaderText="">
          <HeaderTemplate>
            <asp:CheckBox ID="cbValitseKaikki" runat="server" OnCheckedChanged="cbValitseKaikki_Checked" AutoPostBack="true" />
          </HeaderTemplate>
          <ItemTemplate>
            <asp:CheckBox ID="cbValittu" runat="server" />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Käyttäjä">
          <ItemTemplate>
            <asp:Literal ID="lblKayttaja" runat="server" Text='<%# Bind("Käyttäjä")%>'></asp:Literal>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Etunimi">
          <ItemTemplate>
            <asp:Literal ID="lblEtunimi" runat="server" Text='<%# Bind("Etunimi")%>'></asp:Literal>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sukunimi">
          <ItemTemplate>
            <asp:Literal ID="lblSukunimi" runat="server" Text='<%# Bind("Sukunimi")%>'></asp:Literal>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Käyttäjän ryhmät">
          <ItemTemplate>
            <asp:Literal ID="lblKayttajanRyhmat" runat="server" Text='<%# Bind("KäyttäjänRyhmät")%>'></asp:Literal>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Käyttäjän oikeudet">
          <ItemTemplate>
            <asp:Literal ID="lblKayttajanRoolit" runat="server" Text='<%# Bind("KäyttäjänRoolit")%>'></asp:Literal>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="" ControlStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>
            <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän käyttäjän järjestelmästä?');"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>

  </div>

  <div class="footerBar">
  </div>

</asp:Content>
