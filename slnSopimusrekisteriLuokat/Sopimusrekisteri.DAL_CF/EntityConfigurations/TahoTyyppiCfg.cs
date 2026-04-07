using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class TahoTyyppiCfg : EntityTypeConfiguration<TahoTyyppi>
  {
		public TahoTyyppiCfg()
		{

			this.ToTable("hlps_TahoTyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("TATId");
			this.Property(x => x.Luoja).HasColumnName("TATLuoja");
			this.Property(x => x.Luotu).HasColumnName("TATLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("TATPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("TATPaivittaja");
			this.Property(x => x.TahoTyyppiNimi).HasColumnName("TATTahoTyyppi");

		}
  }
}
