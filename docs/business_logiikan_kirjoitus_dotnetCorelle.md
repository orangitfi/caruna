# Business-logiikan kirjoitus .NET Corelle

Tämä ohje kuvaa, miten business-logiikka (domain + sovelluslogiikka) kannattaa kirjoittaa .NET Core / ASP.NET Core -ymparistoon niin, että:

- logiikka irtoaa vanhasta WebForms-kytkennasta
- koodi on testattavaa ja ylläpidettävää
- samaa logiikkaa voi käyttää sekä vanhan UI:n että uuden API:n kautta

## 1. Tavoitearkkitehtuuri

Suositeltu rakenne:

- Domain: entiteetit, value objectit, domain-saannot
- Application: use case -palvelut (orchestration), DTO:t, validointi
- Infrastructure: tietokanta, integraatiot, tiedostot, ulkoiset rajapinnat
- API/UI: ohuet endpointit tai sivukerros, ei business-saantoja

Kriittinen periaate:

- Business-saannot eivat kuulu controllereihin, handlereihin tai code-behindiin.

## 2. Projektirakenne (esimerkki)

```
src/
  Company.Product.Domain/
  Company.Product.Application/
  Company.Product.Infrastructure/
  Company.Product.Api/
tests/
  Company.Product.Domain.Tests/
  Company.Product.Application.Tests/
  Company.Product.Api.IntegrationTests/
```

## 3. Kerrosten vastuut

Domain:

- Sisaltaa liiketoimintasaannot ja invarianssit.
- Ei riippuvuuksia EF Coreen, HTTP:hen tai framework-palveluihin.

Application:

- Toteuttaa kayttotapaukset (esim. LuoSopimus, HyvaksySopimus).
- Kayttaa rajapintoja (repositoryt, integraatioportit), ei konkreettisia toteutuksia.
- Vastaa transaktiorajoista ja virheiden kasittelysta kayttotapaustasolla.

Infrastructure:

- EF Core -toteutukset, ulkoiset API-kutsut, tiedostopalvelut.
- Toteuttaa Application-kerroksen rajapinnat.

API/UI:

- Muuntaa requestin komennoksi/queryksi.
- Kutsuu Application-kerrosta.
- Palauttaa tuloksen ilman liiketoimintasaantoja.

## 4. Kirjoitustapa business-logiikalle

Suositus:

1. Mallinna ensin domain-kasitteet (entiteetit, value objectit).
2. Kirjoita saannot domain-metodeihin.
3. Kirjoita use case -palvelu, joka orkestroi domainin + riippuvuudet.
4. Kirjoita testit ennen integraatiota API-kerrokseen.

Valta naita anti-patterneja:

- "God service" jossa kaikki liiketoiminta on yhdessa luokassa.
- EF Core -entiteetti suoraan API:n request/response mallina.
- Business-saannot SQL-proseduureissa ilman sovelluskerroksen valvontaa.

## 5. Esimerkkikoodi

### Domain-entiteetti

```csharp
public sealed class Sopimus
{
    public Guid Id { get; private set; }
    public string Tila { get; private set; } = "Luonnos";
    public DateTime? HyvaksyttyUtc { get; private set; }

    public void Hyvaksy(DateTime utcNow)
    {
        if (Tila != "Luonnos")
        {
            throw new InvalidOperationException("Vain luonnos voidaan hyvaksyä.");
        }

        Tila = "Hyvaksytty";
        HyvaksyttyUtc = utcNow;
    }
}
```

### Application-palvelu (use case)

```csharp
public interface ISopimusRepository
{
    Task<Sopimus?> GetByIdAsync(Guid id, CancellationToken ct);
    Task SaveAsync(Sopimus sopimus, CancellationToken ct);
}

public sealed class HyvaksySopimusService
{
    private readonly ISopimusRepository _repo;
    private readonly IClock _clock;

    public HyvaksySopimusService(ISopimusRepository repo, IClock clock)
    {
        _repo = repo;
        _clock = clock;
    }

    public async Task ExecuteAsync(Guid sopimusId, CancellationToken ct)
    {
        var sopimus = await _repo.GetByIdAsync(sopimusId, ct)
            ?? throw new KeyNotFoundException("Sopimusta ei loydy.");

        sopimus.Hyvaksy(_clock.UtcNow);
        await _repo.SaveAsync(sopimus, ct);
    }
}
```

### API-controller (ohut)

```csharp
[ApiController]
[Route("api/sopimukset")]
public sealed class SopimuksetController : ControllerBase
{
    private readonly HyvaksySopimusService _service;

    public SopimuksetController(HyvaksySopimusService service)
    {
        _service = service;
    }

    [HttpPost("{id:guid}/hyvaksy")]
    public async Task<IActionResult> Hyvaksy(Guid id, CancellationToken ct)
    {
        await _service.ExecuteAsync(id, ct);
        return NoContent();
    }
}
```

## 6. Validointi, virheet ja transaktiot

Validointi:

- Syntaksivalidointi API-rajalla (pakolliset kentat, formaatit).
- Liiketoimintavalidointi domainissa ja application-palveluissa.

Virheet:

- Domain- ja application-virheet kuvataan selkeina poikkeuksina tai Result-olioina.
- API palauttaa standardoidut virhekoodit (esim. 400, 404, 409).

Transaktiot:

- Yksi use case = yksi selkea transaktioraja.
- Valttele pitkiä transaktioita, joissa on ulkoisia verkko-operaatioita.

## 7. Testausstrategia

Vahimmaisvaatimus:

- Domain-yksikkotestit kaikille kriittisille saannoille.
- Application-yksikkotestit mockatuilla riippuvuuksilla.
- API-integraatiotestit tärkeimmille endpoint-poluille.

Painotus migraatiossa:

- Kirjoita regressiotestit ennen vanhan logiikan siirtoa.
- Varmista parity-testit: vanha toteutus vs uusi toteutus samalla syotteella.

## 8. Migraatio vanhasta arkkitehtuurista (vaiheittain)

1. Tunnista yksi rajattu use case vanhasta sovelluksesta.
2. Siirra saannot Domain + Application -kerroksiin.
3. Toteuta Infrastructure-adapterit nykyiseen tietomalliin.
4. Julkaise uusi API-endpoint.
5. Ohjaa vanha UI kutsumaan APIa (tai jaa rinnakkaisajoon).
6. Mittaa virheet, suorituskyky ja liiketoimintamittarit.
7. Toista seuraavaan use caseen.

## 9. Suorituskyky ja observability

Pakolliset kaytannot:

- Rakenteinen lokitus (correlation id).
- Mittarit kriittisille toiminnoille (latenssi, virheprosentti, onnistumisaste).
- Tracing API -> Application -> DB.
- Aikarajat ja retry-politiikat ulkoisiin integraatioihin.

## 10. Tarkistuslista ennen tuotantoa

- Onko business-saannot irti UI- ja infra-riippuvuuksista?
- Onko kriittisista use caseista testit (unit + integration)?
- Onko virhekasittely vakioitu APIssa?
- Onko observability kunnossa (logit, metriikat, tracing)?
- Onko rollback- tai feature flag -suunnitelma olemassa?

## 11. Tyomaaraarvio Claude-agenttien avustamana

Tama arvio olettaa, etta toteutus tehdään vaiheittain (strangler-malli),
ja Claude-agentit avustavat analyysissa, koodigeneroinnissa, testien
kirjoituksessa, dokumentoinnissa ja refaktoroinnissa.

Arvio ei oleta "fully autonomous" tuotantovientia ilman ihmisen
hyvaksyntaportteja.

### 11.1 Mita agentit nopeuttavat eniten

- Toistuva CRUD-koodin ja DTO-mapin generointi.
- Testipohjien ja regressiotestien tuotanto.
- Refaktoroinnin mekaaniset vaiheet (esim. rajapintojen irrotus).
- Dokumentointi (API-kuvaukset, migraatiomuistiot, tarkistuslistat).

Tyypillinen ajan saasto hyvin johdetussa toteutuksessa:

- 25-45 % kehitystyosta.

Huomio:

- Saasto vaihtelee paljon sen mukaan, kuinka monimutkaista legacy-logiikka
    on ja kuinka hyvin vaatimukset ovat maaritelty.

### 11.2 Vaihekohtainen arvio

1. Esiselvitys ja rajaus (use case -kartoitus, priorisointi): 1-2 viikkoa
2. Core API -perusta (auth, virhemalli, logging, tracing, CI): 2-4 viikkoa
3. Ensimmaisen 5-10 use casen siirto (pilot): 4-8 viikkoa
4. Laajempi business-logiikan siirto (iteratiivinen): 3-6 kuukautta
5. Kovennus ja tuotantovarmistus (load, security, rollback): 3-6 viikkoa

Kokonaisarvio:

- MVP-taso: 3-5 kuukautta
- Laaja tuotantopariteetti: 5-9 kuukautta

### 11.3 Vertailu ilman agentteja vs Claude-agenttien kanssa

Karkea vertailu samassa migraatiossa:

- Ilman agentteja: 6-12 kuukautta
- Claude-agenttien avustamana: 5-9 kuukautta

Suurimmat pullonkaulat, joita agentit eivat poista:

- Liiketoimintasaantojen tulkinta ja päätökset
- Tuotantoriskien hallinta ja go/no-go paatokset
- Hyvaksyntatestauksen organisointi ja sidosryhmayhteistyo

### 11.4 Resursointimalli (suositus)

Pienin toimiva kokoonpano:

- 1 tekninen omistaja / arkkitehti
- 1-2 kehittajaa + Claude-agentit paivittaisessa kaytossa
- 1 testivastuullinen (tai rotaatio)

Talla mallilla voidaan usein saavuttaa:

- 1-3 keskivaikeaa use casea / sprintti

### 11.5 Riskivaraus arvioon

Lisaa aikatauluun 20-30 % riskivaraus, jos:

- Legacy-koodi sisältää paljon implisiittista business-logiikkaa
- Testikattavuus on heikko
- Integraatioita on useita (esim. tiedosto-, SOAP- tai AD-riippuvuudet)

Käytännön suositus:

- Tee ensin 2-4 viikon pilot, mittaa toteutunut nopeus, ja paivita
    lopullinen roadmap datan perusteella.

---

Tiivistelma:

- .NET Core -migraatiossa suurin arvo tulee business-logiikan eriyttamisesta.
- Pida Domain/Application puhtaana ja API/UI ohuena.
- Siirra toiminnallisuus use case kerrallaan ja varmista parity testeilla.
