<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tiedot.aspx.vb" Inherits="appSopimusrekisteri.Korvauslaskelma.Tiedot" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Haku ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div id="formData" runat="server">
    <!-- Yläosan tiedot -->
    <h3>
      <asp:Label ID="lblNimi" runat="server" Font-Bold="true"></asp:Label></h3>
    <div class="viewInfo">
      <table>
        <tr>
          <td class="viewInfoContentElement" style="vertical-align: top; padding-right: 70px;">
            <b>Korvauksen sopimus</b><br />
            <br />
            <asp:HyperLink ID="hlSopimus" runat="server">
            </asp:HyperLink><br />
            <br />
            <asp:Button ID="btLisaaKorvauksenSaaja" runat="server" Visible="false" Text="Lisää saaja korvaukselle"></asp:Button>
            <asp:Button ID="btPoistaKorvauksenSaaja" runat="server" Visible="false" Text="Poista korvauksen saaja" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa korvauksen saajan?');"></asp:Button>
          </td>
          <td class="viewInfoContentElement">
            <b>Korvauksen saaja</b><br />
            <br />
            <asp:Label ID="Saaja_Nimi" runat="server"></asp:Label><br />
            <asp:Label ID="Saaja_Postitusosoite" runat="server"></asp:Label><br />
            <asp:Label ID="Saaja_Postituspostinro" runat="server"></asp:Label>
            <asp:Label ID="Saaja_Postituspostitmp" runat="server"></asp:Label><br />
            <br />
            <asp:Label ID="Saaja_Email" runat="server"></asp:Label><br />
            <asp:Label ID="Saaja_Puhelin" runat="server"></asp:Label>
            <asp:Label ID="Saaja_Bic" runat="server"></asp:Label>
            <asp:Label ID="Saaja_Tilinumero" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td class="viewInfoContentElement"></td>
        </tr>
      </table>
      <div class="viewInfoClearElement"></div>
    </div>

    <div class="headerBar">
      <h1>Korvauslaskelma
      <asp:Label ID="Id" runat="server"></asp:Label></h1>
      <div class="headerBarActionImgLink">
        <asp:ImageButton ID="imgPrint" SkinID="PrintImage" AlternateText="Avaa tulostusnäkymä" runat="server" />
      </div>
    </div>
    <div class="view2columns">
      <table>
        <tr>
          <td class="view2columnsHeader1">Projektinumero</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Sopimus_PCSNumero" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Maksun suoritus</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="MaksunSuoritus_Nimi" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="view2columnsHeader1">Viesti</td>
          <td class="view2columnsContentElement1">
            <asp:Label ID="Viesti" runat="server"></asp:Label></td>
          <td class="view2columnsHeader2">Viite</td>
          <td class="view2columnsContentElement2">
            <asp:Label ID="Viite" runat="server"></asp:Label></td>
        </tr>
        <asp:PlaceHolder ID="phAlv" runat="server">
          <tr>
            <td class="view2columnsHeader1">Maksetaan alv</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="MaksetaanAlv" runat="server"></asp:Label>&nbsp;
              <asp:Label ID="lblAlv" runat="server"></asp:Label>
            </td>
            <td class="view2columnsHeader2"></td>
            <td class="view2columnsContentElement2"></td>
          </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
          <tr>
            <td class="view2columnsHeader1">Korvaustyyppi</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="Korvaustyyppi_Nimi" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Ensimmäinen sallittu maksupäivä</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="EnsimmainenSallittuMaksuPvm" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Korvauksen projektinumero</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="KorvauksenProjektinumero" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Korvauksen status</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="KorvauslaskelmaStatus_Nimi" runat="server"></asp:Label>&nbsp;<asp:Image ID="imgStatus" runat="server" SkinID="InfoImage" />
            </td>
          </tr>

          <tr>
            <td class="view2columnsHeader1">Maksukuukausi</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="MaksuKuukausi_Nimi" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Viimeinen maksuajankohta</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="ViimeinenMaksuPvm" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Sopimuskorvaus org.</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="MaksettavaKorvausAlkuperainen" runat="server"></asp:Label></td>

            <td class="view2columnsHeader2"></td>
            <td class="view2columnsContentElement2"></td>
          </tr>
          <asp:PlaceHolder ID="phLisaMaksutiedot" runat="server">
            <tr>
              <td class="view2columnsHeader1"></td>
              <td class="view2columnsContentElement1"></td>
              <td class="view2columnsHeader2">Maksuehdot</td>
              <td class="view2columnsContentElement2">
                <asp:Label ID="Maksuehdot_Nimi" runat="server"></asp:Label></td>
            </tr>
            <tr>
              <td class="view2columnsHeader1">Sopimuksella on indeksi</td>
              <td class="view2columnsContentElement1">
                <asp:Label ID="OnIndeksi" runat="server"></asp:Label></td>
              <td class="view2columnsHeader2">Indeksityyppi</td>
              <td class="view2columnsContentElement2">
                <asp:Label ID="Indeksityyppi_Nimi" runat="server"></asp:Label></td>
            </tr>
            <tr>
              <td class="view2columnsHeader1">Sopimuksen indeksivuosi</td>
              <td class="view2columnsContentElement1">
                <asp:Label ID="IndeksiVuosi" runat="server"></asp:Label></td>
              <td class="view2columnsHeader2">Viimeisin indeksivuosi</td>
              <td class="view2columnsContentElement2">
                <asp:Label ID="ViimeisinIndeksiVuosi" runat="server"></asp:Label>
              </td>
            </tr>
            <tr>
              <td class="view2columnsHeader1">Sopimushetken indeksiarvo</td>
              <td class="view2columnsContentElement1">
                <asp:Label ID="SopimushetkenIndeksiArvo" runat="server"></asp:Label></td>
              <td class="view2columnsHeader2">Viimeisin indeksiarvo</td>
              <td class="view2columnsContentElement2">
                <asp:Label ID="ViimeisinMaksuIndeksi" runat="server"></asp:Label></td>
            </tr>
            <tr>
              <td class="view2columnsHeader1">Indeksikuukausi</td>
              <td class="view2columnsContentElement1">
                <asp:Label ID="IndeksiKuukausi_Nimi" runat="server"></asp:Label></td>
              <td class="view2columnsHeader2"></td>
              <td class="view2columnsContentElement2"></td>
            </tr>
            <tr>
              <td class="view2columnsHeader1">Maksuun menevä summa (sis. alv%)</td>
              <td class="view2columnsContentElement1">
                <asp:Label ID="MaksuunMenevaSumma" runat="server"></asp:Label></td>
              <td class="view2columnsHeader2"></td>
              <td class="view2columnsContentElement2"></td>
            </tr>
          </asp:PlaceHolder>
          <tr>
            <td class="view2columnsHeader1">Kirjanpidon tili</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="KirjanpidonTili_Nimi" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Kirjanpidon kustannuspaikka</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="KirjanpidonKustannuspaikka_Nimi" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Inv/Cost</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="InvCost_Nimi" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Other Category</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="Category" runat="server"></asp:Label></td>
          </tr>
        </asp:PlaceHolder>
      </table>
      <div class="view2columnsClearElement"></div>
    </div>
    <div class="footerBar">
      <asp:Button ID="btnMuokkaa" runat="server" Text="Muokkaa tietoja" />
      <asp:Button ID="btnLisaaMaksu" runat="server" Text="Lisää maksu" />
      <asp:Button ID="btnTakaisin" runat="server" Text="Palaa takaisin" Visible="False" />
    </div>
  </div>
  <div class="headerBar">
    <h1>Korvauslaskelman rivit</h1>
  </div>
  <div class="list">
    <asp:GridView ID="gwKorvauslaskelmatRivit" runat="server" AutoGenerateColumns="False">
      <SelectedRowStyle ForeColor="Red"></SelectedRowStyle>
      <Columns>
        <asp:BoundField DataField="Id" HeaderText="Tunniste" />
        <asp:BoundField DataField="Korvaushinnasto.KorvausLaji" HeaderText="Korvauslaji" />
        <asp:BoundField DataField="Maara" HeaderText="Määrä" DataFormatString="{0:f3}" />
        <asp:BoundField DataField="Yksikkohinta" HeaderText="Yksikköhinta" DataFormatString="{0:f2}" />
        <asp:BoundField DataField="Korvaus" HeaderText="Korvaus" DataFormatString="{0:f2} euroa" />
        <asp:TemplateField ItemStyle-CssClass="listGridviewAction">
          <ItemTemplate>
            <asp:LinkButton ID="hlMuokkaa" Text="Muokkaa" runat="server"></asp:LinkButton>
            <asp:LinkButton ID="hlPoista" Text="Poista" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('Oletko varma, että haluat poistaa tämän korvausrivin?');"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  <div class="footerBar">
    <asp:Button Text="Lisää rivi korvauslaskelmalle" CausesValidation="False" ID="btLisaaRiviKorvauslaskelmalle" runat="server"></asp:Button>
  </div>

</asp:Content>
