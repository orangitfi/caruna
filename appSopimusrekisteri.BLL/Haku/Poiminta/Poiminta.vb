Public Class Poiminta

  Public Function HaePoimintaEhdot(ehtoId) As Entities.TallennettuPoimintaehto

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaEhdot(ehtoId)

  End Function

  Public Function HaePoimintaEhtojoukot() As IEnumerable(Of Entities.TallennettuPoimintaehto)

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaEhtojoukot()

  End Function

  Public Function HaePoimintajoukot() As IEnumerable(Of Entities.TallennettuPoimintajoukko)

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintajoukot()

  End Function

  Public Sub PoistaPoimintaEhdot(id As Integer)

    Dim tietokanta As New DAL.Poiminta()

    tietokanta.PoistaPoimintaEhdot(id)

  End Sub

  Public Sub PoistaPoimintajoukko(id As Integer)

    Dim tietokanta As New DAL.Poiminta()

    tietokanta.PoistaPoimintaJoukko(id)

  End Sub

  Public Sub TallennaPoimintaEhdot(nimi As String, ehdot As IEnumerable(Of Entities.TallennettuPoimintaehto_Ehto), tyyppi As String, luoja As String)

    Dim tietokanta As New DAL.Poiminta()

    tietokanta.TallennaPoimintaEhdot(nimi, ehdot, tyyppi, luoja)

  End Sub

  Public Sub TallennaPoimintajoukko(nimi As String, luoja As String, sessioId As String)

    Dim tietokanta As New DAL.Poiminta()

    tietokanta.TallennaPoimintaJoukko(nimi, luoja, sessioId)

  End Sub

  Public Sub LisaaTallennettuPoimintaan(sessio As String, poimintajoukkoId As Integer)

    Dim tietokanta As New DAL.Poiminta()

    tietokanta.LisaaTallennettuJoukkoPoimintaan(sessio, poimintajoukkoId)

  End Sub

  Public Function LisaaPoimintaanSopimuksia(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.LisaaPoimintaanSopimuksia(ehdot, sessioId)

  End Function

  Public Function PoistaPoiminnastaSopimuksia(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.PoistaPoiminnastaSopimuksia(ehdot, sessioId)

  End Function

  Public Function LisaaPoimintaanKiinteistoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.LisaaPoimintaanKiinteistoja(ehdot, sessioId)

  End Function

  Public Function PoistaPoiminnastaKiinteistoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.PoistaPoiminnastaKiinteistoja(ehdot, sessioId)

  End Function

  Public Function LisaaPoimintaanTahoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.LisaaPoimintaanTahoja(ehdot, sessioId)

  End Function

  Public Function PoistaPoiminnastaTahoja(ehdot As DTO.Hakuehto(), sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.PoistaPoiminnastaTahoja(ehdot, sessioId)

  End Function

  Public Function TyhjennaPoiminta(sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.TyhjennaPoiminta(sessioId)

  End Function

  Public Function HaePoimintaJoukkoSopimukset(sessioId As String) As DTO.Sopimus()

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaJoukkoSopimukset(sessioId)

  End Function

  Public Function HaePoimintaJoukkoKiinteistot(sessioId As String) As DTO.Kiinteisto()

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaJoukkoKiinteistot(sessioId)

  End Function

  Public Function HaePoimintaJoukkoTahot(sessioId As String) As DTO.Taho()

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaJoukkoTahot(sessioId)

  End Function

  Public Function HaePoimintaLkm(sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaLkm(sessioId)

  End Function

  Public Function HaePoiminnanTyyppi(sessioId As String) As String

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoiminnanTyyppi(sessioId)

  End Function

  Public Function HaePoimintaSopimustenLkm(sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaSopimustenLkm(sessioId)

  End Function

  Public Function HaePoimintaKiinteistojenLkm(sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaKiinteistojenLkm(sessioId)

  End Function
  Public Function HaePoimintaTahojenLkm(sessioId As String) As Integer

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.HaePoimintaTahojenLkm(sessioId)

  End Function

  Public Function TeeAktiviteettiPoiminta(ehdot As DTO.Hakuehto()) As DTO.Aktiviteetti()

    Dim tietokanta As New DAL.Poiminta()

    Return tietokanta.TeeAktiviteettiPoiminta(ehdot)

  End Function

End Class
