using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class ArkistonSijaintiCfg : EntityTypeConfiguration<ArkistonSijainti>
  {
		public ArkistonSijaintiCfg()
		{

			this.ToTable("hlp_ArkistonSijainti");
			this.HasKey(x => x.Id);
      this.Property(x => x.ArkistonSijaintiNimi).HasColumnName("ASIArkistonSijainti");
			this.Property(x => x.Id).HasColumnName("ASIId");
			this.Property(x => x.Luoja).HasColumnName("ASILuoja");
			this.Property(x => x.Luotu).HasColumnName("ASILuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ASIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ASIPaivittaja");

		}
  }
}
