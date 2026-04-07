using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class LupatahoCfg : EntityTypeConfiguration<Lupataho>
  {
		public LupatahoCfg()
		{

			this.ToTable("hlp_Lupataho");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("LPTId");
			this.Property(x => x.Luoja).HasColumnName("LPTLuoja");
			this.Property(x => x.Luotu).HasColumnName("LPTLuotu");
      this.Property(x => x.Nimi).HasColumnName("LPTLupataho");
			this.Property(x => x.Paivitetty).HasColumnName("LPTPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("LPTPaivittaja");

		}
  }
}
