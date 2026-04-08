<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Kirjautuminen.aspx.vb" Inherits="appSopimusrekisteri.Kirjautuminen" Theme="Default" StylesheetTheme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" >
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title></title>
</head>
<body class="plain">
  <form id="form1" runat="server">
    <div class="centeredBox">
      <h1>Kirjaudu</h1>
      <div class="form">
        <div class="formValidationInfo">
          <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>

        <div class="formInfo">
        </div>
        <asp:Login ID="Login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
          <LayoutTemplate>
            <table class="form">
              <tr>
                <td class="formHeader">Käyttäjätunnus</td>
                <td class="formValidation">
                  <asp:RequiredFieldValidator ID="ReqValUsername" runat="server" ControlToValidate="Password" ErrorMessage="Käyttäjätunnus ei voi olla tyhjä"></asp:RequiredFieldValidator>
                </td>
                <td class="formInputElement">
                  <asp:TextBox ID="UserName" runat="server" MaxLength="100"></asp:TextBox></td>
              </tr>
              <tr>
                <td class="formHeader">Salasana</td>
                <td class="formValidation">
                  <asp:RequiredFieldValidator ID="ReqValPassword" runat="server" ControlToValidate="Password" ErrorMessage="Salasana ei voi olla tyhjä"></asp:RequiredFieldValidator>
                </td>
                <td class="formInputElement">
                  <asp:TextBox ID="Password" runat="server" MaxLength="100" TextMode="Password"></asp:TextBox>
                </td>
                <tr>
                  <td colspan="2">&nbsp;</td>
                  <td class="formActions">
                    <asp:Button ID="Login" runat="server" CommandName="Login" Text="Kirjaudu sisään" />
                  </td>
                </tr>
            </table>

          </LayoutTemplate>
        </asp:Login>
      </div>
    </div>
  </form>
</body>
</html>
