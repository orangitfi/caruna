<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Maksuaineisto.aspx.vb" Inherits="appSopimusrekisteri.MaksuaineistonLuominen" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/LomakeVirhe.ascx" TagName="LomakeVirhe" TagPrefix="uc1" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">
  <h1>Maksuaineiston luominen</h1>
  <div class="form">
    <div class="formValidationInfo">
      <uc1:LomakeVirhe ID="LomakeVirhe" runat="server" />
    </div>
    <table class="form" cellpadding="0" cellspacing="0">
      <tr>
        <td class="formActions">
          <asp:Button Text="Päivitä" CausesValidation="False" ID="btnPaivitaMaksuaineisto" runat="server"></asp:Button>
          <asp:Button Text="Luo maksuaineisto" ID="btnTeeMaksuaineisto" runat="server"></asp:Button>
          Maksupvm
          <asp:TextBox ID="txtMaksupvm" runat="server" SkinID="Datetime"></asp:TextBox>
          <asp:Image ID="imgtxtMaksupvm" SkinID="CalendarImage" AlternateText="Valitse päivä" runat="server" />
          <ajaxToolkit:CalendarExtender ID="caltxtMaksupvm" runat="server" TargetControlID="txtMaksupvm" PopupButtonID="imgtxtMaksupvm" PopupPosition="BottomRight" Format="dd.MM.yyyy" />
        </td>
      </tr>
    </table>
  </div>
  <div class="view">
    <div class="viewInfoFull">
      <asp:Label ID="lblTiedot" runat="server"></asp:Label>
    </div>
    <ul class="viewLinkElement">
      <asp:ListView ID="lvMaksuaineistot" runat="server">
        <LayoutTemplate>
          <li runat="server" id="itemPlaceHolder" />
        </LayoutTemplate>
        <ItemTemplate>
          <li>
            <asp:HyperLink ID="hlMaksuaineisto" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
      </asp:ListView>
      <asp:ListView ID="lvKirjanpidonAineistot" runat="server">
        <LayoutTemplate>
          <li runat="server" id="itemPlaceHolder" />
        </LayoutTemplate>
        <ItemTemplate>
          <li>
            <asp:HyperLink ID="hlKirjanpidonAineisto" runat="server"></asp:HyperLink></li>
        </ItemTemplate>
      </asp:ListView>
    </ul>
  </div>

  <asp:HiddenField ID="valinta" runat="server" />

  <cc1:TabContainer ID="TabAineisto" runat="server" CssClass="tabContainer" ActiveTabIndex="0">

    <cc1:TabPanel ID="TabVirheellinenAineisto" runat="server" HeaderText="VIRHEELLINEN AINEISTO" Visible="true" Style="overflow-x: scroll;">
      <ContentTemplate>
        <div class="headerBar">
          <div class="headerBarInfo">
          </div>
          <div class="headerBarActionImgLink">
            <asp:HyperLink ID="hlExcelVirheellinenAineisto" runat="server" Target="_blank">
              <asp:Image ID="imgExcelVirheellinenAineisto" runat="server" SkinID="ExcelImage" />
            </asp:HyperLink>
          </div>
        </div>
        <div class="list">

          <asp:GridView ID="gvVirheellinenAineisto" runat="server" AutoGenerateColumns="False" HeaderStyle-Wrap="false">
            <Columns>
              <asp:TemplateField HeaderText="Sopimus" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlSopimus" runat="server" Text='<%# Bind("SopimuksenNimi")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Projektinumero" HeaderText="Projekti" />
              <asp:BoundField DataField="KorvauksenProjektinumero" HeaderText="Korvauksen projektinumero" />
              <asp:TemplateField HeaderText="KL" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlKorvauslaskelma" runat="server" Text='<%# Bind("KorvauslaskelmaId")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="SopimusId" HeaderText="Sopimusnumero" />
              <asp:BoundField DataField="Kirjanpidontunniste" HeaderText="Yhtiön kirjanpidon tunniste" />
              <asp:BoundField DataField="SaajaId" HeaderText="Asiakastunniste" />
              <asp:BoundField DataField="Saaja" HeaderText="Saaja" />
              <asp:BoundField DataField="BicKoodi" HeaderText="BIC" />
              <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" />
              <asp:BoundField DataField="Viite" HeaderText="Viite" />
              <asp:BoundField DataField="Viesti" HeaderText="Viesti" />
              <asp:BoundField DataField="KorvauksienMaara" HeaderText="Korvauksia" DataFormatString="{0} kpl" />
              <asp:BoundField DataField="KorvauksienSummaIlmanAlv" HeaderText="Korvaus" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienAlv" HeaderText="Alv" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienSumma" HeaderText="Korvaus yht" DataFormatString="{0:f2}" />
              <asp:TemplateField HeaderText="Sopimuksella indeksi">
                <ItemTemplate>
                  <%# appSopimusrekisteri.Muuttujat.EsitaBoolean(Eval("OnIndeksi"))%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Indeksityyppi" HeaderText="Indeksityyppi" />
              <asp:BoundField DataField="Indeksikuukausi" HeaderText="Indeksikuukausi" />
              <asp:BoundField DataField="Indeksi" HeaderText="Indeksin arvo" />
              <asp:BoundField DataField="Sopimustyyppi" HeaderText="Sopimustyyppi" />
              <asp:BoundField DataField="Korvaustyyppi" HeaderText="Korvaustyyppi" />
              <asp:BoundField DataField="MaksunSuoritus" HeaderText="Maksun suoritus" />
              <asp:BoundField DataField="MaksajanTilinro" HeaderText="Yhtiön tilinumero" />
              <asp:BoundField DataField="MaksajanBicKoodi" HeaderText="Yhtiön BIC" />
              <asp:BoundField DataField="Palvelutunnus" HeaderText="Yhtiön palvelutunnus" />
              <asp:BoundField DataField="JuridinenYhtioConcession" HeaderText="Yhtiön concession" />
              <asp:BoundField DataField="TypeOfProject" HeaderText="Type of Project" />
              <asp:BoundField DataField="Type" HeaderText="Type" />
              <asp:BoundField DataField="Owner" HeaderText="Owner" />
              <asp:BoundField DataField="Concession" HeaderText="Concession" />
              <asp:BoundField DataField="CertDate" HeaderText="Cert. Date" />
              <asp:BoundField DataField="FieldWorkStartedA" HeaderText="Field Work Started A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="ProjectClosedA" HeaderText="Project Closed A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="Kustannuspaikka" HeaderText="RESPONS" />
              <asp:BoundField DataField="Kirjanpidontili" HeaderText="ACCOUNT" />
              <asp:BoundField DataField="InvCost" HeaderText="INVCOST" />
              <asp:BoundField DataField="Country" HeaderText="Country" />
              <asp:BoundField DataField="Regulation" HeaderText="REGULATION" />
              <asp:BoundField DataField="Purpose" HeaderText="PURPOSE" />
              <asp:BoundField DataField="Local1" HeaderText="LOCAL1" />
            </Columns>
          </asp:GridView>

        </div>
      </ContentTemplate>
    </cc1:TabPanel>

    <cc1:TabPanel ID="TabTarkistettavaAineisto" runat="server" HeaderText="TARKISTETTAVA AINEISTO" Visible="true" Style="overflow-x: scroll;">
      <ContentTemplate>
        <div class="headerBar">
          <div class="headerBarInfo">
          </div>
          <div class="headerBarActionImgLink">
            <asp:HyperLink ID="hlExcelTarkistettavaAineisto" runat="server" Target="_blank">
              <asp:Image ID="imgExcelTarkistettavaAineisto" runat="server" SkinID="ExcelImage" />
            </asp:HyperLink>
          </div>
        </div>
        <div class="list">

          <asp:GridView ID="gvTarkistettavaAineisto" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId" HeaderStyle-Wrap="false">
            <Columns>
              <asp:TemplateField HeaderText="Sopimus" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlSopimus" runat="server" Text='<%# Bind("SopimuksenNimi")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Projektinumero" HeaderText="Projekti" />
              <asp:BoundField DataField="KorvauksenProjektinumero" HeaderText="Korvauksen projektinumero" />
              <asp:TemplateField HeaderText="KL" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlKorvauslaskelma" runat="server" Text='<%# Bind("KorvauslaskelmaId")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="SopimusId" HeaderText="Sopimusnumero" />
              <asp:BoundField DataField="Kirjanpidontunniste" HeaderText="Yhtiön kirjanpidon tunniste" />
              <asp:BoundField DataField="SaajaId" HeaderText="Asiakastunniste" />
              <asp:BoundField DataField="Saaja" HeaderText="Saaja" />
              <asp:BoundField DataField="BicKoodi" HeaderText="BIC" />
              <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" />
              <asp:BoundField DataField="Viite" HeaderText="Viite" />
              <asp:BoundField DataField="Viesti" HeaderText="Viesti" />
              <asp:BoundField DataField="KorvauksienMaara" HeaderText="Korvauksia" DataFormatString="{0} kpl" />
              <asp:BoundField DataField="KorvauksienSummaIlmanAlv" HeaderText="Korvaus" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienAlv" HeaderText="Alv" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienSumma" HeaderText="Korvaus yht" DataFormatString="{0:f2}" />
              <asp:TemplateField HeaderText="Sopimuksella indeksi">
                <ItemTemplate>
                  <%# appSopimusrekisteri.Muuttujat.EsitaBoolean(Eval("OnIndeksi"))%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Indeksityyppi" HeaderText="Indeksityyppi" />
              <asp:BoundField DataField="Indeksikuukausi" HeaderText="Indeksikuukausi" />
              <asp:BoundField DataField="Indeksi" HeaderText="Indeksin arvo" />
              <asp:BoundField DataField="Sopimustyyppi" HeaderText="Sopimustyyppi" />
              <asp:BoundField DataField="Korvaustyyppi" HeaderText="Korvaustyyppi" />
              <asp:BoundField DataField="MaksunSuoritus" HeaderText="Maksun suoritus" />
              <asp:BoundField DataField="MaksajanTilinro" HeaderText="Yhtiön tilinumero" />
              <asp:BoundField DataField="MaksajanBicKoodi" HeaderText="Yhtiön BIC" />
              <asp:BoundField DataField="Palvelutunnus" HeaderText="Yhtiön palvelutunnus" />
              <asp:BoundField DataField="JuridinenYhtioConcession" HeaderText="Yhtiön concession" />
              <asp:BoundField DataField="TypeOfProject" HeaderText="Type of Project" />
              <asp:BoundField DataField="Type" HeaderText="Type" />
              <asp:BoundField DataField="Owner" HeaderText="Owner" />
              <asp:BoundField DataField="Concession" HeaderText="Concession" />
              <asp:BoundField DataField="CertDate" HeaderText="Cert. Date" />
              <asp:BoundField DataField="FieldWorkStartedA" HeaderText="Field Work Started A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="ProjectClosedA" HeaderText="Project Closed A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="Kustannuspaikka" HeaderText="RESPONS" />
              <asp:BoundField DataField="Kirjanpidontili" HeaderText="ACCOUNT" />
              <asp:BoundField DataField="InvCost" HeaderText="INVCOST" />
              <asp:BoundField DataField="Country" HeaderText="Country" />
              <asp:BoundField DataField="Regulation" HeaderText="REGULATION" />
              <asp:BoundField DataField="Purpose" HeaderText="PURPOSE" />
              <asp:BoundField DataField="Local1" HeaderText="LOCAL1" />
            </Columns>
          </asp:GridView>

        </div>
      </ContentTemplate>
    </cc1:TabPanel>

    <cc1:TabPanel ID="TabMaksettavaAineisto" runat="server" HeaderText="MAKSETTAVA AINEISTO" Visible="true" Style="overflow-x: scroll;">
      <ContentTemplate>
        <div class="headerBar">
          <div class="headerBarInfo">
          </div>
          <div class="headerBarActionImgLink">
            <asp:HyperLink ID="hlExcelMaksettavaAineisto" runat="server" Target="_blank">
              <asp:Image ID="imgExcelMaksettavaAineisto" runat="server" SkinID="ExcelImage" />
            </asp:HyperLink>
          </div>
        </div>
        <div class="list">

          <asp:GridView ID="gvMaksettavaAineisto" runat="server" AutoGenerateColumns="False" DataKeyNames="SopimusId" HeaderStyle-Wrap="false">

            <Columns>
              <asp:TemplateField HeaderText="Sopimus" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlSopimus" runat="server" Text='<%# Bind("SopimuksenNimi")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Projektinumero" HeaderText="Projekti" />
              <asp:BoundField DataField="KorvauksenProjektinumero" HeaderText="Korvauksen projektinumero" />
              <asp:TemplateField HeaderText="KL" ItemStyle-CssClass="listGridviewAction">
                <ItemTemplate>
                  <asp:HyperLink ID="hlKorvauslaskelma" runat="server" Text='<%# Bind("KorvauslaskelmaId")%>'></asp:HyperLink>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="SopimusId" HeaderText="Sopimusnumero" />
              <asp:BoundField DataField="Kirjanpidontunniste" HeaderText="Yhtiön kirjanpidon tunniste" />
              <asp:BoundField DataField="SaajaId" HeaderText="Asiakastunniste" />
              <asp:BoundField DataField="Saaja" HeaderText="Saaja" />
              <asp:BoundField DataField="BicKoodi" HeaderText="BIC" />
              <asp:BoundField DataField="Tilinumero" HeaderText="Tilinumero" />
              <asp:BoundField DataField="Viite" HeaderText="Viite" />
              <asp:BoundField DataField="Viesti" HeaderText="Viesti" />
              <asp:BoundField DataField="KorvauksienMaara" HeaderText="Korvauksia" DataFormatString="{0} kpl" />
              <asp:BoundField DataField="KorvauksienSummaIlmanAlv" HeaderText="Korvaus" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienAlv" HeaderText="Alv" DataFormatString="{0:f2}" />
              <asp:BoundField DataField="KorvauksienSumma" HeaderText="Korvaus yht" DataFormatString="{0:f2}" />
              <asp:TemplateField HeaderText="Sopimuksella indeksi">
                <ItemTemplate>
                  <%# appSopimusrekisteri.Muuttujat.EsitaBoolean(Eval("OnIndeksi"))%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="Indeksityyppi" HeaderText="Indeksityyppi" />
              <asp:BoundField DataField="Indeksikuukausi" HeaderText="Indeksikuukausi" />
              <asp:BoundField DataField="Indeksi" HeaderText="Indeksin arvo" />
              <asp:BoundField DataField="Sopimustyyppi" HeaderText="Sopimustyyppi" />
              <asp:BoundField DataField="Korvaustyyppi" HeaderText="Korvaustyyppi" />
              <asp:BoundField DataField="MaksunSuoritus" HeaderText="Maksun suoritus" />
              <asp:BoundField DataField="MaksajanTilinro" HeaderText="Yhtiön tilinumero" />
              <asp:BoundField DataField="MaksajanBicKoodi" HeaderText="Yhtiön BIC" />
              <asp:BoundField DataField="Palvelutunnus" HeaderText="Yhtiön palvelutunnus" />
              <asp:BoundField DataField="JuridinenYhtioConcession" HeaderText="Yhtiön concession" />
              <asp:BoundField DataField="TypeOfProject" HeaderText="Type of Project" />
              <asp:BoundField DataField="Type" HeaderText="Type" />
              <asp:BoundField DataField="Owner" HeaderText="Owner" />
              <asp:BoundField DataField="Concession" HeaderText="Concession" />
              <asp:BoundField DataField="CertDate" HeaderText="Cert. Date" />
              <asp:BoundField DataField="FieldWorkStartedA" HeaderText="Field Work Started A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="ProjectClosedA" HeaderText="Project Closed A" DataFormatString="{0:dd.MM.yyyy}" />
              <asp:BoundField DataField="Kustannuspaikka" HeaderText="RESPONS" />
              <asp:BoundField DataField="Kirjanpidontili" HeaderText="ACCOUNT" />
              <asp:BoundField DataField="InvCost" HeaderText="INVCOST" />
              <asp:BoundField DataField="Country" HeaderText="Country" />
              <asp:BoundField DataField="Regulation" HeaderText="REGULATION" />
              <asp:BoundField DataField="Purpose" HeaderText="PURPOSE" />
              <asp:BoundField DataField="Local1" HeaderText="LOCAL1" />
            </Columns>
          </asp:GridView>

        </div>
      </ContentTemplate>
    </cc1:TabPanel>

  </cc1:TabContainer>


</asp:Content>
