using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KylaCfg : EntityTypeConfiguration<Kyla>
  {
		public KylaCfg()
		{

			this.ToTable("hlp_Kyla");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KYLId");
      this.Property(x => x.KylaNimi).HasColumnName("KYLKyla");
			this.Property(x => x.Luoja).HasColumnName("KYLLuoja");
			this.Property(x => x.Luotu).HasColumnName("KYLLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KYLPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KYLPaivittaja");

		}
  }
}
