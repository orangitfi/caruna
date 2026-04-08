Public Class Maksuaineisto

  Public Sub New()

    Me.VirheellinenAineisto = New List(Of Maksuraportti)()
    Me.TarkistettavaAineisto = New List(Of Maksuraportti)()
    Me.MaksettavaAineisto = New List(Of Maksuraportti)()
    Me.Maksut = New List(Of Maksu)()

  End Sub

  Public Property VirheellinenAineisto As List(Of Maksuraportti)
  Public Property TarkistettavaAineisto As List(Of Maksuraportti)
  Public Property MaksettavaAineisto As List(Of Maksuraportti)
  Public Property Maksut As List(Of Maksu)

End Class


