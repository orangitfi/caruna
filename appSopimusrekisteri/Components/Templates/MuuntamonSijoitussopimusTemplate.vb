Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class MuuntamonSijoitussopimusTemplate
  Inherits TemplateEntityBase(Of Sopimusrekisteri.BLL_CF.Sopimus)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Sopimusrekisteri.BLL_CF.Sopimus) As String

    Select Case key
      Case "SopimuksenLaatija"
        Return If(String.IsNullOrEmpty(entity.SopimuksenLaatija), String.Empty, entity.SopimuksenLaatija)
      Case "Sopimusnumero"
        Return entity.Id
      Case "ViivakoodiSopimusnumero"
        If entity.Id.ToString().Length Mod 2 <> 0 Then
          Return "0" & entity.Id.ToString()
        End If

        Return entity.Id
      Case "PCSNumero"
        Return If(String.IsNullOrEmpty(entity.PCSNumero), String.Empty, entity.PCSNumero)
      Case "Karttalehti"
        Return If(String.IsNullOrEmpty(entity.Karttaliite), String.Empty, entity.Karttaliite)
      Case "PuustonOmistajuus"
        If Not entity.PuustonOmistajuus Is Nothing Then
          If entity.KieliId = Kielet.Ruotsi Then
            Return If(String.IsNullOrEmpty(entity.PuustonOmistajuus.NimiSwe), String.Empty, entity.PuustonOmistajuus.NimiSwe)
          Else
            Return If(String.IsNullOrEmpty(entity.PuustonOmistajuus.Nimi), String.Empty, entity.PuustonOmistajuus.Nimi)
          End If
        Else
          Return String.Empty
        End If
      Case "PuustonPoisto"
        If Not entity.PuustonPoisto Is Nothing Then
          If entity.KieliId = Kielet.Ruotsi Then
            Return If(String.IsNullOrEmpty(entity.PuustonPoisto.NimiSwe), String.Empty, entity.PuustonPoisto.NimiSwe)
          Else
            Return If(String.IsNullOrEmpty(entity.PuustonPoisto.Nimi), String.Empty, entity.PuustonPoisto.Nimi)
          End If
        Else
          Return String.Empty
        End If
      Case "KorvausYht"
        If entity.Korvauslaskelmat.Count > 0 Then
          Return entity.Korvauslaskelmat.Sum(Function(x) x.VerollinenSumma).ToString("f2")
        Else
          Return String.Empty
        End If
      Case "Alkupvm"
        If entity.Alkaa.HasValue Then
          Return entity.Alkaa.Value.ToString("dd.MM.yyyy")
        Else
          Return String.Empty
        End If
      Case "Loppupvm"
        If entity.Paattyy.HasValue Then
          Return entity.Paattyy.Value.ToString("dd.MM.yyyy")
        Else
          Return String.Empty
        End If
      Case "Erityisehdot"
        Return If(String.IsNullOrEmpty(entity.Erityisehdot), String.Empty, entity.Erityisehdot)
      Case "Karttaliite"
        Return If(String.IsNullOrEmpty(entity.Karttaliite), String.Empty, entity.Karttaliite)
      Case Else

        If key.StartsWith("Sivunvaihto") Then

          Return JASTemplateHelpers.HaeSivunVaihto(entity, key)

        End If

    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Dim sopimus As Sopimusrekisteri.BLL_CF.Sopimus = CType(entity, Sopimusrekisteri.BLL_CF.Sopimus)

    Select Case key
      Case "Korvaus"
        If sopimus.Korvauslaskelmat.Count > 0 Then
          Return sopimus.Korvauslaskelmat.First()
        Else
          Return Nothing
        End If
      Case "JohdonOmistaja"
        Return sopimus.JuridinenYhtio
      Case "MaanOmistaja"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MaanOmistajat"
        Return sopimus.Asiakkaat.Where(Function(x) x.AsiakastyyppiId.GetValueOrDefault(0) = Asiakastyypit.Omistaja).Select(Function(x) x.Taho).ToList()
      Case "SeuraavatMaanOmistajat"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1).Take(2)
        Else
          Return Nothing
        End If
      Case "LoputMaanOmistajat"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(3)
        Else
          Return Nothing
        End If
      Case "Kiinteistot"
        Return sopimus.Kiinteistot
      Case "LinjaOsa"
        If sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Count() > 0 Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MuutLinjaOsat"
        If sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Count() > 1 Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).Skip(1)
        Else
          Return Nothing
        End If
      Case "Muuntamo"
        If sopimus.Tunnisteyksikot.Where(Function(x) x.TunnisteyksikkoTyyppiId = TunnisteyksikkoTyypit.Muuntamo).Count() > 0 Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) x.TunnisteyksikkoTyyppiId = TunnisteyksikkoTyypit.Muuntamo).First()
        Else
          Return Nothing
        End If
      Case "Kiinteisto"
        If sopimus.Kiinteistot.Count > 0 Then
          Return sopimus.Kiinteistot.First()
        Else
          Return Nothing
        End If
    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
    Get
      Dim avaimet = New List(Of String)
      avaimet.Add("Korvaus")
      avaimet.Add("JohdonOmistaja")
      avaimet.Add("MaanOmistaja")
      avaimet.Add("MaanOmistajat")
      avaimet.Add("SeuraavatMaanOmistajat")
      avaimet.Add("LoputMaanOmistajat")
      avaimet.Add("Kiinteistot")
      avaimet.Add("LinjaOsa")
      avaimet.Add("MuutLinjaOsat")
      avaimet.Add("Kiinteisto")
      avaimet.Add("Muuntamo")
      Return avaimet
    End Get
  End Property

End Class
