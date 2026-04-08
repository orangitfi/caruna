Public Class Aktiviteetti
    Public Property Luoja As String
    Public Property Luotu As DateTime?
    Public Property Paivittaja As String
    Public Property Paivitetty As DateTime?

    Public Property Id As Integer
    Public Property TahoId As Integer?
    Public Property Taho As Taho
    Public Property SopimusId As Integer?
    Public Property Sopimus As Sopimus
    Public Property KontaktoijaGuid As Guid?

    Public Property Paivamaara As DateTime?
    Public Property SeuraavaYhteydenottoPaivamaara As DateTime?
    Public Property Kuvaus As String
    Public Property Liitetiedostopolku As String

    Public Property YhteydenottotapaId As Integer?
    Public Property Yhteydenottotapa As String

    Public Property LajiId As Integer?
    Public Property Laji As String

    Public Property StatusId As Integer?
    Public Property Status As String
End Class
