Public Class Sopimus

    Private _strSopimusVuosi As String
    Private _dAlkupvm As Date?

    Public Sub New()
        Me.Kiinteistot = New List(Of Kiinteisto)()
        Me.Tahot = New List(Of SopimusTaho)()
        Me.Tunnisteyksikot = New List(Of Tunnisteyksikko)()
        Me.Tiedostot = New List(Of Tiedosto)()
        Me.Korvauslaskelmat = New List(Of Korvauslaskelma)()
    End Sub

    Public Property Id As Integer
    Public Property Sopimustyyppi As String
    Public Property Tyyppi As String
    Public Property Alkaa As String
    Public Property Paattyy As String

    Public Property MuuTunniste As String
    Public Property Vuosi As String
    'Vain ensimmäisen kiinteistön tiedot näytetään tällä hetkellä. Entä sopimukset joissa on monta kiinteistöä?
    Public ReadOnly Property KiinteistonKunta As String
        Get
            If Kiinteistot.Count > 0 Then Return Kiinteistot.First.Kunta Else Return ""
        End Get
    End Property
    Public ReadOnly Property KiinteistonKyla As String
        Get
            If Kiinteistot.Count > 0 Then Return Kiinteistot.First.Kyla Else Return ""
        End Get
    End Property
    Public ReadOnly Property KiinteistonRekisterinumero As String
        Get
            If Kiinteistot.Count > 0 Then Return Kiinteistot.First.Rekisterinumero Else Return ""
        End Get
    End Property
    Public ReadOnly Property KiinteistonTunnusLyhyt As String
        Get
            If Kiinteistot.Count > 0 Then Return Kiinteistot.First.LyhytKiinteistotunnus Else Return ""
        End Get
    End Property
    Public Property Asiakkaat As String
    Public Property PGTunnus As String
    Public Property Lisatieto As String
    Public Property PCSNumero As String

    Public Property Alkupvm As Date?
        Set(value As Date?)
            _dAlkupvm = value
        End Set
        Get
            If _dAlkupvm.HasValue Then
                Return _dAlkupvm
            End If

            Return Me.VerkonhaltijanAllekirjoitusPvm
        End Get
    End Property


    Public Property Irtisanomispvm As Date?
    Public Property Paattymispvm As Date?

    Public Property Korvaukseton As Boolean

    Public Property TiedostoHaettu As Boolean = False
    Public Property MetatiedotPaivitetty As Boolean = False

    Public Property Luoja As String
    Public Property Luotu As Date?
    Public Property Paivittaja As String
    Public Property Paivitetty As Date?

    Public Property AlkuperainenKorvaus As Decimal?
    Public Property AsiakkaanAllekirjoitusPvm As Date?
    Public Property DFRooliId As Integer?
    Public Property DFRooli As String
    Public Property Info As String
    Public Property JulkisuusasteId As Integer?
    Public Property Julkisuusaste As String
    Public Property JuridinenYhtioId As Integer?
    Public Property Karttaliite As String
    Public Property KestoId As Integer?
    Public Property Korvaa As String
    Public Property Kuvaus As String
    Public Property Luonnonsuojelualue As Boolean = False
    Public Property MaantieteellinenVali As String
    Public Property Muuntamoalue As Decimal?
    Public Property PaasopimusId As Integer?
    Public Property Paasopimus As Sopimus
    Public Property ProjektiAloitusPvm As Date?
    Public Property Pylvasmaara As Integer?
    Public Property Pylvasvali As String
    Public Property SopimuksenAlaluokkaId As Integer?
    Public Property SopimuksenAlaluokka As String
    Public Property SopimuksenEhtoversioId As Integer?
    Public Property SopimuksenEhtoversio As String
    Public Property SopimuksenIrtisanomisaika As Integer?
    Public Property SopimuksenIrtisanomistoimet As String
    Public Property SopimuksenLaatija As String
    Public Property SopimuksenTilaId As Integer?
    Public Property SopimuksenTila As String
    Public Property SopimusluokkaId As Integer?
    Public Property Sopimusluokka As String
    Public Property SopimustyyppiId As Integer?
    Public Property VastaosapuoliSiirtoOikeusId As Integer?
    Public Property VastaosapuoliSiirtoOikeus As String
    Public Property VastuuyksikkoId As Integer?
    Public Property Vastuuyksikko As String
    Public Property VerkonhaltijaSiirtoOikeusId As Integer?
    Public Property VerkonhaltijaSiirtoOikeus As String
    Public Property VerkonhaltijanAllekirjoitusPvm As Date?
    Public Property AlkuperainenYhtioId As Integer?
    Public Property AlkuperainenYhtio As String
    Public Property Projektinvalvoja As String
    Public Property Jatkoaika As Integer?
    Public Property PuustonOmistajuusId As Integer?
    Public Property PuustonOmistajuus As String
    Public Property PuustonPoistoId As Integer?
    Public Property PuustonPoisto As String
    Public Property KohdekategoriaId As Integer?
    Public Property Kohdekategoria As String
    Public Property LaskennallinenPaattymispvm As Date?

    Public Property Luonnos As Boolean = False
    Public Property KieliId As Integer?
    Public Property Kieli As String
    Public Property Erityisehdot As String

    Public Property YlasopimuksenTyyppiId As Integer?
    Public Property YlasopimuksenTyyppi As String

    Public Property LupatahoId As Integer?
    Public Property Lupataho As String

    Public Property Kiinteistot As List(Of Kiinteisto)
    Public Property Tahot As List(Of SopimusTaho)
    Public Property Tunnisteyksikot As List(Of Tunnisteyksikko)
    Public Property Korvauslaskelmat As List(Of Korvauslaskelma)
    Public Property Tiedostot As List(Of Tiedosto)

    Public Property JuridinenYhtio As Taho
    Public Property Mappitunniste As String
    Public Property CaceTehtava As String

    Public ReadOnly Property JuridinenYhtioNimi As String
        Get
            If Not Me.JuridinenYhtio Is Nothing Then
                Return Me.JuridinenYhtio.Nimi
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property Hyvaksytty As Boolean
        Get
            If Me.AsiakkaanAllekirjoitusPvm.HasValue Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    'Public ReadOnly Property LaskennallinenPaattymispvm As Date?
    '  Get
    '    If Me.Paattymispvm.HasValue Then

    '      Dim intIrtisanomisaika As Integer = Me.SopimuksenIrtisanomisaika.GetValueOrDefault(0)
    '      Dim pvmIrtisanomisajalla As Date = DateAdd(DateInterval.Month, -1 * intIrtisanomisaika, Me.Paattymispvm.Value)

    '      If pvmIrtisanomisajalla < Date.Now And pvmIrtisanomisajalla < Me.Irtisanomispvm.GetValueOrDefault(Date.MaxValue) Then

    '        If Me.Jatkoaika.HasValue AndAlso Me.Jatkoaika.Value > 0 Then

    '          Dim pvm As Date = DateAdd(DateInterval.Month, Me.Jatkoaika.Value, Me.Paattymispvm.Value)
    '          pvmIrtisanomisajalla = DateAdd(DateInterval.Month, -1 * intIrtisanomisaika, pvm)

    '          While pvmIrtisanomisajalla < Date.Now And pvmIrtisanomisajalla < Me.Irtisanomispvm.GetValueOrDefault(Date.MaxValue)
    '            pvm = DateAdd(DateInterval.Month, Me.Jatkoaika.Value, pvm)
    '            pvmIrtisanomisajalla = DateAdd(DateInterval.Month, -1 * intIrtisanomisaika, pvm)
    '          End While

    '          Return pvm
    '        End If

    '      End If

    '      Return Me.Paattymispvm

    '    End If

    '    Return Nothing
    '  End Get
    'End Property

    Public Property Sopimusvuosi As String
        Set(value As String)
            _strSopimusVuosi = value
        End Set
        Get
            If Me.Alkupvm.HasValue Then
                Return Year(Me.Alkupvm).ToString()
            Else
                Return _strSopimusVuosi
            End If
        End Get
    End Property

    Public ReadOnly Property Kiinteistotunnukset As String()
        Get
            If Not Me.Kiinteistot Is Nothing Then
                Return Me.Kiinteistot.Where(Function(x) Not String.IsNullOrEmpty(x.LyhytKiinteistotunnus)).Select(Function(x) x.LyhytKiinteistotunnus).Distinct().ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Kunnat As String()
        Get
            If Not Me.Kiinteistot Is Nothing Then
                Return Me.Kiinteistot.Where(Function(x) Not String.IsNullOrEmpty(x.Kunta)).Select(Function(x) x.Kunta).Distinct().ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Kylat As String()
        Get
            If Not Me.Kiinteistot Is Nothing Then
                Return Me.Kiinteistot.Where(Function(x) Not String.IsNullOrEmpty(x.Kyla)).Select(Function(x) x.Kyla).Distinct().ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Rekisterinumerot As String()
        Get
            If Not Me.Kiinteistot Is Nothing Then
                Return Me.Kiinteistot.Where(Function(x) Not String.IsNullOrEmpty(x.Rekisterinumero)).Select(Function(x) x.Rekisterinumero).Distinct().ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Tilat As String()
        Get
            If Not Me.Kiinteistot Is Nothing Then
                Return Me.Kiinteistot.Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Select(Function(x) x.Nimi).Distinct().ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Sopimusosapuolet As String()
        Get
            If Not Me.Tahot Is Nothing Then
                Return Me.Tahot.Select(Function(x) x.Taho).Where(Function(x) Not String.IsNullOrEmpty(x.Nimi)).Select(Function(x) x.Nimi).Distinct.ToArray()
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Kohteet As String()
        Get
            Dim lstKohteet As New List(Of String)()
            If Not Me.Tunnisteyksikot Is Nothing Then

                lstKohteet.AddRange(Me.Tunnisteyksikot.Where(Function(x) Not String.IsNullOrEmpty(x.PGTunnus)).Select(Function(x) x.PGTunnus).Distinct)
                lstKohteet.AddRange(Me.Tunnisteyksikot.Where(Function(x) String.IsNullOrEmpty(x.PGTunnus) And Not String.IsNullOrEmpty(x.Nimi)).Select(Function(x) x.Nimi).Distinct)

                If lstKohteet.Count > 0 Then
                    Return lstKohteet.ToArray()
                End If

            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Nimi
        Get
            Return Me.Id.ToString() & " " & String.Format("({0})", LTrim(Me.MuuTunniste & " " & Me.Vuosi))
        End Get
    End Property

End Class
