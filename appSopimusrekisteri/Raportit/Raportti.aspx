<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Raportti.aspx.vb" Inherits="appSopimusrekisteri.Raportti" Theme="Default" StylesheetTheme="Default" %>


<%@ Register Src="~/Controls/Haku.ascx" TagName="Haku" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
  <link href="../tyyli.css" type="text/css" rel="stylesheet" media="screen" />
  <style type="text/css" media="print">
    .noprint {
      display: none;
    }
  </style>
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

    <h1 id="heading" runat="server"></h1>

    <div class="noprint">
      <div id="divForm" runat="server" class="form">
        <div class="formValidationInfo">
          <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
        </div>
        <div class="formInfo">
          <asp:Label ID="lblHakuohje" runat="server" />
        </div>
        <div class="formDateInfo">
          <asp:Label ID="lblDate" runat="server"></asp:Label>
        </div>

        <div>
          <asp:PlaceHolder ID="phValinnat" runat="server"></asp:PlaceHolder>

          <div style="margin-top: 2em; padding-bottom: 2em; margin-left: 14%;">
            <asp:Button ID="btnHae" runat="server" Text="Hae tiedot" OnClick="btnHae_OnClick" />
          </div>
        </div>

      </div>
    </div>

    <asp:Panel ID="pnlReport" Visible="false" runat="server">
      <div class="noprint">
        <div class="headerBar headerBarExtensionReport">
          <div class="headerBarInfo">
            <asp:Label ID="lblOhje" runat="server"></asp:Label>
          </div>
          <div class="headerBarActionImgLink">
            <asp:ImageButton ID="btnTeeExcel" runat="server" AlternateText="Tee Excel" ToolTip="Lataa raportti Excel-muodossa"
              SkinId="ExcelImage" OnClick="btnTeeExcel_Click" />
          </div>
        </div>
      </div>
      <div id="reportContainer" runat="server" class="list listExtensionReport">
      </div>
      <div>
        <asp:PlaceHolder ID="phPager" runat="server"></asp:PlaceHolder>
      </div>
    </asp:Panel>

    <div class="footerBar">
      <div class="footerBarInfo">
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
      </div>
    </div>

    <asp:Panel ID="pnlSubReport" runat="server" Visible="false">
      <div id="subReportContainer" runat="server" style="margin-top: 2em;" visible="false"></div>
    </asp:Panel>

</asp:Content>
