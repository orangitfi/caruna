<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Haku.aspx.vb" Inherits="appSopimusrekisteri.Tahohaku" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

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
        <div class="formValidationInfo"><asp:validationsummary ID="ValidationSummary1" runat="server" /></div>
    <div class="formInfo">
        
    </div>
    <div class="formDateInfo">
        
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Etunimi</td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHEtunimi" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sukunimi / Yrityksen nimi
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHSukunimi" runat="server"></asp:TextBox>
        </td>
      </tr>
    <%--  <tr>
        <td class="formHeader">
          Sähköposti
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHEmail" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>--%>
      <tr>
        <td class="formHeader">
          Asiakkaan tunniste
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtTAHTahoId" runat="server"></asp:TextBox>
        </td>
      </tr>
        <tr>
            <td class="formHeader">Asiakkaan osoite
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtTAHPostitusosoite" runat="server" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formHeader">Asiakkaan postinumero
            </td>
            <td class="formValidation">
                <asp:CompareValidator Display='None' ControlToValidate='txtTAHPostituspostinro' ID='cmpTAHPostituspostinro' Type='Integer' Operator='DataTypeCheck' runat='server' ErrorMessage='Postinumerossa saa olla vain numeroita'></asp:CompareValidator>
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtTAHPostituspostinro" runat="server" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formHeader">Asiakkaan postitoimipaikka
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtTAHPostituspostitmp" runat="server" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
      <%--<tr>
        <td class="formHeader">
          Kiinteistön osoite
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIOsoite" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Kiinteistön kylä
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKyla" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Kiinteistön kunta
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKunta" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>--%>
      <tr>
        <td class="formHeader">
          Sopimuksen tunniste
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSOPId" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Sopimuksen muu tunniste
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtSOPMuuTunnus" runat="server"></asp:TextBox>
        </td>
      </tr>

      <tr>
        <td colspan="2">
          &nbsp;
        </td>
        <td class="formActions">
          <asp:Button ID="btnHaku" runat="server" Text="Hae" />
          <asp:Button ID="btnPeruuta" runat="server" Text="Palaa edelliselle sivulle"/>
        </td>
      </tr>
    </table>
  </div>
  <div class="list">
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" PageSize="20">
      <Columns>
      
        <asp:BoundField DataField="Etunimi" SortExpression="Etunimi" HeaderText="Etunimi" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Sukunimi" SortExpression="Sukunimi" HeaderText="Sukunimi/Yritys" ItemStyle-VerticalAlign="Top" />
          <asp:HyperLinkField DataNavigateUrlFields="Id" SortExpression="ID" DataTextField="Id" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Taho/TYYPPI/Tiedot.aspx?id={0}" />
          <asp:BoundField DataField="Tyyppi" SortExpression="Tyyppi" HeaderText="Tyyppi" ItemStyle-VerticalAlign="Top" Visible="false" />
          <asp:BoundField DataField="Osoite" HeaderText="Osoite" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Postinumero" HeaderText="Postinumero" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" ItemStyle-VerticalAlign="Top" />
          <asp:BoundField DataField="SopimustenTunnisteet" HeaderText="Sopimuksen tunniste" ItemStyle-VerticalAlign="Top" HtmlEncode="false"/>
          <asp:BoundField DataField="SopimustenMuutTunnisteet" HeaderText="Sopimuksen muu tunniste" ItemStyle-VerticalAlign="Top" HtmlEncode="false" />
        <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:HyperLink ID="hlValitseKorvauslaskelmalle" Text="Valitse korvauslaskelmalle" runat="server" Visible="false"></asp:HyperLink>
            <asp:HyperLink ID="hlValitseKiinteistölle" Text="Valitse kiinteistölle" runat="server" Visible="false"></asp:HyperLink>
            <asp:HyperLink ID="hlValitseSopimukselle" Text="Valitse sopimukselle" runat="server" Visible="false"></asp:HyperLink>
            <%--<asp:HyperLink ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:HyperLink>--%>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnLisaaHenkilo" runat="server" Text="Lisää uusi henkilö" Visible="false" />
    <asp:Button ID="btnLisaaOrganisaatio" runat="server" Text="Lisää uusi organisaatio" Visible="false" />
    <div class="footerBarInfo">
      <asp:Label ID="lblLukumaara" runat="server"></asp:Label>
    </div>
  </div>

</asp:Content>
