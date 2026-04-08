Namespace Konversiot

  Public Class Kiinteisto

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Kiinteisto)) As List(Of DTO.Kiinteisto)

      Dim tulokset = New List(Of DTO.Kiinteisto)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Kiinteisto) As DTO.Kiinteisto

      Dim tulos = New DTO.Kiinteisto()

      tulos.Id = muunnettava.KIIId
      tulos.Nimi = muunnettava.KIIKiinteisto
      tulos.Osoite = muunnettava.KIIKatuosoite
      tulos.Postinumero = muunnettava.KIIPostinumero
      tulos.Postitoimipaikka = muunnettava.KIIPostitoimipaikka
      tulos.Kyla = muunnettava.KIIKyla
      If Not muunnettava.hlp_Kunta Is Nothing Then
        tulos.Kunta = muunnettava.hlp_Kunta.KKunta
      End If
      tulos.Rekisterinumero = muunnettava.KIIRekisterinumero
      tulos.LyhytKiinteistotunnus = muunnettava.KIIKiinteistotunnusLyhyt
      tulos.KiinteistoTunnus = muunnettava.KIIKiinteistotunnus

      If Not muunnettava.hlp_Maa Is Nothing Then
        tulos.Maa = muunnettava.hlp_Maa.MAANimi
      End If

      tulos.KokonaisPintaAla = muunnettava.KIIPintaAla

      Return tulos

    End Function

  End Class

End Namespace
