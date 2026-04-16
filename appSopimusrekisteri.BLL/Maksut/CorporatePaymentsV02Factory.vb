Imports System.Xml
Imports System.Xml.Serialization

Namespace CorporatePaymentsV02

  Public Class CorporatePaymentsV02Factory

    Private _dicPaymentGroups As Dictionary(Of String, String)
    Private _dicCreditTransferTransactionInformation As Dictionary(Of String, List(Of CreditTransferTransactionInformation1))
    Private _dicPaymentInstructionInformation As Dictionary(Of String, PaymentInstructionInformation1)
    Private _initiatingPartyName As String
    Private _initiatingPartyIdentification As String
    Private _paymentInstructionInformationId As Integer
    Private _msgId As String

    Public Sub New(initiatingPartyName As String, initiatingPartyIdentification As String)

      _dicPaymentGroups = New Dictionary(Of String, String)
      _dicCreditTransferTransactionInformation = New Dictionary(Of String, List(Of CreditTransferTransactionInformation1))
      _dicPaymentInstructionInformation = New Dictionary(Of String, PaymentInstructionInformation1)

      _initiatingPartyName = initiatingPartyName
      _initiatingPartyIdentification = initiatingPartyIdentification

      _paymentInstructionInformationId = 1
      _msgId = Date.Now.Ticks

    End Sub

    Public Sub CreateFile(filepath As String)

      Dim doc As New Document()

      Dim pain As New pain00100102()

      pain.GrpHdr = GetGroupHeader()

      Dim lstPaymentInstructionInformation As New List(Of PaymentInstructionInformation1)

      Dim pmtInf As PaymentInstructionInformation1

      For Each kv As KeyValuePair(Of String, PaymentInstructionInformation1) In _dicPaymentInstructionInformation

        pmtInf = kv.Value

        If _dicCreditTransferTransactionInformation.ContainsKey(kv.Key) Then
          pmtInf.CdtTrfTxInf = _dicCreditTransferTransactionInformation(kv.Key).ToArray()
        End If

        lstPaymentInstructionInformation.Add(pmtInf)

      Next

      pain.PmtInf = lstPaymentInstructionInformation.ToArray()

      doc.pain00100102 = pain

      Dim xmlSer As New XmlSerializer(GetType(Document))

      Dim xmlWriterSettings As New XmlWriterSettings()
      xmlWriterSettings.Indent = True
      xmlWriterSettings.Encoding = Text.Encoding.UTF8

      Dim xmlWriter As XmlWriter = xmlWriter.Create(filepath, xmlWriterSettings)

      xmlSer.Serialize(xmlWriter, doc)

      xmlWriter.Close()

    End Sub

    Private Function GetGroupHeader() As GroupHeader1

      Dim gH As New GroupHeader1()

      gH.MsgId = _msgId
      gH.CreDtTm = Date.Now

      gH.NbOfTxs = (From c As List(Of CreditTransferTransactionInformation1) In _dicCreditTransferTransactionInformation.Values Select c.Count).Sum()

      gH.Grpg = Grouping1Code.MIXD

      gH.InitgPty = GetPartyIdentification(_initiatingPartyName)

      Return gH

    End Function

        Private Function GetPaymentInstructionInformation(id As String, debtorAccount As String, debtorBic As String, executionDate As Date) As PaymentInstructionInformation1

            Dim p As New PaymentInstructionInformation1()

            p.PmtInfId = id

            p.PmtMtd = PaymentMethod3Code.TRF
            p.ReqdExctnDt = executionDate

            p.Dbtr = GetPartyIdentification(_initiatingPartyName)

            p.Dbtr.Id = GetPartyChoice(_initiatingPartyIdentification)

            p.DbtrAcct = GetCashAccount(debtorAccount)

            p.DbtrAgt = GetBranchAndFinancialInstitutionIdentification(debtorBic)

            Return p

        End Function

    Private Function GetBranchAndFinancialInstitutionIdentification(bic As String) As BranchAndFinancialInstitutionIdentification3

      Dim b As New BranchAndFinancialInstitutionIdentification3()

      b.FinInstnId = New FinancialInstitutionIdentification5Choice()

      b.FinInstnId.Item = bic

      Return b

    End Function

    Private Function GetPartyChoice(bankPartyId As String) As Party2Choice

      Dim p As New Party2Choice()

      Dim o As New OrganisationIdentification2()

      o.BkPtyId = bankPartyId

      p.Items = {o}

      Return p
    End Function

    Public Function AddSEPATransferWithReferencenumber(id As String, debtorAccount As String, debtorBic As String, executionDate As Date, amount As Decimal, creditorName As String, creditorAccount As String, creditorBic As String, referencenumber As String) As String

      Dim paymentGroupId As String = GetPaymentGroup(debtorAccount, debtorBic, executionDate)

      If Not _dicCreditTransferTransactionInformation.ContainsKey(paymentGroupId) Then
        _dicCreditTransferTransactionInformation.Add(paymentGroupId, New List(Of CreditTransferTransactionInformation1))
      End If

      Dim c As New CreditTransferTransactionInformation1()

      c.PmtId = New PaymentIdentification1()
      c.PmtId.EndToEndId = paymentGroupId & "_" & id

      c.Amt = GetAmountTypeChoice("EUR", amount)

      c.Cdtr = GetPartyIdentification(creditorName)

      c.CdtrAcct = GetCashAccount(creditorAccount)

      c.CdtrAgt = GetBranchAndFinancialInstitutionIdentification(creditorBic)

      c.RmtInf = GetRemittanceInformationWithReference(referencenumber)

      _dicCreditTransferTransactionInformation(paymentGroupId).Add(c)

      Return paymentGroupId

    End Function

    Public Function AddSEPATransferWithMessage(id As String, debtorAccount As String, debtorBic As String, executionDate As Date, amount As Decimal, creditorName As String, creditorAccount As String, creditorBic As String, message As String) As String

      Dim paymentGroupId As String = GetPaymentGroup(debtorAccount, debtorBic, executionDate)

      If Not _dicCreditTransferTransactionInformation.ContainsKey(paymentGroupId) Then
        _dicCreditTransferTransactionInformation.Add(paymentGroupId, New List(Of CreditTransferTransactionInformation1))
      End If

      Dim c As New CreditTransferTransactionInformation1()

      c.PmtId = New PaymentIdentification1()
      c.PmtId.EndToEndId = paymentGroupId & "_" & id

      c.Amt = GetAmountTypeChoice("EUR", amount)

      c.Cdtr = GetPartyIdentification(creditorName)

      c.CdtrAcct = GetCashAccount(creditorAccount)

      c.CdtrAgt = GetBranchAndFinancialInstitutionIdentification(creditorBic)

      c.RmtInf = GetRemittanceInformationWithMessage(message)

      _dicCreditTransferTransactionInformation(paymentGroupId).Add(c)

      Return paymentGroupId

    End Function

    Private Function GetPaymentGroup(debtorAccount As String, debtorBic As String, executionDate As Date) As String

      Dim paymentGroupInfo As String = debtorAccount & debtorBic & executionDate.ToString()

      Dim paymentGroupId As String

      If _dicPaymentGroups.ContainsKey(paymentGroupInfo) Then
        paymentGroupId = _dicPaymentGroups(paymentGroupInfo)
      Else
        paymentGroupId = _msgId & "_" & _paymentInstructionInformationId
        _paymentInstructionInformationId += 1

        _dicPaymentGroups.Add(paymentGroupInfo, paymentGroupId)
      End If

      If Not _dicPaymentInstructionInformation.ContainsKey(paymentGroupId) Then
        _dicPaymentInstructionInformation.Add(paymentGroupId, GetPaymentInstructionInformation(paymentGroupId, debtorAccount, debtorBic, executionDate))
      End If

      Return paymentGroupId

    End Function

    Private Function GetAmountTypeChoice(currency As String, amount As Decimal) As AmountType2Choice

      Dim a As New AmountType2Choice()

      Dim cA As New CurrencyAndAmount()
      cA.Ccy = currency
      cA.Value = amount

      a.Item = cA

      Return a

    End Function

    Private Function GetPartyIdentification(name As String) As PartyIdentification8

      Dim p As New PartyIdentification8()

      p.Nm = name

      Return p

    End Function

    Private Function GetCashAccount(iban As String) As CashAccount7

      Dim c As New CashAccount7()
      c.Id = New AccountIdentification3Choice()
      c.Id.ItemElementName = ItemChoiceType3.IBAN
      c.Id.Item = iban

      Return c

    End Function

    Private Function GetRemittanceInformationWithReference(referencenumber As String) As RemittanceInformation1

      Dim r As New RemittanceInformation1()

      Dim sR As New StructuredRemittanceInformation6()

      sR.CdtrRefInf = New CreditorReferenceInformation1()
      sR.CdtrRefInf.CdtrRefTp = New CreditorReferenceType1()
      sR.CdtrRefInf.CdtrRefTp.Item = "SCOR"

      sR.CdtrRefInf.CdtrRef = referencenumber

      r.Strd = {sR}

      Return r

    End Function

    Private Function GetRemittanceInformationWithMessage(message As String) As RemittanceInformation1

      Dim r As New RemittanceInformation1()

      r.Ustrd = {Left(message, 140)}

      Return r

    End Function

    Public ReadOnly Property TransactionId As String
      Get
        Return _msgId
      End Get
    End Property

  End Class

End Namespace