<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="perusnaytto_sopimus.aspx.vb" MasterPageFile="~/Site.Master" Inherits="appFortumMalli.perusnaytto_sopimus" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="perustiedot" Src="perustiedot_sopimus.ascx" %>
<%@ Register TagPrefix="uc1" TagName="kiinteistoPerustiedot" Src="kiinteistot.ascx" %>
<%@ Register TagPrefix="uc1" TagName="muuntamotiedot" Src="muuntamon_tiedot.ascx" %>
<%@ Register TagPrefix="uc1" TagName="yhteystiedot" Src="yhteystiedot.ascx" %>
<%@ Register TagPrefix="uc1" TagName="korvaus" Src="korvaus.ascx" %>
<%@ Register TagPrefix="uc1" TagName="tiedosto" Src="tiedosto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="aktiviteetti" Src="aktiviteetti.ascx" %>
<%@ Register TagPrefix="uc1" TagName="maksu" Src="maksu.ascx" %>
<%@ Register Src="Haku.ascx" TagName="Haku" TagPrefix="uc1" %>
<%@ Register Src="Tyokalut/HenkiloTyokalut.ascx" TagName="HenkiloTyokalut" TagPrefix="uc2" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0" />
    <%--<link href="App_Themes/JasensivuResponsive.css" rel="stylesheet" />--%> <%--Testiä responsiiviseksi muuttamisesta--%>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
  <script type="text/javascript">
      var classHover = "view2columnsElementHover"

      $('td.view2columnsHeader1').live('mouseover mouseout', function (event) {
          if (event.type == 'mouseover') {
              $(this).addClass(classHover);
              $(this).next().addClass(classHover);
          } else {
              $(this).removeClass(classHover);
              $(this).next().removeClass(classHover);
          }
      });

      $('td.view2columnsContentElement1').live('mouseover mouseout', function (event) {
          if (event.type == 'mouseover') {
              $(this).addClass(classHover);
              $(this).prev().addClass(classHover);
          } else {
              $(this).removeClass(classHover);
              $(this).prev().removeClass(classHover);
          }
      });

      $('td.view2columnsHeader2').live('mouseover mouseout', function (event) {
          if (event.type == 'mouseover') {
              $(this).addClass(classHover);
              $(this).next().addClass(classHover);
          } else {
              $(this).removeClass(classHover);
              $(this).next().removeClass(classHover);
          }
      });

      $('td.view2columnsContentElement2').live('mouseover mouseout', function (event) {
          if (event.type == 'mouseover') {
              $(this).addClass(classHover);
              $(this).prev().addClass(classHover);
          } else {
              $(this).removeClass(classHover);
              $(this).prev().removeClass(classHover);
          }
      });
  </script>
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc2:HenkiloTyokalut ID="HenkiloTyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc1:Haku ID="Haku1" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  
  <uc1:perustiedot ID="Perustiedot" runat="server" ></uc1:perustiedot>
  <uc1:kiinteistoPerustiedot ID="kiinteistoPerustiedot" runat="server"></uc1:kiinteistoPerustiedot>
  <uc1:muuntamotiedot ID="muuntamot" runat="server"></uc1:muuntamotiedot>
  <uc1:yhteystiedot ID="yhteystiedot" runat="server"></uc1:yhteystiedot>
  <uc1:korvaus ID="korvaus" runat="server"></uc1:korvaus>
    <uc1:tiedosto ID="tiedosto" runat="server"></uc1:tiedosto>
    <uc1:aktiviteetti ID="aktiviteetti" runat="server"></uc1:aktiviteetti>
    <uc1:maksu ID="maksu" runat="server"></uc1:maksu>
</asp:Content>