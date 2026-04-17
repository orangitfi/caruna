# Database Scripts

Tässä kansiossa on apuskriptejä tietokannan hallintaan.

## Skriptit

### start.sh / start.ps1 - Käynnistä tietokanta

Käynnistää caruna-db Docker-kontin ja sammuttaa automaattisesti muut SQL Server -kontit jotka käyttävät porttia 1433 (esim. LähiTapiola-projekti).

**Käyttö:**

```bash
# macOS/Linux (projektin juuressa)
./database/scripts/start.sh

# Windows PowerShell (projektin juuressa)
.\database\scripts\start.ps1
```

**Mitä skripti tekee:**
1. Tarkistaa että docker-compose.yml löytyy
2. Etsii muut SQL Server -kontit portissa 1433 (`docker ps --filter "publish=1433"`)
3. Sammuttaa löydetyt kontit (paitsi caruna-db)
4. Käynnistää caruna-db:n (`docker-compose up -d`)
5. Odottaa että SQL Server vastaa (max 60 sekuntia)
6. Näyttää yhteysohjeet

**Käyttötapaukset:**
- Aloitat Caruna-projektin kehitystyön
- Vaihdat toisesta projektista (joka käyttää samaa porttia) Carunaan
- Tietokanta on sammunut ja haluat käynnistää sen uudelleen

---

### Generaattorit - Luo migration-skriptit

#### generate_schema.py

Generoi `000_schema.sql` nykyisen tietokannan rakenteesta.

**Käyttö:**
```bash
python3 database/scripts/generate_schema.py
```

**Vaatii:**
- Tietokanta on käynnissä (caruna-db)
- Fortum-tietokanta on olemassa
- `pyodbc` asennettu (`pip install pyodbc`)

#### generate_inserts.py

Generoi `001_lookup_data.sql` lookup-taulujen datasta.

**Käyttö:**
```bash
python3 database/scripts/generate_inserts.py
```

**Huom:** Käsittelee vain hlp_* ja hlps_* -taulut, käyttää IDENTITY_INSERT kun tarvitaan.

#### upload_pdfs.py

Generoi `003_sample_pdfs.sql` oikeista PDF-tiedostoista.

**Käyttö:**
```bash
# 1. Exportoi ensin 3 PDF:ää DBeaver:lla (ks. sample_pdfs/README.md)
# 2. Generoi SQL-skripti
python3 database/scripts/upload_pdfs.py
```

**Luo:** SQL-skripti jossa on 3 oikeaa PDF:ää (ID 99001-99003) testimukaista dataa varten. Käyttää fake test ID:itä jotta ei viittaa olemattomiin Sopimus-riveihin.

---

## Vianmääritys

### Skripti valittaa "docker-compose.yml not found"

Aja skripti projektin juurikansiosta, ei `database/scripts/`-kansiosta:

```bash
# VÄÄRIN
cd database/scripts
./start.sh

# OIKEIN
cd /path/to/caruna
./database/scripts/start.sh
```

### Porttikonflikti ei poistu

Jos start-skripti ei löydä muita kontteja mutta portti on silti käytössä:

```bash
# Tarkista mikä käyttää porttia 1433
# macOS/Linux:
lsof -i :1433

# Windows:
netstat -ano | findstr :1433

# Jos kyseessä on ei-Docker SQL Server, sammuta se manuaalisesti
```

### SQL Server ei käynnisty

Tarkista Docker-lokit:

```bash
docker-compose logs sqlserver
```

Yleisimmät ongelmat:
- Liian vähän muistia (Docker Desktop: Settings → Resources → Memory: min 4 GB)
- SA-salasana liian heikko (muuta docker-compose.yml)
- Aiempi kontti jäänyt jumiin (aja `docker-compose down -v` ja yritä uudelleen)

---

## Lisäohjeet

Katso täydelliset ohjeet:
- [docs/tietokannan_kehitysymparisto.md](../../docs/tietokannan_kehitysymparisto.md)
