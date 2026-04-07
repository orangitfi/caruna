using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SiirtoOikeusCfg : EntityTypeConfiguration<SiirtoOikeus>
  {
		public SiirtoOikeusCfg()
		{

			this.ToTable("hlp_SiirtoOikeus");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SOIId");
			this.Property(x => x.Luoja).HasColumnName("SOILuoja");
			this.Property(x => x.Luotu).HasColumnName("SOILuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SOIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SOIPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("SOISiirtoOikeus");

		}
  }
}
