Imports Sopimusrekisteri.BLL_CF

Public Class JASTemplateHelpers

  'Public Shared Function HaeTilojenMaara(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As Integer

  '  If Not sopimus.Maanomistaja Is Nothing Then

  '    If Not sopimus.Maanomistaja.MaanomistajanTilat Is Nothing Then
  '      Return sopimus.Maanomistaja.MaanomistajanTilat.Count
  '    End If

  '  End If

  '  Return 0

  'End Function

  Public Shared Function HaeSivunVaihto(sopimus As Sopimusrekisteri.BLL_CF.Sopimus, tagi As String) As String

    Dim intKiinteistot As Integer = sopimus.Kiinteistot.Count
    Dim intAllekirjoitukset As Integer = HaeAllekirjoitustenMaara(sopimus)

        Dim intYhteisMaara As Integer = intKiinteistot + HaeOmistajienMaara(sopimus) + HaeVuokralaistenMaara(sopimus)

        Dim strSivunVaihto As String = String.Empty

    If tagi.Split(";").Count() > 1 Then
      strSivunVaihto = tagi.Split(";")(1)

      tagi = tagi.Split(";")(0)
    End If

    Dim intVaihto As Integer = CInt(tagi.Split("_")(1))

    Dim strYhteismaarat As String = tagi.Split("_")(2).Replace("{", "").Replace("}", "")

    Dim intMinYhteismaara As Integer = 0
    Dim intMaxYhteismaara As Integer = Integer.MaxValue

    If IsNumeric(strYhteismaarat.Split(",")(0)) Then
      intMinYhteismaara = CInt(strYhteismaarat.Split(",")(0))
    End If

    If IsNumeric(strYhteismaarat.Split(",")(1)) Then
      intMaxYhteismaara = CInt(strYhteismaarat.Split(",")(1))
    End If

    Dim intMinOmistajaMaara As Integer?
    Dim intMaxOmistajaMaara As Integer?

    If tagi.Split("_").Count() = 4 Then

      Dim strOmistajienMaarat As String = tagi.Split("_")(3).Replace("{", "").Replace("}", "")

      If IsNumeric(strOmistajienMaarat.Split(",")(0)) Then
        intMinOmistajaMaara = CInt(strOmistajienMaarat.Split(",")(0))
      End If

      If IsNumeric(strOmistajienMaarat.Split(",")(1)) Then
        intMaxOmistajaMaara = CInt(strOmistajienMaarat.Split(",")(1))
      End If

    End If

    If intYhteisMaara <= intMaxYhteismaara And intYhteisMaara >= intMinYhteismaara And
      (Not intMaxOmistajaMaara.HasValue Or (intMaxOmistajaMaara.HasValue AndAlso intAllekirjoitukset <= intMaxOmistajaMaara)) And
      (Not intMinOmistajaMaara.HasValue Or (intMinOmistajaMaara.HasValue AndAlso intAllekirjoitukset >= intMinOmistajaMaara)) Then

      Select Case intVaihto
        Case 1
          Return "</ul></div><div class=""sivu sivunVaihto""><ul class=""oikeudet"">"
        Case 2
          Return strSivunVaihto
        Case 3
                    Return strSivunVaihto
                Case 4
                    Return strSivunVaihto
                Case Else
                    Return String.Empty
      End Select

    Else
      Return String.Empty
    End If

  End Function

  Public Shared Function HaeOmistajienMaara(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As Integer

    Return sopimus.Asiakkaat.Where(Function(x) x.AsiakastyyppiId = Asiakastyypit.Omistaja).Count()

  End Function

    Public Shared Function HaeAllekirjoitustenMaara(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As Integer

        Return sopimus.Asiakkaat.Where(Function(x) x.TulostetaanSopimukseen).Count()

    End Function

    Public Shared Function HaeVuokralaistenMaara(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As Integer

        Return sopimus.Asiakkaat.Where(Function(x) x.AsiakastyyppiId = Asiakastyypit.Vuokralainen).Count()

    End Function

End Class
