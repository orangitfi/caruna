<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="poimintalomake.aspx.vb"  MasterPageFile="~/Site.Master" Inherits="appFortumMalli.poimintalomake" Theme="Default" StylesheetTheme="Default" %>

<%@ Import Namespace="appFortumMalli" %>

<%@ Register  TagName="ctrlDropDown" Src="ctrlDropDown.ascx" TagPrefix="uc1" %>
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
    <div class="headerBar">
    <h1>
      POIMINTALOMAKE</h1>
  </div>
  <div class="form" style="margin-bottom: 0px;">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="btnPoiminta">
      </asp:ValidationSummary>
    </div>
    <div class="formInfo">
      Anna sivulla poimintaehtoja, joilla haluat rajata rekisterin sopimuksia ja kiinteistöjä.
      Ehdot täyttävät tahot otetaan mukaan poimintaan. Jos annat useamman ehdon, kaikkien ehtojen
      pitää täyttyä, jotta taho poimitaan.<br />
      <br />
    </div>
    <div style="clear: both;"></div>  
    <div class="formClearElement">
      &nbsp;</div>      
  </div>

  <%-- Kiinteistön tiedot --%>
  <cc1:CollapsiblePanelExtender ID="cpeKiinteisto" runat="server" CollapseControlID="imgKiinteisto" ExpandControlID="imgKiinteisto"
      TargetControlID="pnlKiinteisto" CollapsedImage="pics/expand.jpg" ExpandedImage="pics/collapse.jpg"
      ImageControlID="imgKiinteisto" SuppressPostBack="true" Collapsed="true" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="true" ></cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgKiinteisto" ImageUrl="pics/expand.jpg" runat="server" />
      <h1>
        Kiinteistön tiedot</h1>
    </div>
  </div>  
  <asp:Panel ID="pnlKiinteisto" runat="server">
    <div class="form formExtensionAccordion">

        <table class="form" cellpadding="0" cellspacing="0">
            <tr>
                <td class="formHeader" valign="top">Kiinteistön kunta</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:DropDownList ID="ddlKiinteistonKunta" runat="server" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="formHeader" valign="top">Kiinteistön kylä</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:DropDownList ID="ddlKiinteistonKyla" runat="server" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="formHeader" valign="top">Kiinteistön postinumero</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:DropDownList ID="ddlKiinteistonPostinro" runat="server" ></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
  </asp:Panel>

    <%-- Sopimuksen tiedot --%>
  <cc1:CollapsiblePanelExtender ID="cpeSopimus" runat="server" CollapseControlID="imgSopimus" ExpandControlID="imgSopimus" 
  TargetControlID="pnlSopimus" CollapsedImage="pics/expand.jpg" ExpandedImage="pics/collapse.jpg"
  ImageControlID="imgSopimus" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgSopimus" ImageUrl="pics/expand.jpg" runat="server" />
      <h1>
        Sopimuksen tiedot</h1>
    </div>
  </div>  
  <asp:Panel ID="pnlSopimus" runat="server">
    <div class="form formExtensionAccordion">

        <table class="form" cellpadding="0" cellspacing="0">
            <tr>
                <td class="formHeader" valign="top">Sopimuksen tyyppi</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:DropDownList ID="ddlSopimuksenTyyppi" runat="server"></asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">Sopimuksen alkupvm</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:TextBox ID='txtSopimusAlkupvm' MaxLength='10' runat='server' SkinID="Datetime"></asp:TextBox>&nbsp; <img id="imgKAMAlkupvm" runat="server" src="pics/Kalenteri.png" alt="Klikkaa kalenteria ja valitse päivämäärä." />
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">Sopimuksen loppupvm</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:TextBox ID='txtSopimusLoppupvm' MaxLength='10' runat='server' SkinID="Datetime"></asp:TextBox>&nbsp; <img id="img1" runat="server" src="pics/Kalenteri.png" alt="Klikkaa kalenteria ja valitse päivämäärä." />
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">Sopimuksen kesto</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:DropDownList ID="ddlKesto" runat="server"></asp:DropDownList>
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">Muu tunniste</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:TextBox ID='txtMuutunniste' Columns='50' MaxLength='300' runat='server'></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">PCS-numero</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:TextBox ID='txtPCS' Columns='50' MaxLength='300' runat='server'></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td class="formHeader" valign="top">Sopimushetken indeksi</td>
                <td class="formValidation"></td>
                <td class="formInputElement">                
                    <asp:TextBox ID='txtSopHetkenIndeksi' Columns='50' MaxLength='300' runat='server'></asp:TextBox>
                </td>
            </tr> 
        </table>
    </div>
  </asp:Panel>
  <div class="form">
    <table class="form" cellpadding="0" cellspacing="0">
      <tr>
        <td class="formActions" style="text-align: center;">
          <asp:Button ID="btnPoimi" runat="server" Text="Poimi" />
          <asp:Button ID="btnPeru" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>
</asp:Content>