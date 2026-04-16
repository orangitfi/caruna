Imports Tietotyyppi = appSopimusrekisteri.Entities
Imports appSopimusrekisteri.DTO

Public Class OrganisaationTyyppi

#Region "Hakumetodit"
    Implements iHaettava

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean))) As List(Of iHakutulos) Implements iHaettava.HaeTulokset

    Return Me.HaeTulokset(hakuehdot, Enumeraattorit.KayttooikeusTaso.Laaja)

  End Function

  Public Function HaeTulokset(hakuehdot As Expressions.Expression(Of Func(Of DataRow, Boolean)), kayttoOikeustaso As DTO.Enumeraattorit.KayttooikeusTaso) As List(Of iHakutulos)

    Using tietokanta As New Entities.FortumEntities()

      Dim rivit As IEnumerable(Of Tietotyyppi.hlps_OrganisaationTyyppi)

      If kayttoOikeustaso = Enumeraattorit.KayttooikeusTaso.Suppea Then
        rivit = tietokanta.hlps_OrganisaationTyyppi.Where(Function(x) x.ORTId <> DTO.Enumeraattorit.OrganisaatioTyyppi.JuridinenYhtio).OrderBy(Function(x) x.ORTTyyppi)
      Else
        rivit = tietokanta.hlps_OrganisaationTyyppi.OrderBy(Function(x) x.ORTTyyppi)
      End If

      Return MuutaHakutulokseksi(rivit)

    End Using

  End Function

#End Region

#Region "Konversiometodit"

    Public Function MuutaHakutulokseksi(muunnettavat As IEnumerable(Of Tietotyyppi.hlps_OrganisaationTyyppi)) As List(Of iHakutulos)

        Dim hakutulokset = New List(Of iHakutulos)
        For Each muunnettava In muunnettavat
            hakutulokset.Add(MuutaHakutulokseksi(muunnettava))
        Next
        Return hakutulokset

    End Function

    Private Function MuutaHakutulokseksi(muunnettava As Tietotyyppi.hlps_OrganisaationTyyppi)

        Dim hakutulos = New Hakutulos()
        hakutulos.ID = muunnettava.ORTId
        hakutulos.Nimi = muunnettava.ORTTyyppi
        hakutulos.Tyyppi = "Organisaation tyyppi"
        Return hakutulos

    End Function

#End Region

End Class
