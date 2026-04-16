Imports System.Linq.Expressions
Imports System.Reflection

Public Class Poiminta

  Public Function HaePoimintaEhdot(ehtoId As Integer) As Entities.TallennettuPoimintaehto
    Using tietokanta As New Entities.FortumEntities()
      Dim tulos As Entities.TallennettuPoimintaehto = tietokanta.TallennettuPoimintaehto.First(Function(x) x.TPEId = ehtoId)
      'pakotetaan lataaman ehdot nyt kun on yhteys tietokantaan
      tulos.TallennettuPoimintaehto_Ehto = tulos.TallennettuPoimintaehto_Ehto.ToList()
      Return tulos
    End Using
  End Function

  Public Function HaePoimintaEhtojoukot() As IEnumerable(Of Entities.TallennettuPoimintaehto)
    Using tietokanta As New Entities.FortumEntities()
      Return tietokanta.TallennettuPoimintaehto.ToList()
    End Using
  End Function

  Public Function HaePoimintajoukot() As IEnumerable(Of Entities.TallennettuPoimintajoukko)
    Using tietokanta As New Entities.FortumEntities()
      Return tietokanta.TallennettuPoimintajoukko.ToList()
    End Using
  End Function

  Public Sub PoistaPoimintaEhdot(id As Integer)
    Using tietokanta As New Entities.FortumEntities()
      Dim poistettava As Entities.TallennettuPoimintaehto = tietokanta.TallennettuPoimintaehto.First(Function(x) x.TPEId = id)
      If Not IsNothing(poistettava) Then
        Dim poistettavatEsineet As List(Of Entities.TallennettuPoimintaehto_Ehto) = poistettava.TallennettuPoimintaehto_Ehto.ToList()
        For Each poistettavaEsine As Entities.TallennettuPoimintaehto_Ehto In poistettavatEsineet
          tietokanta.TallennettuPoimintaehto_Ehto.Remove(poistettavaEsine)
        Next
        tietokanta.TallennettuPoimintaehto.Remove(poistettava)
      End If
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Sub PoistaPoimintaJoukko(id As Integer)
    Using tietokanta As New Entities.FortumEntities()
      Dim poistettava As Entities.TallennettuPoimintajoukko = tietokanta.TallennettuPoimintajoukko.First(Function(x) x.TPJId = id)
      If Not IsNothing(poistettava) Then
        Dim poistettavatEsineet As List(Of Entities.TallennettuPoimintajoukko_Taho) = poistettava.TallennettuPoimintajoukko_Taho.ToList()
        For Each poistettavaEsine As Entities.TallennettuPoimintajoukko_Taho In poistettavatEsineet
          tietokanta.TallennettuPoimintajoukko_Taho.Remove(poistettavaEsine)
        Next
        tietokanta.TallennettuPoimintajoukko.Remove(poistettava)
      End If
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Sub TallennaPoimintaEhdot(nimi As String, ehdot As IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto), tyyppi As String, luoja As String)
    Using tietokanta As New Entities.FortumEntities()
      Dim uusiJoukko As New Entities.TallennettuPoimintaehto()
      uusiJoukko.TPENimi = nimi
      uusiJoukko.TPELuoja = luoja
      uusiJoukko.TPELuotu = Date.Now
      uusiJoukko.TPEPoimintaTyyppi = tyyppi
      uusiJoukko = tietokanta.TallennettuPoimintaehto.Add(uusiJoukko)
      tietokanta.SaveChanges()
      For Each poimittu As Entities.TallennettuPoimintaehto_Ehto In ehdot
        poimittu.TPEELuoja = luoja
        poimittu.TPEELuotu = Date.Now
        poimittu.TPEEEhtojoukkoId = uusiJoukko.TPEId
        tietokanta.TallennettuPoimintaehto_Ehto.Add(poimittu)
      Next
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Sub TallennaPoimintaJoukko(nimi As String, luoja As String, sessioId As String)
    Using tietokanta As New Entities.FortumEntities()
      Dim uusiJoukko As New Entities.TallennettuPoimintajoukko()
      uusiJoukko.TPJNimi = nimi
      uusiJoukko.TPJLuoja = luoja
      uusiJoukko.TPJLuotu = Date.Now
      uusiJoukko = tietokanta.TallennettuPoimintajoukko.Add(uusiJoukko)
      tietokanta.SaveChanges()
      For Each poimittu As Entities.Poiminta In tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId)
        Dim uusiPoimittu As New Entities.TallennettuPoimintajoukko_Taho()
        uusiPoimittu.TPJTTallennettuPoimintajoukkoId = uusiJoukko.TPJId
        uusiPoimittu.TPJTEsineId = poimittu.POEntityId
        uusiPoimittu.TPJTEsineTyyppi = poimittu.POTyyppi
        uusiPoimittu.TPJTLuoja = luoja
        uusiPoimittu.TPJTLuotu = Date.Now
        tietokanta.TallennettuPoimintajoukko_Taho.Add(uusiPoimittu)
      Next
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Sub LisaaTallennettuJoukkoPoimintaan(sessioId As String, poimintaJoukkoId As Integer)
    Using tietokanta As New Entities.FortumEntities()
      For Each poimittu As Entities.TallennettuPoimintajoukko_Taho In tietokanta.TallennettuPoimintajoukko.First(Function(x) x.TPJId = poimintaJoukkoId).TallennettuPoimintajoukko_Taho
        Dim uusiPoimittu As New Entities.Poiminta()
        uusiPoimittu.POEntityId = poimittu.TPJTEsineId
        uusiPoimittu.POTyyppi = poimittu.TPJTEsineTyyppi
        uusiPoimittu.POSession = sessioId
        uusiPoimittu.POLuotu = Date.Now
        tietokanta.Poiminta.Add(uusiPoimittu)
      Next
      tietokanta.SaveChanges()
    End Using
  End Sub

  Private Function LisaaPoimintaanTyypilla(ehdot As DTO.Hakuehto(), sessioId As String, sql As String) As Integer
    Using tietokanta As New Entities.FortumEntities()

      Dim parametrit As New List(Of Object)()

      parametrit.Add(sessioId)
      parametrit.Add(sessioId)

      Dim lstEhdot As New List(Of String)()

      Dim hakukentta As PoimintaHakuKentta

      For Each ehto As DTO.Hakuehto In ehdot

        Select Case ehto.Tyyppi
          Case DTO.Hakutyyppi.Sopimus
            hakukentta = SopimusHaku.HaeSopimusEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Kiinteisto
            hakukentta = KiinteistoHaku.HaeKiinteistoEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Taho
            hakukentta = TahoHaku.HaeTahoEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Korvauslaskelma
            hakukentta = KorvauslaskelmaHaku.HaeKorvauslaskelmaEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Korvauslaskelmarivi
            hakukentta = KorvauslaskelmaRiviHaku.HaeKorvauslaskelmaRiviEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Aktiviteetti
            hakukentta = AktiviteettiHaku.HaeAktiviteettiEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Sopimus_Taho
            hakukentta = Sopimus_TahoHaku.HaeSopimus_TahoEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Maksu
            hakukentta = MaksuHaku.HaeMaksuEhtoKentta(ehto.Kentta)
          Case Else
            hakukentta = Nothing
        End Select

        lstEhdot.Add(Hakuehdot.HaeSqlEhto(hakukentta.Nimi, ehto.Operaattori, parametrit.Count))

        If ehto.Operaattori <> DTO.Hakuoperaattori.EiTyhja AndAlso ehto.Operaattori <> DTO.Hakuoperaattori.Tyhja Then
          If hakukentta.Tyyppi = GetType(Date) Then
            parametrit.Add(CDate(ehto.Arvo))
          ElseIf hakukentta.Tyyppi = GetType(Decimal) Then
            parametrit.Add(CDec(ehto.Arvo))
          ElseIf hakukentta.Tyyppi = GetType(Integer) Then
            parametrit.Add(CInt(ehto.Arvo))
          Else
            parametrit.Add(ehto.Arvo)
          End If
        End If

      Next

      If lstEhdot.Count > 0 Then
        sql = sql & " AND " & Join(lstEhdot.ToArray(), " AND ")
      End If

      Return tietokanta.Database.ExecuteSqlCommand(sql, parametrit.ToArray())

    End Using
  End Function

  Public Function LisaaPoimintaanSopimuksia(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "INSERT INTO Poiminta (POEntityId, POSession, POLuotu, POTyyppi) " & _
                        "SELECT DISTINCT SOPId, @p0, GETDATE(), 'sopimus' " & _
                        "FROM Sopimus " & _
                        Me.HaeSopimusJoin() & _
                        "WHERE SOPId NOT IN (SELECT POEntityId FROM Poiminta WHERE POSession=@p1 AND POTyyppi='sopimus') "
    Return LisaaPoimintaanTyypilla(ehdot, sessioId, sql)

  End Function

  Public Function LisaaPoimintaanKiinteistoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "INSERT INTO Poiminta (POEntityId, POSession, POLuotu, POTyyppi) " & _
                        "SELECT DISTINCT KIIId, @p0, GETDATE(), 'kiinteisto' " & _
                        "FROM Kiinteisto " & _
                        Me.HaeKiinteistoJoin() & _
                        "WHERE KIIId NOT IN (SELECT POEntityId FROM Poiminta WHERE POSession=@p1 AND POTyyppi='kiinteisto') "
    Return LisaaPoimintaanTyypilla(ehdot, sessioId, sql)

  End Function

  Public Function LisaaPoimintaanTahoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "INSERT INTO Poiminta (POEntityId, POSession, POLuotu, POTyyppi) " & _
                        "SELECT DISTINCT TAHTahoId, @p0, GETDATE(), 'taho' " & _
                        "FROM Taho " & _
                        Me.HaeTahoJoin() & _
                        "WHERE TAHTahoid NOT IN (SELECT POEntityId FROM Poiminta WHERE POSession=@p1 AND POTyyppi='taho') "
    Return LisaaPoimintaanTyypilla(ehdot, sessioId, sql)

  End Function

  Private Function PoistaPoiminnastaTyypilla(ehdot As DTO.Hakuehto(), sessioId As String, sql As String) As Integer
    Using tietokanta As New Entities.FortumEntities()

      Dim parametrit As New List(Of Object)()

      parametrit.Add(sessioId)
      parametrit.Add(sessioId)

      Dim lstEhdot As New List(Of String)()

      Dim hakukentta As PoimintaHakuKentta

      For Each ehto As DTO.Hakuehto In ehdot

        Select Case ehto.Tyyppi
          Case DTO.Hakutyyppi.Sopimus
            hakukentta = SopimusHaku.HaeSopimusEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Kiinteisto
            hakukentta = KiinteistoHaku.HaeKiinteistoEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Taho
            hakukentta = TahoHaku.HaeTahoEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Korvauslaskelma
            hakukentta = KorvauslaskelmaHaku.HaeKorvauslaskelmaEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Korvauslaskelmarivi
            hakukentta = KorvauslaskelmaRiviHaku.HaeKorvauslaskelmaRiviEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Aktiviteetti
            hakukentta = AktiviteettiHaku.HaeAktiviteettiEhtoKentta(ehto.Kentta)
          Case DTO.Hakutyyppi.Sopimus_Taho
            hakukentta = Sopimus_TahoHaku.HaeSopimus_TahoEhtoKentta(ehto.Kentta)
          Case Else
            hakukentta = Nothing
        End Select

        lstEhdot.Add(Hakuehdot.HaeSqlEhto(hakukentta.Nimi, ehto.Operaattori, parametrit.Count))
        parametrit.Add(ehto.Arvo)

      Next

      If lstEhdot.Count > 0 Then
        sql = sql & " AND " & Join(lstEhdot.ToArray(), " AND ")
      End If

      Return tietokanta.Database.ExecuteSqlCommand(sql, parametrit.ToArray())

    End Using
  End Function

  Public Function PoistaPoiminnastaSopimuksia(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "DELETE FROM Poiminta " & _
                        "FROM Poiminta " & _
                        "INNER JOIN Sopimus ON POEntityId=SOPId " & _
                        Me.HaeSopimusJoin() & _
                        "WHERE POSession=@p1 AND POTyyppi='sopimus' "

    Return PoistaPoiminnastaTyypilla(ehdot, sessioId, sql)

  End Function

  Public Function PoistaPoiminnastaKiinteistoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "DELETE FROM Poiminta " & _
                        "FROM Poiminta " & _
                        "INNER JOIN Kiinteisto ON POEntityId=KIIId " & _
                        Me.HaeKiinteistoJoin() & _
                        "WHERE POSession=@p1 AND POTyyppi='kiinteisto' "

    Return PoistaPoiminnastaTyypilla(ehdot, sessioId, sql)

  End Function

  Public Function PoistaPoiminnastaTahoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim sql As String = "DELETE FROM Poiminta " & _
                        "FROM Poiminta " & _
                        "INNER JOIN Taho ON POEntityId=TAHTahoId " & _
                        Me.HaeTahoJoin() & _
                        "WHERE POSession=@p1 AND POTyyppi='taho' "

    Return PoistaPoiminnastaTyypilla(ehdot, sessioId, sql)

  End Function

  Private Function HaeSopimusJoin() As String

    Return "LEFT JOIN Sopimus_Kiinteisto ON SOPId=SKSopimusId " & _
           "LEFT JOIN Kiinteisto ON SKKiinteistoId=KIIId " & _
           "LEFT JOIN Korvauslaskelma ON KORSopimusId=SOPId " & _
           "LEFT JOIN Korvauslaskelmarivi ON KORId=KLRKorvauslaskelmaId " & _
           "LEFT JOIN Sopimus_Taho ON SOPId=SOTSopimusId " & _
           "LEFT JOIN Taho ON SOTTahoId=TAHTahoId " & _
           "LEFT JOIN Maksu ON SOPId=MAKSopimusId "

  End Function

  Private Function HaeKiinteistoJoin() As String

    Return "LEFT JOIN Sopimus_Kiinteisto ON SKKiinteistoId=KIIId " & _
           "LEFT JOIN Sopimus ON SOPId=SKSopimusId " & _
           "LEFT JOIN Korvauslaskelma ON KORSopimusId=SOPId " & _
           "LEFT JOIN Korvauslaskelmarivi ON KORId=KLRKorvauslaskelmaId " & _
           "LEFT JOIN Sopimus_Taho ON SOPId=SOTSopimusId " & _
           "LEFT JOIN Taho ON SOTTahoId=TAHTahoId "

  End Function

  Private Function HaeTahoJoin() As String

    Return "LEFT JOIN Sopimus_Taho ON SOTTahoId=TAHTahoId " & _
           "LEFT JOIN Sopimus ON SOPId=SOTSopimusId " & _
           "LEFT JOIN Sopimus_Kiinteisto ON SOPId=SKSopimusId " & _
           "LEFT JOIN Kiinteisto ON SKKiinteistoId=KIIId " & _
           "LEFT JOIN Korvauslaskelma ON KORSopimusId=SOPId " & _
           "LEFT JOIN Korvauslaskelmarivi ON KORId=KLRKorvauslaskelmaId "

  End Function

  Public Function TyhjennaPoiminta(sessioId As String) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Dim sql As String = "DELETE FROM Poiminta WHERE POSession=@p0"

      Return tietokanta.Database.ExecuteSqlCommand(sql, sessioId)

    End Using

  End Function

  Public Function HaePoimintaJoukkoSopimukset(sessioId As String) As DTO.Sopimus()

    Using tietokanta As New Entities.FortumEntities()

      Dim lstSarakkeet As New List(Of String)()
      Dim pDTO As New Common.PropertyAvustaja(Of DTO.Sopimus)

      For Each pInfo As PropertyInfo In GetType(DTO.Sopimus).GetProperties()

        Dim s As String = SopimusHaku.HaeSopimusEhtoKentta(pInfo.Name).Nimi
        Dim p As String

        Select Case pInfo.Name
          Case pDTO.HaePropertyNimi(Function(x) x.VerkonhaltijaSiirtoOikeus)
            p = "siirtoOikeusVerkonhaltija."
          Case pDTO.HaePropertyNimi(Function(x) x.VastaosapuoliSiirtoOikeus)
            p = "siirtoOikeusVastaosapuoli."
          Case pDTO.HaePropertyNimi(Function(x) x.AlkuperainenYhtio)
            p = "alkuperainenYhtio."
          Case Else
            p = String.Empty
        End Select

        If Not String.IsNullOrEmpty(s) Then
          lstSarakkeet.Add(p & s & " AS " & pInfo.Name)
        End If

      Next

      Dim sql As String = "SELECT " & Join(lstSarakkeet.ToArray(), ",") & " " & _
                          "FROM Sopimus  " & _
                          "INNER JOIN Poiminta ON SOPId=POEntityId  " & _
                          "LEFT JOIN hlps_Sopimustyyppi ON SOPSopimustyyppiId=STYId  " & _
                          "LEFT JOIN Taho juridinenYhtio ON SOPJuridinenYhtioId=juridinenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_Julkisuusaste ON SOPJulkisuusasteId=JASId " & _
                          "LEFT JOIN hlp_DFRooli ON SOPDFRooliId=DFRId " & _
                          "LEFT JOIN hlp_Kieli ON SOPKieliId=KIEId " & _
                          "LEFT JOIN hlps_YlasopimuksenTyyppi ON SOPYlasopimuksenTyyppiId=YSTId " & _
                          "LEFT JOIN Taho alkuperainenYhtio ON SOPAlkuperainenYhtioId=alkuperainenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_SopimuksenAlaluokka ON SOPSopimuksenAlaluokkaId=SALId " & _
                          "LEFT JOIN hlp_SopimuksenEhtoversio ON SOPSopimuksenEhtoversioId=SEHId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVerkonhaltija ON SOPVerkohaltijaSiirtoOikeusId=siirtoOikeusVerkonhaltija.SOIId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVastaosapuoli ON SOPVastaosapuoliSiirtoOikeusId=siirtoOikeusVastaosapuoli.SOIId " & _
                          "LEFT JOIN hlp_Kohdekategoria ON SOPKohdekategoriaId=KDKId " & _
                          "LEFT JOIN hlp_PuustonPoisto ON SOPPuustonPoistoId=PPOId " & _
                          "LEFT JOIN hlp_PuustonOmistajuus ON SOPPuustonOmistajuusId=POMId " & _
                          "WHERE POSession=@p0 AND POTyyppi='sopimus'"

      Dim sopimukset = tietokanta.Database.SqlQuery(Of DTO.Sopimus)(sql, sessioId)

      Return sopimukset.ToArray()

    End Using

  End Function

  Public Function HaePoimintaJoukkoKiinteistot(sessioId As String) As DTO.Kiinteisto()

    Using tietokanta As New Entities.FortumEntities()

      Dim lstSarakkeet As New List(Of String)()
      Dim pDTO As New Common.PropertyAvustaja(Of DTO.Kiinteisto)

      For Each pInfo As PropertyInfo In GetType(DTO.Kiinteisto).GetProperties()

        Dim s As String = KiinteistoHaku.HaeKiinteistoEhtoKentta(pInfo.Name).Nimi
        Dim p As String

        Select Case pInfo.Name
          Case Else
            p = String.Empty
        End Select

        If Not String.IsNullOrEmpty(s) Then
          lstSarakkeet.Add(p & s & " AS " & pInfo.Name)
        End If

      Next

      Dim sql As String = "SELECT " & Join(lstSarakkeet.ToArray(), ",") & " " & _
                          "FROM Kiinteisto  " & _
                          "INNER JOIN Poiminta ON KIIId=POEntityId  " & _
                          "LEFT JOIN Sopimus_Kiinteisto ON SKKiinteistoId=KIIId " & _
                          "LEFT JOIN Sopimus ON SOPId = SKSopimusId " & _
                          "LEFT JOIN hlps_Sopimustyyppi ON SOPSopimustyyppiId=STYId  " & _
                          "LEFT JOIN Taho juridinenYhtio ON SOPJuridinenYhtioId=juridinenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_Julkisuusaste ON SOPJulkisuusasteId=JASId " & _
                          "LEFT JOIN hlp_DFRooli ON SOPDFRooliId=DFRId " & _
                          "LEFT JOIN hlp_Kieli ON SOPKieliId=KIEId " & _
                          "LEFT JOIN hlps_YlasopimuksenTyyppi ON SOPYlasopimuksenTyyppiId=YSTId " & _
                          "LEFT JOIN Taho alkuperainenYhtio ON SOPAlkuperainenYhtioId=alkuperainenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_SopimuksenAlaluokka ON SOPSopimuksenAlaluokkaId=SALId " & _
                          "LEFT JOIN hlp_SopimuksenEhtoversio ON SOPSopimuksenEhtoversioId=SEHId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVerkonhaltija ON SOPVerkohaltijaSiirtoOikeusId=siirtoOikeusVerkonhaltija.SOIId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVastaosapuoli ON SOPVastaosapuoliSiirtoOikeusId=siirtoOikeusVastaosapuoli.SOIId " & _
                          "LEFT JOIN hlp_Kohdekategoria ON SOPKohdekategoriaId=KDKId " & _
                          "LEFT JOIN hlp_PuustonPoisto ON SOPPuustonPoistoId=PPOId " & _
                          "LEFT JOIN hlp_PuustonOmistajuus ON SOPPuustonOmistajuusId=POMId " & _
                          "WHERE POSession=@p0 AND POTyyppi='kiinteisto'"

      Dim kiinteistot = tietokanta.Database.SqlQuery(Of DTO.Kiinteisto)(sql, sessioId)

      Return kiinteistot.ToArray()

    End Using

  End Function

  Public Function HaePoimintaJoukkoTahot(sessioId As String) As DTO.Taho()

    Using tietokanta As New Entities.FortumEntities()

      Dim lstSarakkeet As New List(Of String)()
      Dim pDTO As New Common.PropertyAvustaja(Of DTO.Taho)

      For Each pInfo As PropertyInfo In GetType(DTO.Taho).GetProperties()

        Dim s As String = TahoHaku.HaeTahoEhtoKentta(pInfo.Name).Nimi
        Dim p As String

        Select Case pInfo.Name
          Case Else
            p = "poimintaTaho."
        End Select

        If Not String.IsNullOrEmpty(s) Then
          lstSarakkeet.Add(p & s & " AS " & pInfo.Name)
        End If

      Next

      Dim sql As String = "SELECT " & Join(lstSarakkeet.ToArray(), ",") & " " & _
                          "FROM Taho poimintaTaho " & _
                          "INNER JOIN Poiminta ON TAHTahoid=POEntityId  " & _
                          "LEFT JOIN Sopimus_Taho ON SOTTahoID=TAHTahoId " & _
                          "LEFT JOIN Sopimus ON SOTSopimusId=SOPId " & _
                          "LEFT JOIN hlps_Sopimustyyppi ON SOPSopimustyyppiId=STYId  " & _
                          "LEFT JOIN Taho juridinenYhtio ON SOPJuridinenYhtioId=juridinenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_Julkisuusaste ON SOPJulkisuusasteId=JASId " & _
                          "LEFT JOIN hlp_DFRooli ON SOPDFRooliId=DFRId " & _
                          "LEFT JOIN hlp_Kieli ON SOPKieliId=KIEId " & _
                          "LEFT JOIN hlps_YlasopimuksenTyyppi ON SOPYlasopimuksenTyyppiId=YSTId " & _
                          "LEFT JOIN Taho alkuperainenYhtio ON SOPAlkuperainenYhtioId=alkuperainenYhtio.TAHTahoId " & _
                          "LEFT JOIN hlp_SopimuksenAlaluokka ON SOPSopimuksenAlaluokkaId=SALId " & _
                          "LEFT JOIN hlp_SopimuksenEhtoversio ON SOPSopimuksenEhtoversioId=SEHId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVerkonhaltija ON SOPVerkohaltijaSiirtoOikeusId=siirtoOikeusVerkonhaltija.SOIId " & _
                          "LEFT JOIN hlp_SiirtoOikeus siirtoOikeusVastaosapuoli ON SOPVastaosapuoliSiirtoOikeusId=siirtoOikeusVastaosapuoli.SOIId " & _
                          "LEFT JOIN hlp_Kohdekategoria ON SOPKohdekategoriaId=KDKId " & _
                          "LEFT JOIN hlp_PuustonPoisto ON SOPPuustonPoistoId=PPOId " & _
                          "LEFT JOIN hlp_PuustonOmistajuus ON SOPPuustonOmistajuusId=POMId " & _
                          "WHERE POSession=@p0 AND POTyyppi='taho'"

      Dim tahot = tietokanta.Database.SqlQuery(Of DTO.Taho)(sql, sessioId)

      Return tahot.ToArray()

    End Using

  End Function

  Public Function HaePoimintaLkm(sessioId As String) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId).Count

    End Using

  End Function

  Public Function HaePoiminnanTyyppi(sessioId As String) As String

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId).First().POTyyppi

    End Using

  End Function

  Public Function HaePoimintaSopimustenLkm(sessioId As String) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId And x.POTyyppi = "sopimus").Count

    End Using

  End Function

  Public Function HaePoimintaKiinteistojenLkm(sessioId As String) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId And x.POTyyppi = "kiinteisto").Count

    End Using

  End Function

  Public Function HaePoimintaTahojenLkm(sessioId As String) As Integer

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.Poiminta.Where(Function(x) x.POSession = sessioId And x.POTyyppi = "taho").Count

    End Using

  End Function

  Public Function TeeAktiviteettiPoiminta(ehdot As DTO.Hakuehto()) As DTO.Aktiviteetti()

    Using tietokanta As New Entities.FortumEntities()

      Dim aktiviteetit = tietokanta.Aktiviteetti.Where(AktiviteettiHaku.HaeAktiviteettiExpressio(ehdot))

      Return Konversiot.Aktiviteetti.MuutaDTOksi(aktiviteetit).ToArray()

    End Using

  End Function

  Public Function TeeKiinteistoPoiminta(ehdot As DTO.Hakuehto()) As DTO.Kiinteisto()

    Using tietokanta As New Entities.FortumEntities()

      Dim kiinteistot = tietokanta.Kiinteisto.Where(KiinteistoHaku.HaeKiinteistoExpressio(ehdot))

      Return Konversiot.Kiinteisto.MuutaDTOksi(kiinteistot).ToArray()

    End Using

  End Function

  Public Function TeeKorvauslaskelmaPoiminta(ehdot As DTO.Hakuehto()) As DTO.Korvauslaskelma()

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmat = tietokanta.Korvauslaskelma.Where(KorvauslaskelmaHaku.HaeKorvauslaskelmaExpressio(ehdot))

      Return Konversiot.Korvauslaskelma.MuutaDTOksi(korvauslaskelmat).ToArray()

    End Using

  End Function

  Public Function TeeKorvauslaskelmariviPoiminta(ehdot As DTO.Hakuehto()) As DTO.KorvauslaskelmanRivi()

    Using tietokanta As New Entities.FortumEntities()

      Dim korvauslaskelmarivit = tietokanta.KorvauslaskelmaRivi.Where(KorvauslaskelmaRiviHaku.HaeKorvauslaskelmaRiviExpressio(ehdot))

      Return Konversiot.Korvauslaskelma.MuutaDTOksi(korvauslaskelmarivit).ToArray()

    End Using

  End Function

  Public Function TeeTahoPoiminta(ehdot As DTO.Hakuehto()) As DTO.Taho()

    Using tietokanta As New Entities.FortumEntities()

      Dim tahot = tietokanta.Taho.Where(TahoHaku.HaeTahoExpressio(ehdot))

      Return Konversiot.Taho.MuutaDTOksi(tahot).ToArray()

    End Using

  End Function

End Class
