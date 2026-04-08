Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        menu.Visible = True
        cphSearch.Visible = True
        cphToolbar.Visible = True

        Dim tblRow As New HtmlTableRow()

        'Etusivu
        Dim tblCellEtusivu As HtmlTableCell = CreateTableMenuItem("Etusivu", "~/default2.aspx")
        tblRow.Cells.Add(tblCellEtusivu)

        'Poiminta
        Dim tblCellPoiminta As HtmlTableCell = CreateTableMenuItem("Poiminta", "~/poimintalomake.aspx")
        tblRow.Cells.Add(tblCellPoiminta)

        'Raportit
        Dim tblCellRaportit As HtmlTableCell = CreateTableMenuItem("Raportit", "~/default2.aspx")
        tblRow.Cells.Add(tblCellRaportit)

        'Eräajot
        Dim tblCellEraajot As HtmlTableCell = CreateTableMenuItem("Eräajot", "~/default2.aspx")
        tblRow.Cells.Add(tblCellEraajot)

        tblRow.Cells.Add(CreateEmptyTableMenuItem())
        tblMenu.Rows.Add(tblRow)
    End Sub

    Public Function CreateTableMenuItem(ByVal name As String, ByVal url As String) As HtmlTableCell
        Dim tblCell As New HtmlTableCell()
        tblCell.Attributes.Add("class", "menuLinkItem")

        Dim hlLink As New HyperLink()
        hlLink.Text = name
        hlLink.NavigateUrl = url
        tblCell.Controls.Add(hlLink)

        Return tblCell
    End Function

    Public Function CreateEmptyTableMenuItem() As HtmlTableCell
        Dim tblCell As New HtmlTableCell()

        Return tblCell
    End Function
End Class