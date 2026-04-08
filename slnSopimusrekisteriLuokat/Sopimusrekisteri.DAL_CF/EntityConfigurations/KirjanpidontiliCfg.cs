using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KirjanpidontiliCfg : EntityTypeConfiguration<Kirjanpidontili>
  {
		public KirjanpidontiliCfg()
		{

			this.ToTable("hlp_Kirjanpidontili");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KPTId");
			this.Property(x => x.Nimi).HasColumnName("KPTKirjanpidonTili");
			this.Property(x => x.Luoja).HasColumnName("KPTLuoja");
			this.Property(x => x.Luotu).HasColumnName("KPTLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("KPTPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KPTPaivittaja");
			this.Property(x => x.Selite).HasColumnName("KPTSelite");

		}
  }
}
