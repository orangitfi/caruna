<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Lisaa.aspx.vb" Inherits="appSopimusrekisteri.Lisaa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
  <asp:HiddenField ID="hdnSopimusId" runat="server" />
  <asp:HiddenField ID="hdnKorvauslaskelmaId" runat="server" />
  <h1>Maksu</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
      Tähdellä merkityt tiedot ovat pakollisia
    </div>
    <div class="formDateInfo">
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Sopimus</td>
        <td class="formValidation">&nbsp;</td>
        <td class="formInputElement">
          <asp:Label ID="lblSopimus" runat="server"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Korvauslaskelma
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:Label ID="lblKorvauslaskelma" runat="server"></asp:Label>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Tila
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddMAKMaksuStatusId" runat="server" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maksupvm *
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtMAKMaksupaiva" ID="ReqValMAKMaksupaiva" runat="server" ErrorMessage="Maksupvm on pakollinen tieto" />
          <asp:CompareValidator Display="None" ControlToValidate="txtMAKMaksupaiva" ID="ComValMAKMaksupaiva" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Maksupvm: anna muodossa pp.kk.vvvv"></asp:CompareValidator>          
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtMAKMaksupaiva" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgMAKMaksupaiva" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calMAKMaksupaiva" runat="server" TargetControlID="txtMAKMaksupaiva" PopupButtonID="imgMAKMaksupaiva" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Summa *
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtMAKSumma" ID="ReqValMAKSumma" runat="server" ErrorMessage="Maksupvm on pakollinen tieto" />
          <asp:CompareValidator Display="None" ControlToValidate="txtMAKSumma" ID="ComValMAKSumma" Type="Currency" Operator="DataTypeCheck" runat="server" ErrorMessage="Maksupvm: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>          
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtMAKSumma" runat="server" SkinID="Numeric"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Lisätieto
        </td>
        <td class="formValidation">

        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtMAKInfo" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btnTallenna" runat="server" Text="Tallenna" />
          <asp:Button ID="btnPeruuta" runat="server" Text="Peruuta" CausesValidation="false" />
        </td>
      </tr>
    </table>
  </div>

</asp:Content>
