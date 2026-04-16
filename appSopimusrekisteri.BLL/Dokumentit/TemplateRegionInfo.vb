Public Class TemplateRegionInfo

    Public Sub New()

    End Sub

    Public Sub New(args As String)
        Me.LoadArgs(args)
    End Sub

    Public Property Key As String

    Public Property Delimiter As String

    Public Property FontSize As Integer?

    Public Sub LoadArgs(args As String)

        Dim parts As String() = args.Split(";"c)

        For Each s As String In parts
            Me.ParseArgString(s)
        Next

    End Sub

    Private Sub ParseArgString(argItem As String)

        Dim parts As String() = argItem.Split("="c)

        Dim key As String = parts(0)
        Dim value As String = parts(1).Substring(1, parts(1).Length - 2)

        Me.SetArgValue(key, value)

    End Sub

    Private Sub SetArgValue(key As String, value As String)

        Select Case key
            Case "key"
                Me.Key = value
            Case "d"
                Me.Delimiter = value
            Case "s"
                Me.FontSize = Int32.Parse(value)
        End Select

    End Sub

End Class
