Imports System.Linq.Expressions
Imports LinqKit

Public Module Hakuehdot

  Public Function Sopimusluokka(ParamArray hakuehdot As Integer()) As Expression(Of Func(Of Entities.Sopimus, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Sopimus, Boolean)) = PredicateBuilder.False(Of Entities.Sopimus)()

    For Each hakuehto In hakuehdot
      Dim lause As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPSopimusluokkaId = hakuehto
      hakulause = hakulause.Or(lause)
    Next

    Return hakulause

  End Function

  Public Function Tahotyyppi(ParamArray hakuehdot As Integer()) As Expression(Of Func(Of Entities.Taho, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Taho, Boolean)) = PredicateBuilder.False(Of Entities.Taho)()

    For Each hakuehto In hakuehdot
      Dim lause As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHTyyppiId = hakuehto
      hakulause = hakulause.Or(lause)
    Next

    Return hakulause

  End Function

  Public Function TahojenTarkkaHaku(hakuehdot As DTO.TahojenHaku) As Expression(Of Func(Of Entities.Taho, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Taho, Boolean)) = PredicateBuilder.True(Of Entities.Taho)()

    If Not String.IsNullOrWhiteSpace(hakuehdot.Etunimi) Then
      Dim ehto1 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHEtunimi.Contains(hakuehdot.Etunimi)
      hakulause = hakulause.And(ehto1)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Email) Then
      Dim ehto2 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHEmail.Contains(hakuehdot.Email)
      hakulause = hakulause.And(ehto2)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Sukunimi) Then
      Dim ehto3 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHSukunimi.Contains(hakuehdot.Sukunimi)
      hakulause = hakulause.And(ehto3)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Asiakasnumero) Then
      Dim ehto4 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHTahoId = hakuehdot.Asiakasnumero
      hakulause = hakulause.And(ehto4)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonOsoite) Then
      Dim ehto5 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.Kiinteisto.Any(Function(y) y.KIIKatuosoite.Contains(hakuehdot.KiinteistonOsoite) Or y.KIIPostinumero.Contains(hakuehdot.KiinteistonOsoite) Or y.KIIPostitoimipaikka.Contains(hakuehdot.KiinteistonOsoite))
      hakulause = hakulause.And(ehto5)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonKyla) Then
      Dim ehto6 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.Kiinteisto.Any(Function(y) y.hlp_Kyla IsNot Nothing And y.hlp_Kyla.KYLKyla.Contains(hakuehdot.KiinteistonKyla))
      hakulause = hakulause.And(ehto6)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonKunta) Then
      Dim ehto7 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.Kiinteisto.Any(Function(y) y.hlp_Kunta IsNot Nothing And y.hlp_Kunta.KKunta.Contains(hakuehdot.KiinteistonKunta))
      hakulause = hakulause.And(ehto7)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.SopimuksenTunniste) Then
      Dim ehto8 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.Sopimus_Taho.Any(Function(y) y.SOTSopimusId = hakuehdot.SopimuksenTunniste)
      hakulause = hakulause.And(ehto8)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.SopimuksenMuuTunniste) Then
      Dim ehto9 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.Sopimus_Taho.Any(Function(y) y.Sopimus.SOPMuuTunniste = hakuehdot.SopimuksenMuuTunniste)
      hakulause = hakulause.And(ehto9)
    End If

    If Not String.IsNullOrWhiteSpace(hakuehdot.AsiakkaanOsoite) Then
      Dim ehto10 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHPostitusosoite.Contains(hakuehdot.AsiakkaanOsoite)
      hakulause = hakulause.And(ehto10)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.AsiakkaanPostinumero) Then
      Dim ehto11 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHPostituspostinro = hakuehdot.AsiakkaanPostinumero
      hakulause = hakulause.And(ehto11)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.AsiakkaanPostitoimipaikka) Then
      Dim ehto12 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHPostituspostitmp.Contains(hakuehdot.AsiakkaanPostitoimipaikka)
      hakulause = hakulause.And(ehto12)
    End If

    Return hakulause

  End Function

  Public Function KiinteistojenTarkkaHaku(hakuehdot As DTO.KiinteistojenHaku) As Expression(Of Func(Of Entities.Kiinteisto, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Kiinteisto, Boolean)) = PredicateBuilder.True(Of Entities.Kiinteisto)()

    If Not String.IsNullOrWhiteSpace(hakuehdot.Katuosoite) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIKatuosoite.Contains(hakuehdot.Katuosoite))
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Kiinteisto) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIKiinteisto.Contains(hakuehdot.Kiinteisto))
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Postinumero) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIPostinumero.Contains(hakuehdot.Postinumero))
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Postitoimipaikka) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIPostitoimipaikka.Contains(hakuehdot.Postitoimipaikka))
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Rekisterinumero) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIRekisterinumero = hakuehdot.Rekisterinumero)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.LyhytKiinteistotunnus) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIKiinteistotunnusLyhyt = hakuehdot.LyhytKiinteistotunnus)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Kunta) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.hlp_Kunta.KKunta.Contains(hakuehdot.Kunta))
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Kyla) Then
      hakulause = hakulause.And(Function(x As Entities.Kiinteisto) x.KIIKyla.Contains(hakuehdot.Kyla))
    End If

    Return hakulause

  End Function

  Public Function TahojenPerushaku(ParamArray hakuehdot As String()) As Expression(Of Func(Of Entities.Taho, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Taho, Boolean)) = PredicateBuilder.False(Of Entities.Taho)()

    For Each hakuehto In hakuehdot
      Dim ehto1 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHEtunimi.Contains(hakuehto)
      Dim ehto2 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHSukunimi.Contains(hakuehto)
      Dim ehto3 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) x.TAHEdellinenSukunimi.Contains(hakuehto)
      Dim ehto4 As Expression(Of Func(Of Entities.Taho, Boolean)) = Function(x As Entities.Taho) (x.TAHSukunimi & " " & x.TAHEtunimi).Contains(hakuehto)
      hakulause = hakulause.Or(ehto1)
      hakulause = hakulause.Or(ehto2)
      hakulause = hakulause.Or(ehto3)
      hakulause = hakulause.Or(ehto4)
    Next

    Return hakulause

  End Function

  Public Function KiinteistojenPerushaku(ParamArray hakuehdot As String()) As Expression(Of Func(Of Entities.Kiinteisto, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Kiinteisto, Boolean)) = PredicateBuilder.False(Of Entities.Kiinteisto)()

    For Each hakuehto In hakuehdot
      Dim ehto1 As Expression(Of Func(Of Entities.Kiinteisto, Boolean)) = Function(x As Entities.Kiinteisto) x.KIIKiinteisto.Contains(hakuehto)
      Dim ehto2 As Expression(Of Func(Of Entities.Kiinteisto, Boolean)) = Function(x As Entities.Kiinteisto) x.KIIRekisterinumero.Contains(hakuehto)
      hakulause = hakulause.Or(ehto1)
      hakulause = hakulause.Or(ehto2)
    Next

    Return hakulause

  End Function

  Public Function SopimuksienPerushaku(ParamArray hakuehdot As String()) As Expression(Of Func(Of Entities.Sopimus, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Sopimus, Boolean)) = PredicateBuilder.False(Of Entities.Sopimus)()

    For Each hakuehto In hakuehdot
      Dim ehto1 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPSopimusvuosi.Contains(hakuehto)
      Dim ehto2 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) CType(x.SOPId, String) = hakuehto
      Dim ehto3 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPMuuTunniste = hakuehto
      Dim ehto4 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Tunnisteyksikko.Any(Function(y) y.TUYPGTunnus.Contains(hakuehto))
      hakulause = hakulause.Or(ehto1)
      hakulause = hakulause.Or(ehto2)
      hakulause = hakulause.Or(ehto3)
      hakulause = hakulause.Or(ehto4)
    Next

    Return hakulause

  End Function

  Public Function SopimuksienTarkkaHaku(hakuehdot As DTO.SopimuksienHaku) As Expression(Of Func(Of Entities.Sopimus, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of Entities.Sopimus, Boolean)) = PredicateBuilder.True(Of Entities.Sopimus)()

    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonKunta) Then
      Dim ehto1 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.hlp_Kunta.KKunta.Contains(hakuehdot.KiinteistonKunta))
      hakulause = hakulause.And(ehto1)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonKyla) Then
      Dim ehto2 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.KIIKyla.Contains(hakuehdot.KiinteistonKyla))
      hakulause = hakulause.And(ehto2)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonOmistaja) Then
      Dim ehto3 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.Taho IsNot Nothing And (y.Kiinteisto.Taho.TAHEtunimi.Contains(hakuehdot.KiinteistonOmistaja) Or y.Kiinteisto.Taho.TAHSukunimi.Contains(hakuehdot.KiinteistonOmistaja)))
      hakulause = hakulause.And(ehto3)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.KiinteistonOsoite) Then
      Dim ehto4 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Sopimus_Kiinteisto.Any(Function(y) y.Kiinteisto.KIIKatuosoite.Contains(hakuehdot.KiinteistonOsoite) Or y.Kiinteisto.KIIKatuosoite.Contains(hakuehdot.KiinteistonOsoite) Or y.Kiinteisto.KIIPostitoimipaikka.Contains(hakuehdot.KiinteistonOsoite))
      hakulause = hakulause.And(ehto4)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Sopimuksennumero) Then
      Dim ehto6 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPId = hakuehdot.Sopimuksennumero
      hakulause = hakulause.And(ehto6)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Sopimuksenvuosi) Then
      Dim ehto7 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPSopimusvuosi = hakuehdot.Sopimuksenvuosi Or x.SOPAlkaa.Value.Year = hakuehdot.Sopimuksenvuosi
      hakulause = hakulause.And(ehto7)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.SopimuksenMuuTunniste) Then
      Dim ehto8 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPMuuTunniste.Contains(hakuehdot.SopimuksenMuuTunniste)
      hakulause = hakulause.And(ehto8)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.AsiakkaanNimi) Then
      Dim ehto9 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Sopimus_Taho.Any(Function(y) (If(y.Taho.TAHEtunimi, "") & " " & If(y.Taho.TAHSukunimi, "")).Contains(hakuehdot.AsiakkaanNimi))
      hakulause = hakulause.And(ehto9)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.PGTunnus) Then
      Dim ehto10 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.Tunnisteyksikko.Any(Function(y) y.TUYPGTunnus = hakuehdot.PGTunnus)
      hakulause = hakulause.And(ehto10)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.PCSNumero) Then
      Dim ehto11 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPPCSNumero = hakuehdot.PCSNumero
      hakulause = hakulause.And(ehto11)
    End If
    If Not String.IsNullOrWhiteSpace(hakuehdot.Projektivalvoja) Then
      Dim ehto12 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPProjektinvalvoja = hakuehdot.Projektivalvoja
      hakulause = hakulause.And(ehto12)
    End If
    If Not String.IsNullOrEmpty(hakuehdot.Lisatieto) Then
      Dim ehto13 As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPInfo.Contains(hakuehdot.Lisatieto)
      hakulause = hakulause.And(ehto13)
    End If

    Return hakulause

  End Function

  Public Function SopimuksienTunnistehaku(id As Integer) As Expression(Of Func(Of Entities.Sopimus, Boolean))

    Dim ehto As Expression(Of Func(Of Entities.Sopimus, Boolean)) = Function(x As Entities.Sopimus) x.SOPId = id
    Return ehto

  End Function

#Region "Kyselyiden luomismetodit"

  Private Function luoKysely(hakukentta As String, hakuehdot As List(Of String)) As Expression(Of Func(Of DataRow, Boolean))

    ' Luodaan dynaaminen kysely tietokannan rivejä vastaan.
    Dim hakulause As Expression(Of Func(Of DataRow, Boolean))
    hakulause = PredicateBuilder.True(Of DataRow)()
    For Each hakuehto In hakuehdot

      hakulause = hakulause.And(Function(x As DataRow) x(hakukentta) = x)

    Next

    Return hakulause

  End Function

#End Region

  Public Function HaeEhtoExpressio(ehto As DTO.Hakuehto, parametriExpressio As ParameterExpression, hakuKentta As PoimintaHakuKentta) As Expression

    Dim v As Expression = Expression.Property(parametriExpressio, hakuKentta.Nimi)

    Dim o As Expression = Nothing

    If Not ehto.Arvo Is Nothing Then
      If v.Type.IsGenericType AndAlso v.Type.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
        Dim t As Type = Nullable.GetUnderlyingType(v.Type)

        Select Case t
          Case GetType(Integer)
            t = GetType(Nullable(Of Integer))
          Case GetType(Date)
            t = GetType(Nullable(Of Date))
          Case GetType(Boolean)
            t = GetType(Nullable(Of Boolean))
          Case GetType(Guid)
            t = GetType(Nullable(Of Guid))
        End Select

        o = Expression.Constant(ehto.Arvo, t)
      Else
        o = Expression.Constant(ehto.Arvo)
      End If

    End If

    Dim paluuExpressio As Expression

    Select Case ehto.Operaattori
      Case DTO.Hakuoperaattori.YhtaSuuri
        paluuExpressio = Expression.Equal(v, o)
      Case DTO.Hakuoperaattori.PienempiTaiYhtaSuuri
        paluuExpressio = Expression.LessThanOrEqual(v, o)
      Case DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri
        paluuExpressio = Expression.GreaterThanOrEqual(v, o)
      Case DTO.Hakuoperaattori.EriSuuri
        paluuExpressio = Expression.NotEqual(v, o)
      Case DTO.Hakuoperaattori.EiTyhja
        o = Expression.Constant(Nothing)
        paluuExpressio = Expression.NotEqual(v, o)
      Case DTO.Hakuoperaattori.Tyhja
        o = Expression.Constant(Nothing)
        paluuExpressio = Expression.Equal(v, o)
      Case Else
        paluuExpressio = Nothing
    End Select

    Return paluuExpressio

  End Function

  Public Function HaeSqlOperaattori(operaattori As DTO.Hakuoperaattori) As String

    Select Case operaattori
      Case DTO.Hakuoperaattori.YhtaSuuri
        Return "="
      Case DTO.Hakuoperaattori.PienempiTaiYhtaSuuri
        Return "<="
      Case DTO.Hakuoperaattori.SuurempiTaiYhtaSuuri
        Return ">="
      Case DTO.Hakuoperaattori.EriSuuri
        Return "<>"
      Case DTO.Hakuoperaattori.EiTyhja
        Return "IS NOT NULL"
      Case DTO.Hakuoperaattori.Tyhja
        Return "IS NULL"
      Case Else
        Return String.Empty
    End Select

  End Function

  Public Function HaeSqlEhto(kentta As String, operaattori As DTO.Hakuoperaattori, parametriIndeksi As Integer) As String

    If operaattori = DTO.Hakuoperaattori.EiTyhja Then
      Return "(" & kentta & " " & HaeSqlOperaattori(operaattori) & " AND " & kentta & " <> '')"
    ElseIf operaattori = DTO.Hakuoperaattori.Tyhja Then
      Return "(" & kentta & " " & HaeSqlOperaattori(operaattori) & " OR " & kentta & " = '')"
    Else
      Return kentta & " " & HaeSqlOperaattori(operaattori) & " @p" & parametriIndeksi
    End If

  End Function

End Module
