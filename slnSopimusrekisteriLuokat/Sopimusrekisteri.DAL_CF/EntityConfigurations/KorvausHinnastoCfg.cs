using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvausHinnastoCfg : EntityTypeConfiguration<KorvausHinnasto>
  {
		public KorvausHinnastoCfg()
		{

			this.ToTable("KorvausHinnasto");
			this.HasKey(x => x.Id);
			this.Property(x => x.Aktiivinen).HasColumnName("KHIAktiivinen");
			this.Property(x => x.AlkuPvm).HasColumnName("KHIAlkuPvm");
			this.Property(x => x.ArvonPeruste).HasColumnName("KHIArvonPeruste");
			this.Property(x => x.HinnastoAlakategoriaId).HasColumnName("KHIHinnastoAlakategoriaId");
			this.Property(x => x.HinnastoKategoriaId).HasColumnName("KHIHinnastoKategoriaId");
			this.Property(x => x.Id).HasColumnName("KHIId");
			this.Property(x => x.Info).HasColumnName("KHIInfo");
			this.Property(x => x.Korvauslaji).HasColumnName("KHIKorvauslaji");
			this.Property(x => x.Kuvaus).HasColumnName("KHIKuvaus");
			this.Property(x => x.LoppuPvm).HasColumnName("KHILoppuPvm");
			this.Property(x => x.Luoja).HasColumnName("KHILuoja");
			this.Property(x => x.Luotu).HasColumnName("KHILuotu");
			this.Property(x => x.MaksuAlueId).HasColumnName("KHIMaksuAlueId");
			this.Property(x => x.MetsatyyppiId).HasColumnName("KHIMetsatyyppiId");
			this.Property(x => x.Paivitetty).HasColumnName("KHIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KHIPaivittaja");
			this.Property(x => x.PuustolajiId).HasColumnName("KHIPuustolajiId");
			this.Property(x => x.PuustonIka).HasColumnName("KHIPuustonIka");
			this.Property(x => x.SopimustyyppiId).HasColumnName("KHISopimustyyppiId");
			this.Property(x => x.TaimistonValtapituus).HasColumnName("KHITaimistonValtapituus");
			this.Property(x => x.Tiheyskerroin).HasColumnName("KHITiheyskerroin");
			this.Property(x => x.Yksikkkohinta).HasColumnName("KHIYksikkkohinta");
			this.Property(x => x.YksikkohinnanTarkenne).HasColumnName("KHIYksikkohinnanTarkenne");
			this.Property(x => x.YksikkoId).HasColumnName("KHIYksikkoId");

      HasRequired(x => x.Sopimustyyppi).WithMany().HasForeignKey(f => f.SopimustyyppiId);

		}
  }
}
