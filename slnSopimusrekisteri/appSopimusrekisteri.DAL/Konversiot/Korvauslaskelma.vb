Namespace Konversiot

  Public Class Korvauslaskelma

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.KorvauslaskelmaRivi)) As List(Of DTO.KorvauslaskelmanRivi)

      Dim tulokset = New List(Of DTO.KorvauslaskelmanRivi)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Korvauslaskelma)) As List(Of DTO.Korvauslaskelma)

      Dim tulokset = New List(Of DTO.Korvauslaskelma)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.KorvauslaskelmaRivi) As DTO.KorvauslaskelmanRivi

      Dim tulos As New DTO.KorvauslaskelmanRivi()

      tulos.Id = muunnettava.KLRId
      tulos.KorvauslaskelmaId = muunnettava.KLRKorvauslaskelmaId
      tulos.KorvaushinnastoId = muunnettava.KLRKorvaushinnastoId
      tulos.Korvaus = muunnettava.KLRKorvaus
      tulos.KuvionTunnus = muunnettava.KLRKuvionTunnus
      tulos.KuvionPituus = muunnettava.KLRKuvionPituus
      tulos.KuvionLeveys = muunnettava.KLRKuvionLeveys
      tulos.KuvionKorvattavaLeveys = muunnettava.KLRKuvionKorvattavaLeveys
      tulos.KokonaisPintaAla = muunnettava.KLRKokonaispintaAla
      tulos.Maara = muunnettava.KLRMaara
      tulos.Lisatieto = muunnettava.KLRInfo
      tulos.Yksikkohinta = muunnettava.KLRYksikkohinta

      If Not muunnettava.KorvausHinnasto Is Nothing Then

        If Not muunnettava.KorvausHinnasto.hlp_Yksikko Is Nothing Then
          tulos.KorvausyksikonKuvaus = muunnettava.KorvausHinnasto.hlp_Yksikko.C_Korvausyksikko
          tulos.Korvausyksikko = muunnettava.KorvausHinnasto.hlp_Yksikko.YKSKorvausyksikko

          If muunnettava.KorvausHinnasto.hlp_Yksikko.YKSKorvausyksikonTyyppiId.HasValue AndAlso [Enum].TryParse(Of DTO.Enumeraattorit.KorvausyksikonTyyppi)(muunnettava.KorvausHinnasto.hlp_Yksikko.YKSKorvausyksikonTyyppiId.Value, Nothing) Then
            tulos.KorvausYksikonTyyppi = muunnettava.KorvausHinnasto.hlp_Yksikko.YKSKorvausyksikonTyyppiId.Value
          End If

        End If

        tulos.Korvauslaji = muunnettava.KorvausHinnasto.KHIKorvauslaji
        tulos.Kuvaus = muunnettava.KorvausHinnasto.KHIKuvaus
        tulos.ArvonPeruste = muunnettava.KorvausHinnasto.KHIArvonPeruste

      End If


      tulos.KirjanpidonTiliId = muunnettava.KLRKirjanpidonTiliId
      If Not muunnettava.hlp_Kirjanpidontili Is Nothing Then
        tulos.KirjanpidonTili = muunnettava.hlp_Kirjanpidontili.KPTKirjanpidonTili
      End If

      tulos.KustannuspaikkaId = muunnettava.KLRKirjanpidonKustannuspaikkaId
      If Not muunnettava.hlp_KirjanpidonKustannuspaikka Is Nothing Then
        tulos.Kustannuspaikka = muunnettava.hlp_KirjanpidonKustannuspaikka.KPKKirjanpidonKustannuspaikka
      End If

      tulos.InvCostId = muunnettava.KLRInvCostId
      If Not muunnettava.hlp_InvCost Is Nothing Then
        tulos.InvCost = muunnettava.hlp_InvCost.ICONimi
      End If

      tulos.RegulationId = muunnettava.KLRRegulationId
      If Not muunnettava.hlp_Regulation Is Nothing Then
        tulos.Regulation = muunnettava.hlp_Regulation.REGNimi
      End If

      tulos.PurposeId = muunnettava.KLRPurposeId
      If Not muunnettava.hlp_Purpose Is Nothing Then
        tulos.Purpose = muunnettava.hlp_Purpose.PURNimi
      End If

      tulos.Local1Id = muunnettava.KLRLocal1Id
      If Not muunnettava.hlp_Local1 Is Nothing Then
        tulos.Local1 = muunnettava.hlp_Local1.LOCNimi
      End If

      tulos.Luotu = muunnettava.KLRLuotu
      tulos.Luoja = muunnettava.KLRLuoja
      tulos.Paivitetty = muunnettava.KLRPaivitetty
      tulos.Paivittaja = muunnettava.KLRPaivittaja

      Return tulos

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Korvauslaskelma) As DTO.Korvauslaskelma

      Dim tulos As New DTO.Korvauslaskelma()

      tulos.Id = muunnettava.KORId
      tulos.SopimusId = muunnettava.KORSopimusId

      tulos.KorvaustyyppiId = muunnettava.KORKorvaustyyppiId

      If Not muunnettava.hlps_Korvaustyyppi Is Nothing Then
        tulos.Korvaustyyppi = muunnettava.hlps_Korvaustyyppi.KTYKorvaustyyppi
      End If

      tulos.KorvausStatusId = muunnettava.KORKorvauslaskelmaStatusId

      If Not muunnettava.hlps_KorvauslaskemaStatus Is Nothing Then
        tulos.KorvausStatus = muunnettava.hlps_KorvauslaskemaStatus.KSTKorvauslaskelmaStatus
      End If

      tulos.MaksunSuoritusId = muunnettava.KORMaksunSuoritusId

      If Not muunnettava.hlp_MaksunSuoritus Is Nothing Then
        tulos.MaksunSuoritus = muunnettava.hlp_MaksunSuoritus.MSUMaksunSuoritus
      End If

      tulos.KorvauksenProjektinumero = muunnettava.KORKorvauksenProjektinumero

      tulos.TypeOfProject = muunnettava.KORTypeOfProject
      tulos.Type = muunnettava.KORType
      tulos.Owner = muunnettava.KOROwner
      tulos.Concession = muunnettava.KORConcession
      tulos.CertDate = muunnettava.KORCertDate
      tulos.FieldWorkStartedA = muunnettava.KORFieldWorkStarted
      tulos.ProjectClosedA = muunnettava.KORProjectClosedA
      tulos.Viite = muunnettava.KORViite
      tulos.Viesti = muunnettava.KORViesti

      tulos.MaksetaanAlv = muunnettava.KORMaksetaanAlv
      tulos.SopimushetkenIndeksi = muunnettava.KORSopimushetkenIndeksiArvo
      tulos.IndeksikuukausiId = muunnettava.KORIndeksiKuukausiId
      If Not muunnettava.hlps_Kuukausi1 Is Nothing Then
        tulos.Indeksikuukausi = muunnettava.hlps_Kuukausi1.KUUKuukausi
      End If
      tulos.OnIndeksi = muunnettava.KOROnIndeksi

      tulos.IndeksityyppiId = muunnettava.KORIndeksityyppiId

      If Not muunnettava.hlp_Indeksityyppi Is Nothing Then
        tulos.Indeksityyppi = muunnettava.hlp_Indeksityyppi.ITYIndeksityyppi
      End If

      tulos.ViimeisinMaksu = muunnettava.KORViimeisinMaksu
      tulos.ViimeisinIndeksi = muunnettava.KORViimeisinIndeksi
      tulos.ViimeisinMaksupvm = muunnettava.KORViimeisinMaksuPvm
      tulos.ViimeisinMaksuIndeksi = muunnettava.KORViimeisinMaksuIndeksi

      tulos.EnsimmainenSallittuMaksupvmAsetettuKasin = muunnettava.KOREnsimmainenMaksupaivaAsetettuKasin
      tulos.EnsimmainenSallittuMaksupvm = muunnettava.KOREnsimmainenSallittuMaksuPvm
      tulos.AlkuperainenKorvaus = muunnettava.KORMaksettavaKorvausAlkuperainen
      tulos.ViimeinenMaksupvm = muunnettava.KORViimeinenMaksuPvm
      tulos.IndeksiVuosi = muunnettava.KORIndeksiVuosi
      tulos.ViimeisinIndeksiVuosi = muunnettava.KORViimeisinIndeksiVuosi

      tulos.MaksukuukausiId = muunnettava.KORMaksuKuukausiId

      If Not muunnettava.hlps_Kuukausi Is Nothing Then
        tulos.Maksukuukausi = muunnettava.hlps_Kuukausi.KUUKuukausi
      End If

      tulos.MaksuehdotId = muunnettava.KORMaksuehdotId

      If Not muunnettava.hlp_Maksuehdot Is Nothing Then
        tulos.Maksuehdot = muunnettava.hlp_Maksuehdot.MEHMaksuehdot
      End If

      tulos.KirjanpidonTiliId = muunnettava.KORKirjanpidonTiliId

      If Not muunnettava.hlp_Kirjanpidontili Is Nothing Then
        tulos.KirjanpidonTili = muunnettava.hlp_Kirjanpidontili.KPTKirjanpidonTili & " " & muunnettava.hlp_Kirjanpidontili.KPTSelite
      End If

      tulos.KustannuspaikkaId = muunnettava.KORKirjanpidonKustannuspaikkaId

      If Not muunnettava.hlp_KirjanpidonKustannuspaikka Is Nothing Then
        tulos.Kustannuspaikka = muunnettava.hlp_KirjanpidonKustannuspaikka.KPKKirjanpidonKustannuspaikka & " " & muunnettava.hlp_KirjanpidonKustannuspaikka.KPKSelite
      End If

      tulos.InvCostId = muunnettava.KORInvCostId

      If Not muunnettava.hlp_InvCost Is Nothing Then
        tulos.InvCost = muunnettava.hlp_InvCost.ICONimi
      End If

      tulos.RegulationId = muunnettava.KORRegulationId

      If Not muunnettava.hlp_Regulation Is Nothing Then
        tulos.Regulation = muunnettava.hlp_Regulation.REGNimi
      End If

      tulos.PurposeId = muunnettava.KORPurposeId

      If Not muunnettava.hlp_Purpose Is Nothing Then
        tulos.Purpose = muunnettava.hlp_Purpose.PURNimi
      End If

      tulos.Local1Id = muunnettava.KORLocal1Id

      If Not muunnettava.hlp_Local1 Is Nothing Then
        tulos.Local1 = muunnettava.hlp_Local1.LOCNimi
      End If

      tulos.AlvId = muunnettava.KORAlvId

      If Not muunnettava.hlp_Alv Is Nothing Then
        tulos.AlvProsentti = muunnettava.hlp_Alv.ALVProsentti
      End If

      tulos.Luotu = muunnettava.KORLuotu
      tulos.Luoja = muunnettava.KORLuoja
      tulos.Paivitetty = muunnettava.KORPaivitetty
      tulos.Paivittaja = muunnettava.KORPaivittaja

      tulos.SaajaId = muunnettava.KORTahoId

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Korvauslaskelma, Optional tulos As Entities.Korvauslaskelma = Nothing, Optional kaikkiTiedot As Boolean = True) As Entities.Korvauslaskelma

      If tulos Is Nothing Then
        tulos = New Entities.Korvauslaskelma()

        tulos.KORLuoja = muunnettava.Luoja
        tulos.KORLuotu = muunnettava.Luotu
      End If

      tulos.KORId = muunnettava.Id
      tulos.KORSopimusId = muunnettava.SopimusId
      tulos.KORKorvaustyyppiId = muunnettava.KorvaustyyppiId
      tulos.KORKorvauslaskelmaStatusId = muunnettava.KorvausStatusId
      tulos.KORMaksunSuoritusId = muunnettava.MaksunSuoritusId
      tulos.KORKorvauksenProjektinumero = muunnettava.KorvauksenProjektinumero
      tulos.KORViite = muunnettava.Viite
      tulos.KORViesti = muunnettava.Viesti
      tulos.KORMaksetaanAlv = muunnettava.MaksetaanAlv
      tulos.KORSopimushetkenIndeksiArvo = muunnettava.SopimushetkenIndeksi
      tulos.KORIndeksiKuukausiId = muunnettava.IndeksikuukausiId
      tulos.KOROnIndeksi = muunnettava.OnIndeksi
      tulos.KORIndeksityyppiId = muunnettava.IndeksityyppiId
      tulos.KOREnsimmainenMaksupaivaAsetettuKasin = muunnettava.EnsimmainenSallittuMaksupvmAsetettuKasin
      tulos.KOREnsimmainenSallittuMaksuPvm = muunnettava.EnsimmainenSallittuMaksupvm
      tulos.KORMaksettavaKorvausAlkuperainen = muunnettava.AlkuperainenKorvaus
      tulos.KORViimeinenMaksuPvm = muunnettava.ViimeinenMaksupvm
      tulos.KORIndeksiVuosi = muunnettava.IndeksiVuosi
      tulos.KORMaksuKuukausiId = muunnettava.MaksukuukausiId
      tulos.KORMaksuehdotId = muunnettava.MaksuehdotId
      tulos.KORKirjanpidonTiliId = muunnettava.KirjanpidonTiliId
      tulos.KORKirjanpidonKustannuspaikkaId = muunnettava.KustannuspaikkaId
      tulos.KORInvCostId = muunnettava.InvCostId
      tulos.KORRegulationId = muunnettava.RegulationId
      tulos.KORPurposeId = muunnettava.PurposeId
      tulos.KORLocal1Id = muunnettava.Local1Id
      tulos.KORPaivittaja = muunnettava.Paivittaja
      tulos.KORPaivitetty = muunnettava.Paivitetty
      tulos.KORTahoId = muunnettava.SaajaId
      tulos.KORViimeisinIndeksiVuosi = muunnettava.ViimeisinIndeksiVuosi
      tulos.KORAlvId = muunnettava.AlvId

      If kaikkiTiedot Then
        tulos.KORViimeisinMaksuPvm = muunnettava.ViimeisinMaksupvm
        tulos.KORViimeisinIndeksi = muunnettava.ViimeisinIndeksi
        tulos.KORViimeisinMaksu = muunnettava.ViimeisinMaksu
        tulos.KORViimeisinMaksuIndeksi = muunnettava.ViimeisinMaksuIndeksi
      End If

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.KorvauslaskelmanRivi) As Entities.KorvauslaskelmaRivi

      Dim tulos As New Entities.KorvauslaskelmaRivi()

      If muunnettava.Id.HasValue Then
        tulos.KLRId = muunnettava.Id
      End If

      tulos.KLRKorvauslaskelmaId = muunnettava.KorvauslaskelmaId
      tulos.KLRKorvaushinnastoId = muunnettava.KorvaushinnastoId
      tulos.KLRKorvaus = muunnettava.Korvaus
      tulos.KLRKuvionTunnus = muunnettava.KuvionTunnus
      tulos.KLRKuvionPituus = muunnettava.KuvionPituus
      tulos.KLRKuvionLeveys = muunnettava.KuvionLeveys
      tulos.KLRKuvionKorvattavaLeveys = muunnettava.KuvionKorvattavaLeveys
      tulos.KLRKokonaispintaAla = muunnettava.KokonaisPintaAla
      tulos.KLRMaara = muunnettava.Maara
      tulos.KLRYksikkohinta = muunnettava.Yksikkohinta
      tulos.KLRInfo = muunnettava.Lisatieto
      tulos.KLRKirjanpidonTiliId = muunnettava.KirjanpidonTiliId
      tulos.KLRKirjanpidonKustannuspaikkaId = muunnettava.KustannuspaikkaId
      tulos.KLRInvCostId = muunnettava.InvCostId
      tulos.KLRRegulationId = muunnettava.RegulationId
      tulos.KLRPurposeId = muunnettava.PurposeId
      tulos.KLRLocal1Id = muunnettava.Local1Id

      If muunnettava.Luotu.HasValue Then
        tulos.KLRLuotu = muunnettava.Luotu
      End If

      If Not String.IsNullOrEmpty(muunnettava.Luoja) Then
        tulos.KLRLuoja = muunnettava.Luoja
      End If

      If muunnettava.Paivitetty.HasValue Then
        tulos.KLRPaivitetty = muunnettava.Paivitetty
      End If

      If Not String.IsNullOrEmpty(muunnettava.Paivittaja) Then
        tulos.KLRPaivittaja = muunnettava.Paivittaja
      End If

      Return tulos

    End Function

  End Class

End Namespace