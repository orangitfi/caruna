# Caruna Sopimusrekisteri - Tietokannan kehitysympäristö

## Yleiskatsaus

Tietokanta kehitysympäristössä rakennetaan migration-skripteistä:

- **Docker SQL Server 2022** (nopea pystytys, ilmainen Developer Edition)
- **Migration-skriptit** (150 KB, versionhallinnassa)
- **Automaattinen porttikonfliktin käsittely** (sammuttaa muut SQL Server -kontit)

**Migration-skriptit sisältävät:**
- 125 taulua (skeema)
- 49 lookup-taulua (~200 riviä ALV-prosentit, statukset jne.)
- 3 test-PDF:ää (testimukaista dataa)

**Jos tarvitset tuotantodataa**, pyydä DBA-tiimiltä erikseen 1.6 GB DB dump (ei versionhallinnassa).

## Arkkitehtuuri

```
┌─────────────────────────────────────────────────────┐
│  Kehittäjän kone                                     │
│                                                      │
│  ┌──────────────────┐      ┌────────────────────┐  │
│  │  Visual Studio / │─────▶│  Docker Desktop    │  │
│  │  VS Code         │      │                    │  │
│  └──────────────────┘      │  ┌──────────────┐  │  │
│                            │  │ SQL Server   │  │  │
│  ┌──────────────────┐      │  │ 2022         │  │  │
│  │  DBeaver /       │─────▶│  │ Port: 1433   │  │  │
│  │  DataGrip / SSMS │      │  └──────────────┘  │  │
│  └──────────────────┘      └────────────────────┘  │
│                                                      │
└─────────────────────────────────────────────────────┘
```

## Projektirakenne

```
caruna/
├── database/
│   ├── migrations/                # Versionhallinnassa
│   │   ├── 000_schema.sql        # 125 taulua (96 KB)
│   │   ├── 001_lookup_data.sql   # 49 lookup-taulua (53 KB)
│   │   └── 003_sample_pdfs.sql   # 3 test-PDF:ää (5 KB)
│   └── scripts/                   # Apuskriptit
│       ├── start.sh / start.ps1
│       ├── generate_schema.py
│       ├── generate_inserts.py
│       └── generate_sample_pdfs.py
├── docker-compose.yml
└── docs/
    └── tietokannan_kehitysymparisto.md  # Tämä dokumentti
```

## Pika-aloitus (Quick Start)

### Esivalmistelut

1. **Asenna Docker Desktop**
   - macOS: https://www.docker.com/products/docker-desktop
   - Windows: https://www.docker.com/products/docker-desktop
   - Linux: https://docs.docker.com/engine/install/

2. **Varmista Docker toimii**
   ```bash
   docker --version
   docker-compose --version
   ```

### Käynnistys

```bash
# 1. Käynnistä tietokanta (sammuttaa automaattisesti muut SQL Server kontit)
./database/scripts/start.sh        # macOS/Linux
# TAI
.\database\scripts\start.ps1       # Windows PowerShell

# 2. Luo Fortum-tietokanta
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"

# 3. Aja migration-skriptit
docker exec -i caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  < database/migrations/000_schema.sql

docker exec -i caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  < database/migrations/001_lookup_data.sql

docker exec -i caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  < database/migrations/003_sample_pdfs.sql

# Valmis! Yhdistä DBeaver:lla localhost:1433
```

**Huom:** `start.sh` / `start.ps1` sammuttaa automaattisesti muut SQL Server -kontit (esim. LähiTapiola) jotka käyttävät porttia 1433, joten voit vaihtaa projektien välillä helposti.

## docker-compose.yml

Tiedosto on jo projektin juuressa. Sisältö:

```yaml
version: '3.8'

services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: caruna-db
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=DevPassword123!
      - MSSQL_PID=Developer
      - MSSQL_COLLATION=Finnish_Swedish_CI_AS
    ports:
      - "1433:1433"
    volumes:
      # Migration-skriptit (read-only)
      - ./database/migrations:/migrations:ro
      # Pysyvä data (Docker volume)
      - sqldata:/var/opt/mssql/data
    healthcheck:
      test: /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "DevPassword123!" -C -Q "SELECT 1" || exit 1
      interval: 10s
      timeout: 5s
      retries: 10
      start_period: 30s
    networks:
      - caruna-network
    user: "0:0"

networks:
  caruna-network:
    driver: bridge

volumes:
  sqldata:
    driver: local
```

## DBeaver-yhteys

### Uuden yhteyden luominen

1. **Database → New Database Connection**
2. **Valitse:** SQL Server
3. **Connection settings:**
   ```
   Host:           localhost
   Port:           1433
   Database:       Fortum
   Authentication: SQL Server Authentication
   Username:       SA
   Password:       DevPassword123!
   ```
4. **Driver properties** (tärkeä!):
   - `TrustServerCertificate` = `true`
5. **Test Connection** → Pitäisi näyttää "Connected"
6. **Finish**

### JDBC Driver

Jos yhteys ei toimi:
1. DBeaver → Database → Driver Manager → SQL Server
2. Download/Update drivers
3. Valitse "Microsoft SQL Server" (ei jTDS)

### Connection String sovellukselle

Päivitä `slnSopimusrekisteri/appSopimusrekisteri/Web.config`:

```xml
<connectionStrings>
  <add name="FortumEntities" 
       connectionString="metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;
                        provider=System.Data.SqlClient;
                        provider connection string=&quot;
                        Data Source=localhost,1433;
                        Initial Catalog=Fortum;
                        User ID=SA;
                        Password=DevPassword123!;
                        MultipleActiveResultSets=True;
                        TrustServerCertificate=True;
                        App=EntityFramework&quot;" 
       providerName="System.Data.EntityClient" />
  
  <add name="DefaultConnection" 
       providerName="System.Data.SqlClient" 
       connectionString="Data Source=localhost,1433;
                        Initial Catalog=Fortum;
                        User ID=SA;
                        Password=DevPassword123!;
                        TrustServerCertificate=True;" />
</connectionStrings>
```

**Huom:** `TrustServerCertificate=True` tarvitaan kehitysympäristössä Docker-yhteydelle.

## Työnkulku: Projektien välillä vaihtaminen

Jos työskentelet useissa projekteissa jotka käyttävät SQL Server:iä portissa 1433 (esim. Caruna ja LähiTapiola), käytä start-skriptejä:

### Caruna-projektin aloitus

```bash
# macOS/Linux
./database/scripts/start.sh

# Windows
.\database\scripts\start.ps1
```

**Mitä skripti tekee:**
1. 🔍 Etsii muut SQL Server -kontit portissa 1433
2. 🛑 Sammuttaa löydetyt kontit (esim. `lahitapiola-db`)
3. 🚀 Käynnistää `caruna-db`:n
4. ⏳ Odottaa että SQL Server on valmis
5. ✅ Kertoo yhteysohjeet

### Toisen projektin aloitus

Kun haluat vaihtaa toiseen projektiin, aja sen start-skripti samalla tavalla:

```bash
# Esimerkki: Vaihda LähiTapiola-projektiin
cd ../lahitapiola
./database/scripts/start.sh  # Sammuttaa caruna-db:n ja käynnistää lahitapiola-db:n
```

**Vinkki:** Voit kirjoittaa aliakset shell-profiiliisi (~/.zshrc tai ~/.bashrc):

```bash
alias caruna-db='cd ~/Projects/caruna && ./database/scripts/start.sh'
alias lt-db='cd ~/Projects/lahitapiola && ./database/scripts/start.sh'
```

Tämän jälkeen riittää ajaa `caruna-db` tai `lt-db` vaihtaaksesi projektia.

## Docker-komennot

### Peruskäyttö

```bash
# Käynnistä tietokanta taustalle
docker-compose up -d

# Pysäytä tietokanta (data säilyy)
docker-compose down

# Pysäytä JA poista kaikki data (VAROITUS!)
docker-compose down -v

# Seuraa logeja reaaliajassa
docker-compose logs -f sqlserver

# Tarkista kontin tila
docker-compose ps

# Avaa SQL-komentorivi kontissa
docker exec -it caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C
```

### SQL-kyselyitä komentorivillä

```bash
# Taulujen määrä
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS Tables FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'"

# Tietokannan koko
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT name, size*8/1024 AS SizeMB FROM sys.database_files"

# Lookup-datan rivimäärä
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) AS LookupRows FROM hlp_AlvProsentti"
```

## Migration-skriptien generointi

Jos haluat päivittää migration-skriptit (esim. skeema muuttunut):

### Python-generaattorit (suositeltu)

```bash
# Vaatii: pyodbc
pip install pyodbc

# Generoi kaikki 3 skriptiä
python3 database/scripts/generate_schema.py       # 000_schema.sql
python3 database/scripts/generate_inserts.py      # 001_lookup_data.sql
python3 database/scripts/generate_sample_pdfs.py  # 003_sample_pdfs.sql
```

## Vianmääritys

### SQL Server ei käynnisty

```bash
# Tarkista logit
docker-compose logs sqlserver

# Yleisimmät ongelmat:
# 1. SA-salasana liian heikko
#    → Muuta docker-compose.yml: SA_PASSWORD (min 8 merkkiä, isot/pienet/numerot)
# 
# 2. Portti 1433 jo käytössä
#    → macOS/Linux: lsof -i :1433
#    → Windows: netstat -an | findstr 1433
#    → Muuta docker-compose.yml: "1434:1433"
#
# 3. Liian vähän muistia
#    → Docker Desktop → Settings → Resources → Memory: 4 GB
```

### Yhteys ei toimi

```bash
# Tarkista että kontti on käynnissä
docker ps | grep caruna-db

# Testaa yhteys kontin sisältä
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -Q "SELECT 1"

# Jos toimii kontista mutta ei ulkoa:
# - Tarkista firewall
# - Tarkista Docker port mapping: docker ps
# - DBeaver: Lisää TrustServerCertificate=true
```

### Migration-skriptit eivät toimi

```bash
# Varmista että Fortum-kanta on olemassa
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "SELECT name FROM sys.databases"

# Jos ei ole, luo se
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "CREATE DATABASE Fortum COLLATE Finnish_Swedish_CI_AS"

# Aja skriptit uudelleen (katso Pika-aloitus)
```

### Sovellus ei näytä dataa

```bash
# 1. Tarkista että Fortum-kanta on olemassa
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C \
  -Q "SELECT name FROM sys.databases"

# 2. Tarkista taulujen määrä (pitäisi olla 125+)
docker exec caruna-db /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -C -d Fortum \
  -Q "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES"

# 3. Tarkista Web.config connection string
# 4. Tarkista että TrustServerCertificate=True on lisätty
```

### Entity Framework -virhe

```
The model backing the 'FortumEntities' context has changed since the database was created.
```

**Syy:** Koodin DataModel.edmx ei täsmää tietokannan rakenteeseen.

**Ratkaisu:**
1. Tarkista että käytät oikeaa Git-haaraa (main/dev)
2. Aja SQL-päivitysskriptit: `slnSopimusrekisteri/appSopimusrekisteri/SQL/*.sql`
3. TAI regeneroi Entity Framework -malli Visual Studiossa

### Docker volumet vievät tilaa

```bash
# Tarkista volume-koko
docker system df -v

# Poista käyttämättömät volumet
docker volume prune

# Poista caruna-db volume (VAROITUS: Menetät kaiken datan!)
docker-compose down -v
```

## Tietoturva

### Kehitysympäristö vs Tuotanto

**Tämä Docker-setup on VAIN kehityskäyttöön!**

| Asetus | Kehitys | Tuotanto |
|--------|---------|----------|
| Salasana | DevPassword123! | Vahva, monimutkainen |
| Autentikaatio | SQL Server Auth | Windows Authentication |
| Portti | Julkinen (1433) | Firewall-suojattu |
| TLS/SSL | Self-signed (trust) | Virallinen sertifikaatti |
| Backup | Migration-skriptit | Automaattinen, offsite |
| Monitoring | Ei | Kyllä (logs, metrics, alerts) |

### Tuotantoon siirtyminen

Tuotannossa:
- Käytä oikeaa SQL Server -instanssia (ei Docker)
- Windows-autentikaatio connection stringeissä
- Automaattiset backupit ja monitoring

## Lisätietoja

- [database/README.md](../database/README.md) - Migration-skriptien käyttö
- [database/migrations/README.md](../database/migrations/README.md) - Migr aatioiden yksityiskohdat
- [database/scripts/README.md](../database/scripts/README.md) - Apuskriptien dokumentaatio


**Mitä skripti tekee:**
1. 🔍 Etsii muut SQL Server -kontit portissa 1433
2. 🛑 Sammuttaa löydetyt kontit (esim. `lahitapiola-db`)
3. 🚀 Käynnistää `caruna-db`:n
4. ⏳ Odottaa että SQL Server on valmis
5. ✅ Kertoo yhteysohjeet tai tarvittavan restore-komennon

### Toisen projektin aloitus

Kun haluat vaihtaa toiseen projektiin, aja sen start-skripti samalla tavalla:

```bash
# Esimerkki: Vaihda LähiTapiola-projektiin
cd ../lahitapiola
./database/scripts/start.sh  # Sammuttaa caruna-db:n ja käynnistää lahitapiola-db:n
```

**Vinkki:** Voit kirjoittaa aliakset shell-profiiliisi (~/.zshrc tai ~/.bashrc):

```bash
alias caruna-db='cd ~/Projects/caruna && ./database/scripts/start.sh'
alias lt-db='cd ~/Projects/lahitapiola && ./database/scripts/start.sh'
```

Tämän jälkeen riittää ajaa `caruna-db` tai `lt-db` vaihtaaksesi projektia.

## Docker-komennot

### Peruskäyttö

```bash
# Käynnistä tietokanta taustalle
docker-compose up -d

# Pysäytä tietokanta (data säilyy)
docker-compose down

# Pysäytä JA poista kaikki data (VAROITUS!)
docker-compose down -v

# Seuraa logeja reaaliajassa
docker-compose logs -f sqlserver

# Tarkista kontin tila
docker-compose ps

# Avaa SQL-komentorivi kontissa
docker exec -it caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!'
```

### SQL-kyselyitä komentorivillä

```bash
# Taulujen määrä
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -d Fortum \
  -Q "SELECT COUNT(*) AS Tables FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'"

# Tietokannan koko
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -d Fortum \
  -Q "SELECT name, size*8/1024 AS SizeMB FROM sys.database_files"

# Sopimusten määrä
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -d Fortum \
  -Q "SELECT COUNT(*) AS Sopimuksia FROM Sopimus"
```

### Oman backupin luominen

```bash
# Luo uusi backup kontissa
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' \
  -Q "BACKUP DATABASE Fortum TO DISK='/backup/Fortum_$(date +%Y%m%d).bak' WITH COMPRESSION"

# Kopioi backup ulos kontista
docker cp caruna-db:/backup/Fortum_20260407.bak ./database/backup/
```

## Migration-skriptien generointi

Jos haluat luoda omat migration-skriptit täydestä backupista (valinnainen):

### mssql-scripter (suositeltu, cross-platform)

```bash
# Asenna (vaatii Python 3)
pip install mssql-scripter

# Käynnistä Docker ja palauta backup
docker-compose up -d
./database/scripts/restore.sh

# Generoi skeema ilman dataa
mssql-scripter -S localhost -d Fortum -U SA -P 'DevPassword123!' \
  --schema-only \
  --exclude-objects aspnet_* sysdiagrams \
  > database/migrations/001_initial_schema.sql

# Generoi apuarvotaulujen (hlp_*) data
mssql-scripter -S localhost -d Fortum -U SA -P 'DevPassword123!' \
  --data-only \
  --include-objects "hlp_*" \
  > database/migrations/002_lookup_data.sql
```

### SQL Server Management Studio (SSMS)

1. Yhdistä Docker-kantaan: `localhost,1433`
2. Right-click **Fortum** → Tasks → **Generate Scripts**
3. Choose Objects → Select specific database objects
   - **Poista:** aspnet_* (membership), sysdiagrams
4. Set Scripting Options → Advanced:
   - Types of data to script: **Schema only**
5. Save: `database/migrations/001_initial_schema.sql`

### DBeaver

1. Yhdistä kantaan
2. Database Navigator → Fortum → Tables
3. Valitse taulut (Ctrl+Click, poista aspnet_*)
4. Right-click → **Generate SQL** → **DDL**
5. Save: `database/migrations/001_initial_schema.sql`

Data:
1. Valitse apuarvotaulut (hlp_*)
2. Right-click → **Export Data** → Format: **SQL INSERT**
3. Save: `database/migrations/002_lookup_data.sql`

## Vianmääritys

### SQL Server ei käynnisty

```bash
# Tarkista logit
docker-compose logs sqlserver

# Yleisimmät ongelmat:
# 1. SA-salasana liian heikko
#    → Muuta docker-compose.yml: SA_PASSWORD (min 8 merkkiä, isot/pienet/numerot)
# 
# 2. Portti 1433 jo käytössä
#    → macOS/Linux: lsof -i :1433
#    → Windows: netstat -an | findstr 1433
#    → Muuta docker-compose.yml: "1434:1433"
#
# 3. Liian vähän muistia
#    → Docker Desktop → Settings → Resources → Memory: 4 GB
```

### Yhteys ei toimi

```bash
# Tarkista että kontti on käynnissä
docker ps | grep caruna-db

# Testaa yhteys kontin sisältä
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -Q "SELECT 1"

# Jos toimii kontista mutta ei ulkoa:
# - Tarkista firewall
# - Tarkista Docker port mapping: docker ps
# - DBeaver: Lisää TrustServerCertificate=true
```

### Restore epäonnistuu

```bash
# Tarkista backup-tiedoston sijainti
docker exec caruna-db ls -lh /backup/

# Tarkista backup-tiedoston sisältö
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' \
  -Q "RESTORE FILELISTONLY FROM DISK='/backup/Fortum_20260402.bak'"

# Virhe: "Backup set was created by a different version"
# → Backup on uudemmasta SQL Server -versiosta
# → Käytä uudempaa Docker image:
#   docker-compose.yml: image: mcr.microsoft.com/mssql/server:2022-latest
```

### Sovellus ei näytä dataa

```bash
# 1. Tarkista että Fortum-kanta on olemassa
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' \
  -Q "SELECT name FROM sys.databases"

# 2. Tarkista taulujen määrä
docker exec caruna-db /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U SA -P 'DevPassword123!' -d Fortum \
  -Q "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES"

# 3. Tarkista Web.config connection string
# 4. Tarkista että TrustServerCertificate=True on lisätty
```

### Entity Framework -virhe

```
The model backing the 'FortumEntities' context has changed since the database was created.
```

**Syy:** Koodin DataModel.edmx ei täsmää tietokannan rakenteeseen.

**Ratkaisu:**
1. Tarkista että käytät oikeaa Git-haaraa (main/dev)
2. Aja SQL-päivitysskriptit: `slnSopimusrekisteri/appSopimusrekisteri/SQL/*.sql`
3. TAI regeneroi Entity Framework -malli Visual Studiossa

### Docker volumet vievät tilaa

```bash
# Tarkista volume-koko
docker system df -v

# Poista käyttämättömät volumet
docker volume prune

# Poista caruna-db volume (VAROITUS: Menetät kaiken datan!)
docker-compose down -v
```

## Tietoturva

### Kehitysympäristö vs Tuotanto

**Tämä Docker-setup on VAIN kehityskäyttöön!**

| Asetus | Kehitys | Tuotanto |
|--------|---------|----------|
| Salasana | DevPassword123! | Vahva, monimutkainen |
| Autentikaatio | SQL Server Auth | Windows Authentication |
| Portti | Julkinen (1433) | Firewall-suojattu |
| TLS/SSL | Self-signed (trust) | Virallinen sertifikaatti |
| Backup | Manuaalinen | Automaattinen, offsite |
| Monitoring | Ei | Kyllä (logs, metrics, alerts) |

### Tuotantoon siirtyminen

Tuotannossa:
- Käytä oikeaa SQL Server -instanssia (ei Docker)
- Windows-autentikaatio connection stringeissä
- Ks. [tietokannan_palautus.md](tietokannan_palautus.md)

## Tietokantarakenne

### Päätaulut

- **Sopimus** - Sopimusrekisterin päätaulu
- **Henkilo** - Henkilötiedot
- **Kiinteisto** - Kiinteistötiedot
- **Aktiviteetti** - Tapahtumahistoria
- **Tiedosto** - Viitteet M-Files/SharePoint-dokumentteihin

### Apuarvotaulut (hlp_*)

- **hlp_Indeksi** - Indeksityypit
- **hlp_AktiviteetinLaji** - Aktiviteettityypit
- **hlp_Asiakastyyppi** - Asiakastyypit
- Jne. (60+ apuarvotaulua)

### ASP.NET Membership

- **aspnet_Users** - Käyttäjät
- **aspnet_Roles** - Roolit
- **aspnet_Membership** - Salasanat
- Jne. (ASP.NET membership -taulut)

### Binääridatan sisältö

Tietokanta sisältää binäärikenttiä:
- `aspnet_*.PageSettings` (image) - Web Parts -personalisointi
- Jokin `STLTuloste` (varbinary) - Generoidut raportit

**Ei kriittistä kehitykseen** - migration-skripteissä voi jättää tyhjiksi.

## Lisätietoja

### Dokumentaatio

- [Caruna Sopimusrekisteri ohjeistus](caruna_sopimusrekisteri_ohjeistus.md)
- [Tietokannan palautus tuotantoon](tietokannan_palautus.md)
- [Tietokannan automaattinen palautus](tietokannan_automaattinen_palautus.md) - Custom Docker image joka restoraa automaattisesti

### Ulkoiset resurssit

- [Docker SQL Server Documentation](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker)
- [mssql-scripter GitHub](https://github.com/microsoft/mssql-scripter)
- [DBeaver Documentation](https://dbeaver.io/docs/)
- [Entity Framework 6](https://learn.microsoft.com/en-us/ef/ef6/)

---

**Kysymyksiä?** Ota yhteyttä projektin ylläpitäjiin tai avaa issue GitHubissa.
