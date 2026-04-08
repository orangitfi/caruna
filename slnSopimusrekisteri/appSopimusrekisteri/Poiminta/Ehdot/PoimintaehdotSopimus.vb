Imports Sopimusrekisteri.BLL_CF.Poiminnat
Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF

Public Class PoimintaehdotSopimus
  Inherits Poimintaehdot(Of Sopimusrekisteri.BLL_CF.Sopimus)

#Region "Avaimet"

#End Region

  Public DataContext As KiltaDataContext

  Protected Overrides Sub AsetaEhdonTiedot(ehto As Poimintaehto(Of Sopimusrekisteri.BLL_CF.Sopimus))

    Dim avain As String = ehto.Avain
    Dim arvo As String = ehto.Arvo

  End Sub

  Public Overrides Function AnnaValintatekstit() As IEnumerable(Of PoiminnanValintateksti)

    Dim tekstit As List(Of PoiminnanValintateksti) = MyBase.AnnaValintatekstit().ToList()

    For Each Ehdot As IPoimintaehdot In Me.Alipoiminnat.Values

      tekstit.AddRange(Ehdot.AnnaValintatekstit)

    Next

    Return tekstit

  End Function

End Class
