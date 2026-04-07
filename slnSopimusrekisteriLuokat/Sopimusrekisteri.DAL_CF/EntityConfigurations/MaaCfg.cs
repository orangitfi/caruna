using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaaCfg : EntityTypeConfiguration<Maa>
  {
		public MaaCfg()
		{

			this.ToTable("hlp_Maa");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MAAId");
			this.Property(x => x.Koodi).HasColumnName("MAAKoodi");
			this.Property(x => x.Luoja).HasColumnName("MAALuoja");
			this.Property(x => x.Luotu).HasColumnName("MAALuotu");
			this.Property(x => x.Nimi).HasColumnName("MAANimi");
			this.Property(x => x.NimiSuomi).HasColumnName("MAANimiSuomi");
			this.Property(x => x.Paivitetty).HasColumnName("MAAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MAAPaivittaja");

		}
  }
}
