Namespace Konversiot

  Public Class Indeksi

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.hlp_Indeksi)) As List(Of DTO.Indeksi)

      Dim tulokset = New List(Of DTO.Indeksi)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.hlp_Indeksi) As DTO.Indeksi

      Dim tulos As New DTO.Indeksi()

      tulos.Id = muunnettava.IKDId
      tulos.IndeksityyppiId = muunnettava.IKDIndeksityyppiId

      If Not muunnettava.hlp_Indeksityyppi Is Nothing Then
        tulos.Tyyppi = muunnettava.hlp_Indeksityyppi.ITYIndeksityyppi
      End If

      tulos.KuukausiId = muunnettava.IKDKuukausiId

      If Not muunnettava.hlps_Kuukausi Is Nothing Then
        tulos.Kuukausi = muunnettava.hlps_Kuukausi.KUUKuukausi
      End If

      tulos.Vuosi = muunnettava.IKDVuosi
      tulos.Arvo = muunnettava.IKDArvo
      tulos.Luoja = muunnettava.IKDLuoja
      tulos.Luotu = muunnettava.IKDLuotu
      tulos.Paivittaja = muunnettava.IKDPaivittaja
      tulos.Paivitetty = muunnettava.IKDPaivitetty

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Indeksi)) As List(Of Entities.hlp_Indeksi)

      Dim tulokset = New List(Of Entities.hlp_Indeksi)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Indeksi) As Entities.hlp_Indeksi

      Dim tulos As New Entities.hlp_Indeksi()

      If muunnettava.Id.HasValue Then
        tulos.IKDId = muunnettava.Id
      End If
      tulos.IKDIndeksityyppiId = muunnettava.IndeksityyppiId
      tulos.IKDKuukausiId = muunnettava.KuukausiId
      tulos.IKDVuosi = muunnettava.Vuosi
      tulos.IKDArvo = muunnettava.Arvo
      tulos.IKDLuoja = muunnettava.Luoja
      If muunnettava.Luotu.HasValue Then
        tulos.IKDLuotu = muunnettava.Luotu
      End If
      tulos.IKDPaivittaja = muunnettava.Paivittaja
      If muunnettava.Paivitetty.HasValue Then
        tulos.IKDPaivitetty = muunnettava.Paivitetty
      End If

      Return tulos

    End Function

  End Class

End Namespace