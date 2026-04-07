using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AlvCfg : EntityTypeConfiguration<Alv>
  {
		public AlvCfg()
		{

			this.ToTable("hlp_Alv");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("ALVId");
			this.Property(x => x.Luoja).HasColumnName("ALVLuoja");
			this.Property(x => x.Luotu).HasColumnName("ALVLuotu");
			this.Property(x => x.Oletus).HasColumnName("ALVOletus");
			this.Property(x => x.Paivitetty).HasColumnName("ALVPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ALVPaivittaja");
			this.Property(x => x.Prosentti).HasColumnName("ALVProsentti");

		}
  }
}
