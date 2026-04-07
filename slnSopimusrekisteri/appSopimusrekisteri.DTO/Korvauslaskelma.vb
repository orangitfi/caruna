Public Class Korvauslaskelma

  Public Sub New()
    Me.Rivit = New List(Of KorvauslaskelmanRivi)()
  End Sub

  Public Property Id As Integer
  Public Property Nimi As String
  Public Property Asiakas As String
  Public Property SopimusId As Integer
  Public Property KorvaustyyppiId As Integer?
  Public Property Korvaustyyppi As String
  Public Property KorvausStatusId As Integer?
  Public Property KorvausStatus As String
  Public Property MaksunSuoritusId As Integer?
  Public Property MaksunSuoritus As String
  Public Property KorvauksenProjektinumero As String
  Public Property TypeOfProject As String
  Public Property Type As String
  Public Property Owner As String
  Public Property Concession As String
  Public Property CertDate As String
  Public Property FieldWorkStartedA As Date?
  Public Property ProjectClosedA As Date?
  Public Property Country As String
  Public Property Viite As String
  Public Property Viesti As String
  Public Property MaksetaanAlv As Boolean = False
  Public Property SopimushetkenIndeksi As Integer?
  Public Property IndeksikuukausiId As Integer?
  Public Property Indeksikuukausi As String
  Public Property OnIndeksi As Boolean = False
  Public Property IndeksityyppiId As Integer?
  Public Property Indeksityyppi As String
  Public Property ViimeisinMaksu As Decimal?
  Public Property ViimeisinIndeksi As Integer?
  Public Property ViimeisinMaksuIndeksi As Integer?
  Public Property ViimeisinMaksupvm As Date?
  Public Property EnsimmainenSallittuMaksupvmAsetettuKasin As Boolean?
  Public Property EnsimmainenSallittuMaksupvm As Date?
  Public Property AlkuperainenKorvaus As Decimal?
  Public Property ViimeinenMaksupvm As Date?
  Public Property IndeksiVuosi As Integer?
  Public Property MaksukuukausiId As Integer?
  Public Property Maksukuukausi As String
  Public Property MaksuehdotId As Integer?
  Public Property Maksuehdot As String
  Public Property KirjanpidonTiliId As Integer?
  Public Property KirjanpidonTili As String
  Public Property KustannuspaikkaId As Integer?
  Public Property Kustannuspaikka As String
  Public Property InvCostId As Integer?
  Public Property InvCost As String
  Public Property RegulationId As Integer?
  Public Property Regulation As String
  Public Property PurposeId As Integer?
  Public Property Purpose As String
  Public Property Local1Id As Integer?
  Public Property Local1 As String
  Public Property Luoja As String
  Public Property Luotu As Date?
  Public Property Paivittaja As String
  Public Property Paivitetty As Date?
  Public Property SaajaId As Integer?
  Public Property ViimeisinIndeksiVuosi As Integer?
  Public Property AlvId As Integer?
  Public Property AlvProsentti As Decimal?

  Public ReadOnly Property Summa As Decimal
    Get
      If Me.Rivit.Count > 0 Then
        Return Me.Rivit.Sum(Function(x) x.Korvaus.GetValueOrDefault(0))
      Else
        Return 0
      End If
    End Get
  End Property

  Public ReadOnly Property Alv As Decimal
    Get
      If Me.MaksetaanAlv AndAlso Me.AlvProsentti.HasValue Then
        Return Me.Summa * (Me.AlvProsentti / 100)
      End If

      Return 0
    End Get
  End Property

  Public ReadOnly Property SummaAlv As Decimal
    Get
      If Me.MaksetaanAlv Then
        Return Me.Summa + Me.Alv
      Else
        Return Me.Summa
      End If
    End Get
  End Property

  Public Property Rivit As List(Of KorvauslaskelmanRivi)
  Public Property Saaja As Taho
  Public Property Sopimus As Sopimus

End Class