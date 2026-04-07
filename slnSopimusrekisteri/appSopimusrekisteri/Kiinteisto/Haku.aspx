<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Haku.aspx.vb" Inherits="appSopimusrekisteri.Kiinteistohaku" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
        <td class="formHeader">Kiinteistön nimi</td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKiinteisto" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
<%--      <tr>
        <td class="formHeader">
          Katuosoite
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKatuosoite" CssClass="textboxDefault" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Postitoimipaikka
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIPostitoimipaikka" CssClass="textboxDefault" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Postinumero
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIPostinumero" CssClass="textboxDefault" runat="server" MaxLength="5"></asp:TextBox>
        </td>
      </tr>--%>
        <tr>
            <td class="formHeader">Kunta
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtKIIKunta" CssClass="textboxDefault" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formHeader">Kylä
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtKIIKyla" CssClass="textboxDefault" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formHeader">Rekisterinumero
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtKIIRekisterinumero" CssClass="textboxDefault" runat="server" MaxLength="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="formHeader">Kiinteistötunnus, lyhyt
            </td>
            <td class="formValidation">&nbsp;
            </td>
            <td class="formInputElement">
                <asp:TextBox ID="txtKIIKiinteistotunnusLyhyt" CssClass="textboxDefault" runat="server" MaxLength="50"></asp:TextBox>
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
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" AllowSorting="true">
      <Columns>
        <asp:HyperLinkField  DataNavigateUrlFields="Id" DataTextField="Id" SortExpression="KIIId" HeaderText="Tunniste" DataNavigateUrlFormatString="~/Kiinteisto/Tiedot.aspx?id={0}" />
        <asp:BoundField DataField="Nimi" SortExpression="KIIKiinteisto" HeaderText="Nimi" ItemStyle-VerticalAlign="Top" />
        <%--<asp:BoundField DataField="Kyla" HeaderText="Kylä" ItemStyle-VerticalAlign="Top" />--%>
        <asp:BoundField DataField="Rekisterinumero" SortExpression="KIIRekisterinumero" HeaderText="Rekisterinumero" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Kunta" SortExpression="hlp_Kunta.KKunta" HeaderText="Kunta" ItemStyle-VerticalAlign="Top" />
        <%--<asp:BoundField DataField="LyhytKiinteistotunnus" HeaderText="Kiinteistötunnus, lyhyt" ItemStyle-VerticalAlign="Top"  ItemStyle-Width="150" />--%>
        <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ControlStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:HyperLink ID="hlValitseSopimukselle" Text="Valitse sopimukselle" runat="server" Visible="false"></asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnLisaaKiinteisto" runat="server" Text="Lisää uusi kiinteistö" Visible="false" />
    <div class="footerBarInfo">
      <asp:Label ID="lblLukumaara" runat="server"></asp:Label>
    </div>
  </div>


</asp:Content>
