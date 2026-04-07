Imports System.IO
Imports KT.Utils

Public Class LevyTiedosto

  Public Sub New(polku As String)
    Me.Polku = polku
  End Sub

  Public Property Polku As String

  Public Property UusiKansioPolkuRelatiivinen As String

  Public ReadOnly Property UusiKokoPolkuRelatiivinen As String
    Get
      Return IOUtils.CombinePaths(Me.UusiKansioPolkuRelatiivinen, Me.Nimi)
    End Get
  End Property

  Public ReadOnly Property Nimi As String
    Get
      Return Path.GetFileName(Me.Polku)
    End Get
  End Property

  Public ReadOnly Property SopimusId As Integer?
    Get

      Dim id As String = Left(Me.Nimi, Me.Nimi.IndexOf("_"))

      If IsNumeric(id) Then
        Return CInt(id)
      End If

      Return Nothing
    End Get
  End Property

  Public ReadOnly Property Asiakirjatarkenne As String
    Get

      Dim tarkenne As String = Right(Me.Nimi, Me.Nimi.Length - Me.Nimi.IndexOf("_") - 1)

      tarkenne = Left(tarkenne, tarkenne.IndexOf("_"))

      Return tarkenne

    End Get
  End Property

End Class
