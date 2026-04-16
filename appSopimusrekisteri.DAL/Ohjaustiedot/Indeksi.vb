Partial Public Class Indeksi

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As DTO.Indeksi

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Indeksi.MuutaDTOksi(tietokanta.hlp_Indeksi.FirstOrDefault(Function(x) x.IKDId = id))

    End Using

  End Function

  Public Function Hae() As List(Of DTO.Indeksi)

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Indeksi.MuutaDTOksi(tietokanta.hlp_Indeksi)

    End Using

  End Function

  Public Function HaeVuodenIndeksit(vuosi As Integer) As List(Of DTO.Indeksi)

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Indeksi.MuutaDTOksi(tietokanta.hlp_Indeksi.Where(Function(x) x.IKDVuosi = vuosi)).ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(indeksi As DTO.Indeksi) As DTO.Indeksi

    If indeksi Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava As Entities.hlp_Indeksi = Konversiot.Indeksi.MuutaDBOksi(indeksi)

      tietokanta.hlp_Indeksi.Add(lisattava)
      tietokanta.SaveChanges()

      Return Konversiot.Indeksi.MuutaDTOksi(lisattava)

    End Using

  End Function

  Public Function Muokkaa(indeksi As DTO.Indeksi) As DTO.Indeksi

    If indeksi Is Nothing Then
      Return Nothing
    Else
      If Not indeksi.Id.HasValue Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattu As Entities.hlp_Indeksi = Konversiot.Indeksi.MuutaDBOksi(indeksi)

      Dim muokattava = tietokanta.hlp_Indeksi.FirstOrDefault(Function(x) x.IKDId = muokattu.IKDId)

      muokattu.IKDLuotu = muokattava.IKDLuotu
      muokattu.IKDLuoja = muokattava.IKDLuoja

      If Not muokattava Is Nothing Then

        tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

        tietokanta.SaveChanges()

        Return Konversiot.Indeksi.MuutaDTOksi(muokattava)

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As DTO.Indeksi

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.hlp_Indeksi.FirstOrDefault(Function(x) x.IKDId = id)

      If Not poistettava Is Nothing Then

        tietokanta.hlp_Indeksi.Remove(poistettava)
        tietokanta.SaveChanges()

        Return Konversiot.Indeksi.MuutaDTOksi(poistettava)

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
