Partial Public Class Lupataho

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As Entities.hlp_Lupataho

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Lupataho.FirstOrDefault(Function(x) x.LPTId = id)

    End Using

  End Function

  Public Function Hae() As List(Of Entities.hlp_Lupataho)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Lupataho.ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(lisattava As Entities.hlp_Lupataho) As Entities.hlp_Lupataho

    If lisattava Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      lisattava.LPTLuoja = "Tuntematon"
      lisattava.LPTLuotu = Date.Now
      lisattava.LPTPaivitetty = Date.Now
      lisattava.LPTPaivittaja = "Tuntematon"

      tietokanta.hlp_Lupataho.Add(lisattava)
      tietokanta.SaveChanges()
      Return lisattava

    End Using

  End Function

  Public Function Muokkaa(muokattava As Entities.hlp_Lupataho) As Entities.hlp_Lupataho

    If muokattava Is Nothing Then
      Return Nothing
    Else
      If muokattava.LPTId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kantaversio = tietokanta.hlp_Lupataho.FirstOrDefault(Function(x) x.LPTId = muokattava.LPTId)

      If Not kantaversio Is Nothing Then

        tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
        kantaversio.LPTPaivitetty = Date.Now
        kantaversio.LPTPaivittaja = "Tuntematon"

        tietokanta.SaveChanges()
        Return kantaversio

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As Entities.hlp_Lupataho

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      If Not tietokanta.Sopimus.Any(Function(x) x.SOPLupatahoId = id) Then

        Dim poistettava = tietokanta.hlp_Lupataho.FirstOrDefault(Function(x) x.LPTId = id)

        If Not poistettava Is Nothing Then

          tietokanta.hlp_Lupataho.Remove(poistettava)
          tietokanta.SaveChanges()
          Return poistettava

        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
