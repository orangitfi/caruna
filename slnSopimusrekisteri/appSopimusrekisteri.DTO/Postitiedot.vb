Public Class Postitiedot

    Public Property Postinumero As String
    Public Property Postitoimipaikka As String
    Public Property KuntaId As Integer

    Default Public ReadOnly Property Item(Key As String) As String
        Get
            Return Settings(Key)
        End Get
    End Property
    Private Settings As New Dictionary(Of String, String)

End Class
