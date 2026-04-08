Imports System.IO

Namespace Liittymat.Tiedostoraportti

  Public Class Raportti

    Private _tiedostoPolku As String

    Private Const Erotin As String = ";"
    Private Const KenttaRajoitin As String = """"

    Public Sub New(tiedostopolku As String)
      Me._tiedostoPolku = tiedostopolku
    End Sub

    Private Sub LuoRaportti()

      Using writer As New StreamWriter(Me.Polku, False, Me.Encoding)

        writer.WriteLine(Me.MuodostaOtsikkoRivi())

        writer.Flush()
        writer.Close()

      End Using

    End Sub

    Public Sub KirjoitaRivitRaporttiin(rivit As IEnumerable(Of Tiedostorivi))

      For Each rivi As Tiedostorivi In rivit

        Me.KirjoitaRiviRaporttiin(rivi)

      Next

    End Sub

    Public Sub KirjoitaRiviRaporttiin(rivi As Tiedostorivi)

      If Not File.Exists(Me.Polku) Then
        Me.LuoRaportti()
      End If

      Using writer As New StreamWriter(Me.Polku, True, Me.Encoding)

        writer.WriteLine(Me.MuodostaTiedostoRivi(rivi))

        writer.Flush()
        writer.Close()

      End Using

    End Sub

    Private Function MuodostaOtsikkoRivi() As String

      Return Me.MuodostaRivi(False, "Tiedostopolku", "Linkitys tehty", "PCS-numero", "Sopimusosapuolet", "Kiinteistötunnus, lyhyt")

    End Function

    Private Function MuodostaTiedostoRivi(rivi As Tiedostorivi) As String

      Return Me.MuodostaRivi(True, rivi.Tiedostopolku, Me.MuotoilePaivamaara(rivi.Linkitetty), rivi.PcsNro, rivi.SopimusosapuoletString, rivi.KiinteistotunnuksetString)

    End Function

    Private Function MuodostaRivi(kaytaKenttaRajoitinta As Boolean, ParamArray parametrit As String())

      If kaytaKenttaRajoitinta Then
        Return Join(parametrit.Select(Function(x) KenttaRajoitin & x & KenttaRajoitin).ToArray(), Erotin)
      Else
        Return Join(parametrit, Erotin)
      End If

    End Function

    Private Function MuotoilePaivamaara(arvo As Date) As String
      Return arvo.ToString("yyyyMMdd")
    End Function

    Public ReadOnly Property Polku As String
      Get
        Return Me._tiedostoPolku
      End Get
    End Property

    Public ReadOnly Property Encoding As System.Text.Encoding
      Get
        Return System.Text.Encoding.UTF8
      End Get
    End Property

  End Class

End Namespace
