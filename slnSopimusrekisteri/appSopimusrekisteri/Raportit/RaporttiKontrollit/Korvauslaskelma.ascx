<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="Korvauslaskelma.ascx.vb" Inherits="appSopimusrekisteri.RaporttiKontrollit.Korvauslaskelma" %>

<%@ Register Assembly="appSopimusrekisteri" Namespace="appSopimusrekisteri.GeneralControls" TagPrefix="uc" %>

<table class="form" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td class="formHeader">Korvaustyyppi</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="KorvaustyyppiId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Status</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="StatusId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Maksun suoritus</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="MaksunSuoritusId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Sopimusnumero</td>
        <asp:CompareValidator ID="comValSopimusnumero" runat="server" ControlToValidate="Sopimusnumero" ErrorMessage="Anna sopimusnumero numerona" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:TextBox ID="Sopimusnumero" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Viite</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:TextBox ID="Viite" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Projektinumero</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:TextBox ID="Projektinumero" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Ensimmäinen sallittu maksupäivä</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <uc:DateInput ID="EnsimmainenSallittuMaksupaivaAlku" runat="server"></uc:DateInput>
        -
        <uc:DateInput ID="EnsimmainenSallittuMaksupaivaLoppu" runat="server"></uc:DateInput>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Kirjanpidon tili</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:TextBox ID="KirjanpidonTili" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Kirjanpidon kustannuspaikka</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:TextBox id="KirjanpidonKustannuspaikka" runat="server"></asp:TextBox>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Inv/Cost</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="InvCostId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Regulation</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="RegulationId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Purpose</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="PurposeId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Local1</td>
      <td class="formValidation">
      </td>
      <td class="formInputElement">
        <asp:DropDownList ID="Local1Id" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
  </tbody>
</table>

<div id="reportContainer" runat="server" visible="false">
  <table class="listGridview" cellpadding="3" cellspacing="0">
    <thead>
      <tr>
        <th>Korvauslaskelmatunnus</th>
        <th>Sopimusnumero</th>
        <th>Asiakas</th>
        <th>Veroton summa</th>
        <th>Alv</th>
        <th>Verollinen summa</th>
        <th>Maksun suoritus</th>
        <th>Korvaustyyppi</th>
        <th>Projektinumero</th>
        <th>Tila</th>
        <th>Kirjanpidon tili</th>
        <th>Kirjanpidon kustannuspaikka</th>
        <th>Inv/Cost</th>
        <th>Regulation</th>
        <th>Purpose</th>
        <th>Local1</th>
      </tr>
    </thead>
    <tbody>
      <asp:ListView ID="lstReport" runat="server">
        <ItemTemplate>
          <tr>
            <td><a href="../Korvauslaskelma/Tiedot.aspx?id=<%#DataBinder.Eval(Container.DataItem, "Tunnus") %>&sopimusId=<%#DataBinder.Eval(Container.DataItem, "Sopimusnumero") %>"><%#DataBinder.Eval(Container.DataItem, "Tunnus") %></a></td>
            <td><a href="../Sopimus/Sopimus.ashx?id=<%#DataBinder.Eval(Container.DataItem, "Sopimusnumero") %>"><%#DataBinder.Eval(Container.DataItem, "Sopimusnumero") %></a></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Asiakas") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "VerotonSumma", "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Alv") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "VerollinenSumma", "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "MaksunSuoritus") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Korvaustyyppi") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Projektinumero") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Tila") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "KirjanpidonTili") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "KirjanpidonKustannuspaikka") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "InvCost") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Regulation") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Purpose") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, "Local1") %></td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
    </tbody>
  </table>
</div>
