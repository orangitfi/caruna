Namespace Konversiot

  Public Class Infopallura

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.hlp_Infopallura)) As List(Of DTO.Infopallura)

      Dim tulokset = New List(Of DTO.Infopallura)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.hlp_Infopallura) As DTO.Infopallura

      Dim tulos As New DTO.Infopallura()

      tulos.Id = muunnettava.IFPId
      tulos.Lomake = muunnettava.IFPLomake
      tulos.Kentta = muunnettava.IFPKentta
      tulos.Teksti = muunnettava.IFPTeksti

      tulos.Luoja = muunnettava.IFPLuoja
      tulos.Luotu = muunnettava.IFPLuotu
      tulos.Paivittaja = muunnettava.IFPPaivittaja
      tulos.Paivitetty = muunnettava.IFPPaivitetty

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Infopallura)) As List(Of Entities.hlp_Infopallura)

      Dim tulokset = New List(Of Entities.hlp_Infopallura)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Infopallura) As Entities.hlp_Infopallura

      Dim tulos As New Entities.hlp_Infopallura()

      If muunnettava.Id.HasValue Then
        tulos.IFPId = muunnettava.Id
      End If

      tulos.IFPLomake = muunnettava.Lomake
      tulos.IFPKentta = muunnettava.Kentta
      tulos.IFPTeksti = muunnettava.Teksti

      tulos.IFPLuoja = muunnettava.Luoja
      If muunnettava.Luotu.HasValue Then
        tulos.IFPLuotu = muunnettava.Luotu
      End If
      tulos.IFPPaivittaja = muunnettava.Paivittaja
      If muunnettava.Paivitetty.HasValue Then
        tulos.IFPPaivitetty = muunnettava.Paivitetty
      End If

      Return tulos

    End Function

  End Class

End Namespace