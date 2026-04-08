using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksuehdotCfg : EntityTypeConfiguration<Maksuehdot>
  {
		public MaksuehdotCfg()
		{

			this.ToTable("hlp_Maksuehdot");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MEHId");
			this.Property(x => x.Luoja).HasColumnName("MEHLuoja");
			this.Property(x => x.Luotu).HasColumnName("MEHLuotu");
      this.Property(x => x.Nimi).HasColumnName("MEHMaksuehdot");
			this.Property(x => x.Paivitetty).HasColumnName("MEHPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MEHPaivittaja");

		}
  }
}
