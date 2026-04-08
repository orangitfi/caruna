using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimusFormaattiCfg : EntityTypeConfiguration<SopimusFormaatti>
  {
		public SopimusFormaattiCfg()
		{

			this.ToTable("hlp_SopimusFormaatti");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SFOId");
			this.Property(x => x.Luoja).HasColumnName("SFOLuoja");
			this.Property(x => x.Luotu).HasColumnName("SFOLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SFOPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SFOPaivittaja");
      this.Property(x => x.SopimusFormaattiNimi).HasColumnName("SFOSopimusFormaatti");

		}
  }
}
