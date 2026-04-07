<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Poimintalomake_testi.aspx.vb" Inherits="appSopimusrekisteri.Poimintalomake_testi" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Poimintatyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/PoimintaOperaattori.ascx" TagName="Operaattori" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div class="headerBar">
    <h1>POIMINTALOMAKE</h1>
  </div>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server"></asp:ValidationSummary>
    </div>
    <div class="formInfo">
    Poimitaan<br />
    <asp:RadioButtonList ID="rblPoimintaTyyppi" runat="server">
      <asp:ListItem Text="Sopimuksia" Value="sopimus" selected="true" />
      <asp:ListItem text="Kiinteistöjä" Value="kiinteisto" />
      <asp:ListItem Text="Tahoja" Value="taho" />
    </asp:RadioButtonList>
    </div>
  </div>
  <cc1:CollapsiblePanelExtender ID="cpeSopimus" runat="server" CollapseControlID="imgSopimus" ExpandControlID="imgSopimus"
    TargetControlID="pnlSopimus" CollapsedImage="../App_Themes/Default/Images/expand.jpg" ExpandedImage="../App_Themes/Default/Images/collapse.jpg"
    ImageControlID="imgSopimus" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgSopimus" ImageUrl="../App_Themes/Default/Images/expand.jpg" runat="server" />
      <h1>Sopimuksen tiedot</h1>
    </div>
  </div>
  <asp:Panel ID="pnlSopimus" runat="server">
    <div class="form formExtensionAccordion">
      <table class="form">
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="s_lSopimustyyppiId" AssociatedControlID="s_SopimustyyppiId">Sopimustyyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <uc1:Operaattori ID="s_oSopimustyyppiId" runat="server" AssociatedControlID="s_SopimustyyppiId"></uc1:Operaattori>
            </td>
          <td class="formInputElement">
            <asp:DropDownList ID="s_SopimustyyppiId" runat="server"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="s_lPCSNumero" AssociatedControlID="s_PCSNumero">Projektinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <uc1:Operaattori ID="s_oPCSNumero" runat="server" AssociatedControlID="s_PCSNumero"></uc1:Operaattori></td>
          <td class="formInputElement">
            <asp:TextBox ID="s_PCSNumero" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblProjektinvalvoja">Projektivalvoja</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Projektinvalvoja" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblJuridinenYhtioId">Juridinen yhtiö</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="JuridinenYhtioId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMuuTunniste">Muu tunniste</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="MuuTunniste" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimuksenLaatija">Sopimuksen laatija</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="SopimuksenLaatija" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKorvaa">Korvaa sopimuksen</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Korvaa" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblDFRooliId">Verkkoyhtiön rooli sopimuksessa</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="DFRooliId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKarttaliite">Karttaliite</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Karttaliite" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblAsiakkaanAllekirjoitusPvm">Asiakkaan allekirjoituspäivämäärä</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="AsiakkaanAllekirjoitusPvm" ID="ComValAsiakkaanAllekirjoitusPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Asiakkaan allekirjoituspäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="AsiakkaanAllekirjoitusPvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgAsiakkaanAllekirjoitusPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calAsiakkaanAllekirjoitusPvm" runat="server" TargetControlID="AsiakkaanAllekirjoitusPvm" PopupButtonID="imgAsiakkaanAllekirjoitusPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblVerkonhaltijanAllekirjoitusPvm">Verkonhaltijan allekirjoituspäivämäärä</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="VerkonhaltijanAllekirjoitusPvm" ID="ComValVerkonhaltijanAllekirjoitusPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Verkonhaltijan allekirjoituspäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="VerkonhaltijanAllekirjoitusPvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgVerkonhaltijanAllekirjoitusPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calVerkonhaltijanAllekirjoitusPvm" runat="server" TargetControlID="VerkonhaltijanAllekirjoitusPvm" PopupButtonID="imgVerkonhaltijanAllekirjoitusPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblAlkupvm">Alkupvm</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="Alkupvm" ID="ComValAlkupvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Alkupvm: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Alkupvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgAlkupvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calAlkupvm" runat="server" TargetControlID="Alkupvm" PopupButtonID="imgAlkupvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPaattymispvm">Päättymispvm</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="Paattymispvm" ID="ComValSOPPaattyy" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Päättymispvm: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Paattymispvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgPaattymispvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calPaattymispvm" runat="server" TargetControlID="Paattymispvm" PopupButtonID="imgPaattymispvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblJatkoaika">Sopimuksen jatkoaika (kk)</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="Jatkoaika" ID="ComValJatkoaika" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuksen jatkoaika (kk): anna kokonaisluku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Jatkoaika" runat="server" SkinID="Numeric"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimuksenIrtisanomisaika">Sopimuksen irtisanomisaika (kk)</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="SopimuksenIrtisanomisaika" ID="ComValSopimuksenIrtisanomisaika" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuksen irtisanomisaika (kk): anna kokonaisluku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="SopimuksenIrtisanomisaika" runat="server" SkinID="Numeric"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimuksenIrtisanomistoimet">Sopimuksen irtisanomistoimet</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="SopimuksenIrtisanomistoimet" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPuustonOmistajuusId">Puuston omistajuus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="PuustonOmistajuusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPuustonPoistoId">Puuston poisto</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="PuustonPoistoId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKieliId">Kieli</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KieliId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lbl21">Luonnos</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="Luonnos" runat="server" DataTextField="Nimi" DataValueField="ID">
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPaasopimusId">Yläsopimus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="PaasopimusId" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblYlasopimuksenTyyppiId">Yläsopimuksen tyyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="YlasopimuksenTyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblAlkuperainenYhtioId">Alkuperäinen yhtiö</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="AlkuperainenYhtioId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblJulkisuusasteId">Julkisuusaste</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="JulkisuusasteId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimuksenAlaluokkaId">Sopimuksen alaluokka</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="SopimuksenAlaluokkaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimuksenEhtoversioId">Sopimuksen ehtoversio</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="SopimuksenEhtoversioId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKuvaus">Sisällön yleiskuvaus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Kuvaus" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblVerkonhaltijaSiirtoOikeusId">Sopimuksen siirto-oikeus verkonhaltija</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="VerkonhaltijaSiirtoOikeusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblVastaosapuoliSiirtoOikeusId">Sopimuksen siirto-oikeus vastaosapuoli</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="VastaosapuoliSiirtoOikeusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblIrtisanomispvm">Sopimuksen irtisanomispvm</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="IrtisanomisPvm" ID="ComValIrtisanomispvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuksen irtisanomispvm: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Irtisanomispvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgIrtisanomispvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calIrtisanomispvm" runat="server" TargetControlID="IrtisanomisPvm" PopupButtonID="imgIrtisanomispvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKohdekategoriaId">Sopimuksen kohdekategoria</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KohdekategoriaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </table>
    </div>
  </asp:Panel>


  <cc1:CollapsiblePanelExtender ID="cpeKiinteisto" runat="server" CollapseControlID="imgKiinteisto" ExpandControlID="imgKiinteisto"
    TargetControlID="pnlKiinteisto" CollapsedImage="../App_Themes/Default/Images/expand.jpg" ExpandedImage="../App_Themes/Default/Images/collapse.jpg"
    ImageControlID="imgKiinteisto" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgKiinteisto" ImageUrl="../App_Themes/Default/Images/expand.jpg" runat="server" />
      <h1>Kiinteiston tiedot</h1>
    </div>
  </div>
  <asp:Panel ID="pnlKiinteisto" runat="server">
    <div class="form formExtensionAccordion">
      <table class="form">
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblNimi">Kiinteistön nimi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Nimi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblYtunnusKiinteisto">Ytunnus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="YtunnusKiinteisto" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblOsoiteKiinteisto">Osoite</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="OsoiteKiinteisto" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPostinumeroKiinteisto">Postinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="PostinumeroKiinteisto" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPostitoimipaikkaKiinteisto">Postitoimipaikka</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="PostitoimipaikkaKiinteisto" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMaa">Maa</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Maa" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKyla">Kylä</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Kyla" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKunta">Kunta</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Kunta" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblRekisterinumero">Rekisterinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Rekisterinumero" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblLyhytKiinteistotunnus">Lyhyt kiinteistötunnus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="LyhytKiinteistotunnus" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKokonaisPintaAla">Kokonaispinta-ala</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="KokonaisPintaAla" runat="server"></asp:TextBox>
          </td>
        </tr>
      </table>
    </div>
  </asp:Panel>

  <cc1:CollapsiblePanelExtender ID="cpeKorvauslaskelma" runat="server" CollapseControlID="imgKorvauslaskelma" ExpandControlID="imgKorvauslaskelma"
    TargetControlID="pnlKorvauslaskelma" CollapsedImage="../App_Themes/Default/Images/expand.jpg" ExpandedImage="../App_Themes/Default/Images/collapse.jpg"
    ImageControlID="imgKorvauslaskelma" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgKorvauslaskelma" ImageUrl="../App_Themes/Default/Images/expand.jpg" runat="server" />
      <h1>Korvauslaskelman tiedot</h1>
    </div>
  </div>
  <asp:Panel ID="pnlKorvauslaskelma" runat="server">
    <div class="form formExtensionAccordion">
      <table class="form">
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMaksunSuoritusId">Maksun suoritus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="MaksunSuoritusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblViesti">Viesti</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Viesti" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblViite">Viite</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Viite" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKorvaustyyppiId">Korvaustyyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KorvaustyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKorvauksenProjektinumero">Korvauksen projektinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="KorvauksenProjektinumero" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblEnsimmainenSallittuMaksupvm">Ensimmäinen sallittu maksupäivä</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="EnsimmainenSallittuMaksupvm" ID="CompareValidator1" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Korvauslaskelman ensimmäinen sallittu maksupäivä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="EnsimmainenSallittuMaksupvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgEnsimmainenSallittuMaksupvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="ceEnsimmainenSallittuMaksupvm" runat="server" TargetControlID="EnsimmainenSallittuMaksupvm" PopupButtonID="imgEnsimmainenSallittuMaksupvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMaksukuukausiId">Maksukuukausi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="MaksukuukausiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKorvausStatusId">Korvauslaskelman tila</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KorvausStatusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblAlkuperainenKorvaus">Sopimuskorvaus org.</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="AlkuperainenKorvaus" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblViimeisinMaksupvm">Viimeinen maksuajankohta</asp:Label>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="ViimeisinMaksupvm" ID="CompareValidator2" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Korvauslaskelman viimeinen maksuajankohta: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="ViimeisinMaksupvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgViimeisinMaksupvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="ceViimeisinMaksupvm" runat="server" TargetControlID="ViimeisinMaksupvm" PopupButtonID="imgViimeisinMaksupvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMaksetaanAlv">Maksetaan alv</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="MaksetaanAlv" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblOnIndeksi">Sopimuksella on indeksi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="OnIndeksi" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblIndeksityyppiId">Indeksityyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="IndeksityyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblIndeksivuosi">Indeksivuosi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Indeksivuosi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblIndeksikuukausiId">Indeksikuukausi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="IndeksikuukausiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSopimushetkenIndeksi">Sopimushetken indeksi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="SopimushetkenIndeksi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblMaksuehdotId">Maksuehdot</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="MaksuehdotId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKirjanpidonTiliId">Kirjanpidon tili</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KirjanpidonTiliId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblKustannuspaikkaId">Kirjanpidon kustannuspaikka</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="KustannuspaikkaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblInvCostId">Inv/Cost</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="InvCostId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblRegulationId">Regulation</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="RegulationId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPurposeId">Purpose</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="PurposeId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblLocal1Id">Local1</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="Local1Id" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </table>
    </div>
  </asp:Panel>

  <cc1:CollapsiblePanelExtender ID="cpeTaho" runat="server" CollapseControlID="imgTaho" ExpandControlID="imgTaho"
    TargetControlID="pnlTaho" CollapsedImage="../App_Themes/Default/Images/expand.jpg" ExpandedImage="../App_Themes/Default/Images/collapse.jpg"
    ImageControlID="imgTaho" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgTaho" ImageUrl="../App_Themes/Default/Images/expand.jpg" runat="server" />
      <h1>Tahon tiedot</h1>
    </div>
  </div>
  <asp:Panel ID="pnlTaho" runat="server">
    <div class="form formExtensionAccordion">
      <table class="form">
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblTahoTyyppiId">Tyyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="TahoTyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblEtunimi">Etunimi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Etunimi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblSukunimi">Sukunimi / Yhtiön nimi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Sukunimi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblYtunnusTaho">Y-Tunnus</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElementTaho">
            <asp:TextBox ID="Ytunnus" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblOsoiteTaho">Katuosoite</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="OsoiteTaho" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPostinumeroTaho">Postinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="PostinumeroTaho" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPostitoimipaikkaTaho">Postitoimipaikka</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="PostitoimipaikkaTaho" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblPuhelin">Puhelinnumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Puhelin" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblEmail">Sähköposti</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblTilinumero">Tilinumero</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="Tilinumero" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblBicKoodi">BIC-koodi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="BicKoodi" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblBicKoodiMuu">BIC-koodi muu</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:TextBox ID="BicKoodiMuu" runat="server"></asp:TextBox>
          </td>
        </tr>
      </table>
    </div>
  </asp:Panel>
  
  <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="imgSopimus_Taho" ExpandControlID="imgSopimus_Taho"
    TargetControlID="pnlSopimus_Taho" CollapsedImage="../App_Themes/Default/Images/expand.jpg" ExpandedImage="../App_Themes/Default/Images/collapse.jpg"
    ImageControlID="imgSopimus_Taho" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
  </cc1:CollapsiblePanelExtender>
  <div class="headerBar headerBarExtensionAccordion">
    <div class="headerBarAccordionElement">
      <asp:Image ID="imgSopimus_Taho" ImageUrl="../App_Themes/Default/Images/expand.jpg" runat="server" />
      <h1>Sopimuksen asiakkaan tiedot</h1>
    </div>
  </div>
  <asp:Panel ID="pnlSopimus_Taho" runat="server">
    <div class="form formExtensionAccordion">
      <table class="form">
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblstAsiakastyyppiId">Asiakastyyppi</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="stAsiakastyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader"><asp:Label runat="Server" ID="lblstDFRooliId">Verkkoyhtiön rooli</asp:Label>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            &nbsp;</td>
          <td class="formInputElement">
            <asp:DropDownList ID="stDFRooliId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </table>
    </div>
  </asp:Panel>
  <div class="form">
    <table class="form" cellpadding="0" cellspacing="0">
      <tr>
        <td class="formActions" style="text-align: center;">
          <asp:Button ID="btPoimi" runat="server" Text="Poimi" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" />
        </td>
      </tr>
    </table>
  </div>
</asp:Content>
