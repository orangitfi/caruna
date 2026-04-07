Imports System.Linq.Expressions

Public Class KorvauslaskelmaRiviHaku

  Public Shared Function HaeKorvauslaskelmaRiviExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.KorvauslaskelmaRivi, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.KorvauslaskelmaRivi), "korvauslaskelmaRivi")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeKorvauslaskelmaRiviEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.KorvauslaskelmaRivi, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeKorvauslaskelmaRiviEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.KorvauslaskelmanRivi)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.KorvauslaskelmaRivi)
    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRId)
      Case pDTO.HaePropertyNimi(Function(x) x.KorvauslaskelmaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKorvauslaskelmaId)
      Case pDTO.HaePropertyNimi(Function(x) x.KorvaushinnastoId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKorvaushinnastoId)
      Case pDTO.HaePropertyNimi(Function(x) x.Korvaus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKorvaus)
      Case pDTO.HaePropertyNimi(Function(x) x.KuvionTunnus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKuvionTunnus)
      Case pDTO.HaePropertyNimi(Function(x) x.KuvionPituus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKuvionPituus)
      Case pDTO.HaePropertyNimi(Function(x) x.KuvionLeveys)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKuvionLeveys)
      Case pDTO.HaePropertyNimi(Function(x) x.KuvionKorvattavaLeveys)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKuvionKorvattavaLeveys)
      Case pDTO.HaePropertyNimi(Function(x) x.KokonaisPintaAla)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKokonaispintaAla)
      Case pDTO.HaePropertyNimi(Function(x) x.Maara)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRMaara)
      Case pDTO.HaePropertyNimi(Function(x) x.Lisatieto)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRInfo)
      Case pDTO.HaePropertyNimi(Function(x) x.Yksikkohinta)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRYksikkohinta)
      Case pDTO.HaePropertyNimi(Function(x) x.KirjanpidonTiliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKirjanpidonTiliId)
      Case pDTO.HaePropertyNimi(Function(x) x.KustannuspaikkaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRKirjanpidonKustannuspaikkaId)
      Case pDTO.HaePropertyNimi(Function(x) x.InvCostId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRInvCostId)
      Case pDTO.HaePropertyNimi(Function(x) x.RegulationId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRRegulationId)
      Case pDTO.HaePropertyNimi(Function(x) x.PurposeId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRPurposeId)
      Case pDTO.HaePropertyNimi(Function(x) x.Local1Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRLocal1Id)
      Case pDTO.HaePropertyNimi(Function(x) x.Luotu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRLuotu)
      Case pDTO.HaePropertyNimi(Function(x) x.Luoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRLuoja)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivitetty)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRPaivitetty)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivittaja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KLRPaivittaja)
      Case Else
        hakuKentta.Nimi = ""
    End Select

    Return hakuKentta

  End Function

End Class
