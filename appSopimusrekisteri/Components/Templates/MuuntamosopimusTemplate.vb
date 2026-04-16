Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class MuuntamosopimusTemplate
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
      Case "Sivunvaihto"
        If entity.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Count() > 1 Then
          Return MuuntamosopimusTemplateHelpers.HaeSivunVaihto()
        Else
          Return String.Empty
        End If
      Case "KorvausYht"
        If entity.Korvauslaskelmat.Count > 0 Then
          Return entity.Korvauslaskelmat.Sum(Function(x) x.VerollinenSumma).ToString("f2")
        Else
          Return String.Empty
        End If
    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Dim sopimus As Sopimusrekisteri.BLL_CF.Sopimus = CType(entity, Sopimusrekisteri.BLL_CF.Sopimus)

    Select Case key
      Case "JohdonOmistaja"
        Return sopimus.JuridinenYhtio
      Case "Kiinteisto"
        If sopimus.Kiinteistot.Count > 0 Then
          Return sopimus.Kiinteistot.First()
        Else
          Return Nothing
        End If
      Case "MaanOmistaja"
        'maanomistajatietoon otetaan oikea omistaja, allekirjoituskohtiin haetaan tulostetaansopimukseen-täpän perusteella
        If sopimus.Asiakkaat.Any(Function(x) x.AsiakastyyppiId.GetValueOrDefault(0) = Asiakastyypit.Omistaja) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.AsiakastyyppiId.GetValueOrDefault(0) = Asiakastyypit.Omistaja).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "EkaMaanomistaja"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "LoputMaanomistajat"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1)
        Else
          Return Nothing
        End If
      Case "Muuntamo"
        If sopimus.Tunnisteyksikot.Where(Function(x) x.TunnisteyksikkoTyyppiId = TunnisteyksikkoTyypit.Muuntamo).Count() > 0 Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) x.TunnisteyksikkoTyyppiId = TunnisteyksikkoTyypit.Muuntamo).First()
        Else
          Return Nothing
        End If
      Case "Korvaus"
        If sopimus.Korvauslaskelmat.Count > 0 Then
          Return sopimus.Korvauslaskelmat.First()
        Else
          Return Nothing
        End If
    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
    Get
      Dim avaimet = New List(Of String)
      avaimet.Add("JohdonOmistaja")
      avaimet.Add("Kiinteisto")
      avaimet.Add("MaanOmistaja")
      avaimet.Add("EkaMaanomistaja")
      avaimet.Add("LoputMaanomistajat")
      avaimet.Add("Muuntamo")
      avaimet.Add("Korvaus")
      Return avaimet
    End Get
  End Property
End Class

