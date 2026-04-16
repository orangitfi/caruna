Imports Sopimusrekisteri.BLL_CF

Namespace Taho

  Public Class Kiinteistot
    Inherits ListControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub ListaaData(data As IEnumerable(Of Kiinteisto))

      gvKiinteistot.DataSource = data
      gvKiinteistot.DataBind()

    End Sub

  End Class

End Namespace