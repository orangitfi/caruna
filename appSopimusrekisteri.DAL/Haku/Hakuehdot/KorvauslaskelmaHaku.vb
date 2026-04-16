Imports System.Linq.Expressions

Public Class KorvauslaskelmaHaku

  Public Shared Function HaeKorvauslaskelmaExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Korvauslaskelma, Boolean))

    If ehdot.Count = 0 Then
      Return Function(x) True
    End If

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Korvauslaskelma), "korvauslaskelma")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeKorvauslaskelmaEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Korvauslaskelma, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeKorvauslaskelmaEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Korvauslaskelma)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Korvauslaskelma)
    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORId)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORSopimusId)
      Case pDTO.HaePropertyNimi(Function(x) x.KorvaustyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORKorvaustyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.KorvausStatusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORKorvauslaskelmaStatusId)
      Case pDTO.HaePropertyNimi(Function(x) x.MaksunSuoritusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORMaksunSuoritusId)
      Case pDTO.HaePropertyNimi(Function(x) x.KorvauksenProjektinumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORKorvauksenProjektinumero)
      Case pDTO.HaePropertyNimi(Function(x) x.TypeOfProject)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORTypeOfProject)
      Case pDTO.HaePropertyNimi(Function(x) x.Type)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORType)
      Case pDTO.HaePropertyNimi(Function(x) x.Owner)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KOROwner)
      Case pDTO.HaePropertyNimi(Function(x) x.Concession)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORConcession)
      Case pDTO.HaePropertyNimi(Function(x) x.CertDate)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORCertDate)
      Case pDTO.HaePropertyNimi(Function(x) x.FieldWorkStartedA)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORFieldWorkStarted)
      Case pDTO.HaePropertyNimi(Function(x) x.ProjectClosedA)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORProjectClosedA)
      Case pDTO.HaePropertyNimi(Function(x) x.Viite)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViite)
      Case pDTO.HaePropertyNimi(Function(x) x.Viesti)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViesti)
      Case pDTO.HaePropertyNimi(Function(x) x.MaksetaanAlv)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORMaksetaanAlv)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimushetkenIndeksi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORSopimushetkenIndeksiArvo)
      Case pDTO.HaePropertyNimi(Function(x) x.IndeksikuukausiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORIndeksiKuukausiId)
      Case pDTO.HaePropertyNimi(Function(x) x.OnIndeksi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KOROnIndeksi)
      Case pDTO.HaePropertyNimi(Function(x) x.IndeksityyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORIndeksityyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.ViimeisinMaksu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViimeisinMaksu)
      Case pDTO.HaePropertyNimi(Function(x) x.ViimeisinIndeksi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViimeisinIndeksi)
      Case pDTO.HaePropertyNimi(Function(x) x.ViimeisinMaksupvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViimeisinMaksuPvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.ViimeisinMaksuIndeksi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViimeisinMaksuIndeksi)
      Case pDTO.HaePropertyNimi(Function(x) x.EnsimmainenSallittuMaksupvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KOREnsimmainenSallittuMaksuPvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.AlkuperainenKorvaus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORMaksettavaKorvausAlkuperainen)
      Case pDTO.HaePropertyNimi(Function(x) x.ViimeinenMaksupvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORViimeinenMaksuPvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.IndeksiVuosi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORIndeksiVuosi)
      Case pDTO.HaePropertyNimi(Function(x) x.MaksukuukausiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORMaksuKuukausiId)
      Case pDTO.HaePropertyNimi(Function(x) x.MaksuehdotId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORMaksuehdotId)
      Case pDTO.HaePropertyNimi(Function(x) x.KirjanpidonTiliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORKirjanpidonTiliId)
      Case pDTO.HaePropertyNimi(Function(x) x.KustannuspaikkaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORKirjanpidonKustannuspaikkaId)
      Case pDTO.HaePropertyNimi(Function(x) x.InvCostId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORInvCostId)
      Case pDTO.HaePropertyNimi(Function(x) x.RegulationId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORRegulationId)
      Case pDTO.HaePropertyNimi(Function(x) x.PurposeId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORPurposeId)
      Case pDTO.HaePropertyNimi(Function(x) x.Local1Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORLocal1Id)
      Case pDTO.HaePropertyNimi(Function(x) x.Luotu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORLuotu)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Luoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORLuoja)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivitetty)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORPaivitetty)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivittaja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORPaivittaja)
      Case pDTO.HaePropertyNimi(Function(x) x.SaajaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.KORTahoId)
      Case Else
        hakuKentta.Nimi = ""
    End Select

    Return hakuKentta

  End Function

End Class
