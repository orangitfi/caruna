<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="IFRS.aspx.vb" Inherits="appSopimusrekisteri.IFRS1" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Raportit/RaporttiKontrollit/IFRS_Kausi.ascx" TagName="IFRSKausi" TagPrefix="uc" %>
<%@ Register Src="~/Raportit/RaporttiKontrollit/IFRS_Maturiteetti.ascx" TagName="IFRSMaturiteetti" TagPrefix="uc" %>
<%@ Register Assembly="appSopimusrekisteri" Namespace="appSopimusrekisteri.GeneralControls" TagPrefix="uc" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <style type="text/css">

        html {
            width: 100% !important;
            overflow-x: scroll !important;
        }

        .page {
            width: 100% !important;
            min-width: 1350px;
        }

        #sidebar {
            width: 33% !important;
            max-width: 250px;
            display: inline-block;
        }

        #content {
            display: inline-block;
            width: 75% !important;
        }
        
        .tab-header {
            display: flex;
            flex-direction: row;
            border-bottom: 1px solid black;
            margin-bottom: 10px;
        }

        .tab-button {
            margin-bottom: -1px;
            margin-left: -1px;
            display: block;
            padding: 10px;
            background-color: #eee;
            border: 1px solid #ccc;
            border-bottom: 1px solid black;
            cursor: pointer;
            z-index: 0;
        }

        .tab-button-active {
            border: 1px solid black;
            border-bottom: none;
            background-color: #fff;
            z-index: 100;
        }

        .lahde {
            box-sizing: border-box;
            width: 100%;
            padding: 10px;
            background-color: #E6F0FA;
            border: 1px solid #6AB7FB;
            margin-bottom: -5px;
            margin-top: 20px;
            border-radius: 5px;
        }
        
        .align-right {
            text-align: right !important;
            max-width: 75px;
        }

        .list {
            margin-bottom: 0;
            border-top: none !important;
        }

        .headerBar {
            margin-top: 30px;
            border-bottom: 3px solid #9A9899;
        }

/*        .headerBar.headerBarFirst {
            margin-top: 0;
        }*/
    </style>
    <script type="text/javascript">
        function naytaTab(sender) {
            var target = $(sender).data("target");

            $(".tab-content").hide();
            $(".tab-button").removeClass("tab-button-active");
            $(sender).addClass("tab-button-active");
            $(target).show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">

    <h2>Historia</h2>

    <table style="width: 100%;">
        <thead>
            <tr>
                <th style="text-align: left;">Katselupvm</th>
                <th style="text-align: left;">Luoja</th>
            </tr>
        </thead>
        <tbody>
            <asp:ListView runat="server" ID="lstHistoria" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSHistoriaExcelModel" OnItemDataBound="lstHistoria_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><asp:HyperLink runat="server" ID="hlExcel" Target="_blank"></asp:HyperLink></td>
                        <td><span title="<%#: Item.Luotu.ToShortDateString() & " " & Item.Luotu.ToShortTimeString() %>"><%#: Item.Luoja %></span></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">


    <h1>IFRS- ja FAS-Vuokrat ja maturiteetti</h1>

    <div class="noprint">
        <div class="form">
            <div class="formValidationInfo">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
            </div>
            <div class="formInfo">
                <asp:Label ID="lblHakuohje" runat="server" />
            </div>
            <div class="formDateInfo">
                <%#: DateTime.Now.ToShortDateString() %>
            </div>
            <div>
                <table class="form" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td class="formHeader">Katselupvm *</td>
                            <td class="formValidation">
                                <asp:CustomValidator runat="server" ID="cvKatselupvm" Display="None" ErrorMessage="Katselupvm on pakollinen tieto." OnServerValidate="cvKatselupvm_ServerValidate"></asp:CustomValidator>
                            </td>
                            <td class="formInputElement">
                                <uc:DateInput runat="server" ID="cKatselupvm"></uc:DateInput>
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Oletettu inflaatio (%) *</td>
                            <td class="formValidation">
                                <asp:RequiredFieldValidator runat="server" ID="rfvOletettuInflaatio" ControlToValidate="cOletettuInflaatio" Display="None" ErrorMessage="Oletettu inflaatio on pakollinen tieto."></asp:RequiredFieldValidator>
                                <asp:CompareValidator runat="server" ID="cvOletettuInflaatio" ErrorMessage="Anna prosentti kokonaislukuna tai desimaalina" Operator="DataTypeCheck" Display="None" ControlToValidate="cOletettuInflaatio" Type="Double"></asp:CompareValidator>
                                <asp:CustomValidator runat="server" ID="cusOletettuInflaatio" ErrorMessage="Anne prosenttiluku välillä 0-100." OnServerValidate="cusOletettuInflaatio_ServerValidate" Display="None"></asp:CustomValidator>
                            </td>
                            <td class="formInputElement">
                                <asp:TextBox runat="server" ID="cOletettuInflaatio" MaxLength="8" SkinID="Numeric"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td class="formActions">
                                <asp:Button ID="btnHae" runat="server" Text="Hae" OnClick="btnHae_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <asp:PlaceHolder runat="server" ID="phTulokset" Visible="false">

        <asp:Button runat="server" ID="btnTallennaHistoria" Text="Tallenna historia" OnClick="btnTallennaHistoria_Click" OnClientClick="return confirm('Haluatko varmasti tallentaa nykyhetken tilanteen historiaan? Tiedot tallennetaan raportilla annettuun katselupäivään. Historioituja tietoja ei voi jälkikäteen enää muokata. Samalle päivälle ei voi myöskään tallentaa enää uutta historiaa.')" />&nbsp;
        <asp:Button runat="server" ID="btnLataaExcel" Text="Lataa Excel" OnClick="btnLataaExcel_Click" />

        <div class="list listExtensionReport">
            <div id="reportContainer">
                <div class="tab-header">
                    <asp:PlaceHolder runat="server" ID="phMaturiteettiHeader" Visible="false">
                        <div class="tab-button" data-target="#maturiteetti" onclick="naytaTab(this)">
                            <b>MATURITEETTI</b>
                        </div>
                    </asp:PlaceHolder>
                    <asp:ListView runat="server" ID="lstTabHeader" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSKausi">
                        <ItemTemplate>
                            <div class="tab-button <%#: If(Item.HaettuKausi, "tab-button-active", String.Empty) %>" data-target="#<%#: Item.HtmlId %>" onclick="naytaTab(this)">
                                <b><%#: Item.Pvm.ToShortDateString() %></b>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>

                <asp:PlaceHolder runat="server" ID="phMaturiteettiContent">
                    <div class="tab-content" id="maturiteetti" style="display:none;">
                        <div class="lahde">
                            <span>Laskettu vuoden <asp:Label runat="server" ID="lblMaturiteettiVuosi"></asp:Label> vuosivuokralla ja <asp:Label runat="server" ID="lblMaturiteettiInflaatio"></asp:Label>% inflaatiolla</span>
                        </div>

                        <uc:IFRSMaturiteetti runat="server" ID="lstMaturiteettiFAS" Otsikko="Maturiteetti, FAS"></uc:IFRSMaturiteetti>
                        <uc:IFRSMaturiteetti runat="server" ID="lstMaturiteettiIFRS" Otsikko="Maturiteetti, IFRS16"></uc:IFRSMaturiteetti>
                    </div>
                </asp:PlaceHolder>

                <asp:ListView runat="server" ID="lstTabContent" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSKausi" OnItemDataBound="lstTabContent_ItemDataBound">
                    <ItemTemplate>
                        <div class="tab-content" id="<%#: Item.HtmlId %>" style="<%#: If(Not Item.HaettuKausi, "display:none;", String.Empty) %>">

                            <div class="lahde">
                                <span><%#: Item.Lahde %></span>
                            </div>

                            <uc:IFRSKausi runat="server" ID="cKausi" />

                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </asp:PlaceHolder>

</asp:Content>
