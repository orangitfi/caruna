<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tuonti.aspx.vb" Inherits="appSopimusrekisteri.TiedostoExcelTuonti" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">

    <div class="bar barExtensionGray" style="margin-bottom: 0;">
        <h1>M-Files tiedostojen tuonti Kiltaan</h1>
        <div class="barAction">
            <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink>
        </div>
    </div>

    <div class="form formExtensionAccordion" style="border-top: none;">
        <table class="form">
            <tr>
                <td colspan="3" class="formValidationInfo">
                    <asp:ValidationSummary runat="server" ID="VSTuonti" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-bottom: 40px;">
                    <asp:HyperLink runat="server" ID="hlMallitiedosto" NavigateUrl="~/Dokumentit/m-files_tuonti_malli.xlsx">Lataa mallitiedosto</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="formHeader">* Excel tiedosto:
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvTiedosto" Display="None" ErrorMessage="Valitse tiedosto ensin." ControlToValidate="fuTiedosto"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="cvTiedosto" Display="None" OnServerValidate="cvTiedosto_ServerValidate" ErrorMessage="Tiedoston täytyy olla excel tiedosto (xlsx)."></asp:CustomValidator>
                </td>
                <td class="formInputElement">
                    <asp:FileUpload runat="server" ID="fuTiedosto" AllowMultiple="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Button runat="server" ID="btnEsikatsele" Text="Esikatsele tuotavia tiedostoja" OnClick="btnEsikatsele_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
                <td class="formActions">
                    <asp:Label runat="server" ID="lblOnnistunut" ForeColor="Green" Visible="false">Tiedot tuotiin onnistuneesti!</asp:Label>
                    <asp:Label runat="server" ID="lblTuntematonVirhe" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    
    <asp:PlaceHolder runat="server" ID="phTulokset" Visible="false">
        <br />
        <br />
        <div class="bar barExtensionGray" style="margin-bottom: 0;">
            <h1>Tuotavat tiedot</h1>
            <div class="barAction" style="margin-top: 0;">
                <asp:Button runat="server" ID="btnTuo" Text="Tuo tiedot" Style="margin-top: 0;" OnClick="btnTuo_Click" CausesValidation="false" OnClientClick="return confirm('Haluatko varmasti tuoda tiedot?')" />
            </div>
        </div>
        <div class="list" style="border-top: none;">
            <table class="listGridview" style="border-collapse: collapse;">
                <thead>
                    <tr class="listGridviewHeader">
                        <th>Seloste</th>
                        <th>Kpl</th>
                    </tr>
                </thead>
                <tbody>
                    <tr class="listGridviewItem">
                        <td>Lisättäviä tiedostoja</td>
                        <td><asp:Label runat="server" ID="lblUusia"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td>Päivitettäviä tiedostoja</td>
                        <td><asp:Label runat="server" ID="lblPaivitettavia"></asp:Label></td>
                    </tr>
                    <tr class="listGridviewItem">
                        <td><b>Yhteensä</b></td>
                        <td><b><asp:Label runat="server" ID="lblYhteensa"></asp:Label></b></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </asp:PlaceHolder>
</asp:Content>
