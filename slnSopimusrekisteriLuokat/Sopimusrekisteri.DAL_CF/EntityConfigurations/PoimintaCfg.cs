using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PoimintaCfg : EntityTypeConfiguration<Poiminta>
  {
		public PoimintaCfg()
		{

			this.ToTable("Poiminta");
			this.HasKey(x => x.Poimintaid);
      this.Property(x => x.EntityId).HasColumnName("POEntityId");
			this.Property(x => x.Luotu).HasColumnName("POLuotu");
			this.Property(x => x.Poimintaid).HasColumnName("POPoimintaid");
			//this.Property(x => x.Rnd).HasColumnName("PORnd");
			this.Property(x => x.Session).HasColumnName("POSession");
      //this.Property(x => x.Tyyppi).HasColumnName("POTyyppi");

      this.Ignore(x => x.Tyyppi);
      //this.Ignore(x => x.EntityId);

		}
  }

  public class SopimusPoimintaCfg : EntityTypeConfiguration<SopimusPoiminta>
  {

    public SopimusPoimintaCfg()
    {

      Map(x => x.Requires("POTyyppi").HasValue("Sopimus"));

      this.Property(x => x.SopimusId).HasColumnName("POEntityId");

      //this.HasRequired(x => x.Sopimus).WithMany().HasForeignKey(f => f.SopimusId);

    }

  }

}
