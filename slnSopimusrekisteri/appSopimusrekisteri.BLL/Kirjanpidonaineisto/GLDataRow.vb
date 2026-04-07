Public Class GLDataRow

  Private _strProject As String
  Private _strInvCost As String
  Private _strPartner As String
  Private _strProduct As String
  Private _strCustomer As String
  Private _strContract As String
  Private _strPurpose As String
  Private _strAs As String
  Private _strTaxper As String
  Private _strAbc As String
  Private _strLocal1 As String
  Private _strLocal2 As String

  Public ReadOnly Property Record_type As String
    Get
      Return "002"
    End Get
  End Property
  Public Property Batch_id As String
  Public Property Org_id As String
  Public Property Source As String
  Public Property Document_number As Integer
  Public Property Document_category As String
  Public Property Gl_date As Date?
  Public Property Company As String
  Public Property Response As String
  Public Property Account As String
  Public Property Project As String
    Set(value As String)
      Me._strProject = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strProject) Then
        Return Me._strProject
      End If

      Return "0"
    End Get
  End Property
  Public Property Invcost As String
    Set(value As String)
      Me._strInvCost = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strInvCost) Then
        Return Me._strInvCost
      End If

      Return "0"
    End Get
  End Property
  Public Property Partner As String
    Set(value As String)
      Me._strPartner = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strPartner) Then
        Return Me._strPartner
      End If

      Return "0"
    End Get
  End Property
  Public Property Product As String
    Set(value As String)
      Me._strProduct = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strProduct) Then
        Return Me._strProduct
      End If

      Return "0"
    End Get
  End Property
  Public Property Customer As String
    Set(value As String)
      Me._strCustomer = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strCustomer) Then
        Return Me._strCustomer
      End If

      Return "0"
    End Get
  End Property
  Public Property Country As String
  Public Property Contract As String
    Set(value As String)
      Me._strContract = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strContract) Then
        Return Me._strContract
      End If

      Return "0"
    End Get
  End Property
  Public Property Purpose As String
    Set(value As String)
      Me._strPurpose = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strPurpose) Then
        Return Me._strPurpose
      End If

      Return "0"
    End Get
  End Property
  Public Property [As] As String
    Set(value As String)
      Me._strAs = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strAs) Then
        Return Me._strAs
      End If

      Return "0"
    End Get
  End Property
  Public Property Taxper As String
    Set(value As String)
      Me._strTaxper = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strTaxper) Then
        Return Me._strTaxper
      End If

      Return "0"
    End Get
  End Property
  Public Property Abc As String
    Set(value As String)
      Me._strAbc = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strAbc) Then
        Return Me._strAbc
      End If

      Return "0"
    End Get
  End Property
  Public Property Local1 As String
    Set(value As String)
      Me._strLocal1 = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strLocal1) Then
        Return Me._strLocal1
      End If

      Return "0"
    End Get
  End Property
  Public Property Local2 As String
    Set(value As String)
      Me._strLocal2 = value
    End Set
    Get
      If Not String.IsNullOrEmpty(Me._strLocal2) Then
        Return Me._strLocal2
      End If

      Return "0"
    End Get
  End Property
  Public Property Currency_code As String
  Public Property Conversion_type As String
  Public Property Currency_rate As Decimal?
  Public Property Conversion_date As Date?
  Public Property Debet_sum As Decimal?
  Public Property Credit_sum As Decimal?
  Public Property Stat_amount As Decimal?
  Public Property Description As String
  Public Property Gldata_attribute1 As String
  Public Property Gldata_attribute2 As String
  Public Property Gldata_attribute3 As String
  Public Property Gldata_attribute4 As String
  Public Property Gldata_attribute5 As String
  Public Property Gldata_attribute6 As String
  Public Property Gldata_attribute7 As String
  Public Property Gldata_attribute8 As String
  Public Property Gldata_attribute9 As String
  Public Property Gldata_attribute10 As String
  Public Property Flex_build_flag As String
  Public Property Tax_code As String
  Public Property Reserved1 As String
  Public Property Reserved2 As String
  Public Property Reserved3 As String

End Class
