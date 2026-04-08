<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="IFRS_Kausi.ascx.vb" Inherits="appSopimusrekisteri.IFRS_Kausi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:CollapsiblePanelExtender ID="cpeErottelu" runat="server" CollapseControlID="imgErottelu" ExpandControlID="imgErottelu"
TargetControlID="pnlErottelu" CollapsedImage="~/App_Themes/Default/Images/expand.jpg" ExpandedImage="~/App_Themes/Default/Images/collapse.jpg"
ImageControlID="imgErottelu" SuppressPostBack="True" Collapsed="True" CollapsedText="Näytä" ExpandedText="Piilota" Enabled="True">
</cc1:CollapsiblePanelExtender>
<div class="headerBar headerBarFirst">
    <h1>Erottelu&nbsp;<asp:Label runat="server" ID="lblErottelu"></asp:Label>&nbsp;<asp:Image style="cursor: pointer;" ID="imgErottelu" ImageUrl="~/App_Themes/Default/Images/expand.jpg" runat="server" /></h1>
</div>
<asp:Panel ID="pnlErottelu" runat="server">
    <div class="list">
        <table class="listGridview" cellpadding="3" cellspacing="0">
            <thead>
                <tr>
                    <th>Yhtiö</th>
                    <th>Sopimus</th>
                    <th>Maksun suoritus</th>
                    <th>Maksetaan ALV</th>
                    <th class="align-right">Kaudet, vanha</th>
                    <th class="align-right">Kaudet, uusi</th>
                    <th class="align-right">Korko-%, vanha</th>
                    <th class="align-right">Korko-%, uusi</th>
                    <th class="align-right">Vuokra, vanha</th>
                    <th class="align-right">Vuokra, uusi</th>
                    <th class="align-right" title="Nykyarvo edellisen kauden korolla, vuokralla ja kaudella">Nykyarvo vanhoilla tiedoilla</th>
                    <th class="align-right">Nykyarvo uusilla tiedoilla</th>
                    <th class="align-right">Nykyarvon muutos</th>
                    <th class="align-right">Group korko</th>
                    <th class="align-right">Group poisto</th>
                    <th class="align-right">Right of use assets, kauden loppu</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="lstTiedot" runat="server" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSLaskenta">
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.Yhtio %></td>
                            <td><a href="../Sopimus/Sopimus.ashx?id=<%#: Item.Sopimusnumero %>" target="_blank"><%#: Item.Sopimusnumero %></a></td>
                            <td><%#: Item.MaksunSuoritus %></td>
                            <td><%#: IF(Not Item.MaksetaanAlv.HasValue, String.Empty, If(Item.MaksetaanAlv.HasValue AndAlso Item.MaksetaanAlv, "Kyllä", "Ei"))  %></td>
                            <td class="align-right"><%#: If(Not Item.VanhaVuodet Is Nothing, Item.VanhaVuodet.Value.ToString("0"), String.Empty) %></td>
                            <td class="align-right"><%#: Item.UusiVuodet.ToString("0") %></td>
                            <td class="align-right"><%#: If(Not Item.VanhaKorko Is Nothing, Item.VanhaKorko.Value.ToString("0.00"), String.Empty) %></td>
                            <td class="align-right"><%#: Item.UusiKorko.ToString("0.00") %></td>
                            <td class="align-right"><%#: If(Not Item.VanhaVuokra Is Nothing, Item.VanhaVuokra.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                            <td class="align-right"><%#: Item.UusiVuokra.ToString("#,0.00", Formaatti) %></td>
                            <td class="align-right"><%#: If(Not Item.VanhaNykyarvo Is Nothing, Item.VanhaNykyarvo.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                            <td class="align-right"><%#: Item.UusiNykyarvo.ToString("#,0.00", Formaatti) %></td>
                            <td class="align-right"><%#: Item.NykyarvoMuutos.ToString("#,0.00", Formaatti) %></td>
                            <td class="align-right"><%#: If(Not Item.GroupKorko Is Nothing, Item.GroupKorko.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                            <td class="align-right"><%#: If(Not Item.GroupPoisto Is Nothing, Item.GroupPoisto.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                            <td class="align-right"><%#:  Item.UusiAssets.ToString("#,0.00", Formaatti) %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
            <asp:PlaceHolder runat="server" ID="phYhteensa">
                <tfoot>
                    <asp:ListView runat="server" ID="lstYhteensa" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSYhteensaVuokratyypeittain">
                        <ItemTemplate>
                            <tr>
                                <th colspan="8"><%#: Item.Nimi %></th>
                                <td class="align-right"><%#: If(Not Item.VanhaVuokra Is Nothing, Item.VanhaVuokra.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                                <td class="align-right"><%#: Item.UusiVuokra.ToString("#,0.00", Formaatti) %></td>
                                <td class="align-right"><%#: If(Not Item.VanhaNykyarvo Is Nothing, Item.VanhaNykyarvo.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                                <td class="align-right"><%#: Item.UusiNykyarvo.ToString("#,0.00", Formaatti) %></td>
                                <td class="align-right"><%#: Item.NykyarvoMuutos.ToString("#,0.00", Formaatti) %></td>
                                <td class="align-right"><%#: If(Not Item.GroupKorko Is Nothing, Item.GroupKorko.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                                <td class="align-right"><%#: If(Not Item.GroupPoisto Is Nothing, Item.GroupPoisto.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                                <td class="align-right"><%#: If(Not Item.Assets Is Nothing, Item.Assets.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </tfoot>
            </asp:PlaceHolder>
        </table>
    </div>
</asp:Panel>


<asp:ListView runat="server" ID="lstYhteenvedot" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSLaskentaYhteenveto">
    <ItemTemplate>
        <div class="headerBar">
            <h1><%#: Item.Vuokratyyppi %></h1>
        </div>
        <div class="list">
            <table class="listGridview" cellpadding="3" cellspacing="0">
                <tbody>
                    <tr>
                        <td>Right of use asset, debit</td>
                        <td class="align-right"><%#: If(Not Item.Assets Is Nothing, Item.Assets.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Leasingvelka, credit</td>
                        <td class="align-right"><%#: If(Not Item.Leasing Is Nothing, Item.Leasing.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Group korko, debit</td>
                        <td class="align-right"><%#: If(Not Item.GroupKorkoPositiivinen Is Nothing, Item.GroupKorkoPositiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Leasingvelka, credit</td>
                        <td class="align-right"><%#: If(Not Item.GroupKorkoNegatiivinen Is Nothing, Item.GroupKorkoNegatiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Group poisto, debit</td>
                        <td class="align-right"><%#: If(Not Item.GroupPoistoPositiivinen Is Nothing, Item.GroupPoistoPositiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Right of use asset, credit</td>
                        <td class="align-right"><%#: If(Not Item.GroupPoistoNegatiivinen Is Nothing, Item.GroupPoistoNegatiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Group vuokra, credit</td>
                        <td class="align-right"><%#: If(Not Item.GroupVuokraNegatiivinen Is Nothing, Item.GroupVuokraNegatiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Leasingvelka, debit</td>
                        <td class="align-right"><%#: If(Not Item.GroupVuokraPositiivinen Is Nothing, Item.GroupVuokraPositiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Retained earnings</td>
                        <td class="align-right"><%#: If(Not Item.Retained Is Nothing, Item.Retained.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Right of use asset, debit</td>
                        <td class="align-right"><%#: If(Not Item.NykyarvoMuutosPositiivinen Is Nothing, Item.NykyarvoMuutosPositiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Leasingvelka, credit</td>
                        <td class="align-right"><%#: If(Not Item.NykyarvoMuutosNegatiivinen Is Nothing, Item.NykyarvoMuutosNegatiivinen.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td colspan="2"><b>Tarkistus</b></td>
                    </tr>
                    <tr>
                        <td>Right of use asset</td>
                        <td class="align-right"><%#: If(Not Item.TarkistusAssets Is Nothing, Item.TarkistusAssets.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Leasingvelka</td>
                        <td class="align-right"><%#: If(Not Item.TarkistusLeasing Is Nothing, Item.TarkistusLeasing.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                    <tr>
                        <td>Tulosvaikutus + retained</td>
                        <td class="align-right"><%#: If(Not Item.TarkistusRetained Is Nothing, Item.TarkistusRetained.Value.ToString("#,0.00", Formaatti), String.Empty) %></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </ItemTemplate>
</asp:ListView>