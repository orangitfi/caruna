using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class InfopalluraCfg : EntityTypeConfiguration<Infopallura>
  {
		public InfopalluraCfg()
		{

			this.ToTable("hlp_Infopallura");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("IFPId");
			this.Property(x => x.Kentta).HasColumnName("IFPKentta");
			this.Property(x => x.Lomake).HasColumnName("IFPLomake");
			this.Property(x => x.Luoja).HasColumnName("IFPLuoja");
			this.Property(x => x.Luotu).HasColumnName("IFPLuotu");
			this.Property(x => x.Paivitetty).HasColumnName("IFPPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("IFPPaivittaja");
			this.Property(x => x.Teksti).HasColumnName("IFPTeksti");

		}
  }
}
