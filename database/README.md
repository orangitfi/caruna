# Database - Tietokantakansio

Tässä kansiossa on tietokannan kehitysympäristön tiedostot.

## Kansiorakenne

```
database/
├── migrations/         # SQL migration-skriptit (versionhallinnassa)
│   ├── README.md       # Migraatioiden dokumentaatio
│   ├── 000_schema.sql  # Tietokantarakenne (125 taulua)
│   ├── 001_lookup_data.sql  # Lookup/reference-taulut (49 taulua, ~200 riviä)
│   └── 003_sample_pdfs.sql  # 3 testi-PDF:ää (testimukaista dataa)
└── scripts/            # Apuskriptit
    ├── generate_schema.py       # Generoi 000_schema.sql
    ├── generate_inserts.py      # Generoi 001_lookup_data.sql
    ├── generate_sample_pdfs.py  # Generoi 003_sample_pdfs.sql
    ├── start.sh/.ps1            # Käynnistä tietokanta
    └── README.md                # Skriptien dokumentaatio
```

## Pika-aloitus

### Luo tietokanta migration-skripteistä

#### 1. Käynnistä SQL Server

```bash
# macOS/Linux
./database/scripts/start.sh

# Windows
.\database\scripts\start.ps1

# Tai suoraan docker-compose:lla
docker-compose up -d
```

#### 2. Luo tyhjä tietokanta

```bash
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"
```

#### 3. Aja migration-skriptit

**Skeema** (125 taulua, ~30-60 sekuntia):
```bash
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -i /migrations/000_schema.sql
```

**Lookup-data** (49 taulua, ~200 riviä, ~1-2 sekuntia):  
```bash
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -i /migrations/001_lookup_data.sql
```

**Sample PDFs** (3 test PDF-tiedostoa, valinnainen):
```bash
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -i /migrations/003_sample_pdfs.sql
```

**Tulos:** Tyhjä tietokanta valmiina kehitykseen (skeema + lookup-data + 3 testi-PDF:ää)

---

## Migration-skriptien käyttö

Katso tarkemmat ohjeet: [migrations/README.md](migrations/README.md)

**Pikaohje:**
```bash
# 1. Käynnistä
docker-compose up -d

# 2. Luo kanta
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"

# 3. Lataa skeema + data
docker exec caruna-db bash -c "
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' \
    -C -d Fortum -i /migrations/000_schema.sql && \
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' \
    -C -d Fortum -i /migrations/001_lookup_data.sql && \
  /opt/mssql-tools18/bin/sqlcmd -S localhost -U SA -P 'DevPassword123!' \
    -C -d Fortum -i /migrations/003_sample_pdfs.sql
"

# 4. Tarkista
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS table_count FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
# Pitäisi näyttää: 125 taulua
```

Tämä lataa 49 lookup-taulun referenssidatan (ALV-prosentit, sopimustyypit jne.).

**Tulos:** Tyhjä tietokantarakenne + lookup-data valmiina (1-2 min)

**Huom:** Tämä ei sisällä business-dataa (sopimuksia, taho, kiinteis töjä). Jos tarvitset tuotantodataa, pyydä DB dump DBA-tiimiltä erikseen.

---

### Yhdistä DBeaver:lla

- Host: `localhost`
- Port: `1433`
- Database: `Fortum`
- User: `SA`
- Password: `DevPassword123!`

## Migration-skriptit (versionhallinnassa)

Tietokantaan oleellinen data on tallennettu SQL-skripteinä:

- **000_schema.sql** - 125 taulua (tietokantarakenne)
- **001_lookup_data.sql** - 49 lookup-taulua (~200 riviä, ALV%, sopimustyypit jne.)
- **003_sample_pdfs.sql** - 3 testi-PDF:ää (testimukaista dataa)

**Generoi uudelleen (jos skeema muuttuu):**
```bash
python3 database/scripts/generate_schema.py   # 000_schema.sql
python3 database/scripts/generate_inserts.py  # 001_lookup_data.sql
python3 database/scripts/upload_pdfs.py       # 003_sample_pdfs.sql (vaatii PDF-exportin ensin)
```

Katso: [migrations/README.md](migrations/README.md)

## Usein Kysytyt Kysymykset (FAQ)

### Riittääkö migration-skriptit kehitykseen?

**Kyllä**, jos:
- ✅ Tarvitset vain skeeman ja lookup-datan
- ✅ Generoit testidata itse tai käytät mockit
- ✅ Testat sovelluksen logiikkaa (ei tuotantodataa)

**Ei**, jos:
- ❌ Tarvitset oikean production-datan debuggaukseen
- ❌ Haluat nähdä oikeat asiakkaat, sopimukset, kiinteistöt
- ❌ Tarvitset PDF-tulosteet

**Ratkaisu**: Pyydä DB dump DBA-tiimiltä erikseen (ei versionhallinnassa).

### Miksi "Cannot open database Fortum" -virhe?

Tietokantaa ei ole luotu. Aja ensin:
```bash
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"
```

### Port 1433 on jo käytössä, mitä teen?

```bash
# Näytä käytössä olevat containerit portissa 1433
docker ps --filter "publish=1433"

# Sammuta automaattisesti start.sh:lla
./database/scripts/start.sh

# Tai sammuta käsin
docker stop <container-id>
```

### Mihin salaisuudet sijoitan?

Älä koskaan commitaa tuotannon salaisuuksia! Käytä:
- **Lokaalisti**: `.env` tiedostoa (lisää `.gitignore`-tiedostoon)
- **Tuotannossa**: Azure Key Vault, GitHub Secrets
- **Kehityksessä**: Oletussalasana `DevPassword123!` on OK

### Miten tarkistan että migration onnistui?

```bash
# Tarkista taulujen määrä (pitäisi olla 125)
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS table_count FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"

# Tarkista lookup-data (esim. ALV-prosentit)
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT * FROM hlp_Alv"
```

Pitäisi näyttää:
```
table_count
-----------
125

Alvprosentti  Kuvaus
------------  ------
24.00         24 %
25.50         25,5 %
```

### Löysin bugin migration-skriptistä, miten korjaan?

**ÄLÄ** muokkaa `.sql`-tiedostoja suoraan! Ne on generoitu.

1. Korjaa Python-generaattoriskripti (`generate_schema.py` tai `generate_inserts.py`)
2. Generoi uudelleen: `python3 database/scripts/generate_schema.py`
3. Testaa migration: Luo FortumTest-tietokanta ja aja skriptit
4. Commitoi sekä Python-skripti että uusi `.sql`-tiedosto

### Onko Foreign Key -rajoitteet mukana?

⚠️ **Ei vielä**. Generoidussa `000_schema.sql` on:
- ✅ PRIMARY KEY -rajoitteet
- ✅ IDENTITY-sarakkeet
- ✅ NULL/NOT NULL -rajoitteet
- ✅ DEFAULT-arvot
- ❌ FOREIGN KEY -rajoitteet (TODO)
- ❌ Non-PK INDEX-määritykset (TODO)
- ❌ TRIGGERit ja VIEWit (TODO)

## Lisätietoja

Katso kattava dokumentaatio:
- [docs/tietokannan_kehitysymparisto.md](../docs/tietokannan_kehitysymparisto.md)
