using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorkoprosenttiCfg : EntityTypeConfiguration<Korkoprosentti>
  {
		public KorkoprosenttiCfg()
		{

			ToTable("hlp_Korkoprosentti");

			HasKey(x => x.Id);

			Property(x => x.Id).HasColumnName("KPId");
			Property(x => x.Prosentti).HasColumnName("KPProsentti").HasPrecision(18, 6);
			Property(x => x.Vuodet).HasColumnName("KPVuodet");
			Property(x => x.Luoja).HasColumnName("KPLuoja");
			Property(x => x.Luotu).HasColumnName("KPLuotu");
			Property(x => x.Paivitetty).HasColumnName("KPPaivitetty");
			Property(x => x.Paivittaja).HasColumnName("KPPaivittaja");

		}
  }
}
