using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvauslaskelmaCfg : EntityTypeConfiguration<Korvauslaskelma>
  {
		public KorvauslaskelmaCfg()
		{

			this.ToTable("Korvauslaskelma");
			this.HasKey(x => x.Id);
			this.Property(x => x.AlvId).HasColumnName("KORAlvId");
			this.Property(x => x.CertDate).HasColumnName("KORCertDate");
			this.Property(x => x.Concession).HasColumnName("KORConcession");
			this.Property(x => x.EnsimmainenMaksupaivaAsetettuKasin).HasColumnName("KOREnsimmainenMaksupaivaAsetettuKasin");
			this.Property(x => x.EnsimmainenSallittuMaksuPvm).HasColumnName("KOREnsimmainenSallittuMaksuPvm");
			this.Property(x => x.FieldWorkStarted).HasColumnName("KORFieldWorkStarted");
			this.Property(x => x.Id).HasColumnName("KORId");
			this.Property(x => x.IndeksiKuukausiId).HasColumnName("KORIndeksiKuukausiId");
			this.Property(x => x.IndeksityyppiId).HasColumnName("KORIndeksityyppiId");
			this.Property(x => x.IndeksiVuosi).HasColumnName("KORIndeksiVuosi");
			this.Property(x => x.Info).HasColumnName("KORInfo");
			this.Property(x => x.InvCostId).HasColumnName("KORInvCostId");
			this.Property(x => x.KirjanpidonKustannuspaikkaId).HasColumnName("KORKirjanpidonKustannuspaikkaId");
			this.Property(x => x.KirjanpidonTiliId).HasColumnName("KORKirjanpidonTiliId");
			this.Property(x => x.KorvauksenProjektinumero).HasColumnName("KORKorvauksenProjektinumero");
			this.Property(x => x.KorvauslaskelmaStatusId).HasColumnName("KORKorvauslaskelmaStatusId");
			this.Property(x => x.KorvausProsentti).HasColumnName("KORKorvausProsentti");
			this.Property(x => x.KorvaustyyppiId).HasColumnName("KORKorvaustyyppiId");
			this.Property(x => x.LaskennallinenKorvaus).HasColumnName("KORLaskennallinenKorvaus");
			this.Property(x => x.Local1Id).HasColumnName("KORLocal1Id");
			this.Property(x => x.Luoja).HasColumnName("KORLuoja");
			this.Property(x => x.Luotu).HasColumnName("KORLuotu");
			this.Property(x => x.MaksetaanAlv).HasColumnName("KORMaksetaanAlv");
			this.Property(x => x.MaksettavaKorvaus).HasColumnName("KORMaksettavaKorvaus");
			this.Property(x => x.MaksettavaKorvausAlkuperainen).HasColumnName("KORMaksettavaKorvausAlkuperainen");
			this.Property(x => x.MaksualueId).HasColumnName("KORMaksualueId");
			this.Property(x => x.MaksuehdotId).HasColumnName("KORMaksuehdotId");
			this.Property(x => x.MaksuKuukausiId).HasColumnName("KORMaksuKuukausiId");
			this.Property(x => x.MaksunSuoritusId).HasColumnName("KORMaksunSuoritusId");
			this.Property(x => x.Name).HasColumnName("KORName");
			this.Property(x => x.NykyinenIndeksiArvo).HasColumnName("KORNykyinenIndeksiArvo");
			this.Property(x => x.OnIndeksi).HasColumnName("KOROnIndeksi");
			this.Property(x => x.Owner).HasColumnName("KOROwner");
			this.Property(x => x.Paivitetty).HasColumnName("KORPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KORPaivittaja");
			this.Property(x => x.ProjectClosedA).HasColumnName("KORProjectClosedA");
			this.Property(x => x.Projectno).HasColumnName("KORProjectno");
			this.Property(x => x.Projektinumero).HasColumnName("KORProjektinumero");
			this.Property(x => x.PurposeId).HasColumnName("KORPurposeId");
			this.Property(x => x.PuustonOmistajuusId).HasColumnName("KORPuustonOmistajuusId");
			this.Property(x => x.PuustonPoistoId).HasColumnName("KORPuustonPoistoId");
			this.Property(x => x.RegulationId).HasColumnName("KORRegulationId");
			this.Property(x => x.SopimushetkenIndeksiArvo).HasColumnName("KORSopimushetkenIndeksiArvo");
			this.Property(x => x.SopimusId).HasColumnName("KORSopimusId");
			this.Property(x => x.SaajaId).HasColumnName("KORTahoId");
			this.Property(x => x.Type).HasColumnName("KORType");
			this.Property(x => x.TypeOfProject).HasColumnName("KORTypeOfProject");
			this.Property(x => x.VanhaSopimusPaattyyiPvm).HasColumnName("KORVanhaSopimusPaattyyiPvm");
			this.Property(x => x.Viesti).HasColumnName("KORViesti");
			this.Property(x => x.ViimeinenMaksuPvm).HasColumnName("KORViimeinenMaksuPvm");
			this.Property(x => x.ViimeisinIndeksi).HasColumnName("KORViimeisinIndeksi");
			this.Property(x => x.ViimeisinIndeksiVuosi).HasColumnName("KORViimeisinIndeksiVuosi");
			this.Property(x => x.ViimeisinMaksu).HasColumnName("KORViimeisinMaksu");
			this.Property(x => x.ViimeisinMaksuIndeksi).HasColumnName("KORViimeisinMaksuIndeksi");
			this.Property(x => x.ViimeisinMaksuPvm).HasColumnName("KORViimeisinMaksuPvm");
			this.Property(x => x.Viite).HasColumnName("KORViite");
      this.Property(x => x.Category).HasColumnName("KORCategory");

      this.HasRequired(x => x.Sopimus).WithMany(x => x.Korvauslaskelmat).HasForeignKey(x => x.SopimusId);
      this.HasOptional(x => x.Saaja).WithMany().HasForeignKey(x => x.SaajaId);

		}
  }
}
