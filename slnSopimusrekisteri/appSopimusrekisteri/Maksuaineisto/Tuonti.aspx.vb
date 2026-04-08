Public Class MaksuaineistojenTuonti

  Inherits BasePage

  Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

    End If

  End Sub

  Protected Sub btnLataa_Click(sender As Object, e As EventArgs) Handles btnLataa.Click

    Dim rivit = New List(Of String())
    Dim virheellisetRivit = New List(Of String)()

    Using sr As System.IO.StreamReader = New System.IO.StreamReader(FileUpload1.PostedFile.InputStream)

      Dim header = sr.ReadLine()
      Dim headerinSarakkeet = header.Split(";")
      Dim tuontitiedot = New List(Of DTO.MaksuaineistonTuonti)()

      While sr.Peek() >= 0

        Dim rivi = sr.ReadLine()
        Dim rivinSarakkeet = rivi.Split(";")

        If rivinSarakkeet.Length > 0 Then

          If rivinSarakkeet.Length = headerinSarakkeet.Length Then

            Try

              Dim riviDTO = New DTO.MaksuaineistonTuonti()
              riviDTO.Projectno = rivinSarakkeet(0)
              riviDTO.Name = rivinSarakkeet(1)
              riviDTO.TypeOfProject = rivinSarakkeet(2)
              riviDTO.Type = rivinSarakkeet(3)
              riviDTO.Owner = rivinSarakkeet(4)
              riviDTO.Concession = rivinSarakkeet(5)
              riviDTO.CertDate = rivinSarakkeet(6)
              riviDTO.FieldWorkStartedA = Paivaykset.PalautaPaivays(rivinSarakkeet(7))
              riviDTO.ProjectClosedA = Paivaykset.PalautaPaivays(rivinSarakkeet(8))
              tuontitiedot.Add(riviDTO)

            Catch ex As Exception

              virheellisetRivit.Add(rivi)

            End Try
          Else

            virheellisetRivit.Add(rivi)

          End If
        End If

      End While

      If virheellisetRivit.Any() Then

        Dim virheet As String = String.Empty
        For Each rivi In virheellisetRivit
          virheet = virheet & "\r\n" & rivi
        Next

        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "<script>alert('Tiedostossa oli virheellisiä rivejä: " + virheet.Replace("'", """") + "');</script>", False)

      Else

        Dim tietokanta = New BLL.Maksuaineisto(_konteksti)
        Dim palautusarvo = tietokanta.TuoMaksuaineisto(tuontitiedot)
        If palautusarvo.Ok Then

          ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "<script>alert('Tiedot ladattiin onnistuneesti!');</script>", False)

        Else

          Dim virheet As String = String.Empty
          For Each epaonnistunut As DTO.Virhe In palautusarvo.Virheet
            Dim virheilmoitus = epaonnistunut.Virhe.Message.Replace("'", "")
            If Not epaonnistunut.Virhe.InnerException Is Nothing Then
              virheilmoitus = virheilmoitus & " | " & epaonnistunut.Virhe.InnerException.Message.Replace("'", "")
            End If
            virheet = virheet & "\r\nProjektino " & CType(epaonnistunut.Data, DTO.MaksuaineistonTuonti).Projectno & " (" & virheilmoitus & ")"
          Next

          ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "alertMessage", "<script>alert('Tietojen tallennus tietokantaan epäonnistui seuraaville projekteille: " + virheet + "');</script>", False)

        End If

      End If

    End Using

  End Sub

End Class
