Imports appSopimusrekisteri.DTO
Imports appSopimusrekisteri.Entities

Public Class Aktiviteetti

#Region "Hakumetodit"

  Public Function HaeAktiviteetti(id As Integer) As DTO.Aktiviteetti
    Using tietokanta As New Entities.FortumEntities()
      Dim aktiviteetti As DTO.Aktiviteetti
      Dim haettava = tietokanta.Aktiviteetti.FirstOrDefault(Function(x) x.AKId = id)
      aktiviteetti = Konversiot.Aktiviteetti.MuutaDTOksi(haettava)
      If Not IsNothing(aktiviteetti.TahoId) Then
        aktiviteetti.Taho = Konversiot.Taho.MuutaDTOksi(haettava.Taho)
      End If
      If Not IsNothing(aktiviteetti.SopimusId) Then
        aktiviteetti.Sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus)
      End If
      Return aktiviteetti
    End Using
  End Function

  Public Function HaeSopimuksenAktiviteetit(sopimusId As Integer) As List(Of DTO.Aktiviteetti)
    Using tietokanta As New Entities.FortumEntities()
      Dim aktiviteetit = tietokanta.Aktiviteetti.Where(Function(x) x.AKTSopimusId = sopimusId).ToList().Select(Function(x) HaeAktiviteetti(x.AKId)).ToList()
      Return aktiviteetit
    End Using
  End Function

  Public Function HaeKayttajanAktiviteetit(kayttajaGuid As Guid) As List(Of DTO.Aktiviteetti)
    Using tietokanta As New Entities.FortumEntities()
      Dim aktiviteetit = tietokanta.Aktiviteetti.Where(Function(x) x.AKKontaktoijaId = kayttajaGuid).ToList().Select(Function(x) HaeAktiviteetti(x.AKId)).ToList()
      Return aktiviteetit
    End Using
  End Function


#End Region

#Region "Muokkausmetodit"

  Public Function LisaaAktiviteetti(ByVal aktiviteetti As DTO.Aktiviteetti) As DTO.Aktiviteetti
    If aktiviteetti Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()
      Dim lisattava As Entities.Aktiviteetti = Konversiot.Aktiviteetti.MuutaDBOksi(aktiviteetti)

      Try
        tietokanta.Aktiviteetti.Add(lisattava)
        tietokanta.SaveChanges()

        Return Konversiot.Aktiviteetti.MuutaDTOksi(lisattava)
      Catch ex As Exception
        Throw
      End Try
    End Using
  End Function

  Public Function MuokkaaAktiviteettia(ByVal aktiviteetti As DTO.Aktiviteetti) As DTO.Aktiviteetti
    Using tietokanta As New Entities.FortumEntities()

      Dim muokattava = tietokanta.Aktiviteetti.FirstOrDefault(Function(x) x.AKId = aktiviteetti.Id)
      Dim muokattu As Entities.Aktiviteetti = Konversiot.Aktiviteetti.MuutaDBOksi(aktiviteetti, muokattava)

      If Not muokattava Is Nothing Then
        Try
          tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)
          tietokanta.SaveChanges()
          Return Konversiot.Aktiviteetti.MuutaDTOksi(muokattava)
        Catch ex As Exception
          Throw
        End Try
      Else
        Return Nothing
      End If
    End Using
  End Function


#End Region

End Class
