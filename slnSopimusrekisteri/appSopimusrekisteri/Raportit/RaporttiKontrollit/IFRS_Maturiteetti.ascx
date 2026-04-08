<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="IFRS_Maturiteetti.ascx.vb" Inherits="appSopimusrekisteri.IFRS_Maturiteetti" %>
<div class="headerBar">
    <h1><asp:Label runat="server" ID="lblOtsikko"></asp:Label></h1>
</div>
<div class="list">
    <table class="listGridview" cellpadding="3" cellspacing="0">
        <tbody>
            <asp:ListView runat="server" ID="lstTiedot" ItemType="Sopimusrekisteri.BLL_CF.Models.IFRSMaturiteetti">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Nimi %></td>
                        <td><%#: Item.Arvo.ToString("#,0.00", Formaatti) %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </tbody>
    </table>
</div>