Imports System.Configuration

Public Class Konfiguraatiot

  Public Shared ReadOnly Property ConnectionString As String
    Get
      Return ConfigurationManager.ConnectionStrings("defaultSQLServer").ConnectionString
    End Get
  End Property

  Public Shared ReadOnly Property Kayttajatunnus As String
    Get
      Return "Sopimusarkisto"
    End Get
  End Property

  Public Shared ReadOnly Property MaxSiirtoMaara As Integer
    Get
      Return CInt(ConfigurationManager.AppSettings("MaxSiirtoMaara"))
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

  Public Shared ReadOnly Property SopimusarkistoHeratysUrl As String
    Get
      Return ConfigurationManager.AppSettings("SopimusarkistoHeratysUrl").ToString()
    End Get
  End Property

  Public Shared ReadOnly Property TestiMoodi As Boolean
    Get
      Return CBool(ConfigurationManager.AppSettings("TestiMoodi"))
    End Get
  End Property

  Public Shared ReadOnly Property LokiPolku As String
    Get
      Return ConfigurationManager.AppSettings("LokiPolku").ToString()
    End Get
  End Property

  Public Shared ReadOnly Property SopimusarkistoPolkuUudet As String
    Get
      Return ConfigurationManager.AppSettings("SopimusarkistoPolkuUudet").ToString()
    End Get
  End Property

  Public Shared ReadOnly Property SopimusarkistoPolku As String
    Get
      Return ConfigurationManager.AppSettings("SopimusarkistoPolku").ToString()
    End Get
  End Property

  Public Shared ReadOnly Property TiedostoraporttiPolku As String
    Get
      Return ConfigurationManager.AppSettings("TiedostoraporttiPolku").ToString()
    End Get
  End Property

End Class
