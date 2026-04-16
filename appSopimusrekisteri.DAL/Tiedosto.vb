Public Class Tiedosto

#Region "Hakumetodit"

    Public Function HaeTiedosto(id As Integer) As DTO.Tiedosto

        Using tietokanta As New Entities.FortumEntities()

            Dim tiedosto As Entities.Tiedosto
            tiedosto = tietokanta.Tiedosto.FirstOrDefault(Function(x) x.TIEId = id)
            Return Konversiot.Tiedosto.MuutaDTOksi(tiedosto)

        End Using

    End Function

    Public Function HaeSopimuksenTiedostot(sopimusId As Integer) As List(Of DTO.Tiedosto)

        Using tietokanta As New Entities.FortumEntities()

            Dim tiedostot = tietokanta.Tiedosto.Where(Function(x) x.TIESopimusId.HasValue And x.TIESopimusId = sopimusId)
            Return Konversiot.Tiedosto.MuutaDTOksi(tiedostot)

        End Using

        Return Nothing

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function LisaaTiedosto(tiedosto As DTO.Tiedosto) As DTO.Tiedosto

        If tiedosto Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim lisattava As Entities.Tiedosto = Konversiot.Tiedosto.MuutaDBOksi(tiedosto)

            tietokanta.Tiedosto.Add(lisattava)
            tietokanta.SaveChanges()

            Return Konversiot.Tiedosto.MuutaDTOksi(lisattava)

        End Using

        Return Nothing

    End Function

    Public Function MuokkaaTiedostoa(tiedosto As DTO.Tiedosto) As DTO.Tiedosto

        Using tietokanta As New Entities.FortumEntities()

            Dim muokattu As Entities.Tiedosto = Konversiot.Tiedosto.MuutaDBOksi(tiedosto)

            Dim muokattava = tietokanta.Tiedosto.FirstOrDefault(Function(x) x.TIEId = tiedosto.Id)

            If Not muokattava Is Nothing Then

                muokattava.TIETiedostoNimi = muokattu.TIETiedostoNimi
                muokattava.TIEURL = muokattu.TIEURL
                muokattava.TIESelite = muokattu.TIESelite
                muokattava.TIETiedostoLahdeId = muokattu.TIETiedostoLahdeId
                muokattava.TIESopimusId = muokattu.TIESopimusId
                muokattava.TIESharePointId = muokattu.TIESharePointId
                muokattava.TIEArkistonSijaintiId = muokattu.TIEArkistonSijaintiId
                muokattava.TIEDocumentID = muokattu.TIEDocumentID
                muokattava.TIEArkistointiTunniste = muokattu.TIEArkistointiTunniste
                muokattava.TIESivuja = muokattu.TIESivuja
                muokattava.TIEInfo = muokattu.TIEInfo
                muokattava.TIELuotu = muokattu.TIELuotu
                muokattava.TIELuoja = muokattu.TIELuoja
                muokattava.TIEPaivitetty = muokattu.TIEPaivitetty
                muokattava.TIEPaivittaja = muokattu.TIEPaivittaja
                muokattava.TIEAsiakirjaTarkenneId = muokattu.TIEAsiakirjaTarkenneId
                muokattava.TIESopimusFormaattiId = muokattu.TIESopimusFormaattiId
                muokattava.TIEMFilesId = muokattu.TIEMFilesId
                muokattava.TIEMFilesObject = muokattu.TIEMFilesObject
                muokattava.TIEMFilesType = muokattu.TIEMFilesType
                muokattava.TIEMFilesVault = muokattu.TIEMFilesVault

                tietokanta.SaveChanges()
                Return Konversiot.Tiedosto.MuutaDTOksi(muokattava)

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function PoistaTiedosto(id As Integer) As DTO.Tiedosto

        Using tietokanta As New Entities.FortumEntities()

            Dim poistettava = tietokanta.Tiedosto.FirstOrDefault(Function(x) x.TIEId = id)

            If Not poistettava Is Nothing Then

                tietokanta.Tiedosto.Remove(poistettava)
                tietokanta.SaveChanges()
                Return Konversiot.Tiedosto.MuutaDTOksi(poistettava)

            Else

                Return Nothing

            End If

        End Using

    End Function

#End Region

End Class
