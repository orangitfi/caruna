Imports System.Data.SqlTypes

Partial Public Class KirjanpidonTili

#Region "Hakumetodit"

  Public Function Hae(id As Integer) As Entities.hlp_Kirjanpidontili

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Kirjanpidontili.FirstOrDefault(Function(x) x.KPTId = id)

    End Using

  End Function

  Public Function Hae() As List(Of Entities.hlp_Kirjanpidontili)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.hlp_Kirjanpidontili.ToList()

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Function Lisaa(lisattava As Entities.hlp_Kirjanpidontili) As Entities.hlp_Kirjanpidontili

    If lisattava Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      lisattava.KPTLuoja = "Tuntematon"
      lisattava.KPTLuotu = SqlDateTime.MinValue
      lisattava.KPTPaivitetty = SqlDateTime.MinValue
      lisattava.KPTPaivittaja = "Tuntematon"

      tietokanta.hlp_Kirjanpidontili.Add(lisattava)
      tietokanta.SaveChanges()
      Return lisattava

    End Using

  End Function

  Public Function Muokkaa(muokattava As Entities.hlp_Kirjanpidontili) As Entities.hlp_Kirjanpidontili

    If muokattava Is Nothing Then
      Return Nothing
    Else
      If muokattava.KPTId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim kantaversio = tietokanta.hlp_Kirjanpidontili.FirstOrDefault(Function(x) x.KPTId = muokattava.KPTId)

      If Not kantaversio Is Nothing Then

        tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
        kantaversio.KPTLuoja = "Tuntematon"
        kantaversio.KPTLuotu = SqlDateTime.MinValue
        kantaversio.KPTPaivitetty = SqlDateTime.MinValue
        kantaversio.KPTPaivittaja = "Tuntematon"

        tietokanta.SaveChanges()
        Return kantaversio

      Else

        Return Nothing

      End If

    End Using

  End Function

  Public Function Poista(id As Integer) As Entities.hlp_Kirjanpidontili

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      If Not tietokanta.Maksu.Any(Function(x) x.MAKKirjanpidonTiliId = id) And Not tietokanta.Korvauslaskelma.Any(Function(x) x.KORKirjanpidonKustannuspaikkaId = id) And Not tietokanta.KorvauslaskelmaRivi.Any(Function(x) x.KLRKirjanpidonKustannuspaikkaId = id) Then

        Dim poistettava = tietokanta.hlp_Kirjanpidontili.FirstOrDefault(Function(x) x.KPTId = id)

        If Not poistettava Is Nothing Then

          tietokanta.hlp_Kirjanpidontili.Remove(poistettava)
          tietokanta.SaveChanges()
          Return poistettava

        End If

      End If

    End Using

    Return Nothing

  End Function

#End Region

End Class
