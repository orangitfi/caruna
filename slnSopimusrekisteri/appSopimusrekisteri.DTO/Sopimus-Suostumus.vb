Public Class Suostumussopimus

  Public Property JohdonOmistaja As SuostumussopimusJohdonOmistaja
  Public Property Maanomistaja As SuostumussopimusMaanomistaja
  Public Property Sopimusnumero As Integer?

  Sub New()

    JohdonOmistaja = New SuostumussopimusJohdonOmistaja()
    Maanomistaja = New SuostumussopimusMaanomistaja()

  End Sub

End Class

Public Class SuostumussopimusJohdonOmistaja

  Public Property Nimi As String
  Public Property Osoite As String
  Public Property Linjaosa As String
  Public Property Karttalehti As String
  Public Property Tyonumero As String

End Class

Public Class SuostumussopimusMaanomistaja

  Public Property Nimi As String
  Public Property Osoite As String
  Public Property TilanNimi As String
  Public Property TilanKyla As String
  Public Property TilanKunta As String

End Class
