<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Haku.aspx.vb" Inherits="appSopimusrekisteri.Sopimushaku" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" TyhjaaSessionHakuehto="true" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <h1>LAAJENNETTU HAKU</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
      <%--<asp:BoundField DataField="Vuosi" HeaderText="Vuosi" ItemStyle-VerticalAlign="Top" />--%>
    </div>
    <div class="formDateInfo">
      <%--<asp:BoundField DataField="KiinteistönKunta" HeaderText="Kiinteistön kunta" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="KiinteistonKyla" HeaderText="Kiinteistön kylä" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Asiakkaat" HeaderText="Sopimuksen asiakkaat" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="PGTunnus" HeaderText="PG-tunnus" ItemStyle-VerticalAlign="Top" />--%>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Sopimuksen numero
        </td>
        <td class="formValidation">
          <asp:CompareValidator ID="ComValSopimusnumero" runat="server" ErrorMessage="Syötä sopimuksen numero numeerisessa muodossa" ControlToValidate="txtSopimusnumero" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSopimusnumero" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Sopimuksen muu tunniste
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSopimusTunniste" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Sopimuksen vuosi
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSopimusvuosi" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <%--<asp:BoundField DataField="Lisatieto" HeaderText="Lisätieto" ItemStyle-VerticalAlign="Top" />--%>
      <tr>
        <td class="formHeader">Kiinteistön osoite</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtOsoite" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kiinteistön kylä</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKyla" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kiinteistön kunta</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKunta" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kiinteistön omistajan nimi</td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtOmistajanNimi" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>

      <tr>
        <td class="formHeader">Sopimukseen liittyvät asiakkaat (nimi)
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtAsiakkaanNimi" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>

      <tr>
        <td class="formHeader">NIS-tunnus
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtPGTunnus" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>


      <tr>
        <td class="formHeader">Projektinumero
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSOPPCSNumero" CssClass="textboxDefault" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>

      <tr>
        <td class="formHeader">Projektivalvoja
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtProjektivalvoja" CssClass="textboxDefault" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>


      <tr>
        <td class="formHeader">Lisätieto
        </td>
        <td class="formValidation">&nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtLisatieto" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;
        </td>
        <td class="formActions">
          <asp:Button ID="btnHaku" runat="server" Text="Hae" />
        </td>
      </tr>
    </table>
  </div>
  <div class="list">
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" PageSize="20">
      <Columns>
        <asp:TemplateField HeaderText="Tunniste" SortExpression="SOPId" ItemStyle-VerticalAlign="Top">
          <ItemTemplate>
            <asp:HyperLink ID="hlValitse" Text='<%# Bind("ID") %>' runat="server"></asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Sopimustyyppi" SortExpression="SOPTyyppi" HeaderText="Sopimustyyppi" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="KiinteistonRekisterinumero" HeaderText="Kiinteistön rekisterinumero" ItemStyle-VerticalAlign="Top" HtmlEncode="false" />
        <asp:BoundField DataField="KiinteistonTunnusLyhyt" HeaderText="Kiinteistön tunnus" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="KiinteistonKunta" HeaderText="Kiinteistön kunta" ItemStyle-VerticalAlign="Top" />
        <%--<asp:BoundField DataField="MuuTunniste" HeaderText="Muu tunniste" ItemStyle-VerticalAlign="Top" />--%>
        <%--<asp:BoundField DataField="Vuosi" HeaderText="Vuosi" ItemStyle-VerticalAlign="Top" />--%>
        <%--<asp:BoundField DataField="KiinteistönKunta" HeaderText="Kiinteistön kunta" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="KiinteistonKyla" HeaderText="Kiinteistön kylä" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Asiakkaat" HeaderText="Sopimuksen asiakkaat" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="PGTunnus" HeaderText="PG-tunnus" ItemStyle-VerticalAlign="Top" />--%>
        <%--<asp:BoundField DataField="Lisatieto" HeaderText="Lisätieto" ItemStyle-VerticalAlign="Top" />--%>
        <%--<asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:HyperLink ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>--%>
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnLisaaSopimus" runat="server" Text="Lisää uusi sopimus" Visible="false" />
    <div class="footerBarInfo">
      <asp:Label ID="lblLukumaara" runat="server"></asp:Label>
    </div>
  </div>

</asp:Content>
