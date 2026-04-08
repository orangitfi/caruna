Imports appSopimusrekisteri.DTO

Public Class SuostumusTemplate
  Inherits TemplateEntityBase(Of DTO.Sopimus)

  Sub New(context As ITemplateContext)

    MyBase.New(context)

  End Sub

  Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As DTO.Sopimus) As String

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
        If entity.Tahot.Where(Function(x) x.TulostetaanSopimukseen).Count() > 1 Or entity.Tunnisteyksikot.Count() > 2 Then
          Return SuostumusTemplateHelpers.HaeSivunVaihto()
        Else
          Return String.Empty
        End If
    End Select

    Throw New NotImplementedException("Toteutus avaimelle " + key + " puuttuu!")

  End Function

  Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

    Select Case key
      Case "Kiinteisto"
        If CType(entity, DTO.Sopimus).Kiinteistot.Count > 0 Then
          Return CType(entity, DTO.Sopimus).Kiinteistot.First()
        Else
          Return Nothing
        End If
      Case "JohdonOmistaja"
        Return CType(entity, DTO.Sopimus).JuridinenYhtio
      Case "Maanomistaja"
        If CType(entity, DTO.Sopimus).Tahot.Where(Function(x) x.TulostetaanSopimukseen).Count() > 0 Then
          Return CType(entity, DTO.Sopimus).Tahot.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MaanOmistajat"
        Return CType(entity, DTO.Sopimus).Tahot.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho)
      Case "LoputMaanOmistajat"
        If CType(entity, DTO.Sopimus).Tahot.Any(Function(x) x.TulostetaanSopimukseen) Then
          Return CType(entity, DTO.Sopimus).Tahot.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1)
        Else
          Return Nothing
        End If
      Case "LoputMaanOmistajatPareittain"
        If CType(entity, DTO.Sopimus).Tahot.Any(Function(x) x.TulostetaanSopimukseen) Then
          Dim tulostettavat As IEnumerable(Of DTO.Taho) = CType(entity, DTO.Sopimus).Tahot.Where(Function(x) x.TulostetaanSopimukseen).Select(Function(x) x.Taho).OrderBy(Function(x) x.Id).Skip(1)
          Return tulostettavat.Where(Function(x, i) i Mod 2 = 0).Zip(Of DTO.Taho, Tuple(Of DTO.Taho, DTO.Taho))(tulostettavat.Where(Function(x, i) i Mod 2 = 1).Concat({Nothing}), Function(x, y) New Tuple(Of DTO.Taho, DTO.Taho)(x, y))
        Else
          Return Nothing
        End If
      Case "LinjaOsa"
        If CType(entity, DTO.Sopimus).Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Count() > 0 Then
          Return CType(entity, DTO.Sopimus).Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).First()
        Else
          Return Nothing
        End If
      Case "MuutLinjaOsat"
        If CType(entity, DTO.Sopimus).Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Count() > 1 Then
          Return CType(entity, DTO.Sopimus).Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).OrderBy(Function(x) x.Id).Skip(1)
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
      avaimet.Add("Kiinteisto")
      avaimet.Add("LinjaOsa")
      avaimet.Add("MuutLinjaOsat")
      avaimet.Add("LoputMaanOmistajat")
      avaimet.Add("LoputMaanOmistajatPareittain")
      avaimet.Add("MaanOmistajat")
      Return avaimet
    End Get
  End Property

End Class
