<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sopimusarkisto.aspx.vb" Inherits="appSopimusrekisteri.Sopimusarkisto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="btnListat" runat="server" Text="Hae listat" />
      <br />
      <br />
      <asp:Literal ID="litListat" runat="server"></asp:Literal>
      <br />
      <br />
      <asp:Button ID="btnNakymat" runat="server" Text="Hae näkymät" />
&nbsp;<asp:TextBox ID="txtNakymatListaId" runat="server"></asp:TextBox>
      <br />
      <asp:Button ID="btnNakymatHeratys" runat="server" Text="Hae näkymät herätyksellä" />
      <br />
      <br />
      <asp:Literal ID="litNakymat" runat="server"></asp:Literal>
      <br />
      <br />
      <asp:Button ID="btnListanKentat" runat="server" Text="Hae listan kentät" />
&nbsp;<asp:TextBox ID="txtKentatListaId" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="txtKentatNakymaId" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Literal ID="litListanKentat" runat="server"></asp:Literal>
      <br />
      <br />
      <asp:Button ID="btnHaeSopimus" runat="server" Text="Hae sopimus" />
&nbsp;<asp:TextBox ID="txtSopimustunnus" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Label ID="lblSopimus" runat="server"></asp:Label>
      <br />
      <br />
      <asp:Button ID="btnPaivitaSopimus" runat="server" Text="Päivitä sopimus" />
      <br />
      <br />
      <asp:TextBox ID="txtPaivitysId" runat="server"></asp:TextBox>
      <br />
      <asp:TextBox ID="txtPaivitysLisatieto" runat="server"></asp:TextBox>
      <br />
      <asp:TextBox ID="txtPaivitysLisatieto2" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Label ID="lblPaivitysSopimus" runat="server"></asp:Label>
      <br />
      <br />
      <asp:Button ID="btnHaeKaikkiTiedot" runat="server" Text="Hae kaikki tiedot" />
&nbsp;<asp:TextBox ID="txtKaikkiTiedotSopimustunnus" runat="server"></asp:TextBox>
      <br />
      <br />
      <asp:Literal ID="litKaikkiTiedot" runat="server"></asp:Literal>
      <br />
      <br />
      <asp:Button ID="btnPaivitaSopimusarkisto" runat="server" Text="Päivitä sopimusarkisto" />
      <br />
      <br />
      <asp:Button ID="btnHerata" runat="server" Text="Herätä" />
    </div>
    </form>
</body>
</html>
