Namespace Konversiot

  Public Class Tunnisteyksikko

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Tunnisteyksikko)) As List(Of DTO.Tunnisteyksikko)

      Dim tulokset = New List(Of DTO.Tunnisteyksikko)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Tunnisteyksikko) As DTO.Tunnisteyksikko

      Dim tulos As New DTO.Tunnisteyksikko()

      tulos.Id = muunnettava.TUYId
      tulos.Nimi = muunnettava.TUYNimi
      tulos.Tunnus = muunnettava.TUYTunnus
      tulos.SopimusId = muunnettava.TUYSopimusId
      tulos.PGTunnus = muunnettava.TUYPGTunnus

      tulos.TyyppiId = muunnettava.TUYTunnisteyksikkoTyyppiId
      If Not muunnettava.hlp_TunnisteyksikkoTyyppi Is Nothing Then
        tulos.Tyyppi = muunnettava.hlp_TunnisteyksikkoTyyppi.TTYTunnisteYksikkoTyyppi
      End If

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Tunnisteyksikko)) As List(Of Entities.Tunnisteyksikko)

      Dim tulokset = New List(Of Entities.Tunnisteyksikko)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Tunnisteyksikko) As Entities.Tunnisteyksikko

      Dim tulos As New Entities.Tunnisteyksikko()

      If muunnettava.Id.HasValue Then
        tulos.TUYId = muunnettava.Id.Value
      End If

      tulos.TUYNimi = muunnettava.Nimi
      tulos.TUYTunnus = muunnettava.Tunnus
      tulos.TUYSopimusId = muunnettava.SopimusId
      tulos.TUYPGTunnus = muunnettava.PGTunnus

      Return tulos

    End Function

  End Class

End Namespace
