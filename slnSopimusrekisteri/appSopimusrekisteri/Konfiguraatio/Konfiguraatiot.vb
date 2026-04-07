Public Class Konfiguraatiot

    Public Shared ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Get
    End Property

    Public Shared ReadOnly Property TemplateHakemisto As String
        Get
            Return ConfigurationManager.AppSettings("Templatehakemisto").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property NaytaMaksuaineistoKayttajalle As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("NaytaMaksuaineistoKayttajalle"))
        End Get
    End Property

    Public Shared ReadOnly Property LahetaSahkopostiUudelleKayttajalle As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("LahetaSahkopostiUudelleKayttajalle"))
        End Get
    End Property

    Public Shared ReadOnly Property LahetaSahkopostiMaksuaineistoista As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("LahetaSahkopostiMaksuaineistoista"))
        End Get
    End Property

    Public Shared ReadOnly Property LahetaSahkopostiKirjanpitoaineistosta As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("LahetaSahkopostiKirjanpitoaineistosta"))
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoOsoite As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistoOsoite").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpitoaineistoOsoite As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpitoaineistoOsoite").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property SahkopostinLahettaja As String
        Get
            Return ConfigurationManager.AppSettings("SahkopostinLahettaja").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property SmtpPalvelin As String
        Get
            Return ConfigurationManager.AppSettings("SmtpPalvelin").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property ServiceTunnus As String
        Get
            Return ConfigurationManager.AppSettings("ServiceTunnus").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property ServiceTunnusSalasana As String
        Get
            Return ConfigurationManager.AppSettings("ServiceTunnusSalasana").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property ServiceTunnusDomain As String
        Get
            Return ConfigurationManager.AppSettings("ServiceTunnusDomain").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property SopimusarkistoListaId As String
        Get
            Return ConfigurationManager.AppSettings("SopimusarkistoListaId").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property SopimusarkistoNakymaId As String
        Get
            Return ConfigurationManager.AppSettings("SopimusarkistoNakymaId").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property PdfLisenssi As String
        Get
            Return ConfigurationManager.AppSettings("PdfLisenssi").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property PdfContentType As String
        Get
            Return "application/pdf"
        End Get
    End Property

    Public Shared ReadOnly Property SopimusarkistoIntegraatioPaalla As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("SopimusarkistoIntegraatioPaalla").ToString())
        End Get
    End Property

    Public Shared ReadOnly Property SopimusarkistoUrl As String
        Get
            Return ConfigurationManager.AppSettings("SopimusarkistoUrl").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property SopimusarkistoHeratysUrl As String
        Get
            Return ConfigurationManager.AppSettings("SopimusarkistoHeratysUrl").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property NaytaKirjanpidonAineistoKayttajalle As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("NaytaKirjanpidonAineistoKayttajalle").ToString())
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpitoOhjelmistotunniste As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpitoOhjelmistotunniste").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpitoKategoria As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpitoKategoria").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpitoClearingTili As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpitoClearingTili").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpitoClearingKustannuspaikkaPrefix As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpitoClearingKustannuspaikkaPrefix").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KopioiMaksuaineistoPalvelimelle As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("KopioiMaksuaineistoPalvelimelle"))
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoVaatiiServiceTunnukset As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("MaksuaineistoVaatiiServiceTunnukset"))
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistonPolku As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistonPolku").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property KopioiKirjanpidonAineistoPalvelimelle As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("KopioiKirjanpidonAineistoPalvelimelle"))
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpidonAineistoVaatiiServiceTunnukset As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("KirjanpidonAineistoVaatiiServiceTunnukset"))
        End Get
    End Property

    Public Shared ReadOnly Property KirjanpidonAineistonPolku As String
        Get
            Return ConfigurationManager.AppSettings("KirjanpidonAineistonPolku").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property TestiYmparisto As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("TestiYmparisto"))
        End Get
    End Property

    Public Shared ReadOnly Property Ymparisto As String
        Get
            Return ConfigurationManager.AppSettings("Ymparisto")
        End Get
    End Property

    Public Shared ReadOnly Property YmparistoKanta As String
        Get
            Return ConfigurationManager.AppSettings("YmparistoKanta")
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoOletusOsoite As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistoOletusOsoite")
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoOletusPostinro As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistoOletusPostinro")
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoOletusPostitmp As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistoOletusPostitmp")
        End Get
    End Property

    Public Shared ReadOnly Property MaksuaineistoVuokraCategory As String
        Get
            Return ConfigurationManager.AppSettings("MaksuaineistoVuokraCategory")
        End Get
    End Property

    Public Shared ReadOnly Property MFilesHttpLink As String
        Get
            Return ConfigurationManager.AppSettings("MFilesHttpLink").ToString()
        End Get
    End Property

    Public Shared ReadOnly Property NaytaVanhaSharepointLinkki As Boolean
        Get
            Return CBool(ConfigurationManager.AppSettings("NaytaVanhaSharepointLinkki"))
        End Get
    End Property

End Class
