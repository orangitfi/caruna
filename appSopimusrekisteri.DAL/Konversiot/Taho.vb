Namespace Konversiot

  Public Class Taho

    Public Shared Function MuutaDTOksi(muunnettavat As IEnumerable(Of Entities.Taho), Optional sopimusId As Integer = 0) As List(Of DTO.Taho)

      Dim tulokset = New List(Of DTO.Taho)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaDTOksi(muunnettava, sopimusId))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaDTOksi(muunnettava As Entities.Taho, Optional sopimusId As Integer = 0) As DTO.Taho

      Dim tulos = New DTO.Taho()

      If Not muunnettava.TAHTyyppiId Is Nothing Then
        tulos.TahoTyyppiId = muunnettava.TAHTyyppiId
      End If

      tulos.Id = muunnettava.TAHTahoId
      tulos.Etunimi = muunnettava.TAHEtunimi
      tulos.Sukunimi = muunnettava.TAHSukunimi
      tulos.Ytunnus = muunnettava.TAHYtunnus
      tulos.Osoite = muunnettava.TAHPostitusosoite
      tulos.Postinumero = muunnettava.TAHPostituspostinro
      tulos.Postitoimipaikka = muunnettava.TAHPostituspostitmp
      tulos.Puhelin = muunnettava.TAHPuhelin
      tulos.Email = muunnettava.TAHEmail
      tulos.Tilinumero = muunnettava.TAHTilinumero
      tulos.BicKoodiMuu = muunnettava.TAHBic
      tulos.KirjanpidonYritystunniste = muunnettava.TAHKirjanpidonYritystunniste
      tulos.KirjanpidonProjektitunniste = muunnettava.TAHKirjanpidonProjektitunniste
      tulos.PCSConcession = muunnettava.TAHConcession

      If Not muunnettava.hlp_BicKoodi Is Nothing Then
        tulos.BicKoodi = muunnettava.hlp_BicKoodi.BKKoodi
      End If

      For Each sopimustaho As Entities.Sopimus_Taho In muunnettava.Sopimus_Taho

        If (sopimusId <> 0) Then
          If sopimustaho.SOTSopimusId <> sopimusId Then
            Continue For
          End If
        End If

        tulos.SopimusId = sopimustaho.SOTSopimusId

        If Not sopimustaho.hlp_Asiakastyyppi Is Nothing Then
          tulos.Rooli = sopimustaho.hlp_Asiakastyyppi.ATYAsiakastyyppi
        Else
          tulos.Rooli = "Tuntematon"
        End If

        tulos.SopimustenTunnisteet += sopimustaho.Sopimus.SOPId.ToString() + "<br/> "
        tulos.SopimustenMuutTunnisteet += sopimustaho.Sopimus.SOPMuuTunniste + "<br/> "

      Next

      ' Parsitaan ylimääräiset rivinvaihdot.
      If tulos.SopimustenTunnisteet.EndsWith("<br/> ") Then
        tulos.SopimustenTunnisteet = tulos.SopimustenTunnisteet.Remove(tulos.SopimustenTunnisteet.Length - 6, 6)
      End If

      If tulos.SopimustenMuutTunnisteet.EndsWith("<br/> ") Then
        tulos.SopimustenMuutTunnisteet = tulos.SopimustenMuutTunnisteet.Remove(tulos.SopimustenMuutTunnisteet.Length - 6, 6)
      End If

      Return tulos

    End Function

  End Class

End Namespace
