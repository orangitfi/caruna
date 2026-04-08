using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class TunnisteyksikkoCfg : EntityTypeConfiguration<Tunnisteyksikko>
  {
		public TunnisteyksikkoCfg()
		{

			this.ToTable("Tunnisteyksikko");
			this.HasKey(x => x.Id);
			this.Property(x => x.Aktiivinen).HasColumnName("TUYAktiivinen");
			this.Property(x => x.Id).HasColumnName("TUYId");
			this.Property(x => x.Info).HasColumnName("TUYInfo");
			this.Property(x => x.Kohdetieto).HasColumnName("TUYKohdetieto");
			this.Property(x => x.Koordinaatit).HasColumnName("TUYKoordinaatit");
			this.Property(x => x.LinjaOsa).HasColumnName("TUYLinjaOsa");
			this.Property(x => x.Luoja).HasColumnName("TUYLuoja");
			this.Property(x => x.Luotu).HasColumnName("TUYLuotu");
			this.Property(x => x.Nimi).HasColumnName("TUYNimi");
			this.Property(x => x.Paivitetty).HasColumnName("TUYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("TUYPaivittaja");
			this.Property(x => x.PGKoordinaatti1).HasColumnName("TUYPGKoordinaatti1");
			this.Property(x => x.PGKoordinaatti2).HasColumnName("TUYPGKoordinaatti2");
			this.Property(x => x.PGTunniste).HasColumnName("TUYPGTunniste");
			this.Property(x => x.PGTunnus).HasColumnName("TUYPGTunnus");
			this.Property(x => x.SopimusId).HasColumnName("TUYSopimusId");
			this.Property(x => x.TunnisteyksikkoTyyppiId).HasColumnName("TUYTunnisteyksikkoTyyppiId");
			this.Property(x => x.Tunnus).HasColumnName("TUYTunnus");

      this.HasRequired(x => x.Sopimus).WithMany(y => y.Tunnisteyksikot).HasForeignKey(f => f.SopimusId);

		}
  }
}
