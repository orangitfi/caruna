Imports System.Net
Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers
Imports KT.Utils
Imports System.IO
Imports System.Transactions
Imports appSopimusarkistoSiirto.Liittymat.Tiedostoraportti

Namespace Liittymat.Sopimusarkisto

  Public Class SopimusarkistoClient

    Private _dataContext As Sopimusrekisteri.DAL_CF.KiltaDataContext
    Private _handlers As HandlerContext
    Private _testiMoodi As Boolean = Konfiguraatiot.TestiMoodi

    Public Sub New()

    End Sub

    Public Function HaeTiedostot() As IEnumerable(Of LevyTiedosto)

      Dim tiedostot As New List(Of LevyTiedosto)()

      Dim dInfo As New DirectoryInfo(Konfiguraatiot.SopimusarkistoPolkuUudet)

      For Each tiedosto As FileInfo In dInfo.GetFiles()

        If tiedosto.Length > 0 Then
          tiedostot.Add(New LevyTiedosto(tiedosto.FullName))
        End If

      Next

      Return tiedostot

    End Function

    Public Sub TeeSopimuksenTiedostot(sopimusarkistonTiedosto As LevyTiedosto)

      Dim tiedosto As Sopimusrekisteri.BLL_CF.Tiedosto

      If sopimusarkistonTiedosto.SopimusId.HasValue Then

        Dim sopimus As Sopimus = Me.Handlers.Sopimukset.LoadEntityOrNull(sopimusarkistonTiedosto.SopimusId.Value)

        If Not sopimus Is Nothing Then

          Try

            Me.MuodostaTiedostonKansioPolku(sopimusarkistonTiedosto, sopimus)

            tiedosto = Me.TeeTiedosto(sopimusarkistonTiedosto, sopimus)

            Using scope As New TransactionScope()

              Me.Handlers.Tiedostot.SaveEntity(tiedosto)

              Me.SiirraTiedosto(sopimusarkistonTiedosto)

              Me.LisaaRaporttiRivi(sopimusarkistonTiedosto, sopimus)

              scope.Complete()

            End Using

          Catch ex As Exception

            Me.TeeLoki("SopimusId", sopimusarkistonTiedosto.SopimusId.ToString() & " " & sopimusarkistonTiedosto.Nimi, "Käsittely", ex.Message & " " & ex.StackTrace)

          End Try

        Else

          Me.TeeLoki("SopimusId", sopimusarkistonTiedosto.SopimusId.ToString() & " " & sopimusarkistonTiedosto.Nimi, "Haku", "Sopimusta ei löytynyt rekisteristä")

        End If

      Else

        Me.TeeLoki("Tiedostonimi", sopimusarkistonTiedosto.Nimi, "Haku", "Sopimustunnusta ei löytynyt tiedostonimestä")

      End If

    End Sub

    Private Sub LisaaRaporttiRivi(tiedosto As LevyTiedosto, sopimus As Sopimus)

      Dim raportti As New Raportti(Konfiguraatiot.TiedostoraporttiPolku)

      Dim rivi As New Tiedostorivi()

      rivi.Tiedostopolku = tiedosto.UusiKokoPolkuRelatiivinen
      rivi.Linkitetty = Date.Now
      rivi.PcsNro = sopimus.PCSNumero
      rivi.Sopimusosapuolet = sopimus.Asiakkaat.Select(Function(x) x.Taho.Nimi)
      rivi.Kiinteistotunnukset = sopimus.Kiinteistot.Select(Function(x) x.KiinteistotunnusLyhyt)

      raportti.KirjoitaRiviRaporttiin(rivi)

    End Sub

    Private Sub MuodostaTiedostonKansioPolku(tiedosto As LevyTiedosto, sopimus As Sopimus)

      tiedosto.UusiKansioPolkuRelatiivinen = sopimus.Sopimusvuosi.GetValueOrDefault(0).ToString()

    End Sub

    Private Sub SiirraTiedosto(tiedosto As LevyTiedosto)

      Dim polku As String = IOUtils.CombinePaths(Konfiguraatiot.SopimusarkistoPolku, tiedosto.UusiKansioPolkuRelatiivinen)

      If Not Directory.Exists(polku) Then
        Directory.CreateDirectory(polku)
      End If

      File.Move(tiedosto.Polku, IOUtils.CombinePaths(Konfiguraatiot.SopimusarkistoPolku, tiedosto.UusiKokoPolkuRelatiivinen))

    End Sub

    Private Sub TeeLoki(tunnistetyyppi As String, tunniste As String, operaatio As String, tulos As String)

      Dim objSopimusarkistoLoki As New SopimusarkistoLoki()

      objSopimusarkistoLoki.Tunnistetyyppi = tunnistetyyppi
      objSopimusarkistoLoki.Tunniste = tunniste
      objSopimusarkistoLoki.Operaatio = operaatio
      objSopimusarkistoLoki.Tulos = Left(tulos, 2048)

      Me.Handlers.Sopimusarkistot.SaveEntity(objSopimusarkistoLoki)

    End Sub

    Public Sub PaivitaSopimusarkisto()

      Dim tiedostot As IEnumerable(Of LevyTiedosto) = Me.HaeTiedostot()

      For Each tiedosto As LevyTiedosto In tiedostot

        Me.TeeSopimuksenTiedostot(tiedosto)

      Next

    End Sub

    Private Function TeeTiedosto(sopimusarkistonTiedosto As LevyTiedosto, sopimus As Sopimus) As Sopimusrekisteri.BLL_CF.Tiedosto

      Dim objTiedosto As New Sopimusrekisteri.BLL_CF.Tiedosto()

      objTiedosto.SopimusId = sopimus.Id

      objTiedosto.URL = sopimusarkistonTiedosto.UusiKokoPolkuRelatiivinen
      'objTiedosto.SharePointId = sopimusarkistonTiedosto.ID
      objTiedosto.TiedostoNimi = sopimusarkistonTiedosto.Nimi

      objTiedosto.Asiakirjatarkenne = sopimusarkistonTiedosto.Asiakirjatarkenne

      Return objTiedosto

    End Function

    Public ReadOnly Property DataContext As Sopimusrekisteri.DAL_CF.KiltaDataContext
      Get
        If _dataContext Is Nothing Then
          _dataContext = New Sopimusrekisteri.DAL_CF.KiltaDataContext(Konfiguraatiot.ConnectionString, New Kayttooikeustiedot(Konfiguraatiot.Kayttajatunnus))
        End If

        Return _dataContext
      End Get
    End Property

    Public ReadOnly Property Handlers As HandlerContext
      Get
        If _handlers Is Nothing Then
          _handlers = New HandlerContext(Me.DataContext)
        End If

        Return _handlers
      End Get
    End Property

  End Class

End Namespace
