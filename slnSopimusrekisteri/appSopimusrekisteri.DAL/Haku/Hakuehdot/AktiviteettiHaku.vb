Imports System.Linq.Expressions

Public Class AktiviteettiHaku

  Public Shared Function HaeAktiviteettiExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Aktiviteetti, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Aktiviteetti), "aktiviteetti")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeAktiviteettiEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Aktiviteetti, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeAktiviteettiEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Aktiviteetti)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Aktiviteetti)

    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKId)
      Case pDTO.HaePropertyNimi(Function(x) x.TahoId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKTahoId)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKTSopimusId)
      Case pDTO.HaePropertyNimi(Function(x) x.KontaktoijaGuid)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKKontaktoijaId)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivamaara)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKPaivamaara)
      Case pDTO.HaePropertyNimi(Function(x) x.SeuraavaYhteydenottoPaivamaara)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKSeuraavaYhteyspaiva)
      Case pDTO.HaePropertyNimi(Function(x) x.Kuvaus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKKuvaus)
      Case pDTO.HaePropertyNimi(Function(x) x.Liitetiedostopolku)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKLiitetiedostoPolku)
      Case pDTO.HaePropertyNimi(Function(x) x.YhteydenottotapaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKYhteystapaId)
      Case pDTO.HaePropertyNimi(Function(x) x.LajiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKAktiviteetinLajiId)
      Case pDTO.HaePropertyNimi(Function(x) x.StatusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.AKStatusId)
      Case Else
        hakuKentta.Nimi = String.Empty
    End Select

    Return hakuKentta

  End Function

End Class
