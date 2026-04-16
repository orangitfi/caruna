Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class SuostumusTemplate
  Inherits TemplateEntityBase(Of Sopimusrekisteri.BLL_CF.Sopimus)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Sopimusrekisteri.BLL_CF.Sopimus) As String

    Dim sivunvaihto1 As Boolean = False
    Dim sivunvaihto2 As Boolean = False

    If entity.Kiinteistot.Count() + entity.Tunnisteyksikot.Count() + entity.Asiakkaat.Where(Function(x) x.AsiakastyyppiId.GetValueOrDefault(0) = Asiakastyypit.Omistaja).Count() > 14 Then
      sivunvaihto1 = True
    End If

    If Not sivunvaihto1 And (entity.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Or entity.Tunnisteyksikot.Count() > 2) Then
      sivunvaihto2 = True
    End If

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
      Case "Sivunvaihto"
        If sivunvaihto2 Then
          Return SuostumusTemplateHelpers.HaeSivunVaihto()
        Else
          Return String.Empty
        End If
      Case "SivunvaihtoTilat1"
        If sivunvaihto1 Then
          Return SuostumusTemplateHelpers.HaeSivunVaihto()
        Else
          Return String.Empty
        End If
    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Dim sopimus As Sopimusrekisteri.BLL_CF.Sopimus = CType(entity, Sopimusrekisteri.BLL_CF.Sopimus)

    Select Case key
      Case "Kiinteistot"
        Return sopimus.Kiinteistot
      Case "JohdonOmistaja"
          Return sopimus.JuridinenYhtio
      Case "Maanomistaja"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MaanOmistajat"
        'maanomistajalistaukseen otetaan oikeat omistajat, allekirjoituskohtiin haetaan tulostetaansopimukseen-täpän perusteella
        Return sopimus.Asiakkaat.Where(Function(x) x.AsiakastyyppiId.GetValueOrDefault(0) = Asiakastyypit.Omistaja).Select(Function(x) x.Taho)
      Case "LoputMaanOmistajat"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1)
        Else
          Return Nothing
        End If
      Case "LoputMaanOmistajatPareittain"
        If sopimus.Asiakkaat.Any(Function(x) x.TulostetaanSopimukseen) Then
          Dim tulostettavat As IEnumerable(Of Sopimusrekisteri.BLL_CF.Taho) = sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1)
          Return tulostettavat.Where(Function(x, i) i Mod 2 = 0).Zip(Of Sopimusrekisteri.BLL_CF.Taho, Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho))(tulostettavat.Where(Function(x, i) i Mod 2 = 1).Concat({Nothing}), Function(x, y) New Tuple(Of Sopimusrekisteri.BLL_CF.Taho, Sopimusrekisteri.BLL_CF.Taho)(x, y))
        Else
          Return Nothing
        End If
      Case "LinjaOsa"
        If sopimus.Tunnisteyksikot.Any(Function(x) Not String.IsNullOrEmpty(x.Nimi)) Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MuutLinjaOsat"
        If sopimus.Tunnisteyksikot.Any(Function(x) Not String.IsNullOrEmpty(x.Nimi)) Then
          Return sopimus.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).Skip(1)
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
      avaimet.Add("Maanomistaja")
      avaimet.Add("Kiinteistot")
      avaimet.Add("Kiinteistot2")
      avaimet.Add("LinjaOsa")
      avaimet.Add("MuutLinjaOsat")
      avaimet.Add("LoputMaanOmistajat")
      avaimet.Add("LoputMaanOmistajatPareittain")
      avaimet.Add("MaanOmistajat")
      Return avaimet
    End Get
  End Property

End Class
