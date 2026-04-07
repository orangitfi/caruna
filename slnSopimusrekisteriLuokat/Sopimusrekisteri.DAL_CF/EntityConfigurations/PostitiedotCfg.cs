using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PostitiedotCfg : EntityTypeConfiguration<Postitiedot>
  {
		public PostitiedotCfg()
		{

			this.ToTable("hlp_Postitiedot");
			this.HasKey(x => x.Id);
			this.Property(x => x.Kuntaid).HasColumnName("PKuntaid");
			this.Property(x => x.Luoja).HasColumnName("PLuoja");
			this.Property(x => x.Luotu).HasColumnName("PLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("PPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("PPaivittaja");
			this.Property(x => x.Id).HasColumnName("PPostiId");
			this.Property(x => x.Postinumero).HasColumnName("PPostinumero");
			this.Property(x => x.Postitoimipaikka).HasColumnName("PPostitoimipaikka");
			this.Property(x => x.PostitoimipaikkaRUO).HasColumnName("PPostitoimipaikkaRUO");

		}
  }
}
