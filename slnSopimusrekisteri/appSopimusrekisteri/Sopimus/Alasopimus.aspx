<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Alasopimus.aspx.vb" Inherits="appSopimusrekisteri.HaeAlasopimus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

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
    <h1>Lisää alasopimus sopimukselle <asp:Label runat="server" ID="lblSopimusnumero"></asp:Label></h1>
    <div class="form">
        <table class="form">
            <tr>
                <td class="formHeader"></td>
                <td class="formValidation"></td>
                <td class="formInputElement">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="formHeader">* Hae sopimusnumerolla
                </td>
                <td class="formValidation">
                    <asp:RequiredFieldValidator runat="server" ID="rfvVapaaHaku" ControlToValidate="cSopimusnumero" ErrorMessage="Hae sopimusnumerolla on pakollinen tieto."></asp:RequiredFieldValidator>
                </td>
                <td class="formInputElement">
                    <asp:TextBox runat="server" ID="cSopimusnumero"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="formHeader"></td>
                <td class="formValidation"></td>
                <td class="formActions">
                    <asp:Button ID="btnHae" runat="server" OnClick="btnHae_Click" Text="Hae" />
                    <asp:Button ID="btnPeruuta" runat="server" OnClick="btnPeruuta_Click" Text="Peruuta" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>

    <div class="headerBar">
        <h1>Hakutulos <asp:Label runat="server" ID="lblTiedot"></asp:Label></h1>
    </div>
    <div class="list">
        <asp:GridView ID="gvHakutulos" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowDataBound="gvHakutulos_RowDataBound" OnRowCommand="gvHakutulos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Sopimusnumero" ItemStyle-VerticalAlign="Top" />
                <asp:BoundField DataField="MuuTunniste" HeaderText="Muu tunniste" ItemStyle-VerticalAlign="Top" />
                <asp:BoundField DataField="Sopimustyyppi.SopimustyyppiNimi" HeaderText="Sopimustyyppi" ItemStyle-VerticalAlign="Top" />
                <asp:BoundField DataField="Alkaa" HeaderText="Alkaa" ItemStyle-VerticalAlign="Top" DataFormatString="{0:d.M.yyyy}" />
                <asp:BoundField DataField="Paattyy" HeaderText="Päättyy" ItemStyle-VerticalAlign="Top" DataFormatString="{0:d.M.yyyy}" />
                <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="listGridviewAction">
                    <ItemTemplate>
                        <asp:LinkButton ID="hlValitse" CommandName="Valitse" runat="server">Valitse</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="footerBar">
        <asp:Button Text="Uusi sopimus" CausesValidation="False" ID="btnUusiSopimus" OnClick="btnUusiSopimus_Click" runat="server"></asp:Button>
    </div>

</asp:Content>
