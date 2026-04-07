Public Class Infopallurat

  Public Shared Sub AsetaInfopallurat(sivu As Page)

    Dim palluraKontrollit As IEnumerable(Of Infopallura) = Kontrollit.HaeKontrollit(Of Infopallura)(sivu)

    For Each c As Infopallura In palluraKontrollit
      c.Visible = False
    Next

    Dim tietokanta As New BLL.Infopallura()

    Dim infopallurat As List(Of DTO.Infopallura) = tietokanta.HaeLomakkeenPallurat(Right(sivu.Request.Path, sivu.Request.Path.Length - 1))

    For Each infopallura As DTO.Infopallura In infopallurat

      If Not String.IsNullOrEmpty(infopallura.Teksti) Then

        Dim pallura As Infopallura

        If palluraKontrollit.Any(Function(x) x.Kentta = infopallura.Kentta) Then

          pallura = palluraKontrollit.First(Function(x) x.Kentta = infopallura.Kentta)

          pallura.Teksti = infopallura.Teksti
          pallura.Visible = True

        End If

      End If

    Next

  End Sub

End Class
