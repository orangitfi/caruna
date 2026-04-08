using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class SopimuksenKestoCfg : EntityTypeConfiguration<SopimuksenKesto>
  {
		public SopimuksenKestoCfg()
		{

			this.ToTable("hlp_SopimuksenKesto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("SKEId");
			this.Property(x => x.Luoja).HasColumnName("SKELuoja");
			this.Property(x => x.Luotu).HasColumnName("SKELuotu");
			this.Property(x => x.Paivitetty).HasColumnName("SKEPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("SKEPaivittaja");
      this.Property(x => x.SopimuksenKestoNimi).HasColumnName("SKESopimuksenKesto");

		}
  }
}
