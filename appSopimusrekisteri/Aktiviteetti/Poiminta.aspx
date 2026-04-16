<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Poiminta.aspx.vb" Inherits="appSopimusrekisteri.Poiminta" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <div class="headerBar">
    <h1>Aktiviteettihaku</h1>
  </div>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Tunnus
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTunnus" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Keneen aktiviteetti kohdistuu
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKTahoId" runat="server"></asp:TextBox> <asp:Button ID="btnTahoFiltteri" runat="server" Text="Hae" OnClick="btnTahoFiltteri_Click" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKTahoId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Sopimus
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKSopimusId" runat="server"></asp:TextBox> <asp:Button ID="btnSopimusFiltteri" runat="server" Text="Hae" onclick="btnSopimusFiltteri_Click"/>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKSopimusId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kontaktoija
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKKontaktoijaId" runat="server" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Toimenpide
        </td>
        <td class="formValidation">
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
        <td class="formHeader">Päivämäärä välillä
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtAKPaivamaaraAlku" ID="comAKPaivamaaraAlku" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin alkupäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          <asp:CompareValidator Display="None" ControlToValidate="txtAKPaivamaaraLoppu" ID="comAKPaivamaaraLoppu" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin loppupäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKPaivamaaraAlku" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKPaivamaaraAlku" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKPaivamaaraAlku" runat="server" TargetControlID="txtAKPaivamaaraAlku" PopupButtonID="imgAKPaivamaaraAlku" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          <asp:TextBox ID="txtAKPaivamaaraLoppu" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKPaivamaaraLoppu" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKPaivamaaraLoppu" runat="server" TargetControlID="txtAKPaivamaaraLoppu" PopupButtonID="imgAKPaivamaaraLoppu" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Jatkopäivämäärä välillä
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtAKSeuraavaYhteyspaivaAlku" ID="comAKSeuraavaYhteyspaivaAlku" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin jatkopäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
          <asp:CompareValidator Display="None" ControlToValidate="txtAKSeuraavaYhteyspaivaLoppu" ID="comAKSeuraavaYhteyspaivaLoppu" Type="Date" Operator="DataTypeCheck" runat="server" ErrorMessage="Aktiviteetin jatkopäivämäärä: anna muodossa pp.kk.vvvv"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAKSeuraavaYhteyspaivaAlku" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKSeuraavaYhteyspaivaAlku" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKSeuraavaYhteyspaivaAlku" runat="server" TargetControlID="txtAKSeuraavaYhteyspaivaAlku" PopupButtonID="imgAKSeuraavaYhteyspaivaAlku" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
          <asp:TextBox ID="txtAKSeuraavaYhteyspaivaLoppu" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgAKSeuraavaYhteyspaivaLoppu" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="calAKSeuraavaYhteyspaivaLoppu" runat="server" TargetControlID="txtAKSeuraavaYhteyspaivaLoppu" PopupButtonID="imgAKSeuraavaYhteyspaivaLoppu" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Status
        </td>
        <td class="formValidation">
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddAKStatusId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btnHae" runat="server" Text="Hae" OnClick="btnHae_Click" />
        </td>
      </tr>
    </table>
  </div>
  <asp:GridView ID="gvAktiviteetit" runat="server" AutoGenerateColumns="False">
    <Columns>
      <asp:TemplateField HeaderText="Tunnus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlValitse" Text='<%# Bind("ID") %>' runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Päivämäärä" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Label ID="lblPaivamaara" runat="server"></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Hyperlink ID="hlSopimus" runat="server"></asp:Hyperlink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Keneen otetaan yhteyttä" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Hyperlink ID="hlTaho" runat="server"></asp:Hyperlink>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Kontaktoija" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Label ID="lblKontaktoija" runat="server"></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Yhteydenottotapa" HeaderText="Toimenpide" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-VerticalAlign="Top" />
      <asp:BoundField DataField="Laji" HeaderText="Laji" ItemStyle-VerticalAlign="Top" />
      <asp:TemplateField HeaderText="Jatkopäivämäärä" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:Label ID="lblJatkopaivamaara" runat="server"></asp:Label>
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
        <ItemTemplate>
          <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>

</asp:Content>
