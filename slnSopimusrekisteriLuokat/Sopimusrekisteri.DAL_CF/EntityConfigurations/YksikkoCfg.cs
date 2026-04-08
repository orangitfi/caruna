using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class YksikkoCfg : EntityTypeConfiguration<Yksikko>
  {
		public YksikkoCfg()
		{

			this.ToTable("hlp_Yksikko");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("YKSId");
			this.Property(x => x.Kerroin).HasColumnName("YKSKerroin");
			this.Property(x => x.Korvausyksikko).HasColumnName("YKSKorvausyksikko");
			this.Property(x => x.KorvausyksikonTyyppiId).HasColumnName("YKSKorvausyksikonTyyppiId");
			this.Property(x => x.Luoja).HasColumnName("YKSLuoja");
			this.Property(x => x.Luotu).HasColumnName("YKSLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("YKSPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("YKSPaivittaja");

		}
  }
}
