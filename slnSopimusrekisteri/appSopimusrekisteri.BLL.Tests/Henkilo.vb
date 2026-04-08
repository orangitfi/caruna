Imports System.Text
Imports System.Transactions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class Henkilotestit

    <TestMethod()> Public Sub HaeHenkilot()

    'Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo()

        Using transaction = New TransactionScope()

            '' Testaa massahaku.
            'Dim data = tietokanta.HaeHenkilot()
            'Assert.IsNull(data, "Henkilöiden massahaku tietokannasta epäonnistui")

            '' Testaa yhden rivin haku.
            'Dim id = data.FirstOrDefault().TAHTahoId
            'Dim rivi = tietokanta.HaeHenkilot(id)
            'Assert.IsNull(rivi, "Yksittäisen henkilön hakeminen tietokannasta epäonnistui.")

        End Using

    End Sub

    <TestMethod()> Public Sub LisaaHenkilo()

    'Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo()

        'Using transaction = New TransactionScope()

        '    ' Luo testidata.
        '    Dim data = New appSopimusrekisteri.Entities.Taho()
        '    ' Tallenna joko satunnaisia arvoja tai aikaleimoja...

        '    ' Testaa lisäys.
        '    Dim lisatty = tietokanta.LisaaHenkilo(data)
        '    Assert.IsNull(lisatty, "Henkilön lisääminen tietokantaan epäonnistui.")

        '    '' Testaa yhden rivin haku.
        '    'Dim id = lisatty.TAHTahoId
        '    'Dim rivi = tietokanta.HaeHenkilot(id)
        '    'Assert.IsNull(rivi, "Lisätyn henkilön hakeminen tietokannasta epäonnistui.")

        'End Using

    End Sub

    <TestMethod()> Public Sub MuokkaaHenkiloa()

    'Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo()

        Using transaction = New TransactionScope()

            '' Hae ensimmäinen rivi muokattavaksi.
            'Dim data = tietokanta.HaeHenkilot()
            'Dim id = data.FirstOrDefault().TAHTahoId
            'Dim rivi = tietokanta.HaeHenkilot(id)
            'Assert.IsNull(rivi, "Muokattavan henkilön haku epäonnistui.")

            '' Luo testidata.
            '' Tallenna joko satunnaisia arvoja tai aikaleimoja...

            '' Testaa muokkaus.
            'Dim muokattu = tietokanta.MuokkaaHenkiloa(rivi)
            'Assert.Equals(rivi.TAHTahoId = muokattu.TAHTahoId, "Muokattu tieto ei tallentunut.")
            '' Lisää assertteja...
            '' Lisää assertteja...
            '' Lisää assertteja...

        End Using

    End Sub

    <TestMethod()> Public Sub PoistaHenkilo()

        'Dim tietokanta = New appSopimusrekisteri.BLL.Henkilo()

        'Using transaction = New TransactionScope()

        '    ' Luo testidata.
        '    Dim data = New appSopimusrekisteri.Entities.Taho()
        '    ' Tallenna joko satunnaisia arvoja tai aikaleimoja...

        '    ' Testaa lisäys.
        '    Dim lisatty = tietokanta.LisaaHenkilo(data)
        '    Assert.IsNull(lisatty, "Henkilön lisääminen tietokantaan epäonnistui.")

        '    ' Poista lisäys.
        '    Dim poistettu = tietokanta.PoistaHenkilo(lisatty.TAHTahoId)
        '    Assert.IsNull(poistettu, "Henkilön poistaminen tietokannasta epäonnistui.")

        '    '' Testaa yhden rivin haku.
        '    'Dim id = poistettu.TAHTahoId
        '    'Dim rivi = tietokanta.HaeHenkilot(id)
        '    'Assert.IsNotNull(rivi, "Lisätyn henkilön poistaminen tietokannasta epäonnistui.")

        'End Using

    End Sub

End Class