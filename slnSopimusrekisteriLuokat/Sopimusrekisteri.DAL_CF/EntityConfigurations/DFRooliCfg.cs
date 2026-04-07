using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class DFRooliCfg : EntityTypeConfiguration<DFRooli>
  {
		public DFRooliCfg()
		{

			this.ToTable("hlp_DFRooli");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("DFRId");
			this.Property(x => x.Luoja).HasColumnName("DFRLuoja");
			this.Property(x => x.Luotu).HasColumnName("DFRLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("DFRPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("DFRPaivittaja");
			this.Property(x => x.Nimi).HasColumnName("DFRRooli");

		}
  }
}
