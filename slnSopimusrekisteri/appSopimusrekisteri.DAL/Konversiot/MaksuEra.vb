Namespace Konversiot

  Public Class MaksuEra

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Maksuaineisto)) As List(Of DTO.MaksuEra)

      Dim tulokset = New List(Of DTO.MaksuEra)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Maksuaineisto) As DTO.MaksuEra

      Dim tulos As New DTO.MaksuEra()

      tulos.Tunniste = muunnettava.MAIId

      Return tulos

    End Function

  End Class

End Namespace