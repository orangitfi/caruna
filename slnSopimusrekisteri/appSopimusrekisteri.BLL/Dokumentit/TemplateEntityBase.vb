Option Strict On

Public MustInherit Class TemplateEntityBase(Of T)
    Implements ITemplateEntity(Of T)

    Private _context As ITemplateContext

    Public Sub New(context As ITemplateContext)
        Me._context = context
    End Sub

    Public Function GetReplaceValue(key As String, entity As Object) As String Implements ITemplateEntity.GetReplaceValue

        If key.Contains(Me._context.SubEntityDelimiter) Then

            Dim subTemplateKey As String = key.Substring(0, key.IndexOf(Me._context.SubEntityDelimiter))

            If Not IsNothing(Me.SubEntityKeys) AndAlso Me.SubEntityKeys.Contains(subTemplateKey) Then
                Dim subEntity As Object = Me.GetSubEntity(subTemplateKey, entity)
                If IsNothing(subEntity) Then Return String.Empty
                Dim subTemplate As ITemplateEntity = Me._context.GetTemplate(subEntity.GetType(), Me._context)
                Return subTemplate.GetReplaceValue(key.Substring(key.IndexOf(Me._context.SubEntityDelimiter) + 1), subEntity)
            Else
                Return Nothing
            End If

        End If

        Return GetPropertyValue(key, CType(entity, T))

    End Function

    Protected MustOverride Function GetPropertyValue(key As String, entity As T) As String

    Public MustOverride Function GetSubEntity(key As String, entity As Object) As Object Implements ITemplateEntity.GetSubEntity

    Public MustOverride ReadOnly Property SubEntityKeys As IEnumerable(Of String) Implements ITemplateEntity.SubEntityKeys

End Class
