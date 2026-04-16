Option Strict On

Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Packaging
Imports KT.Utils
Imports System.IO

Public Class WordTemplateHelper

#Region "Attribuutit ja vakiot"

    Private Const RunTagName As String = "r"
    'Private Const NewLineDelimiter As String = "rv"
    'Private Const NewLineMarker As String = "@rv"

    Private Const SpaceChar As Char = " "c

#End Region

#Region "Dokumentin käsittely"


    Public Shared Sub ReplaceDocumentValues(tiedostonimi As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext)

        Using doc As DocumentFormat.OpenXml.Packaging.WordprocessingDocument = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(tiedostonimi, True)

            ProcessContent(doc, entityTemplate, entity, context)

            doc.MainDocumentPart.Document.Save()

        End Using

    End Sub

    Public Shared Sub ProcessContent(doc As DocumentFormat.OpenXml.Packaging.WordprocessingDocument, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext)

        'Dim w As XNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main"

        ProcessDocumentPart(doc.MainDocumentPart.RootElement, entityTemplate, entity, context)

    End Sub

    Private Shared Sub ProcessDocumentPart(documentPart As DocumentFormat.OpenXml.OpenXmlElement, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext)

        Dim subPart As DocumentFormat.OpenXml.OpenXmlElement = documentPart.FirstChild

        Dim processed As Boolean = False

        Dim replaceInfo As New RegionReplaceInfo()

        While Not IsNothing(subPart)

            If subPart.LocalName.ToLower() = RunTagName Then

                processed = True

                Dim t1 As Text = subPart.ChildElements.OfType(Of Text)().FirstOrDefault

                If IsNothing(t1) Then
                    subPart = subPart.NextSibling
                    Continue While
                End If

                Dim tagStart As String
                Dim tagEnd As String

                If t1.Text.Contains(context.RegionStart) Then
                    tagStart = context.RegionStart
                    tagEnd = context.RegionEnd
                Else
                    tagStart = context.TagStart
                    tagEnd = context.TagEnd
                End If

                Dim openTags As Integer = StringUtils.CountOccurences(t1.Text, tagStart)
                Dim closeTags As Integer = StringUtils.CountOccurences(t1.Text, tagEnd)


                If openTags <> closeTags AndAlso Not IsNothing(subPart.NextSibling) Then

                    Dim t2 As Text = subPart.NextSibling.ChildElements.OfType(Of Text)().FirstOrDefault

                    If Not IsNothing(t2) Then

                        t1.Text &= t2.Text

                        subPart.NextSibling.Remove()
                    Else
                        subPart = subPart.NextSibling
                    End If

                    Continue While

                ElseIf openTags > 0 Then

                    t1.Text = TemplateHandler.GetRelpacedContent(t1.Text, entityTemplate, entity, context, replaceInfo)
                    t1.Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve
                    If replaceInfo.FontSize.HasValue Then
                        Dim runPart As Run = CType(subPart, Run)
                        If IsNothing(runPart.RunProperties) Then runPart.RunProperties = New RunProperties()
                        runPart.RunProperties.FontSize = New FontSize() With {.Val = New DocumentFormat.OpenXml.StringValue((replaceInfo.FontSize.Value * 2).ToString())}
                    End If

                End If

            End If

            subPart = subPart.NextSibling

        End While

        If processed Then Return

        subPart = documentPart.FirstChild

        While Not IsNothing(subPart)

            ProcessDocumentPart(subPart, entityTemplate, entity, context)

            subPart = subPart.NextSibling

        End While

    End Sub



    Public Shared Sub CombineDocuments(targetDocumentFile As String, documentFilesToAdd As IEnumerable(Of String))


        Using doc As DocumentFormat.OpenXml.Packaging.WordprocessingDocument = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(targetDocumentFile, True)

            Dim mainPart As MainDocumentPart = doc.MainDocumentPart

            Dim i As Integer = 0

            For Each f As String In documentFilesToAdd.OrderByDescending(Function(x) x)

                Dim altChunkId As String = "AltChunkId" & CStr(i)

                Dim chunk As AlternativeFormatImportPart = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId)

                Using fs As FileStream = File.Open(f, FileMode.Open)
                    chunk.FeedData(fs)
                End Using

                Dim altChunk As New AltChunk()
                altChunk.Id = altChunkId

                mainPart.Document.Body.InsertAfter(altChunk, mainPart.Document.Body.Elements(Of Paragraph).Last)

                i += 1

            Next

            mainPart.Document.Save()

        End Using

    End Sub

    'Public Shared Function GetRelpacedContent(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext) As String
    '    Return GetRelpacedContent(templateContent, entityTemplate, entity, context, Nothing)
    'End Function

    'Public Shared Function GetRelpacedContent(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext, replaceInfo As RegionReplaceInfo) As String

    '    templateContent = ReplaceRegions(templateContent, entityTemplate, entity, context, replaceInfo)

    '    Dim result As New StringBuilder()

    '    Dim startTagIndex As Integer
    '    Dim endTagIndex As Integer
    '    Dim startPos As Integer = 0

    '    Dim finished As Boolean = False

    '    While (Not finished)

    '        startTagIndex = templateContent.IndexOf(context.TagStart, startPos)
    '        endTagIndex = templateContent.IndexOf(context.TagEnd, Math.Max(startPos, startTagIndex))

    '        If startTagIndex < 0 OrElse endTagIndex < 0 Then
    '            result.Append(templateContent.Substring(startPos, templateContent.Length - startPos))
    '            finished = True
    '        Else

    '            result.Append(templateContent.Substring(startPos, startTagIndex - startPos))

    '            Dim value As String = templateContent.Substring(startTagIndex + context.TagStart.Length, endTagIndex - (startTagIndex + context.TagStart.Length))

    '            Dim replaceValue As String = entityTemplate.GetReplaceValue(value.Trim, entity)

    '            If Not IsNothing(replaceValue) Then
    '                startPos = endTagIndex + context.TagEnd.Length

    '                If value.StartsWith(SpaceChar) Then result.Append(SpaceChar)
    '                result.Append(replaceValue)
    '                If value.StartsWith(SpaceChar) Then result.Append(SpaceChar)
    '            Else
    '                result.Append(templateContent.Substring(startTagIndex, 1))
    '                startPos = startTagIndex + 1
    '            End If

    '        End If

    '    End While

    '    Return result.ToString()

    'End Function

    'Public Shared Function ReplaceRegions(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext, replaceInfo As RegionReplaceInfo) As String

    '    Dim regionPattern As New Regex(String.Format("{0}.*{1}.*", context.RegionKeyStart, context.RegionKeyEnd))

    '    Dim result As New StringBuilder()

    '    Dim startTagIndex As Integer
    '    Dim endTagIndex As Integer
    '    Dim startPos As Integer = 0

    '    Dim finished As Boolean = False

    '    While (Not finished)

    '        startTagIndex = templateContent.IndexOf(context.RegionStart, startPos)
    '        endTagIndex = templateContent.IndexOf(context.RegionEnd, Math.Max(startPos, startTagIndex))

    '        If startTagIndex < 0 OrElse endTagIndex < 0 Then
    '            result.Append(templateContent.Substring(startPos, templateContent.Length - startPos))
    '            finished = True
    '        Else

    '            result.Append(templateContent.Substring(startPos, startTagIndex - startPos))

    '            Dim value As String = templateContent.Substring(startTagIndex + context.RegionStart.Length, endTagIndex - (startTagIndex + context.RegionStart.Length))

    '            If regionPattern.IsMatch(value) Then
    '                Dim endKeyIndex As Integer = value.IndexOf(context.RegionKeyEnd)
    '                Dim regionData As String = value.Substring(context.RegionKeyStart.Length, endKeyIndex - context.RegionKeyStart.Length)

    '                Dim regionInfo As New TemplateRegionInfo(regionData)

    '                If Not IsNothing(replaceInfo) Then replaceInfo.FontSize = regionInfo.FontSize

    '                Dim regionVisibleStr As String = Nothing
    '                If regionInfo.Key.EndsWith("?"c) Then
    '                    regionVisibleStr = entityTemplate.GetReplaceValue(regionInfo.Key, entity)
    '                End If

    '                If Not String.IsNullOrEmpty(regionVisibleStr) OrElse entityTemplate.SubEntityKeys.Contains(regionInfo.Key) Then
    '                    startPos = endTagIndex + context.RegionEnd.Length

    '                    Dim regionContent As String = value.Substring(endKeyIndex + context.RegionKeyEnd.Length)

    '                    If Not String.IsNullOrEmpty(regionVisibleStr) Then
    '                        If Boolean.Parse(regionVisibleStr) Then result.Append(GetRelpacedContent(regionContent, entityTemplate, entity, context))
    '                    Else
    '                        Dim subEntities As IEnumerable = CType(entityTemplate.GetSubEntity(regionInfo.Key, entity), IEnumerable)
    '                        result.Append(GetRegionReplaceValue(regionContent, subEntities, context, regionInfo))
    '                    End If
    '                Else
    '                    result.Append(templateContent.Substring(startTagIndex, 1))
    '                    startPos = startTagIndex + 1
    '                End If
    '            Else
    '                result.Append(templateContent.Substring(startTagIndex, 1))
    '                startPos = startTagIndex + 1
    '            End If

    '        End If

    '    End While

    '    Return result.ToString()

    'End Function

    'Public Shared Function GetRegionReplaceValue(regionContent As String, entities As IEnumerable, context As ITemplateContext, regionInfo As TemplateRegionInfo) As String

    '    If IsNothing(entities) Then Return String.Empty

    '    Dim result As New StringBuilder()

    '    Dim entityType As Type = Nothing
    '    Dim subTemplate As ITemplateEntity = Nothing

    '    Dim delimiter As String = regionInfo.Delimiter
    '    'If delimiter = NewLineDelimiter Then delimiter = NewLineMarker

    '    For Each entity As Object In entities

    '        If Not String.IsNullOrEmpty(delimiter) AndAlso result.Length > 0 Then result.Append(delimiter)

    '        If IsNothing(entityType) Then
    '            entityType = entity.GetType()
    '            subTemplate = context.GetTemplate(entityType, context)
    '        End If

    '        result.Append(GetRelpacedContent(regionContent, subTemplate, entity, context))

    '    Next

    '    Return result.ToString()

    'End Function

    'Public Shared Sub ReplaceDocumentValues(tiedostonimi As String, replaceValues As IEnumerable(Of KeyObjectValuePair))

    '    Using doc As DocumentFormat.OpenXml.Packaging.WordprocessingDocument = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(tiedostonimi, True)
    '        Dim content As String
    '        Using reader As New StreamReader(doc.MainDocumentPart.GetStream(), System.Text.Encoding.UTF8)
    '            content = reader.ReadToEnd()
    '            reader.Close()
    '        End Using

    '        For Each k As KeyObjectValuePair In replaceValues

    '            Dim replaceString As String
    '            If IsNothing(k.Value) OrElse IsDBNull(k.Value) Then
    '                replaceString = String.Empty
    '            Else
    '                replaceString = HttpUtility.HtmlEncode(k.Value.ToString())
    '            End If
    '            content = content.Replace(k.Key, replaceString)

    '        Next

    '        Using writer As New StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create), System.Text.Encoding.UTF8)
    '            writer.Write(content)
    '        End Using

    '        doc.MainDocumentPart.Document.Save()

    '    End Using

    'End Sub

#End Region

End Class
