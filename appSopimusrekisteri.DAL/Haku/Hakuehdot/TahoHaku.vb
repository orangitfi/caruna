Imports System.Linq.Expressions

Public Class TahoHaku

  Public Shared Function HaeTahoExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Taho, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Taho), "taho")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeTahoEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Taho, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeTahoEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Taho)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Taho)
    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.TahoTyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHTyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHTahoId)
      Case pDTO.HaePropertyNimi(Function(x) x.Etunimi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHEtunimi)
      Case pDTO.HaePropertyNimi(Function(x) x.Sukunimi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHSukunimi)
      Case pDTO.HaePropertyNimi(Function(x) x.Ytunnus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHYtunnus)
      Case pDTO.HaePropertyNimi(Function(x) x.Osoite)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPostitusosoite)
      Case pDTO.HaePropertyNimi(Function(x) x.Postinumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPostituspostinro)
      Case pDTO.HaePropertyNimi(Function(x) x.Postitoimipaikka)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPostituspostitmp)
      Case pDTO.HaePropertyNimi(Function(x) x.Puhelin)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPuhelin)
      Case pDTO.HaePropertyNimi(Function(x) x.Email)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHEmail)
      Case pDTO.HaePropertyNimi(Function(x) x.Tilinumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHTilinumero)
      Case pDTO.HaePropertyNimi(Function(x) x.BicKoodiMuu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHBic)
      Case pDTO.HaePropertyNimi(Function(x) x.OrganisaationTyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHOrganisaationTyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.Luoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHLuoja)
      Case pDTO.HaePropertyNimi(Function(x) x.Luotu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHLuotu)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivittaja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPaivittaja)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivitetty)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.TAHPaivitetty)
        hakuKentta.Tyyppi = GetType(Date)
      Case Else
        hakuKentta.Nimi = String.Empty
    End Select

    Return hakuKentta

  End Function

End Class
