Public Class Sopimukset
  Inherits BaseControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then
      TaytaData()
    End If

  End Sub

  Public Sub TaytaData()

    If Me.TahoId.HasValue Then

      Dim tietokanta = New appSopimusrekisteri.BLL.Sopimus(_konteksti)
      Dim sopimukset = tietokanta.HaeTahonSopimukset(Me.TahoId)
      'btLisaaSopimusKiinteistölle.PostBackUrl = String.Format("~/Sopimus/JAS/Muokkaa.aspx?organisaatioid={0}", organisaatioId)

      gvSopimukset.DataSource = sopimukset
      gvSopimukset.DataBind()
      gvSopimukset.Visible = True

    Else

      gvSopimukset.Visible = False

    End If

  End Sub

  Public Property TahoId As Integer?
    Set(value As Integer?)
      hdnTahoId.Value = value
    End Set
    Get
      If IsNumeric(hdnTahoId.Value) Then
        Return CInt(hdnTahoId.Value)
      Else
        Return Nothing
      End If
    End Get
  End Property

End Class