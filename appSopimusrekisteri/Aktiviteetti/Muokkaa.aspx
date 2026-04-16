<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.AktiviteetinMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
  <asp:HiddenField ID="hdnAId" runat="server" />
  <asp:HiddenField ID="hdnSId" runat="server" />
  <h1>Aktiviteetin tiedot</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
      <asp:PlaceHolder ID="phYksiSopimus" runat="server" Visible="true">
        Sopimus: <asp:Label ID="lblAKSopimusId" runat="server" />
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="phMontaSopimusta" runat="server" Visible="false">
        <asp:Label ID="lblMontaSopimusta" runat="server"></asp:Label>
      </asp:PlaceHolder>
      <br />
      Tähdellä merkityt tiedot ovat pakollisia
    </div>
    <div class="formDateInfo">
      <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
        <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblAKPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblAKPaivittaja" runat="server"></asp:Label>)
            <br />
        <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblAKLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblAKLuoja" runat="server"></asp:Label>)
      </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Keneen aktiviteetti kohdistuu
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKTahoId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kontaktoija *
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKKontaktoijaId" runat="server" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Toimenpide *
        </td>
        <td class="formValidation">
          <asp:CustomValidator ID="custvalAKYhteystapaId" runat="server" OnServerValidate="custvalAKYhteystapaId_ServerValidate" ErrorMessage="Toimenpide on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKYhteystapaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Aktiviteetin laji
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKAktiviteetinLajiId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Päivämäärä *
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtAKPaivamaara" ID="comAKPaivamaara2" runat="server" ErrorMessage="Päivämäärä on vaadittu tieto" />
          <asp:CompareValidator Display="None" ControlToValidate="txtAKPaivamaara" ID="comAKPaivamaara" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin päivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKPaivamaara" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKPaivamaara" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKPaivamaara" runat="server" TargetControlID="txtAKPaivamaara" PopupButtonID="imgAKPaivamaara" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Jatkopäivämäärä
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtAKSeuraavaYhteyspaiva" ID="comAKSeuraavaYhteyspaiva" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin jatkopäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKSeuraavaYhteyspaiva" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKSeuraavaYhteyspaiva" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKSeuraavaYhteyspaiva" runat="server" TargetControlID="txtAKSeuraavaYhteyspaiva" PopupButtonID="imgAKSeuraavaYhteyspaiva" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kuvaus
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKKuvaus" Rows="3" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Status *
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="ddAKStatusId" ID="valAKStatusId" runat="server" ErrorMessage="Status on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKStatusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
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
