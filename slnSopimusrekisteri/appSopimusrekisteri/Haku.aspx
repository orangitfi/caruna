<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Haku.aspx.vb" Inherits="appSopimusrekisteri.Haku" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">        
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
 
     <h1>
    TARKENNETTU HAKU</h1>
  <div class="form">
    <table class="form">
      <tr>
        <td class="formHeader">
          Jäsennumero, nimi tai nimen osa
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtNimi" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          Puhelinnumero
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtPuhelinnumero" CssClass="textboxDefault" runat="server"></asp:TextBox>
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
          <asp:TextBox ID="txtPostinumero" CssClass="textboxDefault" runat="server"></asp:TextBox>
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
          <asp:TextBox ID="txtPostitoimipaikka" CssClass="textboxDefault" runat="server"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          &nbsp;
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInnerTable">
          <table>
            <tr>
              <td>
                <asp:RadioButton ID="rbKaikki" GroupName="TahoTyyppi" runat="server" Text="Kaikki"
                  Checked="True" />
              </td>
              <td>
                <asp:RadioButton ID="rbOrganisaatio" GroupName="TahoTyyppi" runat="server"
                  Text="Vain organisaatiot" />
              </td>
              <td>
                <asp:RadioButton ID="rbjasenyhdistys" GroupName="TahoTyyppi" runat="server" Text="Vain jäsenyhdistykset" />
              </td>
            </tr>
            <tr>
              <td>
                <asp:RadioButton ID="rbHenkilot" GroupName="TahoTyyppi" runat="server" Text="Vain henkilöt" />
              </td>
              <td>
                <asp:RadioButton ID="rbLehtitilaajat" GroupName="TahoTyyppi" runat="server" Text="Lehtitilaajat" />
              </td>
              <td>
                &nbsp;
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td class="formHeader">
          &nbsp;
        </td>
        <td class="formValidation">
          &nbsp;
        </td>
        <td class="formInputElement">
          <asp:CheckBox ID="chkPassiiviset" runat="server" Text="Hae myös passiiviset" />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          &nbsp;
        </td>
        <td class="formActions">
          <asp:Button ID="btnHaku" runat="server" Text="Hae" />
        </td>
      </tr>
    </table>
  </div>
  <div class="list">
    <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False">
      <Columns>
        <asp:TemplateField HeaderText="Nimi" ItemStyle-VerticalAlign="Top">
          <ItemTemplate>
            <asp:HyperLink ID="hlTaho" runat="server"></asp:HyperLink>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Puhelin" HeaderText="Puhelin" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Katuosoite" HeaderText="Katuosoite" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Postinumero" HeaderText="Postinumero" ItemStyle-VerticalAlign="Top" />
        <asp:BoundField DataField="Postitoimipaikka" HeaderText="Postitoimipaikka" ItemStyle-VerticalAlign="Top" />
        <asp:HyperLinkField DataNavigateUrlFields="TAHTahoId" DataNavigateUrlFormatString="TarkennettuHaku.aspx?action=poimi&amp;id={0}"
          Text="Poimi" Visible="false" />
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button ID="btnLisaaHenkilo" runat="server" Text="Lisää uusi henkilö" Visible="false" />
    <asp:Button ID="btnLisaaOrganisaatio" runat="server" Text="Lisää uusi organisaatio" Visible="false" />
    <asp:Button ID="btnLisaaKaikkiPoimintaan" runat="server" Text="Lisää kaikki poimintaan" Visible="false" />
    <div class="footerBarInfo">
      <asp:Label ID="lblLukumaara" runat="server"></asp:Label></div>
  </div>

</asp:Content>
