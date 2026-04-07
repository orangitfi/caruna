Imports System.Linq.Expressions

Public Class KiinteistoHaku

  Public Shared Function HaeKiinteistoExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Kiinteisto, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Kiinteisto), "kiinteisto")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeKiinteistoEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Kiinteisto, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeKiinteistoEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Kiinteisto)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Kiinteisto)
    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIId)
      Case pDTO.HaePropertyNimi(Function(x) x.Nimi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIKiinteisto)
      Case pDTO.HaePropertyNimi(Function(x) x.Osoite)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIKatuosoite)
      Case pDTO.HaePropertyNimi(Function(x) x.Postinumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIPostinumero)
      Case pDTO.HaePropertyNimi(Function(x) x.Postitoimipaikka)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIPostitoimipaikka)
      Case pDTO.HaePropertyNimi(Function(x) x.Kyla)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIKyla)
      Case pDTO.HaePropertyNimi(Function(x) x.Rekisterinumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIRekisterinumero)
      Case pDTO.HaePropertyNimi(Function(x) x.LyhytKiinteistotunnus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIKiinteistotunnusLyhyt)
      Case pDTO.HaePropertyNimi(Function(x) x.Luoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIILuoja)
      Case pDTO.HaePropertyNimi(Function(x) x.Luotu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIILuotu)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivittaja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIPaivittaja)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivitetty)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KIIPaivitetty)
        hakuKentta.Tyyppi = GetType(Date)
      Case Else
        hakuKentta.Nimi = String.Empty
    End Select

    Return hakuKentta

  End Function

End Class
