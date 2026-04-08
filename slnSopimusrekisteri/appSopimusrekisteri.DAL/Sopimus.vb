Imports System.Data.SqlTypes
Imports System.Threading
Imports appSopimusrekisteri.Entities
Imports System.Runtime.Remoting.Services
Imports System.Data.Entity.Migrations.Model
Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports System.Linq.Expressions
Imports LinqKit

Public Class Sopimus

    Private _konteksti As DTO.DataKonteksti

    Public Sub New()

    End Sub

    Public Sub New(konteksti As DTO.DataKonteksti)
        _konteksti = konteksti
    End Sub

#Region "Hakumetodit"

    Public Function HaeKaikkiTulokset(hakuehdot As Expressions.Expression(Of Func(Of Entities.Sopimus, Boolean)), Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Sopimus)

        Using tietokanta As New Entities.FortumEntities()

            Dim sopimukset As IEnumerable(Of Entities.Sopimus) = Nothing

            If jarjestyssarake = String.Empty Then

                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot)

            Else
                ' HACK: Dynaamista järjestämistä Reflectionin avulla ei saatu toimimaan
                ' ja koska sarakkeita on rajoitettu määrä tässä oikaistiin mutka.

                Select Case jarjestyssarake

                    Case "SOPId"

                        Select Case jarjestyssuunta

                            Case "ASC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.SOPId)

                            Case "DESC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.SOPId)

                        End Select

                    Case "SOPTyyppi"

                        Select Case jarjestyssuunta

                            Case "ASC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.hlps_Sopimustyyppi.STYSopimustyyppi)

                            Case "DESC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.hlps_Sopimustyyppi.STYSopimustyyppi)

                        End Select

                    Case "KIIRekisterinumero"

                        Select Case jarjestyssuunta

                            Case "ASC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.KIIKiinteistotunnusLyhyt))

                            Case "DESC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderByDescending(Function(x) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.KIIKiinteistotunnusLyhyt))

                        End Select

                    Case "KIIKunta"

                        Select Case jarjestyssuunta

                            Case "ASC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.hlp_Kunta.KKunta))

                            Case "DESC"
                                sopimukset = tietokanta.Sopimus.Include("Sopimus_Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto").Include("Sopimus_Kiinteisto.Kiinteisto.hlp_Kunta").AsExpandable().Where(hakuehdot).OrderBy(Function(x) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.hlp_Kunta.KKunta))

                        End Select

                End Select

            End If

            Dim lstSopimusDTO As New List(Of DTO.Sopimus)
            Dim sopimusDTO As DTO.Sopimus

            For Each sopimus As Entities.Sopimus In sopimukset

                sopimusDTO = Konversiot.Sopimus.MuutaDTOksi(sopimus)

                For Each kiinteisto As Entities.Sopimus_Kiinteisto In sopimus.Sopimus_Kiinteisto

                    sopimusDTO.Kiinteistot.Add(Konversiot.Kiinteisto.MuutaDTOksi(kiinteisto.Kiinteisto))

                Next

                lstSopimusDTO.Add(sopimusDTO)

            Next

            Return lstSopimusDTO

        End Using

    End Function

    Public Function HaeTulokset(hakuehdot As Expression(Of Func(Of Entities.Sopimus, Boolean))) As List(Of iHakutulos)

        Using tietokanta As New Entities.FortumEntities()

            Dim rivit As IEnumerable(Of Tietotyyppi.Sopimus)

            If hakuehdot Is Nothing Then
                rivit = tietokanta.Sopimus.Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
            Else
                rivit = tietokanta.Sopimus.AsExpandable().Where(hakuehdot).Take(Hakukonfiguraatio.HakutulostenMaksimimaara)
            End If

            Return MuutaHakutulokseksi(rivit)

        End Using

    End Function

    Public Function HaeSopimustenMaara(hakuehdot As Expressions.Expression(Of Func(Of Entities.Sopimus, Boolean))) As Integer

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.Sopimus.AsExpandable().Count(hakuehdot)

        End Using

    End Function

    Public Function HaeTahojenMaara(hakuehdot As Expressions.Expression(Of Func(Of Entities.Sopimus, Boolean))) As Integer

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.Sopimus.AsExpandable().Count(hakuehdot)

        End Using

    End Function

    Public Function HaeSopimus(id As Integer) As Tietotyyppi.Sopimus

        Using tietokanta As New Entities.FortumEntities()

            Dim sopimus As Tietotyyppi.Sopimus
            sopimus = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = id)
            Return sopimus

        End Using

    End Function

    Public Function HaeSopimusDTO(id As Integer) As DTO.Sopimus

        Using tietokanta As New Entities.FortumEntities()

            Dim sopimus As DTO.Sopimus
            Dim haettava As Entities.Sopimus = tietokanta.Sopimus _
                                               .Include("Sopimus_Kiinteisto") _
                                               .Include("Sopimus_Kiinteisto.Kiinteisto") _
                                               .Include("Sopimus_Taho") _
                                               .Include("Sopimus_Taho.Taho") _
                                               .Include("Tunnisteyksikko") _
                                               .Include("Tiedosto") _
                                               .Include("Korvauslaskelma") _
                                               .Include("Korvauslaskelma.KorvauslaskelmaRivi") _
                                               .Include("Taho1") _
                                               .Include("Sopimus2") _
                                               .FirstOrDefault(Function(x) x.SOPId = id)

            sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava)

            If Not haettava.Taho1 Is Nothing Then
                sopimus.JuridinenYhtio = Konversiot.Taho.MuutaDTOksi(haettava.Taho1)
            End If

            For Each haettavaKiinteisto As Entities.Sopimus_Kiinteisto In haettava.Sopimus_Kiinteisto

                sopimus.Kiinteistot.Add(Konversiot.Kiinteisto.MuutaDTOksi(haettavaKiinteisto.Kiinteisto))

            Next

            For Each haettavaTaho As Entities.Sopimus_Taho In haettava.Sopimus_Taho

                Dim sopTaho As DTO.SopimusTaho = Konversiot.SopimusTaho.MuutaDTOksi(haettavaTaho)

                sopTaho.Taho = Konversiot.Taho.MuutaDTOksi(haettavaTaho.Taho)

                sopimus.Tahot.Add(sopTaho)

            Next

            For Each haettavaTunnisteyksikko As Entities.Tunnisteyksikko In haettava.Tunnisteyksikko

                sopimus.Tunnisteyksikot.Add(Konversiot.Tunnisteyksikko.MuutaDTOksi(haettavaTunnisteyksikko))

            Next

            For Each haettavaTiedosto As Entities.Tiedosto In haettava.Tiedosto

                sopimus.Tiedostot.Add(Konversiot.Tiedosto.MuutaDTOksi(haettavaTiedosto))

            Next

            For Each haettavaKorvauslaskelma As Entities.Korvauslaskelma In haettava.Korvauslaskelma

                Dim korvauslaskelma As DTO.Korvauslaskelma = Konversiot.Korvauslaskelma.MuutaDTOksi(haettavaKorvauslaskelma)

                For Each haettavaKorvauslaskelmaRivi As Entities.KorvauslaskelmaRivi In haettavaKorvauslaskelma.KorvauslaskelmaRivi

                    korvauslaskelma.Rivit.Add(Konversiot.Korvauslaskelma.MuutaDTOksi(haettavaKorvauslaskelmaRivi))

                Next

                sopimus.Korvauslaskelmat.Add(korvauslaskelma)

            Next

            If Not haettava.Sopimus2 Is Nothing Then
                sopimus.Paasopimus = Konversiot.Sopimus.MuutaDTOksi(haettava.Sopimus2)
            End If

            Return sopimus

        End Using

    End Function

    Public Function HaeKiinteistonSopimukset(kiinteistoId As Integer) As List(Of DTO.Sopimus)

        Using tietokanta As New Entities.FortumEntities()

            Dim tunnisteet = tietokanta.Sopimus_Kiinteisto.Where(Function(x) x.SKKiinteistoId = kiinteistoId).Select(Function(y) y.SKSopimusId)
            Dim sopimukset = tietokanta.Sopimus.Where(Function(x) tunnisteet.Contains(x.SOPId))
            Return Konversiot.Sopimus.MuutaDTOksi(sopimukset)

        End Using

        Return Nothing

    End Function

    Public Function HaeTahonSopimukset(tahoId As Integer) As List(Of DTO.Sopimus)

        Using tietokanta As New Entities.FortumEntities()

            Dim tunnisteet = tietokanta.Sopimus_Taho.Where(Function(x) x.SOTTahoId = tahoId).Select(Function(y) y.SOTSopimusId)
            Dim sopimukset = tietokanta.Sopimus.Where(Function(x) tunnisteet.Contains(x.SOPId))
            Return Konversiot.Sopimus.MuutaDTOksi(sopimukset)

        End Using

        Return Nothing

    End Function

    Public Function HaeJasSopimus(sopimusId As Integer) As DTO.JASSopimus

        Dim sopimus As JASSopimus = New JASSopimus()

        Using tietokanta As New Entities.FortumEntities()

            Dim perustiedot = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = sopimusId)
            If Not perustiedot Is Nothing Then

                sopimus.Sopimusnumero = perustiedot.SOPId

                ' HACK: Magic numbers: Asiakastyyppi 5 = omistaja...
                Dim maanomistaja = tietokanta.Sopimus_Taho.Include("Taho").FirstOrDefault(Function(x) x.SOTAsiakastyyppiId = 5 And x.SOTSopimusId = sopimusId)
                If Not maanomistaja Is Nothing Then
                    If Not maanomistaja.Taho Is Nothing Then

                        sopimus.Maanomistaja.Nimi = maanomistaja.Taho.TAHEtunimi + " " + maanomistaja.Taho.TAHSukunimi
                        sopimus.Maanomistaja.Osoite = maanomistaja.Taho.TAHPostitusosoite + " " + maanomistaja.Taho.TAHPostituspostinro + " " + maanomistaja.Taho.TAHPostituspostitmp
                        sopimus.Maanomistaja.Tilinumero = maanomistaja.Taho.TAHTilinumero

                    End If
                End If

                Dim johdonOmistaja = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = perustiedot.SOPJuridinenYhtioId)
                If Not johdonOmistaja Is Nothing Then

                    sopimus.JohdonOmistaja.Nimi = johdonOmistaja.TAHEtunimi + " " + johdonOmistaja.TAHSukunimi
                    sopimus.JohdonOmistaja.Osoite = johdonOmistaja.TAHPostitusosoite + " " + johdonOmistaja.TAHPostituspostinro + " " + johdonOmistaja.TAHPostituspostitmp

                End If

                sopimus.JohdonOmistaja.Karttalehti = perustiedot.SOPKarttaliite
                sopimus.JohdonOmistaja.Tyonumero = perustiedot.SOPPCSNumero

                For Each tunnisteyksikko As Entities.Tunnisteyksikko In perustiedot.Tunnisteyksikko

                    If tunnisteyksikko.TUYTunnisteyksikkoTyyppiId = 6 Then ' HACK: Using magic numbers: Linja-osa!
                        sopimus.JohdonOmistaja.Linjaosa = tunnisteyksikko.TUYNimi
                        Exit For
                    End If

                Next

                ' Haetaan kaikkien kiinteistöjen perustiedot sopimukselle.
                Dim kiinteistotunnisteet = tietokanta.Sopimus_Kiinteisto.Where(Function(x) x.SKSopimusId = sopimusId).Select(Function(x) x.SKKiinteistoId)
                Dim kiinteistot = tietokanta.Kiinteisto.Where(Function(x) kiinteistotunnisteet.Contains(x.KIIId))
                kiinteistot.ForEach(Sub(x)
                                        Dim kiinteisto = New JasSopimusMaanomistajanTila()
                                        kiinteisto.Rekisterinumero = x.KIIKiinteistotunnusLyhyt
                                        kiinteisto.TilanNimi = x.KIIKiinteisto
                                        kiinteisto.Kunta = If(x.hlp_Kunta Is Nothing, String.Empty, x.hlp_Kunta.KKunta)
                                        kiinteisto.Kyla = x.KIIKyla
                                        sopimus.Maanomistaja.MaanomistajanTilat.Add(kiinteisto)
                                    End Sub)

                ' Lasketaan korvauslaskelman rivien summa sopimukselle.
                Dim summa As Decimal = 0
                Dim korvauslaskelmat = tietokanta.Korvauslaskelma.Where(Function(x) x.KORSopimusId = sopimusId).Select(Function(x) x.KORId)
                Dim korvauslaskelmanRivit = tietokanta.KorvauslaskelmaRivi.Where(Function(x) korvauslaskelmat.Contains(x.KLRKorvauslaskelmaId))
                korvauslaskelmanRivit.ForEach(Sub(x)
                                                  If Not x.KLRKorvaus Is Nothing Then
                                                      summa += x.KLRKorvaus
                                                  End If
                                              End Sub)

                sopimus.Korvaus.Korvaus = summa

                If perustiedot.SOPPuustonPoistoId Then
                    sopimus.Korvaus.PuustonPoisto = perustiedot.hlp_PuustonPoisto.PPOPuustonPoisto.ToLower()
                End If

                If perustiedot.SOPPuustonOmistajuusId Then
                    sopimus.Korvaus.PuustonOmistajuus = perustiedot.hlp_PuustonOmistajuus.POMPuustonOmistajuus.ToLower()
                End If

            End If

        End Using

        Return sopimus

    End Function

    Public Function HaeSuostumussopimus(sopimusId As Integer) As DTO.Suostumussopimus

        Dim sopimus As Suostumussopimus = New Suostumussopimus()

        Using tietokanta As New Entities.FortumEntities()

            Dim perustiedot = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = sopimusId)
            If Not perustiedot Is Nothing Then

                sopimus.Sopimusnumero = perustiedot.SOPId
                sopimus.JohdonOmistaja.Tyonumero = perustiedot.SOPPCSNumero

                For Each tunnisteyksikko As Entities.Tunnisteyksikko In perustiedot.Tunnisteyksikko

                    If tunnisteyksikko.TUYTunnisteyksikkoTyyppiId = 6 Then ' HACK: Using magic numbers: Linja-osa!
                        sopimus.JohdonOmistaja.Linjaosa = tunnisteyksikko.TUYNimi
                        Exit For
                    End If

                Next

                Dim maanomistaja = tietokanta.Sopimus_Taho.Include("Taho").FirstOrDefault(Function(x) x.SOTAsiakastyyppiId = DTO.Enumeraattorit.Asiakastyyppi.Omistaja And x.SOTSopimusId = sopimusId)
                If Not maanomistaja Is Nothing Then
                    If Not maanomistaja.Taho Is Nothing Then

                        sopimus.Maanomistaja.Nimi = maanomistaja.Taho.TAHEtunimi + " " + maanomistaja.Taho.TAHSukunimi
                        sopimus.Maanomistaja.Osoite = maanomistaja.Taho.TAHPostitusosoite + " " + maanomistaja.Taho.TAHPostituspostinro + " " + maanomistaja.Taho.TAHPostituspostitmp

                    End If
                End If

                Dim kiinteistotunnisteet = tietokanta.Sopimus_Kiinteisto.Where(Function(x) x.SKSopimusId = sopimusId).Select(Function(x) x.SKKiinteistoId)
                Dim kiinteisto = tietokanta.Kiinteisto.Where(Function(x) kiinteistotunnisteet.Contains(x.KIIId)).FirstOrDefault()

                If Not kiinteisto Is Nothing Then

                    sopimus.Maanomistaja.TilanKunta = If(kiinteisto.hlp_Kunta Is Nothing, String.Empty, kiinteisto.hlp_Kunta.KKunta)
                    sopimus.Maanomistaja.TilanKyla = kiinteisto.KIIKyla
                    sopimus.Maanomistaja.TilanNimi = kiinteisto.KIIKiinteisto & " " & kiinteisto.KIIKiinteistotunnusLyhyt

                End If

                Dim johdonOmistaja = tietokanta.Taho.FirstOrDefault(Function(x) x.TAHTahoId = perustiedot.SOPJuridinenYhtioId)
                If Not johdonOmistaja Is Nothing Then

                    sopimus.JohdonOmistaja.Nimi = johdonOmistaja.TAHEtunimi + " " + johdonOmistaja.TAHSukunimi
                    sopimus.JohdonOmistaja.Osoite = johdonOmistaja.TAHPostitusosoite + " " + johdonOmistaja.TAHPostituspostinro + " " + johdonOmistaja.TAHPostituspostitmp

                End If

            End If

        End Using

        Return sopimus

    End Function

    Public Function HaeSopimusarkistoonPaivitettavatSopimukset() As DTO.Sopimus()

        Using tietokanta As New Entities.FortumEntities()

            Dim lstSopimukset As New List(Of DTO.Sopimus)()

            Dim haettavat = tietokanta.Sopimus _
                             .Include("Sopimus_Kiinteisto") _
                             .Include("Sopimus_Kiinteisto.Kiinteisto") _
                             .Include("Sopimus_Taho") _
                             .Include("Sopimus_Taho.Taho") _
                             .Include("Taho1") _
                             .Include("Tiedosto") _
                             .Include("Tunnisteyksikko") _
                             .Where(Function(x) (x.SOPTiedostoHaettu = False Or x.SOPMetatiedotPaivitetty = False) And x.SOPAsiakkaanAllekirjoitusPvm.HasValue And x.SOPLuonnos = False)

            Dim sopimus As DTO.Sopimus

            For Each haettava As Entities.Sopimus In haettavat

                sopimus = Konversiot.Sopimus.MuutaDTOksi(haettava)

                If Not haettava.Taho1 Is Nothing Then
                    sopimus.JuridinenYhtio = Konversiot.Taho.MuutaDTOksi(haettava.Taho1)
                End If

                For Each haettavaKiinteisto As Entities.Sopimus_Kiinteisto In haettava.Sopimus_Kiinteisto

                    sopimus.Kiinteistot.Add(Konversiot.Kiinteisto.MuutaDTOksi(haettavaKiinteisto.Kiinteisto))

                Next

                For Each haettavaTaho As Entities.Sopimus_Taho In haettava.Sopimus_Taho

                    Dim sopTaho As DTO.SopimusTaho = Konversiot.SopimusTaho.MuutaDTOksi(haettavaTaho)

                    sopTaho.Taho = Konversiot.Taho.MuutaDTOksi(haettavaTaho.Taho)

                    sopimus.Tahot.Add(sopTaho)

                Next

                For Each haettavaTunnisteyksikko As Entities.Tunnisteyksikko In haettava.Tunnisteyksikko

                    sopimus.Tunnisteyksikot.Add(Konversiot.Tunnisteyksikko.MuutaDTOksi(haettavaTunnisteyksikko))

                Next

                For Each haettavaTiedosto As Entities.Tiedosto In haettava.Tiedosto

                    sopimus.Tiedostot.Add(Konversiot.Tiedosto.MuutaDTOksi(haettavaTiedosto))

                Next


                lstSopimukset.Add(sopimus)

            Next

            Return lstSopimukset.ToArray()

        End Using

    End Function

    Public Function HaeTuloste(id As Integer) As DTO.SopimusTuloste

        Using tietokanta As New Entities.FortumEntities()

            Dim haettava As Entities.Sopimus_Tuloste = tietokanta.Sopimus_Tuloste.Where(Function(x) x.STLSopimusId = id).FirstOrDefault()

            If Not haettava Is Nothing Then
                Return Konversiot.SopimusTuloste.MuutaDTOksi(haettava)
            End If

            Return Nothing
        End Using

        Return Nothing

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function LisaaSopimus(sopimus As Entities.Sopimus) As Entities.Sopimus

        If sopimus Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Try

                sopimus.SOPAsiakkaanAllekirjoitusPvm = If(sopimus.SOPAsiakkaanAllekirjoitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPAsiakkaanAllekirjoitusPvm)
                sopimus.SOPPaattyy = If(sopimus.SOPPaattyy = SqlDateTime.MinValue, Nothing, sopimus.SOPPaattyy)
                sopimus.SOPProjektiAloitusPvm = If(sopimus.SOPProjektiAloitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPProjektiAloitusPvm)
                sopimus.SOPIrtisanomispvm = If(sopimus.SOPIrtisanomispvm = SqlDateTime.MinValue, Nothing, sopimus.SOPIrtisanomispvm)
                sopimus.SOPVerkonhaltijanAllekirjoitusPvm = If(sopimus.SOPVerkonhaltijanAllekirjoitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPVerkonhaltijanAllekirjoitusPvm)

                tietokanta.Sopimus.Add(sopimus)
                tietokanta.SaveChanges()
                Return sopimus

            Catch ex As Exception

                Throw

            End Try

        End Using

    End Function

    Public Function LisaaSopimus(sopimus As DTO.Sopimus) As DTO.Sopimus

        If sopimus Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim lisattava As Entities.Sopimus = Konversiot.Sopimus.MuutaDBOksi(sopimus)

            Try

                tietokanta.Sopimus.Add(lisattava)
                tietokanta.SaveChanges()

                Return Konversiot.Sopimus.MuutaDTOksi(lisattava)

            Catch ex As Exception

                Throw

            End Try

        End Using

    End Function

    Public Function LisaaTuloste(tuloste As DTO.SopimusTuloste) As DTO.SopimusTuloste

        Using tietokanta As New Entities.FortumEntities()

            Dim lisattava As Entities.Sopimus_Tuloste = Konversiot.SopimusTuloste.MuutaDBOksi(tuloste)

            tietokanta.Sopimus_Tuloste.Add(lisattava)

            tietokanta.SaveChanges()

            Return Konversiot.SopimusTuloste.MuutaDTOksi(lisattava)

        End Using

    End Function

    Public Function LisaaSopimusKiinteistolle(sopimusId As Integer, kiinteistoId As Integer) As Sopimus_Kiinteisto

        If sopimusId = 0 Or kiinteistoId = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim lisattava = tietokanta.Sopimus_Kiinteisto.FirstOrDefault(Function(x) x.SKSopimusId = sopimusId And x.SKKiinteistoId = kiinteistoId)
            If lisattava Is Nothing Then

                lisattava = New Entities.Sopimus_Kiinteisto()
                lisattava.SKSopimusId = sopimusId
                lisattava.SKKiinteistoId = kiinteistoId
                lisattava.SKLuoja = _konteksti.Kayttajatunnus
                lisattava.SKLuotu = Date.Now
                lisattava.SKPaivittaja = _konteksti.Kayttajatunnus
                lisattava.SKPaivitetty = Date.Now
                tietokanta.Sopimus_Kiinteisto.Add(lisattava)
                tietokanta.SaveChanges()
                Return lisattava

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function MuokkaaSopimusta(sopimus As DTO.Sopimus, Optional kaikkiTiedot As Boolean = True) As DTO.Sopimus

        Using tietokanta As New Entities.FortumEntities()

            Dim muokattava = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = sopimus.Id)

            Dim muokattu As Entities.Sopimus = Konversiot.Sopimus.MuutaDBOksi(sopimus, muokattava, kaikkiTiedot)

            If Not muokattava Is Nothing Then

                Try

                    tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

                    tietokanta.SaveChanges()

                    Return Konversiot.Sopimus.MuutaDTOksi(muokattava)

                Catch ex As Exception

                    Throw

                End Try

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function MuokkaaSopimusta(sopimus As Entities.Sopimus) As Entities.Sopimus

        If sopimus Is Nothing Then
            Return Nothing
        Else
            If sopimus.SOPId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim muokattava = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = sopimus.SOPId)

            If Not muokattava Is Nothing Then

                Try

                    muokattava.SOPAlkaa = sopimus.SOPAlkaa
                    muokattava.SOPAlkuperainenKorvaus = sopimus.SOPAlkuperainenKorvaus
                    muokattava.SOPAsiakkaanAllekirjoitusPvm = If(sopimus.SOPAsiakkaanAllekirjoitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPAsiakkaanAllekirjoitusPvm)
                    muokattava.SOPDFRooliId = sopimus.SOPDFRooliId
                    muokattava.SOPIban = sopimus.SOPIban
                    muokattava.SOPId = sopimus.SOPId
                    muokattava.SOPInfo = sopimus.SOPInfo
                    muokattava.SOPJulkisuusasteId = sopimus.SOPJulkisuusasteId
                    muokattava.SOPJuridinenYhtioId = sopimus.SOPJuridinenYhtioId
                    muokattava.SOPKarttaliite = sopimus.SOPKarttaliite
                    muokattava.SOPKestoId = sopimus.SOPKestoId
                    muokattava.SOPKorvaa = sopimus.SOPKorvaa
                    muokattava.SOPKuvaus = sopimus.SOPKuvaus
                    muokattava.SOPLuonnonsuojelualue = sopimus.SOPLuonnonsuojelualue
                    muokattava.SOPMaantieteellinenVali = sopimus.SOPMaantieteellinenVali
                    muokattava.SOPMuuTunniste = sopimus.SOPMuuTunniste
                    muokattava.SOPMuuntamoalue = sopimus.SOPMuuntamoalue
                    muokattava.SOPPaasopimusId = sopimus.SOPPaasopimusId
                    muokattava.SOPPaattyy = If(sopimus.SOPPaattyy = SqlDateTime.MinValue, Nothing, sopimus.SOPPaattyy)
                    muokattava.SOPPaivitetty = sopimus.SOPPaivitetty
                    muokattava.SOPPaivittaja = sopimus.SOPPaivittaja
                    muokattava.SOPProjektiAloitusPvm = If(sopimus.SOPProjektiAloitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPProjektiAloitusPvm)
                    muokattava.SOPProjektinumero = sopimus.SOPProjektinumero
                    muokattava.SOPPylvasmaara = sopimus.SOPPylvasmaara
                    muokattava.SOPPylvasvali = sopimus.SOPPylvasvali
                    muokattava.SOPSopimuksenAlaluokkaId = sopimus.SOPSopimuksenAlaluokkaId
                    muokattava.SOPSopimuksenEhtoversioId = sopimus.SOPSopimuksenEhtoversioId
                    muokattava.SOPSopimuksenIrtisanomisaika = sopimus.SOPSopimuksenIrtisanomisaika
                    muokattava.SOPSopimuksenIrtisanomistoimet = sopimus.SOPSopimuksenIrtisanomistoimet
                    muokattava.SOPIrtisanomispvm = If(sopimus.SOPIrtisanomispvm = SqlDateTime.MinValue, Nothing, sopimus.SOPIrtisanomispvm)
                    muokattava.SOPSopimuksenLaatija = sopimus.SOPSopimuksenLaatija
                    muokattava.SOPSopimuksenTilaId = sopimus.SOPSopimuksenTilaId
                    muokattava.SOPSopimusluokkaId = sopimus.SOPSopimusluokkaId
                    muokattava.SOPSopimustyyppiId = sopimus.SOPSopimustyyppiId
                    muokattava.SOPSopimusvuosi = sopimus.SOPSopimusvuosi
                    muokattava.SOPVastaosapuoliSiirtoOikeusId = sopimus.SOPVastaosapuoliSiirtoOikeusId
                    muokattava.SOPVastuuyksikkoId = sopimus.SOPVastuuyksikkoId
                    muokattava.SOPVerkohaltijaSiirtoOikeusId = sopimus.SOPVerkohaltijaSiirtoOikeusId
                    muokattava.SOPVerkonhaltijanAllekirjoitusPvm = If(sopimus.SOPVerkonhaltijanAllekirjoitusPvm = SqlDateTime.MinValue, Nothing, sopimus.SOPVerkonhaltijanAllekirjoitusPvm)
                    muokattava.SOPAlkuperainenYhtioId = sopimus.SOPAlkuperainenYhtioId
                    muokattava.SOPPCSNumero = sopimus.SOPPCSNumero
                    muokattava.SOPProjektinvalvoja = sopimus.SOPProjektinvalvoja
                    muokattava.SOPJatkoaika = sopimus.SOPJatkoaika
                    muokattava.SOPLaskennallinenPaattymispvm = sopimus.SOPLaskennallinenPaattymispvm

                    muokattava.SOPPuustonOmistajuusId = sopimus.SOPPuustonOmistajuusId
                    muokattava.SOPPuustonPoistoId = sopimus.SOPPuustonPoistoId
                    muokattava.SOPKohdekategoriaId = sopimus.SOPKohdekategoriaId

                    muokattava.SOPTiedostoHaettu = sopimus.SOPTiedostoHaettu
                    muokattava.SOPMetatiedotPaivitetty = sopimus.SOPMetatiedotPaivitetty

                    muokattava.SOPLuonnos = sopimus.SOPLuonnos
                    muokattava.SOPKieliId = sopimus.SOPKieliId

                    tietokanta.SaveChanges()
                    Return muokattava

                Catch ex As Exception

                    Throw

                End Try

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function MuokkaaTulostetta(tuloste As DTO.SopimusTuloste) As DTO.SopimusTuloste

        Using tietokanta As New Entities.FortumEntities()

            Dim muokattu As Entities.Sopimus_Tuloste = Konversiot.SopimusTuloste.MuutaDBOksi(tuloste)

            Dim muokattava = tietokanta.Sopimus_Tuloste.FirstOrDefault(Function(x) x.STLId = muokattu.STLId)

            tietokanta.Entry(muokattava).CurrentValues.SetValues(muokattu)

            tietokanta.SaveChanges()

            Return Konversiot.SopimusTuloste.MuutaDTOksi(muokattava)

        End Using

    End Function

    Public Function PoistaSopimus(sopimusId As Integer) As Entities.Sopimus

        If sopimusId = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim poistettava = tietokanta.Sopimus.FirstOrDefault(Function(x) x.SOPId = sopimusId)

            If Not poistettava Is Nothing Then

                tietokanta.Sopimus.Remove(poistettava)
                tietokanta.SaveChanges()
                Return poistettava

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function PoistaSopimusKiinteistolta(sopimusId As Integer, kiinteistoId As Integer) As Integer

        If sopimusId = 0 Or kiinteistoId = 0 Then
            Return 0
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim poistettava = tietokanta.Sopimus_Kiinteisto.FirstOrDefault(Function(x) x.SKSopimusId = sopimusId And x.SKKiinteistoId = kiinteistoId)

            If Not poistettava Is Nothing Then

                tietokanta.Sopimus_Kiinteisto.Remove(poistettava)
                tietokanta.SaveChanges()
                Return sopimusId

            Else

                Return 0

            End If

        End Using

    End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.Sopimus)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.Sopimus)

        Dim sopimusvuosi As String = If(muunnettava.SOPSopimusvuosi Is Nothing, String.Empty, String.Format("({0})", muunnettava.SOPSopimusvuosi.ToString()))
        Dim muuTunniste As String = If(muunnettava.SOPMuuTunniste Is Nothing, String.Empty, muunnettava.SOPMuuTunniste.ToString())

        Dim tunniste = (muuTunniste + " " + sopimusvuosi).Trim()
        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.SOPId
        hakutulos.Nimi = muunnettava.SOPId.ToString() &
            If(String.IsNullOrWhiteSpace(tunniste), String.Empty, String.Format(" ({0})", tunniste)) &
            If(muunnettava.SOPSopimustyyppiId.HasValue AndAlso muunnettava.SOPSopimustyyppiId.Value = CInt(Enumeraattorit.Sopimustyyppi.Sopimuspohja), " (sopimuspohja)", String.Empty)
        hakutulos.Tyyppi = "Sopimus"
        hakutulos.Disabloitu = muunnettava.SOPSopimustyyppiId.HasValue AndAlso muunnettava.SOPSopimustyyppiId.Value = CInt(Enumeraattorit.Sopimustyyppi.Sopimuspohja)
        Return hakutulos

    End Function

#End Region

End Class
