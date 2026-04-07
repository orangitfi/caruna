Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.Repositories

Public Class SopimusAvustaja

    Public Shared Function PoistaLopullisesti(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As Palaute

        If sopimus.SopimuksenTilaId <> SopimusTilat.Poistettu Then
            Return New Palaute With {.Ok = False, .Viesti = "Sopimuksen tila tulee olla poistettu, jotta se voidaan poistaa lopullisesti."}
        End If

        Try
            Dim repo = New SopimusRepository(Konfiguraatiot.ConnectionString)
            repo.PoistaLopullisesti(sopimus.Id)

            Return New Palaute With {.Ok = True, .Viesti = "Sopimus poistettu onnistuneesti."}
        Catch ex As Exception
            Return New Palaute With {.Ok = False, .Viesti = "Tapahtui virhe: " & ex.Message}
        End Try

    End Function

End Class
