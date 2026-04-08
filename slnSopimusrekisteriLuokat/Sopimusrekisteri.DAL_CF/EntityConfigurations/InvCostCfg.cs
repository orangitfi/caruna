using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class InvCostCfg : EntityTypeConfiguration<InvCost>
  {
		public InvCostCfg()
		{

			this.ToTable("hlp_InvCost");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("ICOId");
			this.Property(x => x.Luoja).HasColumnName("ICOLuoja");
			this.Property(x => x.Luotu).HasColumnName("ICOLuotu");
			this.Property(x => x.Nimi).HasColumnName("ICONimi");
			this.Property(x => x.Paivitetty).HasColumnName("ICOPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ICOPaivittaja");

		}
  }
}
