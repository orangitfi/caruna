Imports System.Linq.Expressions
Imports System.Reflection

Public Class PropertyAvustaja(Of TObjekti)

  Public Function HaePropertyNimi(Of TProperty)(expression As Expression(Of Func(Of TObjekti, TProperty))) As String

    Dim p As MemberExpression = expression.Body

    Return p.Member.Name

  End Function

  Public Function HaeTempSarakkeet() As Dictionary(Of String, String)

    Dim dicSarakkeet As New Dictionary(Of String, String)()

    For Each pInfo As PropertyInfo In GetType(TObjekti).GetProperties()

      If pInfo.Name.StartsWith("C_") Then
        dicSarakkeet.Add(Right(pInfo.Name, pInfo.Name.Length - 1), pInfo.Name)
      End If

    Next

    Return dicSarakkeet
  End Function

  Public Function HaeTietotyyppi(kentta As String) As Type

    Dim pInfo As PropertyInfo = GetType(TObjekti).GetProperties().Where(Function(x) x.Name = kentta).FirstOrDefault()

    If Not pInfo Is Nothing Then

      Dim pTyyppi As Type = pInfo.PropertyType

      If pTyyppi.IsGenericType AndAlso pTyyppi.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then

        pTyyppi = Nullable.GetUnderlyingType(pTyyppi)

      End If

      Return pTyyppi

    End If

    Return Nothing

  End Function

End Class
