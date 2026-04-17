# Tietokannan migraatioskriptit

## Pikaohje (Quick Start)

### Luo tietokanta tyhjästä

```bash
# 1. Käynnistä SQL Server (jos ei ole käynnissä)
./database/scripts/start.sh  # tai start.ps1 Windowsissa

# 2. Luo tyhjä tietokanta
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"

# 3. Aja skeema (125 taulua, ~30-60 sekuntia)
docker exec caruna-db bash -c "cd /migrations && \
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' -C \
  -d Fortum -i 000_schema.sql"

# 4. Lataa lookup-data (49 taulua, ~1-2 sekuntia)
docker exec caruna-db bash -c "cd /migrations && \
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' -C \
  -d Fortum -i 001_lookup_data.sql"

# Valmis! Tietokanta on nyt käytettävissä (tyhjänä, ilman business-dataa)
```

**Windows PowerShell:**

```powershell
# 1. Käynnistä SQL Server
.\database\scripts\start.ps1

# 2. Luo tyhjä tietokanta
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd `
  -S localhost -U SA -P 'DevPassword123!' -C `
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"

# 3. Aja skeema
docker exec caruna-db cmd /c "cd /migrations && sqlcmd -S localhost -U SA -P DevPassword123! -C -d Fortum -i 000_schema.sql"

# 4. Lataa lookup-data
docker exec caruna-db cmd /c "cd /migrations && sqlcmd -S localhost -U SA -P DevPassword123! -C -d Fortum -i 001_lookup_data.sql"
```

### Tarkista että tietokanta on valmis

```bash
# Tarkista taulujen määrä (pitäisi olla 125)
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS Tables FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'"

# Tarkista lookup-data (pitäisi olla esim. 5 riviä)
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS Rows FROM hlps_SopimuksenTila"
```

### Generoi skriptit uudelleen

```bash
# Päivitä skeema (jos tietokantarakenne on muuttunut)
python3 database/scripts/generate_schema.py

# Päivitä lookup-data (jos referenssidata on muuttunut)
python3 database/scripts/generate_inserts.py
```

---

## Yleiskatsaus

Nämä migration-skriptit mahdollistavat Fortum-tietokannan luomisen versionhallinnasta. Sisältävät skeeman ja lookup-datan, mutta eivät business-dataa.

## Skriptit

### 000_schema.sql (125 taulua, ~2,700 riviä, 96 KB)

**Sisältö:**
- CREATE TABLE -lauseet kaikille tauluille
- PRIMARY KEY -määritelmät
- IDENTITY-sarakkeet (auto-increment)
- DEFAULT-arvot
- NULL/NOT NULL -määritelmät

**Taulut:**
- Kaikki 125 taulua tietokannassa
- Business-taulut: Sopimus, Taho, Kiinteisto jne.
- Lookup-taulut: hlp_*, hlps_*
- ASP.NET-taulut: aspnet_*
- Historia-taulut: _access, _JAS jne.

**Käyttö:**
```sql
-- Luo tyhjä tietokanta, sitten aja skeema
sqlcmd -S localhost -U SA -P 'DevPassword123!' -d Fortum -C -i 000_schema.sql
```

**Huom:** Tämä skripti EI sisällä:
- FOREIGN KEY -määritelmiä (tulossa myöhemmin)
- INDEX-määritelmiä (paitsi PRIMARY KEY)
- Trigger-määritelmiä
- View-määritelmiä

### 001_lookup_data.sql (49 taulua, ~200 riviä)

**Sisältö:**
- Kaikki `hlp_*` ja `hlps_*` lookup/reference-taulut
- < 100 riviä per taulu
- Staattiset määrittelytiedot joita sovellus tarvitsee

**Taulut:**
- **hlp_Alv** - ALV-prosentit (24%, 25.5%)
- **hlp_Asiakastyyppi** - Asiakastyypit (Alkuperäinen osapuoli, Omistaja jne.)
- **hlp_BicKoodi** - Pankkien BIC-koodit ja rahalaitostunnukset
- **hlp_Indeksi** - Indeksityypit (X-indeksi, MAKU jne.)
- **hlp_Kieli** - Kielet (Suomi, Ruotsi, Englanti)
- **hlp_Kunta** - Kuntakoodit ja -nimet
- **hlp_SopimuksenKesto** - Sopimuskestot (Määräaikainen, Toistaiseksi jne.)
- **hlps_SopimuksenTila** - Sopimuksen tilat (Voimassa, Päättynyt jne.)
- **hlps_Sopimustyyppi** - Sopimustyypit (Johtoaluesopimus, Vuokrasopimus jne.)
- ... ja 40 muuta lookup-taulua

**Käyttö:**
```sql
-- Tietokannassa on oltava taulut luotuna (skeema)
sqlcmd -S localhost -U SA -P 'DevPassword123!' -d Fortum -C -i 001_lookup_data.sql
```

### 003_sample_pdfs.sql (3 test-PDF:ää)

**Sisältö:**
- 3 minimaalista test-PDF:ää (ID 99001-99003)
- Luotu Python-skriptillä, ei tuotannosta
- Testimukaista dataa PDF-toiminnallisuuden testaamiseen

**Käyttö:**
```sql
-- Tietokannassa on oltava Sopimus_Tuloste-taulu luotuna
sqlcmd -S localhost -U SA -P 'DevPassword123!' -d Fortum -C -i 003_sample_pdfs.sql
```

## Generoidaan uudelleen

Luodaan CREATE TABLE -lauseet:

```bash
python3 database/scripts/generate_schema.py
```

Luodaan INSERT-lauseet lookup-tauluille:

```bash
python3 database/scripts/generate_inserts.py
```

Luodaan test-PDF:t:

```bash
python3 database/scripts/generate_sample_pdfs.py
```

**Skriptit:**
- `generate_schema.py` - Lukee taulujen rakenteen SQL Server:stä ja generoi CREATE TABLE -lauseet
- `generate_inserts.py` - Lukee lookup-taulujen datan ja generoi INSERT-lauseet
- `generate_sample_pdfs.py` - Luo minimaalisia test-PDF:iä Python:lla
- Kaikki toimivat `caruna-db` Docker-containerin kanssa

## Käyttötapaukset

### Uusi kehittäjä

1. **Käynnistä Docker**
   ```bash
   ./database/scripts/start.sh
   ```

2. **Luo tyhjä tietokanta**
   ```sql
   CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS;
   ```

3. **Aja migration-skriptit**
   ```bash
   # Skeema (125 taulua, ~30-60 s)
   docker exec caruna-db bash -c "cd /migrations && \
     /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' -C \
     -d Fortum -i 000_schema.sql"
   
   # Lookup-data (49 taulua, ~1-2 s)
   docker exec caruna-db bash -c "cd /migrations && \
     /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' -C \
     -d Fortum -i 001_lookup_data.sql"
   
   # Test-PDF:t (3 kpl, ~1 s)
   docker exec caruna-db bash -c "cd /migrations && \
     /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' -C \
     -d Fortum -i 003_sample_pdfs.sql"
   ```

4. **Generoi testidata tarvittaessa** sovelluksesta tai SQL-skripteillä

✅ **Kevyt:** ~150 KB versionhallinnassa  
✅ **Nopea:** ~1-2 minuuttia  
✅ **Versionhallinnoitavissa:** Kaikki Git:ssä

### CI/CD-testit

Sama prosessi kuin kehittäjälle. Migration-skriptit soveltuvat erinomaisesti CI/CD-putkiin:

```yaml
# GitHub Actions esimerkki
- name: Run migrations
  run: |
    sqlcmd -S localhost -U SA -P '${{ secrets.SA_PASSWORD }}' -C -d Fortum \
      -i database/migrations/000_schema.sql
    sqlcmd -S localhost -U SA -P '${{ secrets.SA_PASSWORD }}' -C -d Fortum \
      -i database/migrations/001_lookup_data.sql
    sqlcmd -S localhost -U SA -P '${{ secrets.SA_PASSWORD }}' -C -d Fortum \
      -i database/migrations/003_sample_pdfs.sql
```

### Mihin tämä ei sovellu

❌ **Business-data** (Sopimus, Taho, Kiinteisto, ~150k+ riviä):
   - Liian iso versionhallintaan
   - Jos tarvitset tuotantodataa debuggaukseen, pyydä DB dump DBA-tiimiltä erikseen
   - Generoi testidata tarvittaessa

## Ylläpito

### Lookup-datan päivitys

Kun tuotannossa lisätään uusi lookup-arvo:

1. **Päivitä lokaalissa tuotannon dumpista** (jos sinulla on pääsy)
   ```bash
   # Palauta dump lokaalisti
   # Generoi uudelleen lookup-data
   python3 database/scripts/generate_inserts.py
   git add database/migrations/001_lookup_data.sql
   git commit -m "Update lookup data from production"
   ```

2. **TAI päivitä manuaalisesti**
   ```sql
   -- Lisää 001_lookup_data.sql:ään
   INSERT INTO hlps_SopimuksenTila (TilaID, Nimi) VALUES (99, 'Uusi tila');
   ```

### Skeeman muutokset

**Muutosten dokumentointi:**

1. Päivitä skeema:
   ```bash
   # Generoi uudelleen koko skeema
   python3 database/scripts/generate_schema.py
   # TAI luo erillinen migration-skripti
   ```

2. Luo uusi migraatioskripti: `002_add_column_xyz.sql`
3. Aja skripti kehitysympäristössä
4. Testaa sovellus
5. Commitoi versionhallintaan
6. Aja tuotannossa

**Esimerkki:**
```sql
-- 002_add_viitekoodi_column.sql
ALTER TABLE Sopimus ADD SViitekoodi NVARCHAR(50) NULL;
GO
```

**Skeeman uudelleengenerointi:**

Jos tietokantaan tehdään muutoksia (uusia taulujacolumneita jne.):
```bash
# Generoi skeema uudelleen tuotannosta
python3 database/scripts/generate_schema.py

# Tarkista muutokset
git diff database/migrations/000_schema.sql

# Commitoi
git add database/migrations/000_schema.sql
git commit -m "Update schema: add XYZ table"
```

## Vianmääritys (Troubleshooting)

### "Database already exists"

```bash
# Poista vanha tietokanta
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "DROP DATABASE Fortum"

# Luo uudelleen
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"
```

### "Cannot open database Fortum"

Tietokanta ei ole vielä luotu. Aja CREATE DATABASE -komento ensin (ks. Pikaohje).

### "Incorrect syntax near 'GO'"

Jos ajat skriptejä suoraan Python:ssa tai ohjelmakoodissa, GO-lauseet pitää käsitellä erikseen:

```python
# Jaa skripti GO-komentaen mukaan
with open('000_schema.sql', 'r') as f:
    script = f.read()
    batches = script.split('GO')
    for batch in batches:
        if batch.strip():
            cursor.execute(batch)
```

### "Invalid cursor state" (001_lookup_data.sql)

Tämä virhe on korjattu lisäämällä `SET IDENTITY_INSERT ON/OFF` -käsittely. Varmista että käytät uusinta versiota:

```bash
python3 database/scripts/generate_inserts.py  # Generoi uudelleen
```

### Skeema ei generoi oikein

```bash
# Tarkista että SQL Server on käynnissä
docker ps | grep caruna-db

# Tarkista yhteys
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "SELECT @@VERSION"

# Generoi uudelleen
python3 database/scripts/generate_schema.py
```

### "Container not found: caruna-db"

```bash
# Käynnistä SQL Server ensin
./database/scripts/start.sh  # tai start.ps1
```

## Parhaat käytännöt (Best Practices)

### Versionhallinta

**DO:**
- ✅ Commitoi `.sql`-skriptit (`000_schema.sql`, `001_lookup_data.sql`)
- ✅ Commitoi Python-generaattorit (`generate_schema.py`, `generate_inserts.py`)
- ✅ Dokumentoi muutokset CHANGELOG.md-tiedostoon
- ✅ Käytä semanttista versiointia (esim. `002_add_customer_type.sql`)
- ✅ Lisää kommentteja SQL-skripteihin selittämään *miksi*, ei *mitä*

**DON'T:**
- ❌ Älä commitoi `.bak`-tiedostoja (käytä `.gitignore`)
- ❌ Älä muokkaa generoituja `.sql`-tiedostoja suoraan
- ❌ Älä commitoi kehitysdataa (tuotannon asiakastietoja)
- ❌ Älä commitoi SA-salasanoja tai connection stringejä

### Migration-skriptien nimeäminen

Käytä järjestysnumeroa ja kuvaavaa nimeä:

```
000_schema.sql              # Perusskeema
001_lookup_data.sql         # Lookup-data (hlp_*, hlps_*)
002_add_customer_email.sql  # Uusi sarake: Asiakkaat.Sahkoposti
003_create_audit_tables.sql # Auditointitaulut
004_update_indexes.sql      # Indeksien päivitys
```

**Miksi?**
- Leksikaalinen järjestys = suoritusjärjestys
- Git diff näyttää historiallisen kehityksen
- CI/CD voi ajaa skriptit automaattisesti

### Idempotenssi (uudelleenajettavuus)

**Ei-idempotentit skriptit** (ongelma):
```sql
-- ❌ Kaatuu jos taulu on jo olemassa
CREATE TABLE Asiakkaat (...)

-- ❌ Kaatuu jos sarake on jo olemassa  
ALTER TABLE Sopimus ADD COLUMN Sahkoposti NVARCHAR(255)
```

**Idempotentti ratkaisu** (parempi):
```sql
-- ✅ Luo vain jos ei ole olemassa
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Asiakkaat')
BEGIN
    CREATE TABLE Asiakkaat (...)
END

-- ✅ Lisää sarake vain jos puuttuu
IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('Sopimus') 
    AND name = 'Sahkoposti'
)
BEGIN
    ALTER TABLE Sopimus ADD Sahkoposti NVARCHAR(255)
END
```

**Miksi tärkeää?**
- Skriptit voidaan ajaa uudelleen turvallisesti
- CI/CD-putket eivät kaadu toistuvissa ajoissa
- Helpottaa vianmääritystä

### Testing-strategia

**Lokaalitesti ennen committia:**
```bash
# 1. Luo testiympäristö
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE FortumTest COLLATE Finnish_Swedish_CI_AS"

# 2. Aja migration
docker exec -i caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d FortumTest \
  < database/migrations/000_schema.sql

docker exec -i caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d FortumTest \
  < database/migrations/001_lookup_data.sql

# 3. Tarkista tulos
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d FortumTest \
  -Q "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"

# 4. Siivoa
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "DROP DATABASE FortumTest"
```

### CI/CD-integraatio

GitHub Actions -esimerkki:
```yaml
name: Database Migration Test

on: [push, pull_request]

jobs:
  test-migration:
    runs-on: ubuntu-latest
    
    services:
      sqlserver:
        image: mcr.microsoft.com/mssql/server:2022-latest
        env:
          ACCEPT_EULA: Y
          SA_PASSWORD: TestPassword123!
        ports:
          - 1433:1433
    
    steps:
      - uses: actions/checkout@v3
      
      - name: Wait for SQL Server
        run: sleep 15
      
      - name: Create database
        run: |
          sqlcmd -S localhost -U SA -P 'TestPassword123!' -C \
            -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"
      
      - name: Run migrations
        run: |
          sqlcmd -S localhost -U SA -P 'TestPassword123!' -C -d Fortum \
            -i database/migrations/000_schema.sql
          sqlcmd -S localhost -U SA -P 'TestPassword123!' -C -d Fortum \
            -i database/migrations/001_lookup_data.sql
      
      - name: Verify migration
        run: |
          sqlcmd -S localhost -U SA -P 'TestPassword123!' -C -d Fortum \
            -Q "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
```

### Rollback-strategia

**Inkrementaaliset muutokset** (suositus):
```
002_add_email_column.sql         # Forward migration
002_add_email_column_down.sql    # Rollback script
```

Esimerkki rollback-skriptistä:
```sql
-- 002_add_email_column_down.sql
USE Fortum
GO

IF EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID('Asiakkaat') 
    AND name = 'Sahkoposti'
)
BEGIN
    ALTER TABLE Asiakkaat DROP COLUMN Sahkoposti
    PRINT 'Sarake Sahkoposti poistettu onnistuneesti'
END
ELSE
BEGIN
    PRINT 'Saraketta Sahkoposti ei löytynyt'
END
GO
```

### Data-migration vs. Schema-migration

Erota skeema- ja datamuutokset eri skripteihin:

```
003_add_status_column.sql        # ALTER TABLE: Lisää Status-sarake
003_populate_status.sql          # UPDATE: Täytä oletusarvot
```

**Miksi?**
- Skeemamuutos on nopea (< 1s)
- Datamuutos voi kestää kauan (miljoonat rivit)
- Voidaan ajaa erikseen maintenance window -aikana

### Lookup-data vs. Business-data

**Lookup-data** (versionhallinnassa):
- Koodistot, statukset, asetukset
- ~200 riviä, harvoin muuttuu
- Esim. `hlp_Alv`, `hlps_SopimuksenTila`

**Business-data** (EI versionhallinnassa):
- Asiakastiedot, sopimukset, transaktiot
- 158,000+ riviä, muuttuu jatkuvasti
- Esim. `Sopimus`, `Asiakkaat`, `Kiinteisto`

**Poikkeus**: Testidata CI/CD:ssä
```sql
-- 099_test_data.sql (vain CI/CD-ympäristöön)
INSERT INTO Asiakkaat (Nimi, Ytunnus, ...) VALUES
('Testiasiakas Oy', '1234567-8', ...),
('Toinen Testi AB', '8765432-1', ...)
```

### Performance-vinkit

**Massiivinen data** (miljoonia rivejä):
```sql
-- ❌ Hidas: Yksi INSERT per rivi
INSERT INTO Asiakkaat VALUES (...)
INSERT INTO Asiakkaat VALUES (...)
-- ... 1,000,000 riviä

-- ✅ Nopea: Batch insert tai BCP-työkalu
INSERT INTO Asiakkaat (Nimi, Ytunnus) VALUES
('Asiakas 1', '1234567-8'),
('Asiakas 2', '8765432-1'),
-- ... 1000 riviä per batch
```

**IDENTITY_INSERT optimointi**:
```sql
-- Käytä vain kun välttämätöntä (lookup-taulut)
SET IDENTITY_INSERT hlp_Alv ON
-- INSERT ...
SET IDENTITY_INSERT hlp_Alv OFF

-- Normaalit taulut: Anna SQL Serverin generoida ID:t
-- INSERT INTO Asiakkaat (Nimi, ...) VALUES (...)  -- AsiakasID generoituu automaattisesti
```

## Tilastot

- **Taulut yhteensä:** 125 kpl
- **Skeema (000_schema.sql):** ~2,700 riviä, 96 KB
- **Lookup-taulut:** 49 kpl
- **Lookup-rivit:** ~200 riviä  
- **Lookup-data (001_lookup_data.sql):** ~456 riviä, 53 KB
- **Test-PDF:t (003_sample_pdfs.sql):** 3 kpl, 5 KB
- **Yhteensä:** ~150 KB (versionhallinnassa)

## Migration-skriptien edut

| Näkökulma | Migration-skriptit |
|-----------|---------------------|
| **Kehitysympäristö** | ✅ Nopea (1-2 min) |
| **Versionhallinta** | ✅ 150 KB (sopii Git:iin) |
| **CI/CD-testit** | ✅ Kevyt + nopea |
| **Lookup-data hallinta** | ✅ Helppo päivittää |
| **Skeeman hallinta** | ✅ Git diff näyttää muutokset |
| **Business-data** | ⚠️ Ei mukana (generoi tarvittaessa) |
| **Test-PDF:t** | ✅ 3 kpl testimukaista dataa |

**Käyttötapaukset:**
- **Kehitys:** Migration-skriptit + generoi testidata tarvittaessa
- **Versionhallinta:** Kaikki skriptit (skeema + lookup + tes t-PDF:t)
- **CI/CD:** Skeema + lookup-data + test-PDF:t
- **Business-data tarpeet:** Pyydä DB dump DBA-tiimiltä erikseen
