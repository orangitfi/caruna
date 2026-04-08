<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="sopimus_edit.aspx.vb" MasterPageFile="~/Site.Master" Inherits="appFortumMalli.sopimus_edit" Theme="Default" StylesheetTheme="Default" %>

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
    <h1>Muuntamosopimus</h1>
    <div class="view">
        <div class="viewInfoFull">
        </div>
    </div>
    <div>

        <h1>Sopimusosapuolet</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Yhtiö</td>
                    <td class="formInputElement"><asp:DropDownList runat="server" ID="ddlYhtio"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Sopimuksen laatija</td>
                    <td class="formInputElement"><asp:TextBox ID='txtSopijanimi' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
            </table> 
        </div>

        <h1>Kiinteistö</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Rekisterinumero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtTonttinro' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Nimi</td>
                    <td class="formInputElement"><asp:TextBox ID='txtTonttiNimi' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Katuosoite</td>
                    <td class="formInputElement"><asp:TextBox ID='txtKatuosoite' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Postinumero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtPostinro' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Postitoimipaikka</td>
                    <td class="formInputElement"><asp:TextBox ID='txtPostitmp' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Kunta</td>
                    <td class="formInputElement"><asp:TextBox ID='txtTonttiKunta' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Kylä</td>
                    <td class="formInputElement"><asp:TextBox ID='txtTonttiKyla' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Kiinteistötunnus</td>
                    <td class="formInputElement"><asp:TextBox ID='txtKiinteistoTunnus' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
            </table> 
        </div> 

        <h1>Sopimus</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Alkupvm</td>
                    <td class="formInputElement">
                    <asp:TextBox ID='txtSopimusAlkupvm' MaxLength='10' runat='server' SkinID="Datetime"></asp:TextBox>&nbsp; <img id="imgKAMAlkupvm" runat="server" src="pics/Kalenteri.png" alt="Klikkaa kalenteria ja valitse päivämäärä." />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Loppupvm</td>
                    <td class="formInputElement">
                    <asp:TextBox ID='txtSopimusLoppupvm' MaxLength='10' runat='server' SkinID="Datetime"></asp:TextBox>&nbsp; <img id="img1" runat="server" src="pics/Kalenteri.png" alt="Klikkaa kalenteria ja valitse päivämäärä." />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Kesto</td>
                    <td class="formInputElement"><asp:DropDownList runat="server" ID="ddlKesto"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Muu tunniste</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuutunniste' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;PCS-numero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtPCS' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Sopimushetken indeksi</td>
                    <td class="formInputElement"><asp:TextBox ID='txtSophetkenIndeksi' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
            </table> 
        </div> 

        <h1>Muuntamo</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Tunnus</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuuntamoTunnus' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Nimi</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuuntamoNimi' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Katuosoite</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuuntamoOsoite' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Postitoimipaikka</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuuntamoPostitmp' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Pinta-ala</td>
                    <td class="formInputElement"><asp:TextBox ID='txtMuuntamoPintaala' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
            </table> 
        </div> 


        <h1>Omistaja</h1>
        <div class="form">
            <div class="formInfo">* merkityt tiedot ovat pakollisia</div>
            <table class="form" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="formHeader">*&nbsp;Nimi</td>
                    <td class="formInputElement"><asp:TextBox ID='txtOmistajanimi' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Katuosoite</td>
                    <td class="formInputElement"><asp:TextBox ID='txtOmistajaOsoite' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Postinumero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtomistajaPostinro' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Postitoimipaikka</td>
                    <td class="formInputElement"><asp:TextBox ID='txtOmistajaPostitmp' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Puhelinnumero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtomistajaPuh' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;S.Posti</td>
                    <td class="formInputElement"><asp:TextBox ID='txtOmistajasposti' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="formHeader">*&nbsp;Tilinumero</td>
                    <td class="formInputElement"><asp:TextBox ID='txtOmistajaTilinro' Columns='50' MaxLength='300' runat='server'></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="formActions">
                        <asp:Button runat="server" ID="btnJatka" Text="Tallenna" />
                    </td>
                </tr>
            </table> 
        </div> 

        </div>
</asp:Content>
