using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimuksenAlaluokkaCfg : EntityTypeConfiguration<SopimuksenAlaluokka>
  {
		public SopimuksenAlaluokkaCfg()
		{

			this.ToTable("hlp_SopimuksenAlaluokka");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SALId");
			this.Property(x => x.Luoja).HasColumnName("SALLuoja");
			this.Property(x => x.Luotu).HasColumnName("SALLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SALPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SALPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("SALSopimuksenAlaluokka");

		}
  }
}
