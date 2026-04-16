<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Maksuaineistot.aspx.vb" Inherits="appSopimusrekisteri.MaksuaineistojenTiedot" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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
    <h1>Sopimusten maksuaineistot</h1>
    <div class="barAction">
      <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Maksuajot.aspx">Takaisin maksuajoihin</asp:HyperLink>
    </div>
  </div>
  <div class="bar">
    <asp:Button CssClass="fonttinormaali" Text='Luo esikatseluaineisto' CausesValidation='False' ID='btnTeeEsikatseluaineisto' runat='server'></asp:Button>
    <asp:Button CssClass="fonttinormaali" Text='Luo maksuaineisto' CausesValidation='False' ID='btnTeeMaksuaineisto' runat='server'></asp:Button>
    <div class="barInfo">
        <asp:DropDownList ID="ddKORKorvaustyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
        <asp:DropDownList ID="ddKORKorvauslaskelmaStatusId" runat="server" DataTextField="Nimi" DataValueField="ID" AutoPostBack="True"></asp:DropDownList>
        <asp:Label ID="lblTiedot" runat="server"></asp:Label>
    </div>
  </div>
    <div class="list">
        
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId">
      <Columns>
        <asp:BoundField DataField="SopimusId" HeaderText="Tunniste" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="SopimuksenNimi" HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Korvaustyyppi" HeaderText="Korvaustyyppi" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Korvausstatus" HeaderText="Korvausstatus" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="KorvausrivienMaara" HeaderText="Rivejä" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="KorvauslaskelmienSumma" HeaderText="Summa" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:f2}" />
        
      </Columns>
    </asp:GridView>
        
  </div>
</asp:Content>
