<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Tuonti.aspx.vb" Inherits="appSopimusrekisteri.KorvaushinnastoTuonti" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <div class="bar barExtensionGray">
    <h1>Korvaushinnastojen tuonti tiedostosta</h1>
    <div class="barAction">
      <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Ohjaustiedot/Korvaushinnasto/Tiedot.aspx">Takaisin korvaushinnastoihin</asp:HyperLink>
    </div>
  </div>
  <div class="view">

    <div class="form">
      <p>Voit tuoda korvaushinnastoja järjestelmään. Olemassaolevat korvaushinnastot passivoidaan kun uudet korvaushinnastot tuodaan.</p>
      <p>
        <asp:FileUpload ID="FileUpload1" runat="server" /></p>
      <br />
      <asp:Label ID="lblInfo" runat="server" Visible="false"></asp:Label>
    </div>

    <div class="footerBar">
      <asp:Button ID="btnLataa" runat="server" Text="Lataa tiedosto" OnClientClick="return HasFile()" />
    </div>
  </div>

  <script type="text/javascript" language="javascript">

    function HasFile() {
      var selectedFile = $('#<%= FileUpload1.ClientID %>').val();
        if (selectedFile != "") {
          if (endsWith(selectedFile, ".xls") || endsWith(selectedFile, ".xlsx")) {
            return true;
          }
          else {
            alert('Valitse excel-tiedosto maksuaineiston tuomiseen!');
            return false;
          }
        }
        else {
          return false;
        }

      }

      function endsWith(str, suffix) {
        return str.indexOf(suffix, str.length - suffix.length) !== -1;
      }

  </script>

</asp:Content>
