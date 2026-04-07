using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class VuokratyyppiCfg : EntityTypeConfiguration<Vuokratyyppi>
  {
		public VuokratyyppiCfg()
		{

			ToTable("hlp_Vuokratyyppi");

			HasKey(x => x.Id);

			Property(x => x.Id).HasColumnName("VTId");
			Property(x => x.Nimi).HasColumnName("VTNimi");
			Property(x => x.Luoja).HasColumnName("VTLuoja");
			Property(x => x.Luotu).HasColumnName("VTLuotu");
			Property(x => x.Paivitetty).HasColumnName("VTPaivitetty");
			Property(x => x.Paivittaja).HasColumnName("VTPaivittaja");

		}
  }
}
