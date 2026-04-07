using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksualueCfg : EntityTypeConfiguration<Maksualue>
  {
		public MaksualueCfg()
		{

			this.ToTable("hlp_Maksualue");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("MALId");
			this.Property(x => x.Luoja).HasColumnName("MALLuoja");
			this.Property(x => x.Luotu).HasColumnName("MALLuotu");
      this.Property(x => x.MaksualueNimi).HasColumnName("MALMaksualue");
			this.Property(x => x.Paivitetty).HasColumnName("MALPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("MALPaivittaja");

		}
  }
}
