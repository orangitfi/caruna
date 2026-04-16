Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.BLL_CF.Models

Public Class IFRSExcelAsetukset

    Public Property Katselupvm As Date
    Public Property OletettuInflaatio As Decimal
    Public Property Data As IEnumerable(Of IFRSKausi)
    Public Property Vuokratyypit As IEnumerable(Of Vuokratyyppi)

End Class
