using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PuustonOmistajuusCfg : EntityTypeConfiguration<PuustonOmistajuus>
  {
		public PuustonOmistajuusCfg()
		{

			this.ToTable("hlp_PuustonOmistajuus");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("POMId");
			this.Property(x => x.Luoja).HasColumnName("POMLuoja");
			this.Property(x => x.Luotu).HasColumnName("POMLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("POMPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("POMPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("POMPuustonOmistajuus");
      this.Property(x => x.NimiSwe).HasColumnName("POMPuustonOmistajuusSwe");

		}
  }
}
