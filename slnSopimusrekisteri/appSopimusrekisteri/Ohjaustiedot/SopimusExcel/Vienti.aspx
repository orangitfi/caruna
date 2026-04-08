<%@ Page Title="Sopimusten tietojen vienti" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Vienti.aspx.vb" Inherits="appSopimusrekisteri.SopimusExcelVienti" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Sopimusrekisteri.Controls" Namespace="Sopimusrekisteri.Controls" TagPrefix="controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphToolbar" runat="server">
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSearch" runat="server">
    <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">

    <cc1:TabContainer ID="tabContainer" runat="server" CssClass="tabContainer">
        <cc1:TabPanel ID="tabValmiit" runat="server" HeaderText="HAE SOPIMUKSIA" Style="padding-top: 0;">
            <ContentTemplate>
                <div class="form formExtensionAccordion" style="border-top: none;">
                    <table class="form">
                        <tr>
                            <td class="formHeader" style="border-bottom: none;">&nbsp;</td>
                            <td class="formValidation" style="border-bottom: none;">&nbsp;</td>
                            <td class="formInputElement" align="right" style="border-bottom: none;">
                                <asp:HyperLink ID="hlTakaisin" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="formValidationInfo">
                                <asp:ValidationSummary runat="server" ID="VSHaku" ValidationGroup="valmiit" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Sopimusnumero välillä
                            </td>
                            <td class="formValidation">
                                <asp:CompareValidator runat="server" ID="comValSopimusnumeroAlku" ErrorMessage="Anna sopimusnumero välillä kokonaislukuna" Display="None" Operator="DataTypeCheck" ControlToValidate="txtSopimusnumeroAlku" Type="Integer" ValidationGroup="valmiit"></asp:CompareValidator>
                                <asp:CompareValidator runat="server" ID="comValSopimusnumeroLoppu" ErrorMessage="Anna sopimusnumero välillä kokonaislukuna" Display="None" Operator="DataTypeCheck" ControlToValidate="txtSopimusnumeroLoppu" Type="Integer" ValidationGroup="valmiit"></asp:CompareValidator>
                            </td>
                            <td class="formInputElement">
                                <asp:TextBox runat="server" ID="txtSopimusnumeroAlku" Style="width: 100px;"></asp:TextBox>
                                -
                                <asp:TextBox runat="server" ID="txtSopimusnumeroLoppu" Style="width: 100px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Alkupvm välillä
                            </td>
                            <td class="formValidation">
                                <controls:DateInputValidator ID="diValAlkupvmAlku" runat="server" DateInputID="diAlkupvmAlku" ValidationGroup="valmiit" />
                                <controls:DateInputValidator ID="diValAlkupvmLoppu" runat="server" DateInputID="diAlkupvmLoppu" ValidationGroup="valmiit" />
                            </td>
                            <td class="formInputElement">
                                <controls:DateInput ID="diAlkupvmAlku" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                                -
                                <controls:DateInput ID="diAlkupvmLoppu" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Päättymispvm välillä
                            </td>
                            <td class="formValidation">
                                <controls:DateInputValidator ID="diValPaattymispvmAlku" runat="server" DateInputID="diPaattymispvmAlku" ValidationGroup="valmiit" />
                                <controls:DateInputValidator ID="diValPaattymispvmLoppu" runat="server" DateInputID="diPaattymispvmLoppu" ValidationGroup="valmiit" />
                            </td>
                            <td class="formInputElement">
                                <controls:DateInput ID="diPaattymispvmAlku" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                                -
                                <controls:DateInput ID="diPaattymispvmLoppu" runat="server" ImageUrl="/App_Themes/Default/Images/kalenteri.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Sopimustyyppi
                            </td>
                            <td class="formValidation"></td>
                            <td class="formInputElement">
                                <asp:DropDownList ID="ddlSopimustyyppi" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Sopimuksen tila
                            </td>
                            <td class="formValidation"></td>
                            <td class="formInputElement">
                                <asp:DropDownList ID="ddlSopimuksenTila" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td class="formActions">
                                <asp:Button runat="server" ID="btnHaeSopimukset" Text="Hae sopimukset ja esikatsele" OnClick="btnHaeSopimukset_Click" ValidationGroup="valmiit" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel runat="server" ID="tabPohjat" HeaderText="LUO POHJIA / VARAA SOPIMUSNUMEROITA" Style="padding-top: 0;">
            <ContentTemplate>
                <div class="form formExtensionAccordion" style="border-top: none;">
                    <table class="form">
                        <tr>
                            <td class="formHeader" style="border-bottom: none;">&nbsp;</td>
                            <td class="formValidation" style="border-bottom: none;">&nbsp;</td>
                            <td class="formInputElement" align="right" style="border-bottom: none;">
                                <asp:HyperLink ID="hlTakaisin2" runat="server" NavigateUrl="~/Ohjaustiedot/Ohjaustiedot.aspx">Takaisin ohjaustietoihin</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="formValidationInfo">
                                <asp:ValidationSummary runat="server" ID="VSPohja" ValidationGroup="pohja" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formHeader">* Määrä
                            </td>
                            <td class="formValidation">
                                <asp:CompareValidator runat="server" ID="comValMaara" ErrorMessage="Anna pohjien määrä kokonaislukuna." Display="None" Operator="DataTypeCheck" ControlToValidate="txtMaara" Type="Integer" ValidationGroup="pohja"></asp:CompareValidator>
                                <asp:RequiredFieldValidator runat="server" ID="rfvMaara" ErrorMessage="Pohjien määrä on pakollinen tieto." Display="None" ControlToValidate="txtMaara" ValidationGroup="pohja"></asp:RequiredFieldValidator>
                            </td>
                            <td class="formInputElement">
                                <asp:TextBox runat="server" ID="txtMaara"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td class="formActions">
                                <asp:Button runat="server" ID="btnLuoJaLataa" Text="Luo sopimuspohjat ja esikatsele" OnClick="btnLuoJaLataa_Click" ValidationGroup="pohja" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>


    <asp:PlaceHolder runat="server" ID="phTulokset" Visible="false">
        <br />
        <br />
        <div class="list" runat="server" id="tblSopimukset">
            <div class="bar barExtensionGray" style="margin-bottom: 0;">
                <h1>Tulokset</h1>
                <div class="barAction" style="margin-top: 0;">
                    <asp:Button runat="server" ID="btnExcel" Text="Lataa Excel" Style="margin-top: 0;" OnClick="btnExcel_Click" />
                </div>
            </div>
            <table class="listGridview" style="border-collapse: collapse;">
                <thead>
                    <tr class="listGridviewHeader">
                        <th>Sopimusnumero</th>
                        <th>Sopimustyyppi</th>
                        <th>Tila</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView runat="server" ID="lvTiedot" ItemType="Sopimusrekisteri.BLL_CF.Sopimus">
                        <ItemTemplate>
                            <tr class="listGridviewItem">
                                <td><%# Item.Id %><asp:HiddenField runat="server" ID="hfId" Value="<%# Item.Id.ToString() %>" /></td>
                                <td><%# Item.Sopimustyyppi.SopimustyyppiNimi %></td>
                                <td><%# If(Not Item.SopimuksenTila Is Nothing, Item.SopimuksenTila.Nimi, String.Empty) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>
        <asp:Label runat="server" ID="lblEiTietoja" Visible="false">Ei sopimuksia annetuilla ehdoilla</asp:Label>
    </asp:PlaceHolder>

</asp:Content>
