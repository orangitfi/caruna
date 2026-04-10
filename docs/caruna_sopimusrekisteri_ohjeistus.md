# Caruna sopimusrekisteri ohjeistus 

Käykää läpi tämä ohjeistus huolellisesti ennen asennusta. Ohjeistus
sisältää huomioita liittyen web/app.config-tiedostoihin sekä
dev-haarasta löytyviin kehitystöihin.

# Web/app.config-tiedostot 

Tämä osio sisältää ohjeita/huomioita liittyen
web/app.config-tiedostoihin. Käykää ainakin nämä kohdat läpi ennen
asennusta.

## slnSopimusrekisteri 

### appSopimusrekisteri 

**Sähköpostit (Rivit 44-47)\**
Täydentäkää tähän tiedot sähköpostien lähettämistä varten.

**EvoPdf-lisenssi (Rivi 59)\**
Rekisterissä on käytössä EvoPdf-kirjasto, jonka avulla järjestelmä luo
PDF-tiedostoja. Jotta tämä toimii myös jatkossa, teidän on hankittava
oma lisenssi. [Carunan ympäristöissä (dev, test ja tuotanto) valmiina
oleva lisenssiavain on Kehätiedon ja se tulee poistaa, sitä ei saa
käyttää.]

Lisenssin voitte hankkia täältä: [Buy EVO HTML to PDF Converter for .NET
License \| Online Purchase](https://www.evopdf.com/buy.aspx)

**ConnectionStrings (Rivit 69-71)**

Korvatkaa merkittyihin kohtiin palvelimen ja tietokannan tiedot.

### Sopimusrekisteri.Yllapitoajo 

**ConnectionStrings (Rivi 8)**

Korvatkaa merkittyihin kohtiin palvelimen ja tietokannan tiedot.

### appSopimusrekisteri.Entities 

**ConnectionStrings (Rivi 30)**\
Korvatkaa merkittyihin kohtiin palvelimen ja tietokannan tiedot.

## slnIFSIntegraatio 

**ConnectionStrings (Rivi 8)**\
Korvatkaa merkittyihin kohtiin palvelimen ja tietokannan tiedot.

## slnSopimusarkistoSiirto {

**ConnectionStrings (Rivi 8)**\
Korvatkaa merkittyihin kohtiin palvelimen ja tietokannan tiedot.

# Dev-haaraan tehdyt kehitystyöt 

Dev-haarasta löytyy kehitystöitä, jotka on asennettu Carunalle
testattavaksi dev- ja test-ympäristöihin. Koska Kehätieto ei ole saanut
erillistä lupaa asentaa muutoksia tuotantoon, niitä ei ole mergetty
vielä main-haaraan. Alla on listaus muutoksista:

- Muutoksia IFRS-raporttiin: lisätty "Maksun suoritus" ja "Maksetaan
  ALV" kentät.

- Muutettu logiikkaa laskennallisen päättymispäivän päättelemisessä, kun
  sopimus tallennetaan.

- IFRS-exceliin laitettu punaisella päättymispäivät, jotka ovat
  menneisyydessä.

- Vuokratyyppisien sopimusten korvauslaskelmaan lisätty
  indeksiehto-toiminto.

- Kiinteistön tiedoissa omistusosuus-kenttä ottaa vain lukuarvon.

- IFRS-raportille otetaan myös henkilöt, joilla ei ole korvauslaskelmia.

- Sopimusten massatuontiin lisätty laskennallisen päivämäärän
  laskeminen.
