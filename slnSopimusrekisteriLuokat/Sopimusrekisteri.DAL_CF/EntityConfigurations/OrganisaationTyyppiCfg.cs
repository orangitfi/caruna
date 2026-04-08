using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class OrganisaationTyyppiCfg : EntityTypeConfiguration<OrganisaationTyyppi>
  {
		public OrganisaationTyyppiCfg()
		{

			this.ToTable("hlps_OrganisaationTyyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("ORTId");
			this.Property(x => x.Luoja).HasColumnName("ORTLuoja");
			this.Property(x => x.Luotu).HasColumnName("ORTLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ORTPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ORTPaivittaja");
			this.Property(x => x.Tyyppi).HasColumnName("ORTTyyppi");

		}
  }
}
