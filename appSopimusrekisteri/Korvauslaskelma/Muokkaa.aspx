<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.Korvauslaskelma.Muokkaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <h1>Korvauslaskelman tiedot</h1>
  <div class="form" id="formData" runat="server">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">

      <table>
        <tr>
          <td class="viewInfoContentElement" style="vertical-align: top; padding-right: 70px;">
            <b>Korvauksen sopimus</b><br />
            <br />
            <asp:LinkButton ID="lbSopimus" runat="server" CausesValidation="False"></asp:LinkButton><br />
            <br />
          </td>
          <td class="viewInfoContentElement">
              <b>Korvauksen saaja</b><br />
              <br />
              <asp:Label ID="Saaja_Nimi" runat="server"></asp:Label><br />
              <asp:Label ID="Saaja_Postitusosoite" runat="server"></asp:Label><br />
            <asp:Label ID="Saaja_Postituspostinro" runat="server"></asp:Label> <asp:Label ID="Saaja_Postituspostitmp" runat="server"></asp:Label><br />
              <br />
              <asp:Label ID="Saaja_Email" runat="server"></asp:Label><br />
              <asp:Label ID="Saaja_Puhelin" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td class="viewInfoContentElement"></td>
        </tr>
      </table>
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
        <td class="formHeader">Projektinumero</td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">
          <asp:Label ID="Sopimus_PCSNumero" runat="server"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maksun suoritus
          <uc3:Infopallura ID="ifpMaksunSuoritusId" runat="server" Kentta="MaksunSuoritusId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="MaksunSuoritusId" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Viesti
          <uc3:Infopallura ID="ifpViesti" runat="server" Kentta="Viesti"></uc3:Infopallura>
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Viesti" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Viite
          <uc3:Infopallura ID="ifpViite" runat="server" Kentta="Viite"></uc3:Infopallura>
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Viite" runat="server" MaxLength="20"></asp:TextBox></td>
      </tr>
      <asp:PlaceHolder ID="phAlv" runat="server">
        <tr>
          <td class="formHeader">Maksetaan alv
          <uc3:Infopallura ID="Infopallura1" runat="server" Kentta="MaksetaanAlv"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;</td>
          <td class="formInputElement">
            <asp:CheckBox ID="MaksetaanAlv" runat="server" />
          </td>
        </tr>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
        <tr>
          <td class="formHeader">Korvaustyyppi
          <uc3:Infopallura ID="ifpKorvaustyyppiId" runat="server" Kentta="KorvaustyyppiId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td>
            <asp:DropDownList ID="KorvaustyyppiId" runat="server" AutoPostBack="True"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Korvauksen projektinumero
          <uc3:Infopallura ID="ifpKorvauksenProjektinumero" runat="server" Kentta="KorvauksenProjektinumero"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="KorvauksenProjektinumero" runat="server" MaxLength="300"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Ensimmäinen sallittu maksupäivä
          <uc3:Infopallura ID="ifpEnsimmainenSallittuMaksuPvm" runat="server" Kentta="EnsimmainenSallittuMaksuPvm"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="EnsimmainenSallittuMaksuPvm" ID="ComValEnsimmainenSallittuMaksuPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Ensimmäinen sallittu maksupäivä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="EnsimmainenSallittuMaksuPvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgEnsimmainenSallittuMaksuPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calEnsimmainenSallittuMaksuPvm" runat="server" TargetControlID="EnsimmainenSallittuMaksuPvm" PopupButtonID="imgEnsimmainenSallittuMaksuPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <tr>
          <td class="formHeader">Maksukuukausi
          <uc3:Infopallura ID="ifpMaksuKuukausiId" runat="server" Kentta="MaksuKuukausiId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:DropDownList ID="MaksuKuukausiId" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="formHeader">Korvauslaskelman tila
          <uc3:Infopallura ID="ifpKorvauslaskelmaStatusId" runat="server" Kentta="KorvauslaskelmaStatusId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:DropDownList ID="KorvauslaskelmaStatusId" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="formHeader">Sopimuskorvaus org.
          <uc3:Infopallura ID="ifpMaksettavaKorvausAlkuperainen" runat="server" Kentta="MaksettavaKorvausAlkuperainen"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="MaksettavaKorvausAlkuperainen" ID="ComValMaksettavaKorvausAlkuperainen" Type="Currency" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimuskorvaus org.: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="MaksettavaKorvausAlkuperainen" runat="server" SkinID="Decimal"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="formHeader">Viimeinen maksuajankohta
          <uc3:Infopallura ID="ifpViimeinenMaksuPvm" runat="server" Kentta="ViimeinenMaksuPvm"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="ViimeinenMaksuPvm" ID="ComValViimeinenMaksuPvm" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Viimeinen maksuajankohta: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="ViimeinenMaksuPvm" runat="server" SkinID="Datetime"></asp:TextBox>
            <asp:Image ID="imgViimeinenMaksuPvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
            <ajaxToolkit:CalendarExtender ID="calViimeinenMaksuPvm" runat="server" TargetControlID="ViimeinenMaksuPvm" PopupButtonID="imgViimeinenMaksuPvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          </td>
        </tr>
        <asp:PlaceHolder ID="phLisaMaksutiedot" runat="server">
          <tr>
            <td class="formHeader">Sopimuksella on indeksi
          <uc3:Infopallura ID="ifpOnIndeksi" runat="server" Kentta="OnIndeksi"></uc3:Infopallura>
            </td>
            <td class="formValidation">&nbsp;</td>
            <td class="formInputElement">
              <asp:CheckBox ID="OnIndeksi" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="formHeader">Indeksityyppi
          <uc3:Infopallura ID="ifpIndeksityyppiId" runat="server" Kentta="IndeksityyppiId"></uc3:Infopallura>
            </td>
            <td class="formValidation">&nbsp;</td>
            <td class="formInputElement">
              <asp:DropDownList ID="IndeksityyppiId" runat="server"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td class="formHeader">Indeksivuosi
          <uc3:Infopallura ID="ifpIndeksiVuosi" runat="server" Kentta="IndeksiVuosi"></uc3:Infopallura>
            </td>
            <td class="formValidation">
              <asp:CompareValidator Display="None" ControlToValidate="IndeksiVuosi" ID="ComValIndeksiVuosi" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Indeksivuosi: anna numeerisessa muodossa"></asp:CompareValidator></td>
            <td class="formInputElement">
              <asp:TextBox ID="IndeksiVuosi" runat="server" SkinID="Short"></asp:TextBox>&nbsp;
              <asp:Label ID="lblViimeisinIndeksiVuosi" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="formHeader">Indeksi kk
          <uc3:Infopallura ID="ifpIndeksiKuukausiId" runat="server" Kentta="IndeksiKuukausiId"></uc3:Infopallura>
            </td>
            <td class="formValidation">&nbsp;</td>
            <td class="formInputElement">
              <asp:DropDownList ID="IndeksiKuukausiId" runat="server"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td class="formHeader">Sopimushetken indeksi
          <uc3:Infopallura ID="ifpSopimushetkenIndeksiArvo" runat="server" Kentta="SopimushetkenIndeksiArvo"></uc3:Infopallura>
            </td>
            <td class="formValidation">
              <asp:CompareValidator Display="None" ControlToValidate="SopimushetkenIndeksiArvo" ID="ComValSopimushetkenIndeksiArvo" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Sopimushetken indeksi: anna numeerisessa muodossa"></asp:CompareValidator></td>
            <td class="formInputElement">
              <asp:TextBox ID="SopimushetkenIndeksiArvo" runat="server" SkinID="Short"></asp:TextBox>&nbsp;
              <asp:Label ID="lblViimeisinIndeksi" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="formHeader">Maksuehdot
          <uc3:Infopallura ID="ifpMaksuehdotId" runat="server" Kentta="MaksuehdotId"></uc3:Infopallura>
            </td>
            <td class="formValidation">&nbsp;</td>
            <td class="formInputElement">
              <asp:DropDownList ID="MaksuehdotId" runat="server"></asp:DropDownList>
            </td>
          </tr>
        </asp:PlaceHolder>
        <tr>
          <td colspan="3" class="formSeparatorHeader">Tiliöintitiedot</td>
        </tr>
        <tr>
          <td class="formHeader">Kirjanpidon tili
          <uc3:Infopallura ID="ifpKirjanpidonTiliId" runat="server" Kentta="KirjanpidonTiliId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:DropDownList ID="KirjanpidonTiliId" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="formHeader">Kirjanpidon kustannuspaikka
          <uc3:Infopallura ID="ifpKirjanpidonKustannuspaikkaId" runat="server" Kentta="KirjanpidonKustannuspaikkaId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:DropDownList ID="KirjanpidonKustannuspaikkaId" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="formHeader">Inv/Cost
          <uc3:Infopallura ID="ifpInvCostId" runat="server" Kentta="InvCostId"></uc3:Infopallura>
          </td>
          <td class="formValidation">&nbsp;
          </td>
          <td class="formInputElement">
            <asp:DropDownList ID="InvCostId" runat="server"></asp:DropDownList></td>
        </tr>
      </asp:PlaceHolder>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

</asp:Content>