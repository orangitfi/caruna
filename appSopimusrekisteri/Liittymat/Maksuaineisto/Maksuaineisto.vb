Imports Sopimusrekisteri.BLL_CF

Namespace Liittymat.Maksuaineisto

  Public Class Maksuaineisto

    Public Property VirheellinenAineisto As IEnumerable(Of Maksuraportti)
    Public Property TarkistettavaAineisto As IEnumerable(Of Maksuraportti)
    Public Property MaksettavaAineisto As IEnumerable(Of Maksuraportti)
    Public Property Maksut As IEnumerable(Of Maksu)

  End Class

End Namespace