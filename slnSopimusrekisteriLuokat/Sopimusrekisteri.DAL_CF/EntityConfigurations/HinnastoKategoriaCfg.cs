using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class HinnastoKategoriaCfg : EntityTypeConfiguration<HinnastoKategoria>
  {
		public HinnastoKategoriaCfg()
		{

			this.ToTable("hlp_HinnastoKategoria");
			this.HasKey(x => x.Id);
      this.Property(x => x.HinnastoKategoriaNimi).HasColumnName("HKAHinnastoKategoria");
			this.Property(x => x.Id).HasColumnName("HKAId");
			this.Property(x => x.Luoja).HasColumnName("HKALuoja");
			this.Property(x => x.Luotu).HasColumnName("HKALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("HKAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("HKAPaivittaja");

		}
  }
}
