Public Interface iHaettava

    Function HaeTulokset(hakuehdot As System.Linq.Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos)

End Interface
