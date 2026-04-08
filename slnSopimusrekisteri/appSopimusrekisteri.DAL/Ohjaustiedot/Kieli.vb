Partial Public Class Kieli

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As Entities.hlp_Kieli

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Kieli.FirstOrDefault(Function(x) x.KIEId = id)

    End Using

  End Function

  Public Function Hae() As List(Of Entities.hlp_Kieli)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Kieli.ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(lisattava As Entities.hlp_Kieli) As Entities.hlp_Kieli

    If lisattava Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      lisattava.KIELuoja = "Tuntematon"
      lisattava.KIELuotu = Date.Now
      lisattava.KIEPaivitetty = Date.Now
      lisattava.KIEPaivittaja = "Tuntematon"

      tietokanta.hlp_Kieli.Add(lisattava)
      tietokanta.SaveChanges()
      Return lisattava

    End Using

  End Function

  Public Function Muokkaa(muokattava As Entities.hlp_Kieli) As Entities.hlp_Kieli

    If muokattava Is Nothing Then
      Return Nothing
    Else
      If muokattava.KIEId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kantaversio = tietokanta.hlp_Kieli.FirstOrDefault(Function(x) x.KIEId = muokattava.KIEId)

      If Not kantaversio Is Nothing Then

        tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
        kantaversio.KIEPaivitetty = Date.Now
        kantaversio.KIEPaivittaja = "Tuntematon"

        tietokanta.SaveChanges()
        Return kantaversio

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As Entities.hlp_Kieli

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      If Not tietokanta.Sopimus.Any(Function(x) x.SOPKieliId = id) Then

        Dim poistettava = tietokanta.hlp_Kieli.FirstOrDefault(Function(x) x.KIEId = id)

        If Not poistettava Is Nothing Then

          tietokanta.hlp_Kieli.Remove(poistettava)
          tietokanta.SaveChanges()
          Return poistettava

        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
