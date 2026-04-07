using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KirjanpidonKustannuspaikkaCfg : EntityTypeConfiguration<KirjanpidonKustannuspaikka>
  {
		public KirjanpidonKustannuspaikkaCfg()
		{

			this.ToTable("hlp_KirjanpidonKustannuspaikka");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KPKId");
      this.Property(x => x.Nimi).HasColumnName("KPKKirjanpidonKustannuspaikka");
			this.Property(x => x.Luoja).HasColumnName("KPKLuoja");
			this.Property(x => x.Luotu).HasColumnName("KPKLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KPKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KPKPaivittaja");
			this.Property(x => x.Selite).HasColumnName("KPKSelite");

		}
  }
}
