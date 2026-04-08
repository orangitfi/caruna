<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sahkoposti.aspx.vb" Inherits="appSopimusrekisteri.Sahkoposti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      Viestin saaja
      <asp:TextBox ID="txtSaaja" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Button ID="btnLahetaTesti" runat="server" Text="Lähetä testiviesti" />
    </div>
  </form>
</body>
</html>
