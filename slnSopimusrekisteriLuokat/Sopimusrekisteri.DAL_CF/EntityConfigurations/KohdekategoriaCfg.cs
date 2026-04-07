using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KohdekategoriaCfg : EntityTypeConfiguration<Kohdekategoria>
  {
		public KohdekategoriaCfg()
		{

			this.ToTable("hlp_Kohdekategoria");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KDKId");
			this.Property(x => x.Nimi).HasColumnName("KDKKohdeKategoria");
			this.Property(x => x.Luoja).HasColumnName("KDKLuoja");
			this.Property(x => x.Luotu).HasColumnName("KDKLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KDKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KDKPaivittaja");

		}
  }
}
