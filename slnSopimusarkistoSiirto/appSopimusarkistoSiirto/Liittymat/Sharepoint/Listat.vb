Imports appSopimusarkistoSiirto.SopimusarkistoLists
Imports System.Reflection

Namespace Liittymat.Sharepoint

  Public Class Listat
    Inherits Pyynto

    Private _client As ListsSoapClient
    Private _testiClient As TestiClient
    Private Const LISTA_KENTTA_ETULIITE As String = "ows_"

    Public Sub New(kayttajatunnus As String, salasana As String, heratysUrl As String)
      MyBase.New(kayttajatunnus, salasana, heratysUrl)

      _client = New ListsSoapClient()
      _testiClient = New TestiClient()

      AsetaKredentiaalit(_client.ClientCredentials)

    End Sub

    Public Function HaeObjektit(Of TObjekti As New, TEhdot)(listaId As String, nakymaId As String, kysely As Kysely(Of TEhdot), nakymaKentat As NakymaKentat, kyselyAsetukset As KyselyAsetukset) As Vastaus(Of TObjekti)

      Dim objVastaus As Vastaus(Of TObjekti)

      Try

        Dim xmlLista As XElement

        If Testi Then
          xmlLista = _testiClient.GetListItems(Of TObjekti)(listaId, nakymaId, kysely.ToXml(), nakymaKentat.ToXml(), Nothing, kyselyAsetukset.ToXml(), Nothing)
        Else
          xmlLista = _client.GetListItems(listaId, nakymaId, kysely.ToXml(), nakymaKentat.ToXml(), Nothing, kyselyAsetukset.ToXml(), Nothing)
        End If

        objVastaus = New Vastaus(Of TObjekti)()

        objVastaus.Objektit = Me.ParsiListaObjekteiksi(Of TObjekti)(xmlLista)
        objVastaus.Ok = True

      Catch ex As Exception

        objVastaus = Me.KasitteleVirhe(Of TObjekti)(ex)

      End Try

      Return objVastaus

    End Function

    Public Function HaeListat() As Vastaus(Of Lista)

      Dim objVastaus As Vastaus(Of Lista)

      Try

        Dim xmlListat As XElement

        xmlListat = _client.GetListCollection()

        Dim lstListat As New List(Of Lista)()

        Dim objLista As Lista

        For Each el As XElement In xmlListat.Elements

          objLista = New Lista()

          objLista.Nimi = el.Attribute("Title").Value
          objLista.Guid = el.Attribute("ID").Value

          lstListat.Add(objLista)

        Next

        objVastaus = New Vastaus(Of Lista)()

        objVastaus.Objektit = lstListat.ToArray()
        objVastaus.Ok = True

      Catch ex As Exception

        objVastaus = Me.KasitteleVirhe(Of Lista)(ex)

      End Try

      Return objVastaus

    End Function

    Public Function HaeListanKentat(listaId As String, Optional nakymaId As String = "") As Vastaus(Of String)

      Dim objVastaus As Vastaus(Of String)

      Try

        Dim xmlLista As XElement

        xmlLista = _client.GetListAndView(listaId, nakymaId)

        Dim xmlNakyma As XElement = xmlLista.Descendants.Where(Function(x) x.Name.LocalName = "View").First

        Dim xmlNakymanKentat As XElement = xmlNakyma.Descendants.Where(Function(x) x.Name.LocalName = "ViewFields").First

        Dim lstKentat As New List(Of String)()

        For Each el As XElement In xmlNakymanKentat.Descendants

          lstKentat.Add(el.Attributes("Name").First.Value)

        Next

        objVastaus = New Vastaus(Of String)()

        objVastaus.Objektit = lstKentat.ToArray()
        objVastaus.Ok = True

      Catch ex As Exception

        objVastaus = Me.KasitteleVirhe(Of String)(ex)

      End Try

      Return objVastaus

    End Function

    Public Function Paivita(Of T)(listaId As String, objekti As T) As Vastaus(Of T)

      Dim objVastaus As Vastaus(Of T)

      Try

        Dim objEra As New Era(Of T)()

        objEra.LisaaPaivitysMetodi(objekti)

        Dim xmlTulos As XElement

        If Me.Testi Then
          xmlTulos = _testiClient.UpdateListItems(listaId, objEra.ToXml())
        Else
          xmlTulos = _client.UpdateListItems(listaId, objEra.ToXml())
        End If

        objVastaus = New Vastaus(Of T)()

        If xmlTulos.Descendants.Where(Function(x) x.Name.LocalName = "ErrorText").Any() Then

          objVastaus.Ok = False
          objVastaus.Virheilmoitus = xmlTulos.Descendants.Where(Function(x) x.Name.LocalName = "ErrorText").First.Value

        Else

          objVastaus.Ok = True
          objVastaus.Objekti = objekti

        End If

      Catch ex As Exception

        objVastaus = Me.KasitteleVirhe(Of T)(ex)

      End Try

      Return objVastaus

    End Function

    Private Function ParsiListaObjekteiksi(Of T As New)(lista As XElement) As T()

      Dim xmlData As XElement = lista.Descendants.First()

      Dim objT As T
      Dim lstT As New List(Of T)()
      Dim pInfo As PropertyInfo
      Dim pType As Type

      For Each el As XElement In xmlData.Elements

        objT = New T()

        For Each pInfo In GetType(T).GetProperties()

          pType = pInfo.PropertyType

          If pType.IsGenericType AndAlso pType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then

            pType = Nullable.GetUnderlyingType(pType)

          End If

          Dim strAttribuutti As String

          If Not el.Attributes(LISTA_KENTTA_ETULIITE & pInfo.Name) Is Nothing AndAlso el.Attributes(LISTA_KENTTA_ETULIITE & pInfo.Name).Count > 0 Then

            strAttribuutti = el.Attributes(LISTA_KENTTA_ETULIITE & pInfo.Name).First.Value

            If pType = GetType(Int32) Then

              strAttribuutti = CDec(strAttribuutti.Replace(".", ",")).ToString("F0")

            End If

            pInfo.SetValue(objT, Convert.ChangeType(strAttribuutti, pType))
          End If

        Next

        lstT.Add(objT)

      Next

      Return lstT.ToArray()

    End Function

  End Class

End Namespace
