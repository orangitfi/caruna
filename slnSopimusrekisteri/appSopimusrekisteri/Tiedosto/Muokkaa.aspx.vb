Imports KT.Utils

Namespace NSTiedosto ' NS Etuliite koska muuten tulee conflict Tiedosto tai Tiedostot luokan kanssa...

    Public Class Muokkaa
        Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Tiedosto)


        Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            If Not Roles.IsUserInRole(Konfiguraatio.Roolit.TiedostoMuokkaus) Then

                Response.Redirect("~/")

            End If

            If Not IsPostBack Then

                AlustaSivu()

                If Not IsNewEntity Then

                    TaytaLomake()

                Else

                    AsetaOletustiedot()

                End If

            End If

        End Sub

        Private Sub AlustaSivu()


        End Sub

        Private Sub AsetaOletustiedot()

        End Sub

        Protected ReadOnly Property SopimusId As Integer?
            Get
                Return DataUtils.ParseIntOrNull(Request.Params("sopimusid"))
            End Get
        End Property

        Private Sub TaytaLomake()

            FormMapper.FillForm(formData, Entity)

            txtMFilesLinkki.Text = Entity.MFilesLink

        End Sub

        Private Sub Tallenna()

            If IsNewEntity Then

                Entity.SopimusId = SopimusId

            End If

            FormMapper.FillObject(formData, Entity, String.Empty)

            Handlers.Tiedostot.ParsiMFilesLinkki(txtMFilesLinkki.Text, Entity)

            EntityHandler.SaveEntity(Entity)

        End Sub

        Private Sub PalaaSopimukselle()

            Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", If(Entity.SopimusId, SopimusId).ToString()))

        End Sub

        Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

            If Page.IsValid() Then

                Tallenna()

                PalaaSopimukselle()

            End If

        End Sub

        Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

            PalaaSopimukselle()

        End Sub

        Protected Sub cvMFilesLinkki_ServerValidate(source As Object, args As ServerValidateEventArgs)

            args.IsValid = Handlers.Tiedostot.ParsiMFilesLinkki(txtMFilesLinkki.Text)

        End Sub

    End Class

End Namespace