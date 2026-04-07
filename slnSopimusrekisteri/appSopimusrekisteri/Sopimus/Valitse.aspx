<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Valitse.aspx.vb" Inherits="appSopimusrekisteri.ValitseSopimus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
  <asp:HiddenField ID="hdnYlasopimusId" runat="server" />
  <asp:HiddenField ID="hdnKiinteistoId" runat="server" />
  <h1>Valitse sopimuksen tyyppi</h1>
  <div class="form">
    <table class="form">
        <tr>
        <td class="formInputElement">
        &nbsp;
        </td>
        </tr>
        <tr>
        <td class="formInputElement">
        <asp:DropDownList ID="ddSopimustyyppi" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td class="formActions">
            <asp:button ID="btValitse" runat="server" Text="Valitse" />
            <asp:button ID="btPeruuta" runat="server" Text="Peruuta" />
        </td>
        </tr>
    </table>
  </div>

</asp:Content>
