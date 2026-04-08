<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.HenkilonMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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

  <h1>Henkilön tiedot</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
      <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
        <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblTAHPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblTAHPaivittaja" runat="server"></asp:Label>)
            <br />
        <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblTAHLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblTAHLuoja" runat="server"></asp:Label>)
      </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Asiakastyyppi</td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:Label ID="lblAsiakastyyppi" runat="server" Text="Henkilö"></asp:Label></td>
      </tr>
      <tr>
        <td class="formHeader">Etunimi
          <uc3:Infopallura ID="ifpTAHEtunimi" runat="server" Kentta="TAHEtunimi"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHEtunimi" ID="rvtxtTAHEtunimi" runat="server" ErrorMessage="Etunimi on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHEtunimi" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Sukunimi
          <uc3:Infopallura ID="ifpTAHSukunimi" runat="server" Kentta="TAHSukunimi"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHSukunimi" ID="rvtxtTAHSukunimi" runat="server" ErrorMessage="Sukunimi on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHSukunimi" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Nimen jatke
          <uc3:Infopallura ID="ifpTAHNimitarkenne" runat="server" Kentta="TAHNimitarkenne"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHNimitarkenne" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Katuosoite
          <uc3:Infopallura ID="ifpTAHPostitusosoite" runat="server" Kentta="TAHPostitusosoite"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHPostitusosoite" ID="rvtxtTAHPostitusosoite" runat="server" ErrorMessage="Katuosoite on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHPostitusosoite" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Postinumero
          <uc3:Infopallura ID="ifpTAHPostituspostinro" runat="server" Kentta="TAHPostituspostinro"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHPostituspostinro" ID="rvtxtTAHPostituspostinro" runat="server" ErrorMessage="Postinumero on vaadittu tieto" />
          <asp:CompareValidator Display="None" ControlToValidate="txtTAHPostituspostinro" ID="ComValTAHPostituspostinro" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Postinumero: anna numeroina"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHPostituspostinro" runat="server" MaxLength="5"></asp:TextBox>
          <asp:Button ID="btnHaePostitoimipaikka" runat="server" Text="Hae postitoimipaikka" CausesValidation="False" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Postitoimipaikka
          <uc3:Infopallura ID="ifpTAHPostituspostitmp" runat="server" Kentta="TAHPostituspostitmp"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHPostituspostitmp" ID="rvtxtTAHPostituspostitmp" runat="server" ErrorMessage="Postitoimipaikka on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHPostituspostitmp" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Kunta
          <uc3:Infopallura ID="ifpTAHKuntaId" runat="server" Kentta="TAHKuntaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddTAHKuntaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maa
          <uc3:Infopallura ID="ifpTAHMaaId" runat="server" Kentta="TAHMaaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddTAHMaaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Puhelinnumero
          <uc3:Infopallura ID="ifpTAHPuhelin" runat="server" Kentta="TAHPuhelin"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtTAHPuhelin" ID="rvtxtTAHPuhelin" runat="server" ErrorMessage="Puhelinnumero on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHPuhelin" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Sähköposti
          <uc3:Infopallura ID="ifpTAHEmail" runat="server" Kentta="TAHEmail"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHEmail" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Tilinumero
          <uc3:Infopallura ID="ifpTAHTilinumero" runat="server" Kentta="TAHTilinumero"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CustomValidator ID="CusValTAHTilinumero" runat="server" ErrorMessage="Tilinumero: tilinumero ei ole validi IBAN-numero"></asp:CustomValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHTilinumero" runat="server" MaxLength="300" AutoPostBack="True"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">BIC-koodi
          <uc3:Infopallura ID="ifpTAHBicKoodiId" runat="server" Kentta="TAHBicKoodiId"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CustomValidator ID="CusValBic" runat="server" ErrorMessage="Bic-koodi: bic-koodi muu tulee olla tyhjä, jos bic-koodi on valittu" ClientValidationFunction="ValidoiBic"></asp:CustomValidator></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddTAHBicKoodiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">BIC-koodi muu
          <uc3:Infopallura ID="ifpTAHBic" runat="server" Kentta="TAHBic"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHBic" runat="server" MaxLength="15"></asp:TextBox></td>
      </tr>
      <tr>
        <td class="formHeader">Lisätietoa
          <uc3:Infopallura ID="ifpTAHInfo" runat="server" Kentta="TAHInfo"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHInfo" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox></td>
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

    function ValidoiBic(source, arguments)
    {
      var bicKoodiLista = $("#cphContent_ddTAHBicKoodiId");
      var bicKoodiMuu = $("#cphContent_txtTAHBic");

      if (bicKoodiLista.val() > 0 && bicKoodiMuu.val().length > 0) {
        arguments.IsValid = false;
      } else {
        arguments.IsValid = true;
      }

    }

  </script>

</asp:Content>
