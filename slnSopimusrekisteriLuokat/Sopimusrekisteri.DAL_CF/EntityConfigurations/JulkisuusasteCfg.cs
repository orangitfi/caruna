using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class JulkisuusasteCfg : EntityTypeConfiguration<Julkisuusaste>
  {
		public JulkisuusasteCfg()
		{

			this.ToTable("hlp_Julkisuusaste");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("JASId");
      this.Property(x => x.Nimi).HasColumnName("JASJulkisuusaste");
			this.Property(x => x.Luoja).HasColumnName("JASLuoja");
			this.Property(x => x.Luotu).HasColumnName("JASLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("JASPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("JASPaivittaja");

		}
  }
}
