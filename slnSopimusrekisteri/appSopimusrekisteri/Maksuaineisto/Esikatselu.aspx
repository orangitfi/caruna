<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Esikatselu.aspx.vb" Inherits="appSopimusrekisteri.MaksuaineistonEsikatselu" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <div class="bar barExtensionGray">
    <h1>Maksuaineistojen esikatselu</h1>
    <div class="barAction">
      <asp:LinkButton ID="lbTakaisin" runat="server">Takaisin maksuaineistoihin</asp:LinkButton>
    </div>
  </div>
  <div class="bar">
    <asp:Button CssClass="fonttinormaali" Text='Luo maksuaineisto' CausesValidation='False' ID='btnTeeMaksuaineisto' runat='server'></asp:Button>
    <div class="barInfo">
        <asp:Label ID="lblTiedot" runat="server"></asp:Label>
    </div>
  </div>
    
  <asp:hiddenfield ID="valinta" runat="server" />

  <cc1:tabcontainer ID="TabAineisto" runat="server" CssClass="tabContainer" ActiveTabIndex="1">
    <cc1:tabpanel ID="TabYhdistys" runat="server" HeaderText="VIRHEELLINEN AINEISTO" Visible="true">
      <contenttemplate>
            <div class="list">
        
                <asp:GridView ID="gwTulokset" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId">
                  <Columns>
                    <%--<asp:BoundField DataField="SopimusId" HeaderText="Tunniste" ItemStyle-VerticalAlign="Top" />--%>
                    <asp:BoundField DataField="SopimuksenNimi" HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Projektinumero" HeaderText="Projektinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmaId" HeaderText="Korvauslaskelma" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viite" HeaderText="Viite" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viesti" HeaderText="Viesti" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvausrivienMaara" HeaderText="Korvauksia" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmienSumma" HeaderText="Summa" ItemStyle-VerticalAlign="Top" DataFormatString="{0:f2}" />
              
                  </Columns>
                </asp:GridView>
        
          </div>
      </contenttemplate>
    </cc1:tabpanel>

    <cc1:tabpanel ID="TabTarkistettavaAineisto" runat="server" HeaderText="TARKISTETTAVA AINEISTO" Visible="true">
      <contenttemplate>
          
            <div class="list">
        
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId">
                  <Columns>
                    <%--<asp:BoundField DataField="SopimusId" HeaderText="Tunniste" ItemStyle-VerticalAlign="Top" />--%>
                    <asp:BoundField DataField="SopimuksenNimi" HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Projektinumero" HeaderText="Projektinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmaId" HeaderText="Korvauslaskelma" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viite" HeaderText="Viite" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viesti" HeaderText="Viesti" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvausrivienMaara" HeaderText="Korvauksia" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmienSumma" HeaderText="Summa" ItemStyle-VerticalAlign="Top" DataFormatString="{0:f2}" />
              
                  </Columns>
                </asp:GridView>
        
          </div>          
      </contenttemplate>
    </cc1:tabpanel>

    <cc1:tabpanel ID="TabMaksettavaAineisto" runat="server" HeaderText="MAKSETTAVA AINEISTO" Visible="true">
      <contenttemplate>
          
            <div class="list">
        
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId">
                  <Columns>
                    <%--<asp:BoundField DataField="SopimusId" HeaderText="Tunniste" ItemStyle-VerticalAlign="Top" />--%>
                    <asp:BoundField DataField="SopimuksenNimi" HeaderText="Sopimus" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Projektinumero" HeaderText="Projektinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmaId" HeaderText="Korvauslaskelma" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viite" HeaderText="Viite" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="Viesti" HeaderText="Viesti" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvausrivienMaara" HeaderText="Korvauksia" ItemStyle-VerticalAlign="Top" />
                    <asp:BoundField DataField="KorvauslaskelmienSumma" HeaderText="Summa" ItemStyle-VerticalAlign="Top" DataFormatString="{0:f2}" />
              
                  </Columns>
                </asp:GridView>
        
          </div>          
      </contenttemplate>
    </cc1:tabpanel>

  </cc1:tabcontainer>

  
</asp:Content>
