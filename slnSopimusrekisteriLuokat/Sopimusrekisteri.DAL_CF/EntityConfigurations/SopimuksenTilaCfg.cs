using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimuksenTilaCfg : EntityTypeConfiguration<SopimuksenTila>
  {
		public SopimuksenTilaCfg()
		{

			this.ToTable("hlps_SopimuksenTila");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("STIId");
			this.Property(x => x.Luoja).HasColumnName("STILuoja");
			this.Property(x => x.Luotu).HasColumnName("STILuotu");
			this.Property(x => x.Paivitetty).HasColumnName("STIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("STIPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("STISopimuksenTila");

		}
  }
}
