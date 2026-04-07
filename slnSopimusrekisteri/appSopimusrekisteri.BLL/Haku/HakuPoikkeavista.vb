

' Tässä tiedostossa on osatoteutus Hakuluokasta.
' Tämän tiedoston hakumetodit palauttavat jotakin 
' muuta kuin iHakutuloksia palauttavia funktioita.

Partial Public Class Haku

#Region "Hakumetodit"

  Public Function HaePostitiedot(postinumero As String) As appSopimusrekisteri.DTO.Postitiedot

    Dim tietokanta = New DAL.Postitiedot()
    Return tietokanta.HaeTulokset(postinumero.Trim())

  End Function

  Public Function HaeKunta(kuntanumero As String) As DTO.iHakutulos

    Dim tietokanta As New DAL.Kunta()

    Dim kunnat As List(Of DTO.iHakutulos) = tietokanta.HaeKunta(kuntanumero)

    If kunnat.Count > 0 Then
      Return kunnat.First()
    Else
      Return Nothing
    End If

  End Function

    Public Function HaeRahalaitosTunnus(tilinumero As String) As String
        Return New DAL.BicKoodi().HaeRahalaitosTunnus(tilinumero)
    End Function

    Public Function HaeBicKoodi(rahalaitostunnus As String) As DTO.iHakutulos

    Dim tietokanta As New DAL.BicKoodi()

    Dim bicKoodit As List(Of DTO.iHakutulos) = tietokanta.HaeBicKoodi(rahalaitostunnus)

    If bicKoodit.Count > 0 Then
      Return bicKoodit.First()
    Else
      Return Nothing
    End If

  End Function

#End Region

End Class
