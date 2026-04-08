Namespace Konversiot

  Public Class Alv

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.hlp_Alv)) As List(Of DTO.Alv)

      Dim tulokset = New List(Of DTO.Alv)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.hlp_Alv) As DTO.Alv

      Dim tulos As New DTO.Alv()

      tulos.Id = muunnettava.ALVId
      tulos.Prosentti = muunnettava.ALVProsentti
      tulos.Oletus = muunnettava.ALVOletus

      tulos.Luoja = muunnettava.ALVLuoja
      tulos.Luotu = muunnettava.ALVLuotu
      tulos.Paivittaja = muunnettava.ALVPaivittaja
      tulos.Paivitetty = muunnettava.ALVPaivitetty

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Alv)) As List(Of Entities.hlp_Alv)

      Dim tulokset = New List(Of Entities.hlp_Alv)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Alv) As Entities.hlp_Alv

      Dim tulos As New Entities.hlp_Alv()

      If muunnettava.Id.HasValue Then
        tulos.ALVId = muunnettava.Id
      End If
      tulos.ALVProsentti = muunnettava.Prosentti

      tulos.ALVOletus = muunnettava.Oletus

      tulos.ALVLuoja = muunnettava.Luoja
      If muunnettava.Luotu.HasValue Then
        tulos.ALVLuotu = muunnettava.Luotu
      End If
      tulos.ALVPaivittaja = muunnettava.Paivittaja
      If muunnettava.Paivitetty.HasValue Then
        tulos.ALVPaivitetty = muunnettava.Paivitetty
      End If

      Return tulos

    End Function

  End Class

End Namespace
