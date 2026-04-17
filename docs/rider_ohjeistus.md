# JetBrains Rider -ohjeistus Caruna-järjestelmään

Tämä ohje kertoo, miten JetBrains Rideria kannattaa käyttää tämän järjestelmän kehittämiseen, analysointiin ja vaiheittaiseen modernisointiin.

## 1. Ratkaisujen avaaminen Riderissa

Avaa ensisijaisesti pääratkaisu:

```bash
open -a "Rider" /Users/artturilaitakari/Projects/caruna/slnSopimusrekisteri/slnSopimusrekisteri.sln
```

Muut ratkaisut tarpeen mukaan:

```bash
open -a "Rider" /Users/artturilaitakari/Projects/caruna/slnSopimusrekisteriLuokat/slnSopimusrekisteriLuokat.sln
open -a "Rider" /Users/artturilaitakari/Projects/caruna/slnIFSIntegraatio/slnIFSIntegraatio.sln
open -a "Rider" /Users/artturilaitakari/Projects/caruna/slnSopimusarkistoSiirto/slnSopimusarkistoSiirto.sln
open -a "Rider" /Users/artturilaitakari/Projects/caruna/slnFortumMalli/slnFortumMalli.sln
```

## 2. Miksi Rider sopii tämän repositorion kanssa

Nykytila on legacy-painotteinen (WebForms + VB.NET + .NET Framework), joten Riderista on hyötyä erityisesti seuraavissa:

- VB.NET-koodin navigointi ja refaktorointi
- ASPX/code-behind-parien analysointi
- Kytkösten visualisointi projektien välillä
- Turvalliset uudelleennimeämiset koko ratkaisun laajuisesti

## 3. Suositeltu päivittäinen workflow

1. Avaa ratkaisu ja aja Build.
2. Aja Riderin inspektiot (code inspections).
3. Korjaa ensin korkean vaikutuksen varoitukset:
   - dead code
   - null-viitteet
   - vanhentuneet API-kutsut
4. Tee refaktorointi pienissä paloissa (yhden luokan tai use case -alueen kerrallaan).
5. Aja testit aina muutoksen jälkeen.

## 4. Ominaisuudet, joita kannattaa hyödyntää

### 4.1 Refaktorointi

- Rename (Shift+F6): turvallinen nimeäminen koko ratkaisussa
- Extract Method: pilko pitkät code-behind-metodit
- Find Usages (Alt+F7): selvitä vaikutusalue ennen muutosta

### 4.2 Riippuvuusanalyysi

- Analyze -> Inspect Code
- Analyze -> Dependency Matrix
- Analyze -> Type Dependency Diagram

Näitä kannattaa käyttää ennen migraatiota .NET Coreen, jotta tiedetään mistä kerroksesta riippuvuudet katkaistaan ensin.

### 4.3 Testaus

- Luo yksikkotestit suoraan Riderista (Generate/Test scaffolding)
- Aja testit projektitasolla ennen commitia
- Priorisoi regressiotestit niille osille, joita siirretään API-rajapinnan taakse

## 5. AI-avusteinen kehitys Riderissa

Riderin AI Assistantia voi käyttää esimerkiksi:

- legacy-metodien selittämiseen
- testitapausten ideointiin
- refaktorointivaihtoehtojen vertailuun

Huomio:

- AI-ehdotukset tarkistetaan aina ennen tuotantokäyttöä
- turvallisuus- ja domain-säännöt varmennetaan ihmisellä

## 6. .NET Framework + .NET Core rinnakkain

Tässä järjestelmässä suositus on rinnakkaismalli:

- vanha WebForms-sovellus jatkaa toimintaa
- uusi ASP.NET Core API rakennetaan rinnalle
- UI-kutsuja siirretään vaiheittain API:lle

Rider tukee hyvin molempien maailmojen hallintaa samassa kehitysympäristössä.

## 7. Käytännön asetukset Rideriin

Suositeltavat tarkistukset:

- .NET Framework Developer Packit asennettuna (v4.0-v4.8 tarpeen mukaan)
- NuGet restore toimii kaikille ratkaisuillesi
- Inspections-profiili päällä koko ratkaisulle
- Tiedostokohtainen Code Cleanup ennen mergea

## 8. Ensimmäiset 2 viikkoa Rider-käyttöön

1. Viikko 1:
   - analysoi yksi ratkaisu (slnSopimusrekisteri)
   - kartoita 10 eniten muuttuvaa luokkaa
   - luo regressiotestit kriittisiin kohtiin
2. Viikko 2:
   - tee ensimmäinen pieni refaktorointieristys (esim. yksi BLL-use case)
   - dokumentoi riippuvuudet ja riskit
   - valmistele ensimmäinen API-eriytys

## 9. Yhteenveto

Rider on tehokas työkalu tämän järjestelmän kanssa, koska se helpottaa legacy-koodin ymmärtämistä ja turvallista muutosta.

Paras hyöty saadaan, kun:

- muutokset pidetään pieninä
- testit pidetään vihreinä jokaisessa vaiheessa
- modernisointi tehdään iteratiivisesti, ei kertasiirtymana
