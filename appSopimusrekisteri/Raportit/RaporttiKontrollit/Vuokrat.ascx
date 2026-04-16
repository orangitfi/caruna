<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Vuokrat.ascx.vb" Inherits="appSopimusrekisteri.RaporttiKontrollit.Vuokrat" %>

<%@ Register Assembly="appSopimusrekisteri" Namespace="appSopimusrekisteri.GeneralControls" TagPrefix="uc" %>

<table class="form" cellspacing="0" cellpadding="0">
  <tbody>
    <tr>
      <td class="formHeader">Sopimustyyppi</td>
      <td class="formValidation"></td>
      <td class="formInputElement">
        <asp:DropDownList ID="SopimustyyppiId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Korvaustyyppi</td>
      <td class="formValidation"></td>
      <td class="formInputElement">
        <asp:DropDownList ID="KorvaustyyppiId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td class="formHeader">Maksukuukausi</td>
      <td class="formValidation"></td>
      <td class="formInputElement">
        <asp:DropDownList ID="MaksukuukausiId" runat="server" DataTextField="Nimi" DataValueField="Id"></asp:DropDownList>
      </td>
    </tr>
  </tbody>
</table>

<div id="reportContainer" runat="server" visible="false">
  <table class="listGridview" cellpadding="3" cellspacing="0">
    <thead>
      <tr>
        <th>Yhtiö</th>
        <th>Sopimustyyppi</th>
        <th>Sopimusnro</th>
        <th>Muu tunniste</th>
        <th>Alkupvm</th>
        <th>Päättymispvm</th>
        <th>Irtisanomispvm</th>
        <th>Jatkoaika</th>
        <th>Irtisanomisaika</th>
        <th>Korvaustyyppi</th>
        <th>Korvaussumma</th>
        <th>Korvaussumma sis. alv</th>
        <th>Vuosivuokra</th>
        <th>Maksuun menevä summa sis. alv</th>
        <th>Maksukuukausi</th>
        <th>Indeksityyppi</th>
        <th>Sopimushetken indeksi</th>
        <th>Indeksivuosi</th>
        <th>Indeksikuukausi</th>
        <th>Viimeisin indeksi</th>
        <th>Status</th>
        <th>Ensimmäinen sallittu maksupvm</th>
        <th>Saajan etunimi</th>
        <th>Saajan sukunimi</th>
        <th>Alkuperäinen osapuoli</th>
        <th>Kiinteistötunnus</th>
        <th>Kiinteistön kunta</th>
      </tr>
    </thead>
    <tbody>
      <asp:ListView ID="lstReport" runat="server">
        <ItemTemplate>
          <tr>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Yhtio) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Sopimustyyppi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Sopimusnro) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_MuuTunniste) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Alkupvm, "{0:dd.MM.yyyy}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Paattymispvm, "{0:dd.MM.yyyy}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Irtisanomispvm, "{0:dd.MM.yyyy}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Jatkoaika) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Irtisanomisaika) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Korvaustyyppi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Korvaussumma, "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_KorvaussummaSisAlv, "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Vuosivuokra, "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_MaksuunMenevaSumma, "{0:F}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Maksukuukausi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Indeksityyppi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_SopimushetkenIndeksi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Indeksivuosi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Indeksikuukausi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_ViimeisinIndeksi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Status) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_EnsimmainenSallittuMaksupvm, "{0:dd.MM.yyyy}") %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_SaajanEtunimi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_SaajanSukunimi) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_AlkuperainenOsapuoli) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_Kiinteistotunnus) %></td>
            <td><%#DataBinder.Eval(Container.DataItem, Col_KiinteistonKunta) %></td>
          </tr>
        </ItemTemplate>
      </asp:ListView>
    </tbody>
  </table>
</div>
