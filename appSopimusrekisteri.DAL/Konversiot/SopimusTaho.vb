Namespace Konversiot

  Public Class SopimusTaho

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Sopimus_Taho)) As List(Of DTO.SopimusTaho)

      Dim tulokset = New List(Of DTO.SopimusTaho)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Sopimus_Taho) As DTO.SopimusTaho

      Dim tulos = New DTO.SopimusTaho()

      tulos.AsiakastyyppiId = muunnettava.SOTAsiakastyyppiId
      If Not muunnettava.hlp_Asiakastyyppi Is Nothing Then
        tulos.Asiakastyyppi = muunnettava.hlp_Asiakastyyppi.ATYAsiakastyyppi
      End If

      tulos.DFRooliId = muunnettava.SOTDFRooliId
      tulos.TulostetaanSopimukseen = muunnettava.SOTTulostetaanSopimukseen

      Return tulos

    End Function

  End Class

End Namespace
