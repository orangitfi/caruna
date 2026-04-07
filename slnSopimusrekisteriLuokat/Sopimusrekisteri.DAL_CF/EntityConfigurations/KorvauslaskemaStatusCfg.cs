using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvauslaskemaStatusCfg : EntityTypeConfiguration<KorvauslaskelmaStatus>
  {
		public KorvauslaskemaStatusCfg()
		{

			this.ToTable("hlps_KorvauslaskemaStatus");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KSTId");
			this.Property(x => x.Nimi).HasColumnName("KSTKorvauslaskelmaStatus");

		}
  }
}
