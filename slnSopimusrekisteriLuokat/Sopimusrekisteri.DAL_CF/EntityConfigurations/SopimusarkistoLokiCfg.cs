using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimusarkistoLokiCfg : EntityTypeConfiguration<SopimusarkistoLoki>
  {
		public SopimusarkistoLokiCfg()
		{

			this.ToTable("SopimusarkistoLoki");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SALId");
			this.Property(x => x.Luoja).HasColumnName("SALLuoja");
			this.Property(x => x.Luotu).HasColumnName("SALLuotu");
			this.Property(x => x.Operaatio).HasColumnName("SALOperaatio");
			this.Property(x => x.Tulos).HasColumnName("SALTulos");
			this.Property(x => x.Tunniste).HasColumnName("SALTunniste");
			this.Property(x => x.Tunnistetyyppi).HasColumnName("SALTunnistetyyppi");

		}
  }
}
