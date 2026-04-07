Public Module Teksti

    Public Function Lue(merkkijono As Object) As String

        If merkkijono Is Nothing Then
            Return String.Empty
        Else
            If merkkijono.GetType() = GetType(String) Then
                Return merkkijono
            ElseIf merkkijono.GetType() = GetType(DateTime) Then
                Return String.Format("{0:dd.MM.yyyy}", merkkijono)
            Else
                Throw New NotImplementedException("Ohjelmoijan virhe. Tällä metodilla voidaan evaluoida vain tiettyjä tyyppejä!")
            End If

        End If

    End Function

End Module
