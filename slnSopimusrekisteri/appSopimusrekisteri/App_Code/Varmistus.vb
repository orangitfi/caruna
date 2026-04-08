Imports appSopimusrekisteri.DTO

Public Module Varmistus

    Public Function OnTaho(data As List(Of iHakutulos)) As Boolean

        If Not data Is Nothing Then
            If Not data(0) Is Nothing Then
                If data(0).Tyyppi = "Henkilö" Or data(0).Tyyppi = "Organisaatio" Then
                    Return True
                End If
            End If
        End If

        Return False

    End Function

    Public Function OnKiinteisto(data As List(Of iHakutulos)) As Boolean

        If Not data Is Nothing Then
            If Not data(0) Is Nothing Then
                If data(0).Tyyppi = "Kiinteistö" Then
                    Return True
                End If
            End If
        End If

        Return False

    End Function

    Public Function OnSopimus(data As List(Of iHakutulos)) As Boolean

        If Not data Is Nothing Then
            If Not data(0) Is Nothing Then
                If data(0).Tyyppi.StartsWith("Sopimus") Then
                    Return True
                End If
            End If
        End If

        Return False

    End Function

End Module
