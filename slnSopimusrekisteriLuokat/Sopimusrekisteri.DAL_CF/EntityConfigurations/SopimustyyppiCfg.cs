using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimustyyppiCfg : EntityTypeConfiguration<Sopimustyyppi>
  {
		public SopimustyyppiCfg()
		{

			this.ToTable("hlps_Sopimustyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("STYId");
			this.Property(x => x.Luoja).HasColumnName("STYLuoja");
			this.Property(x => x.Luotu).HasColumnName("STYLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("STYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("STYPaivittaja");
      this.Property(x => x.SopimustyyppiNimi).HasColumnName("STYSopimustyyppi");
      this.Property(x => x.Asiakirjatarkenne).HasColumnName("STYAsiakirjatarkenne");

		}
  }
}
