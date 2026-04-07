Namespace Konversiot

  Public Class Aktiviteetti

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Aktiviteetti)) As List(Of DTO.Aktiviteetti)
      Dim tulos As List(Of DTO.Aktiviteetti) = New List(Of DTO.Aktiviteetti)
      For Each muunnettava In muunnettavat
        tulos.Add(MuutaDTOksi(muunnettava))
      Next
      Return tulos
    End Function

    Public Shared Function MuutaDTOksi(ByVal muunnettava As Entities.Aktiviteetti) As DTO.Aktiviteetti
      Dim tulos = New DTO.Aktiviteetti()

      tulos.Luoja = muunnettava.AKLuoja
      tulos.Luotu = muunnettava.AKLuotu
      tulos.Paivittaja = muunnettava.AKPaivittaja
      tulos.Paivitetty = muunnettava.AKPaivitetty

      tulos.Id = muunnettava.AKId
      tulos.TahoId = muunnettava.AKTahoId
      tulos.SopimusId = muunnettava.AKTSopimusId

      tulos.KontaktoijaGuid = muunnettava.AKKontaktoijaId

      tulos.Paivamaara = muunnettava.AKPaivamaara
      tulos.SeuraavaYhteydenottoPaivamaara = muunnettava.AKSeuraavaYhteyspaiva
      tulos.Kuvaus = muunnettava.AKKuvaus
      tulos.Liitetiedostopolku = muunnettava.AKLiitetiedostoPolku

      tulos.YhteydenottotapaId = muunnettava.AKYhteystapaId
      If Not IsNothing(muunnettava.hlp_AktiviteettiYhteystapa) Then
        tulos.Yhteydenottotapa = muunnettava.hlp_AktiviteettiYhteystapa.YTAYhteystapa
      End If

      tulos.LajiId = muunnettava.AKAktiviteetinLajiId
      If Not IsNothing(muunnettava.hlp_AktiviteetinLaji) Then
        tulos.Laji = muunnettava.hlp_AktiviteetinLaji.ALLaji
      End If

      tulos.StatusId = muunnettava.AKStatusId
      If Not IsNothing(muunnettava.hlp_AktiviteetinStatus) Then
        tulos.Status = muunnettava.hlp_AktiviteetinStatus.ASAktiviteetinStatus
      End If
      Return tulos
    End Function

    Public Shared Function MuutaDBOksi(ByVal muunnettava As DTO.Aktiviteetti, Optional ByVal tulos As Entities.Aktiviteetti = Nothing) As Entities.Aktiviteetti
      If tulos Is Nothing Then
        tulos = New Entities.Aktiviteetti()

        tulos.AKLuoja = muunnettava.Luoja
        tulos.AKLuotu = muunnettava.Luotu
      End If

      tulos.AKPaivittaja = muunnettava.Paivittaja
      tulos.AKPaivitetty = muunnettava.Paivitetty

      tulos.AKId = muunnettava.Id
      If Not IsNothing(muunnettava.Taho) Then
        tulos.AKTahoId = muunnettava.Taho.Id
      End If

      If Not IsNothing(muunnettava.Sopimus) Then
        tulos.AKTSopimusId = muunnettava.Sopimus.Id
      End If

      tulos.AKKontaktoijaId = muunnettava.KontaktoijaGuid

      tulos.AKPaivamaara = muunnettava.Paivamaara
      tulos.AKSeuraavaYhteyspaiva = muunnettava.SeuraavaYhteydenottoPaivamaara
      tulos.AKKuvaus = muunnettava.Kuvaus
      tulos.AKLiitetiedostoPolku = muunnettava.Liitetiedostopolku

      tulos.AKYhteystapaId = muunnettava.YhteydenottotapaId
      tulos.AKAktiviteetinLajiId = muunnettava.LajiId
      tulos.AKStatusId = muunnettava.StatusId
      Return tulos
    End Function

  End Class

End Namespace

