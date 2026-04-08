using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class BicKoodiCfg : EntityTypeConfiguration<BicKoodi>
  {
		public BicKoodiCfg()
		{

			this.ToTable("hlp_BicKoodi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("BKId");
			this.Property(x => x.Koodi).HasColumnName("BKKoodi");
			this.Property(x => x.Luoja).HasColumnName("BKLuoja");
			this.Property(x => x.Luotu).HasColumnName("BKLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("BKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("BKPaivittaja");
			this.Property(x => x.Pankki).HasColumnName("BKPankki");
			this.Property(x => x.RahalaitosTunnus).HasColumnName("BKRahalaitosTunnus");

		}
  }
}
