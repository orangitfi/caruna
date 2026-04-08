<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tuonti.aspx.vb" Inherits="appSopimusrekisteri.MaksuaineistojenTuonti" Theme="Default" StylesheetTheme="Default" %>

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

    <div class="headerBar">
        <h1>PCS-AINEISTON TUONTI</h1>
    </div>
    <div class="view">

        
        <div class="form">
            <p>Voit tuoda PCS-aineiston järjestelmään. Tekemäsi muutokset näkyvät heti maksuaineistoa koskevien sopimusten maksuajoja tehtäessä.</p>
            <p><asp:FileUpload ID="FileUpload1" runat="server" /></p>
            <br />
        </div>

        <div class="footerBar">
            <asp:Button ID="btnLataa" runat="server" Text="Lataa tiedosto" OnClientClick="return HasFile()"/>
        </div>
    </div>

    <script type="text/javascript" language="javascript">

        function HasFile() {
            var selectedFile = $('#<%= FileUpload1.ClientID %>').val();
            if (selectedFile != "") {
                if (endsWith(selectedFile, ".csv")) {
                    return true;
                }
                else {
                    alert('Valitse .CSV-tiedosto maksuaineiston tuomiseen!');
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
