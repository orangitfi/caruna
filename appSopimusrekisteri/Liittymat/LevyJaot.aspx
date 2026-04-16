<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LevyJaot.aspx.vb" Inherits="appSopimusrekisteri.LevyJaot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:TextBox ID="txtLahde" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="txtKohde" runat="server"></asp:TextBox>
      <br />
      <asp:Button ID="btnKopioi" runat="server" Text="Kopioi" />
      <br />
      <br />
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
  </form>
</body>
</html>
