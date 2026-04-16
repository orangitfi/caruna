<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Poiminta_sarakkeet_kiinteisto.aspx.vb" Inherits="appSopimusrekisteri.Poiminta_sarakkeet_kiinteisto" MasterPageFile="~/Site.Master" StylesheetTheme="Default" Theme="Default" %>
<%@ Register Src="~/Controls/Poimintatyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <h1>
    POIMINNAN SARAKKEET KIINTEISTÖILLE</h1>
  <div class="form">
    <div class="formInfo">
      &nbsp;
    </div>
    <table class="form" cellspacing="0" cellpadding="0">
      <tr>
        <td class="formHeader">
          Sarake 1:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          Kiinteistön nimi
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 2:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake2" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 3:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake3" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 4:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake4" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 5:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake5" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 6:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake6" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 7:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake7" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 8:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake8" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 9:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake9" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 10:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake10" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 11:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake11" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 12:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake12" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 13:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake13" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 14:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake14" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 15:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake15" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 16:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake16" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 17:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake17" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 18:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake18" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 19:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake19" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sarake 20:
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddSarake20" runat="server"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          &nbsp;
        </td>
        <td class="formActions">
          <asp:Button ID="btnTallenna" runat="server" Text="Tallenna">
          </asp:Button>
          <asp:Button ID="btnPeruuta" runat="server" Text="Peruuta">
          </asp:Button>
        </td>
      </tr>
    </table>
  </div>
</asp:Content>
