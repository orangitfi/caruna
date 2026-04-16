Imports System.Linq.Expressions

Public Class Sopimus_TahoHaku

  Public Shared Function HaeSopimus_TahoExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Sopimus_Taho, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Sopimus_Taho), "sopimus_taho")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeSopimus_TahoEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Sopimus_Taho, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeSopimus_TahoEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.SopimusTaho)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Sopimus_Taho)

    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.AsiakastyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOTAsiakastyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.DFRooliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOTDFRooliId)
      Case Else
        hakuKentta.Nimi = String.Empty
    End Select

    Return hakuKentta

  End Function

End Class
