<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.Muokkaa1" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <asp:HiddenField ID="hdnId" runat="server" />
  <h1>Indeksi</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
      <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblPaivittaja" runat="server"></asp:Label>)
            <br />
      <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblLuoja" runat="server"></asp:Label>)
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Tyyppi</td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ID="ReqValIndeksityyppiId" runat="server" ErrorMessage="Tyyppi on pakollinen tieto" ControlToValidate="ddIndeksityyppiId" InitialValue="-1"></asp:RequiredFieldValidator>
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddIndeksityyppiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Vuosi</td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ID="ReqValVuosi" runat="server" ErrorMessage="Vuosi on pakollinen tieto" ControlToValidate="txtVuosi"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="ComValVuosi" runat="server" ErrorMessage="Vuosi: syötä numeerisessa muodossa" ControlToValidate="txtVuosi" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtVuosi" runat="server" SkinID="Short"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kuukausi</td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ID="ReqValKuukausi" runat="server" ErrorMessage="Kuukausi on pakollinen tieto" ControlToValidate="ddKuukausiId" InitialValue="-1"></asp:RequiredFieldValidator>
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddKuukausiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Arvo</td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ID="ReqValArvo" runat="server" ErrorMessage="Arvo on pakollinen tieto" ControlToValidate="txtArvo"></asp:RequiredFieldValidator>
          <asp:CompareValidator ID="ComValArvo" runat="server" ErrorMessage="Arvo: syötä numeerisessa muodossa" ControlToValidate="txtArvo" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtArvo" runat="server" SkinID="Short"></asp:TextBox>
        </td>
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
