Public Class PoimintaOperaattori
  Inherits UserControl

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not IsPostBack Then

      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.YhtaSuuri.ToString(), "="))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.EriSuuri.ToString(), "<>"))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.PienempiTaiYhtaSuuri.ToString(), "<="))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri.ToString(), ">="))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.Tyhja.ToString(), "Tyhjä"))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.EiTyhja.ToString(), "Ei tyhjä"))
      ddlOperaattori.Items.Add(Pudotusvalikko.LuoValinta(DTO.Hakuoperaattori.Valilla.ToString(), "Välillä"))

    End If

  End Sub

  Public Property AssociatedControlId As String
    Set(value As String)
      hdnAssociatedControId.Value = value
    End Set
    Get
      Return hdnAssociatedControId.Value
    End Get
  End Property

  Public ReadOnly Property SelectedValue As String
    Get
      Return ddlOperaattori.SelectedValue
    End Get
  End Property

End Class