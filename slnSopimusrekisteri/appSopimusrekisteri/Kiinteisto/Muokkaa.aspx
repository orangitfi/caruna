<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Muokkaa.aspx.vb" Inherits="appSopimusrekisteri.KiinteistonMuokkaus" MasterPageFile="~/Site.Master" Theme="Default" StylesheetTheme="Default" %>


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

  <h1>Kiinteistön tiedot</h1>
  <div class="form">
    <div class="formValidationInfo">
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <div class="formInfo">
    </div>
    <div class="formDateInfo">
      <asp:PlaceHolder ID="phPaivitystiedot" runat="server" Visible="false">
        <b>Päivitetty:</b>&nbsp;
            <asp:Label ID="lblKIIPaivitetty" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKIIPaivittaja" runat="server"></asp:Label>)
            <br />
        <b>Luotu:</b>&nbsp;
            <asp:Label ID="lblKIILuotu" runat="server"></asp:Label>&nbsp;
            (<asp:Label ID="lblKIILuoja" runat="server"></asp:Label>)
      </asp:PlaceHolder>
    </div>
    <table class="form">
      <tr>
        <td class="formHeader">Kiinteistön nimi
          <uc3:Infopallura ID="ifpKIIKiinteisto" runat="server" Kentta="KIIKiinteisto"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKiinteisto" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kiinteistötunnus
          <uc3:Infopallura ID="ifpKIIKiinteistotunnus" runat="server" Kentta="KIIKiinteistotunnus"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:RequiredFieldValidator Display="None" ControlToValidate="txtKIIKiinteistotunnus" ID="rvtxtKIIKiinteistotunnus" runat="server" ErrorMessage="Kiinteistötunnus on vaadittu tieto" />
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKiinteistotunnus" onkeyup="luoLyhytKiinteistotunnus()" runat="server" MaxLength="14" AutoPostBack="True"></asp:TextBox>
        </td>
      </tr>

      <tr>
        <td class="formHeader" style="padding-top: 40px;">Kiinteistötunnus, lyhyt
          <uc3:Infopallura ID="ifpKIIKiinteistotunnusLyhyt" runat="server" Kentta="KIIKiinteistotunnusLyhyt"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKIIKuntanumero" ID="ComValKIIKuntanumero" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Kuntanro: anna kokonaisluku"></asp:CompareValidator><asp:CompareValidator
            Display="None" ControlToValidate="txtKIIKylanumero" ID="ComValKIIKylanumero" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Kylänro: anna kokonaisluku"></asp:CompareValidator><asp:CompareValidator
              Display="None" ControlToValidate="txtKIIKortteli" ID="ComValKIIKortteli" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Kortteli: anna kokonaisluku"></asp:CompareValidator><asp:CompareValidator
                Display="None" ControlToValidate="txtKIITontti" ID="ComValtxtKIITontti" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Tontti: anna kokonaisluku"></asp:CompareValidator>
        </td>
        <td class="formContentElement">
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td class="formHeaderUpper" colspan="2">Kuntanro
                <uc3:Infopallura ID="ifpKIIKuntanumero" runat="server" Kentta="KIIKuntanumero"></uc3:Infopallura>
              </td>
              <td class="formHeaderUpper" colspan="2">Kylänro
                <uc3:Infopallura ID="ifpKIIKylanumero" runat="server" Kentta="KIIKylanumero"></uc3:Infopallura>
              </td>
              <td class="formHeaderUpper" colspan="2">Kortteli
                <uc3:Infopallura ID="ifpKIIKortteli" runat="server" Kentta="KIIKortteli"></uc3:Infopallura>
              </td>
              <td class="formHeaderUpper" colspan="2">Tontti
                <uc3:Infopallura ID="ifpKIITontti" runat="server" Kentta="KIITontti"></uc3:Infopallura>
              </td>
            </tr>
            <tr>
              <td>
                <asp:TextBox ID="txtKIIKuntanumero" runat="server" onkeyup="luoPitkaKiinteistotunnus(this);" MaxLength="3" SkinID="Short" AutoPostBack="True"></asp:TextBox>
              </td>
              <td style="text-align: center; padding-right: 5px;">-</td>
              <td>
                <asp:TextBox ID="txtKIIKylanumero" runat="server" onkeyup="luoPitkaKiinteistotunnus(this);" MaxLength="3" SkinID="Short"></asp:TextBox>
              </td>
              <td style="text-align: center; padding-right: 5px;">-</td>
              <td>
                <asp:TextBox ID="txtKIIKortteli" runat="server" onkeyup="luoPitkaKiinteistotunnus(this);" MaxLength="4" SkinID="Short"></asp:TextBox>
              </td>
              <td style="text-align: center; padding-right: 5px;">-</td>
              <td>
                <asp:TextBox ID="txtKIITontti" runat="server" onkeyup="luoPitkaKiinteistotunnus(this);" MaxLength="4" SkinID="Short"></asp:TextBox>
              </td>
              <td style="text-align: center; padding-right: 5px;"></td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Katuosoite
          <uc3:Infopallura ID="ifpKIIKatuosoite" runat="server" Kentta="KIIKatuosoite"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKatuosoite" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Postinumero
          <uc3:Infopallura ID="ifpKIIPostinumero" runat="server" Kentta="KIIPostinumero"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKIIPostinumero" ID="cmpKIIPostinumero" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Postinumerossa saa olla vain numeroita"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIPostinumero" runat="server" MaxLength="5"></asp:TextBox>
          <asp:Button ID="btnHaePostitoimipaikka" runat="server" Text="Hae postitoimipaikka" CausesValidation="False" />
        </td>
      </tr>
      <tr>
        <td class="formHeader">Postitoimipaikka
          <uc3:Infopallura ID="ifpKIIPostitoimipaikka" runat="server" Kentta="KIIPostitoimipaikka"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIPostitoimipaikka" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kylä
          <uc3:Infopallura ID="ifpKIIKyla" runat="server" Kentta="KIIKyla"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIKyla" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kunta
          <uc3:Infopallura ID="ifpKIIKuntaId" runat="server" Kentta="KIIKuntaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddKIIKuntaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maa
          <uc3:Infopallura ID="ifpKIIMaaId" runat="server" Kentta="KIIMaaId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:DropDownList ID="ddKIIMaaId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
        </td>
      </tr>

      <tr>
        <td class="formHeader">Määräala
          <uc3:Infopallura ID="ifpKIIMaaraAla" runat="server" Kentta="KIIMaaraAla"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIMaaraAla" runat="server" MaxLength="50"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Aluetarkenne
          <uc3:Infopallura ID="ifpKIIAlueTarkenneId" runat="server" Kentta="KIIAlueTarkenneId"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIAlueTarkenne" runat="server" MaxLength="300"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Maapinta-ala (m2)
            <uc3:Infopallura ID="ifpKIIMaapintaAla" runat="server" Kentta="KIIMaapintaAla"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKIIMaapintaAla" ID="ComValKIIMaapintaAla" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Maapinta-ala: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIMaapintaAla" runat="server" MaxLength="18" SkinID="Numeric"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Vesipinta-ala (m2)
            <uc3:Infopallura ID="ifpKIIVesipintaAla" runat="server" Kentta="KIIVesipintaAla"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKIIVesipintaAla" ID="ComValKIIVesipintaAla" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Vesipinta-ala: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIVesipintaAla" runat="server" MaxLength="18" SkinID="Numeric"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td class="formHeader">Kokonaispinta-ala (m2)
            <uc3:Infopallura ID="ifpKIIPintaAla" runat="server" Kentta="KIIPintaAla"></uc3:Infopallura>
        </td>
        <td class="formValidation">
          <asp:CompareValidator Display="None" ControlToValidate="txtKIIPintaAla" ID="ComValKIIPintaAla" Type="Double" Operator="DataTypeCheck" runat="server" ErrorMessage="Kokonaispinta-ala: anna numeerisessa muodossa, desimaalierottimena pilkku"></asp:CompareValidator>
        </td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIPintaAla" runat="server" MaxLength="18" SkinID="Numeric"></asp:TextBox>
        </td>
      </tr>
      <asp:PlaceHolder ID="phLaajaNakyma" runat="server">
        <tr>
          <td class="formHeader">Rasitteet
          <uc3:Infopallura ID="ifpKIIRasitteet" runat="server" Kentta="KIIRasitteet"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIRasitteet" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Kiinnitykset
          <uc3:Infopallura ID="ifpKIIKiinnitykset" runat="server" Kentta="KIIKiinnitykset"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIKiinnitykset" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Kiinteistöverotettu vuosi
          <uc3:Infopallura ID="ifpKIIKiinteistoverotettuVuosi" runat="server" Kentta="KIIKiinteistoverotettuVuosi"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKIIKiinteistoverotettuVuosi" ID="ComValKIIKiinteistoverotettuVuosiVahintaan" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Kiinteistöverotettu vuosi: anna kokonaisluku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIKiinteistoverotettuVuosi" runat="server" MaxLength="4" SkinID="Numeric"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Asset id in Fixed Asset Register
            <uc3:Infopallura ID="ifpKIIAssetTunniste" runat="server" Kentta="KIIAssetTunniste"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <asp:CompareValidator Display="None" ControlToValidate="txtKIIAssetTunniste" ID="ComValKIIAssetTunniste" Type="Integer" Operator="DataTypeCheck" runat="server" ErrorMessage="Asset id in Fixed Asset Register: Anna kokonaisluku"></asp:CompareValidator>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIAssetTunniste" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Omistusosuus
            <uc3:Infopallura ID="ifpKIIOmistusosuus" runat="server" Kentta="KIIOmistusosuus"></uc3:Infopallura>
          </td>
          <td class="formValidation">
            <%--<asp:CompareValidator Display="None" ControlToValidate="txtKIIOmistusosuus" ID="ComValKIIOmistusosuusMin" Type="Double" Operator="GreaterThanEqual" ValueToCompare="1" runat="server" ErrorMessage="Omistusosuus: anna luku väliltä 1-100"></asp:CompareValidator>
            <asp:CompareValidator Display="None" ControlToValidate="txtKIIOmistusosuus" ID="ComValKIIOmistusosuusMax" Type="Double" Operator="LessThanEqual" ValueToCompare="100" runat="server" ErrorMessage="Omistusosuus: anna luku väliltä 1-100"></asp:CompareValidator>--%>
          </td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIOmistusosuus" runat="server" SkinID="Numeric" TextMode="Number"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Omistusosuus total
            <uc3:Infopallura ID="ifpKIIOmistusosuusTotal" runat="server" Kentta="KIIOmistusosuusTotal"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:TextBox ID="txtKIIOmistusosuusTotal" runat="server" SkinID="Numeric" TextMode="Number"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Tarpeellisuus liiketoiminnalle
            <uc3:Infopallura ID="ifpKIILiiketoiminnanTarveId" runat="server" Kentta="KIILiiketoiminnanTarveId"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:DropDownList ID="ddKIILiiketoiminnanTarveId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="formHeader">Sääntö
            <uc3:Infopallura ID="ifpKIISaantoId" runat="server" Kentta="KIISaantoId"></uc3:Infopallura>
          </td>
          <td class="formValidation"></td>
          <td class="formInputElement">
            <asp:DropDownList ID="ddKIISaantoId" runat="server" DataTextField="Nimi" DataValueField="ID"></asp:DropDownList>
          </td>
        </tr>
      </asp:PlaceHolder>
      <tr>
        <td class="formHeader">Lisätietoja
          <uc3:Infopallura ID="ifpKIIInfo" runat="server" Kentta="KIIInfo"></uc3:Infopallura>
        </td>
        <td class="formValidation"></td>
        <td class="formInputElement">
          <asp:TextBox ID="txtKIIInfo" runat="server" SkinID="Info" TextMode="MultiLine"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td colspan="2">&nbsp;</td>
        <td class="formActions">
          <asp:Button ID="btTallenna" runat="server" Text="Tallenna" CausesValidation="True" />
          <asp:Button ID="btPeruuta" runat="server" Text="Peruuta" CausesValidation="False" />
        </td>
      </tr>
    </table>
  </div>

  <script language="javascript" type="text/javascript">

    function luoLyhytKiinteistotunnus() {

      var kiinteistotunnus = $("#<%=txtKIIKiinteistotunnus.ClientID%>").val();

      var regExp = new RegExp(/^$|^\d+$/);
      if (!regExp.test(kiinteistotunnus)) {
        return;
      }

      var seq1 = $("#<%=txtKIIKuntanumero.ClientID%>");
      var seq2 = $("#<%=txtKIIKylanumero.ClientID%>");
      var seq3 = $("#<%=txtKIIKortteli.ClientID%>");
      var seq4 = $("#<%=txtKIITontti.ClientID%>");
      var kuntanumero = ""
      var kylanumero = ""
      var kortteli = ""
      var tontti = ""

      if (kiinteistotunnus.length >= 3) {
        kuntanumero = kiinteistotunnus.substring(0, 3);
        if (kuntanumero == "000") seq1.val("");
        else seq1.val(kuntanumero);
      }
      else {
        seq1.val("");
      }

      if (kiinteistotunnus.length >= 6) {
        kylanumero = kiinteistotunnus.substring(3, 6);
        if (kylanumero == "000") seq2.val("");
        else seq2.val(kylanumero);
      }
      else {
        seq2.val("");
      }

      if (kiinteistotunnus.length >= 10) {
        kortteli = kiinteistotunnus.substring(6, 10);
        if (kortteli == "0000") seq3.val("");
        else seq3.val(parseInt(kortteli, 10));
      }
      else {
        seq3.val("");
      }

      if (kiinteistotunnus.length >= 14) {
        tontti = kiinteistotunnus.substring(10, 14);
        if (tontti == "0000") seq4.val("");
        else seq4.val(parseInt(tontti, 10));
      }
      else {
        seq4.val("");
      }
    }

    function luoPitkaKiinteistotunnus(kentta) {

      var regExp = new RegExp(/^$|^\d+$/);
      if (!regExp.test(kentta.value)) {
        return;
      }

      var kiinteistotunnus = $("#<%=txtKIIKiinteistotunnus.ClientID%>");

      if (kentta.id == "<%=txtKIIKuntanumero.ClientID%>") {
        if (kiinteistotunnus.val().length >= 3) {

          var arvo = kentta.value;
          if (arvo.length == 0) arvo = "000";
          else arvo = ("000" + arvo).slice(-3);

          kiinteistotunnus.val(arvo + kiinteistotunnus.val().slice(3, kiinteistotunnus.val().length));
        }
      }
      else if (kentta.id == "<%=txtKIIKylanumero.ClientID%>") {
        if (kiinteistotunnus.val().length >= 6) {

          var arvo = kentta.value;
          if (arvo.length == 0) arvo = "000";
          else arvo = ("000" + arvo).slice(-3);

          var alkuosa = kiinteistotunnus.val().substring(0, 3);
          var loppuosa = kiinteistotunnus.val().substring(6, kiinteistotunnus.val().length)
          kiinteistotunnus.val(alkuosa + arvo + loppuosa);
        }
      }
      else if (kentta.id == "<%=txtKIIKortteli.ClientID%>") {
        if (kiinteistotunnus.val().length >= 10) {

          var arvo = kentta.value;
          if (arvo.length == 0) arvo = "0000";
          else arvo = ("0000" + arvo).slice(-4);

          var alkuosa = kiinteistotunnus.val().substring(0, 6);
          var loppuosa = kiinteistotunnus.val().substring(10, kiinteistotunnus.val().length)
          kiinteistotunnus.val(alkuosa + arvo + loppuosa);
        }
      }
      else if (kentta.id == "<%=txtKIITontti.ClientID%>") {
        if (kiinteistotunnus.val().length >= 14) {

          var arvo = kentta.value;
          if (arvo.length == 0) arvo = "0000";
          else arvo = ("0000" + arvo).slice(-4);

          var alkuosa = kiinteistotunnus.val().substring(0, 10);
          kiinteistotunnus.val(alkuosa + arvo);
        }
      }
}

  </script>

</asp:Content>
