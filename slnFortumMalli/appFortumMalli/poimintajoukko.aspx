<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="poimintajoukko.aspx.vb" MasterPageFile="~/Site.Master" Inherits="appFortumMalli.poimintajoukko" Theme="Default" StylesheetTheme="Default" %>

<%@ Register TagPrefix="KTDROP" TagName="ctrlDropDown" Src="ctrlDropDown.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Haku.ascx" TagName="Haku" TagPrefix="uc1" %>
<%@ Register Src="Tyokalut/HenkiloTyokalut.ascx" TagName="HenkiloTyokalut" TagPrefix="uc1" %>
<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:henkilotyokalut ID="HenkiloTyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc1:Haku ID="Haku1" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <div class="bar barExtensionGray">
    <h1>POIMINTA</h1>
  </div>
  <div class="bar">
      <div class="barText"><asp:label ID="lblInfo" runat="server" Text="Poimittuja 1"></asp:label></div>
  </div>
  <div class="headerBarWhite">
      <asp:button ID="btnUusiPoiminta" runat="server" Text="Uusi poiminta" />
  </div>
  <div class="list">
  <table class="listGridview" cellspacing="0" cellpadding="0">
      <tr class="listGridviewHeader">
            <th>
              Sopimusnro
            </th>
            <th>
              Alkupvm
            </th>
            <th>
              Loppupvm
            </th>
            <th>
                Muu tunniste
            </th>
            <th>
                PCS-numero
            </th>
            <th>
                Tyyppi
            </th>
    </tr>
    <tr class="listGridviewItem">
        <td>
            <asp:HyperLink ID="hlSopimus" runat="server" NavigateUrl="~/perusnaytto_sopimus.aspx" Text="534526"></asp:HyperLink>
        </td>
        <td>
            04.03.1999
        </td>
        <td>
            04.03.2029
        </td>
        <td>
            QWERTYASD
        </td>
        <td>
            123123
        </td>
        <td>
            Muuntamosopimus
        </td>
    </tr>
  </table>
  </div>
</asp:Content>