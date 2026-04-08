using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AsiakastyyppiCfg : EntityTypeConfiguration<Asiakastyyppi>
  {
		public AsiakastyyppiCfg()
		{

			this.ToTable("hlp_Asiakastyyppi");
			this.HasKey(x => x.Id);
      this.Property(x => x.Nimi).HasColumnName("ATYAsiakastyyppi");
			this.Property(x => x.Id).HasColumnName("ATYId");
			this.Property(x => x.Luoja).HasColumnName("ATYLuoja");
			this.Property(x => x.Luotu).HasColumnName("ATYLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ATYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ATYPaivittaja");

		}
  }
}
