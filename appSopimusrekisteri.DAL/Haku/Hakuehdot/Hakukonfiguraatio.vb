Imports System.Configuration

Public Module Hakukonfiguraatio

    Property HakutulostenMaksimimaara As String = CType(ConfigurationManager.AppSettings("HakutulostenMaksimimaara"), Integer)

End Module
