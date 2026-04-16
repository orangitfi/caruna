Imports appSopimusrekisteri.Components
Imports KT.Utils
Imports Sopimusrekisteri.BLL_CF
Imports Sopimusrekisteri.BLL_CF.Hakuehdot
Imports KT.Utils.Mapping
Imports System.Data.Entity
Imports System.Data.SqlClient

Public Class SopimusExcelVienti
    Inherits BasePage2

#Region "Sivun alustus"

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Ohjaustiedot) Then
            Response.Redirect("~/Ohjaustiedot/Ohjaustiedot.aspx")
            Return
        End If

        If Not Page.IsPostBack Then
            AlustaSivu()
        End If
    End Sub

    Private Sub AlustaSivu()
        AlustaValikot()
    End Sub

    Private Sub AlustaValikot()
        WebUtils.DataBindList(ddlSopimuksenTila, Handlers.SopimuksenTilat.GetAll().ToList(), AddressOf UiHelper.LuoListItemSopimuksenTila, AddressOf UiHelper.LuoTyhjaListItem)
        WebUtils.DataBindList(ddlSopimustyyppi, Handlers.Sopimustyypit.GetAll().ToList(), AddressOf UiHelper.LuoListItemSopimustyyppi, AddressOf UiHelper.LuoTyhjaListItem)
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnHaeSopimukset, Me)
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnLuoJaLataa, Me)
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnExcel, Me)
    End Sub

#End Region

#Region "Apufunktiot"

    Private Sub DataBindaaSopimukset(sopimukset As IEnumerable(Of Sopimusrekisteri.BLL_CF.Sopimus))
        phTulokset.Visible = True
        If Not sopimukset Is Nothing AndAlso sopimukset.Any() Then
            tblSopimukset.Visible = True
            lblEiTietoja.Visible = False
            lvTiedot.DataSource = sopimukset
            lvTiedot.DataBind()
        Else
            tblSopimukset.Visible = False
            lblEiTietoja.Visible = True
        End If
    End Sub

#End Region

#Region "Sopimusten haku"

    Private Function MuodostaHakuehdot() As SopimusHakuehdot
        Return New SopimusHakuehdot With {
            .SopimustyyppiId = DataUtils.ParseNullableEnum(Of Sopimustyypit)(ddlSopimustyyppi.SelectedValue),
            .SopimusnumeroAlku = DataUtils.ParseIntOrNull(txtSopimusnumeroAlku.Text),
            .SopimusnumeroLoppu = DataUtils.ParseIntOrNull(txtSopimusnumeroLoppu.Text),
            .SopimuksenTilaId = DataUtils.ParseNullableEnum(Of SopimusTilat)(ddlSopimuksenTila.SelectedValue),
            .AlkupvmAlku = diAlkupvmAlku.DateValue,
            .AlkupvmLoppu = diAlkupvmLoppu.DateValue,
            .PaattymispvmAlku = diPaattymispvmAlku.DateValue,
            .PaattymispvmLoppu = diPaattymispvmLoppu.DateValue
        }
    End Function

    Private Sub HaeSopimukset()
        Dim hakuehdot As SopimusHakuehdot = MuodostaHakuehdot()
        Dim sopimukset = Handlers.Sopimukset.HaeSopimukset(hakuehdot).OrderBy(Function(x) x.Id).ToList()
        DataBindaaSopimukset(sopimukset)
    End Sub

#End Region

#Region "Sopimuspohjien luonti"

    Private Sub LuoPohjat()
        Dim maara As Integer = Convert.ToInt32(txtMaara.Text)
        If maara > 0 Then

            ' Luodaan pohjat
            Dim guid As String = System.Guid.NewGuid().ToString()
            Dim dt As DataTable = New DataTable()
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
                con.Open()

                ' Haetaan datatablen schema
                Dim command As SqlCommand = New SqlCommand("SELECT TOP 1 * FROM Sopimus", con)
                Dim reader = command.ExecuteReader(CommandBehavior.SchemaOnly)
                dt.Load(reader)

                ' Luodaan ja insertoidaan sopimukset
                Dim sopimukset = LuoDTSopimukset(maara, dt, guid)
                BulkInsert(con, sopimukset)
            End Using

            ' Näytetään pohjat
            DataBindaaSopimukset(Handlers.Sopimukset.GetAll().Where(Function(x) x.Guid = guid).ToList())
        End If
    End Sub

    Private Function LuoDTSopimukset(maara As Integer, dt As DataTable, strGuid As String)
        Dim tyyppi = CInt(Sopimustyypit.Sopimuspohja)
        Dim tila = CInt(SopimusTilat.Luonnos)

        For i As Integer = 1 To maara
            Dim dr As DataRow = dt.NewRow()
            dr("SOPSopimustyyppiId") = tyyppi
            dr("SOPSopimuksenTilaId") = tila
            dr("SOPLuonnonsuojelualue") = False
            dr("SOPTiedostoHaettu") = False
            dr("SOPMetatiedotPaivitetty") = False
            dr("SOPKorvaukseton") = False
            dr("SOPLuonnos") = True
            dr("SOPFAS") = False
            dr("SOPIFRS") = False
            dr("SOPGuid") = strGuid
            dr("SOPLuotu") = Now
            dr("SOPLuoja") = User.Identity.Name

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub BulkInsert(con As SqlConnection, dt As DataTable)
        Using bulk As SqlBulkCopy = New SqlBulkCopy(con)
            bulk.DestinationTableName = "Sopimus"
            bulk.WriteToServer(dt)
        End Using
    End Sub

    Private Function LuoSopimuspohja(tyyppi As Sopimustyyppi, tila As SopimuksenTila) As Sopimusrekisteri.BLL_CF.Sopimus
        Return New Sopimusrekisteri.BLL_CF.Sopimus With {
            .SopimustyyppiId = tyyppi.Id,
            .Sopimustyyppi = tyyppi,
            .SopimuksenTilaId = tila.Id,
            .SopimuksenTila = tila,
            .Luotu = Now,
            .Luoja = User.Identity.Name,
            .Luonnos = True
        }
    End Function

#End Region

#Region "Excelin muodostus"

    Private Sub MuodostaExcel()
        Dim sopimusIdt As List(Of Integer) = lvTiedot.Items.Select(Function(x) Convert.ToInt32(CType(x.FindControl("hfId"), HiddenField).Value)).ToList()
        If sopimusIdt.Any() Then

            Dim sopimukset As List(Of Sopimusrekisteri.BLL_CF.Sopimus) = HaeSopimuksetExceliin(sopimusIdt)
            Dim polku = "/Dokumentit/Excel/Sopimukset_" & Now.ToString("yyyy-MM-dd_HH-mm-ss") & ".xlsx"

            Dim dtSopimus As DataTable = DataTableMapper.EntitiesToDataTable(sopimukset, SopimusExcelCommon.ColumnMappingSopimus(DataContext), True)
            Dim dtAsiakkaat As DataTable = DataTableMapper.EntitiesToDataTable(sopimukset.SelectMany(Function(x) x.Asiakkaat), SopimusExcelCommon.ColumnMappingAsiakkaat(DataContext), True)
            Dim dtKiinteistot As DataTable = DataTableMapper.EntitiesToDataTable(sopimukset.SelectMany(Function(x) x.SopimusKiinteistot), SopimusExcelCommon.ColumnMappingKiinteistot(DataContext), True)

            Dim lista = New Dictionary(Of String, DataTable)
            lista.Add(SopimusExcelCommon.SheetSopimukset, dtSopimus)
            lista.Add(SopimusExcelCommon.SheetAsiakkaat, dtAsiakkaat)
            lista.Add(SopimusExcelCommon.SheetKiinteistot, dtKiinteistot)

            ExcelBuilder.CreateExcelFromDataTables(lista, Server.MapPath("~") & polku, True, True, True)

            Response.Redirect("~" + polku)
        End If
    End Sub

    Private Function HaeSopimuksetExceliin(sopimusIdt As List(Of Integer)) As List(Of Sopimusrekisteri.BLL_CF.Sopimus)
        Dim jaljella = sopimusIdt
        Dim tulokset = New List(Of Sopimusrekisteri.BLL_CF.Sopimus)

        Do Until jaljella.Count = 0
            Dim ajettavana = jaljella.Take(300)
            tulokset.AddRange(
                DataContext _
                .Sopimukset _
                .Include(Function(x) x.Asiakkaat.Select(Function(y) y.Taho)) _
                .Include(Function(x) x.SopimusKiinteistot.Select(Function(y) y.Kiinteisto)) _
                .Where(Function(x) ajettavana.Contains(x.Id)).ToList()
            )

            If jaljella.Count > 300 Then
                jaljella.RemoveRange(0, 300)
            Else
                jaljella.RemoveRange(0, jaljella.Count)
            End If
        Loop

        Return tulokset.OrderBy(Function(x) x.Id).ToList()
    End Function

#End Region

#Region "Tapahtumakäsittelijät"

    Protected Sub btnHaeSopimukset_Click(sender As Object, e As EventArgs)
        Page.Validate("valmiit")
        If Page.IsValid Then
            HaeSopimukset()
        End If
    End Sub

    Protected Sub btnLuoJaLataa_Click(sender As Object, e As EventArgs)
        Page.Validate("pohja")
        If Page.IsValid Then
            LuoPohjat()
        End If
    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs)
        MuodostaExcel()
    End Sub

#End Region

End Class