Namespace Konversiot

    Public Class Sopimus

        Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Sopimus)) As List(Of DTO.Sopimus)

            Dim tulokset = New List(Of DTO.Sopimus)
            For Each muunnettava In muunnettavat
                tulokset.Add(MuutaDTOksi(muunnettava))
            Next
            Return tulokset

        End Function

        Public Shared Function MuutaDTOksi(muunnettava As Entities.Sopimus) As DTO.Sopimus

            Dim tulos = New DTO.Sopimus()
            tulos.Id = muunnettava.SOPId
            tulos.Tyyppi = "Sopimus|" + If(muunnettava.SOPSopimustyyppiId Is Nothing, "0", muunnettava.SOPSopimustyyppiId.ToString())

            If Not muunnettava.hlps_Sopimustyyppi Is Nothing Then
                tulos.Sopimustyyppi = muunnettava.hlps_Sopimustyyppi.STYSopimustyyppi
            End If

            tulos.PCSNumero = muunnettava.SOPPCSNumero

            tulos.Alkaa = If(muunnettava.SOPAlkaa Is Nothing, String.Empty, Format(muunnettava.SOPAlkaa, "dd.MM.yyyy"))
            tulos.Paattyy = If(muunnettava.SOPPaattyy Is Nothing, String.Empty, Format(muunnettava.SOPPaattyy, "dd.MM.yyyy"))

            tulos.MuuTunniste = muunnettava.SOPMuuTunniste
            tulos.Vuosi = If(muunnettava.SOPSopimusvuosi Is Nothing, String.Empty, muunnettava.SOPSopimusvuosi)

            'For Each sopimus_kiinteisto As Entities.Sopimus_Kiinteisto In muunnettava.Sopimus_Kiinteisto

            '  tulos.KiinteistonKyla += sopimus_kiinteisto.Kiinteisto.KIIKyla + "<br />"
            '  tulos.KiinteistonRekisterinumero += sopimus_kiinteisto.Kiinteisto.KIIRekisterinumero + "<br />"

            '  If Not sopimus_kiinteisto.Kiinteisto.hlp_Kunta Is Nothing Then

            '    tulos.KiinteistonKunta += sopimus_kiinteisto.Kiinteisto.hlp_Kunta.KKunta + "<br />"

            '  End If

            'Next

            tulos.Alkupvm = muunnettava.SOPAlkaa
            tulos.Irtisanomispvm = muunnettava.SOPIrtisanomispvm
            tulos.Paattymispvm = muunnettava.SOPPaattyy

            tulos.Paivittaja = muunnettava.SOPPaivittaja
            tulos.Paivitetty = muunnettava.SOPPaivitetty

            tulos.TiedostoHaettu = muunnettava.SOPTiedostoHaettu
            tulos.MetatiedotPaivitetty = muunnettava.SOPMetatiedotPaivitetty

            tulos.Luoja = muunnettava.SOPLuoja
            tulos.Luotu = muunnettava.SOPLuotu
            tulos.AlkuperainenKorvaus = muunnettava.SOPAlkuperainenKorvaus
            tulos.AsiakkaanAllekirjoitusPvm = muunnettava.SOPAsiakkaanAllekirjoitusPvm
            tulos.DFRooliId = muunnettava.SOPDFRooliId
            If Not muunnettava.hlp_DFRooli Is Nothing Then
                tulos.DFRooli = muunnettava.hlp_DFRooli.DFRRooli
            End If
            tulos.Info = muunnettava.SOPInfo
            tulos.JulkisuusasteId = muunnettava.SOPJulkisuusasteId
            If Not muunnettava.hlp_Julkisuusaste Is Nothing Then
                tulos.Julkisuusaste = muunnettava.hlp_Julkisuusaste.JASJulkisuusaste
            End If
            tulos.JuridinenYhtioId = muunnettava.SOPJuridinenYhtioId

            tulos.Karttaliite = muunnettava.SOPKarttaliite
            tulos.KestoId = muunnettava.SOPKestoId
            tulos.Korvaa = muunnettava.SOPKorvaa
            tulos.Kuvaus = muunnettava.SOPKuvaus
            tulos.Luonnonsuojelualue = muunnettava.SOPLuonnonsuojelualue
            tulos.MaantieteellinenVali = muunnettava.SOPMaantieteellinenVali
            tulos.Muuntamoalue = muunnettava.SOPMuuntamoalue
            tulos.PaasopimusId = muunnettava.SOPPaasopimusId
            tulos.ProjektiAloitusPvm = muunnettava.SOPProjektiAloitusPvm
            tulos.Pylvasmaara = muunnettava.SOPPylvasmaara
            tulos.Pylvasvali = muunnettava.SOPPylvasvali
            tulos.SopimuksenAlaluokkaId = muunnettava.SOPSopimuksenAlaluokkaId
            If Not muunnettava.hlp_SopimuksenAlaluokka Is Nothing Then
                tulos.SopimuksenAlaluokka = muunnettava.hlp_SopimuksenAlaluokka.SALSopimuksenAlaluokka
            End If
            tulos.SopimuksenEhtoversioId = muunnettava.SOPSopimuksenEhtoversioId
            If Not muunnettava.hlp_SopimuksenEhtoversio Is Nothing Then
                tulos.SopimuksenEhtoversio = muunnettava.hlp_SopimuksenEhtoversio.SEHSopimuksenEhtoversio
            End If
            tulos.SopimuksenIrtisanomisaika = muunnettava.SOPSopimuksenIrtisanomisaika
            tulos.SopimuksenIrtisanomistoimet = muunnettava.SOPSopimuksenIrtisanomistoimet
            tulos.SopimuksenLaatija = muunnettava.SOPSopimuksenLaatija
            tulos.SopimuksenTilaId = muunnettava.SOPSopimuksenTilaId
            If Not muunnettava.hlps_SopimuksenTila Is Nothing Then
                tulos.SopimuksenTila = muunnettava.hlps_SopimuksenTila.STISopimuksenTila
            End If
            tulos.SopimusluokkaId = muunnettava.SOPSopimusluokkaId
            If Not muunnettava.hlps_Sopimusluokka Is Nothing Then
                tulos.Sopimusluokka = muunnettava.hlps_Sopimusluokka.SLUSopimusLuokka
            End If
            tulos.SopimustyyppiId = muunnettava.SOPSopimustyyppiId
            tulos.VastaosapuoliSiirtoOikeusId = muunnettava.SOPVastaosapuoliSiirtoOikeusId
            If Not muunnettava.hlp_SiirtoOikeus1 Is Nothing Then
                tulos.VastaosapuoliSiirtoOikeus = muunnettava.hlp_SiirtoOikeus1.SOISiirtoOikeus
            End If
            tulos.VastuuyksikkoId = muunnettava.SOPVastuuyksikkoId
            If Not muunnettava.Taho Is Nothing Then
                tulos.Vastuuyksikko = muunnettava.Taho.TAHSukunimi
            End If
            tulos.VerkonhaltijaSiirtoOikeusId = muunnettava.SOPVerkohaltijaSiirtoOikeusId
            If Not muunnettava.hlp_SiirtoOikeus Is Nothing Then
                tulos.VerkonhaltijaSiirtoOikeus = muunnettava.hlp_SiirtoOikeus.SOISiirtoOikeus
            End If
            tulos.VerkonhaltijanAllekirjoitusPvm = muunnettava.SOPVerkonhaltijanAllekirjoitusPvm
            tulos.AlkuperainenYhtioId = muunnettava.SOPAlkuperainenYhtioId
            If Not muunnettava.Taho2 Is Nothing Then
                tulos.AlkuperainenYhtio = muunnettava.Taho2.TAHSukunimi
            End If
            tulos.Projektinvalvoja = muunnettava.SOPProjektinvalvoja
            tulos.Jatkoaika = muunnettava.SOPJatkoaika
            tulos.LaskennallinenPaattymispvm = muunnettava.SOPLaskennallinenPaattymispvm
            tulos.PuustonOmistajuusId = muunnettava.SOPPuustonOmistajuusId
            If Not muunnettava.hlp_PuustonOmistajuus Is Nothing Then
                tulos.PuustonOmistajuus = muunnettava.hlp_PuustonOmistajuus.POMPuustonOmistajuus
            End If
            tulos.PuustonPoistoId = muunnettava.SOPPuustonPoistoId
            If Not muunnettava.hlp_PuustonPoisto Is Nothing Then
                tulos.PuustonPoisto = muunnettava.hlp_PuustonPoisto.PPOPuustonPoisto
            End If
            tulos.KohdekategoriaId = muunnettava.SOPKohdekategoriaId
            If Not muunnettava.hlp_Kohdekategoria Is Nothing Then
                tulos.Kohdekategoria = muunnettava.hlp_Kohdekategoria.KDKKohdeKategoria
            End If

            If Not muunnettava.SOPLupatahoId Is Nothing Then
                tulos.LupatahoId = muunnettava.SOPLupatahoId
            End If

            If Not muunnettava.hlp_Lupataho Is Nothing Then
                tulos.Lupataho = muunnettava.hlp_Lupataho.LPTLupataho
            End If

            tulos.Luonnos = muunnettava.SOPLuonnos
            tulos.KieliId = muunnettava.SOPKieliId
            If Not muunnettava.hlp_Kieli Is Nothing Then
                tulos.Kieli = muunnettava.hlp_Kieli.KIEKieli
            End If

            tulos.Erityisehdot = muunnettava.SOPErityisehdot

            tulos.Korvaukseton = muunnettava.SOPKorvaukseton

            tulos.YlasopimuksenTyyppiId = muunnettava.SOPYlasopimuksenTyyppiId
            If Not muunnettava.hlps_YlasopimuksenTyyppi Is Nothing Then
                tulos.YlasopimuksenTyyppi = muunnettava.hlps_YlasopimuksenTyyppi.YSTYlasopimuksenTyyppi
            End If
            If Not String.IsNullOrEmpty(muunnettava.SOPSopimusvuosi) Then
                tulos.Sopimusvuosi = muunnettava.SOPSopimusvuosi
            End If

            tulos.Mappitunniste = muunnettava.SOPMappitunniste
            tulos.CaceTehtava = muunnettava.SOPCaceTehtava

            Return tulos

        End Function

        Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Sopimus)) As List(Of Entities.Sopimus)

            Dim tulokset = New List(Of Entities.Sopimus)
            For Each muunnettava In muunnettavat
                tulokset.Add(MuutaDBOksi(muunnettava))
            Next
            Return tulokset

        End Function

        Public Shared Function MuutaDBOksi(muunnettava As DTO.Sopimus, Optional tulos As Entities.Sopimus = Nothing, Optional kaikkiTiedot As Boolean = True) As Entities.Sopimus

            If tulos Is Nothing Then
                tulos = New Entities.Sopimus()

                tulos.SOPLuoja = muunnettava.Luoja
                tulos.SOPLuotu = muunnettava.Luotu
            End If

            tulos.SOPId = muunnettava.Id
            tulos.SOPPCSNumero = muunnettava.PCSNumero
            tulos.SOPMuuTunniste = muunnettava.MuuTunniste
            tulos.SOPSopimusvuosi = muunnettava.Vuosi

            tulos.SOPAlkaa = muunnettava.Alkupvm
            tulos.SOPIrtisanomispvm = muunnettava.Irtisanomispvm
            tulos.SOPPaattyy = muunnettava.Paattymispvm

            tulos.SOPPaivittaja = muunnettava.Paivittaja
            tulos.SOPPaivitetty = muunnettava.Paivitetty

            tulos.SOPAlkuperainenKorvaus = muunnettava.AlkuperainenKorvaus
            tulos.SOPAsiakkaanAllekirjoitusPvm = muunnettava.AsiakkaanAllekirjoitusPvm
            tulos.SOPDFRooliId = muunnettava.DFRooliId
            tulos.SOPInfo = muunnettava.Info
            tulos.SOPJulkisuusasteId = muunnettava.JulkisuusasteId
            tulos.SOPJuridinenYhtioId = muunnettava.JuridinenYhtioId
            tulos.SOPKarttaliite = muunnettava.Karttaliite
            tulos.SOPKestoId = muunnettava.KestoId
            tulos.SOPKorvaa = muunnettava.Korvaa
            tulos.SOPKuvaus = muunnettava.Kuvaus
            tulos.SOPLuonnonsuojelualue = muunnettava.Luonnonsuojelualue
            tulos.SOPMaantieteellinenVali = muunnettava.MaantieteellinenVali
            tulos.SOPMuuntamoalue = muunnettava.Muuntamoalue
            tulos.SOPPaasopimusId = muunnettava.PaasopimusId
            tulos.SOPProjektiAloitusPvm = muunnettava.ProjektiAloitusPvm
            tulos.SOPPylvasmaara = muunnettava.Pylvasmaara
            tulos.SOPPylvasvali = muunnettava.Pylvasvali
            tulos.SOPSopimuksenAlaluokkaId = muunnettava.SopimuksenAlaluokkaId
            tulos.SOPSopimuksenEhtoversioId = muunnettava.SopimuksenEhtoversioId
            tulos.SOPSopimuksenIrtisanomisaika = muunnettava.SopimuksenIrtisanomisaika
            tulos.SOPSopimuksenIrtisanomistoimet = muunnettava.SopimuksenIrtisanomistoimet
            tulos.SOPSopimuksenLaatija = muunnettava.SopimuksenLaatija
            tulos.SOPSopimuksenTilaId = muunnettava.SopimuksenTilaId
            tulos.SOPSopimusluokkaId = muunnettava.SopimusluokkaId
            tulos.SOPSopimustyyppiId = muunnettava.SopimustyyppiId
            tulos.SOPVastaosapuoliSiirtoOikeusId = muunnettava.VastaosapuoliSiirtoOikeusId
            tulos.SOPVastuuyksikkoId = muunnettava.VastuuyksikkoId
            tulos.SOPVerkohaltijaSiirtoOikeusId = muunnettava.VerkonhaltijaSiirtoOikeusId
            tulos.SOPVerkonhaltijanAllekirjoitusPvm = muunnettava.VerkonhaltijanAllekirjoitusPvm
            tulos.SOPAlkuperainenYhtioId = muunnettava.AlkuperainenYhtioId
            tulos.SOPProjektinvalvoja = muunnettava.Projektinvalvoja
            tulos.SOPJatkoaika = muunnettava.Jatkoaika
            tulos.SOPLaskennallinenPaattymispvm = muunnettava.LaskennallinenPaattymispvm
            tulos.SOPPuustonOmistajuusId = muunnettava.PuustonOmistajuusId
            tulos.SOPPuustonPoistoId = muunnettava.PuustonPoistoId
            tulos.SOPKohdekategoriaId = muunnettava.KohdekategoriaId
            tulos.SOPLupatahoId = muunnettava.LupatahoId

            tulos.SOPLuonnos = muunnettava.Luonnos
            tulos.SOPKieliId = muunnettava.KieliId
            tulos.SOPErityisehdot = muunnettava.Erityisehdot

            tulos.SOPKorvaukseton = muunnettava.Korvaukseton

            tulos.SOPYlasopimuksenTyyppiId = muunnettava.YlasopimuksenTyyppiId

            If kaikkiTiedot Then
                tulos.SOPTiedostoHaettu = muunnettava.TiedostoHaettu
                tulos.SOPMetatiedotPaivitetty = muunnettava.MetatiedotPaivitetty
            End If

            tulos.SOPMappitunniste = muunnettava.Mappitunniste
            tulos.SOPCaceTehtava = muunnettava.CaceTehtava

            Return tulos

        End Function

    End Class

End Namespace
