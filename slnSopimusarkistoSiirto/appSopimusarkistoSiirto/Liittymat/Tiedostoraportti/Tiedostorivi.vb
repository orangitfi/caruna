Namespace Liittymat.Tiedostoraportti

  Public Class Tiedostorivi

    Public Property Tiedostopolku As String
    Public Property Linkitetty As Date
    Public Property PcsNro As String
    Public Property Sopimusosapuolet As IEnumerable(Of String)
    Public Property Kiinteistotunnukset As IEnumerable(Of String)

    Public ReadOnly Property SopimusosapuoletString
      Get
        If Not Me.Sopimusosapuolet Is Nothing Then
          Return Join(Me.Sopimusosapuolet.ToArray(), ",")
        End If

        Return String.Empty
      End Get
    End Property
    Public ReadOnly Property KiinteistotunnuksetString
      Get
        If Not Me.Kiinteistotunnukset Is Nothing Then
          Return Join(Me.Kiinteistotunnukset.ToArray(), ",")
        End If

        Return String.Empty
      End Get
    End Property

  End Class

End Namespace