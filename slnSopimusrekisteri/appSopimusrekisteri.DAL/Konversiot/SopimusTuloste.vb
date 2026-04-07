Namespace Konversiot

  Public Class SopimusTuloste

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Sopimus_Tuloste)) As List(Of DTO.SopimusTuloste)

      Dim tulokset = New List(Of DTO.SopimusTuloste)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Sopimus_Tuloste) As DTO.SopimusTuloste

      Dim tulos As New DTO.SopimusTuloste()

      tulos.Id = muunnettava.STLId
      tulos.SopimusId = muunnettava.STLSopimusId
      tulos.Tuloste = muunnettava.STLTuloste
      tulos.Luoja = muunnettava.STLLuoja
      tulos.Luotu = muunnettava.STLLuotu
      tulos.Paivittaja = muunnettava.STLPaivittaja
      tulos.Paivitetty = muunnettava.STLPaivitetty

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.SopimusTuloste)) As List(Of Entities.Sopimus_Tuloste)

      Dim tulokset = New List(Of Entities.Sopimus_Tuloste)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.SopimusTuloste) As Entities.Sopimus_Tuloste

      Dim tulos As New Entities.Sopimus_Tuloste()

      If muunnettava.Id.HasValue Then
        tulos.STLId = muunnettava.Id.Value
      End If

      tulos.STLSopimusId = muunnettava.SopimusId
      tulos.STLTuloste = muunnettava.Tuloste
      tulos.STLLuoja = muunnettava.Luoja
      tulos.STLLuotu = muunnettava.Luotu
      tulos.STLPaivittaja = muunnettava.Paivittaja
      tulos.STLPaivitetty = muunnettava.Paivitetty

      Return tulos

    End Function

  End Class

End Namespace
