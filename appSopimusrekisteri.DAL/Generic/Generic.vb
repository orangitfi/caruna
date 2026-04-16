Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection

Public Class GenericSorter(Of T)

    Public Function Sort(ByVal source As IQueryable(Of T), _
                         ByVal sortBy As String, _
                         ByVal sortDirection As String) As IEnumerable(Of T)

        Dim param = Expression.Parameter(GetType(T), "item")
        Dim propertyType As Type

        Dim propertyInfo As PropertyInfo = GetType(T).GetProperty(sortBy)
        propertyType = propertyInfo.PropertyType


        'If sortBy.Contains(".") Then

        '    Dim split = sortBy.Split(".")
        '    Dim childNavigationPropertyInfo As PropertyInfo = GetType(T).GetProperty(split(0).ToString())
        '    Dim childPropertyInfo As PropertyInfo = childNavigationPropertyInfo.PropertyType.GetProperty(split(1))
        '    propertyType = childPropertyInfo.PropertyType

        'Else

        '    Dim propertyInfo As PropertyInfo = GetType(T).GetProperty(sortBy)
        '    propertyType = propertyInfo.PropertyType

        'End If

        If propertyType = GetType(String) Then

            Dim sortExpression = Expression.Lambda(Of Func(Of T, String))(Expression.Convert(Expression.[Property](param, sortBy), GetType(String)), param)

            Select Case sortDirection.ToLower
                Case "asc"
                    Return source.OrderBy(sortExpression)
                Case Else
                    Return source.OrderByDescending(sortExpression)
            End Select

        ElseIf propertyType = GetType(Int32) Then
            Dim sortExpression = Expression.Lambda(Of Func(Of T, Int32))(Expression.Convert(Expression.[Property](param, sortBy), GetType(Int32)), param)

            Select Case sortDirection.ToLower
                Case "asc"
                    Return source.OrderBy(sortExpression)
                Case Else
                    Return source.OrderByDescending(sortExpression)
            End Select

        ElseIf propertyType = GetType(Decimal) Then
            Dim sortExpression = Expression.Lambda(Of Func(Of T, Decimal))(Expression.Convert(Expression.[Property](param, sortBy), GetType(Decimal)), param)

            Select Case sortDirection.ToLower
                Case "asc"
                    Return source.OrderBy(sortExpression)
                Case Else
                    Return source.OrderByDescending(sortExpression)
            End Select
        End If

    End Function

End Class