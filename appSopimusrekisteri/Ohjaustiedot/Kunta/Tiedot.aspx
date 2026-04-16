<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.KuntienTiedot" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

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
    <h1>Kuntien tiedot</h1>
    <div class="barAction">
      <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
    </div>
  </div>
  <div class="bar">
    <asp:Button Text='Lisää' CausesValidation='False' ID='btnLisaa' runat='server' PostBackUrl="~/Ohjaustiedot/Kunta/Muokkaa.aspx"></asp:Button>
    <div class="barInfo">
        <asp:Label ID="lblTiedot" runat="server"></asp:Label>
        <%--<asp:CheckBox runat="server" Checked="True" ID="cbNaytaAktiiviset" Text="Näytä vain aktiiviset rivit" AutoPostBack="True"/>--%>
    </div>
  </div>
    <div class="list">
        
        <asp:ObjectDataSource ID="odsTulokset" runat="server"   
            TypeName="appSopimusrekisteri.BLL.Kunta"
            SelectMethod="Hae" 
            InsertMethod="Lisaa"
            UpdateMethod="Muokkaa" 
            DeleteMethod="Poista">
            <%--
            <SelectParameters>
                <asp:ControlParameter ControlID="cbNaytaAktiiviset" PropertyName="Checked" type="String" Name="vainAktiiviset" /> 
            </SelectParameters>
            --%>
        </asp:ObjectDataSource>
        
        <asp:GridView ID="gwTulokset" DataKeyNames="KKuntaId" runat="server" AutoGenerateColumns="False" DataSourceID="odsTulokset" AllowPaging="True" AllowSorting="True" PageSize="20">
            <Columns>
            <asp:BoundField DataField="KKuntaId" HeaderText="Tunniste" ItemStyle-VerticalAlign="Top" />
            <asp:BoundField DataField="KKunta" HeaderText="Nimi" ItemStyle-VerticalAlign="Top" />
            <asp:HyperLinkField Text="Muokkaa" DataNavigateUrlFields="KKuntaId" DataNavigateUrlFormatString="~/Ohjaustiedot/Kunta/Muokkaa.aspx?id={0}" />
            <asp:ButtonField CommandName="Delete" Text="Poista" ButtonType="Link" ControlStyle-CssClass="deleteLink"/>
            </Columns>
        </asp:GridView>
        
        <script language="javascript" type="text/javascript">
            $(".deleteLink").click(function () {
                return confirm('Oletko varma, että haluat poistaa tämän tiedon?');
            });
        </script>
  </div>
</asp:Content>
