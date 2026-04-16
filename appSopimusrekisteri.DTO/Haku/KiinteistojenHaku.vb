Public Class KiinteistojenHaku

    Public Property ID As Integer
    Public Property Nimi As String
    Public Property Kyla As String
    Public Property Kunta As String
    Public Property Tyyppi As String

    ' ---------------------------------

    Public Property Katuosoite As String
    Public Property Kiinteisto As String
    Public Property Postinumero As String
    Public Property Postitoimipaikka As String
    Public Property Rekisterinumero As String
    Public Property LyhytKiinteistotunnus As String

    Sub New()
        Tyyppi = "Kiinteistö"
    End Sub

End Class
