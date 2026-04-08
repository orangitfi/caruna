<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Roolit.aspx.vb" Inherits="appSopimusrekisteri.Roolit" Theme="Default" StylesheetTheme="Default" %>


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
<h3>Roolien ylläpito</h3>
    <div class="viewInfo">
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
        <h1>Roolien ylläpito</h1>
    </div>
    
    <div class="list">

        <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False">
          <Columns>
              <asp:TemplateField HeaderText="Nimi" ItemStyle-VerticalAlign="Top">
                  <ItemTemplate>
                      <asp:Literal ID="lblNimi" runat="server" Text='<%# Bind("Nimi")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Käyttäjämäärä" ItemStyle-VerticalAlign="Top">
                  <ItemTemplate>
                      <asp:Literal ID="lblLukumaara" runat="server" Text='<%# Bind("Käyttäjämäärä")%>'></asp:Literal>
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
                  <ItemTemplate>
                      <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän roolin järjestelmästä?');"></asp:LinkButton>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
        </asp:GridView>

    </div>

    <div class="footerBar">
        <asp:Button Text="Lisää käyttäjä" CausesValidation="False" ID="btLisaaKayttaja" runat="server" PostBackUrl="~/Yllapito/Kayttaja.aspx"></asp:Button>
        <asp:Button Text="Lisää rooli" CausesValidation="False" ID="btLisaaRooli" runat="server" PostBackUrl="~/Yllapito/Rooli.aspx"></asp:Button>
        <asp:Button Text="Lisää ryhmä" CausesValidation="False" ID="btLisaaRyhma" runat="server" PostBackUrl="~/Yllapito/Ryhma.aspx"></asp:Button>
    </div>

</asp:Content>
