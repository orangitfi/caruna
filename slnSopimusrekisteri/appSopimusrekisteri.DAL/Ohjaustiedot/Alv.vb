Public Class Alv

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As DTO.Alv

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Alv.MuutaDTOksi(tietokanta.hlp_Alv.FirstOrDefault(Function(x) x.ALVId = id))

    End Using

  End Function

  Public Function Hae() As List(Of DTO.Alv)

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Alv.MuutaDTOksi(tietokanta.hlp_Alv)

    End Using

  End Function

  Public Function HaeOletusAlv() As DTO.Alv

    Using tietokanta As New Entities.FortumEntities()

      Dim alv As Entities.hlp_Alv = tietokanta.hlp_Alv.FirstOrDefault(Function(x) x.ALVOletus = True)

      If Not alv Is Nothing Then

        Return Konversiot.Alv.MuutaDTOksi(alv)

      End If

      Return Nothing

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(alv As DTO.Alv) As DTO.Alv

    If alv Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava As Entities.hlp_Alv = Konversiot.Alv.MuutaDBOksi(alv)

      tietokanta.hlp_Alv.Add(lisattava)
      tietokanta.SaveChanges()

      Return Konversiot.Alv.MuutaDTOksi(lisattava)

    End Using

  End Function

  Public Function Muokkaa(alv As DTO.Alv) As DTO.Alv

    If alv Is Nothing Then
      Return Nothing
    Else
      If Not alv.Id.HasValue Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattu As Entities.hlp_Alv = Konversiot.Alv.MuutaDBOksi(alv)

      Dim muokattava = tietokanta.hlp_Alv.FirstOrDefault(Function(x) x.ALVId = muokattu.ALVId)

      muokattu.ALVLuotu = muokattava.ALVLuotu
      muokattu.ALVLuoja = muokattava.ALVLuoja

      If Not muokattava Is Nothing Then

        tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

        tietokanta.SaveChanges()

        Return Konversiot.Alv.MuutaDTOksi(muokattava)

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As DTO.Alv

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.hlp_Alv.FirstOrDefault(Function(x) x.ALVId = id)

      If Not poistettava Is Nothing Then

        tietokanta.hlp_Alv.Remove(poistettava)
        tietokanta.SaveChanges()

        Return Konversiot.Alv.MuutaDTOksi(poistettava)

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
