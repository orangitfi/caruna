Public Class Hakutulos
    Implements iHakutulos

    Public Sub New()

    End Sub

    Public Sub New(ID As Integer, Nimi As String, Tyyppi As String, Optional Disabloitu As Boolean = False)
        Me.ID = ID
        Me.Nimi = Nimi
        Me.Tyyppi = Tyyppi
        Me.Disabloitu = Disabloitu
    End Sub


    Public Property ID As Integer Implements iHakutulos.ID
    Public Property Nimi As String Implements iHakutulos.Nimi
    Public Property Tyyppi As String Implements iHakutulos.Tyyppi
    Public Property Disabloitu As Boolean Implements iHakutulos.Disabloitu

End Class
