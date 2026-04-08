using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class LiiketoiminnanTarveCfg : EntityTypeConfiguration<LiiketoiminnanTarve>
  {
		public LiiketoiminnanTarveCfg()
		{

			this.ToTable("hlp_LiiketoiminnanTarve");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("LTOId");
      this.Property(x => x.LiiketoiminnanTarveNimi).HasColumnName("LTOLiiketoiminnanTarve");
			this.Property(x => x.Luoja).HasColumnName("LTOLuoja");
			this.Property(x => x.Luotu).HasColumnName("LTOLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("LTOPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("LTOPaivittaja");

		}
  }
}
