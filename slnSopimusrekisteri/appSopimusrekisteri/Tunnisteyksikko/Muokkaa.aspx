<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.TunnisteyksikonMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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

  <h1>Tunnisteyksikön tiedot</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
      <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
        <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblTUYPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblTUYPaivittaja" runat="server"></asp:Label>)
            <br />
        <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblTUYLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblTUYLuoja" runat="server"></asp:Label>)
      </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Sopimus</td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:Label ID="lblTUYSopimusId" runat="server" Visible="False"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Tunnisteyksikön tyyppi
          <uc3:Infopallura ID="ifpTUYTunnisteyksikkoTyyppiId" runat="server" Kentta="TUYTunnisteyksikkoTyyppiId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddTUYTunnisteyksikkoTyyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Muu tunniste
          <uc3:Infopallura ID="ifpTUYTunnus" runat="server" Kentta="TUYTunnus"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTUYTunnus" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
        <tr>
          <td class="formHeader">NIS-tunnus
          <uc3:Infopallura ID="ifpTUYPGTunnus" runat="server" Kentta="TUYPGTunnus"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtTUYPGTunnus" runat="server" MaxLength="300"></asp:TextBox></td>
        </tr>
      <tr>
        <td class="formHeader">Nimi/Linja osa
          <uc3:Infopallura ID="ifpTUYNimi" runat="server" Kentta="TUYNimi"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTUYNimi" runat="server" MaxLength="300"></asp:TextBox></td>
      </tr>
      <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
        <tr>
          <td class="formHeader">Verkkotietojärjestelmäid-tunniste
          <uc3:Infopallura ID="ifpTUYPGTunniste" runat="server" Kentta="TUYPGTunniste"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtTUYPGTunniste" runat="server" MaxLength="300"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="formHeader">Verkkotietojärjestelmä-koordinaatti 1
          <uc3:Infopallura ID="ifpTUYPGKoordinaatti1" runat="server" Kentta="TUYPGKoordinaatti1"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtTUYPGKoordinaatti1" ID="ComValTUYPGKoordinaatti1" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="PG-koordinaatti 1: anna kokonaisluku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtTUYPGKoordinaatti1" runat="server" MaxLength="10"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="formHeader">Verkkotietojärjestelmä-koordinaatti 2
          <uc3:Infopallura ID="ifpTUYPGKoordinaatti2" runat="server" Kentta="TUYPGKoordinaatti2"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtTUYPGKoordinaatti2" ID="ComValTUYPGKoordinaatti2" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="PG-koordinaatti 2: anna kokonaislukus"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtTUYPGKoordinaatti2" runat="server" MaxLength="10"></asp:TextBox></td>
        </tr>
      </asp:PlaceHolder>
      <tr>
        <td class="formHeader">Lisätieto
          <uc3:Infopallura ID="ifpTUYInfo" runat="server" Kentta="TUYInfo"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTUYInfo" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox></td>
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

</asp:Content>
