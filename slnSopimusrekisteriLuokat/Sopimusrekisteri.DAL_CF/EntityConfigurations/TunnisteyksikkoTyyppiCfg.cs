using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class TunnisteyksikkoTyyppiCfg : EntityTypeConfiguration<TunnisteyksikkoTyyppi>
  {
		public TunnisteyksikkoTyyppiCfg()
		{

			this.ToTable("hlp_TunnisteyksikkoTyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("TTYId");
			this.Property(x => x.Luoja).HasColumnName("TTYLuoja");
			this.Property(x => x.Luotu).HasColumnName("TTYLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("TTYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("TTYPaivittaja");
			this.Property(x => x.TunnisteYksikkoTyyppi).HasColumnName("TTYTunnisteYksikkoTyyppi");

		}
  }
}
