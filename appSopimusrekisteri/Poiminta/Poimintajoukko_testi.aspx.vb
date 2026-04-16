Imports KT.Utils
Imports KT.Utils.Mapping
Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.DAL_CF.EntityHandlers

Public Class Poimintajoukko_testi
  Inherits BasePage(Of Sopimusrekisteri.BLL_CF.Poiminta)

  Private Const MAX_TULOKSIA As Integer = 100

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    If Not Me.IsPostBack Then

      Me.AlustaSivu()
      Me.SetPoiminta()

    End If

  End Sub

  Private Sub AlustaSivu()

    gvPoimitut.PageSize = MAX_TULOKSIA

    Me.DataContext.SessioId = Me.Session.SessionID

  End Sub

  Private Sub SetPoiminta()

    Dim poimitut As IEnumerable(Of IPoimittava) = Me.PoimintaHandler.HaeAktiivinenPoimintajoukko()

    '  this.PoimintaTyokalut1.AsetaPoimintatoimintojenNakyvyys(SessionManager.Poimintaehdot.Any(), onkoPoimittuja);

    Dim onkoPoimittuja As Boolean = poimitut.Count() > 0

    '  this.phPoimintapainikkeet.Visible = onkoPoimittuja;
    '  this.phPoimintalinkit.Visible = onkoPoimittuja;

    '  this.gvPoimitut.Visible = onkoPoimittuja;
    '  this.lvPoiminta.Visible = onkoPoimittuja;

    If Not onkoPoimittuja Then

      lblInfo.Text = "Ei poimittuja."

    Else

      If Me.SarakevalintaKaytossa Then

        '      //täytetään dynaaminen grid
        '      FillGridSarakkeet(tahot);

      Else

        Me.FillGridNormaali(poimitut)

      End If


      '    this.TeeExcel(tahot);

      If poimitut.Count() > MAX_TULOKSIA Then

        lblPageCount.Text = "(" & Math.Ceiling(poimitut.Count() / MAX_TULOKSIA) & " sivua)"
        lblPageCount.Visible = True

      End If

      lblInfo.Text = "Poimittuja " & poimitut.Count() & " kpl."

      '    this.ListaaPoimintaehdot();

    End If

  End Sub

  Private Sub FillGridNormaali(poimitut As IEnumerable(Of IPoimittava))

    If Not TryCast(poimitut.First(), Sopimusrekisteri.BLL_CF.Sopimus) Is Nothing Then
      Me.LuoDynaamisetSarakkeet(Me.HaeSopimuksenOletusSarakkeet())
    End If

    gvPoimitut.DataSource = poimitut.OrderBy(Function(x) x.Id).ToList()
    gvPoimitut.DataBind()
    gvPoimitut.Visible = True

  End Sub

  Private Sub LuoDynaamisetSarakkeet(sarakkeet As IEnumerable(Of ColumnBinding))

    gvPoimitut.Columns.Clear()

    Dim bf As BoundField = Nothing
    Dim hf As New HyperLinkField()

    hf.HeaderText = sarakkeet.First().HeaderText

    gvPoimitut.Columns.Add(hf)

    For Each sarake As ColumnBinding In sarakkeet.Skip(1)

      bf = New BoundField()

      bf.HeaderText = sarake.HeaderText
      bf.DataField = sarake.DataField

      gvPoimitut.Columns.Add(bf)

    Next


  End Sub

  Private ReadOnly Property PoimintaHandler As PoimintaHandler
    Get
      Return CType(Me.EntityHandler, PoimintaHandler)
    End Get
  End Property

  Private Function HaeSopimuksenOletusSarakkeet() As IEnumerable(Of ColumnBinding)

    Return New ColumnBinding() _
      { _
        ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimusnumero", Function(x) x.Id, GetType(Integer)), _
        ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimustyyppi", Function(x) x.Sopimustyyppi.SopimustyyppiNimi, GetType(String)), _
        ColumnBindingMapper.GetColumnBinding(Of Sopimusrekisteri.BLL_CF.Sopimus)("Sopimusvuosi", Function(x) x.Sopimusvuosi, GetType(Integer)) _
      }

  End Function

  Private ReadOnly Property SarakevalintaKaytossa As Boolean
    Get
      Return Sessio.Poimintasarakkeet.Count() > 0
    End Get
  End Property

  Private ReadOnly Property PoimintajoukkoValittu
    Get
      Return DataUtils.ParseBoolean(Me.Request.QueryString("poimintajoukko"), False)
    End Get
  End Property

End Class