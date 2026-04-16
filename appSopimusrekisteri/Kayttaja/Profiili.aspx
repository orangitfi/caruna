<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Profiili.aspx.vb" Inherits="appSopimusrekisteri.Profiili" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register src="~/Controls/Tyokalut.ascx" tagname="Tyokalut" tagprefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">        
    <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
     <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <h1>Käyttäjätilin tiedot</h1>

    <p><asp:Label ID="lblViesti" runat="server"></asp:Label></p>
    <cc1:TabContainer ID="TabKayttajanTiedot" runat="server" CssClass="tabContainer" ActiveTabIndex="0">

        <cc1:TabPanel ID="tabProfiilinTiedot" runat="server" HeaderText="Profiilin tiedot" Visible="true">
            <ContentTemplate>

                <div class="form">
                    <div class="formValidationInfo">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Profiilivalidaatio"/>
                    </div>

                    <div class="formInfo">
                        <asp:Literal ID="lblAsetuksienTallentaminen" runat="server"></asp:Literal>
                    </div>

                    <table class="form">
                        <tr>
                            <td class="formHeader">Käyttäjätunnus</td>
                            <td class="formValidation">
                                &nbsp;</td>
                            <td class="formInputElement">
                                <asp:TextBox ID="txtKayttajatunnus" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                          <td class="formHeader">Sähköposti</td>
                          <td class="formValidation">
                            <asp:RegularExpressionValidator ID="regSahkoposti" runat="server" ControlToValidate="txtSahkoposti" ErrorMessage="Sähköpostiosoite on väärässä muodossa" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Profiilivalidaatio"></asp:RegularExpressionValidator>
                          </td>
                          <td class="formInputElement">
                            <asp:TextBox ID="txtSahkoposti" runat="server" MaxLength="100"></asp:TextBox>
                          </td>
                        </tr>
                        <tr>
                            <td class="formHeader">Etunimi</td>
                            <td class="formValidation">&nbsp;
                            </td>
                            <td class="formInputElement">
                                <asp:TextBox ID="txtEtunimi" runat="server" MaxLength="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="formHeader">Sukunimi</td>
                            <td class="formValidation">&nbsp; </td>
                            <td class="formInputElement">
                                <asp:TextBox ID="txtSukunimi" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td class="formActions">
                                <asp:Button ID="btTallenna" runat="server" Text="Tallenna" ValidationGroup="Profiilivalidaatio" />
                            </td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tabProfiilinSalasana" runat="server" HeaderText="Salasanan vaihtaminen" Visible="true">
            <ContentTemplate>
                
                <div class="form">

                    <%--ChangePasswordFailureText="Salasanan vaihtaminen epäonnistui."
                    ConfirmPasswordCompareErrorMessage="Salasanan vahvistaminen epäonnistui."
                    ConfirmPasswordRequiredErrorMessage="Vanha salasana on pakollinen tieto."
                    NewPasswordRegularExpressionErrorMessage="Salasanan tulee olla riittävän vahva. Lisää salasanan pituutta ja LOC siihen numeroita ja erikoismerkkejä."
                    NewPasswordRequiredErrorMessage="Uusi salasana on pakollinen tieto."
                    PasswordRequiredErrorMessage="Vanha salasana on pakollinen tieto."
                    UserNameRequiredErrorMessage="Käyttäjätunnus on pakollinen tieto."--%>
                    <asp:ChangePassword ID="cpSalasananVaihtaminen" runat="server"
                     
                        >
                        <SuccessTemplate>
                            <div class="formInfo">
                                Salasana vaihdettiin onnistuneesti!
                            </div>
                        </SuccessTemplate>
                        <ChangePasswordTemplate>
                            <div class="formValidationInfo" style="min-width: 861px;">
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Salasanavalidaatio" />
                            </div>

                            <div class="formInfo">
                                &nbsp;
                            </div>
                            
                            <asp:Panel ID="pError" runat="server" Visible="false">
                                <div class="formValidationInfo" style="min-width: 861px;">
                                    <div>
                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </asp:Panel>


                            <table class="form">
                                <tr>

                                    <td class="formHeader">Vanha salasana</td>
                                    <td class="formValidation">
                                        <asp:RequiredFieldValidator ID="revTamanhetkinenSalasana" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Tämänhetkinen salasana ei voi olla tyhjä" ValidationGroup="Salasanavalidaatio"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="formInputElement">
                                        <asp:TextBox ID="CurrentPassword" runat="server" MaxLength="20" Text="" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <tr>
                                        <td class="formHeader">Uusi salasana</td>
                                        <td class="formValidation">
                                            <asp:RequiredFieldValidator ID="revUusiSalasana" runat="server" ControlToValidate="NewPassword" ErrorMessage="Uusi salasana ei voi olla tyhjä" ValidationGroup="Salasanavalidaatio"></asp:RequiredFieldValidator>
                                            <td class="formInputElement">
                                                <asp:TextBox ID="NewPassword" runat="server" MaxLength="20" Text="" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;</td>
                                        <td class="formActions">
                                            <asp:Button ID="ChangePassword" CommandName="ChangePassword" runat="server" CausesValidation="True" Text="Vaihda salasana" ValidationGroup="Salasanavalidaatio" />
                                        </td>
                                    </tr>
                            </table>
                        </ChangePasswordTemplate>
                    </asp:ChangePassword>
                </div>
                
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

</asp:Content>
