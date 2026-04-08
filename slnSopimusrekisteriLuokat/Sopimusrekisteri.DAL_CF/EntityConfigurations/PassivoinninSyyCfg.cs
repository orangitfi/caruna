using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PassivoinninSyyCfg : EntityTypeConfiguration<PassivoinninSyy>
  {
		public PassivoinninSyyCfg()
		{

			this.ToTable("hlp_PassivoinninSyy");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("PASId");
			this.Property(x => x.Luoja).HasColumnName("PASLuoja");
			this.Property(x => x.Luotu).HasColumnName("PASLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("PASPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("PASPaivittaja");
      this.Property(x => x.PassivoinninSyyNimi).HasColumnName("PASPassivoinninSyy");

		}
  }
}
