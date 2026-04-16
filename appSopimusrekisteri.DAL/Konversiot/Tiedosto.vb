Namespace Konversiot

    Public Class Tiedosto

        Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Tiedosto)) As List(Of DTO.Tiedosto)

            Dim tulokset = New List(Of DTO.Tiedosto)
            For Each muunnettava In muunnettavat
                tulokset.Add(MuutaDTOksi(muunnettava))
            Next
            Return tulokset

        End Function

        Public Shared Function MuutaDTOksi(muunnettava As Entities.Tiedosto) As DTO.Tiedosto

            Dim tulos As New DTO.Tiedosto()

            tulos.Id = muunnettava.TIEId
            tulos.Nimi = muunnettava.TIETiedostoNimi
            tulos.Url = muunnettava.TIEURL
            tulos.Selite = muunnettava.TIESelite
            tulos.LahdeId = muunnettava.TIETiedostoLahdeId
            If Not muunnettava.hlps_Tiedostolahde Is Nothing Then
                tulos.Lahde = muunnettava.hlps_Tiedostolahde.TLATiedostoLahde
            End If
            tulos.SopimusId = muunnettava.TIESopimusId
            tulos.SharepointId = muunnettava.TIESharePointId
            tulos.ArkistonSijaintiId = muunnettava.TIEArkistonSijaintiId
            If Not muunnettava.hlp_ArkistonSijainti Is Nothing Then
                tulos.ArkistonSijainti = muunnettava.hlp_ArkistonSijainti.ASIArkistonSijainti
            End If
            tulos.DocumentId = muunnettava.TIEDocumentID
            tulos.ArkistointiTunniste = muunnettava.TIEArkistointiTunniste
            tulos.Sivuja = muunnettava.TIESivuja
            tulos.Info = muunnettava.TIEInfo
            tulos.Luotu = muunnettava.TIELuotu
            tulos.Luoja = muunnettava.TIELuoja
            tulos.Paivitetty = muunnettava.TIEPaivitetty
            tulos.Paivittaja = muunnettava.TIEPaivittaja
            tulos.AsiakirjaTarkenneId = muunnettava.TIEAsiakirjaTarkenneId
            tulos.MFilesObject = muunnettava.TIEMFilesObject
            tulos.MFilesId = muunnettava.TIEMFilesId
            tulos.MFilesType = muunnettava.TIEMFilesType
            tulos.MFilesVault = muunnettava.TIEMFilesVault
            If Not muunnettava.hlp_AsiakirjaTarkenne Is Nothing Then
                tulos.AsiakirjaTarkenne = muunnettava.hlp_AsiakirjaTarkenne.ATAAsiakirjaTarkenne
            End If
            tulos.SopimusFormaattiId = muunnettava.TIESopimusFormaattiId
            If Not muunnettava.hlp_SopimusFormaatti Is Nothing Then
                tulos.SopimusFormaatti = muunnettava.hlp_SopimusFormaatti.SFOSopimusFormaatti
            End If
            tulos.AsiakirjaTarkenne = muunnettava.TIEAsiakirjatarkenne

            Return tulos

        End Function

        Public Shared Function MuutaDBOksi(muunnettavat As IEnumerable(Of DTO.Tiedosto)) As List(Of Entities.Tiedosto)

            Dim tulokset = New List(Of Entities.Tiedosto)
            For Each muunnettava In muunnettavat
                tulokset.Add(MuutaDBOksi(muunnettava))
            Next
            Return tulokset

        End Function

        Public Shared Function MuutaDBOksi(muunnettava As DTO.Tiedosto) As Entities.Tiedosto

            Dim tulos As New Entities.Tiedosto()

            If muunnettava.Id.HasValue Then
                tulos.TIEId = muunnettava.Id
            End If
            tulos.TIETiedostoNimi = muunnettava.Nimi
            tulos.TIEURL = muunnettava.Url
            tulos.TIESelite = muunnettava.Selite
            tulos.TIETiedostoLahdeId = muunnettava.LahdeId
            tulos.TIESopimusId = muunnettava.SopimusId
            tulos.TIESharePointId = muunnettava.SharepointId
            tulos.TIEArkistonSijaintiId = muunnettava.ArkistonSijaintiId
            tulos.TIEDocumentID = muunnettava.DocumentId
            tulos.TIEArkistointiTunniste = muunnettava.ArkistointiTunniste
            tulos.TIESivuja = muunnettava.Sivuja
            tulos.TIEInfo = muunnettava.Info
            If muunnettava.Luotu.HasValue Then
                tulos.TIELuotu = muunnettava.Luotu
            End If
            tulos.TIELuoja = muunnettava.Luoja
            If muunnettava.Paivitetty.HasValue Then
                tulos.TIEPaivitetty = muunnettava.Paivitetty
            End If
            tulos.TIEPaivittaja = muunnettava.Paivittaja
            tulos.TIEAsiakirjaTarkenneId = muunnettava.AsiakirjaTarkenneId
            tulos.TIEAsiakirjatarkenne = muunnettava.AsiakirjaTarkenne
            tulos.TIESopimusFormaattiId = muunnettava.SopimusFormaattiId
            tulos.TIEMFilesObject = muunnettava.MFilesObject
            tulos.TIEMFilesId = muunnettava.MFilesId
            tulos.TIEMFilesType = muunnettava.MFilesType
            tulos.TIEMFilesVault = muunnettava.MFilesVault

            Return tulos

        End Function

    End Class

End Namespace
