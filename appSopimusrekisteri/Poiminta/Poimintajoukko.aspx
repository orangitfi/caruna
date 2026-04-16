<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Poimintajoukko.aspx.vb" Inherits="appSopimusrekisteri.Poimintajoukko" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
    <h1>POIMINTA</h1>
  </div>
  <div class="info">
    <asp:Label ID="lblPoimintaehdotNaytolle" runat="server" Visible="False"></asp:Label>
  </div>
  <div class="bar">
    <div class="barText">
      <asp:Label ID="lblInfo" runat="server"></asp:Label>
    </div>
    <div class="barAction">
      <%--      <asp:HyperLink ID="hlEmail" runat="server" NavigateUrl="email_luo_sahkoposti.aspx" Visible="False">Lähetä sähköpostia</asp:HyperLink>
      <asp:HyperLink ID="hlTekstiviesti" runat="server" NavigateUrl="~/Lisaosat/SMS/SMSLahetys.aspx" Visible="False">Lähetä tekstiviestejä</asp:HyperLink>--%>
      <%--      <asp:HyperLink ID="hlTarrat" runat="server" Target="_blank" Visible="False">Tarratiedosto</asp:HyperLink>--%>
      <asp:HyperLink ID="hlExcel" runat="server" Target="_blank" Visible="False">Lataa Excel-tiedosto</asp:HyperLink>
    </div>
  </div>
  <div class="headerBarWhite">
    <asp:Button ID="btnUusiPoiminta" runat="server" Text="Uusi poiminta" />
    <asp:Button ID="btnLisaaPoimintaan" runat="server" Text="Lisää poimintaan" Visible="False" />
    <asp:Button ID="btnPoistaPoiminnasta" runat="server" Text="Poista poiminnasta" Visible="False" />
    <asp:Button ID="btnNollaa" runat="server" Text="Nollaa poiminta" Visible="False" />
    <%--    <asp:Button ID="btnPoista" runat="server" Visible="false" Text="Poista valitut" />--%>
  </div>
  <asp:PlaceHolder ID="phSopimukset" runat="server">
    <div class="list">
      <asp:GridView ID="gvPoimitutSopimukset" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="true" PageSize="100"
        Visible="False">
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
      </asp:GridView>
      <table class="listGridview" cellspacing="0" cellpadding="0">
        <asp:ListView ID="lvPoimintaSopimukset" runat="server" Visible="False" DataKeyNames="Id">
          <LayoutTemplate>
            <tr class="listGridviewHeader">
              <th><asp:LinkButton ID="lbJarjestaSopimusNimi" runat="server" OnClick="lbJarjestaSopimusNimi_Click">Nimi</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaSopimusTyyppi" runat="server" OnClick="lbJarjestaSopimusTyyppi_Click">Sopimustyyppi</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaSopimusVuosi" runat="server" OnClick="lbJarjestaSopimusVuosi_Click">Sopimusvuosi</asp:LinkButton>
              </th>
            </tr>
            <tr runat="server" id="itemPlaceHolder" />
          </LayoutTemplate>
          <ItemTemplate>
            <tr class="listGridviewItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("Sopimustyyppi")%>
              </td>
              <td>
                <%# Eval("Sopimusvuosi")%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="listGridviewAlternatingItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("Sopimustyyppi")%>
              </td>
              <td>
                <%# Eval("Sopimusvuosi")%>
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:ListView>
      </table>
    </div>
    <div class="footerBar">
      <asp:DataPager ID="dpPoimintaSopimukset" runat="server" PagedControlID="lvPoimintaSopimukset" PageSize="100"
        Visible="False">
        <Fields>
          <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" LastPageText="" NextPageText=""
            PreviousPageText="&lt;" ShowFirstPageButton="True" ShowNextPageButton="False" />
          <asp:NumericPagerField NumericButtonCssClass="pieni" />
          <asp:NextPreviousPagerField FirstPageText="" LastPageText="&gt;&gt;" NextPageText="&gt;"
            PreviousPageText="" ShowLastPageButton="True" ShowPreviousPageButton="False" />
        </Fields>
      </asp:DataPager>
      &nbsp;<asp:Label ID="lblPageCountSopimukset" runat="server" Visible="False"></asp:Label>
    </div>
  </asp:PlaceHolder>
  <asp:PlaceHolder ID="phKiinteistot" runat="server">
    <div class="list">
      <asp:GridView ID="gvPoimitutKiinteistot" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="true" PageSize="100"
        Visible="False">
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
      </asp:GridView>
      <table class="listGridview" cellspacing="0" cellpadding="0">
        <asp:ListView ID="lvPoimintaKiinteistot" runat="server" Visible="False" DataKeyNames="Id">
          <LayoutTemplate>
            <tr class="listGridviewHeader">
              <th><asp:LinkButton ID="lbJarjestaKiinteistoNimi" runat="server" OnClick="lbJarjestaKiinteistoNimi_Click">Nimi</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaKiinteistoTunnus" runat="server" OnClick="lbJarjestaKiinteistoTunnus_Click">Kiinteistötunnus</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaKiinteistoOsoite" runat="server" OnClick="lbJarjestaKiinteistoOsoite_Click">Osoite</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaKiinteistoPostinumero" runat="server" OnClick="lbJarjestaKiinteistoPostinumero_Click">Postinumero</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaKiinteistoPostitoimipaikka" runat="server" OnClick="lbJarjestaKiinteistoPostitoimipaikka_Click">Postitoimipaikka</asp:LinkButton>
              </th>
            </tr>
            <tr runat="server" id="itemPlaceHolder" />
          </LayoutTemplate>
          <ItemTemplate>
            <tr class="listGridviewItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("LyhytKiinteistotunnus")%>
              </td>
              <td>
                <%# Eval("Osoite")%>
              </td>
              <td>
                <%# Eval("Postinumero")%>
              </td>
              <td>
                <%# Eval("Postitoimipaikka")%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="listGridviewAlternatingItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("LyhytKiinteistotunnus")%>
              </td>
              <td>
                <%# Eval("Osoite")%>
              </td>
              <td>
                <%# Eval("Postinumero")%>
              </td>
              <td>
                <%# Eval("Postitoimipaikka")%>
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:ListView>
      </table>
    </div>
    <div class="footerBar">
      <asp:DataPager ID="dpPoimintaKiinteistot" runat="server" PagedControlID="lvPoimintaKiinteistot" PageSize="100"
        Visible="False">
        <Fields>
          <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" LastPageText="" NextPageText=""
            PreviousPageText="&lt;" ShowFirstPageButton="True" ShowNextPageButton="False" />
          <asp:NumericPagerField NumericButtonCssClass="pieni" />
          <asp:NextPreviousPagerField FirstPageText="" LastPageText="&gt;&gt;" NextPageText="&gt;"
            PreviousPageText="" ShowLastPageButton="True" ShowPreviousPageButton="False" />
        </Fields>
      </asp:DataPager>
      &nbsp;<asp:Label ID="lblPageCountKiinteistot" runat="server" Visible="False"></asp:Label>
    </div>
  </asp:PlaceHolder>
  <asp:PlaceHolder ID="phTahot" runat="server">
    <div class="list">
      <asp:GridView ID="gvPoimitutTahot" runat="server" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="true" PageSize="100"
        Visible="False">
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
      </asp:GridView>
      <table class="listGridview" cellspacing="0" cellpadding="0">
        <asp:ListView ID="lvPoimintaTahot" runat="server" Visible="False" DataKeyNames="Id">
          <LayoutTemplate>
            <tr class="listGridviewHeader">
              <th><asp:LinkButton ID="lbJarjestaTahoNimi" runat="server" OnClick="lbJarjestaTahoNimi_Click">Nimi</asp:LinkButton>
              </th>
              <th><asp:LinkButton ID="lbJarjestaTahoTyyppi" runat="server" OnClick="lbJarjestaTahoTyyppi_Click">Tyyppi</asp:LinkButton></th>
              <th><asp:LinkButton ID="lbJarjestaTahoOsoite" runat="server" OnClick="lbJarjestaTahoOsoite_Click">Osoite</asp:LinkButton></th>
              <th><asp:LinkButton ID="lbJarjestaTahoPostinumero" runat="server" OnClick="lbJarjestaTahoPostinumero_Click">Postinumero</asp:LinkButton></th>
              <th><asp:LinkButton ID="lbJarjestaTahoPostitoimipaikka" runat="server" OnClick="lbJarjestaTahoPostitoimipaikka_Click">Postitoimipaikka</asp:LinkButton></th>
            </tr>
            <tr runat="server" id="itemPlaceHolder" />
          </LayoutTemplate>
          <ItemTemplate>
            <tr class="listGridviewItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("Tyyppi")%>
              </td>
              <td>
                <%# Eval("Osoite")%>
              </td>
              <td>
                <%# Eval("Postinumero")%>
              </td>
              <td>
                <%# Eval("Postitoimipaikka")%>
              </td>
            </tr>
          </ItemTemplate>
          <AlternatingItemTemplate>
            <tr class="listGridviewAlternatingItem">
              <td>
                <asp:HyperLink ID="hlLinkki" runat="server"></asp:HyperLink>
              </td>
              <td>
                <%# Eval("Tyyppi")%>
              </td>
              <td>
                <%# Eval("Osoite")%>
              </td>
              <td>
                <%# Eval("Postinumero")%>
              </td>
              <td>
                <%# Eval("Postitoimipaikka")%>
              </td>
            </tr>
          </AlternatingItemTemplate>
        </asp:ListView>
      </table>
    </div>
    <div class="footerBar">
      <asp:DataPager ID="dpPoimintaTahot" runat="server" PagedControlID="lvPoimintaTahot" PageSize="100"
        Visible="False">
        <Fields>
          <asp:NextPreviousPagerField FirstPageText="&lt;&lt;" LastPageText="" NextPageText=""
            PreviousPageText="&lt;" ShowFirstPageButton="True" ShowNextPageButton="False" />
          <asp:NumericPagerField NumericButtonCssClass="pieni" />
          <asp:NextPreviousPagerField FirstPageText="" LastPageText="&gt;&gt;" NextPageText="&gt;"
            PreviousPageText="" ShowLastPageButton="True" ShowPreviousPageButton="False" />
        </Fields>
      </asp:DataPager>
      &nbsp;<asp:Label ID="lblPageCountTahot" runat="server" Visible="False"></asp:Label>
    </div>
  </asp:PlaceHolder>
</asp:Content>
