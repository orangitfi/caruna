Public Class LomakeVirhe
  Inherits BaseControl

  Private _lstVirheet As List(Of String)

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    pnlVirhe.Visible = False

  End Sub

  Public Sub NaytaVirhe(virheilmoitus As String)

    Me.LisaaVirhe(virheilmoitus)

  End Sub

  Public Sub LisaaVirhe(virheilmoitus As String)

    If _lstVirheet Is Nothing Then
      _lstVirheet = New List(Of String)()
    End If

    _lstVirheet.Add(virheilmoitus)

    lvVirheet.DataSource = _lstVirheet
    lvVirheet.DataBind()

    pnlVirhe.Visible = True

  End Sub

  Public ReadOnly Property Virheet As String()
    Get
      If Not _lstVirheet Is Nothing Then
        Return _lstVirheet.ToArray()
      End If

      Return New String() {}
    End Get
  End Property

End Class