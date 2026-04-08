Imports System.IO
Imports System
Imports Sopimusrekisteri.BLL_CF
Imports System.Data.SqlClient
Imports System.Transactions
Imports Sopimusrekisteri.BLL_CF.[Class]

Public Class SopimusExcelTuonti
    Inherits BasePage2

#Region "Propertyt"

    Private ReadOnly Property AllowedEndings As String() = New String() {
        ".xlsx"
    }

    Private ReadOnly Property Paivittaja As String = "Excel-tuonti (" & User.Identity.Name & ")"

#End Region

#Region "Sivun alustus"

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(Konfiguraatio.Roolit.Ohjaustiedot) Then
            Response.Redirect("~/Ohjaustiedot/Ohjaustiedot.aspx")
            Return
        End If
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnEsikatsele, Me)
        JavascriptAvustaja.LisaaTuplaklikinEsto(btnTuo, Me)
        If Not Page.IsPostBack() Then
            AlustaSivu()
        End If
    End Sub

    Private Sub AlustaSivu()
        Dim guid = Request.QueryString("guid")
        If Not String.IsNullOrEmpty(guid) Then
            NaytaTiedot(guid)
        End If
    End Sub


#End Region

#Region "Tuonti"

    Private Function InsertTiedot() As String
        Dim path = Server.MapPath("~") & TallennaTiedosto()
        Dim ds As DataSet = ExcelReader.ExcelToDataset(path, 1)
        Dim guid = System.Guid.NewGuid().ToString()
        Dim dtSopimukset = LuoDTSopimukset(ds.Tables(SopimusExcelCommon.SheetSopimukset), guid)
        Dim dtAsiakkaat = LuoDTAsiakkaat(ds.Tables(SopimusExcelCommon.SheetAsiakkaat), guid)
        Dim dtKiinteistot = LuoDTKiinteistot(ds.Tables(SopimusExcelCommon.SheetKiinteistot), guid)

        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 10, 0))
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
                con.Open()
                BulkInsert(con, dtSopimukset)
                BulkInsert(con, dtAsiakkaat)
                BulkInsert(con, dtKiinteistot)
                scope.Complete()
            End Using
        End Using
        Return guid
    End Function

    Private Sub PaivitaTiedot()
        If String.IsNullOrEmpty(Request.QueryString("guid")) Then
            Throw New Exception("Guidia ei annettu.")
        End If

        Using scope As TransactionScope = New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 10, 0))
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
                con.Open()
                Dim guid = Request.QueryString("guid")
                TuoSopimustenTiedot(con, guid)
                TuoAsiakkaidenTiedot(con, guid)
                TuoKiinteistojenTiedot(con, guid)
                scope.Complete()
            End Using
        End Using

        lblOnnistunut.Visible = True
        phTulokset.Visible = False
        lblTuntematonVirhe.Visible = False
    End Sub

#Region "Tietojen esitys"

    Private Sub NaytaTiedot(strGuid As String)
        phTulokset.Visible = True

        Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
            con.Open()
            NaytaTuotavatSopimukset(con, strGuid)
            NaytaTuotavatAsiakkaat(con, strGuid)
            NaytaTuotavatKiinteistot(con, strGuid)
            NaytaVirheellisetSopimukset(con, strGuid)
            NaytaVirheellisetKiinteistot(con, strGuid)
            NaytaVirheellisetAsiakkaat(con, strGuid)
        End Using
    End Sub

    Private Sub NaytaTuotavatAsiakkaat(con As SqlConnection, strGuid As String)
        Dim strSQL = "SELECT " &
            "SUM(CASE WHEN TAHTahoId IS NULL THEN 1 ELSE 0 END) AS Lisattavat, " &
            "SUM(CASE WHEN TAHTahoId IS NOT NULL THEN 1 ELSE 0 END) AS Paivitettavat " &
            "FROM ExcelTuonti_Asiakkaat  " &
            "LEFT JOIN Taho ON TAHTahoId = ETATahoId " &
            "WHERE ETAKasitelty = 0 AND ETAGuid = @guid "
        Dim command = New SqlCommand(strSQL, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        Dim ds = New DataSet()
        Using da As SqlDataAdapter = New SqlDataAdapter(command)
            da.Fill(ds)
        End Using
        Dim lisattavat = ds.Tables(0).Rows(0)("Lisattavat")
        Dim paivitettavat = ds.Tables(0).Rows(0)("Paivitettavat")
        lblUusiaTahoja.Text = If(Not IsDBNull(lisattavat) AndAlso Not lisattavat Is Nothing, lisattavat.ToString(), "0")
        lblPaivitettaviaTahoja.Text = If(Not IsDBNull(paivitettavat) AndAlso Not paivitettavat Is Nothing, paivitettavat.ToString(), "0")
    End Sub

    Private Sub NaytaTuotavatKiinteistot(con As SqlConnection, strGuid As String)
        Dim strSQL = "SELECT " &
            "SUM(CASE WHEN KIIId IS NULL THEN 1 ELSE 0 END) AS Lisattavat, " &
            "SUM(CASE WHEN KIIId IS NOT NULL THEN 1 ELSE 0 END) AS Paivitettavat " &
            "FROM ExcelTuonti_Kiinteistot  " &
            "LEFT JOIN Kiinteisto ON KIIId = ETKKiinteistoId " &
            "WHERE ETKKasitelty = 0 AND ETKGuid = @guid "
        Dim command = New SqlCommand(strSQL, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        Dim ds = New DataSet()
        Using da As SqlDataAdapter = New SqlDataAdapter(command)
            da.Fill(ds)
        End Using
        Dim lisattavat = ds.Tables(0).Rows(0)("Lisattavat")
        Dim paivitettavat = ds.Tables(0).Rows(0)("Paivitettavat")
        lblUusiaKiinteistoja.Text = If(Not IsDBNull(lisattavat) AndAlso Not lisattavat Is Nothing, lisattavat.ToString(), "0")
        lblPaivitettaviaKiinteistoja.Text = If(Not IsDBNull(paivitettavat) AndAlso Not paivitettavat Is Nothing, paivitettavat.ToString(), "0")
    End Sub

    Private Sub NaytaTuotavatSopimukset(con As SqlConnection, strGuid As String)
        Dim strSQL = "SELECT COUNT(ETSSopimusnumero) AS Tuotavia " &
            "FROM ExcelTuonti_Sopimukset " &
            "INNER JOIN Sopimus ON SOPId = ETSSopimusnumero " &
            "INNER JOIN hlps_Sopimustyyppi ON STYSopimustyyppi = ETSSopimustyyppi " &
            "WHERE ETSKasitelty = 0 AND ETSGuid = @guid "
        Dim command = New SqlCommand(strSQL, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        Dim sopimuksia = command.ExecuteScalar()
        lblSopimuksia.Text = If(Not IsDBNull(sopimuksia) AndAlso Not sopimuksia Is Nothing, sopimuksia.ToString(), "0")
    End Sub

    Private Sub NaytaVirheellisetSopimukset(con As SqlConnection, strGuid As String)
        ' Virheellinen sopimustyyppi
        Dim strSQL = "SELECT CAST(ETSSopimusnumero AS varchar) + ' -> ' + ETSSopimustyyppi AS Virheellinen " &
            "FROM ExcelTuonti_Sopimukset " &
            "LEFT JOIN hlps_Sopimustyyppi ON STYSopimustyyppi = ETSSopimustyyppi " &
            "WHERE ETSKasitelty = 0 AND ETSGuid = @guid " &
            "AND STYSopimustyyppi IS NULL " 'Sopimustyyppi on aina pakollinen, joten ei tarkisteta ETSSopimustyyppi NOT NULL 
        lblVirheellinenSopimustyyppi.Text = ParsiVirheelliset(con, strSQL, strGuid)

        ' Virheellinen juridinen yhtiö
        strSQL = "SELECT CAST(ETSSopimusnumero AS varchar) + ' -> ' + ETSJuridinenYhtio AS Virheellinen " &
            "FROM ExcelTuonti_Sopimukset " &
            "LEFT JOIN Taho ON TAHSukunimi = ETSJuridinenYhtio " &
            "WHERE ETSKasitelty = 0 AND ETSGuid = @guid " &
            "AND TAHTahoId IS NULL AND ETSJuridinenYhtio IS NOT NULL "
        lblVirheellinenJuridinenYhtio.Text = ParsiVirheelliset(con, strSQL, strGuid)

        ' Virheellinen kieli
        strSQL = "SELECT CAST(ETSSopimusnumero AS varchar) + ' -> ' + ETSKieli AS Virheellinen " &
            "FROM ExcelTuonti_Sopimukset " &
            "LEFT JOIN hlp_Kieli ON KIEKieli = ETSKieli " &
            "WHERE ETSKasitelty = 0 AND ETSGuid = @guid " &
            "AND KIEId IS NULL AND ETSKieli IS NOT NULL "
        lblVirheellinenKieli.Text = ParsiVirheelliset(con, strSQL, strGuid)

        ' Virheellinen tila
        strSQL = "SELECT CAST(ETSSopimusnumero AS varchar) + ' -> ' + ETSTila AS Virheellinen " &
            "FROM ExcelTuonti_Sopimukset " &
            "LEFT JOIN hlps_SopimuksenTila ON STISopimuksenTila = ETSTila " &
            "WHERE ETSKasitelty = 0 AND ETSGuid = @guid " &
            "AND STIId IS NULL AND ETSTila IS NOT NULL "
        lblVirheellinenTila.Text = ParsiVirheelliset(con, strSQL, strGuid)
    End Sub

    Private Sub NaytaVirheellisetKiinteistot(con As SqlConnection, strGuid As String)
        Dim strSQL = "SELECT CAST(ETKSopimusnumero AS varchar) + ' -> ' + ETKKunta AS Virheellinen " &
            "FROM ExcelTuonti_Kiinteistot " &
            "LEFT JOIN hlp_Kunta ON ETKKunta = KKunta " &
            "WHERE ETKKasitelty = 0 AND ETKGuid = @guid " &
            "AND KKuntaid IS NULL AND ETKKunta IS NOT NULL "
        lblVirheellinenKunta.Text = ParsiVirheelliset(con, strSQL, strGuid)
    End Sub

    Private Sub NaytaVirheellisetAsiakkaat(con As SqlConnection, strGuid As String)
        ' Virheellinen asiakastyyppi
        Dim strSQL = "SELECT CAST(ETASopimusnumero AS varchar) + ' -> ' + ETAAsiakastyyppi AS Virheellinen " &
            "FROM ExcelTuonti_Asiakkaat " &
            "LEFT JOIN hlp_Asiakastyyppi ON ATYAsiakastyyppi = ETAAsiakastyyppi " &
            "WHERE ETAKasitelty = 0 AND ETAGuid = @guid " &
            "AND ATYId IS NULL AND ETAAsiakastyyppi IS NOT NULL "
        lblVirheellinenAsiakastyyppi.Text = ParsiVirheelliset(con, strSQL, strGuid)

        ' Virheellinen tahon tyyppi tai se puuttuu
        strSQL = "SELECT CAST(ETASopimusnumero AS varchar) + ' -> ' + ETATahoTyyppi AS Virheellinen " &
            "FROM ExcelTuonti_Asiakkaat " &
            "LEFT JOIN hlps_TahoTyyppi ON ETATahoTyyppi = TATTahoTyyppi " &
            "WHERE ETAKasitelty = 0 AND ETAGuid = @guid " &
            "AND TATId IS NULL "
        lblVirheellinenTahoTyyppi.Text = ParsiVirheelliset(con, strSQL, strGuid)

        ' Virheellinen rooli
        strSQL = "SELECT CAST(ETASopimusnumero AS varchar) + ' -> ' + ETARooli AS Virheellinen " &
            "FROM ExcelTuonti_Asiakkaat " &
            "LEFT JOIN hlp_DFRooli ON ETARooli = DFRRooli " &
            "WHERE ETAKasitelty = 0 AND ETAGuid = @guid " &
            "AND DFRId IS NULL AND ETARooli IS NOT NULL "
        lblVirheellinenRooli.Text = ParsiVirheelliset(con, strSQL, strGuid)
    End Sub

    Private Function ParsiVirheelliset(con As SqlConnection, strSQL As String, strGuid As String) As String
        Dim command = New SqlCommand(strSQL, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        Dim ds = New DataSet()
        Using da As SqlDataAdapter = New SqlDataAdapter(command)
            da.Fill(ds)
        End Using
        Dim virheelliset = ds.Tables(0).Rows.Cast(Of DataRow).Select(Function(x) x.Field(Of String)("Virheellinen")).ToList()
        Return String.Join("<br/>", virheelliset)
    End Function

#End Region

    Private Sub TuoSopimustenTiedot(con As SqlConnection, strGuid As String)
        ' Päivitys scripti sopimuksia varten
        Dim updateSopimukset = "UPDATE Sopimus SET  " &
                    "SOPSopimustyyppiId = STYId, " &
                    "SOPSopimuksenLaatija = ETSSopimuksenLaatija, " &
                    "SOPJuridinenYhtioId = (SELECT TOP 1 TAHTahoId FROM Taho WHERE TAHOrganisaationTyyppiId = " & CInt(Organisaatiotyypit.JuridinenYhtio) & " AND TAHSukunimi = ETSJuridinenYhtio), " &
                    "SOPProjektinvalvoja = ETSProjektivalvoja, " &
                    "SOPPCSNumero = ETSProjektinumero, " &
                    "SOPAsiakkaanAllekirjoitusPvm = CAST(ETSAsiakkaanAllekirjoituspvm AS date), " &
                    "SOPVerkonhaltijanAllekirjoitusPvm = CAST(ETSVerkonhaltijanAllekirjoituspvm AS date), " &
                    "SOPAlkaa = CAST(ETSAlkaa AS date), " &
                    "SOPKieliId = ISNULL(KIEId, CASE WHEN ETSKieli IS NOT NULL THEN SOPKieliId ELSE NULL END), " &
                    "SOPLuonnos = CASE WHEN ETSLuonnos = '" & SopimusExcelCommon.StringTrue & "' THEN 1 ELSE 0 END, " &
                    "SOPSopimuksenTilaId = ISNULL(STIId, CASE WHEN ETSTila IS NOT NULL THEN SOPSopimuksenTilaId ELSE NULL END), " &
                    "SOPPylvasvali = ETSPylvasvali, " &
                    "SOPMuuTunniste = ETSMuuTunniste, " &
                    "SOPInfo = ISNULL(SOPInfo + ' ', '') + ISNULL(ETSInfo, ''), " &
                    "SOPPaivittaja = @paivittaja, " &
                    "SOPPaivitetty = GETDATE() " &
                    "FROM Sopimus " &
                    "INNER JOIN ExcelTuonti_Sopimukset ON SOPId = ETSSopimusnumero " &
                    "INNER JOIN hlps_Sopimustyyppi ON ETSSopimustyyppi = STYSopimustyyppi " &
                    "LEFT JOIN hlp_Kieli ON ETSKieli = KIEKieli " &
                    "LEFT JOIN hlps_SopimuksenTila ON ETSTila = STISopimuksenTila " &
                    "WHERE ETSKasitelty = 0 AND ETSGuid = @guid "

        ' Päivitys scripti excel tuonnin käsittelytilaa varten
        Dim updateKasittelyTila = "UPDATE ExcelTuonti_Sopimukset SET ETSKasitelty = 1 WHERE ETSKasitelty = 0 AND ETSGuid = @guid "

        ' Ajetaan kaikki kyselyt
        Dim command As SqlCommand = New SqlCommand(updateSopimukset, con)
        command.Parameters.Add(New SqlParameter("@paivittaja", "Excel-tuonti (" & User.Identity.Name & ")"))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(updateKasittelyTila, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        ' Päivitetään vielä laskennallinen päättymispäivä
        Dim Sql As String = "SELECT * FROM Sopimus INNER JOIN ExcelTuonti_Sopimukset ON SOPId = ETSSopimusnumero WHERE ETSGuid = @guid "
        command = New SqlCommand(Sql, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        Dim ds = New DataSet()
        Using da As SqlDataAdapter = New SqlDataAdapter(command)
            da.Fill(ds)
        End Using

        If ds.Tables.Count > 0 Then
            For Each row As DataRow In ds.Tables(0).Rows

                Dim laskennallinenPaattymispvm As New LaskennallinenPaattymispvm With {
                    .Irtisanomisaika = If(Not IsDBNull(row.Item("SOPSopimuksenIrtisanomisaika")), row.Item("SOPSopimuksenIrtisanomisaika"), Nothing),
                    .Irtisanottu = If(Not IsDBNull(row.Item("SOPIrtisanomispvm")), row.Item("SOPIrtisanomispvm"), Nothing),
                    .Paattyy = If(Not IsDBNull(row.Item("SOPPaattyy")), row.Item("SOPPaattyy"), Nothing),
                    .Jatkoaika = If(Not IsDBNull(row.Item("SOPJatkoaika")), row.Item("SOPJatkoaika"), Nothing),
                    .Alkaa = If(Not IsDBNull(row.Item("SOPAlkaa")), row.Item("SOPAlkaa"), Nothing)
                }

                Dim laskennallinenPaattymispaiva As DateTime = laskennallinenPaattymispvm.Value
                PaivitaLaskennallinenPaattymispaiva(con, row.Item("SOPId"), laskennallinenPaattymispaiva)

            Next
        End If

    End Sub

    Private Sub PaivitaLaskennallinenPaattymispaiva(conn As SqlConnection, sopimusId As Integer, pvm As DateTime?)

        Dim Sql As String = "UPDATE Sopimus " &
                            "SET SOPLaskennallinenPaattymispvm = @pvm " &
                            "WHERE SOPId = @sopimusId"

        Dim command As SqlCommand = New SqlCommand(Sql, conn)
        command.Parameters.Add(New SqlParameter("@sopimusId", sopimusId))
        command.Parameters.Add(New SqlParameter("@pvm", pvm))
        command.ExecuteNonQuery()

    End Sub

    Private Sub TuoAsiakkaidenTiedot(con As SqlConnection, strGuid As String)
        ' Päivitys scripti tahojen tietojen päivittämiseen
        Dim updateTahot = "UPDATE Taho SET " &
                        "TAHEtunimi = ETAEtunimi, " &
                        "TAHSukunimi = ETASukunimi, " &
                        "TAHYtunnus = ETAYTunnus, " &
                        "TAHPostitusosoite = ETAPostiosoite, " &
                        "TAHPostituspostinro = ETAPostinumero, " &
                        "TAHPostituspostitmp = ETAPostitoimipaikka, " &
                        "TAHPaivittaja = @paivittaja, " &
                        "TAHPaivitetty = GETDATE() " &
                        "FROM Taho  " &
                        "INNER JOIN ExcelTuonti_Asiakkaat ON ETATahoId = TAHTahoId " &
                        "WHERE ETAKasitelty = 0 AND ETAGuid = @guid "

        ' Päivitys scripti sopimusten tahojen rooleille jne.
        Dim updateSopimusTaho = "UPDATE Sopimus_Taho SET " &
                        "SOTDFRooliId = ISNULL(DFRId, CASE WHEN ETARooli IS NOT NULL THEN SOTDFRooliId ELSE NULL END), " &
                        "SOTAsiakastyyppiId = ISNULL(ATYId, CASE WHEN ETAAsiakastyyppi IS NOT NULL THEN SOTAsiakastyyppiId ELSE NULL END), " &
                        "SOTPaivittaja = @paivittaja, " &
                        "SOTPaivitetty = GETDATE() " &
                        "FROM Sopimus_Taho " &
                        "INNER JOIN ExcelTuonti_Asiakkaat ON ETASopimusTahoId = SOTId " &
                        "LEFT JOIN hlp_DFRooli ON ETARooli = DFRRooli " &
                        "LEFT JOIN hlp_Asiakastyyppi ON ETAAsiakastyyppi = ATYAsiakastyyppi " &
                        "WHERE ETAKasitelty = 0 AND ETAGuid = @guid "

        ' Luonti scripti uusia tahoja varten (Ei annettu TahoIdtä)
        Dim insertTahot = "INSERT INTO Taho (TAHExcelTuontiId, TAHEtunimi, TAHSukunimi, TAHTyyppiId, TAHOrganisaationTyyppiId, TAHYtunnus, TAHPostitusosoite, TAHPostituspostinro, TAHPostituspostitmp, TAHAktiivi, TAHLuotu, TAHLuoja) " &
                        "SELECT ETAId, ETAEtunimi, ETASukunimi, TATId, " &
                        "CASE WHEN TATId = " & CInt(TahoTyypit.Organisaatio) & " THEN " & CInt(Organisaatiotyypit.Yritys) & " ELSE NULL END, " &
                        "ETAYTunnus, ETAPostiosoite, ETAPostinumero, ETAPostitoimipaikka, 1, GETDATE(), @luoja " &
                        "FROM ExcelTuonti_Asiakkaat " &
                        "INNER JOIN hlps_TahoTyyppi ON TATTahoTyyppi = ETATahoTyyppi " &
                        "LEFT JOIN Taho ON ETATahoId = TAHTahoId " &
                        "WHERE TAHTahoId IS NULL " &
                        "AND ETAKasitelty = 0 AND ETAGuid = @guid "

        Dim insertSopimusTahot = "INSERT INTO Sopimus_Taho (SOTExcelTuontiId, SOTSopimusId, SOTTahoId, SOTAsiakastyyppiId, SOTLuotu, SOTLuoja, SOTDFRooliId, SOTTulostetaanSopimukseen) " &
                        "SELECT ETAId, ETASopimusnumero, TAHTahoId, ATYId, GETDATE(), @luoja, DFRId, 1 " &
                        "FROM Taho " &
                        "INNER JOIN ExcelTuonti_Asiakkaat ON ETATahoId = TAHTahoId OR ETAId = TAHExcelTuontiId " &
                        "LEFT JOIN hlp_Asiakastyyppi ON ETAAsiakastyyppi = ATYAsiakastyyppi " &
                        "LEFT JOIN hlp_DFRooli ON ETARooli = DFRRooli " &
                        "WHERE ETASopimusTahoId IS NULL " &
                        "AND ETAKasitelty = 0 AND ETAGuid = @guid "

        ' Luonti scripti tahon ja sopimuksen linkitykseen, niistä joista se puuttuu

        ' Päivitys scripti excel tuonnin käsittelytilaa varten
        Dim updateKasittelyTila = "UPDATE ExcelTuonti_Asiakkaat SET ETAKasitelty = 1 WHERE ETAKasitelty = 0 AND ETAGuid = @guid "

        ' Ajetaan kaikki kyselyt
        Dim command As SqlCommand = New SqlCommand(updateTahot, con)
        command.Parameters.Add(New SqlParameter("@paivittaja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(updateSopimusTaho, con)
        command.Parameters.Add(New SqlParameter("@paivittaja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(insertTahot, con)
        command.Parameters.Add(New SqlParameter("@luoja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(insertSopimusTahot, con)
        command.Parameters.Add(New SqlParameter("@luoja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(updateKasittelyTila, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

    End Sub

    Private Sub TuoKiinteistojenTiedot(con As SqlConnection, strGuid As String)
        ' Päivitys scripti kiinteistöjä varten
        Dim updateKiinteisto = "UPDATE Kiinteisto SET  " &
                        "KIIKiinteisto = ETKNimi, " &
                        "KIIKiinteistotunnus = ETKTunnus, " &
                        "KIIKuntaId = KKuntaid, " &
                        "KIIKuntanumero = CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3) AS int) ELSE 0 END, " &
                        "KIIKylanumero = CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3) AS int) ELSE 0 END, " &
                        "KIIKortteli = CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4) AS int) ELSE 0 END, " &
                        "KIITontti = CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4) AS int) ELSE 0 END, " &
                        "KIIKiinteistotunnusLyhyt = CASE " &
                        "    WHEN ISNULL(ETKTunnus, '') = '' THEN NULL " & ' Tunnusta ei annettu, niin ei voida määritellä lyhyttä tunnustakaan
                        "    WHEN CHARINDEX('-', ETKTunnus, 1) > 0 THEN ETKTunnus " & ' Tunnus on jo valmiiksi lyhyessä muodossa
                        "ELSE " & ' Yhdistellään tunnus
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4) AS int) ELSE 0 END), '') " &
                        "END, " &
                        "KIIPaivitetty = GETDATE(), " &
                        "KIIPaivittaja = @paivittaja " &
                        "FROM Kiinteisto " &
                        "INNER JOIN ExcelTuonti_Kiinteistot ON ETKKiinteistoId = KIIId " &
                        "LEFT JOIN hlp_Kunta ON KKunta = ETKKunta " &
                        "WHERE ETKKasitelty = 0 AND ETKGuid = @guid "

        ' Luonti scripti uusia kiinteistöjä varten (kiinteistön Id:tä ei annettu)
        Dim insertKiinteisto = "INSERT INTO Kiinteisto (KIIExcelTuontiId, KIIKiinteisto, KIIKiinteistotunnus, KIIKuntaId, KIIKuntanumero, KIIKylanumero, KIIKortteli, KIITontti, KIIKiinteistotunnusLyhyt, KIILuotu, KIILuoja) " &
                        "SELECT ETKId, ETKNimi, ETKTunnus, KKuntaid, " &
                        "CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3) AS int) ELSE 0 END, " & ' Kuntanumero
                        "CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3) AS int) ELSE 0 END, " & ' Kylänumero
                        "CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4) AS int) ELSE 0 END, " & ' Kortteli
                        "CASE WHEN ISNULL(ETKTunnus, '') = '' THEN NULL WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4) AS int) ELSE 0 END, " & ' Tontti
                        "CASE " & ' Lyhyt tunnus alkaa
                        "    WHEN ISNULL(ETKTunnus, '') = '' THEN NULL " & ' Tunnusta ei annettu, niin ei voida määritellä lyhyttä tunnustakaan
                        "    WHEN CHARINDEX('-', ETKTunnus, 1) > 0 THEN ETKTunnus " & ' Tunnus on jo valmiiksi lyhyessä muodossa
                        "ELSE " & ' Yhdistellään tunnus
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 1, 3) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 4, 3) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 7, 4) AS int) ELSE 0 END), '') + '-' + " &
                        "    ISNULL(CONVERT(VARCHAR(4), CASE WHEN ISNUMERIC(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4)) = 1 THEN CAST(SUBSTRING(REPLACE(ETKTunnus, '-', ''), 11, 4) AS int) ELSE 0 END), '') " &
                        "END, " & ' Lyhyt tunnus loppuu
                        "GETDATE(), @luoja " &
                        "FROM ExcelTuonti_Kiinteistot " &
                        "LEFT JOIN hlp_Kunta ON KKunta = ETKKunta " &
                        "LEFT JOIN Kiinteisto ON KIIId = ETKKiinteistoId " &
                        "WHERE KIIId IS NULL " &
                        "AND ETKKasitelty = 0 AND ETKGuid = @guid  "

        ' Luonti scripti sopimuksen ja kiinteistön välitauluun. Liitetään kiinteistöt sopimuksiin, joista liitos puuttuu
        Dim insertSopimusKiinteisto = "INSERT INTO Sopimus_Kiinteisto (SKExcelTuontiId, SKSopimusId, SKKiinteistoId, SKLuoja, SKLuotu) " &
                        "SELECT ETKId, ETKSopimusnumero, KIIId, @luoja, GETDATE() " &
                        "FROM Kiinteisto " &
                        "INNER JOIN ExcelTuonti_Kiinteistot ON ETKKiinteistoId = KIIId OR ETKId = KIIExcelTuontiId " &
                        "WHERE ETKSopimusKiinteistoId IS NULL " &
                        "AND ETKKasitelty = 0 AND ETKGuid = @guid  "

        ' Päivitys scripti excel tuonnin käsittelytilaa varten
        Dim updateKasittelyTila = "UPDATE ExcelTuonti_Kiinteistot SET ETKKasitelty = 1 WHERE ETKKasitelty = 0 AND ETKGuid = @guid "

        ' Ajetaan kaikki kyselyt
        Dim command As SqlCommand = New SqlCommand(updateKiinteisto, con)
        command.Parameters.Add(New SqlParameter("@paivittaja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(insertKiinteisto, con)
        command.Parameters.Add(New SqlParameter("@luoja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(insertSopimusKiinteisto, con)
        command.Parameters.Add(New SqlParameter("@luoja", Paivittaja))
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

        command = New SqlCommand(updateKasittelyTila, con)
        command.Parameters.Add(New SqlParameter("@guid", strGuid))
        command.ExecuteNonQuery()

    End Sub

#Region "DataTable Luonti"

    Private Function LuoDTSopimukset(dtExcel As DataTable, strGuid As String) As DataTable
        Dim dt As DataTable = New DataTable("ExcelTuonti_Sopimukset")
        dt.Columns.Add(New DataColumn("ETSId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETSSopimusnumero", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETSSopimustyyppi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSSopimuksenLaatija", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSJuridinenYhtio", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSProjektivalvoja", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSProjektinumero", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSAsiakkaanAllekirjoituspvm", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETSVerkonhaltijanAllekirjoituspvm", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETSAlkaa", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETSKieli", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSLuonnos", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSTila", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSPylvasvali", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSKasitelty", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("ETSLuotu", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETSLuoja", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSGuid", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSInfo", GetType(String)))
        dt.Columns.Add(New DataColumn("ETSMuuTunniste", GetType(String)))

        For Each row As DataRow In dtExcel.Rows
            Dim sopimusnumero = NumerinenArvo(row(SopimusExcelCommon.ColSopimusnumero))
            If Not sopimusnumero.HasValue Then Continue For

            Dim asiakasallekirjoituspvm = DateArvo(row(SopimusExcelCommon.ColAsiakkaanAllekirjoituspvm))
            Dim verkonhaltijaallekirjoituspvm = DateArvo(row(SopimusExcelCommon.ColVerkonhaltijanAllekirjoituspvm))
            Dim alkaa = DateArvo(row(SopimusExcelCommon.ColAlkupvm))
            Dim dr As DataRow = dt.NewRow()
            dr("ETSSopimusnumero") = sopimusnumero.Value
            dr("ETSSopimustyyppi") = row(SopimusExcelCommon.ColSopimustyyppi)
            dr("ETSSopimuksenLaatija") = row(SopimusExcelCommon.ColSopimuksenlaatija)
            dr("ETSJuridinenYhtio") = row(SopimusExcelCommon.ColJuridinenYhtio)
            dr("ETSProjektivalvoja") = row(SopimusExcelCommon.ColProjektivalvoja)
            dr("ETSProjektinumero") = row(SopimusExcelCommon.ColProjektinumero)
            dr("ETSAsiakkaanAllekirjoituspvm") = If(asiakasallekirjoituspvm, DBNull.Value)
            dr("ETSVerkonhaltijanAllekirjoituspvm") = If(verkonhaltijaallekirjoituspvm, DBNull.Value)
            dr("ETSAlkaa") = If(alkaa, DBNull.Value)
            dr("ETSKieli") = row(SopimusExcelCommon.ColKieli)
            dr("ETSLuonnos") = row(SopimusExcelCommon.ColLuonnos)
            dr("ETSTila") = row(SopimusExcelCommon.ColTila)
            dr("ETSPylvasvali") = row(SopimusExcelCommon.ColLuovutettujenPylvaidenMaara)
            dr("ETSKasitelty") = False
            dr("ETSLuotu") = Now
            dr("ETSLuoja") = User.Identity.Name
            dr("ETSGuid") = strGuid
            dr("ETSInfo") = row(SopimusExcelCommon.ColLisatietoja)
            dr("ETSMuuTunniste") = row(SopimusExcelCommon.ColMuuTunnus)

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function LuoDTAsiakkaat(dtExcel As DataTable, strGuid As String) As DataTable
        Dim dt As DataTable = New DataTable("ExcelTuonti_Asiakkaat")
        dt.Columns.Add(New DataColumn("ETAId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETASopimusnumero", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETASopimusTahoId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETATahoId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETAAsiakastyyppi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAEtunimi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETASukunimi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETATahoTyyppi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAYTunnus", GetType(String)))
        dt.Columns.Add(New DataColumn("ETARooli", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAPostiosoite", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAPostinumero", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAPostitoimipaikka", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAKasitelty", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("ETALuotu", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETALuoja", GetType(String)))
        dt.Columns.Add(New DataColumn("ETAGuid", GetType(String)))

        For Each row As DataRow In dtExcel.Rows
            Dim sopimusnumero = NumerinenArvo(row(SopimusExcelCommon.ColSopimusnumero))
            If Not sopimusnumero.HasValue Then Continue For

            Dim sopimusTahoId = NumerinenArvo(row(SopimusExcelCommon.ColTunnus))
            Dim tahoId = NumerinenArvo(row(SopimusExcelCommon.ColAsiakasnumero))
            Dim dr As DataRow = dt.NewRow()
            dr("ETASopimusnumero") = sopimusnumero.Value
            dr("ETASopimusTahoId") = If(sopimusTahoId, DBNull.Value)
            dr("ETATahoId") = If(tahoId, DBNull.Value)
            dr("ETAAsiakastyyppi") = row(SopimusExcelCommon.ColAsiakastyyppi)
            dr("ETAEtunimi") = row(SopimusExcelCommon.ColEtunimi)
            dr("ETASukunimi") = row(SopimusExcelCommon.ColSukunimi)
            dr("ETATahoTyyppi") = row(SopimusExcelCommon.ColTahoTyyppi)
            dr("ETAYTunnus") = row(SopimusExcelCommon.ColYTunnus)
            dr("ETARooli") = row(SopimusExcelCommon.ColRooli)
            dr("ETAPostiosoite") = row(SopimusExcelCommon.ColPostiosoite)
            dr("ETAPostinumero") = row(SopimusExcelCommon.ColPostinumero)
            dr("ETAPostitoimipaikka") = row(SopimusExcelCommon.ColPostitoimipaikka)
            dr("ETAKasitelty") = False
            dr("ETALuotu") = Now
            dr("ETALuoja") = User.Identity.Name
            dr("ETAGuid") = strGuid

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Function LuoDTKiinteistot(dtExcel As DataTable, strGuid As String)
        Dim dt As DataTable = New DataTable("ExcelTuonti_Kiinteistot")
        dt.Columns.Add(New DataColumn("ETKId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETKSopimusnumero", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETKSopimusKiinteistoId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETKKiinteistoId", GetType(Integer)))
        dt.Columns.Add(New DataColumn("ETKNimi", GetType(String)))
        dt.Columns.Add(New DataColumn("ETKTunnus", GetType(String)))
        dt.Columns.Add(New DataColumn("ETKKunta", GetType(String)))
        dt.Columns.Add(New DataColumn("ETKKasitelty", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("ETKLuotu", GetType(Date)))
        dt.Columns.Add(New DataColumn("ETKLuoja", GetType(String)))
        dt.Columns.Add(New DataColumn("ETKGuid", GetType(String)))

        For Each row As DataRow In dtExcel.Rows
            Dim sopimusnumero = NumerinenArvo(row(SopimusExcelCommon.ColSopimusnumero))
            If Not sopimusnumero.HasValue Then Continue For

            Dim sopimusKiinteistoId = NumerinenArvo(row(SopimusExcelCommon.ColKiinteistoSopimusTunnus))
            Dim kiinteistoId = NumerinenArvo(row(SopimusExcelCommon.ColKiinteistonumero))
            Dim dr As DataRow = dt.NewRow()
            dr("ETKSopimusnumero") = sopimusnumero.Value
            dr("ETKSopimusKiinteistoId") = If(sopimusKiinteistoId, DBNull.Value)
            dr("ETKKiinteistoId") = If(kiinteistoId, DBNull.Value)
            dr("ETKNimi") = row(SopimusExcelCommon.ColKiinteistonNimi)
            dr("ETKTunnus") = row(SopimusExcelCommon.ColKiinteistotunnus)
            dr("ETKKunta") = row(SopimusExcelCommon.ColKunta)
            dr("ETKKasitelty") = False
            dr("ETKLuotu") = Now
            dr("ETKLuoja") = User.Identity.Name
            dr("ETKGuid") = strGuid

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

#End Region

#End Region

#Region "Apufunktiot"

    Private Function TallennaTiedosto() As String
        Dim path = "/Import/Excel/" + fuTiedosto.FileName
        File.WriteAllBytes(Server.MapPath("~") + path, fuTiedosto.FileBytes)
        Return path
    End Function

    Private Function DateArvo(arvo As Object) As Date?
        ' Tarkistaa onko arvo datetime ja palauttaa parsitun arvon
        If IsDBNull(arvo) OrElse String.IsNullOrWhiteSpace(arvo) Then
            Return Nothing
        End If

        ' Yritetään parsia stringistä
        Dim dtArvo As Date
        If Date.TryParse(arvo, dtArvo) Then
            Return dtArvo
        End If

        ' Joskus datetime tulee numerisena excelistä. Silloin täytyy parsia se numerosta
        Dim aoDouble As Double
        If Double.TryParse(arvo, aoDouble) Then
            Return Date.FromOADate(aoDouble)
        End If

        Return Nothing
    End Function

    Private Function NumerinenArvo(arvo As Object) As Integer?
        ' Tarkistaa onko arvo integer ja palauttaa parsitun arvon
        If IsDBNull(arvo) OrElse String.IsNullOrWhiteSpace(arvo) Then
            Return Nothing
        End If

        Dim intArvo As Integer
        If Integer.TryParse(arvo, intArvo) Then
            Return intArvo
        End If

        Return Nothing
    End Function

    Private Sub BulkInsert(con As SqlConnection, dt As DataTable)
        Using bulk As SqlBulkCopy = New SqlBulkCopy(con)
            bulk.DestinationTableName = dt.TableName
            bulk.WriteToServer(dt)
        End Using
    End Sub

    Private Sub KasitteleException(ex As Exception)
        phTulokset.Visible = False
        lblOnnistunut.Visible = False
        lblTuntematonVirhe.Visible = True
        lblTuntematonVirhe.Text = "Sovelluksessa tapahtui tuntematon virhe. Virheen tiedot: " & ex.Message
    End Sub

    Private Sub KasitteleExceptionViallinen(ex As Exception)
        phTulokset.Visible = False
        lblOnnistunut.Visible = False
        lblTuntematonVirhe.Visible = True
        lblTuntematonVirhe.Text = "Antamasi excelistä voi puuttua tiettyjä metadatoja. Avaa excel tiedosto, tallenna se kerran ja yritä uudelleen. Virheen tarkemmat tiedot: " & ex.Message
    End Sub

#End Region

#Region "Tapahtumakäsittelijät"

    Protected Sub btnEsikatsele_Click(sender As Object, e As EventArgs)
        Try
            Page.Validate()
            If Page.IsValid Then
                Dim guid = InsertTiedot()
                Response.Redirect(Request.Url.GetLeftPart(UriPartial.Path) & "?guid=" & guid)
            End If
        Catch ex As Exception
            KasitteleExceptionViallinen(ex)
        End Try
    End Sub

    Protected Sub cvTiedosto_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Try
            ' Tarkistetaan että tiedosto on excel
            If fuTiedosto.HasFile Then
                Dim ending = Path.GetExtension(fuTiedosto.FileName)
                args.IsValid = AllowedEndings.Contains(ending)
            Else
                args.IsValid = False
            End If

            If Not args.IsValid Then
                cvTiedosto.ErrorMessage = "Tiedoston täytyy olla excel tiedosto (xlsx)."
                Return
            End If

            ' Tarkistetaan onko excelissä kaikki tarvittavat välilehdet (sheetit)
            Dim tiedostoPolku = Server.MapPath("~") & TallennaTiedosto()
            Dim sheets = ExcelReader.GetSheetNames(tiedostoPolku)
            args.IsValid =
                sheets.Contains(SopimusExcelCommon.SheetSopimukset) AndAlso
                sheets.Contains(SopimusExcelCommon.SheetAsiakkaat) AndAlso
                sheets.Contains(SopimusExcelCommon.SheetKiinteistot)
            If Not args.IsValid Then
                Dim errorMessage As String = "Excelistä puuttuu seuraavat välilehdet: "
                Dim puuttuvatSheetit = New List(Of String)
                If Not sheets.Contains(SopimusExcelCommon.SheetSopimukset) Then puuttuvatSheetit.Add(SopimusExcelCommon.SheetSopimukset)
                If Not sheets.Contains(SopimusExcelCommon.SheetAsiakkaat) Then puuttuvatSheetit.Add(SopimusExcelCommon.SheetAsiakkaat)
                If Not sheets.Contains(SopimusExcelCommon.SheetKiinteistot) Then puuttuvatSheetit.Add(SopimusExcelCommon.SheetKiinteistot)
                errorMessage &= String.Join(", ", puuttuvatSheetit)
                cvTiedosto.ErrorMessage = errorMessage
                Return
            End If

            ' Tarkistetaan sarakkeet

            Dim puuttuvatSarakkeet = New List(Of String)
            For Each sheet In sheets
                Dim columns = ExcelReader.GetSheetColumns(tiedostoPolku, sheet, 1)
                If sheet = SopimusExcelCommon.SheetSopimukset Then
                    For Each mapping In SopimusExcelCommon.ColumnMappingSopimus(DataContext)
                        If Not columns.Contains(mapping.ColumnName) Then
                            puuttuvatSarakkeet.Add(sheet & " -> " & mapping.ColumnName)
                        End If
                    Next
                ElseIf sheet = SopimusExcelCommon.SheetAsiakkaat Then
                    For Each mapping In SopimusExcelCommon.ColumnMappingAsiakkaat(DataContext)
                        If Not columns.Contains(mapping.ColumnName) Then
                            puuttuvatSarakkeet.Add(sheet & " -> " & mapping.ColumnName)
                        End If
                    Next
                ElseIf sheet = SopimusExcelCommon.SheetKiinteistot Then
                    For Each mapping In SopimusExcelCommon.ColumnMappingKiinteistot(DataContext)
                        If Not columns.Contains(mapping.ColumnName) Then
                            puuttuvatSarakkeet.Add(sheet & " -> " & mapping.ColumnName)
                        End If
                    Next
                End If
            Next

            If puuttuvatSarakkeet.Any() Then
                args.IsValid = False
                cvTiedosto.ErrorMessage = "Excelistä puuttuu seuraavat sarakkeet:<br/>" & String.Join("<br/>", puuttuvatSarakkeet)
                Return
            End If

        Catch ex As Exception
            cvTiedosto.ErrorMessage = "Sovelluksessa tapahtui virhe. Excel voi olla viallisessa muodossa. Avaa excel tiedosto, tallenna se kerran ja yritä uudelleen. Virheen tiedot: " & ex.Message
            args.IsValid = False
        End Try
    End Sub

    Protected Sub btnTuo_Click(sender As Object, e As EventArgs)
        Try
            PaivitaTiedot()
        Catch ex As Exception
            KasitteleException(ex)
        End Try
    End Sub

#End Region

End Class