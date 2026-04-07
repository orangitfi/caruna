using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KieliCfg : EntityTypeConfiguration<Kieli>
  {
		public KieliCfg()
		{

			this.ToTable("hlp_Kieli");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KIEId");
      this.Property(x => x.Nimi).HasColumnName("KIEKieli");
			this.Property(x => x.KieliTunniste).HasColumnName("KIEKieliTunniste");
			this.Property(x => x.Luoja).HasColumnName("KIELuoja");
			this.Property(x => x.Luotu).HasColumnName("KIELuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KIEPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KIEPaivittaja");

		}
  }
}
