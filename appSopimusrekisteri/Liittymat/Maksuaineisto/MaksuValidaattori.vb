Namespace Liittymat.Maksuaineisto

  Public Class MaksuValidaattori

    Public Sub New()

    End Sub

    Public Sub ValidoiMaksu(maksuraportit As IEnumerable(Of Maksuraportti))

      For Each maksuraportti As Maksuraportti In maksuraportit

        ValidoiSopimuksenTiedot(maksuraportti)
        ValidoiSaajanTiedot(maksuraportti)
        ValidoiKorvauslaskelmanTiedot(maksuraportti)
        ValidoiKorvaustenTiedot(maksuraportti)

      Next

    End Sub

    Private Sub ValidoiSopimuksenTiedot(ByVal maksuraportti As Maksuraportti)

      If String.IsNullOrWhiteSpace(maksuraportti.MaksajanTilinro) Then
        maksuraportti.MaksajanTilinro = "Yhtiön tilinumero puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrWhiteSpace(maksuraportti.MaksajanBicKoodi) Then
        maksuraportti.MaksajanBicKoodi = "Yhtiön BIC puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrWhiteSpace(maksuraportti.Palvelutunnus) Then
        maksuraportti.Palvelutunnus = "Yhtiön palvelutunnus puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrWhiteSpace(maksuraportti.Kirjanpidontunniste) Then
        maksuraportti.Kirjanpidontunniste = "Yhtiön kirjanpidontunniste puuttuu"
        Me.Ok = False
      End If

      'If String.IsNullOrWhiteSpace(maksuraportti.JuridinenYhtioConcession) Then
      '  maksuraportti.JuridinenYhtioConcession = "Yhtiön concession puuttuu"
      '  Me.Ok = False
      'End If

      'If maksuraportti.Concession <> maksuraportti.JuridinenYhtioConcession Then
      '  maksuraportti.Concession = String.Format("({0}) Ei täsmää juridiseen yhtiöön", maksuraportti.Concession)
      '  Me.Ok = False
      'End If

      If String.IsNullOrEmpty(maksuraportti.Category) Then
        maksuraportti.Category = "Category puuttuu"
        Me.Ok = False
      End If

      If maksuraportti.Category.Contains("_") Then
        maksuraportti.Category = String.Format("({0}) Category on virheellinen", maksuraportti.Category)
        Me.Ok = False
      End If

    End Sub

    Private Sub ValidoiSaajanTiedot(ByVal maksuraportti As Maksuraportti)

      If String.IsNullOrWhiteSpace(maksuraportti.Saaja) Then
        maksuraportti.Saaja = "Saaja puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrWhiteSpace(maksuraportti.BicKoodi) Then
        maksuraportti.BicKoodi = "BIC puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrWhiteSpace(maksuraportti.Tilinumero) Then
        maksuraportti.Tilinumero = "Tilinumero puuttuu"
        Me.Ok = False
      End If

    End Sub

    Private Sub ValidoiKorvauslaskelmanTiedot(ByVal maksuraportti As Maksuraportti)

      If String.IsNullOrWhiteSpace(maksuraportti.Viite) And String.IsNullOrWhiteSpace(maksuraportti.Viesti) Then
        maksuraportti.Viesti = "Viesti puuttuu"
        maksuraportti.Viite = "Viite puuttuu"
        Me.Ok = False
      End If

      If (maksuraportti.ProjectClosedA.HasValue AndAlso maksuraportti.ProjectClosedA.Value <= Date.Now) And String.IsNullOrEmpty(maksuraportti.KorvauksenProjektinumero) Then
        Me.Ok = False
      End If

    End Sub

    Private Sub ValidoiKorvaustenTiedot(ByVal maksuraportti As Maksuraportti)

      If String.IsNullOrEmpty(maksuraportti.Kustannuspaikka) Then
        maksuraportti.Kustannuspaikka = "Kustannuspaikka puuttuu"
        Me.Ok = False
      End If

      If String.IsNullOrEmpty(maksuraportti.Kirjanpidontili) Then
        maksuraportti.Kirjanpidontili = "Kirjanpidontili puuttuu"
        Me.Ok = False
      End If

      'PCS-raportin tiedot --

      Dim tarkistetaanPCSTiedot As Boolean = True
      If maksuraportti.EnsimmainenMaksupvm.HasValue AndAlso maksuraportti.EnsimmainenMaksupvmSyotettyKasin = True Then
        tarkistetaanPCSTiedot = False
      End If

      If tarkistetaanPCSTiedot Then

        If String.IsNullOrEmpty(maksuraportti.TypeOfProject) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          maksuraportti.TypeOfProject = "TypeOfProject puuttuu"
          Me.Ok = False
        End If

        If String.IsNullOrEmpty(maksuraportti.Type) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          maksuraportti.Type = "Type puuttuu"
          Me.Ok = False
        End If

        If String.IsNullOrEmpty(maksuraportti.Owner) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          maksuraportti.Owner = "Owner puuttuu"
          Me.Ok = False
        End If

        If String.IsNullOrEmpty(maksuraportti.Concession) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          maksuraportti.Concession = "Concession puuttuu"
          Me.Ok = False
        End If

        If String.IsNullOrEmpty(maksuraportti.CertDate) And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          maksuraportti.CertDate = "CertDate puuttuu"
          Me.Ok = False
        End If

        If Not maksuraportti.FieldWorkStartedA.HasValue And maksuraportti.KorvausTyyppiId = DTO.Enumeraattorit.Korvaustyyppi.Kertakorvaus Then
          Me.Ok = False
        End If

      End If

      'PCS-raportin tiedot päättyy

      If maksuraportti.KorvauksienSumma = 0 Then
        Me.Ok = False
      End If

      If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksityyppi) Then
        maksuraportti.Indeksityyppi = "Indeksityyppi puuttuu"
        Me.Ok = False
      End If

      If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksikuukausi) Then
        maksuraportti.Indeksikuukausi = "Indeksikuukausi puuttuu"
        Me.Ok = False
      End If

      If maksuraportti.OnIndeksi And String.IsNullOrEmpty(maksuraportti.Indeksi) Then
        maksuraportti.Indeksi = "Indeksi puuttuu"
        Me.Ok = False
      End If

    End Sub

    Public Property Ok As Boolean = True

  End Class

End Namespace
