Imports Sopimusrekisteri.BLL_CF
Imports KT.Utils

Namespace Korvauslaskelma

  Public Class Muokkaa
    Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Korvauslaskelma)

    Private _sopimus As Sopimusrekisteri.BLL_CF.Sopimus

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      ' Irrallisia korvauslaskelmia ei hyväksytä, joten 
      ' sopimuksen tunniste on pakollinen parametri.
      If Not Me.SopimusId.HasValue Then
        btPeruuta_Click(Nothing, Nothing)
      End If

      If Not IsPostBack Then

        AsetaNakyvyydet()

        Infopallurat.AsetaInfopallurat(Me)

        Me.AlustaSivu()

        'Hyväksyttyä ei saa muokata jos ei ole oikeuksia
        If Me.Entity.KorvauslaskelmaStatusId = KorvauslaskelmaStatukset.Maksettu AndAlso Not RooliAvustaja.OikeusMuokataMaksettuaKorvauslaskelmaa(Context.User.Identity.Name) Then
          btPeruuta_Click(Nothing, Nothing)
        End If

        If Not Me.IsNewEntity Then

          Me.TaytaLomake()

        Else

          Me.AsetaOletustiedot()

        End If

        AsetaKentat()

      End If

    End Sub

    Private Sub AsetaOletustiedot()

      Viesti.Text = "Korvaus sopimuksesta " & Me.Sopimus.Sopimustyyppi.SopimustyyppiNimi & " " & Me.Sopimus.Id.ToString()

    End Sub

    Private Sub AsetaKentat()

      Dim korvaustyyppi As Korvaustyypit? = DataUtils.ParseNullableEnum(Of Korvaustyypit)(KorvaustyyppiId.SelectedValue)

      If korvaustyyppi.HasValue AndAlso korvaustyyppi = Korvaustyypit.Kertakorvaus Then
        MaksuKuukausiId.Enabled = False
      Else
        MaksuKuukausiId.Enabled = True
      End If

    End Sub

    Private Sub AsetaNakyvyydet()

      phAlv.Visible = (Me.Sopimus.SopimustyyppiId = Sopimustyypit.Muuntamosopimus Or Me.Sopimus.SopimustyyppiId = Sopimustyypit.Kiinteistomuuntamosopimus)
            phLisaMaksutiedot.Visible = (Me.Sopimus.SopimustyyppiId = Sopimustyypit.Muuntamosopimus Or Me.Sopimus.SopimustyyppiId = Sopimustyypit.Vuokrasopimus Or Me.Sopimus.SopimustyyppiId = Sopimustyypit.SuurjanniteverkkoVuokrasopimus)

            phLaajaNakyma.Visible = Roles.IsUserInRole(Konfiguraatio.Roolit.KorvauslaskelmaLaaja)

    End Sub

    Private Sub AlustaSivu()

      lbSopimus.Text = Me.Sopimus.Id.ToString()

      lbSopimus.PostBackUrl = String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.Sopimus.Id)

      WebUtils.DataBindList(Of KorvauslaskelmaStatus)(KorvauslaskelmaStatusId, Me.Handlers.KorvauslaskelmaStatukset.GetAll(), AddressOf UiHelper.LuoListItemKorvauslaskemaStatus, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Korvaustyyppi)(KorvaustyyppiId, Me.Handlers.Korvaustyypit.GetAll(), AddressOf UiHelper.LuoListItemKorvaustyyppi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Kuukausi)(MaksuKuukausiId, Me.Handlers.Kuukaudet.GetAll(), AddressOf UiHelper.LuoListItemKuukausi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of MaksunSuoritus)(MaksunSuoritusId, Me.Handlers.MaksunSuoritukset.GetAll(), AddressOf UiHelper.LuoListItemMaksunSuoritus, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Kirjanpidontili)(KirjanpidonTiliId, Me.Handlers.Kirjanpidontilit.GetAll(), AddressOf UiHelper.LuoListItemKirjanpidontili, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of KirjanpidonKustannuspaikka)(KirjanpidonKustannuspaikkaId, Me.Handlers.Kustannuspaikat.GetAll(), AddressOf UiHelper.LuoListItemKustannuspaikka, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of InvCost)(InvCostId, Me.Handlers.InvCostit.GetAll, AddressOf UiHelper.LuoListItemInvCost, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Indeksityyppi)(IndeksityyppiId, Me.Handlers.Indeksityypit.GetAll, AddressOf UiHelper.LuoListItemIndeksityyppi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Kuukausi)(IndeksiKuukausiId, Me.Handlers.Kuukaudet.GetAll, AddressOf UiHelper.LuoListItemKuukausi, AddressOf UiHelper.LuoTyhjaListItem)
      WebUtils.DataBindList(Of Maksuehdot)(MaksuehdotId, Me.Handlers.Maksuehdot.GetAll, AddressOf UiHelper.LuoListItemMaksuehdot, AddressOf UiHelper.LuoTyhjaListItem)

    End Sub

    Private Sub TaytaLomake()

      Me.FormMapper.FillForm(Me.formData, Me.Entity)

      If Me.Entity.ViimeisinIndeksiVuosi.HasValue Then
        lblViimeisinIndeksiVuosi.Text = "Viimeisin indeksivuosi " & Luvut.EsitaNullableInteger(Me.Entity.ViimeisinIndeksiVuosi)
      End If

      If Me.Entity.ViimeisinIndeksi.HasValue Then
        lblViimeisinIndeksi.Text = "Viimeisin indeksi " & Luvut.EsitaNullableInteger(Me.Entity.ViimeisinIndeksi)
      End If

    End Sub

    Private Sub Tallenna()

      Dim ensimmainenSallittuMaksupvm As Date? = Me.Entity.EnsimmainenSallittuMaksuPvm

      Me.FormMapper.FillObject(formData, Me.Entity, String.Empty)

      If ensimmainenSallittuMaksupvm.ToString() <> Me.Entity.EnsimmainenSallittuMaksuPvm.ToString() Then
        Me.Entity.EnsimmainenMaksupaivaAsetettuKasin = True
      End If

      If Me.IsNewEntity Then
        Me.Entity.SopimusId = Me.SopimusId
      End If

      Me.EntityHandler.SaveEntity(Me.Entity)

    End Sub

    Protected Sub btTallenna_Click(sender As Object, e As EventArgs) Handles btTallenna.Click

      If Page.IsValid() Then

        Me.Tallenna()

        Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", Me.Entity.Id.ToString(), Me.SopimusId.ToString()))

      End If

    End Sub

    Protected Sub btPeruuta_Click(sender As Object, e As EventArgs) Handles btPeruuta.Click

      If Me.EntityId.HasValue Then
        Response.Redirect(String.Format("~/Korvauslaskelma/Tiedot.aspx?id={0}&sopimusid={1}", Me.EntityId.ToString(), Me.SopimusId.ToString()), True)
      End If

      Response.Redirect(String.Format("~/Sopimus/Sopimus.ashx?id={0}", Me.SopimusId.ToString()))

    End Sub

    Public ReadOnly Property SopimusId As Integer?
      Get
        If Not String.IsNullOrEmpty(ViewState("sopimusId")) Then
          Return CInt(ViewState("sopimusId"))
        End If

        If IsNumeric(Request.QueryString("sopimusId")) Then
          ViewState("sopimusId") = Request.QueryString("sopimusId")
          Return CInt(ViewState("sopimusId"))
        End If

        Return Nothing
      End Get
    End Property

    Public ReadOnly Property Sopimus As Sopimusrekisteri.BLL_CF.Sopimus
      Get

        If Me._sopimus Is Nothing Then
          If Not Me.Entity.Sopimus Is Nothing Then
            Me._sopimus = Me.Entity.Sopimus
          Else
            Me._sopimus = Me.Handlers.Sopimukset.LoadEntity(Me.SopimusId)
          End If
        End If

        Return Me._sopimus

      End Get
    End Property

    Private Sub KorvaustyyppiId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KorvaustyyppiId.SelectedIndexChanged

      AsetaKentat()

    End Sub

  End Class

End Namespace