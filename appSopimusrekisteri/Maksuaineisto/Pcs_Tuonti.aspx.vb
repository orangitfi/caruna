Imports Sopimusrekisteri.BLL_CF
Imports System.IO
Imports KT.Utils

Public Class Pcs_Tuonti
  Inherits BasePage2

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    lblInfo.Visible = False

  End Sub

  Protected Sub btnLataa_Click(sender As Object, e As EventArgs) Handles btnLataa.Click

    If Me.FileUpload1.HasFile Then

      Try

        Dim tiedostonimi As String = "Pcs_Raportti_" & Date.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

        Dim tiedostopolku As String = IOUtils.CombinePaths(Hakemistot.PcsRaporttiHakemisto, tiedostonimi)

        FileUpload1.SaveAs(tiedostopolku)

        Dim raportit As IEnumerable(Of PcsSummaryRaportti) = Me.LueRivit(tiedostopolku)

        Dim paivitetyt As Integer

        paivitetyt = Me.Handlers.PcsSummaryRaportit.SaveReport(raportit)

        lblInfo.Text = paivitetyt & " korvauslaskelmaa päivitetty"
        lblInfo.Visible = True

      Catch ex As Exception

        LomakeVirhe.NaytaVirhe("Tiedoston tuonnissa tapahtui virhe: " & ex.Message)

      End Try

    End If

  End Sub

  Private Function LueRivit(tiedosto As String) As IEnumerable(Of PcsSummaryRaportti)

    Dim raportit As New List(Of PcsSummaryRaportti)()
    Dim raportti As PcsSummaryRaportti
    Dim rivi As String()

    Using reader As New StreamReader(tiedosto, Encoding.GetEncoding("ISO-8859-1"))

      reader.ReadLine()

      While reader.Peek() >= 0

        rivi = reader.ReadLine().Split(";")

        raportti = New PcsSummaryRaportti()

        raportti.ProjectNo = rivi(0)
        raportti.Name = rivi(1)
        raportti.TypeOfProject = rivi(2)
        raportti.Type = rivi(3)
        raportti.Category = rivi(4)
        raportti.Owner = rivi(5)
        raportti.Concession = rivi(6)
        raportti.CertDate = (rivi(7))
        raportti.FieldWorkStartedA = DataUtils.ParseValue(Of DateTime?)(rivi(8))
        raportti.ProjectClosedA = DataUtils.ParseValue(Of DateTime?)(rivi(9))

        raportit.Add(raportti)

      End While

    End Using

    Return raportit

  End Function

  Protected Sub cvTiedosto_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvTiedosto.ServerValidate

    If Not FileUpload1.HasFile Then
      args.IsValid = False
      cvTiedosto.ErrorMessage = "Valitse tiedosto"
    ElseIf Not FileUpload1.FileName.EndsWith(".csv")
      args.IsValid = False
      cvTiedosto.ErrorMessage = "Valitse tiedosto CSV-tiedosto"
    Else
      args.IsValid = True
    End If

  End Sub

End Class