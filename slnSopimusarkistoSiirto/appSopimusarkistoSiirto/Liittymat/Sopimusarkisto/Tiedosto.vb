Namespace Liittymat.Sopimusarkisto

  Public Class Tiedosto
    'propertyjen nimet mätsää tällä hetkellä suoraan Sharepointin kenttänimiin, voisi ehkä muuttaa niin, että Sharepointin kenttänimi tulisi attribuutin kautta

    <Liittymat.Sharepoint.KenttaAttribuutti(Tunniste:=True)> _
    Public Property ID As Integer?
    Public Property EncodedAbsUrl As String
    Public Property ServerUrl As String
    Public Property DocIcon As String
    Public Property LinkFilename As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Yhti_x00f6__Juridinen As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Metatietojen_x0020_viimeistely As String = "Valmis"
    Public Property DocumentID As String
    Public Property LiittyvatDokumentit As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property XMuu_x0020_tunnus As String
    Public Property Asiakirjatarkenne As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Sopimusosapuolet As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property XSopimuksen_x0020_kohde As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Kunta As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Kyl_x00e4_ As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Rekisterinumero0 As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Tilan_x0020_nimi As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Kiinteist_x00f6_tunnus As String
    Public Property Piirustustunnus As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Mappitunniste As String
    Public Property LinkCheckedOutTitle As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Tila As String
    Public Property XKorvaa As String
    Public Property XKorvattu As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Sijainti As String = "Keskusarkisto"
    Public Property Sivuja As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property BU As String = "Save"
    Public Property Asiakirjan_x0020_muutos As String
    Public Property Muutosp_x00e4_iv_x00e4_m_x00e4__x00e4_r_x00e4_ As String
    Public Property Asiakirjatyyppi As String
    Public Property XAsiasanat As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property UseID As String = "S"
    Public Property Document_x0020_Number As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Fyysinen_x0020_formaatti As String = "Paperi"
    Public Property Havitysvastuullinen As String
    Public Property XH_x00e4_vityksen_x0020_suorittaja As String
    Public Property HavitysPvm As String
    Public Property XH_x00e4_vitystapa As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property XLuottamuksellisuus As String = "Sisäinen ja asiakirjan osapuolet"
    Public Property Kieli As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property TargetID As String = "FD"
    Public Property _CopySource As String
    Public Property SPSDescription As String
    Public Property XK_x00e4_ytt_x00f6_rajoitukset As String
    Public Property Laatija_x002f_K_x00e4_sittelij_x00e4_ As String
    Public Property CreateDate As String
    Public Property Liitteet As String
    Public Property Lisatietoa As String
    Public Property Created As String
    Public Property L_x00e4_hetystiedot As String
    Public Property ModifiedBy As String
    Public Property Modified As String
    Public Property Edit As String
    Public Property Editor As String
    Public Property FileLeafRef As String
    Public Property LinkFilenameNoMenu As String
    Public Property Oikeudet As String
    Public Property Owner As String
    Public Property XOrganisaatio As String
    Public Property Title As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Projektitunnus_x0020__x002f__x0020_Nimi As String
    Public Property Rinnakkaisnimeke As String
    Public Property XSaapumistiedot As String
    Public Property Saatavuus As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property ContentType As String = "Sopimusdokumentti"
    Public Property _CheckinComment As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Alkupvm As Date?
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Irtisanomispvm As Date?
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Paattymispvm As Date?
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property Sopimusvuosi As String
    Public Property S_x00e4_hk_x00f6_inen_x0020_allekirjoitus As String
    Public Property XS_x00e4_hk_x00f6_inen_x0020_formaatti As String
    Public Property XS_x00e4_hk_x00f6_inen_x0020_tiedoksianto_x0020_ennen_x0020_h_x00e4_vitt_x00e4_mist_x00e4_ As String
    Public Property XS_x00e4_hk_x00f6_inen_x0020_tiedoksianto_x0020_laatijalle_x002f_k_x00e4_sittelij_x00e4_lle As String
    Public Property S_x00e4_ilytysaika As String
    Public Property XS_x00e4_ilytyshistoria As String
    Public Property XTapahtuma_x0020_ja_x0020_muutosloki As String
    Public Property Author As String
    Public Property FileSizeDisplay As String
    <Liittymat.Sharepoint.KenttaAttribuutti(Paivitettava:=True)> _
    Public Property XTurvaluokka As String = "Security 2"
    Public Property CheckoutUser As String
    Public Property _UIVersionString As String
    Public Property Yhti_x00f6_ As String
    Public Property SopRekNro As Integer?

    Public Sub TaytaOletusTiedot()
      Me.Tila = "Voimassa"
      Me.Metatietojen_x0020_viimeistely = "Valmis"
      Me.Sijainti = "Keskusarkisto"
      Me.Fyysinen_x0020_formaatti = "Paperi"
      Me.TargetID = "FD"
      Me.ContentType = "Sopimusdokumentti"
      Me.XTurvaluokka = "Security 2"
    End Sub

  End Class

End Namespace
