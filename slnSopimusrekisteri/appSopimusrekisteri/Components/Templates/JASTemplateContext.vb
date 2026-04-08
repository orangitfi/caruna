Imports TemplateHandler
Imports Sopimusrekisteri.BLL_CF

Public Class JASTemplateContext
  Implements ITemplateContext

  Public Function GetTemplate(entityType As Type, context As ITemplateContext) As ITemplateEntity Implements ITemplateContext.GetTemplate

    If entityType.Namespace = "System.Data.Entity.DynamicProxies" Then
      entityType = entityType.BaseType
    End If

    Select Case entityType

      Case GetType(Sopimusrekisteri.BLL_CF.Sopimus)
        Return New JASTemplate(context)
      Case GetType(Sopimusrekisteri.BLL_CF.Taho)
        Return New TahoTemplate(context)
      Case GetType(Kiinteisto)
        Return New KiinteistoTemplate(context)
      Case GetType(Sopimusrekisteri.BLL_CF.Korvauslaskelma)
        Return New KorvausTemplate(context)
      Case GetType(Tunnisteyksikko)
        Return New TunnisteyksikkoTemplate(context)

    End Select

    Throw New NotImplementedException("Toteutus tyypille " + entityType.ToString() + " puuttuu!")

  End Function

  Public ReadOnly Property RegionEnd As String Implements ITemplateContext.RegionEnd
    Get
      Return ">>"
    End Get
  End Property

  Public ReadOnly Property RegionKeyEnd As String Implements ITemplateContext.RegionKeyEnd
    Get
      Return "}"
    End Get
  End Property

  Public ReadOnly Property RegionKeyStart As String Implements ITemplateContext.RegionKeyStart
    Get
      Return "{"
    End Get
  End Property

  Public ReadOnly Property RegionStart As String Implements ITemplateContext.RegionStart
    Get
      Return "<<"
    End Get
  End Property

  Public ReadOnly Property SubEntityDelimiter As Char Implements ITemplateContext.SubEntityDelimiter
    Get
      Return "."
    End Get
  End Property

  Public ReadOnly Property TagEnd As String Implements ITemplateContext.TagEnd
    Get
      Return "]"
    End Get
  End Property

  Public ReadOnly Property TagStart As String Implements ITemplateContext.TagStart
    Get
      Return "["
    End Get
  End Property
End Class
