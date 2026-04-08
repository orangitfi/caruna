using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PuustolajiCfg : EntityTypeConfiguration<Puustolaji>
  {
		public PuustolajiCfg()
		{

			this.ToTable("hlp_Puustolaji");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("PLAId");
			this.Property(x => x.Luoja).HasColumnName("PLALuoja");
			this.Property(x => x.Luotu).HasColumnName("PLALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("PLAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("PLAPaivittaja");
      this.Property(x => x.PuustolajiNimi).HasColumnName("PLAPuustolaji");

		}
  }
}
