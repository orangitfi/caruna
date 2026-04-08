using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimuksenEhtoversioCfg : EntityTypeConfiguration<SopimuksenEhtoversio>
  {
		public SopimuksenEhtoversioCfg()
		{

			this.ToTable("hlp_SopimuksenEhtoversio");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SEHId");
			this.Property(x => x.Luoja).HasColumnName("SEHLuoja");
			this.Property(x => x.Luotu).HasColumnName("SEHLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SEHPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SEHPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("SEHSopimuksenEhtoversio");

		}
  }
}
