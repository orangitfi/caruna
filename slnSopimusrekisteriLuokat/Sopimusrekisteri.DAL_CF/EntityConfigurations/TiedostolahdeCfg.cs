using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class TiedostolahdeCfg : EntityTypeConfiguration<Tiedostolahde>
  {
		public TiedostolahdeCfg()
		{

			this.ToTable("hlps_Tiedostolahde");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("TLAId");
			this.Property(x => x.Luoja).HasColumnName("TLALuoja");
			this.Property(x => x.Luotu).HasColumnName("TLALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("TLAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("TLAPaivittaja");
			this.Property(x => x.TiedostoLahde).HasColumnName("TLATiedostoLahde");

		}
  }
}
