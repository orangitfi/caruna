Imports System.IO
Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF

Public Class Hakemistot

    Public Shared ReadOnly Property Juuri As String
        Get
            Return HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath.TrimEnd("/") + "/"
        End Get
    End Property

    Public Shared ReadOnly Property TemplateHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & "\Dokumentit\"

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property LiiteHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & "\Dokumentit\"

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property ExcelHakemistoRelatiivinen As String
        Get
            Return "~/Dokumentit/Excel/"
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoHakemistoRelatiivinen As String
        Get
            Return "~/Dokumentit/Maksuaineisto/"
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpidonaineistoHakemistoRelatiivinen As String
        Get
            Return "~/Dokumentit/Kirjanpidonaineisto/"
        End Get
    End Property

    Public Shared ReadOnly Property PcsRaporttiHakemisto As String
        Get
            Dim strPolku As String = IOUtils.CombinePaths(AppDomain.CurrentDomain.BaseDirectory, "Dokumentit\PcsRaportit\")

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property SopimusHakemistoRelatiivinen As String
        Get
            Return "~/Dokumentit/Sopimukset/"
        End Get
    End Property

    Public Shared ReadOnly Property ExcelHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & MuutaRelatiivinenPolku(ExcelHakemistoRelatiivinen)

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & MuutaRelatiivinenPolku(MaksuaineistoHakemistoRelatiivinen)

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpidonaineistoHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & MuutaRelatiivinenPolku(KirjanpidonaineistoHakemistoRelatiivinen)

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared ReadOnly Property SopimusHakemisto As String
        Get
            Dim strPolku As String = AppDomain.CurrentDomain.BaseDirectory & MuutaRelatiivinenPolku(SopimusHakemistoRelatiivinen)

            TarkastaHakemisto(strPolku)

            Return strPolku
        End Get
    End Property

    Public Shared Sub TarkastaHakemisto(polku As String)

        If Not Directory.Exists(polku) Then
            Directory.CreateDirectory(polku)
        End If

    End Sub

    Public Shared Function MuutaRelatiivinenPolku(polku As String) As String
        Return polku.Replace("/", "\").Replace("~", "")
    End Function

    Public Shared Function HaeSopimusHakemisto(sopimustyyppi As Sopimustyypit) As String

        Dim strHakemisto As String = "~/Sopimus/{0}/"

        Select Case sopimustyyppi

            Case Sopimustyypit.Johtoaluesopimus
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.Maankayttosopimus
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.Yksityistiesopimus
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.PylvaidenJaMaadYhteiskayttosopimus
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.Suostumus
                Return String.Format(strHakemisto, "Suostumus")
            Case Sopimustyypit.MuistioSuullisestaSopimuksesta
                Return String.Format(strHakemisto, "Suostumus")
            Case Sopimustyypit.Muuntamosopimus
                Return String.Format(strHakemisto, "Muuntamo")
            Case Sopimustyypit.Kiinteistomuuntamosopimus
                Return String.Format(strHakemisto, "Muuntamo")
            Case Sopimustyypit.Sijoituslupa
                Return String.Format(strHakemisto, "Lupa")
            Case Sopimustyypit.Rakennuslupa
                Return String.Format(strHakemisto, "Lupa")
            Case Sopimustyypit.Toimenpidelupa
                Return String.Format(strHakemisto, "Lupa")
            Case Sopimustyypit.Vuokrasopimus
                Return String.Format(strHakemisto, "Vuokra")
            Case Sopimustyypit.Risteilylupa
                Return String.Format(strHakemisto, "Lupa")
            Case Sopimustyypit.JohtoaluesopimusMaakaapeli
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.CCAPylvaidenLuovutuskirja
                Return String.Format(strHakemisto, "Suostumus")
            Case Sopimustyypit.SijoituslupaMRL161
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.KiinteistonKauppakirja
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.YhteistoimintasopimusKunta
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.YhteiskayttoPuitesopimus
                Return String.Format(strHakemisto, "JAS")
            Case Sopimustyypit.Naapurisuostumus
                Return String.Format(strHakemisto, "Suostumus")
            Case Sopimustyypit.SuurjanniteverkkoVuokrasopimus
                Return String.Format(strHakemisto, "Vuokra")
            Case Else
                Return "~/Etusivu.aspx"

        End Select

    End Function

End Class
