<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Poimintaehdot_Tallenna_Lataa.aspx.vb" Inherits="appSopimusrekisteri.Poimintaehdot_Tallenna_Lataa" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/PoimintaTyokalut.ascx" TagName="PoimintaTyokalut" TagPrefix="uc3" %>
<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc3:PoimintaTyokalut ID="PoimintaTyokalut1" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div class="bar barExtensionGray">
    <h1>POIMINTAEHTOJEN TALLENNUS JA LATAUS</h1>
  </div>
  <div class="formValidationInfo">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="tallenna" />
    <br />
  </div>
  <div>
    <asp:Label runat="server" ID="lblEhdot"></asp:Label>
  </div>
  <div class="headerBarWhite">
    <table>
      <tr>
        <td class="formHeader">
          <asp:Button ID="btnTallenna" Text="Tallenna nykyiset poimintaehdot" runat="server" ValidationGroup="tallenna" visible="False"/>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator ControlToValidate="txtNimi" ID="RequiredFieldValidator1" ErrorMessage="Anna nimi tallennettaville ehdoille" ValidationGroup="tallenna" runat="server" Visible="False"></asp:RequiredFieldValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtNimi" runat="server" MaxLength="50" Visible="False"></asp:TextBox>
        </td>
      </tr>
    </table>
  </div>
  <div class="bar">
    <div class="barText">
      <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </div>
    <div class="barAction">
    </div>
  </div>
  <div class="list">
    <table class="listGridview" cellspacing="0" cellpadding="0">
      <asp:GridView ID="lvTallennetutEhdot" runat="server" DataKeyNames="TPEId" AutoGenerateColumns="false">
        <Columns>
          <asp:BoundField DataField="TPENimi" />
          <asp:TemplateField>
            <ItemTemplate>
              <asp:Button ID="btnPoimi" Text="Tee poiminta" CommandName="poimi" CommandArgument='<%#Eval("TPEId")%>' runat="server"></asp:Button>
              <asp:Button ID="btnPoista" Text="Poista" CommandName="poista" CommandArgument='<%#Eval("TPEId")%>' runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa nämä poimintaehdot?');"></asp:Button>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </table>
  </div>
</asp:Content>
