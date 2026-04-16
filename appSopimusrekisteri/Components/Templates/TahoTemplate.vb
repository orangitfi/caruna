Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class TahoTemplate
    Inherits TemplateEntityBase(Of Sopimusrekisteri.BLL_CF.Taho)

    Sub New(context As ITemplateContext)

        MyBase.New(context)

    End Sub

    Protected Overrides Function GetPropertyValue(ByVal key As String, ByVal entity As Sopimusrekisteri.BLL_CF.Taho) As String

        Select Case key
            Case "Nimi"
                Return If(String.IsNullOrEmpty(entity.Nimi), String.Empty, entity.Nimi)
            Case "Sukunimi"
                Return If(String.IsNullOrEmpty(entity.Sukunimi), String.Empty, entity.Sukunimi)
            Case "Etunimi"
                Return If(String.IsNullOrEmpty(entity.Etunimi), String.Empty, entity.Etunimi)
            Case "Nimitarkenne"
                Return If(String.IsNullOrEmpty(entity.Nimitarkenne), String.Empty, entity.Nimitarkenne)
            Case "Tilinumero"
                Return If(String.IsNullOrEmpty(entity.Tilinumero), String.Empty, entity.Tilinumero)
            Case "Osoite"
                Return entity.Postitusosoite & " " & entity.Postituspostinro & " " & entity.Postituspostitmp
            Case "Postiosoite"
                Return entity.Postitusosoite
            Case "Postinumero"
                Return entity.Postituspostinro
            Case "Postitoimipaikka"
                Return entity.Postituspostitmp
            Case "Syntymaaika"
                Return String.Empty
            Case "YTunnus"
                Return If(String.IsNullOrEmpty(entity.Ytunnus), String.Empty, entity.Ytunnus)
            Case "Puhelin"
                Return If(String.IsNullOrEmpty(entity.Puhelin), String.Empty, entity.Puhelin)
            Case "Email"
                Return If(String.IsNullOrEmpty(entity.Email), String.Empty, entity.Email)
        End Select

        Return Nothing

    End Function

    Public Overrides Function GetSubEntity(ByVal key As String, ByVal entity As Object) As Object

        Return Nothing

    End Function

    Public Overrides ReadOnly Property SubEntityKeys() As IEnumerable(Of String)
        Get
            Return Nothing
        End Get
    End Property

End Class
