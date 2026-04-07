using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimusKiinteistoCfg : EntityTypeConfiguration<SopimusKiinteisto>
  {
    public SopimusKiinteistoCfg()
		{

			this.ToTable("Sopimus_Kiinteisto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SKId");
			this.Property(x => x.Luoja).HasColumnName("SKLuoja");
			this.Property(x => x.Luotu).HasColumnName("SKLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SKPaivittaja");
			this.Property(x => x.SopimusId).HasColumnName("SKSopimusId");
			this.Property(x => x.KiinteistoId).HasColumnName("SKKiinteistoId");

      this.HasRequired(x => x.Sopimus).WithMany(y => y.SopimusKiinteistot).HasForeignKey(f => f.SopimusId);
      this.HasRequired(x => x.Kiinteisto).WithMany().HasForeignKey(f => f.KiinteistoId);

		}
  }
}
