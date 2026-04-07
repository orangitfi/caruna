Imports System.Data.SqlTypes

Partial Public Class Maksuehdot

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As Entities.hlp_Maksuehdot

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Maksuehdot.FirstOrDefault(Function(x) x.MEHId = id)

    End Using

  End Function

  Public Function Hae() As List(Of Entities.hlp_Maksuehdot)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Maksuehdot.ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(lisattava As Entities.hlp_Maksuehdot) As Entities.hlp_Maksuehdot

    If lisattava Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      lisattava.MEHLuoja = "Tuntematon"
      lisattava.MEHLuotu = SqlDateTime.MinValue
      lisattava.MEHPaivitetty = SqlDateTime.MinValue
      lisattava.MEHPaivittaja = "Tuntematon"

      tietokanta.hlp_Maksuehdot.Add(lisattava)
      tietokanta.SaveChanges()
      Return lisattava

    End Using

  End Function

  Public Function Muokkaa(muokattava As Entities.hlp_Maksuehdot) As Entities.hlp_Maksuehdot

    If muokattava Is Nothing Then
      Return Nothing
    Else
      If muokattava.MEHId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kantaversio = tietokanta.hlp_Maksuehdot.FirstOrDefault(Function(x) x.MEHId = muokattava.MEHId)

      If Not kantaversio Is Nothing Then

        tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
        kantaversio.MEHLuoja = "Tuntematon"
        kantaversio.MEHLuotu = SqlDateTime.MinValue
        kantaversio.MEHPaivitetty = SqlDateTime.MinValue
        kantaversio.MEHPaivittaja = "Tuntematon"

        tietokanta.SaveChanges()
        Return kantaversio

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As Entities.hlp_Maksuehdot

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      If Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORMaksuehdotId = id) Then

        Dim poistettava = tietokanta.hlp_Maksuehdot.FirstOrDefault(Function(x) x.MEHId = id)

        If Not poistettava Is Nothing Then

          tietokanta.hlp_Maksuehdot.Remove(poistettava)
          tietokanta.SaveChanges()
          Return poistettava

        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
