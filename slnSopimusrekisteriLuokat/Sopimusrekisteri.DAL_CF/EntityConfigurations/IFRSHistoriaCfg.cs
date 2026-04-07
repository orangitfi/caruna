using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class IFRSHistoriaCfg : EntityTypeConfiguration<IFRSHistoria>
  {
		public IFRSHistoriaCfg()
		{

			this.ToTable("IFRS_Historia");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("IFRSId");
			this.Property(x => x.Pvm).HasColumnName("IFRSPvm");
			this.Property(x => x.SopimusId).HasColumnName("IFRSSopimusId");
			this.Property(x => x.SopimusAlkaa).HasColumnName("IFRSSopimusAlkaa");
			this.Property(x => x.SopimusPaattyy).HasColumnName("IFRSSopimusPaattyy");
			this.Property(x => x.SopimusJuridinenYhtioId).HasColumnName("IFRSSopimusJuridinenYhtioId");
			this.Property(x => x.SopimusJuridinenYhtioStr).HasColumnName("IFRSSopimusJuridinenYhtio");
			this.Property(x => x.SopimusVuokratyyppiId).HasColumnName("IFRSSopimusVuokratyyppiId");
			this.Property(x => x.SopimusIFRS).HasColumnName("IFRSSopimusIFRS");
			this.Property(x => x.SopimusKorkoprosentti).HasColumnName("IFRSSopimusKorkoprosentti");
			this.Property(x => x.KorvauslaskelmaId).HasColumnName("IFRSKorvauslaskelmaId");
			this.Property(x => x.KorvauslaskelmaTahoId).HasColumnName("IFRSKorvauslaskelmaTahoId");
			this.Property(x => x.KorvauslaskelmaTahoStr).HasColumnName("IFRSKorvauslaskelmaTaho");
			this.Property(x => x.KorvauslaskelmaViimeisinMaksu).HasColumnName("IFRSKorvauslaskelmaViimeisinMaksu");
			this.Property(x => x.Luoja).HasColumnName("IFRSLuoja");
			this.Property(x => x.Luotu).HasColumnName("IFRSLuotu");

		}
  }
}
