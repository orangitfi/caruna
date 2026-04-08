<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.Taho.Organisaatio.Muokkaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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

  <h1>Organisaation tiedot</h1>
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
        <td class="formHeader">Asiakastyyppi</td>
        <td class="formValidation"></td>
        <td class="formInputElement">Organisaatio</td>
      </tr>
      <tr>
        <td class="formHeader">Organisaation tyyppi
          <uc3:Infopallura ID="ifpOrganisaationTyyppiId" runat="server" Kentta="OrganisaationTyyppiId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="OrganisaationTyyppiId" runat="server"></asp:DropDownList></td>
      </tr>
      <tr>
        <td class="formHeader">Yrityksen nimi
          <uc3:Infopallura ID="ifpSukunimi" runat="server" Kentta="Sukunimi"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="Sukunimi" ID="rvSukunimi" runat="server" ErrorMessage="Yrityksen nimi on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Sukunimi" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Nimen jatke
          <uc3:Infopallura ID="ifpNimitarkenne" runat="server" Kentta="Nimitarkenne"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="Nimitarkenne" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Y-tunnus
          <uc3:Infopallura ID="ifpYtunnus" runat="server" Kentta="Ytunnus"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="Ytunnus" runat="server" MaxLength="9"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Katuosoite
          <uc3:Infopallura ID="ifpPostitusosoite" runat="server" Kentta="Postitusosoite"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="Postitusosoite" ID="rvPostitusosoite" runat="server" ErrorMessage="Katuosoite on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Postitusosoite" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Postinumero
          <uc3:Infopallura ID="ifpPostituspostinro" runat="server" Kentta="Postituspostinro"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="Postituspostinro" ID="rvPostituspostinro" runat="server" ErrorMessage="Postinumero on vaadittu tieto" />
          <asp:CompareValidator Display="None" ControlToValidate="Postituspostinro" ID="ComValPostituspostinro" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Postinumero: anna numeroina"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Postituspostinro" runat="server" MaxLength="50"></asp:TextBox>
          <asp:Button ID="btnHaePostitoimipaikka" runat="server" Text="Hae postitoimipaikka" CausesValidation="False" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Postitoimipaikka
          <uc3:Infopallura ID="ifpPostituspostitmp" runat="server" Kentta="Postituspostitmp"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="Postituspostitmp" ID="rvPostituspostitmp" runat="server" ErrorMessage="Postitoimipaikka on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Postituspostitmp" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Kunta
          <uc3:Infopallura ID="ifpKuntaId" runat="server" Kentta="KuntaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="KuntaId" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maa
          <uc3:Infopallura ID="ifpMaaId" runat="server" Kentta="MaaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="MaaId" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Puhelinnumero
          <uc3:Infopallura ID="ifpPuhelin" runat="server" Kentta="Puhelin"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="Puhelin" ID="rvPuhelin" runat="server" ErrorMessage="Puhelinnumero on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Puhelin" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Sähköposti
          <uc3:Infopallura ID="ifpEmail" runat="server" Kentta="Email"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="Email" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Tilinumero
          <uc3:Infopallura ID="ifpTilinumero" runat="server" Kentta="Tilinumero"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CustomValidator ID="CusValTilinumero" runat="server" ErrorMessage="Tilinumero: tilinumero ei ole validi IBAN-numero"></asp:CustomValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="Tilinumero" runat="server" MaxLength="300" AutoPostBack="True"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">BIC-koodi
          <uc3:Infopallura ID="ifpBicKoodiId" runat="server" Kentta="BicKoodiId"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CustomValidator ID="CusValBic" runat="server" ErrorMessage="Bic-koodi: bic-koodi muu tulee olla tyhjä, jos bic-koodi on valittu" ClientValidationFunction="ValidoiBic"></asp:CustomValidator></td>
        <td class="formInputElement">
          <asp:DropDownList ID="BicKoodiId" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">BIC-koodi muu
          <uc3:Infopallura ID="ifpBicKoodiMuu" runat="server" Kentta="BicKoodiMuu"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="BicKoodiMuu" runat="server" MaxLength="15"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Alv-velvollinen
          <uc3:Infopallura ID="ifpAlvVelvollinen" runat="server" Kentta="AlvVelvollinen"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:CheckBox ID="AlvVelvollinen" runat="server"></asp:CheckBox></td>
      </tr>
      <tr>
        <td class="formHeader">Kirjanpidon yritystunniste
          <uc3:Infopallura ID="ifpKirjanpidonYritystunniste" runat="server" Kentta="KirjanpidonYritystunniste"></uc3:Infopallura>
        </td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">
          <asp:TextBox ID="KirjanpidonYritystunniste" runat="server" MaxLength="15"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Kirjanpidon projektitunniste
          <uc3:Infopallura ID="ifpKirjanpidonProjektitunniste" runat="server" Kentta="KirjanpidonProjektitunniste"></uc3:Infopallura>
        </td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">
          <asp:TextBox ID="KirjanpidonProjektitunniste" runat="server" MaxLength="15"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">PCS-Concession
          <uc3:Infopallura ID="ifpConcession" runat="server" Kentta="Concession"></uc3:Infopallura>
        </td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">
          <asp:TextBox ID="Concession" runat="server" MaxLength="15"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Lisätietoa
          <uc3:Infopallura ID="ifpInfo" runat="server" Kentta="Info"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="Info" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox></td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

  <script language="javascript" type="text/javascript">

    function ValidoiBic(source, arguments) {
      var bicKoodiLista = $("#cphContent_BicKoodiId");
      var bicKoodiMuu = $("#cphContent_BicKoodiMuu");

      if (bicKoodiLista.val() > 0 && bicKoodiMuu.val().length > 0) {
        arguments.IsValid = false;
      } else {
        arguments.IsValid = true;
      }

    }

  </script>

</asp:Content>
