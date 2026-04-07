Public Class SuostumusContext
  Implements ITemplateContext

  Public Function GetTemplate(entityType As Type, context As ITemplateContext) As ITemplateEntity Implements ITemplateContext.GetTemplate

    Select Case entityType

      Case GetType(DTO.Sopimus)
        Return New SuostumusTemplate(context)
      Case GetType(DTO.Taho)
        Return New TahoTemplate(context)
      Case GetType(DTO.Kiinteisto)
        Return New KiinteistoTemplate(context)
      Case GetType(DTO.Korvauslaskelma)
        Return New KorvausTemplate(context)
      Case GetType(Tuple(Of DTO.Taho, DTO.Taho))
        Return New TahoPariTemplate(context)
      Case GetType(DTO.Tunnisteyksikko)
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
