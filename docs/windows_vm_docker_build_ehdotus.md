# Ehdotus: Mac-kehitys, Windows VM -build ja Docker-container build-komentoriviltä

## 1. Tavoite

Tavoite on pitää kehitystyö sujuvana Macilla ja käyttää Windows-ympäristöä vain siihen, mitä legacy WebForms -ratkaisu oikeasti tarvitsee:

- .NET Framework 4.x build
- WebForms-ajon verifiointi
- mahdollinen julkaisuverifiointi

## 2. Suositeltu työnjako

Mac (päivittäinen kehitys):

- Koodimuutokset
- Git commit ja push
- SQL Dockerissa (jo käytössä)
- Dokumentointi, analyysi, refaktorointi

Windows VM (build ja runtime-verifiointi):

- Git pull
- NuGet restore
- MSBuild
- Sovelluksen käynnistys ja smoke-testit

## 3. Miksi tämä malli

- Legacy WebForms ja .NET Framework vaativat Windows-työkaluketjun.
- Macilla kehitys on kevyempää ja nopeampaa editorityössä.
- VM:n hitaus haittaa vähemmän, jos VM:ää käytetään vain buildiin ja testiajoon.

## 4. Build komentoriviltä Docker-containerissa

Tärkeä huomio:

- Tämä toimii vain Windows-hostissa (tai Windows VM:ssä), jossa Docker pyörii Windows container -tilassa.
- Tämä ei toimi suoraan macOS Docker Desktopilla tämän legacy-ratkaisun buildiin.

### 4.1 Esimerkkikomento (Windows VM)

PowerShell-komento, joka buildaa ratkaisun Docker Windows -containerissa:

  docker run --rm `
    -v C:\caruna:C:\src `
    -w C:\src\slnSopimusrekisteri `
    mcr.microsoft.com/dotnet/framework/sdk:4.8 `
    powershell -NoProfile -Command "nuget restore .\slnSopimusrekisteri.sln; msbuild .\slnSopimusrekisteri.sln /m /p:Configuration=Debug /t:Build"

Jos NuGet restore ei onnistu containerissa, käytä kahta vaihetta:

1. Restore VM:ssä hostilla
2. Build containerissa

## 5. Käytännöllinen fallback (suositus)

Jos container-build on epävakaa legacy-riippuvuuksien takia, käytä VM:ssä natiivia buildia:

  nuget restore C:\caruna\slnSopimusrekisteri\slnSopimusrekisteri.sln
  msbuild C:\caruna\slnSopimusrekisteri\slnSopimusrekisteri.sln /m /p:Configuration=Debug /t:Build

Tämä on yleensä luotettavin tapa vanhoille WebForms-ratkaisuille.

## 6. Päivittäinen workflow

1. Tee muutos Macilla
2. Commit ja push
3. Avaa Windows VM
4. Pull ja build (containerissa tai natiivisti)
5. Aja smoke-testit
6. Tee korjaukset taas Macilla

## 7. Minimivaatimukset Windows VM:lle

- Windows 11
- 4 vCPU, mieluummin 6 vCPU
- 8 GB RAM minimi, 12 GB suositus
- 100 GB levy minimi
- .NET Framework 4.8 Developer Pack
- Build Tools tai Visual Studio 2022

## 8. Päätelmä

Tämä malli on kömpelö mutta käytännössä toimiva legacy-projektille:

- Mac pitää kehityksen sujuvana
- Windows VM varmistaa buildin ja ajon
- Docker-container build on mahdollinen lisä, jos halutaan toistettavuutta build-vaiheeseen
