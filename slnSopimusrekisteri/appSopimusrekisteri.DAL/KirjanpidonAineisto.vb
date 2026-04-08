Imports appSopimusrekisteri.Entities
Imports System.Configuration
Imports System.Runtime.Serialization

Public Class KirjanpidonAineisto
    Public Function HaeKirjanpidonAineistonPerustiedot(maksuaineistoId As Integer) As Entities.KirjanpidonAineisto

        Using tietokanta As New FortumEntities()

            Return tietokanta.KirjanpidonAineisto.FirstOrDefault(Function(x) x.batch_id = maksuaineistoId)

        End Using
    End Function

    Public Function HaeKirjanpidonAineistonRivit(maksuaineistoId As Integer) As List(Of Entities.KirjanpidonAineisto)

        Using tietokanta As New FortumEntities()

            Return tietokanta.KirjanpidonAineistoRivi.Where(Function(x) x.batch_id = maksuaineistoId)

        End Using
    End Function

    Public Function LuoKirjanpidonAineisto(maksuaineistoId As Integer) As Entities.KirjanpidonAineisto

        Using tietokanta As New FortumEntities()

            Dim kirjanpidonAineisto = New Entities.KirjanpidonAineisto()
            kirjanpidonAineisto.record_type = "001"
            kirjanpidonAineisto.batch_id = maksuaineistoId
            kirjanpidonAineisto.application_id = ConfigurationManager.AppSettings("application_id").ToString()
            kirjanpidonAineisto.org_id = ConfigurationManager.AppSettings("org_id").ToString()
            kirjanpidonAineisto.check_sum = 0
            tietokanta.KirjanpidonAineisto.Add(kirjanpidonAineisto)
            tietokanta.SaveChanges()
            Return kirjanpidonAineisto

        End Using
    End Function

    Public Function LuoKirjanpidonAineistonRivi(maksuaineistoId As Integer, maksut As DTO.Maksuaineisto) As Entities.KirjanpidonAineistoRivi

        Using tietokanta As New FortumEntities()

            Dim kirjanpidonAineistonRivi = New Entities.KirjanpidonAineistoRivi()
            kirjanpidonAineistonRivi.record_type = "002"
            kirjanpidonAineistonRivi.batch_id = maksuaineistoId
            kirjanpidonAineistonRivi.org_id = ConfigurationManager.AppSettings("org_id").ToString()
            kirjanpidonAineistonRivi.source = ConfigurationManager.AppSettings("source").ToString()
            kirjanpidonAineistonRivi.document_number = ""
            kirjanpidonAineistonRivi.document_category = ""
            kirjanpidonAineistonRivi.gl_date = ""
            kirjanpidonAineistonRivi.company = ConfigurationManager.AppSettings("company").ToString()
            kirjanpidonAineistonRivi.response = ""
            kirjanpidonAineistonRivi.account = ""
            kirjanpidonAineistonRivi.project = ""
            kirjanpidonAineistonRivi.invcost = ""
            kirjanpidonAineistonRivi.partner = ""
            kirjanpidonAineistonRivi.product = ""
            kirjanpidonAineistonRivi.customer = ""
            kirjanpidonAineistonRivi.country = ""
            kirjanpidonAineistonRivi.contract = ""
            kirjanpidonAineistonRivi.purpose = ""
            kirjanpidonAineistonRivi.org_id = ""
            kirjanpidonAineistonRivi.as = ""
            kirjanpidonAineistonRivi.taxper = ""
            kirjanpidonAineistonRivi.abc = ""
            kirjanpidonAineistonRivi.local1 = ""
            kirjanpidonAineistonRivi.local2 = ""
            kirjanpidonAineistonRivi.currency_code = ""
            kirjanpidonAineistonRivi.conversion_type = ""
            kirjanpidonAineistonRivi.currency_rate = ""
            kirjanpidonAineistonRivi.conversion_date = DateTime.Today
            kirjanpidonAineistonRivi.debet_sum =
            kirjanpidonAineistonRivi.credit_sum = 0
            kirjanpidonAineistonRivi.stat_amount = 0
            kirjanpidonAineistonRivi.description = Nothing
            kirjanpidonAineistonRivi.gldata_attribute1 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute2 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute3 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute4 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute5 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute6 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute7 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute8 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute9 = Nothing
            kirjanpidonAineistonRivi.gldata_attribute10 = Nothing
            kirjanpidonAineistonRivi.flex_build_flag = Nothing
            kirjanpidonAineistonRivi.tax_code = "NTJ" ' Tax code for journal line (code table). "NTJ"  can be used if no tax code needed. 
            tietokanta.KirjanpidonAineistoRivi.Add(kirjanpidonAineistonRivi)
            tietokanta.SaveChanges()
            Return kirjanpidonAineistonRivi

        End Using
    End Function

End Class
