using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MetsatyyppiCfg : EntityTypeConfiguration<Metsatyyppi>
  {
		public MetsatyyppiCfg()
		{

			this.ToTable("hlp_Metsatyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MTYId");
			this.Property(x => x.Luoja).HasColumnName("MTYLuoja");
			this.Property(x => x.Luotu).HasColumnName("MTYLuotu");
      this.Property(x => x.MetsatyyppiNimi).HasColumnName("MTYMetsatyyppi");
			this.Property(x => x.Paivitetty).HasColumnName("MTYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MTYPaivittaja");

		}
  }
}
