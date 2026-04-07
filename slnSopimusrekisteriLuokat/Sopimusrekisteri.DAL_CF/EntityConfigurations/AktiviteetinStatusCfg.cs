using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AktiviteetinStatusCfg : EntityTypeConfiguration<AktiviteetinStatus>
  {
		public AktiviteetinStatusCfg()
		{

			this.ToTable("hlp_AktiviteetinStatus");
			this.HasKey(x => x.Id);
      this.Property(x => x.AktiviteetinStatusNimi).HasColumnName("ASAktiviteetinStatus");
			this.Property(x => x.Id).HasColumnName("ASId");
			this.Property(x => x.Luoja).HasColumnName("ASLuoja");
			this.Property(x => x.Luotu).HasColumnName("ASLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ASPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ASPaivittaja");

		}
  }
}
