Imports appSopimusrekisteri.Liittymat.Sharepoint
Imports System.Net
Imports System.IO
Imports KT.Utils

Namespace Liittymat.Sopimusarkisto

  Public Class Operaatiot

    Friend Shared _konteksti As New DTO.DataKonteksti("Sopimusarkisto")
    Private Shared _testiMoodi As Boolean = False

    Public Shared Function HaeSopimuksenTiedostot(sopimustunnus As Integer) As Tiedosto()

      Dim pyynto As New Listat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)
      pyynto.Testi = _testiMoodi

      Dim objHakuehdot As New SopimusHakuehdot()

      objHakuehdot.SopRek_tunnus = sopimustunnus

      Dim objKysely As New Kysely(Of SopimusHakuehdot)(objHakuehdot)

      Dim objVastaus As Vastaus(Of Tiedosto) = pyynto.HaeObjektit(Of Tiedosto, SopimusHakuehdot)(Konfiguraatiot.SopimusarkistoListaId, Konfiguraatiot.SopimusarkistoNakymaId, objKysely, New NakymaKentat(), New KyselyAsetukset())

      If objVastaus.Ok Then

        If objVastaus.Objektit.Length > 0 Then

          TeeLoki("Sopimustunnus", sopimustunnus, "Haku", "OK")

          Return objVastaus.Objektit

        Else

          TeeLoki("Sopimustunnus", sopimustunnus, "Haku", "Tunnuksella ei löydy sopimusta")

        End If

      Else

        TeeLoki("Sopimustunnus", sopimustunnus, "Haku", objVastaus.Virheilmoitus)

      End If

      Return Nothing

    End Function

    Public Shared Function PaivitaSopimus(sopimus As Tiedosto) As Tiedosto

      Dim pyynto As New Listat(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana, Konfiguraatiot.SopimusarkistoHeratysUrl)
      pyynto.Testi = _testiMoodi

      Dim objVastaus As Vastaus(Of Tiedosto) = pyynto.Paivita(Of Tiedosto)(Konfiguraatiot.SopimusarkistoListaId, sopimus)

      If objVastaus.Ok Then

        TeeLoki("ID", sopimus.ID.GetValueOrDefault(0), "Päivitys", "OK")

        Return objVastaus.Objekti
      Else

        TeeLoki("ID", sopimus.ID.GetValueOrDefault(0), "Päivitys", objVastaus.Virheilmoitus)

        Return Nothing
      End If

    End Function

    Public Shared Sub PaivitaSopimus(id As Integer, konteksti As DTO.DataKonteksti)

      Dim tietokanta As New BLL.Sopimus(konteksti)
      Dim objSopimus As DTO.Sopimus = tietokanta.HaeSopimusDTO(id)

      Dim objSopimusarkistonTiedosto As New Tiedosto()

      objSopimusarkistonTiedosto = TaytaSopimusarkistonTiedosto(objSopimusarkistonTiedosto, objSopimus)

      objSopimusarkistonTiedosto = PaivitaSopimus(objSopimusarkistonTiedosto)

    End Sub

    Public Shared Sub TeeLoki(tunnistetyyppi As String, tunniste As String, operaatio As String, tulos As String)

      Dim objSopimusarkistoLoki As New DTO.SopimusarkistoLoki()

      objSopimusarkistoLoki.Tunnistetyyppi = tunnistetyyppi
      objSopimusarkistoLoki.Tunniste = tunniste
      objSopimusarkistoLoki.Operaatio = operaatio
      objSopimusarkistoLoki.Tulos = tulos

      Dim tietokanta As New BLL.SopimusarkistoLoki(_konteksti)

      If Not _testiMoodi Then
        tietokanta.LisaaLoki(objSopimusarkistoLoki)
      End If

    End Sub

    Public Shared Sub PaivitaSopimuksenTiedostot(sopimusId As Integer, konteksti As DTO.DataKonteksti)

      Dim tietokanta As New BLL.Sopimus(konteksti)
      Dim objSopimus As DTO.Sopimus = tietokanta.HaeSopimusDTO(sopimusId)

      Dim objSopimusarkistonTiedostot As Tiedosto()
      Dim objTiedosto As DTO.Tiedosto

      objSopimusarkistonTiedostot = HaeSopimuksenTiedostot(objSopimus.Id)

      If Not objSopimusarkistonTiedostot Is Nothing Then

        For Each objSopimusarkistonTiedosto As Tiedosto In objSopimusarkistonTiedostot

          If Not objSopimus.TiedostoHaettu Then

            objSopimus.TiedostoHaettu = True

          End If

          If Not objSopimus.Tiedostot.Where(Function(x) x.SharepointId.HasValue AndAlso (x.SharepointId.Value = objSopimusarkistonTiedosto.ID.Value)).Any() Then
            objTiedosto = TeeTiedosto(objSopimusarkistonTiedosto, objSopimus)

            Dim tietokantaTiedosto As New BLL.Tiedosto(_konteksti)

            If Not _testiMoodi Then
              tietokantaTiedosto.LisaaTiedosto(objTiedosto)
            End If
          End If

          objSopimusarkistonTiedosto = TaytaSopimusarkistonTiedosto(objSopimusarkistonTiedosto, objSopimus)

          objSopimusarkistonTiedosto = PaivitaSopimus(objSopimusarkistonTiedosto)

          If Not objSopimusarkistonTiedosto Is Nothing Then
            objSopimus.MetatiedotPaivitetty = True
          End If

        Next

        If Not _testiMoodi Then
          tietokanta.MuokkaaSopimusta(objSopimus)
        End If

      End If

    End Sub

    Public Shared Sub PaivitaSopimusarkisto()

      Dim tietokanta As New BLL.Sopimus(_konteksti)

      Dim tietokantaAputiedot = New appSopimusrekisteri.BLL.Haku()

      Dim sopimukset As DTO.Sopimus() = tietokanta.HaeSopimusarkistoonPaivitettavatSopimukset()

      Dim objSopimusarkistonTiedostot As Tiedosto()
      Dim objTiedosto As DTO.Tiedosto

      For Each objSopimus As DTO.Sopimus In sopimukset

        objSopimusarkistonTiedostot = HaeSopimuksenTiedostot(objSopimus.Id)

        If Not objSopimusarkistonTiedostot Is Nothing Then

          For Each objSopimusarkistonTiedosto As Tiedosto In objSopimusarkistonTiedostot

            objSopimusarkistonTiedosto.TaytaOletusTiedot()

            If Not objSopimus.TiedostoHaettu Then

              objSopimus.TiedostoHaettu = True

            End If

            If Not objSopimus.Tiedostot.Where(Function(x) x.SharepointId.HasValue AndAlso (x.SharepointId.Value = objSopimusarkistonTiedosto.ID.Value)).Any() Then
              objTiedosto = TeeTiedosto(objSopimusarkistonTiedosto, objSopimus)

              Dim tietokantaTiedosto As New BLL.Tiedosto(_konteksti)

              If Not _testiMoodi Then
                tietokantaTiedosto.LisaaTiedosto(objTiedosto)
              End If
            End If

            objSopimusarkistonTiedosto = TaytaSopimusarkistonTiedosto(objSopimusarkistonTiedosto, objSopimus)

            objSopimusarkistonTiedosto = PaivitaSopimus(objSopimusarkistonTiedosto)

            If Not objSopimusarkistonTiedosto Is Nothing Then
              objSopimus.MetatiedotPaivitetty = True
            End If

            If Not _testiMoodi Then
              tietokanta.MuokkaaSopimusta(objSopimus)
            End If

          Next

        End If

      Next


    End Sub

    Private Shared Function TaytaSopimusarkistonTiedosto(sopimusarkistonTiedosto As Tiedosto, sopimus As DTO.Sopimus) As Tiedosto

      'objSopimusarkistonTiedosto.Asiakirjatarkenne 
      'objSopimusarkistonTiedosto.XSopimuksen_x0020_kohde

      sopimusarkistonTiedosto.Projektitunnus_x0020__x002f__x0020_Nimi = sopimus.PCSNumero
      sopimusarkistonTiedosto.Alkupvm = sopimus.Alkupvm
      sopimusarkistonTiedosto.Irtisanomispvm = sopimus.Irtisanomispvm
      sopimusarkistonTiedosto.Paattymispvm = sopimus.Paattymispvm
      sopimusarkistonTiedosto.XMuu_x0020_tunnus = sopimus.MuuTunniste
      sopimusarkistonTiedosto.Sopimusvuosi = sopimus.Sopimusvuosi
      sopimusarkistonTiedosto.Yhti_x00f6__Juridinen = sopimus.JuridinenYhtioNimi
      sopimusarkistonTiedosto.XLuottamuksellisuus = sopimus.Julkisuusaste
      sopimusarkistonTiedosto.Mappitunniste = sopimus.Mappitunniste

      If Not sopimus.Kiinteistot Is Nothing Then

        sopimusarkistonTiedosto.Kiinteist_x00f6_tunnus = Taulukot.YhdistaTaulukko(sopimus.Kiinteistotunnukset, ",")
        sopimusarkistonTiedosto.Kunta = Taulukot.YhdistaTaulukko(sopimus.Kunnat, ",")
        sopimusarkistonTiedosto.Kyl_x00e4_ = Taulukot.YhdistaTaulukko(sopimus.Kylat, ",")
        sopimusarkistonTiedosto.Rekisterinumero0 = Taulukot.YhdistaTaulukko(sopimus.Rekisterinumerot, ",")
        sopimusarkistonTiedosto.Tilan_x0020_nimi = Taulukot.YhdistaTaulukko(sopimus.Tilat, ",")

      End If

      If Not sopimus.Tahot Is Nothing Then
        sopimusarkistonTiedosto.Sopimusosapuolet = Taulukot.YhdistaTaulukko(sopimus.Sopimusosapuolet, ",")
      End If

      If Not sopimus.Tunnisteyksikot Is Nothing Then
        sopimusarkistonTiedosto.XSopimuksen_x0020_kohde = Taulukot.YhdistaTaulukko(sopimus.Kohteet, ",")
      End If

      Return sopimusarkistonTiedosto

    End Function

    Private Shared Function TeeTiedosto(sopimusarkistonTiedosto As Tiedosto, sopimus As DTO.Sopimus) As DTO.Tiedosto

      Dim objTiedosto As New DTO.Tiedosto()
      objTiedosto.SopimusId = sopimus.Id
      objTiedosto.Url = sopimusarkistonTiedosto.ServerUrl
      objTiedosto.SharepointId = sopimusarkistonTiedosto.ID
      objTiedosto.Nimi = sopimusarkistonTiedosto.LinkFilename
      objTiedosto.DocumentId = sopimusarkistonTiedosto.DocumentID
      objTiedosto.AsiakirjaTarkenne = sopimusarkistonTiedosto.Asiakirjatarkenne

      Return objTiedosto

    End Function

    Public Shared Function HaeTiedosto(url As String) As Byte()

      Dim client As New WebClient()

      If Not String.IsNullOrEmpty(Konfiguraatiot.ServiceTunnus) And Not String.IsNullOrEmpty(Konfiguraatiot.ServiceTunnusSalasana) Then
        client.Credentials = New NetworkCredential(Konfiguraatiot.ServiceTunnus, Konfiguraatiot.ServiceTunnusSalasana)
      Else
        client.Credentials = CredentialCache.DefaultCredentials
      End If

      Return client.DownloadData(url)

    End Function

    Public Shared Function LueTiedosto(tiedosto As Sopimusrekisteri.BLL_CF.Tiedosto) As Byte()

      Dim polku As String = IOUtils.CombinePaths(Konfiguraatiot.SopimusarkistoUrl, tiedosto.URL)

      If File.Exists(polku) Then

        Return File.ReadAllBytes(polku)

      End If

      Return Nothing

    End Function

  End Class

End Namespace
