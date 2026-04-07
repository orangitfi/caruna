using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class RegulationCfg : EntityTypeConfiguration<Regulation>
  {
		public RegulationCfg()
		{

			this.ToTable("hlp_Regulation");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("REGId");
			this.Property(x => x.Luoja).HasColumnName("REGLuoja");
			this.Property(x => x.Luotu).HasColumnName("REGLuotu");
			this.Property(x => x.Nimi).HasColumnName("REGNimi");
			this.Property(x => x.Paivitetty).HasColumnName("REGPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("REGPaivittaja");

		}
  }
}
