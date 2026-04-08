using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvaustyyppiCfg : EntityTypeConfiguration<Korvaustyyppi>
  {
		public KorvaustyyppiCfg()
		{

			this.ToTable("hlps_Korvaustyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KTYId");
      this.Property(x => x.Nimi).HasColumnName("KTYKorvaustyyppi");

		}
  }
}
