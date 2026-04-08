using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class AktiviteettiCfg : EntityTypeConfiguration<Aktiviteetti>
  {
		public AktiviteettiCfg()
		{

			this.ToTable("Aktiviteetti");
			this.HasKey(x => x.Id);
			this.Property(x => x.AktiviteetinLajiId).HasColumnName("AKAktiviteetinLajiId");
			this.Property(x => x.Id).HasColumnName("AKId");
			//this.Property(x => x.KontaktoijaId).HasColumnName("AKKontaktoijaId");
			this.Property(x => x.Kuvaus).HasColumnName("AKKuvaus");
			this.Property(x => x.LiitetiedostoPolku).HasColumnName("AKLiitetiedostoPolku");
			this.Property(x => x.Luoja).HasColumnName("AKLuoja");
			this.Property(x => x.Luotu).HasColumnName("AKLuotu");
			this.Property(x => x.Paivamaara).HasColumnName("AKPaivamaara");
			this.Property(x => x.Paivitetty).HasColumnName("AKPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("AKPaivittaja");
			this.Property(x => x.SeuraavaYhteyspaiva).HasColumnName("AKSeuraavaYhteyspaiva");
			this.Property(x => x.StatusId).HasColumnName("AKStatusId");
			this.Property(x => x.TahoId).HasColumnName("AKTahoId");
			this.Property(x => x.TSopimusId).HasColumnName("AKTSopimusId");
			this.Property(x => x.YhteystapaId).HasColumnName("AKYhteystapaId");

		}
  }
}
