using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class YlasopimuksenTyyppiCfg : EntityTypeConfiguration<YlasopimuksenTyyppi>
  {
		public YlasopimuksenTyyppiCfg()
		{

			this.ToTable("hlps_YlasopimuksenTyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("YSTId");
			this.Property(x => x.Luoja).HasColumnName("YSTLuoja");
			this.Property(x => x.Luotu).HasColumnName("YSTLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("YSTPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("YSTPaivittaja");
			this.Property(x => x.Nimi).HasColumnName("YSTYlasopimuksenTyyppi");

		}
  }
}
