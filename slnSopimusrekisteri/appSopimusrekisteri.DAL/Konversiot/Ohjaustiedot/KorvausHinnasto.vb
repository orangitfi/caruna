Namespace Konversiot
  Public Class KorvausHinnasto

    Public Shared Function MuutaEntityksi(muunnettavat As IEnumerable(Of DTO.Korvaushinnasto)) As List(Of Entities.KorvausHinnasto)

      Dim tulokset = New List(Of Entities.KorvausHinnasto)
      For Each muunnettava In muunnettavat
        tulokset.Add(MuutaEntityksi(muunnettava))
      Next
      Return tulokset

    End Function

    Public Shared Function MuutaEntityksi(muunnettava As DTO.Korvaushinnasto) As Entities.KorvausHinnasto

      Dim tulos = New Entities.KorvausHinnasto()

      tulos.KHIId = muunnettava.Id
      tulos.KHIKorvauslaji = muunnettava.Korvauslaji
      tulos.KHIKuvaus = muunnettava.Kuvaus
      If muunnettava.SopimustyyppiId.HasValue Then tulos.KHISopimustyyppiId = muunnettava.SopimustyyppiId
      If muunnettava.YksikkoId.HasValue Then tulos.KHIYksikkoId = muunnettava.YksikkoId
      If muunnettava.Yksikkohinta.HasValue Then tulos.KHIYksikkkohinta = muunnettava.Yksikkohinta
      tulos.KHIYksikkohinnanTarkenne = muunnettava.YksikkohinnanTarkenne
      If muunnettava.MetsatyyppiId.HasValue Then tulos.KHIMetsatyyppiId = muunnettava.MetsatyyppiId
      If muunnettava.PuustolajiId.HasValue Then tulos.KHIPuustolajiId = muunnettava.PuustolajiId
      If muunnettava.HinnastoKategoriaId.HasValue Then tulos.KHIHinnastoKategoriaId = muunnettava.HinnastoKategoriaId
      If muunnettava.HinnastoAlakategoriaId.HasValue Then tulos.KHIHinnastoAlakategoriaId = muunnettava.HinnastoAlakategoriaId
      tulos.KHIArvonPeruste = muunnettava.ArvonPeruste
      If muunnettava.MaksuAlueId.HasValue Then tulos.KHIMaksuAlueId = muunnettava.MaksuAlueId
      If muunnettava.PuustonIka.HasValue Then tulos.KHIPuustonIka = muunnettava.PuustonIka
      If muunnettava.TaimistonValtapituus.HasValue Then tulos.KHITaimistonValtapituus = muunnettava.TaimistonValtapituus
      If muunnettava.Tiheyskerroin.HasValue Then tulos.KHITiheyskerroin = muunnettava.Tiheyskerroin
      If muunnettava.Alkupvm.HasValue Then tulos.KHIAlkuPvm = muunnettava.Alkupvm
      If muunnettava.Loppupvm.HasValue Then tulos.KHILoppuPvm = muunnettava.Loppupvm

      tulos.KHIAktiivinen = muunnettava.Aktiivinen
      tulos.KHIInfo = muunnettava.Info
      tulos.KHILuotu = muunnettava.Luotu
      tulos.KHILuoja = muunnettava.Luoja
      tulos.KHIPaivittaja = muunnettava.Paivittaja
      If muunnettava.Paivitetty.HasValue Then tulos.KHIPaivitetty = muunnettava.Paivitetty

      Return tulos

    End Function

  End Class

End Namespace
