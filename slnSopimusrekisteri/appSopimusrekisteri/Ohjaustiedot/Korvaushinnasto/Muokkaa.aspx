<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.KorvaushinnastonMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
 
  <h1>Korvaushinnaston tiedot</h1>
  <div class="form">
    <div class="formValidationInfo"><asp:validationsummary ID="ValidationSummary1" runat="server" /></div>
    <div class="formInfo">
      
    </div>
    <div class="formDateInfo">
        <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
            <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblKHIPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKHIPaivittaja" runat="server"></asp:Label>)
            <br />
            <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblKHILuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKHILuoja" runat="server"></asp:Label>)
        </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Korvauslaji</td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">        
        <asp:textbox ID="txtKHIKorvauslaji" runat="server" Text="" MaxLength="500"></asp:textbox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kuvaus</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">        
        <asp:textbox ID="txtKHIKuvaus" runat="server" Text="" MaxLength="500"></asp:textbox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Sopimustyyppi</td>
        <td class="formValidation">&nbsp;
        </td>
        <td><asp:DropDownList ID="ddKHISopimustyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
      </tr>        
       <tr>
        <td class="formHeader">Yksikkö</td>
        <td class="formValidation">&nbsp;
        </td>
        <td><asp:DropDownList ID="ddKHIYksikkoId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
        </tr>
        <tr>
       <td class="formHeader">Yksikköhinta</td>
       <td class="formValidation">
           <asp:CompareValidator Display="None" ControlToValidate="txtKHIYksikkkohinta" ID="cmpKHIYksikkkohinta" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Yksikköhinnan tulee olla desimaaliluku"></asp:CompareValidator>
       </td>
       <td class="formInputElement"><asp:textbox ID="txtKHIYksikkkohinta" runat="server" Text="" MaxLength="10"></asp:textbox></td>
       </tr>
       <tr>
        <td class="formHeader">Yksikköhinnan tarkenne</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement"><asp:textbox ID="txtKHIYksikkohinnanTarkenne" runat="server" Text="" MaxLength="500"></asp:textbox></td>
        </tr>
      <tr>
        <td class="formHeader">Kasvupaikkatyyppi</td>
        <td class="formValidation">&nbsp;
        </td>          
        <td class="formInputElement">
            <asp:DropDownList ID="ddKHIMetsatyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Puustolaji</td>
        <td class="formValidation">&nbsp;
        </td>          
        <td class="formInputElement">
            <asp:DropDownList ID="ddKHIPuustolajiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>       
      <tr>
        <td class="formHeader">Hinnaston kategoria</td>
        <td class="formValidation">&nbsp;</td>
        <td>
            <asp:DropDownList ID="ddKHIHinnastoKategoriaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
      </tr>

      <tr>
        <td class="formHeader">Hinnaston alakategoria</td>
        <td class="formValidation">&nbsp;
        </td>
        <td><asp:DropDownList ID="ddKHIHinnastoAlakategoriaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
      </tr>

      <tr>
        <td class="formHeader">Arvon peruste</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement"><asp:textbox ID="txtKHIArvonPeruste" runat="server" Text="" TextMode="MultiLine" Rows="5" MaxLength="500"></asp:textbox></td>
      </tr>
      <tr>
        <td class="formHeader">Maksualue</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
            <asp:DropDownList ID="ddKHIMaksuAlueId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Puuston ikä</td>
        <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKHIPuustonIka" ID="cmpKHIPuustonIka" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Puuston iän tulee olla luku"></asp:CompareValidator>
        </td>
        <td class="formInputElement"><asp:textbox ID="txtKHIPuustonIka" runat="server" Text="" MaxLength="3"></asp:textbox></td>
       </tr>
       <tr>
       <td class="formHeader">Taimiston valtapitoisuus</td>
       <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKHITaimistonValtapituus" ID="cmpKHITaimistonValtapituus" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Taimiston valtapitoisuuden tulee olla desimaaliluku"></asp:CompareValidator>
       </td>
       <td class="formInputElement"><asp:textbox ID="txtKHITaimistonValtapituus" runat="server" Text="" MaxLength="10"></asp:textbox></td>
       </tr>
       <tr>
       <td class="formHeader">Tiheyskerroin</td>
       <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKHITiheyskerroin" ID="cmpKHITiheyskerroin" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Tiheyskertoimen tulee olla desimaaliluku"></asp:CompareValidator>
       </td>
       <td class="formInputElement"><asp:textbox ID="txtKHITiheyskerroin" runat="server" Text="" MaxLength="10"></asp:textbox></td>
       </tr>
        <tr>
        <td class="formHeader">Alkupäivä</td>
        <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKHIAlkuPvm" ID="cmpKHIAlkuPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Alkamispäivän tulee olla päivämäärä"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
            <asp:textbox ID="txtKHIAlkuPvm" runat="server" Text="" MaxLength="10"></asp:textbox>
            <asp:Image ID="imgKHIAlkuPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server"/>
            <ajaxToolkit:CalendarExtender ID="calKHIAlkuPvm" runat="server" TargetControlID="txtKHIAlkuPvm" PopupButtonID="imgKHIAlkuPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>         
      <tr>
        <td class="formHeader">Loppupäivä</td>
        <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKHILoppuPvm" ID="cmpKHILoppuPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Loppupäivän tulee olla päivämäärä"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
            <asp:textbox ID="txtKHILoppuPvm" runat="server" Text="" MaxLength="10"></asp:textbox>
            <asp:Image ID="imgKHILoppuPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server"/>
            <ajaxToolkit:CalendarExtender ID="calKHILoppuPvm" runat="server" TargetControlID="txtKHILoppuPvm" PopupButtonID="imgKHILoppuPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>  
        <tr>
        <td class="formHeader">Aktiivinen</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement"><asp:CheckBox ID="cbKHIAktiivinen" runat="server" Text=""></asp:CheckBox></td>
        </tr>
        <tr>
        <td class="formHeader">Lisätieto</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement"><asp:textbox ID="txtKHIInfo" runat="server" Text="" MaxLength="10"></asp:textbox></td>
        </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formDescription">
            
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True"/>
          <asp:button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False"/>
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
