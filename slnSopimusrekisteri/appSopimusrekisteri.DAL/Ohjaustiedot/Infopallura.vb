Partial Public Class Infopallura

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As DTO.Infopallura

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Infopallura.MuutaDTOksi(tietokanta.hlp_Infopallura.FirstOrDefault(Function(x) x.IFPId = id))

    End Using

  End Function

  Public Function Hae() As List(Of DTO.Infopallura)

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Infopallura.MuutaDTOksi(tietokanta.hlp_Infopallura)

    End Using

  End Function

  Public Function HaeLomakkeenPallurat(lomake As String) As List(Of DTO.Infopallura)

    Using tietokanta As New Entities.FortumEntities()

      Return Konversiot.Infopallura.MuutaDTOksi(tietokanta.hlp_Infopallura.Where(Function(x) x.IFPLomake = lomake)).ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(infopallura As DTO.Infopallura) As DTO.Infopallura

    If infopallura Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim lisattava As Entities.hlp_Infopallura = Konversiot.Infopallura.MuutaDBOksi(infopallura)

      tietokanta.hlp_Infopallura.Add(lisattava)
      tietokanta.SaveChanges()

      Return Konversiot.Infopallura.MuutaDTOksi(lisattava)

    End Using

  End Function

  Public Function Muokkaa(infopallura As DTO.Infopallura) As DTO.Infopallura

    If infopallura Is Nothing Then
      Return Nothing
    Else
      If Not infopallura.Id.HasValue Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim muokattu As Entities.hlp_Infopallura = Konversiot.Infopallura.MuutaDBOksi(infopallura)

      Dim muokattava = tietokanta.hlp_Infopallura.FirstOrDefault(Function(x) x.IFPId = muokattu.IFPId)

      muokattu.IFPLuotu = muokattava.IFPLuotu
      muokattu.IFPLuoja = muokattava.IFPLuoja

      If Not muokattava Is Nothing Then

        tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

        tietokanta.SaveChanges()

        Return Konversiot.Infopallura.MuutaDTOksi(muokattava)

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As DTO.Infopallura

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.hlp_Infopallura.FirstOrDefault(Function(x) x.IFPId = id)

      If Not poistettava Is Nothing Then

        tietokanta.hlp_Infopallura.Remove(poistettava)
        tietokanta.SaveChanges()

        Return Konversiot.Infopallura.MuutaDTOksi(poistettava)

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
