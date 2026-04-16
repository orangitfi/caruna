
Imports appSopimusrekisteri.DTO

' Tässä tiedostossa on osatoteutus Hakuluokasta.
' Tämän tiedoston hakumetodit palauttavat pää-
' taulujen tietoja iHakutulos-muodossa.

Partial Public Class Haku

#Region "Hakumetodit"

  Public Function HaeHenkiloitaNimella(hakusanat As DTO.TahojenHaku) As List(Of DTO.Taho)

  End Function

  Public Function HaeSopimuksenTahot(sopimusId As Integer) As List(Of DTO.Taho)

    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeTuloksetSopimuksille(sopimusId)

  End Function

  Public Function HaeTahot(hakusanat As DTO.TahojenHaku) As List(Of iHakutulos)

    Dim hakuehdot = DAL.Hakuehdot.TahojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeTulokset(hakuehdot)

  End Function

  Public Function HaeKaikkiTahot(hakusanat As DTO.TahojenHaku, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Taho)

    Dim hakuehdot = DAL.Hakuehdot.TahojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiTahot(hakusanat As DTO.TahojenHaku) As List(Of DTO.Taho)

    Dim hakuehdot = DAL.Hakuehdot.TahojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot)

  End Function

  Public Function HaeKaikkiTahot(hakusana As String, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Taho)

    Dim hakuehdot = DAL.Hakuehdot.TahojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiTahot(hakusana As String) As List(Of DTO.Taho)

    Dim hakuehdot = DAL.Hakuehdot.TahojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot)

  End Function

  Public Function HaeTahot(hakusana As String) As List(Of iHakutulos)

    Dim hakuehdot = DAL.Hakuehdot.TahojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeTulokset(hakuehdot)

  End Function

  Public Function HaeTahojenMaara(hakusanat As DTO.TahojenHaku) As Integer

    Dim hakuehdot = DAL.Hakuehdot.TahojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeTahojenMaara(hakuehdot)

  End Function

  Public Function HaeTahojenMaara(hakusana As String) As Integer

    Dim hakuehdot = DAL.Hakuehdot.TahojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Taho()
    Return tietokanta.HaeTahojenMaara(hakuehdot)

  End Function

  Public Function HaeKaikkiKiinteistot(hakusanat As DTO.KiinteistojenHaku, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Kiinteisto)

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiKiinteistot(hakusana As String, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Kiinteisto)

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiKiinteistot(hakusana As String) As List(Of DTO.Kiinteisto)

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot)

  End Function

  Public Function HaeKiinteistot(hakusana As String) As List(Of iHakutulos)

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeTulokset(hakuehdot)

  End Function

  Public Function HaeKiinteistojenMaara(hakusanat As DTO.KiinteistojenHaku) As Integer

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKiinteistojenMaara(hakuehdot)

  End Function

  Public Function HaeKiinteistojenMaara(hakusana As String) As Integer

    Dim hakuehdot = DAL.Hakuehdot.KiinteistojenPerushaku(hakusana)
    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKiinteistojenMaara(hakuehdot)

  End Function

  Public Function HaeSopimukset(hakusanat As DTO.SopimuksienHaku) As List(Of iHakutulos)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeTulokset(hakuehdot)

  End Function

  Public Function HaeSopimukset(hakusana As String) As List(Of iHakutulos)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienPerushaku(hakusana)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeTulokset(hakuehdot)

  End Function

  Public Function HaeKaikkiSopimukset(hakusana As String, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Sopimus)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienPerushaku(hakusana)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiSopimukset(hakusanat As DTO.SopimuksienHaku, Optional jarjestyssarake As String = "", Optional jarjestyssuunta As String = "") As List(Of DTO.Sopimus)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot, jarjestyssarake, jarjestyssuunta)

  End Function

  Public Function HaeKaikkiSopimukset(hakusanat As DTO.SopimuksienHaku) As List(Of DTO.Sopimus)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot)

  End Function

  Public Function HaeKaikkiSopimukset(hakusana As String) As List(Of DTO.Sopimus)

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienPerushaku(hakusana)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeKaikkiTulokset(hakuehdot)

  End Function


  Public Function HaeSopimustenMaara(hakusanat As DTO.SopimuksienHaku) As Integer

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienTarkkaHaku(hakusanat)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeSopimustenMaara(hakuehdot)

  End Function

  Public Function HaeSopimustenMaara(hakusana As String) As Integer

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienPerushaku(hakusana)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeSopimustenMaara(hakuehdot)

  End Function

  Public Function HaeSopimus(id As Integer) As iHakutulos

    Dim hakuehdot = DAL.Hakuehdot.SopimuksienTunnistehaku(id)
    Dim tietokanta = New DAL.Sopimus()
    Return tietokanta.HaeTulokset(hakuehdot).FirstOrDefault()

  End Function

#End Region

End Class
