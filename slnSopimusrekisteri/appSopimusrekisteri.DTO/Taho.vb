Public Class Taho

  Public Property SopimusId As Integer?
  Public Property TahoTyyppiId As Integer?
  Public Property Id As Integer
  Public ReadOnly Property Nimi As String
    Get
      Return (Etunimi + " " + Sukunimi).Trim()
    End Get
  End Property
  Public Property Etunimi As String
  Public Property Sukunimi As String
  Public Property SopimustenTunnisteet As String
  Public Property SopimustenMuutTunnisteet As String
  Public ReadOnly Property Tyyppi As String
    Get
      If TahoTyyppiId = DTO.Enumeraattorit.TahoTyyppi.Henkilo Then
        Return "Henkilö"
      ElseIf TahoTyyppiId = DTO.Enumeraattorit.TahoTyyppi.Organisaatio Then
        Return "Organisaatio"
      End If
      Return "Tuntematon"
    End Get
  End Property
  Public Property Ytunnus As String
  Public Property Osoite As String
  Public Property Postinumero As String
  Public Property Postitoimipaikka As String
  Public Property Puhelin As String
  Public Property Email As String
  Public Property Rooli As String

  Public Property Tilinumero As String
  Public Property BicKoodi As String
  Public Property BicKoodiMuu As String
  Public Property KirjanpidonYritystunniste As String
  Public Property KirjanpidonProjektitunniste As String
  Public Property PCSConcession As String
  Public Property OrganisaationTyyppiId As Integer?
  Public Property Luoja As String
  Public Property Luotu As Date?
  Public Property Paivittaja As String
  Public Property Paivitetty As Date?

  Public ReadOnly Property Bic As String
    Get
      If Not String.IsNullOrEmpty(Me.BicKoodi) Then
        Return Me.BicKoodi
      Else
        Return Me.BicKoodiMuu
      End If
    End Get
  End Property

  Sub New()
    SopimustenMuutTunnisteet = String.Empty
    SopimustenTunnisteet = String.Empty
  End Sub

End Class
