using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KuntaCfg : EntityTypeConfiguration<Kunta>
  {
		public KuntaCfg()
		{

			this.ToTable("hlp_Kunta");
			this.HasKey(x => x.Id);
      this.Property(x => x.KuntaNimi).HasColumnName("KKunta");
			this.Property(x => x.Id).HasColumnName("KKuntaid");
			this.Property(x => x.KuntaNro).HasColumnName("KKuntaNro");
			this.Property(x => x.KuntaSwe).HasColumnName("KKuntaSwe");
			this.Property(x => x.Luoja).HasColumnName("KLuoja");
			this.Property(x => x.Luotu).HasColumnName("KLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KPaivittaja");

		}
  }
}
