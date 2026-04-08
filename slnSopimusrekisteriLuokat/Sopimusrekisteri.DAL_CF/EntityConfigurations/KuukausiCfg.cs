using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KuukausiCfg : EntityTypeConfiguration<Kuukausi>
  {
		public KuukausiCfg()
		{

			this.ToTable("hlps_Kuukausi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KUUId");
      this.Property(x => x.Nimi).HasColumnName("KUUKuukausi");
			this.Property(x => x.Luoja).HasColumnName("KUULuoja");
			this.Property(x => x.Luotu).HasColumnName("KUULuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KUUPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KUUPaivittaja");

		}
  }
}
