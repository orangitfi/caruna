Public Class Pudotusvalikko

  Public Shared Sub Valitse(valikko As DropDownList, valinta As Integer?)

    If Not valinta Is Nothing Then
      If Not valikko Is Nothing Then
        If Not valikko.Items.FindByValue(valinta) Is Nothing Then
          valikko.SelectedIndex = -1
          valikko.SelectedValue = valinta
        End If
      End If
    End If

  End Sub

  Public Shared Sub ValitseTekstinPerusteella(valikko As DropDownList, valinta As String)

    If Not valinta Is Nothing Then
      If Not valikko Is Nothing Then
        If Not valikko.Items.FindByText(valinta) Is Nothing Then
          valikko.SelectedIndex = -1
          valikko.SelectedValue = valikko.Items.FindByText(valinta).Value
        End If
      End If
    End If

  End Sub

  Public Shared Function HaeValittuTeksti(valikko As DropDownList) As String

    If Not valikko Is Nothing Then
      If Not valikko.SelectedItem Is Nothing Then
        Return valikko.SelectedItem.Text

      End If
    End If

    Return String.Empty

  End Function

  ' Kaikki pudotusvalikkojen takana olevat tietokentät ovat int (NULL) tai 
  ' tai int (NOT NULL) -tyyppisiä. Tällä metodilla voidaan hakea pudotusvalikosta
  ' pudotusvalikon valinta molempiin, mutta ennen kaikkea int (NULL) -kenttiin.
  ' Koodissa validaattorien pitäisi hoitaa int (NOT NULL) -kenttien valinnat sillä 
  ' tämä metodi palauttaa NULL:in, jos valikosta ei ole valittu mitään.
  Public Shared Function HaeValittuArvo(valikko As DropDownList) As Integer?

    If Not valikko Is Nothing Then
      If Not valikko.SelectedItem Is Nothing Then
        If Not valikko.SelectedItem.Value = -1 Then
          Return valikko.SelectedItem.Value
        End If
      End If
    End If

    Return Nothing

  End Function

  Public Shared Function LuoTyhjaValinta() As ListItem

    Dim tyhjaValinta = New ListItem()
    tyhjaValinta.Text = "-- Ei valintaa --"
    tyhjaValinta.Value = -1
    Return tyhjaValinta

  End Function

  Public Shared Function LuoTyhjaHakutulos(Optional teksti As String = "") As appSopimusrekisteri.DTO.Hakutulos

    Dim tyhjaHakutulos = New appSopimusrekisteri.DTO.Hakutulos()
    tyhjaHakutulos.ID = -1
    tyhjaHakutulos.Tyyppi = "Ei valintaa"

    If teksti = String.Empty Then
      tyhjaHakutulos.Nimi = "-- Ei valintaa -- "
    Else
      tyhjaHakutulos.Nimi = teksti
    End If

    Return tyhjaHakutulos

  End Function

  Public Shared Function LuoHakutulos(id As Integer, teksti As String) As appSopimusrekisteri.DTO.Hakutulos

    Dim hakuTulos = New appSopimusrekisteri.DTO.Hakutulos()
    hakuTulos.ID = id
    hakuTulos.Nimi = teksti

    Return hakuTulos

  End Function

  Public Shared Function LuoValinta(avain As String, teksti As String) As ListItem

    Dim valinta = New ListItem()
    valinta.Text = teksti
    valinta.Value = avain
    Return valinta

  End Function

  Public Shared Sub Jarjesta(valikko As DropDownList)

    Dim lstObjektit As New List(Of ListItem)

    For Each i As ListItem In valikko.Items

      lstObjektit.Add(i)

    Next


    lstObjektit = lstObjektit.OrderBy(Function(x) x.Text).ToList()


    valikko.Items.Clear()


    valikko.Items.AddRange(lstObjektit.ToArray())

  End Sub

End Class
