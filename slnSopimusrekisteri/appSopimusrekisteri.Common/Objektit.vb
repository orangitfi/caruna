Imports System.Reflection

Public Class Objektit

  Public Shared Function Kopioi(Of T As New)(objekti As T) As T

    Dim uusiObjekti As New T()

    For Each pInfo As PropertyInfo In GetType(T).GetProperties()

      If (pInfo.PropertyType.IsValueType Or pInfo.PropertyType = GetType(String)) And pInfo.CanWrite Then

        pInfo.SetValue(uusiObjekti, pInfo.GetValue(objekti))

      End If

    Next

    Return uusiObjekti

  End Function

End Class
