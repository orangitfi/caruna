Imports System.Linq.Expressions

Public Class SopimusHaku

  Public Shared Function HaeSopimusExpressio(ehdot As DTO.Hakuehto()) As Expression(Of Func(Of Entities.Sopimus, Boolean))

    Dim pe As ParameterExpression = Expression.Parameter(GetType(Entities.Sopimus), "sopimus")

    Dim hakuExpressio As Expression = Nothing
    Dim ehtoExrpessio As Expression

    For Each ehto As DTO.Hakuehto In ehdot

      ehtoExrpessio = Hakuehdot.HaeEhtoExpressio(ehto, pe, HaeSopimusEhtoKentta(ehto.Kentta))

      If hakuExpressio Is Nothing Then
        hakuExpressio = ehtoExrpessio
      Else
        hakuExpressio = Expression.And(hakuExpressio, ehtoExrpessio)
      End If

    Next

    Return Expression.Lambda(Of Func(Of Entities.Sopimus, Boolean))(hakuExpressio, pe)

  End Function

  Public Shared Function HaeSopimusEhtoKentta(kentta As String) As PoimintaHakuKentta

    Dim pDTO As New Common.PropertyAvustaja(Of DTO.Sopimus)
    Dim pEntity As New Common.PropertyAvustaja(Of Entities.Sopimus)

    Dim hakuKentta As New PoimintaHakuKentta()

    Select Case kentta
      Case pDTO.HaePropertyNimi(Function(x) x.SopimustyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimustyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.Id)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPId)
      Case pDTO.HaePropertyNimi(Function(x) x.PCSNumero)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPCSNumero)
      Case pDTO.HaePropertyNimi(Function(x) x.Projektinvalvoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPProjektinvalvoja)
      Case pDTO.HaePropertyNimi(Function(x) x.JuridinenYhtioId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPJuridinenYhtioId)
      Case pDTO.HaePropertyNimi(Function(x) x.MuuTunniste)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPMuuTunniste)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenLaatija)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimuksenLaatija)
      Case pDTO.HaePropertyNimi(Function(x) x.Korvaa)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPKorvaa)
      Case pDTO.HaePropertyNimi(Function(x) x.DFRooliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPDFRooliId)
      Case pDTO.HaePropertyNimi(Function(x) x.Karttaliite)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPKarttaliite)
      Case pDTO.HaePropertyNimi(Function(x) x.AsiakkaanAllekirjoitusPvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPAsiakkaanAllekirjoitusPvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.VerkonhaltijanAllekirjoitusPvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPVerkonhaltijanAllekirjoitusPvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Alkupvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPAlkaa)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Paattymispvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPaattyy)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Jatkoaika)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPJatkoaika)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenIrtisanomisaika)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimuksenIrtisanomisaika)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenIrtisanomistoimet)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimuksenIrtisanomistoimet)
      Case pDTO.HaePropertyNimi(Function(x) x.PuustonOmistajuusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPuustonOmistajuusId)
      Case pDTO.HaePropertyNimi(Function(x) x.PuustonPoistoId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPuustonPoistoId)
      Case pDTO.HaePropertyNimi(Function(x) x.KieliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPKieliId)
      Case pDTO.HaePropertyNimi(Function(x) x.Luonnos)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPLuonnos)
      Case pDTO.HaePropertyNimi(Function(x) x.PaasopimusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPaasopimusId)
      Case pDTO.HaePropertyNimi(Function(x) x.YlasopimuksenTyyppiId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPYlasopimuksenTyyppiId)
      Case pDTO.HaePropertyNimi(Function(x) x.AlkuperainenYhtioId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPAlkuperainenYhtioId)
      Case pDTO.HaePropertyNimi(Function(x) x.JulkisuusasteId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPJulkisuusasteId)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenAlaluokkaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimuksenAlaluokkaId)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenEhtoversioId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPSopimuksenEhtoversioId)
      Case pDTO.HaePropertyNimi(Function(x) x.Kuvaus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPKuvaus)
      Case pDTO.HaePropertyNimi(Function(x) x.VerkonhaltijaSiirtoOikeusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPVerkohaltijaSiirtoOikeusId)
      Case pDTO.HaePropertyNimi(Function(x) x.VastaosapuoliSiirtoOikeusId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPVastaosapuoliSiirtoOikeusId)
      Case pDTO.HaePropertyNimi(Function(x) x.Irtisanomispvm)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPIrtisanomispvm)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.KohdekategoriaId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPKohdekategoriaId)
      Case pDTO.HaePropertyNimi(Function(x) x.Sopimustyyppi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlps_Sopimustyyppi.STYSopimustyyppi)
      Case pDTO.HaePropertyNimi(Function(x) x.Julkisuusaste)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_Julkisuusaste.JASJulkisuusaste)
      Case pDTO.HaePropertyNimi(Function(x) x.DFRooli)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_DFRooli.DFRRooli)
      Case pDTO.HaePropertyNimi(Function(x) x.KieliId)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_Kieli.KIEKieli)
      Case pDTO.HaePropertyNimi(Function(x) x.YlasopimuksenTyyppi)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlps_YlasopimuksenTyyppi.YSTYlasopimuksenTyyppi)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenAlaluokka)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_SopimuksenAlaluokka.SALSopimuksenAlaluokka)
      Case pDTO.HaePropertyNimi(Function(x) x.SopimuksenEhtoversio)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_SopimuksenEhtoversio.SEHSopimuksenEhtoversio)
      Case pDTO.HaePropertyNimi(Function(x) x.VerkonhaltijaSiirtoOikeus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_SiirtoOikeus.SOISiirtoOikeus)
      Case pDTO.HaePropertyNimi(Function(x) x.VastaosapuoliSiirtoOikeus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_SiirtoOikeus1.SOISiirtoOikeus)
      Case pDTO.HaePropertyNimi(Function(x) x.Kohdekategoria)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_Kohdekategoria.KDKKohdeKategoria)
      Case pDTO.HaePropertyNimi(Function(x) x.PuustonPoisto)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_PuustonPoisto.PPOPuustonPoisto)
      Case pDTO.HaePropertyNimi(Function(x) x.PuustonOmistajuus)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.hlp_PuustonOmistajuus.POMPuustonOmistajuus)
      Case pDTO.HaePropertyNimi(Function(x) x.AlkuperainenYhtio)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.Taho2.TAHSukunimi)
      Case pDTO.HaePropertyNimi(Function(x) x.Luoja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPLuoja)
      Case pDTO.HaePropertyNimi(Function(x) x.Luotu)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPLuotu)
        hakuKentta.Tyyppi = GetType(Date)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivittaja)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPaivittaja)
      Case pDTO.HaePropertyNimi(Function(x) x.Paivitetty)
        hakuKentta.Nimi = pEntity.HaePropertyNimi(Function(x) x.SOPPaivitetty)
        hakuKentta.Tyyppi = GetType(Date)
      Case Else
        hakuKentta.Nimi = String.Empty
    End Select

    Return hakuKentta

  End Function

End Class
