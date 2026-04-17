-- Database Schema (DDL)
-- CREATE TABLE statements for Fortum database
-- Generated from SQL Server 2022
-- Total tables: 125

SET NOCOUNT ON;
GO

-- Table: _access
CREATE TABLE [dbo].[_access] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Id] FLOAT NULL,
    [MmoNro] NVARCHAR(255) NULL,
    [CContractNumber] NVARCHAR(255) NULL,
    [ContractType] FLOAT NULL,
    [DescrContractTypeDescr] NVARCHAR(255) NULL,
    [OldCOntractNumber] NVARCHAR(255) NULL,
    [MmoNimi] NVARCHAR(255) NULL,
    [MmoOsoite] NVARCHAR(255) NULL,
    [Commune] FLOAT NULL,
    [DescrCommuneDescr] NVARCHAR(255) NULL,
    [MmoKyla] NVARCHAR(255) NULL,
    [MmoTontti] NVARCHAR(255) NULL,
    [NameSop] NVARCHAR(255) NULL,
    [Name] NVARCHAR(255) NULL,
    [Address] NVARCHAR(255) NULL,
    [ZipCode] NVARCHAR(255) NULL,
    [PostalAddress] NVARCHAR(255) NULL,
    [StartDate] DATETIME NULL,
    [EndDate] DATETIME NULL,
    [Duration] NVARCHAR(255) NULL,
    [SopJatkoAika] NVARCHAR(255) NULL,
    [SopIrtisanAika] NVARCHAR(255) NULL,
    [SopPintaAla] FLOAT NULL,
    [SopHetkenVuokraEUR] FLOAT NULL,
    [PaymentMode] FLOAT NULL,
    [DescrPaymentModeDescr] NVARCHAR(255) NULL,
    [AlkuIndeksi] FLOAT NULL,
    [VViimIndeksi] FLOAT NULL,
    [ViimIndeksiKK] FLOAT NULL,
    [SopIndexId] FLOAT NULL,
    [SopIndexDescr] NVARCHAR(255) NULL,
    [MaksuKK] FLOAT NULL,
    [DescrMonth_1Descr] NVARCHAR(255) NULL,
    [PayDate] DATETIME NULL,
    [Field1] DATETIME NULL,
    [Payment] FLOAT NULL,
    [PaymentAlv] FLOAT NULL,
    [BankAccount] NVARCHAR(255) NULL,
    [OmIlmViiteNro] NVARCHAR(255) NULL,
    [ViiteNroVoimassa] NVARCHAR(255) NULL,
    [OrigContractSigner] NVARCHAR(255) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [SOPMAININTA] NVARCHAR(255) NULL,
    [SOPMAINITTUY] NVARCHAR(255) NULL,
    [SOPMAINITTUAS] NVARCHAR(255) NULL,
    [SOPMAINITTUSYS] NVARCHAR(255) NULL,
    [SopTila] FLOAT NULL,
    [SopTilaDescr] NVARCHAR(255) NULL,
    [MaksuTiedotSaatu] NVARCHAR(255) NULL,
    [SopKasittelyssa] NVARCHAR(255) NULL,
    [KiinteistoVerotettu] FLOAT NULL,
    [Muokkauspvm] DATETIME NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [AlvId] FLOAT NULL,
    [AlvDescr] NVARCHAR(255) NULL,
    [AlvValue] FLOAT NULL,
    [CompanyId] FLOAT NULL,
    [DescrCompanyDescr] NVARCHAR(255) NULL,
    [ResponsId] FLOAT NULL,
    [DescrResponsDescr] NVARCHAR(255) NULL,
    [OikeaSopindeksi] NVARCHAR(255) NULL,
    [LastPayDate] DATETIME NULL,
    [PaymentWayId] FLOAT NULL,
    [DescrPaymentWayDescr] NVARCHAR(255) NULL,
    [Y_tunnus] NVARCHAR(255) NULL,
    [Liitekartat] NVARCHAR(255) NULL,
    [OrigRecordLoc] NVARCHAR(255) NULL,
    [CopyRecordLoc] NVARCHAR(255) NULL,
    [AkuAnkka] FLOAT NULL,
    [ArchieveID] NVARCHAR(255) NULL,
    [Lisaaja] NVARCHAR(255) NULL,
    [Lisayspvm] DATETIME NULL,
    [Rowlock] FLOAT NULL,
    [Rowlock_locker] NVARCHAR(255) NULL,
    [Account_for_Lessee_Payments_Fina_Companies] NVARCHAR(255) NULL,
    [Account_for_Lessee_Payments_NonFina_Companies] NVARCHAR(255) NULL,
    [Internal_Counterparty] BIT NOT NULL,
    [Counterparty_entity] NVARCHAR(255) NULL,
    [Lease_Object_Asset] NVARCHAR(255) NULL,
    [Asset_Group] NVARCHAR(255) NULL,
    [Contract_nr_in_other_software] NVARCHAR(255) NULL,
    [Concessions] NVARCHAR(255) NULL,
    [MoneyCurrency] NVARCHAR(255) NULL,
    [Contract_Term] NVARCHAR(255) NULL,
    [Renewal_Option] BIT NOT NULL,
    [Extension_date] NVARCHAR(255) NULL,
    [Useful_life_shorter_longer_than_lease_term] BIT NOT NULL,
    [Useful_life_of_the_leased_asset] NVARCHAR(255) NULL,
    [Estimated_Market_Value] NVARCHAR(255) NULL,
    [Residual_Value_Guarantee] BIT NOT NULL,
    [Known_Payment_Period] NVARCHAR(255) NULL,
    [Unknown_Payment_Period] NVARCHAR(255) NULL,
    [Term_Option_Penalties] BIT NOT NULL,
    [Term_Option_Penalties_Amount] NVARCHAR(255) NULL,
    [_sopimusId] INT NULL
);
GO

-- Table: _access_uusi
CREATE TABLE [dbo].[_access_uusi] (
    [Id] FLOAT NULL,
    [MmoNro] NVARCHAR(255) NULL,
    [CContractNumber] NVARCHAR(255) NULL,
    [ContractType] FLOAT NULL,
    [DescrContractType_Descr] NVARCHAR(255) NULL,
    [OldCOntractNumber] NVARCHAR(255) NULL,
    [MmoNimi] NVARCHAR(255) NULL,
    [MmoOsoite] NVARCHAR(255) NULL,
    [Commune] NVARCHAR(255) NULL,
    [DescrCommune_Descr] NVARCHAR(255) NULL,
    [MmoKyla] NVARCHAR(255) NULL,
    [MmoTontti] NVARCHAR(255) NULL,
    [NameSop] NVARCHAR(255) NULL,
    [Name] NVARCHAR(255) NULL,
    [Address] NVARCHAR(255) NULL,
    [ZipCode] NVARCHAR(255) NULL,
    [PostalAddress] NVARCHAR(255) NULL,
    [StartDate] DATETIME NULL,
    [EndDate] DATETIME NULL,
    [Duration] NVARCHAR(255) NULL,
    [SopJatkoAika] NVARCHAR(255) NULL,
    [SopIrtisanAika] NVARCHAR(255) NULL,
    [SopPintaAla] FLOAT NULL,
    [SopHetkenVuokraEUR] FLOAT NULL,
    [PaymentMode] FLOAT NULL,
    [DescrPaymentMode_Descr] NVARCHAR(255) NULL,
    [AlkuIndeksi] FLOAT NULL,
    [VViimIndeksi] FLOAT NULL,
    [ViimIndeksiKK] FLOAT NULL,
    [SopIndexId] FLOAT NULL,
    [SopIndexDescr] NVARCHAR(255) NULL,
    [MaksuKK] FLOAT NULL,
    [DescrMonth_1_Descr] NVARCHAR(255) NULL,
    [PayDate] DATETIME NULL,
    [Payment] FLOAT NULL,
    [PaymentAlv] FLOAT NULL,
    [BankAccount] NVARCHAR(255) NULL,
    [OmIlmViiteNro] NVARCHAR(255) NULL,
    [ViiteNroVoimassa] NVARCHAR(255) NULL,
    [OrigContractSigner] NVARCHAR(255) NULL,
    [Remark] NVARCHAR(MAX) NULL,
    [SOPMAININTA] NVARCHAR(255) NULL,
    [SOPMAINITTUY] NVARCHAR(255) NULL,
    [SOPMAINITTUAS] NVARCHAR(255) NULL,
    [SOPMAINITTUSYS] NVARCHAR(255) NULL,
    [SopTila] FLOAT NULL,
    [SopTilaDescr] NVARCHAR(255) NULL,
    [MaksuTiedotSaatu] NVARCHAR(255) NULL,
    [SopKasittelyssa] NVARCHAR(255) NULL,
    [KiinteistoVerotettu] NVARCHAR(255) NULL,
    [Muokkauspvm] DATETIME NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [AlvId] FLOAT NULL,
    [AlvDescr] NVARCHAR(255) NULL,
    [AlvValue] FLOAT NULL,
    [CompanyId] FLOAT NULL,
    [DescrCompany_Descr] NVARCHAR(255) NULL,
    [ResponsId] FLOAT NULL,
    [DescrRespons_Descr] NVARCHAR(255) NULL,
    [OikeaSopindeksi] NVARCHAR(255) NULL,
    [LastPayDate] DATETIME NULL,
    [PaymentWayId] FLOAT NULL,
    [DescrPaymentWay_Descr] NVARCHAR(255) NULL,
    [Y_tunnus] NVARCHAR(255) NULL,
    [Liitekartat] NVARCHAR(255) NULL,
    [OrigRecordLoc] NVARCHAR(255) NULL,
    [CopyRecordLoc] NVARCHAR(255) NULL,
    [AkuAnkka] NVARCHAR(255) NULL,
    [ArchieveID] NVARCHAR(255) NULL,
    [Lisaaja] NVARCHAR(255) NULL,
    [Lisayspvm] DATETIME NULL,
    [Rowlock] FLOAT NULL,
    [Rowlock_locker] NVARCHAR(255) NULL,
    [Account_for_Lessee_Payments_Fina_Companies] NVARCHAR(255) NULL,
    [Account_for_Lessee_Payments_NonFina_Companies] NVARCHAR(255) NULL,
    [Internal_Counterparty] BIT NOT NULL,
    [Counterparty_entity] NVARCHAR(255) NULL,
    [Lease_Object_Asset] NVARCHAR(255) NULL,
    [Asset_Group] NVARCHAR(255) NULL,
    [Contract_nr_in_other_software] NVARCHAR(255) NULL,
    [Concessions] NVARCHAR(255) NULL,
    [MoneyCurrency] NVARCHAR(255) NULL,
    [Contract_Term] NVARCHAR(255) NULL,
    [Renewal_Option] BIT NOT NULL,
    [Extension_date] NVARCHAR(255) NULL,
    [Useful_life_shorter_longer_than_lease_term] BIT NOT NULL,
    [Useful_life_of_the_leased_asset] NVARCHAR(255) NULL,
    [Estimated_Market_Value] NVARCHAR(255) NULL,
    [Residual_Value_Guarantee] BIT NOT NULL,
    [Known_Payment_Period] NVARCHAR(255) NULL,
    [Unknown_Payment_Period] NVARCHAR(255) NULL,
    [Term_Option_Penalties] BIT NOT NULL,
    [Term_Option_Penalties_Amount] NVARCHAR(255) NULL,
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [_sopimusId] INT NULL,
    [_vahvistettuSopimusId] INT NULL,
    [_sopimusPaivitetaan] BIT NULL,
    [_duration] INT NULL,
    [_irtisanomisaika] INT NULL,
    [_kiinteistoId] INT NULL,
    [_kiinteistoPaivitetaan] BIT NULL,
    [_kortteli] INT NULL,
    [_tontti] INT NULL,
    [_tahoId] INT NULL,
    [_tahoPaivitetaan] BIT NULL,
    [_iban] VARCHAR(50) NULL,
    [_bic] VARCHAR(50) NULL,
    [_tunnisteyksikkoId] INT NULL,
    [_tunnisteyksikkoPaivitetaan] BIT NULL,
    [_korvauslaskelmaId] INT NULL,
    [_korvauslaskelmaPaivitetaan] BIT NULL,
    [_korvauslaskelmariviId] INT NULL,
    [_korvauslaskelmariviPaivitetaan] BIT NULL
);
GO

-- Table: _JAS
CREATE TABLE [dbo].[_JAS] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [ID] INT NOT NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] NVARCHAR(255) NULL,
    [Sopimuksen paattymisajankohta] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tila] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL,
    [öArkistonmuodostaja] NVARCHAR(255) NULL,
    [öAsiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [öAsiakirjatyyppi] NVARCHAR(255) NULL,
    [öAsiasanat] NVARCHAR(255) NULL,
    [öHävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [öHävityksen suorittaja] NVARCHAR(255) NULL,
    [öHävityspäivämäärä] DATETIME NULL,
    [öHävitystapa] NVARCHAR(255) NULL,
    [öKohdetunnus] NVARCHAR(255) NULL,
    [öKäyttörajoitukset] NVARCHAR(255) NULL,
    [öLiitteet] NVARCHAR(255) NULL,
    [öLähetystiedot] NVARCHAR(255) NULL,
    [öMetatiedot] NVARCHAR(255) NULL,
    [öOn kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [öOikeudet] NVARCHAR(255) NULL,
    [öOrganisaatio] NVARCHAR(255) NULL,
    [öOtsikko] NVARCHAR(255) NULL,
    [öRinnakkaisnimeke] NVARCHAR(255) NULL,
    [öSaapumistiedot] NVARCHAR(255) NULL,
    [öSisältölaji] NVARCHAR(255) NULL,
    [öSopimuksen Irtisanomisajankohta] NVARCHAR(255) NULL,
    [öSähköinen allekirjoitus] BIT NOT NULL,
    [öSähköinen formaatti] NVARCHAR(255) NULL,
    [öSähköinen tiedoksianto ennen hävittämistä] NVARCHAR(255) NULL,
    [öSähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [öSäilytysaika] NVARCHAR(255) NULL,
    [öSäilytyshistoria] NVARCHAR(255) NULL,
    [öTapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [öUloskuittaaja] NVARCHAR(255) NULL,
    [öKohteen tyyppi] NVARCHAR(255) NULL,
    CONSTRAINT [PK__JAS] PRIMARY KEY CLUSTERED ([SQLId])
);
GO

-- Table: _JAS20131220
CREATE TABLE [dbo].[_JAS20131220] (
    [ID] INT NOT NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] FLOAT NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] DATETIME NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] DATETIME NULL,
    [Sopimuksen Irtisanomisajankohta] DATETIME NULL,
    [Sopimuksen paattymisajankohta] DATETIME NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] DATETIME NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] DATETIME NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Uloskuittaaja2] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL
);
GO

-- Table: _Kiinteisto20201125
CREATE TABLE [dbo].[_Kiinteisto20201125] (
    [KIIId] INT IDENTITY(1,1) NOT NULL,
    [KIIKiinteisto] NVARCHAR(300) NULL,
    [KIITahoId] INT NULL,
    [KIIKatuosoite] NVARCHAR(300) NULL,
    [KIIPostitoimipaikka] NVARCHAR(300) NULL,
    [KIIPostinumero] NVARCHAR(50) NULL,
    [KIIMaaId] INT NULL,
    [KIIRekisterinumero] NVARCHAR(300) NULL,
    [KIIKyla] NVARCHAR(300) NULL,
    [KIIKylanumero] INT NULL,
    [KIIKylaId] INT NULL,
    [KIIKunta] NVARCHAR(300) NULL,
    [KIIKuntanumero] INT NULL,
    [KIIKuntaId] INT NULL,
    [KIIKiinteistotunnus] NVARCHAR(300) NULL,
    [KIIKiinteistotunnusLyhyt] NVARCHAR(300) NULL,
    [KIIPintaAla] DECIMAL(18, 2) NULL,
    [KIIMaapintaAla] DECIMAL(18, 2) NULL,
    [KIIVesipintaAla] DECIMAL(18, 2) NULL,
    [KIIKortteli] NVARCHAR(50) NULL,
    [KIITontti] NVARCHAR(50) NULL,
    [KIIMaaraAla] NVARCHAR(50) NULL,
    [KIIMaaraAlaTarkenneId] INT NULL,
    [KIIKiinteistoverotettuVuosi] INT NULL,
    [KIIAssetTunniste] INT NULL,
    [KIIRasitteet] NVARCHAR(MAX) NULL,
    [KIIKiinnitykset] NVARCHAR(MAX) NULL,
    [KIIOmistusosuus] INT NULL,
    [KIIOmistusosuusTotal] INT NULL,
    [KIILiiketoiminnanTarveId] INT NULL,
    [KIISaantoId] INT NULL,
    [KIIInfo] NVARCHAR(500) NULL,
    [KIILuoja] NVARCHAR(50) NULL,
    [KIILuotu] DATETIME NOT NULL,
    [KIIPaivittaja] NVARCHAR(50) NULL,
    [KIIPaivitetty] DATETIME NULL,
    [_kiisqlId] INT NULL,
    [KIIAlueTarkenne] VARCHAR(300) NULL,
    [KIIExcelTuontiId] INT NULL,
    [_SOHATempGuid] UNIQUEIDENTIFIER NULL
);
GO

-- Table: _Kustannuskatalogi
CREATE TABLE [dbo].[_Kustannuskatalogi] (
    [ID] INT NOT NULL,
    [Active] NVARCHAR(255) NULL,
    [Voimassaoloaika] NVARCHAR(255) NULL,
    [Kategoria] NVARCHAR(255) NULL,
    [Alakategoria] NVARCHAR(255) NULL,
    [Korvauslaji] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Maksualue] NVARCHAR(255) NULL,
    [Metsätyyppi] NVARCHAR(255) NULL,
    [Puustolaji] NVARCHAR(255) NULL,
    [Puuston ikä] NVARCHAR(255) NULL,
    [Taimiston valtapituus] NVARCHAR(255) NULL,
    [Tiheyskerroin] NVARCHAR(255) NULL,
    [Yksikköhinta] FLOAT NULL,
    [Korvausyksikkö] NVARCHAR(255) NULL,
    [Yksikköhinnan tarkenne] NVARCHAR(255) NULL
);
GO

-- Table: _maksuhistoria
CREATE TABLE [dbo].[_maksuhistoria] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Id] FLOAT NULL,
    [SopId] FLOAT NULL,
    [MmoNro] NVARCHAR(255) NULL,
    [CContractNumber] NVARCHAR(255) NULL,
    [NameSop] NVARCHAR(255) NULL,
    [Name] NVARCHAR(255) NULL,
    [SopHetkenVuokraEUR] FLOAT NULL,
    [AlkuIndeksi] NVARCHAR(255) NULL,
    [VViimIndeksi] NVARCHAR(255) NULL,
    [SopIndexId] FLOAT NULL,
    [SopIndexDescr] NVARCHAR(255) NULL,
    [MaksuKK] FLOAT NULL,
    [DescrMonthDescr] NVARCHAR(255) NULL,
    [PayDate] DATETIME NULL,
    [Payment] FLOAT NULL,
    [PaymentAlv] FLOAT NULL,
    [BankAccount] NVARCHAR(255) NULL,
    [OmIlmViiteNro] NVARCHAR(255) NULL,
    [ViiteNroVoimassa] NVARCHAR(255) NULL,
    [Muokkauspvm] DATETIME NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [CompanyId] FLOAT NULL,
    [DescrCompanyDescr] NVARCHAR(255) NULL,
    [ResponsId] FLOAT NULL,
    [DescrResponsDescr] NVARCHAR(255) NULL,
    [PaymentWayId] NVARCHAR(255) NULL,
    [DescrPaymentWayDescr] NVARCHAR(255) NULL,
    [Y_tunnus] NVARCHAR(255) NULL,
    [Liitekartat] NVARCHAR(255) NULL,
    [ArchieveID] NVARCHAR(255) NULL,
    [Lisaaja] NVARCHAR(255) NULL,
    [Lisayspvm] NVARCHAR(255) NULL
);
GO

-- Table: _muuntamo
CREATE TABLE [dbo].[_muuntamo] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] FLOAT NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] DATETIME NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] DATETIME NULL,
    [Sopimuksen Irtisanomisajankohta] DATETIME NULL,
    [Sopimuksen paattymisajankohta] DATETIME NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] DATETIME NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] DATETIME NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Uloskuittaaja2] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL
);
GO

-- Table: _rakennus_ja_sijoitusluvat
CREATE TABLE [dbo].[_rakennus_ja_sijoitusluvat] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] FLOAT NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] DATETIME NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] DATETIME NULL,
    [Sopimuksen Irtisanomisajankohta] DATETIME NULL,
    [Sopimuksen paattymisajankohta] DATETIME NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] DATETIME NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] DATETIME NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Uloskuittaaja2] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL
);
GO

-- Table: _sharepoint_uudet20141103
CREATE TABLE [dbo].[_sharepoint_uudet20141103] (
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimus_vuosi] NVARCHAR(255) NULL,
    [SopRekNro] NVARCHAR(255) NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Tunnus] FLOAT NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] NVARCHAR(255) NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] NVARCHAR(255) NULL,
    [Sopimuksen Irtisanomisajankohta] NVARCHAR(255) NULL,
    [Sopimuksen paattymisajankohta] NVARCHAR(255) NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Allekirjoituspvm] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Asiakas] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] NVARCHAR(255) NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tekijä2] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Toimittaja] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [ID] INT NOT NULL,
    [Polku] NVARCHAR(255) NULL,
    [_sopimusId] INT NULL,
    [_tuplaTasmaa] BIT NULL,
    [_siirretaan] BIT NULL,
    [_uusi] BIT NULL,
    [_juridinenYhtio] VARCHAR(50) NULL,
    [_alkuperainenYhtio] VARCHAR(50) NULL,
    [_tyyppi] INT NULL,
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [_sopimusId2] INT NULL
);
GO

-- Table: _SOHAEheytys
CREATE TABLE [dbo].[_SOHAEheytys] (
    [SOPId] FLOAT NULL,
    [SOPAlkaa] NVARCHAR(255) NULL,
    [SOPInfo] NVARCHAR(MAX) NULL,
    [TAHSukunimi] NVARCHAR(MAX) NULL,
    [KIIToiminto] NVARCHAR(255) NULL,
    [KIIKuntanumero] NVARCHAR(255) NULL,
    [KIIKuntanumeroStr] NVARCHAR(255) NULL,
    [KIIKylanumero] NVARCHAR(255) NULL,
    [KIIKyla] NVARCHAR(MAX) NULL,
    [KIIKiinteisto] NVARCHAR(MAX) NULL,
    [KIIRekisterinumero] NVARCHAR(MAX) NULL,
    [TUYToiminto] NVARCHAR(MAX) NULL,
    [TUYTunnisteyksikkoTyyppiId] NVARCHAR(MAX) NULL,
    [TUYPGTunnus] NVARCHAR(MAX) NULL,
    [TUYNimi] NVARCHAR(MAX) NULL,
    [F16] NVARCHAR(255) NULL,
    [SOPAlkaaDate] DATE NULL,
    [TUYTempGuid] UNIQUEIDENTIFIER NULL
);
GO

-- Table: _SOHAEheytys_Kiinteisto
CREATE TABLE [dbo].[_SOHAEheytys_Kiinteisto] (
    [SOPId] FLOAT NULL,
    [KIIToiminto] VARCHAR(MAX) NULL,
    [KIIKuntanumero] VARCHAR(MAX) NULL,
    [KIIKylanumero] VARCHAR(MAX) NULL,
    [KIIKyla] VARCHAR(MAX) NULL,
    [KIIKiinteisto] VARCHAR(MAX) NULL,
    [KIIRekisterinumero] VARCHAR(MAX) NULL,
    [KIITempGuid] UNIQUEIDENTIFIER NULL,
    [KIIUseampi] BIT NOT NULL DEFAULT ((0)),
    [KIIParsittu] BIT NOT NULL DEFAULT ((0)),
    [KIIParsittuNumero] INT NULL,
    [KIIKiinteistoId] INT NULL,
    [KIIOhitaLiianHankala] BIT NOT NULL DEFAULT ((0))
);
GO

-- Table: _SOHAEheytys_Kiinteisto_Useampi
CREATE TABLE [dbo].[_SOHAEheytys_Kiinteisto_Useampi] (
    [SOPId] FLOAT NULL,
    [Sarakenumero] INT NULL,
    [Kuntanumero] VARCHAR(MAX) NULL,
    [Kylanumero] VARCHAR(MAX) NULL,
    [Kyla] VARCHAR(MAX) NULL,
    [Kiinteisto] VARCHAR(MAX) NULL,
    [Rekisterinumero] VARCHAR(MAX) NULL,
    [TempGuid] UNIQUEIDENTIFIER NULL
);
GO

-- Table: _SOHAEheytys_Kunta
CREATE TABLE [dbo].[_SOHAEheytys_Kunta] (
    [KKuntaid] FLOAT NULL,
    [KKunta] NVARCHAR(255) NULL,
    [KKuntaSwe] NVARCHAR(255) NULL,
    [KKuntaNro] NVARCHAR(255) NULL,
    [KPaivittaja] NVARCHAR(255) NULL,
    [KPaivitetty] NVARCHAR(255) NULL,
    [KLuotu] NVARCHAR(255) NULL,
    [KLuoja] NVARCHAR(255) NULL
);
GO

-- Table: _SOHAEheytys_Taho
CREATE TABLE [dbo].[_SOHAEheytys_Taho] (
    [SOPId] FLOAT NULL,
    [TAHTahoId] INT NULL,
    [TAHEtunimi] NVARCHAR(300) NULL,
    [TAHSukunimi] NVARCHAR(300) NULL,
    [TAHTyyppi] INT NULL,
    [TAHTempGuid] UNIQUEIDENTIFIER NULL
);
GO

-- Table: _suostumus
CREATE TABLE [dbo].[_suostumus] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] FLOAT NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] DATETIME NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] DATETIME NULL,
    [Sopimuksen Irtisanomisajankohta] DATETIME NULL,
    [Sopimuksen paattymisajankohta] DATETIME NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] DATETIME NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] DATETIME NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Uloskuittaaja2] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL
);
GO

-- Table: _toimenpide_ja_risteilyluvat
CREATE TABLE [dbo].[_toimenpide_ja_risteilyluvat] (
    [SQLId] INT IDENTITY(1,1) NOT NULL,
    [Yhtiö_Juridinen] NVARCHAR(255) NULL,
    [Metatiedot] NVARCHAR(255) NULL,
    [DocumentID] NVARCHAR(255) NULL,
    [Liittyvät asiakirjat] NVARCHAR(255) NULL,
    [Sopimustunnus] NVARCHAR(255) NULL,
    [Asiakirjatarkenne] NVARCHAR(255) NULL,
    [Sopimusosapuolet] NVARCHAR(255) NULL,
    [Sopimuskohde] NVARCHAR(255) NULL,
    [Kunta] NVARCHAR(255) NULL,
    [Kylä] NVARCHAR(255) NULL,
    [Rekisterinumero] NVARCHAR(255) NULL,
    [Tilan nimi] NVARCHAR(255) NULL,
    [Kiinteistötunnus] NVARCHAR(255) NULL,
    [Piirustustunnus] NVARCHAR(255) NULL,
    [Mappitunniste] NVARCHAR(255) NULL,
    [Uloskuittaaja] NVARCHAR(255) NULL,
    [Tila] NVARCHAR(255) NULL,
    [Korvaa] NVARCHAR(255) NULL,
    [Korvattu] NVARCHAR(255) NULL,
    [Sijainti (fyys)] NVARCHAR(255) NULL,
    [Sivuja] FLOAT NULL,
    [Arkistonmuodostaja] NVARCHAR(255) NULL,
    [Asiakirjan muutos] NVARCHAR(255) NULL,
    [Asiakirjan muutospäivämäärä] NVARCHAR(255) NULL,
    [Asiakirjatyyppi] NVARCHAR(255) NULL,
    [Asiasanat] NVARCHAR(255) NULL,
    [Asiatunnus] NVARCHAR(255) NULL,
    [Document Number] NVARCHAR(255) NULL,
    [Fyysinen formaatti] NVARCHAR(255) NULL,
    [Hävityksen hyväksyjä(t)] NVARCHAR(255) NULL,
    [Hävityksen suorittaja] NVARCHAR(255) NULL,
    [Hävityspäivämäärä] DATETIME NULL,
    [Hävitystapa] NVARCHAR(255) NULL,
    [Julkisuusaste] NVARCHAR(255) NULL,
    [Kieli] NVARCHAR(255) NULL,
    [Kohdetunnus] NVARCHAR(255) NULL,
    [Kuvaus] NVARCHAR(255) NULL,
    [Käyttörajoitukset] NVARCHAR(255) NULL,
    [Laatija/Käsittelijä] NVARCHAR(255) NULL,
    [Laatimispäivämäärä] NVARCHAR(255) NULL,
    [Liitteet] NVARCHAR(255) NULL,
    [Lisätietoa] NVARCHAR(255) NULL,
    [Luotu] DATETIME NULL,
    [Lähetystiedot] NVARCHAR(255) NULL,
    [Muokannut] NVARCHAR(255) NULL,
    [Muokattu] DATETIME NULL,
    [On kuitattu ulos paikalliseen kohteeseen] NVARCHAR(255) NULL,
    [Muokkaaja] NVARCHAR(255) NULL,
    [Nimi] NVARCHAR(255) NULL,
    [Oikeudet] NVARCHAR(255) NULL,
    [Omistaja] NVARCHAR(255) NULL,
    [Organisaatio] NVARCHAR(255) NULL,
    [Otsikko] NVARCHAR(255) NULL,
    [Projektitunnus] NVARCHAR(255) NULL,
    [Rinnakkaisnimeke] NVARCHAR(255) NULL,
    [Saapumistiedot] NVARCHAR(255) NULL,
    [Saatavuus] NVARCHAR(255) NULL,
    [Sisältölaji] NVARCHAR(255) NULL,
    [Sopimuksen alkamisajankohta] DATETIME NULL,
    [Sopimuksen Irtisanomisajankohta] DATETIME NULL,
    [Sopimuksen paattymisajankohta] DATETIME NULL,
    [Sopimusvuosi] NVARCHAR(255) NULL,
    [Sähköinen allekirjoitus] BIT NOT NULL,
    [Sähköinen formaatti] NVARCHAR(255) NULL,
    [Sähköinen tiedoksianto ennen hävittämistä] DATETIME NULL,
    [Sähköinen tiedoksianto laatijalle/käsittelijälle] NVARCHAR(255) NULL,
    [Säilytysaika] DATETIME NULL,
    [Säilytyshistoria] NVARCHAR(255) NULL,
    [Tapahtuma ja muutosloki] NVARCHAR(255) NULL,
    [Tekijä] NVARCHAR(255) NULL,
    [Tiedoston koko] FLOAT NULL,
    [Tunnus] FLOAT NULL,
    [Turvaluokka] NVARCHAR(255) NULL,
    [Uloskuittaaja2] NVARCHAR(255) NULL,
    [Yhtiö] NVARCHAR(255) NULL,
    [Kohteen tyyppi] NVARCHAR(255) NULL,
    [Polku] NVARCHAR(255) NULL
);
GO

-- Table: Aktiviteetti
CREATE TABLE [dbo].[Aktiviteetti] (
    [AKId] INT IDENTITY(1,1) NOT NULL,
    [AKTahoId] INT NULL,
    [AKTSopimusId] INT NULL,
    [AKYhteystapaId] INT NULL,
    [AKPaivamaara] DATETIME NULL,
    [AKKuvaus] NVARCHAR(1000) NULL,
    [AKAktiviteetinLajiId] INT NULL,
    [AKSeuraavaYhteyspaiva] DATETIME NULL,
    [AKStatusId] INT NULL,
    [AKLiitetiedostoPolku] NVARCHAR(500) NULL,
    [AKLuotu] DATETIME NULL DEFAULT (getdate()),
    [AKLuoja] NVARCHAR(50) NULL,
    [AKPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [AKPaivittaja] NVARCHAR(50) NULL,
    [AKKontaktoijaId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Aktiviteetti] PRIMARY KEY CLUSTERED ([AKId])
);
GO

-- Table: aspnet_AccessRules
CREATE TABLE [dbo].[aspnet_AccessRules] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [AccessRuleId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [AccessRuleName] NVARCHAR(256) NOT NULL,
    [LoweredAccessRuleName] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(256) NULL,
    CONSTRAINT [PK__aspnet_A__4BE26F221CB22475] PRIMARY KEY CLUSTERED ([AccessRuleId])
);
GO

-- Table: aspnet_AccessRulesInRoles
CREATE TABLE [dbo].[aspnet_AccessRulesInRoles] (
    [AccessRuleId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__aspnet_A__F34DC3C2226AFDCB] PRIMARY KEY CLUSTERED ([AccessRuleId], [RoleId])
);
GO

-- Table: aspnet_Applications
CREATE TABLE [dbo].[aspnet_Applications] (
    [ApplicationName] NVARCHAR(256) NOT NULL,
    [LoweredApplicationName] NVARCHAR(256) NOT NULL,
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [Description] NVARCHAR(256) NULL,
    CONSTRAINT [PK__aspnet_A__C93A4C987BBB44FE] PRIMARY KEY CLUSTERED ([ApplicationId])
);
GO

-- Table: aspnet_Membership
CREATE TABLE [dbo].[aspnet_Membership] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Password] NVARCHAR(128) NOT NULL,
    [PasswordFormat] INT NOT NULL DEFAULT ((0)),
    [PasswordSalt] NVARCHAR(128) NOT NULL,
    [MobilePIN] NVARCHAR(16) NULL,
    [Email] NVARCHAR(256) NULL,
    [LoweredEmail] NVARCHAR(256) NULL,
    [PasswordQuestion] NVARCHAR(256) NULL,
    [PasswordAnswer] NVARCHAR(128) NULL,
    [IsApproved] BIT NOT NULL,
    [IsLockedOut] BIT NOT NULL,
    [CreateDate] DATETIME NOT NULL,
    [LastLoginDate] DATETIME NOT NULL,
    [LastPasswordChangedDate] DATETIME NOT NULL,
    [LastLockoutDate] DATETIME NOT NULL,
    [FailedPasswordAttemptCount] INT NOT NULL,
    [FailedPasswordAttemptWindowStart] DATETIME NOT NULL,
    [FailedPasswordAnswerAttemptCount] INT NOT NULL,
    [FailedPasswordAnswerAttemptWindowStart] DATETIME NOT NULL,
    [Comment] NTEXT NULL,
    CONSTRAINT [PK__aspnet_M__1788CC4D1A3FCC1E] PRIMARY KEY CLUSTERED ([UserId])
);
GO

-- Table: aspnet_Paths
CREATE TABLE [dbo].[aspnet_Paths] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [PathId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [Path] NVARCHAR(256) NOT NULL,
    [LoweredPath] NVARCHAR(256) NOT NULL,
    CONSTRAINT [PK__aspnet_P__CD67DC585378497A] PRIMARY KEY CLUSTERED ([PathId])
);
GO

-- Table: aspnet_PersonalizationAllUsers
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers] (
    [PathId] UNIQUEIDENTIFIER NOT NULL,
    [PageSettings] IMAGE NOT NULL,
    [LastUpdatedDate] DATETIME NOT NULL,
    CONSTRAINT [PK__aspnet_P__CD67DC595B196B42] PRIMARY KEY CLUSTERED ([PathId])
);
GO

-- Table: aspnet_PersonalizationPerUser
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser] (
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [PathId] UNIQUEIDENTIFIER NULL,
    [UserId] UNIQUEIDENTIFIER NULL,
    [PageSettings] IMAGE NOT NULL,
    [LastUpdatedDate] DATETIME NOT NULL,
    CONSTRAINT [PK__aspnet_P__3214EC065FDE205F] PRIMARY KEY CLUSTERED ([Id])
);
GO

-- Table: aspnet_Profile
CREATE TABLE [dbo].[aspnet_Profile] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [PropertyNames] NTEXT NOT NULL,
    [PropertyValuesString] NTEXT NOT NULL,
    [PropertyValuesBinary] IMAGE NOT NULL,
    [LastUpdatedDate] DATETIME NOT NULL,
    CONSTRAINT [PK__aspnet_P__1788CC4C31233176] PRIMARY KEY CLUSTERED ([UserId])
);
GO

-- Table: aspnet_RoleGroups
CREATE TABLE [dbo].[aspnet_RoleGroups] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [GroupId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [GroupName] NVARCHAR(256) NOT NULL,
    [LoweredGroupName] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(256) NULL,
    CONSTRAINT [PK__aspnet_R__149AF36B0A93743A] PRIMARY KEY CLUSTERED ([GroupId])
);
GO

-- Table: aspnet_Roles
CREATE TABLE [dbo].[aspnet_Roles] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [RoleName] NVARCHAR(256) NOT NULL,
    [LoweredRoleName] NVARCHAR(256) NOT NULL,
    [Description] NVARCHAR(256) NULL,
    CONSTRAINT [PK__aspnet_R__8AFACE1B3C94E422] PRIMARY KEY CLUSTERED ([RoleId])
);
GO

-- Table: aspnet_RolesInGroups
CREATE TABLE [dbo].[aspnet_RolesInGroups] (
    [GroupId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__aspnet_R__AC355F8B104C4D90] PRIMARY KEY CLUSTERED ([GroupId], [RoleId])
);
GO

-- Table: aspnet_SchemaVersions
CREATE TABLE [dbo].[aspnet_SchemaVersions] (
    [Feature] NVARCHAR(128) NOT NULL,
    [CompatibleSchemaVersion] NVARCHAR(128) NOT NULL,
    [IsCurrentVersion] BIT NOT NULL,
    CONSTRAINT [PK__aspnet_S__5A1E6BC10DD9F539] PRIMARY KEY CLUSTERED ([Feature], [CompatibleSchemaVersion])
);
GO

-- Table: aspnet_Users
CREATE TABLE [dbo].[aspnet_Users] (
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL DEFAULT (newid()),
    [UserName] NVARCHAR(256) NOT NULL,
    [LoweredUserName] NVARCHAR(256) NOT NULL,
    [MobileAlias] NVARCHAR(16) NULL DEFAULT (NULL),
    [IsAnonymous] BIT NOT NULL DEFAULT ((0)),
    [LastActivityDate] DATETIME NOT NULL,
    CONSTRAINT [PK__aspnet_U__1788CC4D0638D371] PRIMARY KEY CLUSTERED ([UserId])
);
GO

-- Table: aspnet_UsersInGroups
CREATE TABLE [dbo].[aspnet_UsersInGroups] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleGroupId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__aspnet_U__CC01CE4E2ED0D4B0] PRIMARY KEY CLUSTERED ([UserId], [RoleGroupId])
);
GO

-- Table: aspnet_UsersInRoles
CREATE TABLE [dbo].[aspnet_UsersInRoles] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK__aspnet_U__AF2760AD424DBD78] PRIMARY KEY CLUSTERED ([UserId], [RoleId])
);
GO

-- Table: aspnet_WebEvent_Events
CREATE TABLE [dbo].[aspnet_WebEvent_Events] (
    [EventId] CHAR(32) NOT NULL,
    [EventTimeUtc] DATETIME NOT NULL,
    [EventTime] DATETIME NOT NULL,
    [EventType] NVARCHAR(256) NOT NULL,
    [EventSequence] DECIMAL(19, 0) NOT NULL,
    [EventOccurrence] DECIMAL(19, 0) NOT NULL,
    [EventCode] INT NOT NULL,
    [EventDetailCode] INT NOT NULL,
    [Message] NVARCHAR(1024) NULL,
    [ApplicationPath] NVARCHAR(256) NULL,
    [ApplicationVirtualPath] NVARCHAR(256) NULL,
    [MachineName] NVARCHAR(256) NOT NULL,
    [RequestUrl] NVARCHAR(1024) NULL,
    [ExceptionType] NVARCHAR(256) NULL,
    [Details] NTEXT NULL,
    CONSTRAINT [PK__aspnet_W__7944C81073E5190C] PRIMARY KEY CLUSTERED ([EventId])
);
GO

-- Table: ExcelTuonti_Asiakkaat
CREATE TABLE [dbo].[ExcelTuonti_Asiakkaat] (
    [ETAId] INT IDENTITY(1,1) NOT NULL,
    [ETASopimusnumero] INT NULL,
    [ETASopimusTahoId] INT NULL,
    [ETATahoId] INT NULL,
    [ETAAsiakastyyppi] VARCHAR(300) NULL,
    [ETAEtunimi] VARCHAR(300) NULL,
    [ETASukunimi] VARCHAR(300) NULL,
    [ETATahoTyyppi] VARCHAR(300) NULL,
    [ETAYTunnus] VARCHAR(300) NULL,
    [ETARooli] VARCHAR(300) NULL,
    [ETAPostiosoite] VARCHAR(300) NULL,
    [ETAPostinumero] VARCHAR(300) NULL,
    [ETAPostitoimipaikka] VARCHAR(300) NULL,
    [ETAKasitelty] BIT NOT NULL DEFAULT ((0)),
    [ETALuotu] DATETIME NOT NULL,
    [ETALuoja] VARCHAR(300) NOT NULL,
    [ETAGuid] VARCHAR(300) NULL,
    CONSTRAINT [PK__ExcelTuo__054F34A67DC38901] PRIMARY KEY CLUSTERED ([ETAId])
);
GO

-- Table: ExcelTuonti_Kiinteistot
CREATE TABLE [dbo].[ExcelTuonti_Kiinteistot] (
    [ETKId] INT IDENTITY(1,1) NOT NULL,
    [ETKSopimusnumero] INT NULL,
    [ETKSopimusKiinteistoId] INT NULL,
    [ETKKiinteistoId] INT NULL,
    [ETKNimi] VARCHAR(300) NULL,
    [ETKTunnus] VARCHAR(300) NULL,
    [ETKKunta] VARCHAR(300) NULL,
    [ETKKasitelty] BIT NOT NULL DEFAULT ((0)),
    [ETKLuotu] DATETIME NOT NULL,
    [ETKLuoja] VARCHAR(300) NOT NULL,
    [ETKGuid] VARCHAR(300) NULL,
    CONSTRAINT [PK__ExcelTuo__01CF050E02883E1E] PRIMARY KEY CLUSTERED ([ETKId])
);
GO

-- Table: ExcelTuonti_Sopimukset
CREATE TABLE [dbo].[ExcelTuonti_Sopimukset] (
    [ETSId] INT IDENTITY(1,1) NOT NULL,
    [ETSSopimusnumero] INT NULL,
    [ETSSopimustyyppi] VARCHAR(300) NULL,
    [ETSSopimuksenLaatija] VARCHAR(300) NULL,
    [ETSJuridinenYhtio] VARCHAR(300) NULL,
    [ETSProjektivalvoja] VARCHAR(300) NULL,
    [ETSProjektinumero] VARCHAR(300) NULL,
    [ETSAsiakkaanAllekirjoituspvm] DATETIME NULL,
    [ETSVerkonhaltijanAllekirjoituspvm] DATETIME NULL,
    [ETSAlkaa] DATETIME NULL,
    [ETSKieli] VARCHAR(300) NULL,
    [ETSLuonnos] VARCHAR(300) NULL,
    [ETSTila] VARCHAR(300) NULL,
    [ETSPylvasvali] VARCHAR(300) NULL,
    [ETSKasitelty] BIT NOT NULL DEFAULT ((0)),
    [ETSLuotu] DATETIME NOT NULL,
    [ETSLuoja] VARCHAR(300) NOT NULL,
    [ETSGuid] VARCHAR(300) NULL,
    [ETSInfo] VARCHAR(4000) NULL,
    [ETSMuuTunniste] VARCHAR(300) NULL,
    CONSTRAINT [PK__ExcelTuo__3FCE0D0C78FED3E4] PRIMARY KEY CLUSTERED ([ETSId])
);
GO

-- Table: hlp_AktiviteetinLaji
CREATE TABLE [dbo].[hlp_AktiviteetinLaji] (
    [ALId] INT IDENTITY(1,1) NOT NULL,
    [ALLaji] NVARCHAR(300) NOT NULL,
    [ALLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ALLuoja] NVARCHAR(50) NOT NULL,
    [ALPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ALPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_AktiviteetinLaji] PRIMARY KEY CLUSTERED ([ALId])
);
GO

-- Table: hlp_AktiviteetinStatus
CREATE TABLE [dbo].[hlp_AktiviteetinStatus] (
    [ASId] INT IDENTITY(1,1) NOT NULL,
    [ASAktiviteetinStatus] NVARCHAR(300) NOT NULL,
    [ASLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ASLuoja] NVARCHAR(50) NOT NULL,
    [ASPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ASPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_AktiviteetinStatus] PRIMARY KEY CLUSTERED ([ASId])
);
GO

-- Table: hlp_AktiviteettiYhteystapa
CREATE TABLE [dbo].[hlp_AktiviteettiYhteystapa] (
    [YTAId] INT IDENTITY(1,1) NOT NULL,
    [YTAYhteystapa] NVARCHAR(300) NOT NULL,
    [YTALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [YTALuoja] NVARCHAR(50) NOT NULL,
    [YTAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [YTAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Yhteystapa] PRIMARY KEY CLUSTERED ([YTAId])
);
GO

-- Table: hlp_Alv
CREATE TABLE [dbo].[hlp_Alv] (
    [ALVId] INT IDENTITY(1,1) NOT NULL,
    [ALVProsentti] DECIMAL(5, 2) NULL,
    [ALVOletus] BIT NULL DEFAULT ((0)),
    [ALVLuoja] VARCHAR(50) NOT NULL,
    [ALVLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ALVPaivittaja] NVARCHAR(50) NULL,
    [ALVPaivitetty] DATETIME NULL,
    CONSTRAINT [PK_hlp_Alv] PRIMARY KEY CLUSTERED ([ALVId])
);
GO

-- Table: hlp_ArkistonSijainti
CREATE TABLE [dbo].[hlp_ArkistonSijainti] (
    [ASIId] INT IDENTITY(1,1) NOT NULL,
    [ASIArkistonSijainti] NVARCHAR(300) NULL,
    [ASILuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ASILuoja] NVARCHAR(50) NOT NULL,
    [ASIPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ASIPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_ArkistonSijainti] PRIMARY KEY CLUSTERED ([ASIId])
);
GO

-- Table: hlp_Asiakastyyppi
CREATE TABLE [dbo].[hlp_Asiakastyyppi] (
    [ATYId] INT IDENTITY(1,1) NOT NULL,
    [ATYAsiakastyyppi] NVARCHAR(300) NOT NULL,
    [ATYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ATYLuoja] NVARCHAR(50) NOT NULL,
    [ATYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ATYPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Asiakastyyppi] PRIMARY KEY CLUSTERED ([ATYId])
);
GO

-- Table: hlp_AsiakirjaTarkenne
CREATE TABLE [dbo].[hlp_AsiakirjaTarkenne] (
    [ATAId] INT IDENTITY(1,1) NOT NULL,
    [ATAAsiakirjaTarkenne] NVARCHAR(300) NOT NULL,
    [ATALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ATaLuoja] NVARCHAR(50) NOT NULL,
    [ATAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ATAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_AsiakirjaTarkenne] PRIMARY KEY CLUSTERED ([ATAId])
);
GO

-- Table: hlp_BicKoodi
CREATE TABLE [dbo].[hlp_BicKoodi] (
    [BKId] INT IDENTITY(1,1) NOT NULL,
    [BKKoodi] VARCHAR(50) NULL,
    [BKPankki] VARCHAR(300) NULL,
    [BKRahalaitosTunnus] VARCHAR(300) NULL,
    [BKLuotu] DATETIME NULL DEFAULT (getdate()),
    [BKLuoja] VARCHAR(300) NULL,
    [BKPaivitetty] DATETIME NULL,
    [BKPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_BicKoodi] PRIMARY KEY CLUSTERED ([BKId])
);
GO

-- Table: hlp_DFRooli
CREATE TABLE [dbo].[hlp_DFRooli] (
    [DFRId] INT IDENTITY(1,1) NOT NULL,
    [DFRRooli] NVARCHAR(300) NOT NULL,
    [DFRLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [DFRLuoja] NVARCHAR(50) NOT NULL,
    [DFRPaivittaja] NVARCHAR(50) NULL,
    [DFRPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlp_DFRooli] PRIMARY KEY CLUSTERED ([DFRId])
);
GO

-- Table: hlp_HinnastoAlakategoria
CREATE TABLE [dbo].[hlp_HinnastoAlakategoria] (
    [HAKId] INT IDENTITY(1,1) NOT NULL,
    [HAKHinnastoAlakategoria] NVARCHAR(300) NOT NULL,
    [HAKLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [HAKLuoja] NVARCHAR(50) NOT NULL,
    [HAKPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [HAKPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_HinnastoAlakategoria] PRIMARY KEY CLUSTERED ([HAKId])
);
GO

-- Table: hlp_HinnastoKategoria
CREATE TABLE [dbo].[hlp_HinnastoKategoria] (
    [HKAId] INT IDENTITY(1,1) NOT NULL,
    [HKAHinnastoKategoria] NVARCHAR(300) NOT NULL,
    [HKALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [HKALuoja] NVARCHAR(50) NOT NULL,
    [HKAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [HKAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_HinnastoKategoria] PRIMARY KEY CLUSTERED ([HKAId])
);
GO

-- Table: hlp_Indeksi
CREATE TABLE [dbo].[hlp_Indeksi] (
    [IKDId] INT IDENTITY(1,1) NOT NULL,
    [IKDIndeksityyppiId] INT NOT NULL,
    [IKDKuukausiId] INT NOT NULL,
    [IKDVuosi] INT NOT NULL,
    [IKDArvo] INT NOT NULL,
    [IKDLuoja] VARCHAR(50) NOT NULL,
    [IKDLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [IKDPaivittaja] NVARCHAR(50) NULL,
    [IKDPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlp_Indeksi] PRIMARY KEY CLUSTERED ([IKDId])
);
GO

-- Table: hlp_Indeksityyppi
CREATE TABLE [dbo].[hlp_Indeksityyppi] (
    [ITYId] INT IDENTITY(1,1) NOT NULL,
    [ITYIndeksityyppi] NVARCHAR(300) NOT NULL,
    [ITYLuoja] NVARCHAR(50) NOT NULL,
    [ITYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ITYPaivittaja] NVARCHAR(50) NULL,
    [ITYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlp_Indeksityyppi] PRIMARY KEY CLUSTERED ([ITYId])
);
GO

-- Table: hlp_Infopallura
CREATE TABLE [dbo].[hlp_Infopallura] (
    [IFPId] INT IDENTITY(1,1) NOT NULL,
    [IFPLomake] NVARCHAR(50) NOT NULL,
    [IFPKentta] NVARCHAR(50) NOT NULL,
    [IFPTeksti] NVARCHAR(1000) NOT NULL,
    [IFPLuoja] NVARCHAR(50) NOT NULL,
    [IFPLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [IFPPaivittaja] NVARCHAR(50) NULL,
    [IFPPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlp_Infopallura] PRIMARY KEY CLUSTERED ([IFPId])
);
GO

-- Table: hlp_InvCost
CREATE TABLE [dbo].[hlp_InvCost] (
    [ICOId] INT IDENTITY(1,1) NOT NULL,
    [ICONimi] NVARCHAR(300) NOT NULL,
    [ICOLuotu] DATETIME NOT NULL,
    [ICOLuoja] NVARCHAR(50) NOT NULL,
    [ICOPaivitetty] DATETIME NULL,
    [ICOPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_InvCost] PRIMARY KEY CLUSTERED ([ICOId])
);
GO

-- Table: hlp_Julkisuusaste
CREATE TABLE [dbo].[hlp_Julkisuusaste] (
    [JASId] INT IDENTITY(1,1) NOT NULL,
    [JASJulkisuusaste] NVARCHAR(300) NOT NULL,
    [JASLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [JASLuoja] NVARCHAR(50) NOT NULL,
    [JASPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [JASPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Julkisuusaste] PRIMARY KEY CLUSTERED ([JASId])
);
GO

-- Table: hlp_Kieli
CREATE TABLE [dbo].[hlp_Kieli] (
    [KIEId] INT IDENTITY(1,1) NOT NULL,
    [KIEKieli] VARCHAR(50) NOT NULL,
    [KIELuoja] VARCHAR(50) NOT NULL,
    [KIELuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KIEPaivittaja] NVARCHAR(50) NULL,
    [KIEPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KIEKieliTunniste] VARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Kieli] PRIMARY KEY CLUSTERED ([KIEId])
);
GO

-- Table: hlp_KirjanpidonKustannuspaikka
CREATE TABLE [dbo].[hlp_KirjanpidonKustannuspaikka] (
    [KPKId] INT IDENTITY(1,1) NOT NULL,
    [KPKKirjanpidonKustannuspaikka] NVARCHAR(300) NOT NULL,
    [KPKLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KPKLuoja] NVARCHAR(50) NOT NULL,
    [KPKPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KPKPaivittaja] NVARCHAR(50) NULL,
    [KPKSelite] NVARCHAR(300) NULL,
    [_responsId] INT NULL,
    CONSTRAINT [PK_hlp_KirjanpidonKustannuspaikka] PRIMARY KEY CLUSTERED ([KPKId])
);
GO

-- Table: hlp_Kirjanpidontili
CREATE TABLE [dbo].[hlp_Kirjanpidontili] (
    [KPTId] INT IDENTITY(1,1) NOT NULL,
    [KPTKirjanpidonTili] NVARCHAR(300) NOT NULL,
    [KPTLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KPTLuoja] NVARCHAR(50) NOT NULL,
    [KPTPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KPTPaivittaja] NVARCHAR(50) NULL,
    [KPTSelite] VARCHAR(300) NULL,
    CONSTRAINT [PK_hlp_Kirjanpidontili] PRIMARY KEY CLUSTERED ([KPTId])
);
GO

-- Table: hlp_Kohdekategoria
CREATE TABLE [dbo].[hlp_Kohdekategoria] (
    [KDKId] INT IDENTITY(1,1) NOT NULL,
    [KDKKohdeKategoria] NVARCHAR(300) NOT NULL,
    [KDKLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KDKLuoja] NVARCHAR(50) NOT NULL,
    [KDKPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KDKPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Kohdekategoria] PRIMARY KEY CLUSTERED ([KDKId])
);
GO

-- Table: hlp_Korkoprosentti
CREATE TABLE [dbo].[hlp_Korkoprosentti] (
    [KPId] INT IDENTITY(1,1) NOT NULL,
    [KPProsentti] DECIMAL(18, 6) NULL,
    [KPVuodet] INT NOT NULL,
    [KPLuotu] DATETIME NOT NULL,
    [KPLuoja] VARCHAR(300) NOT NULL,
    [KPPaivitetty] DATETIME NULL,
    [KPPaivittaja] VARCHAR(300) NULL,
    CONSTRAINT [PK__hlp_Kork__BC81E1A68601354E] PRIMARY KEY CLUSTERED ([KPId])
);
GO

-- Table: hlp_Kunta
CREATE TABLE [dbo].[hlp_Kunta] (
    [KKuntaid] INT IDENTITY(1,1) NOT NULL,
    [KKunta] NVARCHAR(300) NULL,
    [KKuntaSwe] NVARCHAR(300) NULL,
    [KKuntaNro] NVARCHAR(50) NULL,
    [KPaivittaja] NVARCHAR(50) NULL,
    [KPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KLuotu] DATETIME NULL DEFAULT (getdate()),
    [KLuoja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Kunta] PRIMARY KEY CLUSTERED ([KKuntaid])
);
GO

-- Table: hlp_Kyla
CREATE TABLE [dbo].[hlp_Kyla] (
    [KYLId] INT IDENTITY(1,1) NOT NULL,
    [KYLKyla] NVARCHAR(300) NOT NULL,
    [KYLLuoja] NVARCHAR(50) NOT NULL,
    [KYLLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KYLPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KYLPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Kyla] PRIMARY KEY CLUSTERED ([KYLId])
);
GO

-- Table: hlp_LiiketoiminnanTarve
CREATE TABLE [dbo].[hlp_LiiketoiminnanTarve] (
    [LTOId] INT IDENTITY(1,1) NOT NULL,
    [LTOLiiketoiminnanTarve] NVARCHAR(300) NOT NULL,
    [LTOLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [LTOLuoja] NVARCHAR(50) NOT NULL,
    [LTOPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [LTOPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_LiiketoiminnanTarve] PRIMARY KEY CLUSTERED ([LTOId])
);
GO

-- Table: hlp_Local1
CREATE TABLE [dbo].[hlp_Local1] (
    [LOCId] INT IDENTITY(1,1) NOT NULL,
    [LOCNimi] NVARCHAR(300) NOT NULL,
    [LOCLuotu] DATETIME NOT NULL,
    [LOCLuoja] NVARCHAR(50) NOT NULL,
    [LOCPaivitetty] DATETIME NULL,
    [LOCPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Local1] PRIMARY KEY CLUSTERED ([LOCId])
);
GO

-- Table: hlp_Lupataho
CREATE TABLE [dbo].[hlp_Lupataho] (
    [LPTId] INT IDENTITY(1,1) NOT NULL,
    [LPTLupataho] VARCHAR(300) NOT NULL,
    [LPTLuoja] VARCHAR(50) NOT NULL,
    [LPTLuotu] DATETIME NOT NULL,
    [LPTPaivittaja] NVARCHAR(50) NULL,
    [LPTPaivitetty] DATETIME NULL,
    CONSTRAINT [PK_hlp_Lupataho] PRIMARY KEY CLUSTERED ([LPTId])
);
GO

-- Table: hlp_Maa
CREATE TABLE [dbo].[hlp_Maa] (
    [MAAId] INT IDENTITY(1,1) NOT NULL,
    [MAANimi] NVARCHAR(300) NOT NULL,
    [MAANimiSuomi] NVARCHAR(300) NULL,
    [MAAKoodi] NVARCHAR(50) NULL,
    [MAALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MAALuoja] NVARCHAR(50) NOT NULL,
    [MAAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MAAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Maa] PRIMARY KEY CLUSTERED ([MAAId])
);
GO

-- Table: hlp_MaaraAlaTarkenne
CREATE TABLE [dbo].[hlp_MaaraAlaTarkenne] (
    [MATId] INT IDENTITY(1,1) NOT NULL,
    [MATMaaraAlaTarkenne] NVARCHAR(300) NOT NULL,
    [MATLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MATLuoja] NVARCHAR(50) NOT NULL,
    [MATPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MATPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_MaaraAlaTarkenne] PRIMARY KEY CLUSTERED ([MATId])
);
GO

-- Table: hlp_Maksualue
CREATE TABLE [dbo].[hlp_Maksualue] (
    [MALId] INT IDENTITY(1,1) NOT NULL,
    [MALMaksualue] NVARCHAR(300) NOT NULL,
    [MALLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MALLuoja] NVARCHAR(50) NOT NULL,
    [MALPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MALPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Maksualue] PRIMARY KEY CLUSTERED ([MALId])
);
GO

-- Table: hlp_Maksuehdot
CREATE TABLE [dbo].[hlp_Maksuehdot] (
    [MEHId] INT IDENTITY(1,1) NOT NULL,
    [MEHMaksuehdot] NVARCHAR(300) NOT NULL,
    [MEHLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MEHLuoja] NVARCHAR(50) NOT NULL,
    [MEHPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MEHPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Maksuehdot] PRIMARY KEY CLUSTERED ([MEHId])
);
GO

-- Table: hlp_MaksunSuoritus
CREATE TABLE [dbo].[hlp_MaksunSuoritus] (
    [MSUId] INT IDENTITY(1,1) NOT NULL,
    [MSUMaksunSuoritus] NVARCHAR(300) NOT NULL,
    [MSULuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MSULuoja] NVARCHAR(50) NOT NULL,
    [MSUPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MSUPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_MaksunSuoritus] PRIMARY KEY CLUSTERED ([MSUId])
);
GO

-- Table: hlp_Metsatyyppi
CREATE TABLE [dbo].[hlp_Metsatyyppi] (
    [MTYId] INT IDENTITY(1,1) NOT NULL,
    [MTYMetsatyyppi] NVARCHAR(300) NOT NULL,
    [MTYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MTYLuoja] NVARCHAR(50) NOT NULL,
    [MTYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MTYPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Metsatyyppi] PRIMARY KEY CLUSTERED ([MTYId])
);
GO

-- Table: hlp_PassivoinninSyy
CREATE TABLE [dbo].[hlp_PassivoinninSyy] (
    [PASId] INT IDENTITY(1,1) NOT NULL,
    [PASPassivoinninSyy] NVARCHAR(300) NOT NULL,
    [PASLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [PASLuoja] NVARCHAR(50) NOT NULL,
    [PASPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [PASPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_PassivoinninSyy] PRIMARY KEY CLUSTERED ([PASId])
);
GO

-- Table: hlp_Postitiedot
CREATE TABLE [dbo].[hlp_Postitiedot] (
    [PPostiId] INT NOT NULL,
    [PPostinumero] VARCHAR(50) NULL,
    [PPostitoimipaikka] VARCHAR(300) NULL,
    [PPostitoimipaikkaRUO] VARCHAR(300) NULL,
    [PKuntaid] INT NULL,
    [PLuoja] VARCHAR(300) NULL,
    [PLuotu] DATETIME NULL,
    [PPaivittaja] NVARCHAR(50) NULL,
    [PPaivitetty] DATETIME NULL
);
GO

-- Table: hlp_Purpose
CREATE TABLE [dbo].[hlp_Purpose] (
    [PURId] INT IDENTITY(1,1) NOT NULL,
    [PURNimi] NVARCHAR(300) NOT NULL,
    [PURLuotu] DATETIME NOT NULL,
    [PURLuoja] NVARCHAR(50) NOT NULL,
    [PURPaivitetty] DATETIME NULL,
    [PURPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Purpose] PRIMARY KEY CLUSTERED ([PURId])
);
GO

-- Table: hlp_Puustolaji
CREATE TABLE [dbo].[hlp_Puustolaji] (
    [PLAId] INT IDENTITY(1,1) NOT NULL,
    [PLAPuustolaji] NVARCHAR(300) NOT NULL,
    [PLALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [PLALuoja] NVARCHAR(50) NOT NULL,
    [PLAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [PLAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Puustolaji] PRIMARY KEY CLUSTERED ([PLAId])
);
GO

-- Table: hlp_PuustonOmistajuus
CREATE TABLE [dbo].[hlp_PuustonOmistajuus] (
    [POMId] INT IDENTITY(1,1) NOT NULL,
    [POMPuustonOmistajuus] NVARCHAR(300) NOT NULL,
    [POMLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [POMLuoja] NVARCHAR(50) NOT NULL,
    [POMPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [POMPaivittaja] NVARCHAR(50) NULL,
    [POMPuustonOmistajuusSwe] NVARCHAR(300) NULL,
    CONSTRAINT [PK_hlp_PuustonOmistajuus] PRIMARY KEY CLUSTERED ([POMId])
);
GO

-- Table: hlp_PuustonPoisto
CREATE TABLE [dbo].[hlp_PuustonPoisto] (
    [PPOId] INT IDENTITY(1,1) NOT NULL,
    [PPOPuustonPoisto] NVARCHAR(300) NOT NULL,
    [PPOLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [PPOLuoja] NVARCHAR(50) NOT NULL,
    [PPOPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [PPOPaivittaja] NVARCHAR(50) NULL,
    [PPOPuustonPoistoSwe] NVARCHAR(300) NULL,
    CONSTRAINT [PK_hlp_PuustonPoisto] PRIMARY KEY CLUSTERED ([PPOId])
);
GO

-- Table: hlp_Regulation
CREATE TABLE [dbo].[hlp_Regulation] (
    [REGId] INT IDENTITY(1,1) NOT NULL,
    [REGNimi] NVARCHAR(300) NOT NULL,
    [REGLuotu] DATETIME NOT NULL,
    [REGLuoja] NVARCHAR(50) NOT NULL,
    [REGPaivitetty] DATETIME NULL,
    [REGPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Regulation] PRIMARY KEY CLUSTERED ([REGId])
);
GO

-- Table: hlp_Saanto
CREATE TABLE [dbo].[hlp_Saanto] (
    [SAAId] INT IDENTITY(1,1) NOT NULL,
    [SAASaanto] NVARCHAR(300) NOT NULL,
    [SAALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SAALuoja] NVARCHAR(50) NOT NULL,
    [SAAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SAAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Saanto] PRIMARY KEY CLUSTERED ([SAAId])
);
GO

-- Table: hlp_SiirtoOikeus
CREATE TABLE [dbo].[hlp_SiirtoOikeus] (
    [SOIId] INT IDENTITY(1,1) NOT NULL,
    [SOISiirtoOikeus] NVARCHAR(300) NOT NULL,
    [SOILuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SOILuoja] NVARCHAR(50) NOT NULL,
    [SOIPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SOIPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_SiirtoOikeus] PRIMARY KEY CLUSTERED ([SOIId])
);
GO

-- Table: hlp_SopimuksenAlaluokka
CREATE TABLE [dbo].[hlp_SopimuksenAlaluokka] (
    [SALId] INT IDENTITY(1,1) NOT NULL,
    [SALSopimuksenAlaluokka] NVARCHAR(300) NOT NULL,
    [SALLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SALLuoja] NVARCHAR(50) NOT NULL,
    [SALPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SALPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_SopimuksenAlaluokka] PRIMARY KEY CLUSTERED ([SALId])
);
GO

-- Table: hlp_SopimuksenEhtoversio
CREATE TABLE [dbo].[hlp_SopimuksenEhtoversio] (
    [SEHId] INT IDENTITY(1,1) NOT NULL,
    [SEHSopimuksenEhtoversio] NVARCHAR(300) NOT NULL,
    [SEHLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SEHLuoja] NVARCHAR(50) NOT NULL,
    [SEHPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SEHPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_SopimuksenEhtoversio] PRIMARY KEY CLUSTERED ([SEHId])
);
GO

-- Table: hlp_SopimuksenKesto
CREATE TABLE [dbo].[hlp_SopimuksenKesto] (
    [SKEId] INT IDENTITY(1,1) NOT NULL,
    [SKESopimuksenKesto] NVARCHAR(300) NOT NULL,
    [SKELuoja] NVARCHAR(50) NOT NULL,
    [SKELuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SKEPaivittaja] NVARCHAR(50) NULL,
    [SKEPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlp_SopimuksenKesto] PRIMARY KEY CLUSTERED ([SKEId])
);
GO

-- Table: hlp_SopimusFormaatti
CREATE TABLE [dbo].[hlp_SopimusFormaatti] (
    [SFOId] INT IDENTITY(1,1) NOT NULL,
    [SFOSopimusFormaatti] NVARCHAR(50) NOT NULL,
    [SFOLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SFOLuoja] NVARCHAR(50) NOT NULL,
    [SFOPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SFOPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_SopimusFormaatti] PRIMARY KEY CLUSTERED ([SFOId])
);
GO

-- Table: hlp_TunnisteyksikkoTyyppi
CREATE TABLE [dbo].[hlp_TunnisteyksikkoTyyppi] (
    [TTYId] INT IDENTITY(1,1) NOT NULL,
    [TTYTunnisteYksikkoTyyppi] NVARCHAR(300) NOT NULL,
    [TTYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [TTYLuoja] NVARCHAR(50) NOT NULL,
    [TTYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [TTYPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_TunnisteyksikkoTyyppi] PRIMARY KEY CLUSTERED ([TTYId])
);
GO

-- Table: hlp_Vuokratyyppi
CREATE TABLE [dbo].[hlp_Vuokratyyppi] (
    [VTId] INT IDENTITY(1,1) NOT NULL,
    [VTNimi] VARCHAR(300) NOT NULL,
    [VTLuotu] DATETIME NOT NULL,
    [VTLuoja] VARCHAR(300) NOT NULL,
    [VTPaivitetty] DATETIME NULL,
    [VTPaivittaja] VARCHAR(300) NULL,
    CONSTRAINT [PK__hlp_Vuok__B31EEE6937408131] PRIMARY KEY CLUSTERED ([VTId])
);
GO

-- Table: hlp_Yksikko
CREATE TABLE [dbo].[hlp_Yksikko] (
    [YKSId] INT IDENTITY(1,1) NOT NULL,
    [YKSKorvausyksikko] NVARCHAR(50) NOT NULL,
    [YKSKerroin] DECIMAL(8, 4) NULL,
    [YKSLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [YKSLuoja] NVARCHAR(50) NOT NULL,
    [YKSPaivittaja] NVARCHAR(50) NULL,
    [YKSPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [_Korvausyksikko] NVARCHAR(50) NULL,
    [YKSKorvausyksikonTyyppiId] INT NULL,
    CONSTRAINT [PK_hlp_Korvausyksikko] PRIMARY KEY CLUSTERED ([YKSId])
);
GO

-- Table: hlps_KorvauslaskemaStatus
CREATE TABLE [dbo].[hlps_KorvauslaskemaStatus] (
    [KSTId] INT IDENTITY(1,1) NOT NULL,
    [KSTKorvauslaskelmaStatus] NVARCHAR(300) NOT NULL,
    [KSTLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KSTLuoja] NVARCHAR(50) NOT NULL,
    [KSTPaivittaja] NVARCHAR(50) NULL,
    [KSTPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlps_KorvauslaskemaStatus] PRIMARY KEY CLUSTERED ([KSTId])
);
GO

-- Table: hlps_Korvaustyyppi
CREATE TABLE [dbo].[hlps_Korvaustyyppi] (
    [KTYId] INT IDENTITY(1,1) NOT NULL,
    [KTYKorvaustyyppi] NVARCHAR(300) NOT NULL,
    [KTYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KTYLuoja] NVARCHAR(50) NOT NULL,
    [KTYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KTYPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlps_Korvaustyyppi] PRIMARY KEY CLUSTERED ([KTYId])
);
GO

-- Table: hlps_KorvausyksikonTyyppi
CREATE TABLE [dbo].[hlps_KorvausyksikonTyyppi] (
    [KYTId] INT IDENTITY(1,1) NOT NULL,
    [KYTKorvausyksikonTyyppi] NVARCHAR(300) NOT NULL,
    [KYTLuotu] DATETIME NOT NULL,
    [KYTLuoja] NVARCHAR(50) NOT NULL,
    [KYTPaivittaja] NVARCHAR(50) NULL,
    [KYTPaivitetty] DATETIME NULL,
    CONSTRAINT [PK_hlps_KorvausYksikonTyyppi] PRIMARY KEY CLUSTERED ([KYTId])
);
GO

-- Table: hlps_Kuukausi
CREATE TABLE [dbo].[hlps_Kuukausi] (
    [KUUId] INT IDENTITY(1,1) NOT NULL,
    [KUUKuukausi] NVARCHAR(50) NOT NULL,
    [KUULuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KUULuoja] NVARCHAR(50) NOT NULL,
    [KUUPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KUUPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Kuukausi] PRIMARY KEY CLUSTERED ([KUUId])
);
GO

-- Table: hlps_MaksuStatus
CREATE TABLE [dbo].[hlps_MaksuStatus] (
    [MSAId] INT NOT NULL,
    [MSAMaksuStatus] NVARCHAR(300) NOT NULL,
    [MSALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MSALuoja] NVARCHAR(50) NOT NULL,
    [MSAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [MSAPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlps_MaksuStatus] PRIMARY KEY CLUSTERED ([MSAId])
);
GO

-- Table: hlps_OrganisaationTyyppi
CREATE TABLE [dbo].[hlps_OrganisaationTyyppi] (
    [ORTId] INT IDENTITY(1,1) NOT NULL,
    [ORTTyyppi] NVARCHAR(300) NOT NULL,
    [ORTLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [ORTLuoja] NVARCHAR(50) NOT NULL,
    [ORTPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [ORTPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlps_OrganisaationTyyppi] PRIMARY KEY CLUSTERED ([ORTId])
);
GO

-- Table: hlps_SopimuksenTila
CREATE TABLE [dbo].[hlps_SopimuksenTila] (
    [STIId] INT IDENTITY(1,1) NOT NULL,
    [STISopimuksenTila] NVARCHAR(50) NOT NULL,
    [STILuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [STILuoja] NVARCHAR(50) NOT NULL,
    [STIPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [STIPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlps_SopimuksenTila] PRIMARY KEY CLUSTERED ([STIId])
);
GO

-- Table: hlps_Sopimusluokka
CREATE TABLE [dbo].[hlps_Sopimusluokka] (
    [SLUId] INT IDENTITY(1,1) NOT NULL,
    [SLUSopimusLuokka] NVARCHAR(300) NOT NULL,
    [SLULuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SLULuoja] NVARCHAR(50) NOT NULL,
    [SLUPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SLUPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_hlp_Sopimusluokka] PRIMARY KEY CLUSTERED ([SLUId])
);
GO

-- Table: hlps_Sopimustyyppi
CREATE TABLE [dbo].[hlps_Sopimustyyppi] (
    [STYId] INT IDENTITY(1,1) NOT NULL,
    [STYSopimustyyppi] NVARCHAR(300) NOT NULL,
    [STYLuoja] NVARCHAR(50) NOT NULL,
    [STYLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [STYPaivittaja] NVARCHAR(50) NULL,
    [STYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [_kategoria] NVARCHAR(50) NULL,
    [STYAsiakirjatarkenne] VARCHAR(100) NULL,
    CONSTRAINT [PK_hlp_Sopimustyyppi] PRIMARY KEY CLUSTERED ([STYId])
);
GO

-- Table: hlps_TahoTyyppi
CREATE TABLE [dbo].[hlps_TahoTyyppi] (
    [TATId] INT IDENTITY(1,1) NOT NULL,
    [TATTahoTyyppi] NVARCHAR(300) NOT NULL,
    [TATLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [TATLuoja] NVARCHAR(50) NOT NULL,
    [TATPaivittaja] NVARCHAR(50) NULL DEFAULT (getdate()),
    [TATPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlps_TahoTyyppi] PRIMARY KEY CLUSTERED ([TATId])
);
GO

-- Table: hlps_Tiedostolahde
CREATE TABLE [dbo].[hlps_Tiedostolahde] (
    [TLAId] INT IDENTITY(1,1) NOT NULL,
    [TLATiedostoLahde] NVARCHAR(300) NOT NULL,
    [TLALuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [TLALuoja] NVARCHAR(50) NOT NULL,
    [TLAPaivittaja] NVARCHAR(50) NULL,
    [TLAPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlps_Tiedostolahde] PRIMARY KEY CLUSTERED ([TLAId])
);
GO

-- Table: hlps_YlasopimuksenTyyppi
CREATE TABLE [dbo].[hlps_YlasopimuksenTyyppi] (
    [YSTId] INT IDENTITY(1,1) NOT NULL,
    [YSTYlasopimuksenTyyppi] NVARCHAR(300) NOT NULL,
    [YSTLuoja] NVARCHAR(50) NOT NULL,
    [YSTLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [YSTPaivittaja] NVARCHAR(50) NULL,
    [YSTPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_hlps_YlasopimuksenTyyppi] PRIMARY KEY CLUSTERED ([YSTId])
);
GO

-- Table: IFRS_Historia
CREATE TABLE [dbo].[IFRS_Historia] (
    [IFRSId] INT IDENTITY(1,1) NOT NULL,
    [IFRSPvm] DATETIME NOT NULL,
    [IFRSSopimusId] INT NOT NULL,
    [IFRSSopimusAlkaa] DATETIME NULL,
    [IFRSSopimusPaattyy] DATETIME NULL,
    [IFRSSopimusJuridinenYhtioId] INT NULL,
    [IFRSSopimusJuridinenYhtio] VARCHAR(600) NULL,
    [IFRSSopimusVuokratyyppiId] INT NULL,
    [IFRSSopimusIFRS] BIT NOT NULL DEFAULT ((0)),
    [IFRSSopimusKorkoprosentti] DECIMAL(18, 6) NULL,
    [IFRSKorvauslaskelmaId] INT NULL,
    [IFRSKorvauslaskelmaTahoId] INT NULL,
    [IFRSKorvauslaskelmaTaho] VARCHAR(600) NULL,
    [IFRSKorvauslaskelmaViimeisinMaksu] MONEY NULL,
    [IFRSLuotu] DATETIME NOT NULL,
    [IFRSLuoja] VARCHAR(300) NOT NULL,
    [IFRSKorvauslaskelmaMaksunSuoritusId] INT NULL,
    [IFRSKorvauslaskelmaMaksetaanAlv] BIT NULL,
    CONSTRAINT [PK__IFRS_His__2F04E58891937BF2] PRIMARY KEY CLUSTERED ([IFRSId])
);
GO

-- Table: IFRS_Historia_Excel
CREATE TABLE [dbo].[IFRS_Historia_Excel] (
    [EId] INT IDENTITY(1,1) NOT NULL,
    [EPvm] DATETIME NOT NULL,
    [ENimi] VARCHAR(300) NOT NULL,
    [ESisalto] VARBINARY(MAX) NOT NULL,
    [ELuotu] DATETIME NOT NULL,
    [ELuoja] VARCHAR(300) NOT NULL,
    CONSTRAINT [PK__IFRS_His__C190176B3B0E7D0E] PRIMARY KEY CLUSTERED ([EId])
);
GO

-- Table: IFSPayment
CREATE TABLE [dbo].[IFSPayment] (
    [IPId] INT IDENTITY(1,1) NOT NULL,
    [IPSequence] NVARCHAR(50) NULL,
    [IPPaymentReference] NVARCHAR(300) NULL,
    [IPPaymentDate] DATETIME NULL,
    [IPInvoiceNo] NVARCHAR(50) NULL,
    [IPIfsInvoiceNo] NVARCHAR(50) NULL,
    [IPName] NVARCHAR(300) NULL,
    [IPAmount] MONEY NULL,
    [IPLuoja] NVARCHAR(50) NULL,
    [IPLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [IPPaivittaja] NVARCHAR(50) NULL,
    [IPPaivitetty] DATETIME NULL,
    CONSTRAINT [PK_IFSPayment] PRIMARY KEY CLUSTERED ([IPId])
);
GO

-- Table: Kiinteisto
CREATE TABLE [dbo].[Kiinteisto] (
    [KIIId] INT IDENTITY(1,1) NOT NULL,
    [KIIKiinteisto] NVARCHAR(300) NULL,
    [KIITahoId] INT NULL,
    [KIIKatuosoite] NVARCHAR(300) NULL,
    [KIIPostitoimipaikka] NVARCHAR(300) NULL,
    [KIIPostinumero] NVARCHAR(50) NULL,
    [KIIMaaId] INT NULL,
    [KIIRekisterinumero] NVARCHAR(300) NULL,
    [KIIKyla] NVARCHAR(300) NULL,
    [KIIKylanumero] INT NULL,
    [KIIKylaId] INT NULL,
    [KIIKunta] NVARCHAR(300) NULL,
    [KIIKuntanumero] INT NULL,
    [KIIKuntaId] INT NULL,
    [KIIKiinteistotunnus] NVARCHAR(300) NULL,
    [KIIKiinteistotunnusLyhyt] NVARCHAR(300) NULL,
    [KIIPintaAla] DECIMAL(18, 2) NULL,
    [KIIMaapintaAla] DECIMAL(18, 2) NULL,
    [KIIVesipintaAla] DECIMAL(18, 2) NULL,
    [KIIKortteli] NVARCHAR(50) NULL,
    [KIITontti] NVARCHAR(50) NULL,
    [KIIMaaraAla] NVARCHAR(50) NULL,
    [KIIMaaraAlaTarkenneId] INT NULL,
    [KIIKiinteistoverotettuVuosi] INT NULL,
    [KIIAssetTunniste] INT NULL,
    [KIIRasitteet] NVARCHAR(MAX) NULL,
    [KIIKiinnitykset] NVARCHAR(MAX) NULL,
    [KIIOmistusosuus] INT NULL,
    [KIIOmistusosuusTotal] INT NULL,
    [KIILiiketoiminnanTarveId] INT NULL,
    [KIISaantoId] INT NULL,
    [KIIInfo] NVARCHAR(500) NULL,
    [KIILuoja] NVARCHAR(50) NULL,
    [KIILuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KIIPaivittaja] NVARCHAR(50) NULL,
    [KIIPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [_kiisqlId] INT NULL,
    [KIIAlueTarkenne] VARCHAR(300) NULL,
    [KIIExcelTuontiId] INT NULL,
    [_SOHATempGuid] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Kiinteisto] PRIMARY KEY CLUSTERED ([KIIId])
);
GO

-- Table: KirjanpidonAineisto
CREATE TABLE [dbo].[KirjanpidonAineisto] (
    [record_type] NVARCHAR(3) NOT NULL,
    [batch_id] INT IDENTITY(1,1) NOT NULL,
    [application_id] NVARCHAR(30) NOT NULL,
    [org_id] NVARCHAR(30) NOT NULL,
    [check_sum] DECIMAL(15, 0) NOT NULL,
    CONSTRAINT [PK_KirjanpidonAineisto] PRIMARY KEY CLUSTERED ([batch_id])
);
GO

-- Table: KirjanpidonAineistoRivi
CREATE TABLE [dbo].[KirjanpidonAineistoRivi] (
    [record_type] NVARCHAR(3) NOT NULL,
    [batch_id] INT NOT NULL,
    [org_id] NVARCHAR(30) NOT NULL,
    [source] NVARCHAR(30) NOT NULL,
    [document_number] DECIMAL(15, 0) NOT NULL,
    [document_category] NVARCHAR(30) NOT NULL,
    [gl_date] DATE NOT NULL,
    [company] NVARCHAR(30) NOT NULL,
    [response] NVARCHAR(30) NOT NULL,
    [account] NVARCHAR(30) NOT NULL,
    [project] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [invcost] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [partner] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [product] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [customer] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [country] NVARCHAR(30) NOT NULL,
    [contract] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [purpose] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [as] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [taxper] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [abc] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [local1] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [local2] NVARCHAR(30) NOT NULL DEFAULT ((0)),
    [currency_code] NVARCHAR(3) NOT NULL,
    [conversion_type] NVARCHAR(15) NOT NULL,
    [currency_rate] DECIMAL(15, 0) NOT NULL,
    [conversion_date] DATE NOT NULL,
    [debet_sum] DECIMAL(15, 0) NOT NULL,
    [credit_sum] DECIMAL(15, 0) NOT NULL,
    [stat_amount] DECIMAL(15, 0) NOT NULL,
    [description] NVARCHAR(30) NOT NULL,
    [gldata_attribute1] NVARCHAR(150) NULL,
    [gldata_attribute2] NVARCHAR(150) NULL,
    [gldata_attribute3] NVARCHAR(150) NULL,
    [gldata_attribute4] NVARCHAR(150) NULL,
    [gldata_attribute5] NVARCHAR(150) NULL,
    [gldata_attribute6] NVARCHAR(150) NULL,
    [gldata_attribute7] NVARCHAR(150) NULL,
    [gldata_attribute8] NVARCHAR(150) NULL,
    [gldata_attribute9] NVARCHAR(150) NULL,
    [gldata_attribute10] NVARCHAR(150) NULL,
    [flex_build_flag] NVARCHAR(1) NULL,
    [tax_code] NVARCHAR(15) NOT NULL,
    CONSTRAINT [PK_KirjanpidonAineistoRivi] PRIMARY KEY CLUSTERED ([batch_id])
);
GO

-- Table: KorvausHinnasto
CREATE TABLE [dbo].[KorvausHinnasto] (
    [KHIId] INT IDENTITY(1,1) NOT NULL,
    [KHIAlkuPvm] DATE NULL,
    [KHILoppuPvm] DATE NULL,
    [KHISopimustyyppiId] INT NULL,
    [KHIHinnastoKategoriaId] INT NULL,
    [KHIHinnastoAlakategoriaId] INT NULL,
    [KHIKorvauslaji] NVARCHAR(500) NULL,
    [KHIKuvaus] NVARCHAR(500) NULL,
    [KHIArvonPeruste] NVARCHAR(500) NULL,
    [KHIMaksuAlueId] INT NULL,
    [KHIMetsatyyppiId] INT NULL,
    [KHIPuustolajiId] INT NULL,
    [KHIPuustonIka] INT NULL,
    [KHITaimistonValtapituus] DECIMAL(18, 2) NULL,
    [KHITiheyskerroin] DECIMAL(18, 2) NULL,
    [KHIYksikkkohinta] MONEY NULL,
    [KHIYksikkoId] INT NULL,
    [KHIYksikkohinnanTarkenne] NVARCHAR(500) NULL,
    [KHIAktiivinen] BIT NOT NULL DEFAULT ((1)),
    [KHIInfo] NVARCHAR(500) NULL,
    [KHILuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KHILuoja] NVARCHAR(50) NOT NULL,
    [KHIPaivittaja] NVARCHAR(50) NULL,
    [KHIPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Hinnasto] PRIMARY KEY CLUSTERED ([KHIId])
);
GO

-- Table: Korvauslaskelma
CREATE TABLE [dbo].[Korvauslaskelma] (
    [KORId] INT IDENTITY(1,1) NOT NULL,
    [KORSopimusId] INT NULL,
    [KORTahoId] INT NULL,
    [KORMaksualueId] INT NULL,
    [KORKorvaustyyppiId] INT NULL,
    [KORKorvauslaskelmaStatusId] INT NULL,
    [KORLaskennallinenKorvaus] MONEY NULL,
    [KORMaksettavaKorvaus] MONEY NULL,
    [KORMaksettavaKorvausAlkuperainen] MONEY NULL,
    [KORVanhaSopimusPaattyyiPvm] DATE NULL,
    [KORKorvausProsentti] DECIMAL(18, 0) NULL,
    [KORMaksuKuukausiId] INT NULL,
    [KORViimeisinMaksuPvm] DATE NULL,
    [KORViimeinenMaksuPvm] DATE NULL,
    [KOREnsimmainenSallittuMaksuPvm] DATE NULL,
    [KORSopimushetkenIndeksiArvo] INT NULL,
    [KORNykyinenIndeksiArvo] INT NULL,
    [KORIndeksityyppiId] INT NULL,
    [KORIndeksiKuukausiId] INT NULL,
    [KORIndeksiVuosi] INT NULL,
    [KORViite] NVARCHAR(300) NULL,
    [KORViesti] NVARCHAR(300) NULL,
    [KORProjektinumero] NVARCHAR(300) NULL,
    [KORKorvauksenProjektinumero] NVARCHAR(300) NULL,
    [KORMaksunSuoritusId] INT NULL,
    [KORPuustonOmistajuusId] INT NULL,
    [KORPuustonPoistoId] INT NULL,
    [KORInfo] NVARCHAR(500) NULL,
    [KORLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KORLuoja] NVARCHAR(50) NOT NULL,
    [KORPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KORPaivittaja] NVARCHAR(50) NULL,
    [KORKirjanpidonTiliId] INT NULL,
    [KORKirjanpidonKustannuspaikkaId] INT NULL,
    [KORInvCostId] INT NULL,
    [KORRegulationId] INT NULL,
    [KORPurposeId] INT NULL,
    [KORLocal1Id] INT NULL,
    [KORProjectno] NVARCHAR(300) NULL,
    [KORName] NVARCHAR(300) NULL,
    [KORTypeOfProject] NVARCHAR(300) NULL,
    [KORType] NVARCHAR(300) NULL,
    [KOROwner] NVARCHAR(300) NULL,
    [KORConcession] NVARCHAR(300) NULL,
    [KORCertDate] NVARCHAR(300) NULL,
    [KORFieldWorkStarted] DATE NULL,
    [KORProjectClosedA] DATE NULL,
    [KORMaksetaanAlv] BIT NOT NULL DEFAULT ((0)),
    [KOROnIndeksi] BIT NOT NULL DEFAULT ((0)),
    [KORMaksuehdotId] INT NULL,
    [KORViimeisinMaksu] MONEY NULL,
    [KORViimeisinIndeksi] INT NULL,
    [KORViimeisinMaksuIndeksi] INT NULL,
    [_korSqlId] INT NULL,
    [KOREnsimmainenMaksupaivaAsetettuKasin] BIT NULL DEFAULT ((0)),
    [KORViimeisinIndeksiVuosi] INT NULL,
    [KORAlvId] INT NULL,
    [KORCategory] NVARCHAR(50) NULL,
    CONSTRAINT [PK_Korvauslaskelma] PRIMARY KEY CLUSTERED ([KORId])
);
GO

-- Table: KorvauslaskelmaLoki
CREATE TABLE [dbo].[KorvauslaskelmaLoki] (
    [KLLId] INT IDENTITY(1,1) NOT NULL,
    [KLLKorvauslaskelmaId] INT NULL,
    [KLLStatusId] INT NULL,
    [KLLLuoja] NVARCHAR(50) NULL,
    [KLLLuotu] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_KorvauslaskelmaLoki] PRIMARY KEY CLUSTERED ([KLLId])
);
GO

-- Table: KorvauslaskelmaRivi
CREATE TABLE [dbo].[KorvauslaskelmaRivi] (
    [KLRId] INT IDENTITY(1,1) NOT NULL,
    [KLRKorvauslaskelmaId] INT NULL,
    [KLRKorvaushinnastoId] INT NULL,
    [KLRKorvaus] MONEY NULL,
    [KLRVanhaSopimusPaattyiPvm] DATE NULL,
    [KLRKorvausProsentti] INT NULL,
    [KLRKuvionTunnus] NVARCHAR(50) NULL,
    [KLRKuvionPituus] DECIMAL(18, 3) NULL,
    [KLRKuvionLeveys] DECIMAL(18, 3) NULL,
    [KLRKuvionKorvattavaLeveys] DECIMAL(18, 3) NULL,
    [KLRKokonaispintaAla] DECIMAL(18, 3) NULL,
    [KLRKokonaispintaAlaYksikkoId] INT NULL,
    [KLRMaara] DECIMAL(18, 3) NULL,
    [KLRInfo] NVARCHAR(MAX) NULL,
    [KLRLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [KLRLuoja] NVARCHAR(50) NOT NULL,
    [KLRPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [KLRPaivittaja] NVARCHAR(50) NULL,
    [KLRKirjanpidonTiliId] INT NULL,
    [KLRKirjanpidonKustannuspaikkaId] INT NULL,
    [KLRYksikkohinta] DECIMAL(18, 2) NULL,
    [KLRInvCostId] INT NULL,
    [KLRRegulationId] INT NULL,
    [KLRPurposeId] INT NULL,
    [KLRLocal1Id] INT NULL,
    [_klrSqlId] INT NULL,
    CONSTRAINT [PK_Tuote] PRIMARY KEY CLUSTERED ([KLRId])
);
GO

-- Table: Maksu
CREATE TABLE [dbo].[Maksu] (
    [MAKId] INT IDENTITY(1,1) NOT NULL,
    [MAKMaksuaineistoId] INT NULL,
    [MAKKorvauslaskelmaId] INT NULL,
    [MAKMaksupaiva] DATE NULL,
    [MAKSumma] MONEY NULL,
    [MAKVero] MONEY NULL,
    [MAKTilinumero] NVARCHAR(100) NULL,
    [MAKBic] NVARCHAR(50) NULL,
    [MAKViite] NVARCHAR(300) NULL,
    [MAKViesti] NVARCHAR(300) NULL,
    [MAKIndeksiKuukausiId] INT NULL,
    [MAKIndeksi] INT NULL,
    [MAKKirjanpidonTiliId] INT NULL,
    [MAKKustannuspaikka] NVARCHAR(300) NULL,
    [MAKMaksuStatusId] INT NULL,
    [MAKLaskunNumero] NVARCHAR(300) NULL,
    [MAKEraTunniste] NVARCHAR(300) NULL,
    [MAKAjoPvm] DATE NULL,
    [MAKVuosi] INT NULL,
    [MAKInfo] NVARCHAR(500) NULL,
    [MAKLuotu] DATETIME NULL,
    [MAKLuoja] NVARCHAR(50) NULL,
    [MAKPaivitetty] DATETIME NULL,
    [MAKPaivittaja] NVARCHAR(50) NULL,
    [MAKSaajaId] INT NULL,
    [MAKSaaja] NVARCHAR(300) NULL,
    [MAKOnIndeksi] BIT NOT NULL DEFAULT ((0)),
    [MAKIndeksityyppiId] INT NULL,
    [MAKMaksuIndeksi] INT NULL,
    [MAKAlvOsuus] MONEY NULL,
    [_makSqlId] INT NULL,
    [MAKJuridinenYhtioId] INT NULL,
    [MAKMaksajanNimi] VARCHAR(300) NULL,
    [MAKMaksajanTilinro] VARCHAR(50) NULL,
    [MAKMaksajanBicKoodi] VARCHAR(50) NULL,
    [MAKSopimusId] INT NULL,
    [MAKKirjanpidonTunniste] VARCHAR(50) NULL,
    [MAKPalvelutunnus] VARCHAR(50) NULL,
    [MAKPassivoitu] BIT NOT NULL DEFAULT ((0)),
    [MAKSummaIlmanAlv] MONEY NULL,
    [MAKIndeksiVuosi] INT NULL,
    [MAKAlv] DECIMAL(18, 2) NULL,
    [MAKIfsMaksupvm] DATETIME NULL,
    [MAKIfsLaskunro] VARCHAR(50) NULL,
    CONSTRAINT [PK_Maksu] PRIMARY KEY CLUSTERED ([MAKId])
);
GO

-- Table: Maksu_Tiliointi
CREATE TABLE [dbo].[Maksu_Tiliointi] (
    [MTLId] INT IDENTITY(1,1) NOT NULL,
    [MTLMaksuId] INT NOT NULL,
    [MTLSumma] MONEY NULL,
    [MTLProjektinro] NVARCHAR(50) NULL,
    [MTLKirjanpidontili] NVARCHAR(50) NULL,
    [MTLKustannuspaikka] NVARCHAR(50) NULL,
    [MTLInvCost] NVARCHAR(50) NULL,
    [MTLRegulation] NVARCHAR(50) NULL,
    [MTLPurpose] NVARCHAR(50) NULL,
    [MTLLocal1] NVARCHAR(50) NULL,
    [MTLLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [MTLLuoja] NVARCHAR(50) NOT NULL,
    [MTLAlvOsuus] MONEY NULL,
    [MTLSummaIlmanAlv] MONEY NULL,
    [MTLCategory] NVARCHAR(50) NULL,
    CONSTRAINT [PK_Maksu_Tiliointi] PRIMARY KEY CLUSTERED ([MTLId])
);
GO

-- Table: Maksuaineisto
CREATE TABLE [dbo].[Maksuaineisto] (
    [MAIId] INT IDENTITY(1,1) NOT NULL,
    [MAILuotu] DATETIME NULL,
    [MAILuoja] NVARCHAR(50) NULL,
    [MAIPaivitetty] DATETIME NULL,
    [MAIPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_Maksuaineisto] PRIMARY KEY CLUSTERED ([MAIId])
);
GO

-- Table: PcsSummaryRaportti
CREATE TABLE [dbo].[PcsSummaryRaportti] (
    [PSRId] INT IDENTITY(1,1) NOT NULL,
    [PSRProjectno] NVARCHAR(50) NOT NULL,
    [PSRName] NVARCHAR(300) NULL,
    [PSRTypeOfProject] NVARCHAR(50) NULL,
    [PSRType] NVARCHAR(50) NULL,
    [PSRCategory] NVARCHAR(50) NULL,
    [PSROwner] NVARCHAR(50) NULL,
    [PSRConcession] NVARCHAR(50) NULL,
    [PSRCertDate] VARCHAR(50) NULL,
    [PSRFieldWorkStartedA] DATETIME NULL,
    [PSRProjectClosedA] DATETIME NULL,
    [PSREra] VARCHAR(50) NOT NULL,
    [PSRLuoja] NVARCHAR(50) NOT NULL,
    [PSRLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_PcsSummaryRaportti] PRIMARY KEY CLUSTERED ([PSRId])
);
GO

-- Table: Poiminta
CREATE TABLE [dbo].[Poiminta] (
    [POPoimintaid] INT IDENTITY(1,1) NOT NULL,
    [POEntityId] INT NULL,
    [POSession] VARCHAR(50) NULL,
    [PORnd] UNIQUEIDENTIFIER NULL,
    [POLuotu] DATETIME NULL DEFAULT (getdate()),
    [POTyyppi] VARCHAR(50) NULL,
    CONSTRAINT [PK_Poiminta] PRIMARY KEY CLUSTERED ([POPoimintaid])
);
GO

-- Table: Sopimus
CREATE TABLE [dbo].[Sopimus] (
    [SOPId] INT IDENTITY(1,1) NOT NULL,
    [SOPSopimustyyppiId] INT NULL,
    [SOPPaasopimusId] INT NULL,
    [SOPAlkaa] DATE NULL,
    [SOPPaattyy] DATE NULL,
    [SOPKestoId] INT NULL,
    [SOPProjektiAloitusPvm] DATE NULL,
    [SOPMuuTunniste] NVARCHAR(300) NULL,
    [SOPIban] NVARCHAR(50) NULL,
    [SOPJuridinenYhtioId] INT NULL,
    [SOPSopimuksenLaatija] NVARCHAR(300) NULL,
    [SOPVastuuyksikkoId] INT NULL,
    [SOPProjektinumero] NVARCHAR(50) NULL,
    [SOPPylvasmaara] INT NULL,
    [SOPLuonnonsuojelualue] BIT NOT NULL DEFAULT ((0)),
    [SOPPylvasvali] NVARCHAR(300) NULL,
    [SOPMaantieteellinenVali] NVARCHAR(300) NULL,
    [SOPMuuntamoalue] DECIMAL(18, 0) NULL,
    [SOPJulkisuusasteId] INT NULL,
    [SOPKorvaa] NVARCHAR(50) NULL,
    [SOPSopimuksenTilaId] INT NULL,
    [SOPSopimusvuosi] NVARCHAR(50) NULL,
    [SOPInfo] NVARCHAR(4000) NULL,
    [SOPLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SOPLuoja] NVARCHAR(50) NOT NULL,
    [SOPPaivittaja] NVARCHAR(50) NULL,
    [SOPPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [_JasId] INT NULL,
    [_SQLId] INT NULL,
    [_kiineistotunnus] VARCHAR(50) NULL,
    [_kiinteistotunnus] VARCHAR(50) NULL,
    [SOPAlkuperainenKorvaus] DECIMAL(18, 0) NULL,
    [SOPDFRooliId] INT NULL,
    [SOPSopimusluokkaId] INT NULL,
    [SOPSopimuksenAlaluokkaId] INT NULL,
    [SOPSopimuksenEhtoversioId] INT NULL,
    [SOPKarttaliite] NVARCHAR(MAX) NULL,
    [SOPKuvaus] NVARCHAR(MAX) NULL,
    [SOPVerkonhaltijanAllekirjoitusPvm] DATE NULL,
    [SOPAsiakkaanAllekirjoitusPvm] DATE NULL,
    [SOPSopimuksenIrtisanomisaika] INT NULL,
    [SOPSopimuksenIrtisanomistoimet] NVARCHAR(MAX) NULL,
    [SOPVerkohaltijaSiirtoOikeusId] INT NULL,
    [SOPVastaosapuoliSiirtoOikeusId] INT NULL,
    [SOPAlkuperainenYhtioId] INT NULL,
    [SOPIrtisanomispvm] DATE NULL,
    [SOPPCSNumero] NVARCHAR(300) NULL,
    [SOPProjektinvalvoja] NVARCHAR(300) NULL,
    [SOPPuustonPoistoId] INT NULL,
    [SOPPuustonOmistajuusId] INT NULL,
    [SOPJatkoaika] INT NULL,
    [SOPLaskennallinenPaattymispvm] DATETIME NULL,
    [SOPKohdekategoriaId] INT NULL,
    [SOPTiedostoHaettu] BIT NOT NULL DEFAULT ((0)),
    [SOPMetatiedotPaivitetty] BIT NOT NULL DEFAULT ((0)),
    [SOPLuonnos] BIT NOT NULL DEFAULT ((0)),
    [SOPKieliId] INT NULL,
    [SOPErityisehdot] VARCHAR(300) NULL,
    [SOPYlasopimuksenTyyppiId] INT NULL,
    [SOPKorvaukseton] BIT NOT NULL DEFAULT ((0)),
    [SOPLupatahoId] INT NULL,
    [SOPMappitunniste] NVARCHAR(300) NULL,
    [SOPCaceTehtava] NVARCHAR(300) NULL,
    [SOPVerkonhaltijaAllekirjoittaja] NVARCHAR(300) NULL,
    [SOPSopimusarkistosiirtoTehty] DATETIME NULL,
    [SOPGuid] VARCHAR(300) NULL,
    [SOPVuokratyyppiId] INT NULL,
    [SOPKorkoprosentti] DECIMAL(18, 6) NULL,
    [SOPLahdeKorkoprosenttiId] INT NULL,
    [SOPFAS] BIT NOT NULL DEFAULT ((0)),
    [SOPIFRS] BIT NOT NULL DEFAULT ((0)),
    CONSTRAINT [PK_Sopimus] PRIMARY KEY CLUSTERED ([SOPId])
);
GO

-- Table: Sopimus_Kiinteisto
CREATE TABLE [dbo].[Sopimus_Kiinteisto] (
    [SKId] INT IDENTITY(1,1) NOT NULL,
    [SKSopimusId] INT NOT NULL,
    [SKKiinteistoId] INT NOT NULL,
    [SKLuoja] NVARCHAR(50) NOT NULL,
    [SKLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SKPaivittaja] NVARCHAR(50) NULL,
    [SKPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SKExcelTuontiId] INT NULL,
    CONSTRAINT [PK_Sopimus_Kiinteisto] PRIMARY KEY CLUSTERED ([SKId])
);
GO

-- Table: Sopimus_Taho
CREATE TABLE [dbo].[Sopimus_Taho] (
    [SOTId] INT IDENTITY(1,1) NOT NULL,
    [SOTSopimusId] INT NOT NULL,
    [SOTTahoId] INT NOT NULL,
    [SOTAsiakastyyppiId] INT NULL,
    [SOTLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [SOTLuoja] NVARCHAR(50) NOT NULL,
    [SOTPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [SOTPaivittaja] NVARCHAR(50) NULL,
    [SOTDFRooliId] INT NULL,
    [SOTTulostetaanSopimukseen] BIT NOT NULL DEFAULT ((1)),
    [STExcelTuontiId] INT NULL,
    [SOTExcelTuontiId] INT NULL,
    CONSTRAINT [PK_Sopimus_Taho] PRIMARY KEY CLUSTERED ([SOTId])
);
GO

-- Table: Sopimus_Tuloste
CREATE TABLE [dbo].[Sopimus_Tuloste] (
    [STLId] INT IDENTITY(1,1) NOT NULL,
    [STLSopimusId] INT NOT NULL,
    [STLTuloste] VARBINARY(MAX) NOT NULL,
    [STLLuoja] NVARCHAR(50) NOT NULL,
    [STLLuotu] DATETIME NOT NULL DEFAULT (getdate()),
    [STLPaivittaja] NVARCHAR(50) NULL,
    [STLPaivitetty] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Sopimus_Tuloste] PRIMARY KEY CLUSTERED ([STLId])
);
GO

-- Table: SopimusarkistoLoki
CREATE TABLE [dbo].[SopimusarkistoLoki] (
    [SALId] INT IDENTITY(1,1) NOT NULL,
    [SALTunnistetyyppi] VARCHAR(50) NULL,
    [SALTunniste] VARCHAR(300) NULL,
    [SALOperaatio] VARCHAR(50) NULL,
    [SALTulos] VARCHAR(2048) NULL,
    [SALLuoja] VARCHAR(300) NULL,
    [SALLuotu] DATETIME NULL DEFAULT (getdate()),
    CONSTRAINT [PK_SopimusarkistoLoki] PRIMARY KEY CLUSTERED ([SALId])
);
GO

-- Table: Taho
CREATE TABLE [dbo].[Taho] (
    [TAHTahoId] INT IDENTITY(1,1) NOT NULL,
    [TAHTyyppiId] INT NULL,
    [TAHSukunimi] NVARCHAR(300) NULL,
    [TAHEdellinenSukunimi] NVARCHAR(300) NULL,
    [TAHEtunimi] NVARCHAR(300) NULL,
    [TAHNimitarkenne] NVARCHAR(300) NULL,
    [TAHOrganisaationTyyppiId] INT NULL,
    [TAHYtunnus] NVARCHAR(300) NULL,
    [TAHLisaosoite] NVARCHAR(300) NULL,
    [TAHPostitusosoite] NVARCHAR(300) NULL,
    [TAHPostituspostinro] NVARCHAR(300) NULL,
    [TAHPostituspostitmp] NVARCHAR(300) NULL,
    [TAHMaaId] INT NULL,
    [TAHTilinumero] NVARCHAR(300) NULL,
    [TAHPuhelin] NVARCHAR(300) NULL,
    [TAHEmail] NVARCHAR(300) NULL,
    [TAHAlvVelvollinen] BIT NOT NULL DEFAULT ((0)),
    [TAHPassivointipvm] DATETIME NULL,
    [TAHPassivoinninsyyId] INT NULL,
    [TAHAktiivi] BIT NOT NULL,
    [TAHInfo] NVARCHAR(1000) NULL,
    [TAHPaivittaja] NVARCHAR(50) NULL,
    [TAHPaivitetty] DATETIME NULL,
    [TAHLuotu] DATETIME NOT NULL,
    [TAHLuoja] NVARCHAR(50) NULL,
    [_tahsqlid] INT NULL,
    [TAHKuntaId] INT NULL,
    [TAHBic] NVARCHAR(50) NULL,
    [TAHBicKoodiId] INT NULL,
    [TAHKirjanpidonYritystunniste] VARCHAR(50) NULL,
    [TAHKirjanpidonProjektitunniste] VARCHAR(50) NULL,
    [TAHConcession] VARCHAR(50) NULL,
    [_tahsqlid2] INT NULL,
    [TAHExcelTuontiId] INT NULL,
    [_SOHATempGuid] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Taho] PRIMARY KEY CLUSTERED ([TAHTahoId])
);
GO

-- Table: TallennettuPoimintaehto
CREATE TABLE [dbo].[TallennettuPoimintaehto] (
    [TPEId] INT IDENTITY(1,1) NOT NULL,
    [TPEPoimintaTyyppi] VARCHAR(50) NOT NULL,
    [TPENimi] VARCHAR(50) NOT NULL,
    [TPELuotu] DATETIME NOT NULL,
    [TPELuoja] VARCHAR(50) NOT NULL,
    [TPEPaivitetty] DATETIME NULL,
    [TPEPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_TallennettuPoimintaehto] PRIMARY KEY CLUSTERED ([TPEId])
);
GO

-- Table: TallennettuPoimintaehto_Ehto
CREATE TABLE [dbo].[TallennettuPoimintaehto_Ehto] (
    [TPEEId] INT IDENTITY(1,1) NOT NULL,
    [TPEEEhtojoukkoId] INT NOT NULL,
    [TPEEKentta] VARCHAR(50) NOT NULL,
    [TPEEOperaattori] VARCHAR(50) NOT NULL,
    [TPEEArvo] VARCHAR(200) NOT NULL,
    [TPEELuotu] DATETIME NOT NULL,
    [TPEELuoja] VARCHAR(50) NOT NULL,
    [TPEEPaivitetty] DATETIME NULL,
    [TPEEPaivittaja] NVARCHAR(50) NULL,
    [TPEETekstikentta] BIT NULL,
    [TPEEKenttaNaytolle] VARCHAR(50) NULL,
    [TPEEOperaattoriNaytolle] VARCHAR(50) NULL,
    [TPEEArvoNaytolle] VARCHAR(200) NULL,
    CONSTRAINT [PK_TallennettuPoimintaehto_Ehto] PRIMARY KEY CLUSTERED ([TPEEId])
);
GO

-- Table: TallennettuPoimintajoukko
CREATE TABLE [dbo].[TallennettuPoimintajoukko] (
    [TPJId] INT IDENTITY(1,1) NOT NULL,
    [TPJNimi] VARCHAR(50) NOT NULL,
    [TPJLuotu] DATETIME NOT NULL,
    [TPJLuoja] VARCHAR(50) NOT NULL,
    [TPJPaivitetty] DATETIME NULL,
    [TPJPaivittaja] NVARCHAR(50) NULL,
    CONSTRAINT [PK_TallennettuPoimintajoukko] PRIMARY KEY CLUSTERED ([TPJId])
);
GO

-- Table: TallennettuPoimintajoukko_Taho
CREATE TABLE [dbo].[TallennettuPoimintajoukko_Taho] (
    [TPJTId] INT IDENTITY(1,1) NOT NULL,
    [TPJTTallennettuPoimintajoukkoId] INT NOT NULL,
    [TPJTEsineId] INT NOT NULL,
    [TPJTLuotu] DATETIME NOT NULL,
    [TPJTLuoja] VARCHAR(50) NOT NULL,
    [TPJTPaivitetty] DATETIME NULL,
    [TPJTPaivittaja] NVARCHAR(50) NULL,
    [TPJTEsineTyyppi] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_TallennettuPoimintajoukko_Taho] PRIMARY KEY CLUSTERED ([TPJTId])
);
GO

-- Table: Tiedosto
CREATE TABLE [dbo].[Tiedosto] (
    [TIEId] INT IDENTITY(1,1) NOT NULL,
    [TIETiedostoNimi] NVARCHAR(300) NULL,
    [TIEURL] NVARCHAR(300) NULL,
    [TIESelite] NVARCHAR(300) NULL,
    [TIETiedostoLahdeId] INT NULL,
    [TIESopimusId] INT NULL,
    [TIESharePointId] INT NULL,
    [TIEArkistonSijaintiId] INT NULL,
    [TIEDocumentID] NVARCHAR(50) NULL,
    [TIEArkistointiTunniste] NVARCHAR(300) NULL,
    [TIESivuja] INT NULL,
    [TIEInfo] NVARCHAR(500) NULL,
    [TIELuotu] DATETIME NOT NULL,
    [TIELuoja] VARCHAR(50) NOT NULL,
    [TIEPaivitetty] DATETIME NULL,
    [TIEPaivittaja] NVARCHAR(50) NULL,
    [TIEAsiakirjaTarkenneId] INT NULL,
    [TIESopimusFormaattiId] INT NULL,
    [TIEAsiakirjatarkenne] VARCHAR(300) NULL,
    [TIEMFilesVault] UNIQUEIDENTIFIER NULL,
    [TIEMFilesType] INT NOT NULL DEFAULT ((0)),
    [TIEMFilesId] INT NULL,
    [TIEMFilesObject] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_TIedosto] PRIMARY KEY CLUSTERED ([TIEId])
);
GO

-- Table: TiedostoImport
CREATE TABLE [dbo].[TiedostoImport] (
    [TIIId] INT IDENTITY(1,1) NOT NULL,
    [TIITiedostoId] INT NULL,
    [TIISopimusId] INT NULL,
    [TIITiedostoNimi] VARCHAR(600) NULL,
    [TIIMFilesVault] VARCHAR(600) NULL,
    [TIIMFilesType] INT NULL,
    [TIIMFilesId] INT NULL,
    [TIIMFilesObject] VARCHAR(600) NULL,
    [TIILuotu] DATETIME NOT NULL,
    [TIILuoja] VARCHAR(300) NOT NULL,
    [TIISessio] VARCHAR(300) NOT NULL,
    [TIIKasitelty] BIT NOT NULL DEFAULT ((0)),
    CONSTRAINT [PK__Tiedosto__BE2876AB01B99279] PRIMARY KEY CLUSTERED ([TIIId])
);
GO

-- Table: Tunnisteyksikko
CREATE TABLE [dbo].[Tunnisteyksikko] (
    [TUYId] INT IDENTITY(1,1) NOT NULL,
    [TUYTunnus] NVARCHAR(300) NULL,
    [TUYNimi] NVARCHAR(300) NULL,
    [TUYLinjaOsa] NVARCHAR(300) NULL,
    [TUYPGTunniste] NVARCHAR(300) NULL,
    [TUYKoordinaatit] NVARCHAR(300) NULL,
    [TUYSopimusId] INT NULL,
    [TUYInfo] NVARCHAR(500) NULL,
    [TUYLuotu] DATETIME NULL DEFAULT (getdate()),
    [TUYLuoja] NVARCHAR(50) NULL,
    [TUYPaivitetty] DATETIME NULL DEFAULT (getdate()),
    [TUYPaivittaja] NVARCHAR(50) NULL,
    [TUYAktiivinen] BIT NOT NULL DEFAULT ((1)),
    [TUYPGTunnus] NVARCHAR(300) NULL,
    [TUYPGKoordinaatti1] INT NULL,
    [TUYPGKoordinaatti2] INT NULL,
    [TUYTunnisteyksikkoTyyppiId] INT NULL,
    [TUYKohdetieto] NVARCHAR(300) NULL,
    [_tuySqlId] INT NULL,
    [_SOHATempGuid] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Tunnisteyksikko] PRIMARY KEY CLUSTERED ([TUYId])
);
GO

