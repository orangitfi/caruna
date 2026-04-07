Public Class KayttajaRyhmat

  Private Application As Guid = New Guid("5D1B778A-B9AA-4C82-ABFB-38B7C33E6000")

  Public Function HaeRyhmat() As List(Of Entities.aspnet_RoleGroups)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.aspnet_RoleGroups.ToList()

    End Using

  End Function

  Public Function HaeRyhmanRoolit(ryhma As String) As List(Of Entities.aspnet_Roles)

    Using tietokanta As New Entities.FortumEntities()

      Dim ryhmanRoolit = tietokanta.aspnet_RolesInGroups.Where(Function(x) x.aspnet_RoleGroups.GroupName = ryhma)
      If ryhmanRoolit.Any() Then
        Dim roolienTunnisteet = ryhmanRoolit.Select(Function(x) x.RoleId).ToList()
        Return tietokanta.aspnet_Roles.Where(Function(x) roolienTunnisteet.Contains(x.RoleId)).ToList()
      Else
        Return New List(Of Entities.aspnet_Roles)
      End If

    End Using

  End Function

  Public Function HaeKayttajanRyhmat(kayttaja As String) As List(Of Entities.aspnet_RoleGroups)

    Using tietokanta As New Entities.FortumEntities()

      Dim kayttajanTiedot = tietokanta.aspnet_Users.FirstOrDefault(Function(x) x.UserName = kayttaja)
      If Not kayttajanTiedot Is Nothing Then
        Dim kayttajatunnus = kayttajanTiedot.UserId

        Return tietokanta.aspnet_UsersInGroups.Where(Function(x) x.UserId = kayttajatunnus).Select(Function(x) x.aspnet_RoleGroups).ToList()
      Else
        Return New List(Of Entities.aspnet_RoleGroups)
      End If

    End Using

  End Function

  Public Function HaeRyhmanKayttajat(ryhma As String) As List(Of Entities.aspnet_Users)

    Using tietokanta As New Entities.FortumEntities()

      Dim ryhmanKayttajat = tietokanta.aspnet_UsersInGroups.Where(Function(x) x.aspnet_RoleGroups.GroupName = ryhma)
      If Not ryhmanKayttajat Is Nothing Then
        Dim kayttajienTunnisteet = ryhmanKayttajat.Select(Function(x) x.UserId).ToList()
        Return tietokanta.aspnet_Users.Where(Function(x) kayttajienTunnisteet.Contains(x.UserId)).ToList()
      Else
        Return New List(Of Entities.aspnet_Users)
      End If

    End Using

  End Function

  Public Function PoistaRooliRyhmasta(rooli As String, ryhma As String) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Dim roolitunnus = HaeRoolinTunniste(rooli)
      Dim ryhmatunnus = HaeRyhmanTunniste(ryhma)
      Dim poistettava = tietokanta.aspnet_RolesInGroups.Where(Function(x) x.RoleId = roolitunnus And x.GroupId = ryhmatunnus)
      tietokanta.aspnet_RolesInGroups.Remove(poistettava.FirstOrDefault())
      tietokanta.SaveChanges()

    End Using

  End Function

  Public Function LisaaRooliRyhmaan(rooli As String, ryhma As String) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Dim roolitunnus = HaeRoolinTunniste(rooli)
      Dim ryhmatunnus = HaeRyhmanTunniste(ryhma)

      If tietokanta.aspnet_RolesInGroups.Any(Function(x) x.RoleId = roolitunnus And x.GroupId = ryhmatunnus) Then
        Return False
      End If

      Dim liitos = New Entities.aspnet_RolesInGroups()
      liitos.RoleId = roolitunnus
      liitos.GroupId = ryhmatunnus
      tietokanta.aspnet_RolesInGroups.Add(liitos)
      tietokanta.SaveChanges()

      Return True

    End Using

  End Function

  Private Function HaeKayttajanTunniste(kayttaja As String) As Guid

    Using tietokanta As New Entities.FortumEntities()

      Dim kayttajanTiedot = tietokanta.aspnet_Users.FirstOrDefault(Function(x) x.UserName = kayttaja)
      If Not kayttajanTiedot Is Nothing Then
        Return kayttajanTiedot.UserId
      Else
        Return Guid.Empty
      End If

    End Using

  End Function


  Private Function HaeRoolinTunniste(rooli As String) As Guid

    Using tietokanta As New Entities.FortumEntities()

      Dim roolinTiedot = tietokanta.aspnet_Roles.FirstOrDefault(Function(x) x.RoleName = rooli)
      If Not roolinTiedot Is Nothing Then
        Return roolinTiedot.RoleId
      Else
        Return Guid.Empty
      End If

    End Using

  End Function

  Private Function HaeRyhmanTunniste(ryhma As String) As Guid

    Using tietokanta As New Entities.FortumEntities()

      Dim ryhmanTiedot = tietokanta.aspnet_RoleGroups.FirstOrDefault(Function(x) x.GroupName = ryhma)
      If Not ryhmanTiedot Is Nothing Then
        Return ryhmanTiedot.GroupId
      Else
        Return Guid.Empty
      End If

    End Using

  End Function

  Public Function LuoRyhma(ryhma As Entities.aspnet_RoleGroups) As Entities.aspnet_RoleGroups

    If ryhma Is Nothing Then
      Return Nothing
    Else
      If ryhma.GroupId <> Guid.Empty Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      ' Varmistetaan, että kahta samannimistä ryhmää ei voi luoda!
      If tietokanta.aspnet_RoleGroups.Count(Function(x) x.GroupName = ryhma.GroupName) <> 0 Then
        Return Nothing
      End If

      ryhma.GroupId = Guid.NewGuid()
      ryhma.Description = String.Empty
      ryhma.ApplicationId = Application
      ryhma.LoweredGroupName = ryhma.GroupName.ToLower()
      tietokanta.aspnet_RoleGroups.Add(ryhma)
      tietokanta.SaveChanges()

    End Using

    Return ryhma

  End Function


  Public Function TallennaRyhma(ryhma As Entities.aspnet_RoleGroups) As Entities.aspnet_RoleGroups

    If ryhma Is Nothing Then
      Return Nothing
    Else
      If ryhma.GroupId = Guid.Empty Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      ' Varmistetaan, että kahta samannimistä ryhmää ei voi luoda!
      If tietokanta.aspnet_RoleGroups.Count(Function(x) x.GroupName = ryhma.GroupName) <> 1 Then
        Return Nothing
      End If

      Dim muokattava = tietokanta.aspnet_RoleGroups.FirstOrDefault(Function(x) x.GroupId = ryhma.GroupId)

      If Not muokattava Is Nothing Then

        muokattava.Description = String.Empty
        muokattava.ApplicationId = Application
        muokattava.LoweredGroupName = ryhma.GroupName.ToLower()
        muokattava.GroupName = ryhma.GroupName
        tietokanta.SaveChanges()

      End If

    End Using

    Return Nothing

  End Function

  Public Function PoistaRyhma(ryhma As Guid) As Boolean

    If ryhma = Guid.Empty Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        Dim kayttajaliitokset = tietokanta.aspnet_UsersInGroups.Where(Function(x) x.RoleGroupId = ryhma)
        For Each kayttajaliitos In kayttajaliitokset
          tietokanta.aspnet_UsersInGroups.Remove(kayttajaliitos)
        Next

        Dim rooliliitokset = tietokanta.aspnet_RolesInGroups.Where(Function(x) x.GroupId = ryhma)
        For Each rooliliitos In rooliliitokset
          tietokanta.aspnet_RolesInGroups.Remove(rooliliitos)
        Next

        Dim poistettavaRyhma = tietokanta.aspnet_RoleGroups.Where(Function(x) x.GroupId = ryhma).FirstOrDefault()
        tietokanta.aspnet_RoleGroups.Remove(poistettavaRyhma)

        tietokanta.SaveChanges()
        transaktio.Complete()
        Return True

      End Using

    End Using

  End Function

  Public Function LisaaRooliRyhmiin(rooli As String, ryhmat As List(Of String)) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        For Each ryhma As String In ryhmat

          LisaaRooliRyhmaan(rooli, ryhma)



        Next

        transaktio.Complete()
        Return True

      End Using

    End Using

  End Function

  Public Function PoistaRooliRyhmista(rooli As String, ryhmat As List(Of String)) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        For Each ryhma As String In ryhmat

          'Dim ryhmatunniste = HaeRyhmanTunniste(ryhma)
          'Dim liitos = tietokanta.aspnet_RolesInGroups.Where(Function(x) x.GroupId = ryhmatunniste And x.RoleId = roolitunniste)
          'tietokanta.aspnet_RolesInGroups.Remove(liitos)
          'tietokanta.SaveChanges()
          PoistaRooliRyhmasta(rooli, ryhma)

        Next

        transaktio.Complete()
        Return True

      End Using

    End Using

  End Function

  Public Function LisaaKayttajatRyhmaan(kayttajat As List(Of String), ryhmatunnus As Guid) As List(Of Entities.aspnet_Roles)

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        For Each kayttaja As String In kayttajat
          LisaaKayttajaRyhmaan(kayttaja, ryhmatunnus)
        Next

        transaktio.Complete()

      End Using

    End Using

    ' Move this to BLL.
    Using tietokanta As New Entities.FortumEntities()

      Dim roolit = tietokanta.aspnet_Roles.Where(Function(x) x.aspnet_RolesInGroups.Any(Function(y) y.GroupId = ryhmatunnus)).ToList()
      Return roolit

    End Using

  End Function

  Public Function PoistaKayttajatRyhmasta(kayttajat As List(Of String), ryhmatunnus As Guid) As List(Of Entities.aspnet_Roles)

    Using tietokanta As New Entities.FortumEntities()

      Using transaktio As New Transactions.TransactionScope()

        For Each kayttaja As String In kayttajat
          PoistaKayttajaRyhmasta(kayttaja, ryhmatunnus)
        Next

        transaktio.Complete()

      End Using

    End Using

    ' Move this to BLL.
    Using tietokanta As New Entities.FortumEntities()

      Dim roolit = tietokanta.aspnet_Roles.Where(Function(x) x.aspnet_RolesInGroups.Any(Function(y) y.GroupId = ryhmatunnus)).ToList()
      Return roolit

    End Using

  End Function


  Public Function LisaaKayttajaRyhmaan(kayttaja As String, ryhmatunnus As Guid) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Dim kayttajatunnus = HaeKayttajanTunniste(kayttaja)

      If tietokanta.aspnet_UsersInGroups.Any(Function(x) x.RoleGroupId = ryhmatunnus And x.UserId = kayttajatunnus) Then
        Return False
      End If

      Dim liitos = New Entities.aspnet_UsersInGroups()
      liitos.RoleGroupId = ryhmatunnus
      liitos.UserId = kayttajatunnus
      tietokanta.aspnet_UsersInGroups.Add(liitos)

      tietokanta.SaveChanges()

    End Using

  End Function


  Public Function PoistaKayttajaRyhmasta(kayttaja As String, ryhmatunnus As Guid) As Boolean

    Using tietokanta As New Entities.FortumEntities()

      Dim kayttajatunnus = HaeKayttajanTunniste(kayttaja)
      Dim poistettava = tietokanta.aspnet_UsersInGroups.Where(Function(x) x.UserId = kayttajatunnus And x.RoleGroupId = ryhmatunnus).FirstOrDefault()

      If Not poistettava Is Nothing Then

        tietokanta.aspnet_UsersInGroups.Remove(poistettava)
        tietokanta.SaveChanges()

      End If

    End Using

  End Function

End Class
