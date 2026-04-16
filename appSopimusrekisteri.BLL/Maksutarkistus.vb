Public Class Maksutarkistus

  Public Shared Sub TarkistaMaksu(maksuaineisto As DTO.Maksuaineisto, maksu As DTO.Maksu, maksuraportit As DTO.Maksuraportti())

    For Each maksuraportti As DTO.Maksuraportti In maksuraportit

      TarkistaSopimuksenTiedot(maksuraportti)
      TarkistaSaajanTiedot(maksuraportti)
      TarkistaKorvauslaskelmanTiedot(maksuraportti)
      TarkistaKorvaustenTiedot(maksuraportti)

    Next

    If maksuraportit.Where(Function(x) x.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto).Any() Then
      maksuaineisto.VirheellinenAineisto.AddRange(maksuraportit)
    Else
      maksuaineisto.MaksettavaAineisto.AddRange(maksuraportit)
      maksuaineisto.Maksut.Add(maksu)
    End If

  End Sub

  Private Shared Sub TarkistaSopimuksenTiedot(ByVal maksuraportti As DTO.Maksuraportti)

    If String.IsNullOrWhiteSpace(maksuraportti.MaksajanTilinro) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.MaksajanTilinro = "Yhtiön tilinumero puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.MaksajanBicKoodi) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.MaksajanBicKoodi = "Yhtiön BIC puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.Palvelutunnus) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Palvelutunnus = "Yhtiön palvelutunnus puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.Kirjanpidontunniste) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Kirjanpidontunniste = "Yhtiön kirjanpidontunniste puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.JuridinenYhtioConcession) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.JuridinenYhtioConcession = "Yhtiön concession puuttuu"
    End If

  End Sub

  Private Shared Sub TarkistaSaajanTiedot(ByVal maksuraportti As DTO.Maksuraportti)

    If String.IsNullOrWhiteSpace(maksuraportti.Saaja) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Saaja = "Saaja puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.BicKoodi) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.BicKoodi = "BIC puuttuu"
    End If

    If String.IsNullOrWhiteSpace(maksuraportti.Tilinumero) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Tilinumero = "Tilinumero puuttuu"
    End If

  End Sub

  Private Shared Sub TarkistaKorvauslaskelmanTiedot(ByVal maksuraportti As DTO.Maksuraportti)

    If String.IsNullOrWhiteSpace(maksuraportti.Viite) And String.IsNullOrWhiteSpace(maksuraportti.Viesti) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Viesti = "Viesti puuttuu"
      maksuraportti.Viite = "Viite puuttuu"
    End If

    If (maksuraportti.ProjectClosedA.HasValue AndAlso maksuraportti.ProjectClosedA.Value <= Date.Now) And String.IsNullOrEmpty(maksuraportti.KorvauksenProjektinumero) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      'maksuraportti.MaksuaineistonVirheet.Add("Korvauksen projekti on suljettu")
    End If

  End Sub

  Private Shared Sub TarkistaKorvaustenTiedot(ByVal maksuraportti As DTO.Maksuraportti)

    If String.IsNullOrEmpty(maksuraportti.Kustannuspaikka) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Kustannuspaikka = "Kustannuspaikka puuttuu"
    End If

    If String.IsNullOrEmpty(maksuraportti.Kirjanpidontili) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Kirjanpidontili = "Kirjanpidontili puuttuu"
    End If

    'PCS-raportin tiedot --

    Dim tarkistetaanPCSTiedot As Boolean = True
    If maksuraportti.EnsimmainenMaksupvm.HasValue AndAlso maksuraportti.EnsimmainenMaksupvmSyotettyKasin = True Then
      tarkistetaanPCSTiedot = False
    End If

    If tarkistetaanPCSTiedot Then

      If String.IsNullOrEmpty(maksuraportti.TypeOfProject) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.TypeOfProject = "TypeOfProject puuttuu"
      End If

      If String.IsNullOrEmpty(maksuraportti.Type) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.Type = "Type puuttuu"
      End If

      If String.IsNullOrEmpty(maksuraportti.Owner) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.Owner = "Owner puuttuu"
      End If

      If String.IsNullOrEmpty(maksuraportti.Concession) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.Concession = "Concession puuttuu"
      End If

      If String.IsNullOrEmpty(maksuraportti.CertDate) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.CertDate = "CertDate puuttuu"
      End If

      If Not maksuraportti.FieldWorkStartedA.HasValue And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        'Maksuaineisto.MaksuaineistonVirheet.Add("FieldWorkStartedA puuttuu")
      End If

      If maksuraportti.Concession <> maksuraportti.JuridinenYhtioConcession Then
        maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
        maksuraportti.Concession = String.Format("({0}) Ei täsmää juridiseen yhtiöön", maksuraportti.Concession)
      End If

    End If

    'PCS-raportin tiedot päättyy

    If maksuraportti.KorvauksienSumma = 0 Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      'Maksuaineisto.MaksuaineistonVirheet.Add("Korvauslaskelman summa on 0 euroa")
    End If

    If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksityyppi) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Indeksityyppi = "Indeksityyppi puuttuu"
    End If

    If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksikuukausi) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Indeksikuukausi = "Indeksikuukausi puuttuu"
    End If

    If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksi) Then
      maksuraportti.MaksuaineistonRyhma = DTO.MaksuaineistonRyhma.VirheellinenAineisto
      maksuraportti.Indeksi = "Indeksi puuttuu"
    End If

  End Sub

End Class
