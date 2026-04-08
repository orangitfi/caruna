Public Class Palautusarvo

    Public Property Tiedot
    Public Property Virheet As List(Of Virhe)
    Public ReadOnly Property Ok() As Boolean
        Get
            Return Not Virheet.Any()
        End Get
    End Property

    Public Sub New()

        Virheet = New List(Of Virhe)()

    End Sub

End Class
