using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksunSuoritusCfg : EntityTypeConfiguration<MaksunSuoritus>
  {
		public MaksunSuoritusCfg()
		{

			this.ToTable("hlp_MaksunSuoritus");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MSUId");
      this.Property(x => x.Nimi).HasColumnName("MSUMaksunSuoritus");

		}
  }
}
