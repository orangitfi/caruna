using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class HinnastoAlakategoriaCfg : EntityTypeConfiguration<HinnastoAlakategoria>
  {
		public HinnastoAlakategoriaCfg()
		{

			this.ToTable("hlp_HinnastoAlakategoria");
			this.HasKey(x => x.Id);
      this.Property(x => x.HinnastoAlakategoriaNimi).HasColumnName("HAKHinnastoAlakategoria");
			this.Property(x => x.Id).HasColumnName("HAKId");
			this.Property(x => x.Luoja).HasColumnName("HAKLuoja");
			this.Property(x => x.Luotu).HasColumnName("HAKLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("HAKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("HAKPaivittaja");

		}
  }
}
