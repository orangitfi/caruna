using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class IndeksiCfg : EntityTypeConfiguration<Indeksi>
  {
		public IndeksiCfg()
		{

			this.ToTable("hlp_Indeksi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Arvo).HasColumnName("IKDArvo");
			this.Property(x => x.Id).HasColumnName("IKDId");
			this.Property(x => x.IndeksityyppiId).HasColumnName("IKDIndeksityyppiId");
			this.Property(x => x.KuukausiId).HasColumnName("IKDKuukausiId");
			this.Property(x => x.Luoja).HasColumnName("IKDLuoja");
			this.Property(x => x.Luotu).HasColumnName("IKDLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("IKDPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("IKDPaivittaja");
			this.Property(x => x.Vuosi).HasColumnName("IKDVuosi");

		}
  }
}
