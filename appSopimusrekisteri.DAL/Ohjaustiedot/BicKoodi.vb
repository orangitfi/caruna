Partial Public Class BicKoodi

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As Entities.hlp_BicKoodi

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_BicKoodi.FirstOrDefault(Function(x) x.BKId = id)

    End Using

  End Function

  Public Function Hae() As List(Of Entities.hlp_BicKoodi)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_BicKoodi.ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(lisattava As Entities.hlp_BicKoodi) As Entities.hlp_BicKoodi

    If lisattava Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      lisattava.BKLuoja = "Tuntematon"
      lisattava.BKLuotu = Date.Now
      lisattava.BKPaivitetty = Date.Now
      lisattava.BKPaivittaja = "Tuntematon"

      tietokanta.hlp_BicKoodi.Add(lisattava)
      tietokanta.SaveChanges()
      Return lisattava

    End Using

  End Function

  Public Function Muokkaa(muokattava As Entities.hlp_BicKoodi) As Entities.hlp_BicKoodi

    If muokattava Is Nothing Then
      Return Nothing
    Else
      If muokattava.BKId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kantaversio = tietokanta.hlp_BicKoodi.FirstOrDefault(Function(x) x.BKId = muokattava.BKId)

      If Not kantaversio Is Nothing Then

        tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
        kantaversio.BKPaivitetty = Date.Now
        kantaversio.BKPaivittaja = "Tuntematon"

        tietokanta.SaveChanges()
        Return kantaversio

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As Entities.hlp_BicKoodi

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      If Not tietokanta.Taho.Any(Function(x) x.TAHBicKoodiId = id) Then

        Dim poistettava = tietokanta.hlp_BicKoodi.FirstOrDefault(Function(x) x.BKId = id)

        If Not poistettava Is Nothing Then

          tietokanta.hlp_BicKoodi.Remove(poistettava)
          tietokanta.SaveChanges()
          Return poistettava

        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
