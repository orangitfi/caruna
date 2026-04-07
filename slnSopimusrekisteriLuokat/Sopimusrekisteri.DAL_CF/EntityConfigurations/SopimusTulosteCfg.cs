using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimusTulosteCfg : EntityTypeConfiguration<SopimusTuloste>
  {
		public SopimusTulosteCfg()
		{

			this.ToTable("Sopimus_Tuloste");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("STLId");
			this.Property(x => x.Luoja).HasColumnName("STLLuoja");
			this.Property(x => x.Luotu).HasColumnName("STLLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("STLPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("STLPaivittaja");
			this.Property(x => x.SopimusId).HasColumnName("STLSopimusId");
      this.Property(x => x.Tuloste).HasColumnName("STLTuloste");

		}
  }
}
