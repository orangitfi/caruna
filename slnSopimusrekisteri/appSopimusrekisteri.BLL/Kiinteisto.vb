Public Class Kiinteisto

  Private _konteksti As DTO.DataKonteksti

  Public Sub New(konteksti As DTO.DataKonteksti)
    _konteksti = konteksti
  End Sub

#Region "Hakumetodit"

  Public Function HaeKiinteisto(id As Integer) As Entities.Kiinteisto

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeKiinteisto(id)

  End Function

  Public Function HaeSopimuksenKiinteistot(sopimusId As Integer) As List(Of DTO.Kiinteisto)

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeSopimuksenKiinteistot(sopimusId)

  End Function

  Public Function HaeTahonKiinteistot(henkiloId As Integer) As List(Of DTO.Kiinteisto)

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.HaeTahonKiinteistot(henkiloId)

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function LisaaKiinteisto(kiinteisto As Entities.Kiinteisto) As Entities.Kiinteisto

    kiinteisto.KIIRekisterinumero = LuoRekisterinumero(kiinteisto)
    kiinteisto.KIIKiinteistotunnusLyhyt = LuoLyhytKiinteistotunnus(kiinteisto)

    If Not String.IsNullOrEmpty(kiinteisto.KIIMaaraAla) And kiinteisto.KIIAlueTarkenne = "" Then
      kiinteisto.KIIAlueTarkenne = "Erottamaton"
    End If

    Dim tietokanta = New DAL.Kiinteisto()

    kiinteisto.KIILuoja = _konteksti.Kayttajatunnus
    kiinteisto.KIILuotu = Date.Now
    kiinteisto.KIIPaivittaja = _konteksti.Kayttajatunnus
    kiinteisto.KIIPaivitetty = Date.Now

    Return tietokanta.LisaaKiinteisto(kiinteisto)

  End Function

  Public Function MuokkaaKiinteistoa(kiinteisto As Entities.Kiinteisto) As Entities.Kiinteisto

    kiinteisto.KIIRekisterinumero = LuoRekisterinumero(kiinteisto)
    kiinteisto.KIIKiinteistotunnusLyhyt = LuoLyhytKiinteistotunnus(kiinteisto)

    If Not String.IsNullOrEmpty(kiinteisto.KIIMaaraAla) And kiinteisto.KIIAlueTarkenne = "" Then
      kiinteisto.KIIAlueTarkenne = "Erottamaton"
    End If

    Dim tietokanta = New DAL.Kiinteisto()

    kiinteisto.KIIPaivittaja = _konteksti.Kayttajatunnus
    kiinteisto.KIIPaivitetty = Date.Now

    Return tietokanta.MuokkaaKiinteistoa(kiinteisto)

  End Function

  Public Function PoistaKiinteisto(kiinteistoId As Integer) As Entities.Kiinteisto

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.PoistaKiinteisto(kiinteistoId)

  End Function

  Public Function PoistaKiinteistonOmistaja(kiinteistoId As Integer) As Integer

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.PoistaKiinteistonOmistaja(kiinteistoId)

  End Function

  Public Function PoistaKiinteistoSopimukselta(kiinteistoId As Integer, sopimusId As Integer) As Integer

    Dim tietokanta = New DAL.Kiinteisto()
    Return tietokanta.PoistaKiinteistoSopimuksesta(kiinteistoId, sopimusId)

  End Function

  Private Function LuoRekisterinumero(kiinteisto As Entities.Kiinteisto) As String

    Return String.Format("{0}-{1}", _
                          If(String.IsNullOrWhiteSpace(kiinteisto.KIIKortteli), "0", kiinteisto.KIIKortteli), _
                           If(String.IsNullOrWhiteSpace(kiinteisto.KIITontti), "0", kiinteisto.KIITontti))

  End Function

  Private Function LuoLyhytKiinteistotunnus(kiinteisto As Entities.Kiinteisto) As String

    Dim kuntanumero = 0
    If IsNumeric(kiinteisto.KIIKuntanumero) Then
      kuntanumero = kiinteisto.KIIKuntanumero
    End If

    Dim kylanumero = 0
    If IsNumeric(kiinteisto.KIIKylanumero) Then
      kylanumero = kiinteisto.KIIKylanumero
    End If

    Return String.Format("{0}-{1}-{2}", kuntanumero, kylanumero, LuoRekisterinumero(kiinteisto))

  End Function

#End Region

End Class
