using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class Local1Cfg : EntityTypeConfiguration<Local1>
  {
		public Local1Cfg()
		{

			this.ToTable("hlp_Local1");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("LOCId");
			this.Property(x => x.Luoja).HasColumnName("LOCLuoja");
			this.Property(x => x.Luotu).HasColumnName("LOCLuotu");
			this.Property(x => x.Nimi).HasColumnName("LOCNimi");
			this.Property(x => x.Paivitetty).HasColumnName("LOCPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("LOCPaivittaja");

		}
  }
}
