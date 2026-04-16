Public Class RooliAvustaja

  Public Shared Function OnRooli(rooli As String) As Boolean

    Return OnRooli(HttpContext.Current.User.Identity.Name, rooli)

  End Function

  Public Shared Function OnRooli(kayttajatunnus As String, rooli As String) As Boolean

    Dim tietokanta As New BLL.Kayttajienhallinta()

    Dim lstRyhmat As List(Of String) = tietokanta.HaeKayttajanRyhmanimet(kayttajatunnus)

    Dim booRyhmallaRooli As Boolean = False

    For Each r As String In lstRyhmat

      If tietokanta.OnkoRyhmallaRooli(r, rooli) Then
        booRyhmallaRooli = True
        Exit For
      End If

    Next

    If booRyhmallaRooli Then
      Return True
    Else
      Return Roles.IsUserInRole(kayttajatunnus, rooli)
    End If

  End Function

  Public Shared Function OikeusMuokataHyvaksyttyaSopimusta(kayttajatunnus As String) As Boolean
    Return OnRooli(kayttajatunnus, "SopimusLaaja")
  End Function

  Public Shared Function OikeusMuokataMaksettuaKorvauslaskelmaa(kayttajatunnus As String) As Boolean
    Return OnRooli(kayttajatunnus, "KorvauslaskelmaLaaja")
  End Function

  Public Shared Function OnMaksujenHyvaksymisOikeus(summa As Decimal) As Boolean

    Dim dicTasot As New Dictionary(Of Decimal, String)()

    dicTasot.Add(5000, "MaksutHyvaksynta5000")
    dicTasot.Add(25000, "MaksutHyvaksynta25000")
    dicTasot.Add(50000, "MaksutHyvaksynta50000")
    dicTasot.Add(100000, "MaksutHyvaksynta100000")
    dicTasot.Add(1000000, "MaksutHyvaksynta1000000")

    Dim decSeuraavaTaso As Decimal

    For i As Integer = 0 To dicTasot.Count - 1

      If summa <= dicTasot.Keys(i) Then

        If i < dicTasot.Count - 1 Then
          decSeuraavaTaso = dicTasot.Keys(i + 1)
        Else
          decSeuraavaTaso = Integer.MaxValue
        End If

        Return OnRooli(dicTasot(dicTasot.Keys(i))) Or OnMaksujenHyvaksymisOikeus(decSeuraavaTaso)

      End If

    Next

    Return False

  End Function

End Class
