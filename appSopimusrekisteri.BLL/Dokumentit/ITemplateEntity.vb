Option Strict On

Public Interface ITemplateEntity

    ReadOnly Property SubEntityKeys As IEnumerable(Of String)

    Function GetReplaceValue(key As String, entity As Object) As String

    Function GetSubEntity(key As String, entity As Object) As Object

End Interface

Public Interface ITemplateEntity(Of T)
    Inherits ITemplateEntity

End Interface
