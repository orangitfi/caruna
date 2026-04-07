using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksuaineistoCfg : EntityTypeConfiguration<Maksuaineisto>
  {
		public MaksuaineistoCfg()
		{

			this.ToTable("Maksuaineisto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MAIId");
			this.Property(x => x.Luoja).HasColumnName("MAILuoja");
			this.Property(x => x.Luotu).HasColumnName("MAILuotu");
			this.Property(x => x.Paivitetty).HasColumnName("MAIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MAIPaivittaja");

		}
  }
}
