using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksuCfg : EntityTypeConfiguration<Maksu>
  {
		public MaksuCfg()
		{

			this.ToTable("Maksu");
			this.HasKey(x => x.Id);
			this.Property(x => x.AjoPvm).HasColumnName("MAKAjoPvm");
			this.Property(x => x.AlvOsuus).HasColumnName("MAKAlvOsuus");
			this.Property(x => x.Bic).HasColumnName("MAKBic");
			this.Property(x => x.EraTunniste).HasColumnName("MAKEraTunniste");
			this.Property(x => x.Id).HasColumnName("MAKId");
			this.Property(x => x.Indeksi).HasColumnName("MAKIndeksi");
			this.Property(x => x.IndeksiKuukausiId).HasColumnName("MAKIndeksiKuukausiId");
			this.Property(x => x.IndeksityyppiId).HasColumnName("MAKIndeksityyppiId");
			this.Property(x => x.IndeksiVuosi).HasColumnName("MAKIndeksiVuosi");
			this.Property(x => x.Info).HasColumnName("MAKInfo");
			this.Property(x => x.JuridinenYhtioId).HasColumnName("MAKJuridinenYhtioId");
			this.Property(x => x.KirjanpidonTiliId).HasColumnName("MAKKirjanpidonTiliId");
			this.Property(x => x.KirjanpidonTunniste).HasColumnName("MAKKirjanpidonTunniste");
			this.Property(x => x.KorvauslaskelmaId).HasColumnName("MAKKorvauslaskelmaId");
			this.Property(x => x.Kustannuspaikka).HasColumnName("MAKKustannuspaikka");
			this.Property(x => x.LaskunNumero).HasColumnName("MAKLaskunNumero");
			this.Property(x => x.Luoja).HasColumnName("MAKLuoja");
			this.Property(x => x.Luotu).HasColumnName("MAKLuotu");
			this.Property(x => x.MaksajanBicKoodi).HasColumnName("MAKMaksajanBicKoodi");
			this.Property(x => x.MaksajanNimi).HasColumnName("MAKMaksajanNimi");
			this.Property(x => x.MaksajanTilinro).HasColumnName("MAKMaksajanTilinro");
			this.Property(x => x.MaksuaineistoId).HasColumnName("MAKMaksuaineistoId");
			this.Property(x => x.MaksuIndeksi).HasColumnName("MAKMaksuIndeksi");
			this.Property(x => x.Maksupaiva).HasColumnName("MAKMaksupaiva");
			this.Property(x => x.MaksuStatusId).HasColumnName("MAKMaksuStatusId");
			this.Property(x => x.OnIndeksi).HasColumnName("MAKOnIndeksi");
			this.Property(x => x.Palvelutunnus).HasColumnName("MAKPalvelutunnus");
			this.Property(x => x.Passivoitu).HasColumnName("MAKPassivoitu");
      this.Property(x => x.SaajaNimi).HasColumnName("MAKSaaja");
			this.Property(x => x.SaajaId).HasColumnName("MAKSaajaId");
			this.Property(x => x.SopimusId).HasColumnName("MAKSopimusId");
			this.Property(x => x.Summa).HasColumnName("MAKSumma");
			this.Property(x => x.SummaIlmanAlv).HasColumnName("MAKSummaIlmanAlv");
			this.Property(x => x.Tilinumero).HasColumnName("MAKTilinumero");
			this.Property(x => x.Vero).HasColumnName("MAKVero");
			this.Property(x => x.Viesti).HasColumnName("MAKViesti");
			this.Property(x => x.Viite).HasColumnName("MAKViite");
			this.Property(x => x.Vuosi).HasColumnName("MAKVuosi");
      this.Property(x => x.Alv).HasColumnName("MAKAlv");
      this.Property(x => x.IfsMaksupvm).HasColumnName("MAKIfsMaksupvm");
      this.Property(x => x.IfsLaskunro).HasColumnName("MAKIfsLaskunro");

		}
  }
}
