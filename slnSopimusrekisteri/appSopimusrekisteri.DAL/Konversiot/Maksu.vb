Namespace Konversiot

  Public Class Maksu

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Maksu)) As List(Of DTO.Maksu)

      Dim tulokset = New List(Of DTO.Maksu)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Maksu) As DTO.Maksu

      Dim tulos As New DTO.Maksu()

      tulos.Id = muunnettava.MAKId
      tulos.MaksuEraTunniste = muunnettava.MAKMaksuaineistoId
      tulos.KorvauslaskelmaId = muunnettava.MAKKorvauslaskelmaId
      tulos.Ajopvm = muunnettava.MAKAjoPvm
      tulos.MaksuStatusId = muunnettava.MAKMaksuStatusId
      tulos.Maksupvm = muunnettava.MAKMaksupaiva
      tulos.Summa = muunnettava.MAKSumma
      tulos.Alv = muunnettava.MAKVero
      tulos.Viite = muunnettava.MAKViite
      tulos.Viesti = muunnettava.MAKViesti
      tulos.Vuosi = muunnettava.MAKVuosi
      tulos.Tilinumero = muunnettava.MAKTilinumero
      tulos.BicKoodi = muunnettava.MAKBic
      tulos.Luoja = muunnettava.MAKLuoja
      tulos.Luotu = muunnettava.MAKLuotu
      tulos.Saaja = muunnettava.MAKSaaja
      tulos.SaajaId = muunnettava.MAKSaajaId
      tulos.OnIndeksi = muunnettava.MAKOnIndeksi
      tulos.Indeksi = muunnettava.MAKIndeksi
      tulos.IndeksikuukausiId = muunnettava.MAKIndeksiKuukausiId
      If Not muunnettava.hlps_Kuukausi Is Nothing Then
        tulos.Indeksikuukausi = muunnettava.hlps_Kuukausi.KUUKuukausi
      End If
      tulos.IndeksityyppiId = muunnettava.MAKIndeksityyppiId
      If Not muunnettava.hlp_Indeksityyppi Is Nothing Then
        tulos.Indeksityyppi = muunnettava.hlp_Indeksityyppi.ITYIndeksityyppi
      End If
      tulos.MaksuIndeksi = muunnettava.MAKMaksuIndeksi
      tulos.Info = muunnettava.MAKInfo
      tulos.AlvOsuus = muunnettava.MAKAlvOsuus
      tulos.JuridinenYhtioId = muunnettava.MAKJuridinenYhtioId
      tulos.MaksajanNimi = muunnettava.MAKMaksajanNimi
      tulos.MaksajanTilinro = muunnettava.MAKMaksajanTilinro
      tulos.MaksajanBicKoodi = muunnettava.MAKMaksajanBicKoodi
      tulos.SopimusId = muunnettava.MAKSopimusId
      tulos.Kirjanpidontunniste = muunnettava.MAKKirjanpidonTunniste
      tulos.Palvelutunnus = muunnettava.MAKPalvelutunnus
      tulos.SummaIlmanAlv = muunnettava.MAKSummaIlmanAlv
      tulos.Indeksivuosi = muunnettava.MAKIndeksiVuosi

      If Not muunnettava.Maksu_Tiliointi Is Nothing Then

        Dim lstTilioinnit As New List(Of DTO.MaksunTiliointi)()

        For Each tiliointi As Entities.Maksu_Tiliointi In muunnettava.Maksu_Tiliointi

          lstTilioinnit.Add(MuutaDTOksi(tiliointi))

        Next

        tulos.Tiliointi = lstTilioinnit.ToArray()

      End If

      Return tulos

    End Function

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Maksu_Tiliointi)) As List(Of DTO.MaksunTiliointi)

      Dim tulokset = New List(Of DTO.MaksunTiliointi)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Maksu_Tiliointi) As DTO.MaksunTiliointi

      Dim tulos As New DTO.MaksunTiliointi()

      tulos.Id = muunnettava.MTLId
      tulos.MaksuId = muunnettava.MTLMaksuId
      tulos.Summa = muunnettava.MTLSumma
      tulos.Projektinro = muunnettava.MTLProjektinro
      tulos.Kirjanpidontili = muunnettava.MTLKirjanpidontili
      tulos.Kustannuspaikka = muunnettava.MTLKustannuspaikka
      tulos.InvCost = muunnettava.MTLInvCost
      tulos.Regulation = muunnettava.MTLRegulation
      tulos.Purpose = muunnettava.MTLPurpose
      tulos.Local1 = muunnettava.MTLLocal1
      tulos.Luotu = muunnettava.MTLLuotu
      tulos.Luoja = muunnettava.MTLLuoja
      tulos.AlvOsuus = muunnettava.MTLAlvOsuus
      tulos.SummaIlmanAlv = muunnettava.MTLSummaIlmanAlv

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Maksu)) As List(Of Entities.Maksu)

      Dim tulokset = New List(Of Entities.Maksu)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.Maksu) As Entities.Maksu

      Dim tulos As New Entities.Maksu()

      If muunnettava.Id.HasValue Then
        tulos.MAKId = muunnettava.Id
      End If
      tulos.MAKMaksuaineistoId = muunnettava.MaksuEraTunniste
      tulos.MAKKorvauslaskelmaId = muunnettava.KorvauslaskelmaId
      tulos.MAKAjoPvm = muunnettava.Ajopvm
      tulos.MAKMaksuStatusId = muunnettava.MaksuStatusId
      tulos.MAKMaksupaiva = muunnettava.Maksupvm
      tulos.MAKSumma = muunnettava.Summa
      tulos.MAKVero = muunnettava.Alv
      tulos.MAKViite = muunnettava.Viite
      tulos.MAKViesti = muunnettava.Viesti
      tulos.MAKVuosi = muunnettava.Vuosi
      tulos.MAKTilinumero = muunnettava.Tilinumero
      tulos.MAKBic = muunnettava.BicKoodi
      tulos.MAKLuoja = muunnettava.Luoja
      tulos.MAKLuotu = muunnettava.Luotu
      tulos.MAKSaaja = muunnettava.Saaja
      tulos.MAKSaajaId = muunnettava.SaajaId
      tulos.MAKOnIndeksi = muunnettava.OnIndeksi
      tulos.MAKIndeksiKuukausiId = muunnettava.IndeksikuukausiId
      tulos.MAKIndeksityyppiId = muunnettava.IndeksityyppiId
      tulos.MAKIndeksi = muunnettava.Indeksi
      tulos.MAKMaksuIndeksi = muunnettava.MaksuIndeksi
      tulos.MAKInfo = muunnettava.Info
      tulos.MAKAlvOsuus = muunnettava.AlvOsuus
      tulos.MAKJuridinenYhtioId = muunnettava.JuridinenYhtioId
      tulos.MAKMaksajanNimi = muunnettava.MaksajanNimi
      tulos.MAKMaksajanTilinro = muunnettava.MaksajanTilinro
      tulos.MAKMaksajanBicKoodi = muunnettava.MaksajanBicKoodi
      tulos.MAKSopimusId = muunnettava.SopimusId
      tulos.MAKKirjanpidonTunniste = muunnettava.Kirjanpidontunniste
      tulos.MAKPalvelutunnus = muunnettava.Palvelutunnus
      tulos.MAKSummaIlmanAlv = muunnettava.SummaIlmanAlv
      tulos.MAKIndeksiVuosi = muunnettava.Indeksivuosi

      If Not muunnettava.Tiliointi Is Nothing Then
        For Each tiliointi As DTO.MaksunTiliointi In muunnettava.Tiliointi
          tulos.Maksu_Tiliointi.Add(MuutaDBOksi(tiliointi))
        Next
      End If

      Return tulos

    End Function

    Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.MaksunTiliointi)) As List(Of Entities.Maksu_Tiliointi)

      Dim tulokset = New List(Of Entities.Maksu_Tiliointi)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDBOksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDBOksi(muunnettava As DTO.MaksunTiliointi) As Entities.Maksu_Tiliointi

      Dim tulos As New Entities.Maksu_Tiliointi()

      If muunnettava.Id.HasValue Then
        tulos.MTLId = muunnettava.Id
      End If

      If muunnettava.MaksuId.HasValue Then
        tulos.MTLMaksuId = muunnettava.MaksuId
      End If
      tulos.MTLSumma = muunnettava.Summa
      tulos.MTLProjektinro = muunnettava.Projektinro
      tulos.MTLKirjanpidontili = muunnettava.Kirjanpidontili
      tulos.MTLKustannuspaikka = muunnettava.Kustannuspaikka
      tulos.MTLInvCost = muunnettava.InvCost
      tulos.MTLRegulation = muunnettava.Regulation
      tulos.MTLPurpose = muunnettava.Purpose
      tulos.MTLLocal1 = muunnettava.Local1
      tulos.MTLLuotu = muunnettava.Luotu
      tulos.MTLLuoja = muunnettava.Luoja
      tulos.MTLAlvOsuus = muunnettava.AlvOsuus
      tulos.MTLSummaIlmanAlv = muunnettava.SummaIlmanAlv

      Return tulos

    End Function

  End Class

End Namespace