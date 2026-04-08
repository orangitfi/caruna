Imports appSopimusarkistoSiirto.Liittymat.Sopimusarkisto
Imports Microsoft.VisualBasic.Logging

Module Siirto

  Dim _ts As TraceSource

  Sub Main()

    _ts = ConfigureLogging()

    Try

      Dim client As New SopimusarkistoClient()

      client.PaivitaSopimusarkisto()

      _ts.TraceEvent(TraceEventType.Information, 1, "Siirto tehty " & Date.Now.ToString())

    Catch ex As Exception
      _ts.TraceEvent(TraceEventType.Error, 3, ex.Message & vbCrLf & ex.StackTrace)
    End Try

  End Sub

  Private Function ConfigureLogging() As TraceSource
    Dim ts As TraceSource = New TraceSource("DefaultSource")

    ts.Switch.Level = SourceLevels.All

    Dim objFileLogListener As FileLogTraceListener = Nothing
    Dim objEventLogListener As EventLogTraceListener = Nothing

    For Each objLogListener As TraceListener In ts.Listeners
      If TypeOf objLogListener Is FileLogTraceListener Then
        objFileLogListener = CType(objLogListener, FileLogTraceListener)
      ElseIf TypeOf objLogListener Is EventLogTraceListener Then
        objEventLogListener = CType(objLogListener, EventLogTraceListener)
      End If
    Next

    If objFileLogListener IsNot Nothing Then
      objFileLogListener.Location = LogFileLocation.Custom
      If Not String.IsNullOrEmpty(Konfiguraatiot.LokiPolku) Then
        objFileLogListener.CustomLocation = Konfiguraatiot.LokiPolku
      End If
      objFileLogListener.BaseFileName = "SopimusarkistoSiirto"
      objFileLogListener.LogFileCreationSchedule = LogFileCreationScheduleOption.Weekly
      objFileLogListener.Append = True
      objFileLogListener.Delimiter = ";"
      objFileLogListener.AutoFlush = True
    End If

    If objEventLogListener IsNot Nothing Then

    End If

    Return ts
  End Function

End Module
