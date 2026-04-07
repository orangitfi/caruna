Namespace Konversiot

  Public Class SopimusarkistoLoki

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.SopimusarkistoLoki)) As List(Of Entities.SopimusarkistoLoki)

      Dim tulokset = New List(Of Entities.SopimusarkistoLoki)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.SopimusarkistoLoki) As Entities.SopimusarkistoLoki

      Dim tulos As New Entities.SopimusarkistoLoki()

      tulos.SALTunnistetyyppi = muunnettava.Tunnistetyyppi
      tulos.SALTunniste = muunnettava.Tunniste
      tulos.SALOperaatio = muunnettava.Operaatio
      tulos.SALTulos = muunnettava.Tulos
      tulos.SALLuoja = muunnettava.Luoja
      tulos.SALLuotu = muunnettava.Luotu

      Return tulos

    End Function

  End Class

End Namespace