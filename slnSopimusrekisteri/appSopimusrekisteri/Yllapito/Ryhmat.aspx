<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Ryhmat.aspx.vb" Inherits="appSopimusrekisteri.Ryhmat" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

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
<h3>Ryhmien ylläpito</h3>
    <div class="viewInfo">

        <asp:DropDownList ID="ddRooli" runat="server"></asp:DropDownList>
        <asp:Button Text="Lisää oikeus valituille ryhmille" CausesValidation="False" ID="btLisaaRooliValittuihinRyhmiin" runat="server"></asp:Button>
        <asp:Button Text="Poista oikeus valituilta ryhmiltä" CausesValidation="False" ID="btPoistaRooliValituistaRyhmista" runat="server"></asp:Button>

        <table>
            <tr>
                <td class="viewInfoContentElement"></td>
            </tr>
            <tr>
                <td class="viewInfoContentElement"></td>
            </tr>
        </table>
        <div class="viewInfoClearElement"></div>
    </div>

    <div class="headerBar">
        <h1>Ryhmien ylläpito</h1>
    </div>
    
    <div class="list">

        <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupId">
          <Columns>
              <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top">
                  <HeaderTemplate>
                      <asp:CheckBox ID="cbValitseKaikki" runat="server" OnCheckedChanged="cbValitseKaikki_Checked" AutoPostBack="true" />
                  </HeaderTemplate>
                  <ItemTemplate>
                      <asp:CheckBox ID="cbValittu" runat="server" />
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Id" ItemStyle-VerticalAlign="Top" Visible="false">
                  <ItemTemplate>
                      <asp:Literal ID="lblId" runat="server" Text='<%# Bind("GroupId")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Nimi" ItemStyle-VerticalAlign="Top">
                  <ItemTemplate>
                      <asp:Literal ID="lblGroupName" runat="server" Text='<%# Bind("GroupName")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Ryhmään kuuluvat roolit" ItemStyle-VerticalAlign="Top">
                  <ItemTemplate>
                      <asp:Literal ID="lblRoolit" runat="server" Text='<%# Bind("Roolit")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
                  <ItemTemplate>
                      <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän ryhmän järjestelmästä?');"></asp:LinkButton>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
        </asp:GridView>

    </div>

    <div class="footerBar">
        <asp:Button Text="Lisää käyttäjä" CausesValidation="False" ID="btLisaaKayttaja" runat="server" PostBackUrl="~/Yllapito/Kayttaja.aspx" Visible="False"></asp:Button>
        <asp:Button Text="Lisää rooli" CausesValidation="False" ID="btLisaaRooli" runat="server" PostBackUrl="~/Yllapito/Rooli.aspx" Visible="False"></asp:Button>
        <asp:Button Text="Lisää ryhmä" CausesValidation="False" ID="btLisaaRyhma" runat="server" PostBackUrl="~/Yllapito/Ryhma.aspx"></asp:Button>
    </div>

</asp:Content>
