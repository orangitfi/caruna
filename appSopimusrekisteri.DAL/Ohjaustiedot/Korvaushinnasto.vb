Imports System.Data.SqlTypes
Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO
Imports LinqKit

Public Class Korvaushinnasto

#Region "Hakumetodit"

  Public Function HaeKorvaushinnastot(alakategoriaId As Integer, maksualueId As Integer, Optional valittuId As Integer = 0) As List(Of Entities.KorvausHinnasto)

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.KorvausHinnasto _
          .Include("hlp_Metsatyyppi") _
          .Include("hlp_Puustolaji") _
          .Include("hlp_Yksikko") _
          .Where(Function(x) x.KHIHinnastoAlakategoriaId = alakategoriaId And x.KHIMaksuAlueId = maksualueId And (x.KHIAktiivinen = True Or x.KHIId = valittuId)) _
          .OrderBy(Function(x) x.KHIKorvauslaji) _
          .ThenBy(Function(x) x.hlp_Metsatyyppi.MTYMetsatyyppi) _
          .ThenBy(Function(x) x.hlp_Puustolaji.PLAPuustolaji) _
          .ThenBy(Function(x) x.KHIPuustonIka) _
          .ThenBy(Function(x) x.KHITaimistonValtapituus) _
          .ThenBy(Function(x) x.KHITiheyskerroin) _
          .ThenBy(Function(x) x.KHIYksikkkohinta) _
          .ThenBy(Function(x) x.hlp_Yksikko.YKSKorvausyksikko) _
          .ThenBy(Function(x) x.KHIYksikkohinnanTarkenne) _
          .ToList()

    End Using

  End Function

  Public Function HaeKorvaushinnastot(Optional vainAktiiviset As Boolean = False) As List(Of Tietotyyppi.KorvausHinnasto)

    Using tietokanta As New Entities.FortumEntities()

      If vainAktiiviset Then
        Return tietokanta.KorvausHinnasto.Include("hlp_Metsatyyppi").Include("hlp_Puustolaji").Include("hlp_Yksikko").Where(Function(x) x.KHIAktiivinen = True).ToList()
      Else
        Return tietokanta.KorvausHinnasto.Include("hlp_Metsatyyppi").Include("hlp_Puustolaji").Include("hlp_Yksikko").ToList()
      End If

    End Using

  End Function

  Public Function HaeKorvaushinnasto(id As Integer) As Tietotyyppi.KorvausHinnasto

    Using tietokanta As New Entities.FortumEntities()

      Return tietokanta.KorvausHinnasto.Include("hlp_Yksikko").FirstOrDefault(Function(x) x.KHIId = id)

    End Using

  End Function

#End Region

#Region "Muokkausmetodit"

  Public Sub PassivoiKaikki()
    Using tietokanta As New Entities.FortumEntities()
      For Each korvaushinnasto As Entities.KorvausHinnasto In tietokanta.KorvausHinnasto
        korvaushinnasto.KHIAktiivinen = False
      Next
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Sub LisaaKorvaushinnastot(korvaushinnastot As List(Of Entities.KorvausHinnasto))
    Using tietokanta As New Entities.FortumEntities()
      For Each korvaushinnasto As Entities.KorvausHinnasto In korvaushinnastot
        tietokanta.KorvausHinnasto.Add(korvaushinnasto)
      Next
      tietokanta.SaveChanges()
    End Using
  End Sub

  Public Function LisaaKorvaushinnasto(korvaushinnasto As Entities.KorvausHinnasto) As Entities.KorvausHinnasto

    If korvaushinnasto Is Nothing Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      korvaushinnasto.KHIAktiivinen = True
      korvaushinnasto.KHILuoja = "Tuntematon"
      korvaushinnasto.KHILuotu = SqlDateTime.MinValue
      korvaushinnasto.KHIPaivittaja = "Tuntematon"
      korvaushinnasto.KHIPaivitetty = SqlDateTime.MinValue
      tietokanta.KorvausHinnasto.Add(korvaushinnasto)
      tietokanta.SaveChanges()
      Return korvaushinnasto

    End Using

  End Function

  Public Function MuokkaaKorvaushinnastoa(korvaushinnasto As Entities.KorvausHinnasto) As Entities.KorvausHinnasto


    If korvaushinnasto Is Nothing Then
      Return Nothing
    Else
      If korvaushinnasto.KHIId = 0 Then
        Return Nothing
      End If
    End If

    Using tietokanta As New Entities.FortumEntities()

      korvaushinnasto.KHILuotu = DateTime.Now
      korvaushinnasto.KHILuoja = "Tuntematon"
      korvaushinnasto.KHIPaivitetty = DateTime.Now
      korvaushinnasto.KHIPaivittaja = "Tuntematon"
      tietokanta.KorvausHinnasto.Attach(korvaushinnasto)
      tietokanta.Entry(korvaushinnasto).State = System.Data.Entity.EntityState.Modified

      tietokanta.SaveChanges()
      Return korvaushinnasto

    End Using

  End Function

  Public Function PoistaKorvaushinnasto(id As Integer) As Entities.KorvausHinnasto

    If id = 0 Then
      Return Nothing
    End If

    Using tietokanta As New Entities.FortumEntities()

      Dim poistettava = tietokanta.KorvausHinnasto.FirstOrDefault(Function(x) x.KHIId = id)

      If Not poistettava Is Nothing Then

        poistettava.KHIAktiivinen = False
        tietokanta.SaveChanges()
        Return poistettava

      Else

        Return Nothing

      End If

    End Using

  End Function

#End Region

End Class
