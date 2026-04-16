Option Strict On

Imports System.Text
Imports KT.Utils
Imports System.IO
Imports System.Web
Imports System.Text.RegularExpressions

Public Class TemplateHandler

    Private Const SpaceChar As Char = " "c

    Public Shared Function GetRelpacedContent(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext) As String
        Return GetRelpacedContent(templateContent, entityTemplate, entity, context, Nothing)
    End Function

    Public Shared Function GetRelpacedContent(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext, replaceInfo As RegionReplaceInfo) As String

        templateContent = ReplaceRegions(templateContent, entityTemplate, entity, context, replaceInfo)

        Dim result As New StringBuilder()

        Dim startTagIndex As Integer
        Dim endTagIndex As Integer
        Dim startPos As Integer = 0

        Dim finished As Boolean = False

        While (Not finished)

            startTagIndex = templateContent.IndexOf(context.TagStart, startPos)
            endTagIndex = templateContent.IndexOf(context.TagEnd, Math.Max(startPos, startTagIndex))

            If startTagIndex < 0 OrElse endTagIndex < 0 Then
                result.Append(templateContent.Substring(startPos, templateContent.Length - startPos))
                finished = True
            Else

                result.Append(templateContent.Substring(startPos, startTagIndex - startPos))

                Dim value As String = templateContent.Substring(startTagIndex + context.TagStart.Length, endTagIndex - (startTagIndex + context.TagStart.Length))

                Dim replaceValue As String = entityTemplate.GetReplaceValue(value.Trim, entity)

                If Not IsNothing(replaceValue) Then
                    startPos = endTagIndex + context.TagEnd.Length

                    If value.StartsWith(SpaceChar) Then result.Append(SpaceChar)
                    result.Append(replaceValue)
                    If value.StartsWith(SpaceChar) Then result.Append(SpaceChar)
                Else
                    result.Append(templateContent.Substring(startTagIndex, 1))
                    startPos = startTagIndex + 1
                End If

            End If

        End While

        Return result.ToString()

    End Function

    Public Shared Function ReplaceRegions(templateContent As String, entityTemplate As ITemplateEntity, entity As Object, context As ITemplateContext, replaceInfo As RegionReplaceInfo) As String

        Dim regionPattern As New Regex(String.Format("{0}.*{1}.*", context.RegionKeyStart, context.RegionKeyEnd))

        Dim result As New StringBuilder()

        Dim startTagIndex As Integer
        Dim endTagIndex As Integer
        Dim startPos As Integer = 0

        Dim finished As Boolean = False

        While (Not finished)

            startTagIndex = templateContent.IndexOf(context.RegionStart, startPos)
            endTagIndex = templateContent.IndexOf(context.RegionEnd, Math.Max(startPos, startTagIndex))

            If startTagIndex < 0 OrElse endTagIndex < 0 Then
                result.Append(templateContent.Substring(startPos, templateContent.Length - startPos))
                finished = True
            Else

                result.Append(templateContent.Substring(startPos, startTagIndex - startPos))

                Dim value As String = templateContent.Substring(startTagIndex + context.RegionStart.Length, endTagIndex - (startTagIndex + context.RegionStart.Length))

                If regionPattern.IsMatch(value) Then
                    Dim endKeyIndex As Integer = value.IndexOf(context.RegionKeyEnd)
                    Dim regionData As String = value.Substring(context.RegionKeyStart.Length, endKeyIndex - context.RegionKeyStart.Length)

                    Dim regionInfo As New TemplateRegionInfo(regionData)

                    If Not IsNothing(replaceInfo) Then replaceInfo.FontSize = regionInfo.FontSize

                    Dim regionVisibleStr As String = Nothing
                    If regionInfo.Key.EndsWith("?"c) Then
                        regionVisibleStr = entityTemplate.GetReplaceValue(regionInfo.Key, entity)
                    End If

                    If Not String.IsNullOrEmpty(regionVisibleStr) OrElse entityTemplate.SubEntityKeys.Contains(regionInfo.Key) Then
                        startPos = endTagIndex + context.RegionEnd.Length

                        Dim regionContent As String = value.Substring(endKeyIndex + context.RegionKeyEnd.Length)

                        If Not String.IsNullOrEmpty(regionVisibleStr) Then
                            If Boolean.Parse(regionVisibleStr) Then result.Append(GetRelpacedContent(regionContent, entityTemplate, entity, context))
                        Else
                            Dim subEntities As IEnumerable = CType(entityTemplate.GetSubEntity(regionInfo.Key, entity), IEnumerable)
                            result.Append(GetRegionReplaceValue(regionContent, subEntities, context, regionInfo))
                        End If
                    Else
                        result.Append(templateContent.Substring(startTagIndex, 1))
                        startPos = startTagIndex + 1
                    End If
                Else
                    result.Append(templateContent.Substring(startTagIndex, 1))
                    startPos = startTagIndex + 1
                End If

            End If

        End While

        Return result.ToString()

    End Function

    Public Shared Function GetRegionReplaceValue(regionContent As String, entities As IEnumerable, context As ITemplateContext, regionInfo As TemplateRegionInfo) As String

        If IsNothing(entities) Then Return String.Empty

        Dim result As New StringBuilder()

        Dim entityType As Type = Nothing
        Dim subTemplate As ITemplateEntity = Nothing

        Dim delimiter As String = regionInfo.Delimiter

        For Each entity As Object In entities

            If Not String.IsNullOrEmpty(delimiter) AndAlso result.Length > 0 Then result.Append(delimiter)

            If IsNothing(entityType) Then
                entityType = entity.GetType()
                subTemplate = context.GetTemplate(entityType, context)
            End If

            result.Append(GetRelpacedContent(regionContent, subTemplate, entity, context))

        Next

        Return result.ToString()

    End Function

    Public Shared Sub ReplaceDocumentValues(tiedostonimi As String, replaceValues As IEnumerable(Of KeyObjectValuePair))

        Using doc As DocumentFormat.OpenXml.Packaging.WordprocessingDocument = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(tiedostonimi, True)
            Dim content As String
            Using reader As New StreamReader(doc.MainDocumentPart.GetStream(), System.Text.Encoding.UTF8)
                content = reader.ReadToEnd()
                reader.Close()
            End Using

            For Each k As KeyObjectValuePair In replaceValues

                Dim replaceString As String
                If IsNothing(k.Value) OrElse IsDBNull(k.Value) Then
                    replaceString = String.Empty
                Else
                    replaceString = System.Web.HttpUtility.HtmlEncode(k.Value.ToString())
                End If
                content = content.Replace(k.Key, replaceString)

            Next

            Using writer As New StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create), System.Text.Encoding.UTF8)
                writer.Write(content)
            End Using

            doc.MainDocumentPart.Document.Save()

        End Using

    End Sub

End Class
