Imports System.Data.SqlTypes

Partial Public Class Siirtooikeus

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_SiirtoOikeus

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SiirtoOikeus.FirstOrDefault(Function(x) x.SOIId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_SiirtoOikeus)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_SiirtoOikeus.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_SiirtoOikeus) As Entities.hlp_SiirtoOikeus

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.SOILuoja = "Tuntematon"
            lisattava.SOILuotu = SqlDateTime.MinValue
            lisattava.SOIPaivitetty = SqlDateTime.MinValue
            lisattava.SOIPaivittaja = "Tuntematon"

            tietokanta.hlp_SiirtoOikeus.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_SiirtoOikeus) As Entities.hlp_SiirtoOikeus

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.SOIId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_SiirtoOikeus.FirstOrDefault(Function(x) x.SOIId = muokattava.SOIId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.SOILuoja = "Tuntematon"
                kantaversio.SOILuotu = SqlDateTime.MinValue
                kantaversio.SOIPaivitetty = SqlDateTime.MinValue
                kantaversio.SOIPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_SiirtoOikeus

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus.Any(Function(x) x.SOPVastaosapuoliSiirtoOikeusId = id) Then
                If Not tietokanta.Sopimus.Any(Function(x) x.SOPVerkohaltijaSiirtoOikeusId = id) Then

                    Dim poistettava = tietokanta.hlp_SiirtoOikeus.FirstOrDefault(Function(x) x.SOIId = id)

                    If Not poistettava Is Nothing Then

                        tietokanta.hlp_SiirtoOikeus.Remove(poistettava)
                        tietokanta.SaveChanges()
                        Return poistettava

                    End If

                End If
            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
