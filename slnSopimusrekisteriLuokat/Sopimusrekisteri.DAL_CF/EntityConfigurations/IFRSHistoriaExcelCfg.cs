using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class IFRSHistoriaExcelCfg : EntityTypeConfiguration<IFRSHistoriaExcel>
  {
		public IFRSHistoriaExcelCfg()
		{
			this.ToTable("IFRS_Historia_Excel");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("EId");
			this.Property(x => x.Pvm).HasColumnName("EPvm");
			this.Property(x => x.Nimi).HasColumnName("ENimi");
			this.Property(x => x.Luoja).HasColumnName("ELuoja");
			this.Property(x => x.Luotu).HasColumnName("ELuotu");
			this.Property(x => x.Sisalto).HasColumnName("ESisalto");
		}
  }
}
