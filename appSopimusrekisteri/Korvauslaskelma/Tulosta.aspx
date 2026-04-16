<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Tulosta.aspx.vb" Inherits="appSopimusrekisteri.TulostaKorvauslaskelmanTiedot" %>

<html class="print">
<head>
  <title></title>
  <style type="text/css">
    body {
      margin: 0px;
      padding-right: 20px;
      padding-left: 20px;
      background-color: white;
      color: black;
      font-family: Verdana, Geneva, Arial, Helvetica, sans-serif;
      font-size: 10pt;
    }

    h1 {
      font-size: 12pt;
      text-transform: uppercase;
    }

    .info {
      font-size: 12pt;
      margin-top: 20pt;
      margin-bottom: 20pt;
    }

    @media print {
      body {
        padding-right: 0px;
        padding-left: 0px;
      }

      .no-print, .no-print * {
        display: none !important;
      }
    }

    fieldset {
      padding: 5pt 20pt 15px 20pt;
      background-color: white;
      border: 1pt solid black;
      /*border-radius: 10px;*/
      /*box-shadow: 0 2pt 4pt -2pt gray;*/
    }

    legend {
      padding: 0pt 5pt 0pt 5pt;
      background-color: white;
      font-size: 10pt;
      font-weight: bold;
      text-transform: uppercase;
    }

    table {
      font-size: 8pt;
      width: 100%;
      min-width: 100%;
    }

    thead td {
      font-weight: bold;
      text-transform: uppercase;
    }

    td {
      vertical-align: top;
      padding-bottom: 5pt;
      padding-right: 5pt;
      /*border-bottom:1px solid black;*/
    }

      td.right {
        text-align: right;
        white-space: nowrap;
      }
  </style>
</head>
<body>

  <form id="form1" runat="server">

    <div class="info no-print">
      Olet tulostamassa alla näkyvää korvauslaskelmaa. Klikkaa
      <asp:HyperLink ID="hlTakaisin" runat="server">tästä</asp:HyperLink>
      palataksesi takaisin.
    </div>

    <h1>
      <asp:Literal ID="litKorvauslaskelmanTiedot" runat="server"></asp:Literal></h1>

    <fieldset>
      <legend>Korvauksen saaja</legend>
      <table>
        <thead>
          <tr>
            <td colspan="2"></td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td style="width: 40%">
              <asp:Literal ID="litSaaja" runat="server"></asp:Literal>
              <br />
            </td>
            <td style="width: 60%">
              <asp:Repeater ID="rptKiinteistot" runat="server">
                <HeaderTemplate>
                  <table>
                      <tr>
                        <td>Tila</td>
                        <td>Kiinteistötunnus</td>
                        <td>Osoite</td>
                      </tr>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                  <tr>
                    <td><%# Left(Eval("Nimi"), 60) %></td>
                    <td><%# Eval("LyhytKiinteistotunnus") %></td>
                    <td><%# Eval("Osoite") %>, <%# Eval("Postinumero") %> <%# Eval("Postitoimipaikka") %></td>
                  </tr>
                </ItemTemplate>
                <FooterTemplate>
                  </tbody>
                </table>
                </FooterTemplate>
              </asp:Repeater>
            </td>
          </tr>
        </tbody>
      </table>
    </fieldset>
    <br />

    <fieldset>
      <legend>Korvauslaskelman perusteet</legend>
      <asp:Repeater ID="repKorvauslaskelmanRivit" runat="server">
        <HeaderTemplate>
          <table>
            <thead>
              <tr>
                <td>Korvauslaji</td>
                <td class="right">Lisätietoja</td>
                <td class="right">Määrä</td>
                <td class="right">Yksikköhinta</td>
                <td class="right">Korvaus</td>
              </tr>
            </thead>
            <tbody>
        </HeaderTemplate>
        <ItemTemplate>
          <tr>
            <td>
              <asp:Literal ID="litKorvauslaji" runat="server" Text='<%# Bind("Korvauslaji") %>' />
              (<asp:Literal ID="litKuvaus" runat="server" Text='<%# Bind("Kuvaus") %>' />)
                                <br />
              <asp:Literal ID="litArvonPerusta" runat="server" Text='<%# Bind("ArvonPeruste")%>' />
            </td>
            <td class="right">
              <asp:Literal ID="litLisatieto" runat="server" Text='<%# Bind("Lisatieto")%>' />
            </td>
            <td class="right">
              <asp:Literal ID="litMaara" runat="server" Text='<%# Bind("Maara", "{0:f2}")%>' />
              <asp:Literal ID="litKorvausyksikko" runat="server" />
            </td>
            <td class="right">
              <asp:Literal ID="litYksikkohinta" runat="server" Text='<%# Bind("Yksikkohinta", "{0:f2}") %>' />
              <asp:Literal ID="litKorvausyksikonKuvaus" runat="server" />
            </td>
            <td class="right">
              <asp:Literal ID="litKorvaus" runat="server" Text='<%# Bind("Korvaus", "{0:f2}")%>' /></td>
          </tr>
        </ItemTemplate>
        <FooterTemplate>
          <%--<tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td class="right"><b><asp:Literal ID="litSumma" runat="server"></asp:Literal></b></td>
                        </tr>--%>
                    </tbody>
                </table>
        </FooterTemplate>
      </asp:Repeater>
    </fieldset>
    <br />

    <fieldset>
      <legend>Korvauslaskelman tiedot</legend>
      <table>
        <thead>
          <tr>
            <td>Päiväys</td>
            <td>Laatija</td>
            <td class="right">Summa</td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <asp:Literal ID="litPaivays" runat="server"></asp:Literal></td>
            <td>
              <asp:Literal ID="litLaatija" runat="server"></asp:Literal></td>
            <td class="right">
              <asp:Literal ID="litSumma" runat="server"></asp:Literal></td>
          </tr>
        </tbody>
      </table>
    </fieldset>
    <br />

  </form>

</body>
</html>
