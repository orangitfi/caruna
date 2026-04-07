
Public Class Korvaushinnasto

#Region "Hakumetodit"

    Public Function HaeKorvaushinnastot(Optional vainAktiiviset As Boolean = False) As List(Of Entities.KorvausHinnasto)

        Dim tietokanta = New DAL.Korvaushinnasto()
        Return tietokanta.HaeKorvaushinnastot(vainAktiiviset)

    End Function


  Public Function HaeKorvaushinnastot(alakategoriaId As Integer, maksualueId As Integer, Optional valittuId As Integer = 0) As List(Of Entities.KorvausHinnasto)

    Dim tietokanta = New DAL.Korvaushinnasto()
    Return tietokanta.HaeKorvaushinnastot(alakategoriaId, maksualueId, valittuId)

  End Function

    Public Function HaeKorvaushinnasto(id As Integer) As Entities.KorvausHinnasto

        Dim tietokanta = New DAL.Korvaushinnasto()
        Return tietokanta.HaeKorvaushinnasto(id)

    End Function

#End Region

#Region "Muokkausmetodit"

  Public Sub PassivoiKaikki()

    Dim tietokanta = New DAL.Korvaushinnasto()
    tietokanta.PassivoiKaikki()

  End Sub

  Public Sub LisaaKorvaushinnastot(korvaushinnastot As List(Of DTO.Korvaushinnasto))

    Dim tietokanta = New DAL.Korvaushinnasto()
    tietokanta.LisaaKorvaushinnastot(DAL.Konversiot.KorvausHinnasto.MuutaEntityksi(korvaushinnastot))

  End Sub

    Public Function LisaaKorvaushinnasto(korvaushinnasto As Entities.KorvausHinnasto) As Entities.KorvausHinnasto

        Dim tietokanta = New DAL.Korvaushinnasto()
        Return tietokanta.LisaaKorvaushinnasto(korvaushinnasto)

    End Function
    
    Public Function MuokkaaKorvaushinnastoa(korvaushinnasto As Entities.KorvausHinnasto) As Entities.KorvausHinnasto

        Dim tietokanta = New DAL.Korvaushinnasto()
        Return tietokanta.MuokkaaKorvaushinnastoa(korvaushinnasto)

    End Function

    Public Function PoistaKorvaushinnasto(KHIID As Integer) As Entities.KorvausHinnasto

        Dim tietokanta = New DAL.Korvaushinnasto()
        Return tietokanta.PoistaKorvaushinnasto(KHIID)

    End Function

#End Region

End Class
