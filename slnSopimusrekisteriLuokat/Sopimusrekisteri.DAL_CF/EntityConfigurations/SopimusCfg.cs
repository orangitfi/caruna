using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF
{
    public class SopimusCfg : EntityTypeConfiguration<Sopimus>
    {
        public SopimusCfg()
        {

            ToTable("Sopimus");
            HasKey(x => x.Id);
            Property(x => x.Alkaa).HasColumnName("SOPAlkaa");
            Property(x => x.AlkuperainenKorvaus).HasColumnName("SOPAlkuperainenKorvaus");
            Property(x => x.AlkuperainenYhtioId).HasColumnName("SOPAlkuperainenYhtioId");
            Property(x => x.AsiakkaanAllekirjoitusPvm).HasColumnName("SOPAsiakkaanAllekirjoitusPvm");
            Property(x => x.CaceTehtava).HasColumnName("SOPCaceTehtava");
            Property(x => x.DFRooliId).HasColumnName("SOPDFRooliId");
            Property(x => x.Erityisehdot).HasColumnName("SOPErityisehdot");
            Property(x => x.Iban).HasColumnName("SOPIban");
            Property(x => x.Id).HasColumnName("SOPId");
            Property(x => x.Info).HasColumnName("SOPInfo");
            Property(x => x.Irtisanomispvm).HasColumnName("SOPIrtisanomispvm");
            Property(x => x.Jatkoaika).HasColumnName("SOPJatkoaika");
            Property(x => x.JulkisuusasteId).HasColumnName("SOPJulkisuusasteId");
            Property(x => x.JuridinenYhtioId).HasColumnName("SOPJuridinenYhtioId");
            Property(x => x.Karttaliite).HasColumnName("SOPKarttaliite");
            Property(x => x.KestoId).HasColumnName("SOPKestoId");
            Property(x => x.KieliId).HasColumnName("SOPKieliId");
            Property(x => x.KohdekategoriaId).HasColumnName("SOPKohdekategoriaId");
            Property(x => x.Korvaa).HasColumnName("SOPKorvaa");
            Property(x => x.Korvaukseton).HasColumnName("SOPKorvaukseton");
            Property(x => x.Kuvaus).HasColumnName("SOPKuvaus");
            Property(x => x.Luoja).HasColumnName("SOPLuoja");
            Property(x => x.Luonnonsuojelualue).HasColumnName("SOPLuonnonsuojelualue");
            Property(x => x.Luonnos).HasColumnName("SOPLuonnos");
            Property(x => x.Luotu).HasColumnName("SOPLuotu");
            Property(x => x.LupatahoId).HasColumnName("SOPLupatahoId");
            Property(x => x.MaantieteellinenVali).HasColumnName("SOPMaantieteellinenVali");
            Property(x => x.Mappitunniste).HasColumnName("SOPMappitunniste");
            Property(x => x.MetatiedotPaivitetty).HasColumnName("SOPMetatiedotPaivitetty");
            Property(x => x.Muuntamoalue).HasColumnName("SOPMuuntamoalue");
            Property(x => x.MuuTunniste).HasColumnName("SOPMuuTunniste");
            Property(x => x.PaasopimusId).HasColumnName("SOPPaasopimusId");
            Property(x => x.Paattyy).HasColumnName("SOPPaattyy");
            Property(x => x.Paivitetty).HasColumnName("SOPPaivitetty");
            Property(x => x.Paivittaja).HasColumnName("SOPPaivittaja");
            Property(x => x.PCSNumero).HasColumnName("SOPPCSNumero");
            Property(x => x.ProjektiAloitusPvm).HasColumnName("SOPProjektiAloitusPvm");
            Property(x => x.Projektinumero).HasColumnName("SOPProjektinumero");
            Property(x => x.Projektinvalvoja).HasColumnName("SOPProjektinvalvoja");
            Property(x => x.PuustonOmistajuusId).HasColumnName("SOPPuustonOmistajuusId");
            Property(x => x.PuustonPoistoId).HasColumnName("SOPPuustonPoistoId");
            Property(x => x.Pylvasmaara).HasColumnName("SOPPylvasmaara");
            Property(x => x.Pylvasvali).HasColumnName("SOPPylvasvali");
            Property(x => x.SopimuksenAlaluokkaId).HasColumnName("SOPSopimuksenAlaluokkaId");
            Property(x => x.SopimuksenEhtoversioId).HasColumnName("SOPSopimuksenEhtoversioId");
            Property(x => x.SopimuksenIrtisanomisaika).HasColumnName("SOPSopimuksenIrtisanomisaika");
            Property(x => x.SopimuksenIrtisanomistoimet).HasColumnName("SOPSopimuksenIrtisanomistoimet");
            Property(x => x.SopimuksenLaatija).HasColumnName("SOPSopimuksenLaatija");
            Property(x => x.SopimuksenTilaId).HasColumnName("SOPSopimuksenTilaId");
            Property(x => x.SopimusluokkaId).HasColumnName("SOPSopimusluokkaId");
            Property(x => x.SopimustyyppiId).HasColumnName("SOPSopimustyyppiId");
            Property(x => x.TiedostoHaettu).HasColumnName("SOPTiedostoHaettu");
            Property(x => x.VastaosapuoliSiirtoOikeusId).HasColumnName("SOPVastaosapuoliSiirtoOikeusId");
            Property(x => x.VastuuyksikkoId).HasColumnName("SOPVastuuyksikkoId");
            Property(x => x.VerkonhaltijaSiirtoOikeusId).HasColumnName("SOPVerkohaltijaSiirtoOikeusId");
            Property(x => x.VerkonhaltijanAllekirjoitusPvm).HasColumnName("SOPVerkonhaltijanAllekirjoitusPvm");
            Property(x => x.YlasopimuksenTyyppiId).HasColumnName("SOPYlasopimuksenTyyppiId");
            Property(x => x.SopimusarkistosiirtoTehty).HasColumnName("SOPSopimusarkistosiirtoTehty");
            Property(x => x.Guid).HasColumnName("SOPGuid");
            Property(x => x.VuokratyyppiId).HasColumnName("SOPVuokratyyppiId");
            Property(x => x.Korkoprosentti).HasColumnName("SOPKorkoprosentti").HasPrecision(18, 6);
            Property(x => x.LahdeKorkoprosenttiId).HasColumnName("SOPLahdeKorkoprosenttiId");
            Property(x => x.FAS).HasColumnName("SOPFAS");
            Property(x => x.IFRS).HasColumnName("SOPIFRS");
            Property(x => x.LaskennallinenPaattymispvm).HasColumnName("SOPLaskennallinenPaattymispvm");

            HasRequired(x => x.Sopimustyyppi).WithMany().HasForeignKey(f => f.SopimustyyppiId);

            HasOptional(x => x.Paasopimus).WithMany().HasForeignKey(f => f.PaasopimusId);
            HasOptional(x => x.JuridinenYhtio).WithMany().HasForeignKey(f => f.JuridinenYhtioId);
            HasOptional(x => x.Julkisuusaste).WithMany().HasForeignKey(f => f.JulkisuusasteId);
            HasOptional(x => x.SopimuksenTila).WithMany().HasForeignKey(f => f.SopimuksenTilaId);
            HasOptional(x => x.DFRooli).WithMany().HasForeignKey(f => f.DFRooliId);
            HasOptional(x => x.Sopimusluokka).WithMany().HasForeignKey(f => f.SopimusluokkaId);
            HasOptional(x => x.SopimuksenAlaluokka).WithMany().HasForeignKey(f => f.SopimuksenAlaluokkaId);
            HasOptional(x => x.SopimuksenEhtoversio).WithMany().HasForeignKey(f => f.SopimuksenEhtoversioId);
            HasOptional(x => x.VerkonhaltijaSiirtoOikeus).WithMany().HasForeignKey(f => f.VerkonhaltijaSiirtoOikeusId);
            HasOptional(x => x.VastaosapuoliSiirtoOikeus).WithMany().HasForeignKey(f => f.VastaosapuoliSiirtoOikeusId);
            HasOptional(x => x.AlkuperainenYhtio).WithMany().HasForeignKey(f => f.AlkuperainenYhtioId);
            HasOptional(x => x.PuustonPoisto).WithMany().HasForeignKey(f => f.PuustonPoistoId);
            HasOptional(x => x.PuustonOmistajuus).WithMany().HasForeignKey(f => f.PuustonOmistajuusId);
            HasOptional(x => x.Kohdekategoria).WithMany().HasForeignKey(f => f.KohdekategoriaId);
            HasOptional(x => x.Kieli).WithMany().HasForeignKey(f => f.KieliId);
            HasOptional(x => x.YlasopimuksenTyyppi).WithMany().HasForeignKey(f => f.YlasopimuksenTyyppiId);
            HasOptional(x => x.Lupataho).WithMany().HasForeignKey(f => f.LupatahoId);
            HasOptional(x => x.Vuokratyyppi).WithMany().HasForeignKey(f => f.VuokratyyppiId);

        }
    }
}
