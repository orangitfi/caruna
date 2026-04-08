using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class TahoCfg : EntityTypeConfiguration<Taho>
  {
		public TahoCfg()
		{

			this.ToTable("Taho");
			this.HasKey(x => x.Id);
			this.Property(x => x.Aktiivi).HasColumnName("TAHAktiivi");
			this.Property(x => x.AlvVelvollinen).HasColumnName("TAHAlvVelvollinen");
			this.Property(x => x.BicKoodiMuu).HasColumnName("TAHBic");
			this.Property(x => x.BicKoodiId).HasColumnName("TAHBicKoodiId");
			this.Property(x => x.Concession).HasColumnName("TAHConcession");
			this.Property(x => x.EdellinenSukunimi).HasColumnName("TAHEdellinenSukunimi");
			this.Property(x => x.Email).HasColumnName("TAHEmail");
			this.Property(x => x.Etunimi).HasColumnName("TAHEtunimi");
			this.Property(x => x.Info).HasColumnName("TAHInfo");
			this.Property(x => x.KirjanpidonProjektitunniste).HasColumnName("TAHKirjanpidonProjektitunniste");
			this.Property(x => x.KirjanpidonYritystunniste).HasColumnName("TAHKirjanpidonYritystunniste");
			this.Property(x => x.KuntaId).HasColumnName("TAHKuntaId");
			this.Property(x => x.Lisaosoite).HasColumnName("TAHLisaosoite");
			this.Property(x => x.Luoja).HasColumnName("TAHLuoja");
			this.Property(x => x.Luotu).HasColumnName("TAHLuotu");
			this.Property(x => x.MaaId).HasColumnName("TAHMaaId");
			this.Property(x => x.Nimitarkenne).HasColumnName("TAHNimitarkenne");
			this.Property(x => x.OrganisaationTyyppiId).HasColumnName("TAHOrganisaationTyyppiId");
			this.Property(x => x.Paivitetty).HasColumnName("TAHPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("TAHPaivittaja");
			this.Property(x => x.PassivoinninsyyId).HasColumnName("TAHPassivoinninsyyId");
			this.Property(x => x.Passivointipvm).HasColumnName("TAHPassivointipvm");
			this.Property(x => x.Postitusosoite).HasColumnName("TAHPostitusosoite");
			this.Property(x => x.Postituspostinro).HasColumnName("TAHPostituspostinro");
			this.Property(x => x.Postituspostitmp).HasColumnName("TAHPostituspostitmp");
			this.Property(x => x.Puhelin).HasColumnName("TAHPuhelin");
			this.Property(x => x.Sukunimi).HasColumnName("TAHSukunimi");
			this.Property(x => x.Id).HasColumnName("TAHTahoId");
			this.Property(x => x.Tilinumero).HasColumnName("TAHTilinumero");
			this.Property(x => x.TyyppiId).HasColumnName("TAHTyyppiId");
			this.Property(x => x.Ytunnus).HasColumnName("TAHYtunnus");

      this.HasRequired(x => x.Tyyppi).WithMany().HasForeignKey(f => f.TyyppiId);
      this.HasOptional(x => x.OrganisaationTyyppi).WithMany().HasForeignKey(f => f.OrganisaationTyyppiId);
      this.HasOptional(x => x.Maa).WithMany().HasForeignKey(f => f.MaaId);
      this.HasOptional(x => x.Passivoinninsyy).WithMany().HasForeignKey(f => f.PassivoinninsyyId);
      this.HasOptional(x => x.Kunta).WithMany().HasForeignKey(f => f.KuntaId);
      this.HasOptional(x => x.BicKoodi).WithMany().HasForeignKey(f => f.BicKoodiId);

		}
  }
}
