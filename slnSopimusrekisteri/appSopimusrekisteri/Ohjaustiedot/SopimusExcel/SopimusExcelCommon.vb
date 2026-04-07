Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils.Mapping
Imports Sopimusrekisteri.DAL_CF

Public Class SopimusExcelCommon


    Public Shared ReadOnly Property ColSopimusnumero As String = "* Sopimusnumero"
    Public Shared ReadOnly Property ColSopimustyyppi As String = "* Sopimustyyppi"
    Public Shared ReadOnly Property ColSopimuksenlaatija As String = "Sopimuksen laatija"
    Public Shared ReadOnly Property ColJuridinenYhtio As String = "Juridinen yhtiö"
    Public Shared ReadOnly Property ColKieli As String = "Kieli"
    Public Shared ReadOnly Property ColLuonnos As String = "Luonnos"
    Public Shared ReadOnly Property ColTila As String = "Tila"
    Public Shared ReadOnly Property ColLuovutettujenPylvaidenMaara As String = "Luovutettujen pylväiden määrä"
    Public Shared ReadOnly Property ColAlkupvm As String = "Alkupvm"
    Public Shared ReadOnly Property ColVerkonhaltijanAllekirjoituspvm As String = "Verkonhaltijan allekirjoituspäivämäärä"
    Public Shared ReadOnly Property ColAsiakkaanAllekirjoituspvm As String = "Asiakkaan allekirjoituspäivämäärä"
    Public Shared ReadOnly Property ColProjektinumero As String = "Projektinumero"
    Public Shared ReadOnly Property ColProjektivalvoja As String = "Projektivalvoja"
    Public Shared ReadOnly Property ColEtunimi As String = "(*) Etunimi"
    Public Shared ReadOnly Property ColSukunimi As String = "(*) Sukunimi tai organisaation nimi"
    Public Shared ReadOnly Property ColTunnus As String = "Sopimus-Asiakas välinen tunnus"
    Public Shared ReadOnly Property ColAsiakasnumero As String = "Asiakastunnus"
    Public Shared ReadOnly Property ColYTunnus As String = "Y-tunnus"
    Public Shared ReadOnly Property ColRooli As String = "Rooli"
    Public Shared ReadOnly Property ColPostiosoite As String = "Postiosoite"
    Public Shared ReadOnly Property ColPostinumero As String = "Postinumero"
    Public Shared ReadOnly Property ColPostitoimipaikka As String = "Postitoimipaikka"
    Public Shared ReadOnly Property ColKiinteistoSopimusTunnus As String = "Sopimus-Kiinteistö välinen tunnus"
    Public Shared ReadOnly Property ColKiinteistonumero As String = "Kiinteistönumero"
    Public Shared ReadOnly Property ColKiinteistonNimi As String = "(*) Kiinteistön nimi"
    Public Shared ReadOnly Property ColKiinteistotunnus As String = "Kiinteistötunnus"
    Public Shared ReadOnly Property ColKunta As String = "Kunta"
    Public Shared ReadOnly Property ColTahoTyyppi As String = "(*) Tahon tyyppi"
    Public Shared ReadOnly Property ColAsiakastyyppi As String = "* Asiakastyyppi"
    Public Shared ReadOnly Property ColMuuTunnus As String = "Muu tunnus"
    Public Shared ReadOnly Property ColLisatietoja As String = "Lisätietoja"

    Public Shared ReadOnly Property SheetSopimukset As String = "Sopimukset"
    Public Shared ReadOnly Property SheetAsiakkaat As String = "Sopimusten asiakkaat"
    Public Shared ReadOnly Property SheetKiinteistot As String = "Sopimusten kiinteistöt"

    Public Shared ReadOnly Property StringTrue As String = "Kyllä"
    Public Shared ReadOnly Property StringFalse As String = "Ei"

    Public Shared Function ColumnMappingSopimus(context As KiltaDataContext) As List(Of DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Sopimus))
        Return New List(Of DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Sopimus)) From {
            ColumnSopimus(ColSopimusnumero, GetType(Integer), Function(x) x.Id),
            ColumnSopimus(ColSopimustyyppi, GetType(String), Function(x) x.Sopimustyyppi.SopimustyyppiNimi, "Yksi seuraavista vaihtoehdoista: " + HaeSopimustyypit(context)),
            ColumnSopimus(ColSopimuksenlaatija, GetType(String), Function(x) x.SopimuksenLaatija),
            ColumnSopimus(ColJuridinenYhtio, GetType(String), Function(x) If(Not x.JuridinenYhtio Is Nothing, x.JuridinenYhtio.Nimi, String.Empty), "Yksi seuraavista vaihtoehdoista: " + HaeJuridisetYhtiot(context)),
            ColumnSopimus(ColProjektivalvoja, GetType(String), Function(x) x.Projektinvalvoja),
            ColumnSopimus(ColProjektinumero, GetType(String), Function(x) x.PCSNumero),
            ColumnSopimus(ColAsiakkaanAllekirjoituspvm, GetType(String), Function(x) If(x.AsiakkaanAllekirjoitusPvm.HasValue, x.AsiakkaanAllekirjoitusPvm.Value.ToShortDateString(), String.Empty)),
            ColumnSopimus(ColVerkonhaltijanAllekirjoituspvm, GetType(String), Function(x) If(x.VerkonhaltijanAllekirjoitusPvm.HasValue, x.VerkonhaltijanAllekirjoitusPvm.Value.ToShortDateString(), String.Empty)),
            ColumnSopimus(ColAlkupvm, GetType(String), Function(x) If(x.Alkaa.HasValue, x.Alkaa.Value.ToShortDateString(), String.Empty)),
            ColumnSopimus(ColKieli, GetType(String), Function(x) If(Not x.Kieli Is Nothing, x.Kieli.Nimi, String.Empty), "Yksi seuraavista vaihtoehdoista: " + HaeKielet(context)),
            ColumnSopimus(ColLuonnos, GetType(String), Function(x) If(x.Luonnos, StringTrue, StringFalse), "Kyllä tai Ei. Jos tietoa ei anneta, tai se on joku muu kuin Kyllä tai Ei, niin oletuksena tulee Ei."),
            ColumnSopimus(ColTila, GetType(String), Function(x) If(Not x.SopimuksenTila Is Nothing, x.SopimuksenTila.Nimi, String.Empty), "Yksi seuraavista vaihtoehdoista: " + HaeSopimustilat(context)),
            ColumnSopimus(ColLuovutettujenPylvaidenMaara, GetType(String), Function(x) x.Pylvasvali),
            ColumnSopimus(ColMuuTunnus, GetType(String), Function(x) x.MuuTunniste),
            ColumnSopimus(ColLisatietoja, GetType(String), Function(x) x.Info)
        }
    End Function

    Public Shared Function ColumnMappingAsiakkaat(context As KiltaDataContext) As List(Of DataColumnMapping(Of SopimusTaho))
        Return New List(Of DataColumnMapping(Of SopimusTaho)) From {
            ColumnAsiakas(ColSopimusnumero, GetType(Integer), Function(x) x.SopimusId),
            ColumnAsiakas(ColTunnus, GetType(Integer), Function(x) x.Id, "Jos tietoa ei anneta, niin rivin henkilö tai organisaatio liitetään uutena sopimukselle, vaikka kyseinen henkilö olisi jo sopimuksella. Jos tieto annetaan, niin päivitetään olemassa olevaa linkitystä."),
            ColumnAsiakas(ColAsiakasnumero, GetType(Integer), Function(x) x.TahoId, "Jos tietoa ei anneta niin luodaan uusi henkilö tai organisaatio rekisteriin. Jos tieto annetaan, niin päivitetään olemassa olevan henkilön tietoja."),
            ColumnAsiakas(ColAsiakastyyppi, GetType(String), Function(x) If(Not x.Asiakastyyppi Is Nothing, x.Asiakastyyppi.Nimi, String.Empty), "Yksi seuraavista vaihtoehdoista: " + HaeAsiakastyypit(context)),
            ColumnAsiakas(ColRooli, GetType(String), Function(x) If(Not x.DFRooli Is Nothing, x.DFRooli.Nimi, String.Empty), "Yksi seuraavista vaihtoehdoista: " + HaeDFRoolit(context)),
            ColumnAsiakas(ColEtunimi, GetType(String), Function(x) x.Taho.Etunimi, "Jos '" + ColAsiakasnumero + "' ei ole annettu (uusi henkilö / organisaatio luodaan), niin pakollinen."),
            ColumnAsiakas(ColSukunimi, GetType(String), Function(x) x.Taho.Sukunimi, "Jos '" + ColAsiakasnumero + "' ei ole annettu (uusi henkilö / organisaatio luodaan), niin pakollinen."),
            ColumnAsiakas(ColTahoTyyppi, GetType(String), Function(x) If(Not x.Taho.Tyyppi Is Nothing, x.Taho.Tyyppi.TahoTyyppiNimi, String.Empty), "Jos '" + ColAsiakasnumero + "' ei ole annettu (uusi henkilö / organisaatio luodaan), niin pakollinen. Yksi seuraavista vaihtoehdoista: " + HaeTahotyypit(context)),
            ColumnAsiakas(ColYTunnus, GetType(String), Function(x) x.Taho.Ytunnus),
            ColumnAsiakas(ColPostiosoite, GetType(String), Function(x) x.Taho.Postitusosoite),
            ColumnAsiakas(ColPostinumero, GetType(String), Function(x) x.Taho.Postituspostinro),
            ColumnAsiakas(ColPostitoimipaikka, GetType(String), Function(x) x.Taho.Postituspostitmp)
        }
    End Function

    Public Shared Function ColumnMappingKiinteistot(context As KiltaDataContext) As List(Of DataColumnMapping(Of SopimusKiinteisto))
        Return New List(Of DataColumnMapping(Of SopimusKiinteisto)) From {
            ColumnKiinteisto(ColSopimusnumero, GetType(Integer), Function(x) x.SopimusId),
            ColumnKiinteisto(ColKiinteistoSopimusTunnus, GetType(Integer), Function(x) x.Id, "Jos tietoa ei anneta, niin rivin kiinteistö liitetään uutena sopimukselle, vaikka kyseinen kiinteistö olisi jo sopimuksella. Jos tieto annetaan, niin päivitetään olemassa olevaa linkitystä."),
            ColumnKiinteisto(ColKiinteistonumero, GetType(Integer), Function(x) x.KiinteistoId, "Jos tietoa ei anneta niin luodaan uusi kiinteistö rekisteriin. Jos tieto annetaan, niin päivitetään olemassa olevan kiinteistön tietoja."),
            ColumnKiinteisto(ColKiinteistonNimi, GetType(String), Function(x) x.Kiinteisto.KiinteistoNimi, "Jos '" + ColAsiakasnumero + "' ei ole annettu (uusi henkilö / organisaatio luodaan), niin pakollinen."),
            ColumnKiinteisto(ColKiinteistotunnus, GetType(String), Function(x) x.Kiinteisto.Kiinteistotunnus, "Ilman viivoja."),
            ColumnKiinteisto(ColKunta, GetType(String), Function(x) If(Not x.Kiinteisto.Kunta Is Nothing, x.Kiinteisto.Kunta.KuntaNimi, String.Empty), "Tieto yritetään täsmätä nimellä tuonnissa Killassa oleviin kuntiin. Tuonnissa ilmoitetaan, jos kuntaa ei löydetty. ")
        }
    End Function

    Private Shared Function HaeSopimustyypit(context As KiltaDataContext) As String
        Return String.Join(", ", context.Sopimustyypit.Select(Function(x) x.SopimustyyppiNimi).ToList())
    End Function

    Private Shared Function HaeJuridisetYhtiot(context As KiltaDataContext) As String
        Return String.Join(", ", context.Tahot _
            .Where(Function(x) x.OrganisaationTyyppiId.HasValue AndAlso x.OrganisaationTyyppiId.Value = Organisaatiotyypit.JuridinenYhtio) _
            .Select(Function(x) x.Sukunimi).ToList())
    End Function

    Private Shared Function HaeKielet(context As KiltaDataContext) As String
        Return String.Join(", ", context.Kielet.Select(Function(x) x.Nimi).ToList())
    End Function

    Private Shared Function HaeSopimustilat(context As KiltaDataContext) As String
        Return String.Join(", ", context.SopimuksenTilat.Select(Function(x) x.Nimi).ToList())
    End Function

    Private Shared Function HaeAsiakastyypit(context As KiltaDataContext) As String
        Return String.Join(", ", context.Asiakastyypit.Select(Function(x) x.Nimi).ToList())
    End Function

    Private Shared Function HaeTahotyypit(context As KiltaDataContext) As String
        Return String.Join(", ", context.TahoTyyppi.Select(Function(x) x.TahoTyyppiNimi).ToList())
    End Function

    Private Shared Function HaeDFRoolit(context As KiltaDataContext) As String
        Return String.Join(", ", context.DFRoolit.Select(Function(x) x.Nimi).ToList())
    End Function

    Private Shared Function ColumnSopimus(header As String, tyyppi As Type, arvo As Func(Of Sopimusrekisteri.BLL_CF.Sopimus, Object), Optional description As String = "")
        Return New DataColumnMapping(Of Sopimusrekisteri.BLL_CF.Sopimus)(header, tyyppi, arvo, description)
    End Function

    Private Shared Function ColumnAsiakas(header As String, tyyppi As Type, arvo As Func(Of SopimusTaho, Object), Optional description As String = "")
        Return New DataColumnMapping(Of SopimusTaho)(header, tyyppi, arvo, description)
    End Function

    Private Shared Function ColumnKiinteisto(header As String, tyyppi As Type, arvo As Func(Of SopimusKiinteisto, Object), Optional description As String = "")
        Return New DataColumnMapping(Of SopimusKiinteisto)(header, tyyppi, arvo, description)
    End Function

End Class
