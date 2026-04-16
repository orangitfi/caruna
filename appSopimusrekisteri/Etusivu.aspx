<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Etusivu.aspx.vb" Inherits="appSopimusrekisteri.Etusivu" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>
<%@ Register src="Aktiviteetti/Tehtavalista.ascx" tagname="Tehtavalista" tagprefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">        
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
     <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <uc1:Tehtavalista ID="tehtavalista1" runat="server" />
</asp:Content>
