using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimusluokkaCfg : EntityTypeConfiguration<Sopimusluokka>
  {
		public SopimusluokkaCfg()
		{

			this.ToTable("hlps_Sopimusluokka");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SLUId");
			this.Property(x => x.Luoja).HasColumnName("SLULuoja");
			this.Property(x => x.Luotu).HasColumnName("SLULuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SLUPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SLUPaivittaja");
			this.Property(x => x.SopimusLuokka).HasColumnName("SLUSopimusLuokka");

		}
  }
}
