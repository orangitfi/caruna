<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.KorkoprosentinTiedot" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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
        <h1>Korkoprosentit</h1>
        <div class="barAction">
            <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
        </div>
    </div>
    <div class="bar">
        <asp:Button Text='Lisää' CausesValidation='False' ID='btnLisaa' runat='server' PostBackUrl="~/Ohjaustiedot/Korkoprosentti/Muokkaa.aspx"></asp:Button>
        <div class="barInfo">
            <asp:Label ID="lblTiedot" runat="server"></asp:Label>
        </div>
    </div>
    <div class="list">
        <table class="listGridview" cellpadding="3" cellspacing="0">
            <thead>
                <tr>
                    <th>Jäljellä oleva vuokra-aika vuosissa</th>
                    <th>Korkoprosentti</th>
                    <th class="listGridviewAction"></th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView runat="server" ID="lstTulokset" ItemType="Sopimusrekisteri.BLL_CF.Korkoprosentti" DataKeyNames="Id" OnItemEditing="lstTulokset_ItemEditing" OnItemDeleting="lstTulokset_ItemDeleting">
                    <ItemTemplate>
                        <tr class="listGridviewItem">
                            <td><%#: Item.Vuodet %></td>
                            <td><%#: Item.Prosentti.ToString("0.00") %> %</td>
                            <td class="listGridviewAction">
                                <asp:LinkButton runat="server" ID="lbMuokkaa" CommandName="Edit">Muokkaa</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbPoista" CommandName="Delete" OnClientClick="return confirm('Oletko varma, että haluat poistaa tämän tiedon?')">Poista</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
        </table>
    </div>
</asp:Content>
