using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AsiakirjaTarkenneCfg : EntityTypeConfiguration<AsiakirjaTarkenne>
  {
		public AsiakirjaTarkenneCfg()
		{

			this.ToTable("hlp_AsiakirjaTarkenne");
			this.HasKey(x => x.Id);
      this.Property(x => x.AsiakirjaTarkenneNimi).HasColumnName("ATAAsiakirjaTarkenne");
			this.Property(x => x.Id).HasColumnName("ATAId");
			this.Property(x => x.Luoja).HasColumnName("ATaLuoja");
			this.Property(x => x.Luotu).HasColumnName("ATALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ATAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ATAPaivittaja");

		}
  }
}
