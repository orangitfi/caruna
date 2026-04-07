using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksuStatusCfg : EntityTypeConfiguration<MaksuStatus>
  {
		public MaksuStatusCfg()
		{

			this.ToTable("hlps_MaksuStatus");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MSAId");
			this.Property(x => x.Luoja).HasColumnName("MSALuoja");
			this.Property(x => x.Luotu).HasColumnName("MSALuotu");
      this.Property(x => x.MaksuStatusNimi).HasColumnName("MSAMaksuStatus");
			this.Property(x => x.Paivitetty).HasColumnName("MSAPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MSAPaivittaja");

		}
  }
}
