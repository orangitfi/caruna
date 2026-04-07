using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PurposeCfg : EntityTypeConfiguration<Purpose>
  {
		public PurposeCfg()
		{

			this.ToTable("hlp_Purpose");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("PURId");
			this.Property(x => x.Luoja).HasColumnName("PURLuoja");
			this.Property(x => x.Luotu).HasColumnName("PURLuotu");
			this.Property(x => x.Nimi).HasColumnName("PURNimi");
			this.Property(x => x.Paivitetty).HasColumnName("PURPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("PURPaivittaja");

		}
  }
}
