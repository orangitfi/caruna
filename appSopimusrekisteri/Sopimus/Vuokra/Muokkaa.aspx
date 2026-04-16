<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.Sopimus.Vuokra.Muokkaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>
<%@ Register Assembly="Sopimusrekisteri.Controls" Namespace="Sopimusrekisteri.Controls" TagPrefix="controls" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
    <h1>
        <asp:Label ID="lblOtsikko" runat="server"></asp:Label></h1>
    <div class="form" id="formData" runat="server">
        <div class="formValidationInfo">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <div class="formInfo">
        </div>
        <div class="formDateInfo">
            <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="Paivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="Paivittaja" runat="server"></asp:Label>)
            <br />
            <b>Luotu:</b>&nbsp;
            <asp:Label ID="Luotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="Luoja" runat="server"></asp:Label>)
        </div>
        <table class="form">
            <tr>
                <td class="formHeader">Sopimustyyppi
          <uc3:Infopallura ID="ifpSopimustyyppiId" runat="server" Kentta="SopimustyyppiId"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:DropDownList ID="SopimustyyppiId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Korvaukseton
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:CheckBox ID="Korvaukseton" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sopimusnumero
          <uc3:Infopallura ID="ifpSopimusnro" runat="server" Kentta="lblSopimusnro"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:Label ID="lblSopimusnro" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Projektinumero
          <uc3:Infopallura ID="ifpPCSNumero" runat="server" Kentta="PCSNumero"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator Display="None" ControlToValidate="PCSNumero" ID="rvPCSNumero" runat="server" ErrorMessage="Projektinumero on vaadittu tieto" />
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="PCSNumero" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">CaCe-tehtävä
          <uc3:Infopallura ID="ifpCaceTehtava" runat="server" Kentta="CaceTehtava"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="CaceTehtava" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Projektivalvoja
          <uc3:Infopallura ID="ifpProjektinvalvoja" runat="server" Kentta="Projektinvalvoja"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="Projektinvalvoja" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Juridinen yhtiö
          <uc3:Infopallura ID="ifpJuridinenYhtioId" runat="server" Kentta="JuridinenYhtioId"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator Display="None" ControlToValidate="JuridinenYhtioId" ID="rvJuridinenyhtio" runat="server" ErrorMessage="Juridinen yhtiö on vaadittu tieto" />
                </td>
                <td class="formInputElement">
                    <asp:DropDownList ID="JuridinenYhtioId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Muu tunniste
          <uc3:Infopallura ID="ifpMuuTunniste" runat="server" Kentta="MuuTunniste"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="MuuTunniste" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sopimuksen laatija
          <uc3:Infopallura ID="ifpSopimuksenLaatija" runat="server" Kentta="SopimuksenLaatija"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator Display="None" ControlToValidate="SopimuksenLaatija" ID="rvSopimuksenLaatija" runat="server" ErrorMessage="Sopimuksen laatija on vaadittu tieto" />
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="SopimuksenLaatija" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Korvaa sopimuksen
          <uc3:Infopallura ID="ifpKorvaa" runat="server" Kentta="Korvaa"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="Korvaa" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Verkkoyhtiön rooli sopimuksessa
          <uc3:Infopallura ID="ifpDFRooliId" runat="server" Kentta="DFRooliId"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:DropDownList ID="DFRooliId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Karttaliite
          <uc3:Infopallura ID="ifpKarttaliite" runat="server" Kentta="Karttaliite"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="Karttaliite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Asiakkaan allekirjoituspäivämäärä
          <uc3:Infopallura ID="ifpAsiakkaanAllekirjoitusPvm" runat="server" Kentta="AsiakkaanAllekirjoitusPvm"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <controls:DateInputValidator ID="dvAsiakkaanAllekirjoitusPvm" runat="server" DateInputID="AsiakkaanAllekirjoitusPvm" FieldName="Asiakkaan allekirjoituspäivämäärä" />
                </td>
                <td class="formInputElement">
                    <controls:DateInput ID="AsiakkaanAllekirjoitusPvm" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Verkonhaltijan allekirjoituspäivämäärä
          <uc3:Infopallura ID="ifpVerkonhaltijanAllekirjoitusPvm" runat="server" Kentta="VerkonhaltijanAllekirjoitusPvm"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <controls:DateInputValidator ID="dvVerkonhaltijanAllekirjoitusPvm" runat="server" DateInputID="VerkonhaltijanAllekirjoitusPvm" FieldName="Verkonhaltijan allekirjoituspäivämäärä" />
                </td>
                <td class="formInputElement">
                    <controls:DateInput ID="VerkonhaltijanAllekirjoitusPvm" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Alkupvm
          <uc3:Infopallura ID="ifpAlkaa" runat="server" Kentta="Alkaa"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <controls:DateInputValidator ID="dvAlkaa" runat="server" DateInputID="Alkaa" FieldName="Alkupvm" />
                </td>
                <td class="formInputElement">
                    <controls:DateInput ID="Alkaa" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Päättymispvm
          <uc3:Infopallura ID="ifpPaattyy" runat="server" Kentta="Paattyy"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <controls:DateInputValidator ID="dvPaattyy" runat="server" DateInputID="Paattyy" FieldName="Päättymispvm" />
                </td>
                <td class="formInputElement">
                    <controls:DateInput ID="Paattyy" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sopimuksen jatkoaika (kk)
          <uc3:Infopallura ID="ifpJatkoaika" runat="server" Kentta="Jatkoaika"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:CompareValidator Display="None" ControlToValidate="Jatkoaika" ID="ComValJatkoaika" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuksen jatkoaika (kk): anna kokonaisluku"></asp:CompareValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="Jatkoaika" runat="server" SkinID="Numeric"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sopimuksen irtisanomisaika (kk)
          <uc3:Infopallura ID="ifpSopimuksenIrtisanomisaika" runat="server" Kentta="SopimuksenIrtisanomisaika"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:CompareValidator Display="None" ControlToValidate="SopimuksenIrtisanomisaika" ID="ComValSopimuksenIrtisanomisaika" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuksen irtisanomisaika (kk): anna kokonaisluku"></asp:CompareValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox ID="SopimuksenIrtisanomisaika" runat="server" SkinID="Numeric"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Sopimuksen irtisanomistoimet
          <uc3:Infopallura ID="ifpSopimuksenIrtisanomistoimet" runat="server" Kentta="SopimuksenIrtisanomistoimet"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="SopimuksenIrtisanomistoimet" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Puuston omistajuus
          <uc3:Infopallura ID="ifpPuustonOmistajuusId" runat="server" Kentta="PuustonOmistajuusId"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:DropDownList ID="PuustonOmistajuusId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Puuston poisto
          <uc3:Infopallura ID="ifpPuustonPoistoId" runat="server" Kentta="PuustonPoistoId"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:DropDownList ID="PuustonPoistoId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Luovutettujen pylväiden määrä
          <uc3:Infopallura ID="ifpPylvasmaara" runat="server" Kentta="Pylvasvali"></uc3:Infopallura>
                </td>
                <td class="formValidation">
                    <asp:CustomValidator runat="server" ID="cvPylvasvali" OnServerValidate="cvPylvasvali_ServerValidate" ErrorMessage="Anna pylväsmäärä kokonaislukuna tai kokonaislukujen välinä (esim 10 tai 10-15)."></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="Pylvasvali" SkinID="Numeric"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader">Kieli
          <uc3:Infopallura ID="ifpKieliId" runat="server" Kentta="KieliId"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:DropDownList ID="KieliId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Erityisehdot
          <uc3:Infopallura ID="ifpErityisehdot" runat="server" Kentta="Erityisehdot"></uc3:Infopallura>
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="Erityisehdot" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
                <tr>
                    <td class="formHeader">Yläsopimus
          <uc3:Infopallura ID="ifpPaasopimusId" runat="server" Kentta="PaasopimusId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="PaasopimusId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Yläsopimuksen tyyppi
          <uc3:Infopallura ID="ifpYlasopimuksenTyyppiId" runat="server" Kentta="YlasopimuksenTyyppiId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="YlasopimuksenTyyppiId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Alkuperäinen yhtiö
          <uc3:Infopallura ID="ifpAlkuperainenYhtioId" runat="server" Kentta="AlkuperainenYhtioId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="AlkuperainenYhtioId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Julkisuusaste
          <uc3:Infopallura ID="ifpJulkisuusasteId" runat="server" Kentta="JulkisuusasteId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="JulkisuusasteId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen alaluokka
          <uc3:Infopallura ID="ifpSopimuksenAlaluokkaId" runat="server" Kentta="SopimuksenAlaluokkaId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="SopimuksenAlaluokkaId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen ehtoversio
          <uc3:Infopallura ID="ifpSopimuksenEhtoversioId" runat="server" Kentta="SopimuksenEhtoversioId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="SopimuksenEhtoversioId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Mappitunniste
          <uc3:Infopallura ID="ifpMappitunniste" runat="server" Kentta="Mappitunniste"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:TextBox ID="Mappitunniste" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sisällön yleiskuvaus
          <uc3:Infopallura ID="ifpKuvaus" runat="server" Kentta="Kuvaus"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:TextBox ID="Kuvaus" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen siirto-oikeus verkonhaltija
          <uc3:Infopallura ID="ifpVerkonhaltijaSiirtoOikeusId" runat="server" Kentta="VerkonhaltijaSiirtoOikeusId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="VerkonhaltijaSiirtoOikeusId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen siirto-oikeus vastaosapuoli
          <uc3:Infopallura ID="ifpVastaosapuoliSiirtoOikeusId" runat="server" Kentta="VastaosapuoliSiirtoOikeusId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="VastaosapuoliSiirtoOikeusId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen irtisanomispvm
          <uc3:Infopallura ID="ifpIrtisanomispvm" runat="server" Kentta="Irtisanomispvm"></uc3:Infopallura>
                    </td>
                    <td class="formValidation">
                        <controls:DateInputValidator ID="dvIrtisanomispvm" runat="server" DateInputID="Irtisanomispvm" FieldName="Sopimuksen irtisanomispvm" />
                    </td>
                    <td class="formInputElement">
                        <controls:DateInput ID="Irtisanomispvm" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">Sopimuksen kohdekategoria
          <uc3:Infopallura ID="ifpKohdekategoriaId" runat="server" Kentta="KohdekategoriaId"></uc3:Infopallura>
                    </td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList ID="KohdekategoriaId" runat="server" />
                    </td>
                </tr>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="phIFRS" Visible="false">
                <tr>
                    <td class="formHeader">IFRS Raportointi ja Maturiteetti</td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:CheckBox runat="server" ID="FAS" Text="FAS" /><br />
                        <asp:CheckBox runat="server" ID="IFRS" Text="IFRS16" />
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">IFRS Vuokratyyppi</td>
                    <td class="formValidation"></td>
                    <td class="formInputElement">
                        <asp:DropDownList runat="server" ID="VuokratyyppiId"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="formHeader">IFRS Korkoprosentti (%)</td>
                    <td class="formValidation">
                        <asp:CompareValidator runat="server" ID="cvKorkoprosentti" ErrorMessage="Anna prosentti kokonaislukuna tai desimaalina" Operator="DataTypeCheck" Display="None" ControlToValidate="Korkoprosentti" Type="Double"></asp:CompareValidator>
                        <asp:CustomValidator runat="server" ID="cusKorkoprosentti" ErrorMessage="Anne prosenttiluku välillä 0-100." OnServerValidate="cusKorkoprosentti_ServerValidate" Display="None"></asp:CustomValidator>
                    </td>
                    <td class="formInputElement">
                        <asp:UpdatePanel runat="server" ID="upKorkoprosentti">
                            <ContentTemplate>
                                <asp:TextBox runat="server" ID="Korkoprosentti" MaxLength="8" SkinID="Numeric"></asp:TextBox>
                                <asp:Button runat="server" ID="btnLaskeKorkoprosentti" Text="Hae korko" CausesValidation="false" OnClick="btnLaskeKorkoprosentti_Click" />
                                <asp:Image ID="ifpKorkoprosentti" runat="server" SkinID="InfoImage" style="display: inline-block" ToolTip="Korko haetaan ohjaustietohin määritellyistä korkoprosenteista. Sopimuksen jäljellä olevat vuodet lasketaan vertaamalla päättymispäivää nykyiseen päivään, tai jos sopimus alkaa tulevaisuudessa niin sopimuksen alkupäivään. Jos sopimuksella ei ole päättymispäivää, otetaan oletuksena 35 vuoden korkoprosentti." />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td class="formHeader">Tila
                </td>
                <td class="formValidation">
                    <asp:CustomValidator ID="cvSopimuksenTilaTilinumerot" runat="server" ErrorMessage="Tila ei voi olla Voimassa, jos korvauslaskelman saajien tilinumerot puuttuvat"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvSopimuksenTilaId" runat="server" ErrorMessage="Tila ei voi olla Voimassa, jos allekirjoituspäivämäärät puuttuvat"></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:DropDownList ID="SopimuksenTilaId" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="formHeader">Lisätietoja
                </td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    <asp:TextBox ID="Info" runat="server" SkinID="Info" TextMode="MultiLine" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Button ID="btTallenna" runat="server" Text="Tallenna" />
                    <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
