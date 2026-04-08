Public Class Tiedosto

    Public Property Id As Integer?
    Public Property Nimi As String
    Public Property Url As String
    Public Property Selite As String
    Public Property LahdeId As Integer?
    Public Property Lahde As String
    Public Property SopimusId As Integer?
    Public Property SharepointId As Integer?
    Public Property ArkistonSijaintiId As Integer?
    Public Property ArkistonSijainti As String
    Public Property DocumentId As String
    Public Property ArkistointiTunniste As String
    Public Property Sivuja As Integer?
    Public Property Info As String
    Public Property Luoja As String
    Public Property Luotu As Date?
    Public Property Paivittaja As String
    Public Property Paivitetty As Date?
    Public Property AsiakirjaTarkenneId As Integer?
    Public Property AsiakirjaTarkenne As String
    Public Property SopimusFormaattiId As Integer?
    Public Property SopimusFormaatti As String
    Public Property MFilesVault As Guid?
    Public Property MFilesType As Integer
    Public Property MFilesId As Integer?
    Public Property MFilesObject As Guid?

    Public ReadOnly Property MFilesLink As String
        Get
            Return GetMFilesLink(Enumeraattorit.MFilesAction.Show)
        End Get
    End Property

    Public ReadOnly Property Sijainti As Enumeraattorit.TiedostonSijainti
        Get
            Return If(Not String.IsNullOrEmpty(MFilesLink), Enumeraattorit.TiedostonSijainti.MFiles, Enumeraattorit.TiedostonSijainti.Sharepoint)
        End Get
    End Property

    Public Function GetMFilesLink(ByVal action As Enumeraattorit.MFilesAction) As String
        If MFilesVault.HasValue AndAlso MFilesId.HasValue Then
            Dim actionStr As String = action.ToString().ToLower()
            Dim link As String = $"m-files://{actionStr}/{MFilesVault.ToString().ToUpper()}/{MFilesType}-{MFilesId}"
            If MFilesObject.HasValue Then link += $"?object={MFilesObject.ToString().ToUpper()}"
            Return link
        End If

        Return String.Empty
    End Function


End Class
