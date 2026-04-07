using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AktiviteettiYhteystapaCfg : EntityTypeConfiguration<AktiviteettiYhteystapa>
  {
		public AktiviteettiYhteystapaCfg()
		{

			this.ToTable("hlp_AktiviteettiYhteystapa");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("YTAId");
			this.Property(x => x.Luoja).HasColumnName("YTALuoja");
			this.Property(x => x.Luotu).HasColumnName("YTALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("YTAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("YTAPaivittaja");
			this.Property(x => x.Yhteystapa).HasColumnName("YTAYhteystapa");

		}
  }
}
