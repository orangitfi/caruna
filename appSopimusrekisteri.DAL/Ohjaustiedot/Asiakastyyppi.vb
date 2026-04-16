Imports System.Data.SqlTypes

Partial Public Class Asiakastyyppi

#Region "Hakumetodit"

    Public Function Hae(id As Integer) As Entities.hlp_Asiakastyyppi

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Asiakastyyppi.FirstOrDefault(Function(x) x.ATYId = id)

        End Using

    End Function

    Public Function Hae() As List(Of Entities.hlp_Asiakastyyppi)

        Using tietokanta As New Entities.FortumEntities()

            Return tietokanta.hlp_Asiakastyyppi.ToList()

        End Using

    End Function

#End Region

#Region "Muokkausmetodit"

    Public Function Lisaa(lisattava As Entities.hlp_Asiakastyyppi) As Entities.hlp_Asiakastyyppi

        If lisattava Is Nothing Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            lisattava.ATYLuoja = "Tuntematon"
            lisattava.ATYLuotu = SqlDateTime.MinValue
            lisattava.ATYPaivitetty = SqlDateTime.MinValue
            lisattava.ATYPaivittaja = "Tuntematon"

            tietokanta.hlp_Asiakastyyppi.Add(lisattava)
            tietokanta.SaveChanges()
            Return lisattava

        End Using

    End Function

    Public Function Muokkaa(muokattava As Entities.hlp_Asiakastyyppi) As Entities.hlp_Asiakastyyppi

        If muokattava Is Nothing Then
            Return Nothing
        Else
            If muokattava.ATYId = 0 Then
                Return Nothing
            End If
        End If

        Using tietokanta As New Entities.FortumEntities()

            Dim kantaversio = tietokanta.hlp_Asiakastyyppi.FirstOrDefault(Function(x) x.ATYId = muokattava.ATYId)

            If Not kantaversio Is Nothing Then

                tietokanta.Entry(kantaversio).CurrentValues.SetValues(muokattava)
                kantaversio.ATYLuoja = "Tuntematon"
                kantaversio.ATYLuotu = SqlDateTime.MinValue
                kantaversio.ATYPaivitetty = SqlDateTime.MinValue
                kantaversio.ATYPaivittaja = "Tuntematon"

                tietokanta.SaveChanges()
                Return kantaversio

            Else

                Return Nothing

            End If

        End Using

    End Function

    Public Function Poista(id As Integer) As Entities.hlp_Asiakastyyppi

        If id = 0 Then
            Return Nothing
        End If

        Using tietokanta As New Entities.FortumEntities()

            If Not tietokanta.Sopimus_Taho.Any(Function(x) x.SOTAsiakastyyppiId = id) Then

                Dim poistettava = tietokanta.hlp_Asiakastyyppi.FirstOrDefault(Function(x) x.ATYId = id)

                If Not poistettava Is Nothing Then

                    tietokanta.hlp_Asiakastyyppi.Remove(poistettava)
                    tietokanta.SaveChanges()
                    Return poistettava

                End If

            End If

        End Using

        Return Nothing

    End Function

#End Region

End Class
