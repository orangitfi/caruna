<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="valitseTyyppi.aspx.vb" MasterPageFile="~/Site.Master" Inherits="appFortumMalli.valitseTyyppi" Theme="Default" StylesheetTheme="Default" %>

<%@ Register TagPrefix="KTDROP" TagName="ctrlDropDown" Src="ctrlDropDown.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Haku.ascx" TagName="Haku" TagPrefix="uc1" %>
<%@ Register Src="Tyokalut/HenkiloTyokalut.ascx" TagName="HenkiloTyokalut" TagPrefix="uc1" %>
<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
        <link href="App_Themes/PalvelupyyntojenKasittely.css" rel="stylesheet" />
    <link href="App_Themes/font-awesome/css/font-awesome-ie7.min.css" rel="stylesheet" />
    <link href="App_Themes/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:henkilotyokalut ID="HenkiloTyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc1:Haku ID="Haku1" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <h1>Sopimuksen tyyppi</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Sopimuksen tyyppi:</td>
                    <td class="formInputElement"><asp:DropDownList runat="server" ID="ddlTyyppi"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formActions">
                        <asp:Button runat="server" ID="btnJatka" Text="Jatka" />
                    </td>
                </tr>
            </table> 
        </div>

</asp:Content>
