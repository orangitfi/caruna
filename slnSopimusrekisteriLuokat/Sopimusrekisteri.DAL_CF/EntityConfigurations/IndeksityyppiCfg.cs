using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class IndeksityyppiCfg : EntityTypeConfiguration<Indeksityyppi>
  {
		public IndeksityyppiCfg()
		{

			this.ToTable("hlp_Indeksityyppi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("ITYId");
      this.Property(x => x.Nimi).HasColumnName("ITYIndeksityyppi");
			this.Property(x => x.Luoja).HasColumnName("ITYLuoja");
			this.Property(x => x.Luotu).HasColumnName("ITYLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("ITYPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("ITYPaivittaja");

		}
  }
}
