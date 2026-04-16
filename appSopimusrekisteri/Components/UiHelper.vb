Imports Sopimusrekisteri.BLL_CF

Public Class UiHelper

    Public Shared Function LuoListItemAsiakastyyppi(tyyppi As Asiakastyyppi) As ListItem
        Return New ListItem(tyyppi.Nimi, tyyppi.Id.ToString())
    End Function
    Public Shared Function LuoListItemBicKoodi(koodi As BicKoodi) As ListItem
        Return New ListItem(koodi.KokoNimi, koodi.Id.ToString())
    End Function
    Public Shared Function LuoListItemDFRooli(rooli As DFRooli) As ListItem
        Return New ListItem(rooli.Nimi, rooli.Id.ToString())
    End Function

    Public Shared Function LuoListItemIndeksityyppi(tyyppi As Indeksityyppi) As ListItem
        Return New ListItem(tyyppi.Nimi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemInvCost(invCost As InvCost) As ListItem
        Return New ListItem(invCost.Nimi, invCost.Id.ToString())
    End Function

    Public Shared Function LuoListItemJulkisuusaste(julkisuusaste As Julkisuusaste) As ListItem
        Return New ListItem(julkisuusaste.Nimi, julkisuusaste.Id.ToString())
    End Function

    Public Shared Function LuoListItemKieli(kieli As Kieli) As ListItem
        Return New ListItem(kieli.Nimi, kieli.Id.ToString())
    End Function

    Public Shared Function LuoListItemKirjanpidontili(tili As Kirjanpidontili) As ListItem
        Return New ListItem(tili.KokoNimi, tili.Id.ToString())
    End Function

    Public Shared Function LuoListItemKohdekategoria(kategoria As Kohdekategoria) As ListItem
        Return New ListItem(kategoria.Nimi, kategoria.Id.ToString())
    End Function

    Public Shared Function LuoListItemKorvauslaskemaStatus(status As KorvauslaskelmaStatus) As ListItem
        Return New ListItem(status.Nimi, status.Id.ToString())
    End Function

    Public Shared Function LuoListItemKorvaustyyppi(tyyppi As Korvaustyyppi) As ListItem
        Return New ListItem(tyyppi.Nimi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemKunta(kunta As Kunta) As ListItem
        Return New ListItem(kunta.KuntaNimi, kunta.Id.ToString())
    End Function

    Public Shared Function LuoListItemKustannuspaikka(kustannuspaikka As KirjanpidonKustannuspaikka) As ListItem
        Return New ListItem(kustannuspaikka.KokoNimi, kustannuspaikka.Id.ToString())
    End Function

    Public Shared Function LuoListItemKuukausi(kuukausi As Kuukausi) As ListItem
        Return New ListItem(kuukausi.Nimi, kuukausi.Id.ToString())
    End Function

    Public Shared Function LuoListItemLocal1(local1 As Local1) As ListItem
        Return New ListItem(local1.Nimi, local1.Id.ToString())
    End Function

    Public Shared Function LuoListItemLupataho(lupataho As Lupataho) As ListItem
        Return New ListItem(lupataho.Nimi, lupataho.Id.ToString())
    End Function

    Public Shared Function LuoListItemMaa(maa As Maa) As ListItem
        Return New ListItem(maa.NimiSuomi, maa.Id.ToString())
    End Function

    Public Shared Function LuoListItemMaksuehdot(maksuehdot As Maksuehdot) As ListItem
        Return New ListItem(maksuehdot.Nimi, maksuehdot.Id.ToString())
    End Function

    Public Shared Function LuoListItemMaksunSuoritus(maksunSuoritus As MaksunSuoritus) As ListItem
        Return New ListItem(maksunSuoritus.Nimi, maksunSuoritus.Id.ToString())
    End Function

    Public Shared Function LuoListItemOrganisaationTyyppi(tyyppi As OrganisaationTyyppi) As ListItem
        Return New ListItem(tyyppi.Tyyppi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemPurpose(purpose As Purpose) As ListItem
        Return New ListItem(purpose.Nimi, purpose.Id.ToString())
    End Function

    Public Shared Function LuoListItemPuustonOmistajuus(puustonOmistajuus As PuustonOmistajuus) As ListItem
        Return New ListItem(puustonOmistajuus.Nimi, puustonOmistajuus.Id.ToString())
    End Function

    Public Shared Function LuoListItemPuustonPoisto(puustonPoisto As PuustonPoisto) As ListItem
        Return New ListItem(puustonPoisto.Nimi, puustonPoisto.Id.ToString())
    End Function

    Public Shared Function LuoListItemRegulation(regulation As Regulation) As ListItem
        Return New ListItem(regulation.Nimi, regulation.Id.ToString())
    End Function

    Public Shared Function LuoListItemSiirtoOikeus(oikeus As SiirtoOikeus) As ListItem
        Return New ListItem(oikeus.Nimi, oikeus.Id.ToString())
    End Function

    Public Shared Function LuoListItemSopimuksenAlaluokka(luokka As SopimuksenAlaluokka) As ListItem
        Return New ListItem(luokka.Nimi, luokka.Id.ToString())
    End Function

    Public Shared Function LuoListItemSopimuksenEhtoversio(versio As SopimuksenEhtoversio) As ListItem
        Return New ListItem(versio.Nimi, versio.Id.ToString())
    End Function

    Public Shared Function LuoListItemSopimuksenTila(tila As SopimuksenTila) As ListItem
        Return New ListItem(tila.Nimi, tila.Id.ToString())
    End Function

    Public Shared Function LuoListItemSopimus(sopimus As Sopimusrekisteri.BLL_CF.Sopimus) As ListItem
        Return New ListItem(sopimus.Nimi, sopimus.Id.ToString())
    End Function

    Public Shared Function LuoListItemSopimustyyppi(tyyppi As Sopimustyyppi) As ListItem
        Return New ListItem(tyyppi.SopimustyyppiNimi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemTaho(taho As Sopimusrekisteri.BLL_CF.Taho) As ListItem
        Return New ListItem(taho.Nimi, taho.Id.ToString())
    End Function

    Public Shared Function LuoListItemYlasopimuksenTyyppi(tyyppi As YlasopimuksenTyyppi) As ListItem
        Return New ListItem(tyyppi.Nimi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemVuokratyyppi(tyyppi As Vuokratyyppi) As ListItem
        Return New ListItem(tyyppi.Nimi, tyyppi.Id.ToString())
    End Function

    Public Shared Function LuoListItemOhjaustieto(ohjaustieto As IOhjaustieto) As ListItem
        Return New ListItem(ohjaustieto.Nimi, ohjaustieto.Id.ToString())
    End Function

    Public Shared Function LuoTyhjaListItem() As ListItem
        Return New ListItem("-- Ei valintaa --", String.Empty)
    End Function

    Public Shared Function RivitaOsoite(taho As Sopimusrekisteri.BLL_CF.Taho) As String

        Dim lstKentat As New List(Of String)

        lstKentat.Add(taho.Nimi)

        If Not String.IsNullOrEmpty(taho.Postitusosoite) Then
            lstKentat.Add(taho.Postitusosoite)
        End If

        If Not String.IsNullOrEmpty(taho.Postituspostinro) Then
            lstKentat.Add(taho.Postituspostinro)
        End If

        If Not String.IsNullOrEmpty(taho.Postituspostitmp) Then
            lstKentat.Add(taho.Postituspostitmp)
        End If

        If Not taho.Maa Is Nothing Then
            lstKentat.Add(taho.Maa.Nimi)
        End If

        Return Join(lstKentat.ToArray(), "<br />")

    End Function

    Public Shared Function RivitaHtml(ParamArray rivit As String()) As String

        Return String.Join("<br />", rivit.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).Select(Function(x) HttpUtility.HtmlEncode(x)))

    End Function

End Class
