Public Interface ITemplateContext

    Function GetTemplate(entityType As Type, context As ITemplateContext) As ITemplateEntity

    ReadOnly Property TagStart As String
    ReadOnly Property TagEnd As String
    ReadOnly Property SubEntityDelimiter As Char

    ReadOnly Property RegionStart As String
    ReadOnly Property RegionEnd As String

    ReadOnly Property RegionKeyStart As String
    ReadOnly Property RegionKeyEnd As String

End Interface
