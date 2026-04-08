
Public Class Kayttajienhallinta

  Public Function HaeKaikkiRyhmat() As List(Of Entities.aspnet_RoleGroups)

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.HaeRyhmat()

  End Function

  Public Function HaeRyhmanRoolit(ryhma As String) As List(Of Entities.aspnet_Roles)

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.HaeRyhmanRoolit(ryhma)

  End Function

  Public Function HaeRyhmanKayttajat(ryhma As String) As List(Of Entities.aspnet_Users)

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.HaeRyhmanKayttajat(ryhma)

  End Function

  Public Function HaeKayttajanRyhmanimet(kayttaja As String) As List(Of String)

    Return Me.HaeKayttajanRyhmat(kayttaja).Select(Function(x) x.GroupName).ToList()

  End Function

  Public Function HaeKayttajanRyhmat(kayttaja As String) As List(Of Entities.aspnet_RoleGroups)

    Dim tietokanta = New DAL.KayttajaRyhmat()

    Return tietokanta.HaeKayttajanRyhmat(kayttaja)

  End Function

  Public Function OnkoRyhmallaRooli(ryhma As String, rooli As String) As Boolean

    Dim roolit As List(Of Entities.aspnet_Roles) = Me.HaeRyhmanRoolit(ryhma)

    Dim booTulos As Boolean = False

    For Each r As Entities.aspnet_Roles In roolit

      If r.RoleName = rooli Then
        booTulos = True
        Exit For
      End If

    Next

    Return booTulos
  End Function

  Public Function TallennaRyhma(ryhma As Entities.aspnet_RoleGroups) As Entities.aspnet_RoleGroups

    Dim tietokanta = New DAL.KayttajaRyhmat()
    If ryhma.GroupId = Guid.Empty Then
      Return tietokanta.LuoRyhma(ryhma)
    Else
      Return tietokanta.TallennaRyhma(ryhma)
    End If

  End Function

  Public Function PoistaRyhma(ryhma As Guid) As Boolean

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.PoistaRyhma(ryhma)

  End Function

  Public Function LisaaRooliRyhmiin(rooli As String, ryhmat As List(Of String)) As Boolean

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.LisaaRooliRyhmiin(rooli, ryhmat)

  End Function

  Public Function PoistaRooliRyhmista(rooli As String, ryhmat As List(Of String)) As Boolean

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.PoistaRooliRyhmista(rooli, ryhmat)

  End Function

  Public Function LisaaKayttajatRyhmaan(kayttajat As List(Of String), ryhmatunnus As Guid) As List(Of Entities.aspnet_Roles)

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.LisaaKayttajatRyhmaan(kayttajat, ryhmatunnus)

  End Function

  Public Function PoistaKayttajaRyhmasta(kayttaja As String, ryhmatunnus As Guid) As List(Of Entities.aspnet_Roles)

    Return Me.PoistaKayttajatRyhmasta({kayttaja}.ToList(), ryhmatunnus)

  End Function

  Public Function PoistaKayttajatRyhmasta(kayttajat As List(Of String), ryhmatunnus As Guid) As List(Of Entities.aspnet_Roles)

    Dim tietokanta = New DAL.KayttajaRyhmat()
    Return tietokanta.PoistaKayttajatRyhmasta(kayttajat, ryhmatunnus)

  End Function

End Class
