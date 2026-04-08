using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvausyksikonTyyppiCfg : EntityTypeConfiguration<KorvausyksikonTyyppi>
  {
		public KorvausyksikonTyyppiCfg()
		{

			this.ToTable("hlps_KorvausyksikonTyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KYTId");
      this.Property(x => x.KorvausyksikonTyyppiNimi).HasColumnName("KYTKorvausyksikonTyyppi");
			this.Property(x => x.Luoja).HasColumnName("KYTLuoja");
			this.Property(x => x.Luotu).HasColumnName("KYTLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KYTPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KYTPaivittaja");

		}
  }
}
