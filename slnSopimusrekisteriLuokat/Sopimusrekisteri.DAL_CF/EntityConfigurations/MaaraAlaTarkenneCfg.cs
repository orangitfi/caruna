using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaaraAlaTarkenneCfg : EntityTypeConfiguration<MaaraAlaTarkenne>
  {
		public MaaraAlaTarkenneCfg()
		{

			this.ToTable("hlp_MaaraAlaTarkenne");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MATId");
			this.Property(x => x.Luoja).HasColumnName("MATLuoja");
			this.Property(x => x.Luotu).HasColumnName("MATLuotu");
      this.Property(x => x.MaaraAlaTarkenneNimi).HasColumnName("MATMaaraAlaTarkenne");
			this.Property(x => x.Paivitetty).HasColumnName("MATPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MATPaivittaja");

		}
  }
}
