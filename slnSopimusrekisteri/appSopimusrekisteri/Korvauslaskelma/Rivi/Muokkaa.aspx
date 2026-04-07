<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.KorvauslaskelmarivinMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>

<%@ Register Src="~/Controls/Haku.ascx" TagName="Hakualue" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/Tyokalut.ascx" TagName="Tyokalut" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Infopallura.ascx" TagName="Infopallura" TagPrefix="uc3" %>

<asp:Content ID="ctnHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnToolbar" ContentPlaceHolderID="cphToolbar" runat="server">
  <uc1:Tyokalut ID="Tyokalut" runat="server" />
</asp:Content>
<asp:Content ID="ctnSearch" ContentPlaceHolderID="cphSearch" runat="server">
  <uc2:Hakualue ID="Haku" runat="server" />
</asp:Content>
<asp:Content ID="ctnContent" ContentPlaceHolderID="cphContent" runat="server">

  <h1>Korvauslaskelman rivin tiedot</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
      <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
        <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblKLRPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKLRPaivittaja" runat="server"></asp:Label>)
            <br />
        <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblKLRLuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKLRLuoja" runat="server"></asp:Label>)
      </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Hinnaston kategoria
          <uc3:Infopallura ID="ifpKHIHinnastoKategoriaId" runat="server" Kentta="KHIHinnastoKategoriaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddKHIHinnastoKategoriaId" runat="server" AutoPostBack="true" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <asp:PlaceHolder ID="phKategoriaValittu" runat="server">
        <tr>
          <td class="formHeader">Hinnaston alakategoria
          <uc3:Infopallura ID="ifpKHIHinnastoAlakategoriaId" runat="server" Kentta="KHIHinnastoAlakategoriaId"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:DropDownList ID="ddKHIHinnastoAlakategoriaId" runat="server" AutoPostBack="true" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="phAlakategoriaValittu" runat="server">
        <tr>
          <td class="formHeader">Hinnaston maksualue
          <uc3:Infopallura ID="ifpKHIMaksualueId" runat="server" Kentta="KHIMaksualueId"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:DropDownList ID="ddKHIMaksualueId" runat="server" AutoPostBack="true" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </asp:PlaceHolder>
      <asp:PlaceHolder ID="phMaksualueValittu" runat="server">
        <tr>
          <td class="formTableElement" colspan="4">
            <div class="list">
              <asp:GridView ID="gvHinnastot" runat="server" AutoGenerateColumns="False" DataKeyNames="KHIId">
                <Columns>

                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                      <asp:LinkButton ID="btnValitse" runat="server" CommandName="Select" CommandArgument='<%# Bind("KHIId")%>' Text="Valitse" CausesValidation="false" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="KHIKorvauslaji" HeaderText="Korvauslaji" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="hlp_Metsatyyppi.MTYMetsatyyppi" HeaderText="Kasvupaikkatyyppi" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="hlp_Puustolaji.PLAPuustolaji" HeaderText="Puustolaji" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="KHIPuustonIka" HeaderText="Puuston ikä" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="KHITaimistonValtapituus" HeaderText="Puuston pituus" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="KHITiheyskerroin" HeaderText="Puuston tiheyskerroin" ItemStyle-VerticalAlign="Top" />
                  <asp:BoundField DataField="KHIYksikkkohinta" HeaderText="Hinta" ItemStyle-VerticalAlign="Top" DataFormatString="{0:f2}" />
                  <asp:BoundField DataField="hlp_Yksikko.YKSKorvausyksikko" HeaderText="Yksikkö" ItemStyle-VerticalAlign="Top" />

                  <%--<asp:BoundField DataField="KHIYksikkohinnanTarkenne" HeaderText="Yksikköhinnan tarkenne" ItemStyle-VerticalAlign="Top" />--%>
                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                      <asp:Image runat="server" ID="imgInfo" SkinID="InfoImage" Visible="False" />
                    </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                      <asp:HiddenField runat="server" ID="hfKerroin" Value='<%#Bind("hlp_Yksikko.YKSKerroin") %>' />
                    </ItemTemplate>
                  </asp:TemplateField>

                </Columns>
              </asp:GridView>
            </div>
          </td>
        </tr>

      </asp:PlaceHolder>
    </table>
    <asp:Panel ID="pnlHinnastoValittu" runat="server">
      <div class="headerBar">
        <h1>Valittu korvaushinnasto</h1>
        <div class="headerBarActionImgLink" style="padding-top: 10px;">
          <asp:Image ID="imgInfo" SkinID="InfoImage" AlternateText="(i)" runat="server" />
        </div>
      </div>
      <div class="view2columns">
        <table>
          <tr>
            <td class="view2columnsHeader1">Korvauslaji</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="lblKHIKorvauslaji" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Tiheyskerroin</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="lblKHITiheyskerroin" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Kasvupaikkatyyppi</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="lblMTYMetsatyyppi" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Puustolaji</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="lblPLAPuustolaji" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Puuston ikä</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="lblKHIPuustonIka" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Puuston pituus</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="lblKHITaimistonValtapituus" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td class="view2columnsHeader1">Yksikköhinta</td>
            <td class="view2columnsContentElement1">
              <asp:Label ID="lblKHIYksikkkohinta" runat="server"></asp:Label></td>
            <td class="view2columnsHeader2">Korvausyksikkö</td>
            <td class="view2columnsContentElement2">
              <asp:Label ID="lblYKSKorvausyksikko" runat="server"></asp:Label></td>
          </tr>
        </table>
      </div>
      <div class="headerBar">
        <h1>Korvauslaskelman rivi</h1>
      </div>
      <table class="form">
        <tr>
          <td class="formHeader">Kuvion numero
          <uc3:Infopallura ID="ifpKLRKuvionTunnus" runat="server" Kentta="KLRKuvionTunnus"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKLRKuvionTunnus" runat="server" MaxLength="4" SkinID="Numeric"></asp:TextBox></td>
        </tr>
        <asp:PlaceHolder ID="phPintaAla" runat="server" Visible="false">
          <tr>
            <td class="formHeader" style="padding-top: 40px;">Pinta-ala
            </td>
            <td class="formValidation"></td>
            <td class="formInputElement">
              <table cellpadding="0" cellspacing="0">
                <tr>
                  <td class="formHeader" colspan="1" style="text-align: left; width: 80px;">Kuvion pituus (m)
                    <uc3:Infopallura ID="ifpKLRKuvionPituus" runat="server" Kentta="KLRKuvionPituus"></uc3:Infopallura>
                  </td>
                  <td class="formHeader" colspan="1" style="text-align: left; width: 80px;">Kuvion leveys (m)
                    <uc3:Infopallura ID="ifpKLRKuvionLeveys" runat="server" Kentta="KLRKuvionLeveys"></uc3:Infopallura>
                  </td>
                  <td class="formHeader" colspan="1" style="text-align: left; width: 80px;">Pinta-ala (<asp:Label ID="lblPintaAlaYksikko" runat="server"></asp:Label>)
                    <uc3:Infopallura ID="ifpKLRKokonaispintaAla" runat="server" Kentta="KLRKokonaispintaAla"></uc3:Infopallura>
                  </td>
                </tr>
                <tr>
                  <td style="padding-right: 29px;">
                    <asp:CompareValidator Display="None" ControlToValidate="txtKLRKuvionPituus" ID="ComValKLRKuvionPituus" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Kuvion pituus (m): anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
                    <asp:TextBox onkeyup="laskePintaala()" ID="txtKLRKuvionPituus" runat="server" Text="" MaxLength="50" SkinID="Short"></asp:TextBox></td>
                  <td style="padding-right: 29px;">
                    <asp:CompareValidator Display="None" ControlToValidate="txtKLRKuvionLeveys" ID="ComValKLRKuvionLeveys" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Kuvion leveys (m): anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
                    <asp:TextBox onkeyup="laskePintaala()" ID="txtKLRKuvionLeveys" runat="server" Text="" MaxLength="50" SkinID="Short"></asp:TextBox></td>
                  <td style="padding-right: 29px;">
                    <asp:CompareValidator Display="None" ControlToValidate="txtKLRKokonaispintaAla" ID="ComValKLRKokonaispintaAla" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Pinta-ala: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
                    <asp:TextBox ID="txtKLRKokonaispintaAla" runat="server" Text="" MaxLength="10" SkinID="Short" Enabled="false"></asp:TextBox>
                    <asp:HiddenField ID="hfYKSKerroin" runat="server"></asp:HiddenField>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td class="formHeader">Korvattava leveys
          <uc3:Infopallura ID="ifpKLRKuvionKorvattavaLeveys" runat="server" Kentta="KLRKuvionKorvattavaLeveys"></uc3:Infopallura>
            </td>
            <td class="formValidation">
              <asp:CompareValidator Display="None" ControlToValidate="txtKLRKuvionKorvattavaLeveys" ID="ComValKLRKuvionKorvattavaLeveys" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Korvattava leveys: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
            </td>
            <td class="formInputElement">
              <asp:TextBox ID="txtKLRKuvionKorvattavaLeveys" runat="server" MaxLength="10" SkinID="Numeric"></asp:TextBox></td>
          </tr>
        </asp:PlaceHolder>
        <tr>
          <td class="formHeader">Yksikköhinta
          <uc3:Infopallura ID="ifpKLRYksikkohinta" runat="server" Kentta="KLRYksikkohinta"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKLRYksikkohinta" ID="ComValKLRYksikkohinta" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Yksikköhinta: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKLRYksikkohinta" runat="server" MaxLength="10" Enabled="false" SkinID="Numeric"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="formHeader">Määrä
          <uc3:Infopallura ID="ifpKLRMaara" runat="server" Kentta="KLRMaara"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKLRMaara" ID="ComValKLRMaara" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Määrä: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKLRMaara" runat="server" MaxLength="18" SkinID="Numeric"></asp:TextBox>
            <asp:Button ID="btLaskeMaaraPintaalasta" OnClientClick="return laskeKorvattavaPintaala()" runat="server" Text="Laske korvattavasta pinta-alasta" CausesValidation="False" Visible="false" />
          </td>
        </tr>
        <tr>
          <td class="formHeader">Korvaus
          <uc3:Infopallura ID="ifpKLRKorvaus" runat="server" Kentta="KLRKorvaus"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKLRKorvaus" ID="ComValKLRKorvaus" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Korvaus: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKLRKorvaus" runat="server" MaxLength="10" SkinID="Numeric"></asp:TextBox>
            <asp:Button ID="btnLaskeKorvaus" OnClientClick="return laskeKorvaus();" runat="server" Text="Laske korvaus" CausesValidation="False" />
            <asp:Label ID="lblProsenttiKorvaus" runat="server" Text="Korvaus lasketaan muiden korvausten perusteella" Visible="false"></asp:Label>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Lisätieto
          <uc3:Infopallura ID="ifpKLRInfo" runat="server" Kentta="KLRInfo"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKLRInfo" runat="server"></asp:TextBox></td>
        </tr>
        <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
          <tr>
            <td colspan="3" class="formSeparatorHeader">Tiliöintitiedot</td>
          </tr>
          <tr>
            <td class="formHeader">Kirjanpidon tili
          <uc3:Infopallura ID="ifpKLRKirjanpidonTiliId" runat="server" Kentta="KLRKirjanpidonTiliId"></uc3:Infopallura>
            </td>
            <td class="formValidation"></td>
            <td class="formInputElement">
              <asp:DropDownList ID="ddKLRKirjanpidonTiliId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
          </tr>
          <tr>
            <td class="formHeader">Kirjanpidon kustannuspaikka
          <uc3:Infopallura ID="ifpKLRKirjanpidonKustannuspaikkaId" runat="server" Kentta="KLRKirjanpidonKustannuspaikkaId"></uc3:Infopallura>
            </td>
            <td class="formValidation"></td>
            <td class="formInputElement">
              <asp:DropDownList ID="ddKLRKirjanpidonKustannuspaikkaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
          </tr>
          <tr>
            <td class="formHeader">Inv/Cost
          <uc3:Infopallura ID="ifpKLRInvCostId" runat="server" Kentta="KLRInvCostId"></uc3:Infopallura>
            </td>
            <td class="formValidation"></td>
            <td class="formInputElement">
              <asp:DropDownList ID="ddKLRInvCostId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList></td>
          </tr>
        </asp:PlaceHolder>
      </table>
    </asp:Panel>
    <table class="form">
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True" Visible="false" />
          <asp:Button ID="btTallennaJaLisaaUusi" runat="server" Text="Tallenna ja lisää uusi" CausesValidation="True" Visible="false" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" Visible="true" />
        </td>
      </tr>
    </table>
  </div>

  <script language="javascript" type="text/javascript">

    function laskePintaala() {
      var pituus = $("#<%=txtKLRKuvionPituus.ClientID%>").val();
      var leveys = $("#<%=txtKLRKuvionLeveys.ClientID%>").val();
      var kerroin = $("#<%=hfYKSKerroin.ClientID%>").val();

      if (pituus != null) pituus = parseFloat(pituus.replace(',', '.'));
      if (leveys != null) leveys = parseFloat(leveys.replace(',', '.'));
      if (kerroin != null) kerroin = parseFloat(kerroin.replace(',', '.'));

      try {
        var summa = pituus * leveys * kerroin;
        if (!isNaN(summa)) {
          $("#<%=txtKLRKokonaispintaAla.ClientID%>").val(summa.toFixed(3).replace('.', ','));
        }
      }
      catch (ex) {
        $("#<%=txtKLRKokonaispintaAla.ClientID%>").val("");
      }
    }

    function laskeKorvattavaPintaala() {
      var pituus = $("#<%=txtKLRKuvionPituus.ClientID%>").val();
      var leveys = $("#<%=txtKLRKuvionKorvattavaLeveys.ClientID%>").val();
      var kerroin = $("#<%=hfYKSKerroin.ClientID%>").val();

      if (pituus != null) pituus = parseFloat(pituus.replace(',', '.'));
      if (leveys != null) leveys = parseFloat(leveys.replace(',', '.'));
      if (kerroin != null) kerroin = parseFloat(kerroin.replace(',', '.'));

      try {
        var summa = pituus * leveys * kerroin;
        if (!isNaN(summa)) {
          $("#<%=txtKLRMaara.ClientID%>").val(summa.toFixed(3).replace('.', ','));
        }
      }
      catch (ex) {
        $("#<%=txtKLRMaara.ClientID%>").val("");
      }
      return false;
    }

    function laskeKorvaus() {
      var maara = $("#<%=txtKLRMaara.ClientID%>").val();
      var hinta = $("#<%=txtKLRYksikkohinta.ClientID%>").val();

      if (maara != null) maara = parseFloat(maara.replace(',', '.'));
      if (hinta != null) hinta = parseFloat(hinta.replace(',', '.'));

      try {
        var summa = maara * hinta;
        if (!isNaN(summa)) {
          $("#<%=txtKLRKorvaus.ClientID%>").val(summa.toFixed(2).replace('.', ','));
        }
      }
      catch (ex) {
        $("#<%=txtKLRKorvaus.ClientID%>").val("");
      }
      return false;
    }

    $(document).ready(function () {
      laskePintaala();
    });

  </script>

</asp:Content>
