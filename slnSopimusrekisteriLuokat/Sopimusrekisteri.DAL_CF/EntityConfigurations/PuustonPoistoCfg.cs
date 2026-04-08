using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PuustonPoistoCfg : EntityTypeConfiguration<PuustonPoisto>
  {
		public PuustonPoistoCfg()
		{

			this.ToTable("hlp_PuustonPoisto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("PPOId");
			this.Property(x => x.Luoja).HasColumnName("PPOLuoja");
			this.Property(x => x.Luotu).HasColumnName("PPOLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("PPOPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("PPOPaivittaja");
      this.Property(x => x.Nimi).HasColumnName("PPOPuustonPoisto");
      this.Property(x => x.NimiSwe).HasColumnName("PPOPuustonPoistoSwe");

		}
  }
}
