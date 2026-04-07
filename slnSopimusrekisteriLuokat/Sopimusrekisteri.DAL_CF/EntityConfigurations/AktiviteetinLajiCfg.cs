using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AktiviteetinLajiCfg : EntityTypeConfiguration<AktiviteetinLaji>
  {
		public AktiviteetinLajiCfg()
		{

			this.ToTable("hlp_AktiviteetinLaji");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("ALId");
			this.Property(x => x.Laji).HasColumnName("ALLaji");
			this.Property(x => x.Luoja).HasColumnName("ALLuoja");
			this.Property(x => x.Luotu).HasColumnName("ALLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ALPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ALPaivittaja");

		}
  }
}
