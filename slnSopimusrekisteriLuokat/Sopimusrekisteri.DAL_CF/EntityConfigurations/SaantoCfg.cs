using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SaantoCfg : EntityTypeConfiguration<Saanto>
  {
		public SaantoCfg()
		{

			this.ToTable("hlp_Saanto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SAAId");
			this.Property(x => x.Luoja).HasColumnName("SAALuoja");
			this.Property(x => x.Luotu).HasColumnName("SAALuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SAAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SAAPaivittaja");
      this.Property(x => x.SaantoNimi).HasColumnName("SAASaanto");

		}
  }
}
