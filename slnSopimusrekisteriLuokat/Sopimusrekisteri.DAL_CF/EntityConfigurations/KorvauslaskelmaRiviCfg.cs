using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvauslaskelmaRiviCfg : EntityTypeConfiguration<KorvauslaskelmaRivi>
  {
		public KorvauslaskelmaRiviCfg()
		{

			this.ToTable("KorvauslaskelmaRivi");
			this.HasKey(x => x.Id);
			this.Property(x => x.Id).HasColumnName("KLRId");
			this.Property(x => x.Info).HasColumnName("KLRInfo");
			this.Property(x => x.InvCostId).HasColumnName("KLRInvCostId");
			this.Property(x => x.KirjanpidonKustannuspaikkaId).HasColumnName("KLRKirjanpidonKustannuspaikkaId");
			this.Property(x => x.KirjanpidonTiliId).HasColumnName("KLRKirjanpidonTiliId");
			this.Property(x => x.KokonaispintaAla).HasColumnName("KLRKokonaispintaAla");
			this.Property(x => x.KokonaispintaAlaYksikkoId).HasColumnName("KLRKokonaispintaAlaYksikkoId");
			this.Property(x => x.Korvaus).HasColumnName("KLRKorvaus");
			this.Property(x => x.KorvaushinnastoId).HasColumnName("KLRKorvaushinnastoId");
			this.Property(x => x.KorvauslaskelmaId).HasColumnName("KLRKorvauslaskelmaId");
			this.Property(x => x.KorvausProsentti).HasColumnName("KLRKorvausProsentti");
			this.Property(x => x.KuvionKorvattavaLeveys).HasColumnName("KLRKuvionKorvattavaLeveys");
			this.Property(x => x.KuvionLeveys).HasColumnName("KLRKuvionLeveys");
			this.Property(x => x.KuvionPituus).HasColumnName("KLRKuvionPituus");
			this.Property(x => x.KuvionTunnus).HasColumnName("KLRKuvionTunnus");
			this.Property(x => x.Local1Id).HasColumnName("KLRLocal1Id");
			this.Property(x => x.Luoja).HasColumnName("KLRLuoja");
			this.Property(x => x.Luotu).HasColumnName("KLRLuotu");
			this.Property(x => x.Maara).HasColumnName("KLRMaara");
			this.Property(x => x.Paivitetty).HasColumnName("KLRPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KLRPaivittaja");
			this.Property(x => x.PurposeId).HasColumnName("KLRPurposeId");
			this.Property(x => x.RegulationId).HasColumnName("KLRRegulationId");
			this.Property(x => x.VanhaSopimusPaattyiPvm).HasColumnName("KLRVanhaSopimusPaattyiPvm");
			this.Property(x => x.Yksikkohinta).HasColumnName("KLRYksikkohinta");

      this.HasRequired(x => x.Korvauslaskelma).WithMany(y => y.Rivit).HasForeignKey(f => f.KorvauslaskelmaId);

		}
  }
}
