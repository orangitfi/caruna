using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KiinteistoCfg : EntityTypeConfiguration<Kiinteisto>
  {
		public KiinteistoCfg()
		{

			this.ToTable("Kiinteisto");
			this.HasKey(x => x.Id);
			this.Property(x => x.AlueTarkenne).HasColumnName("KIIAlueTarkenne");
			this.Property(x => x.AssetTunniste).HasColumnName("KIIAssetTunniste");
			this.Property(x => x.Id).HasColumnName("KIIId");
			this.Property(x => x.Info).HasColumnName("KIIInfo");
			this.Property(x => x.Katuosoite).HasColumnName("KIIKatuosoite");
			this.Property(x => x.Kiinnitykset).HasColumnName("KIIKiinnitykset");
			this.Property(x => x.KiinteistoNimi).HasColumnName("KIIKiinteisto");
			this.Property(x => x.Kiinteistotunnus).HasColumnName("KIIKiinteistotunnus");
			this.Property(x => x.KiinteistotunnusLyhyt).HasColumnName("KIIKiinteistotunnusLyhyt");
			this.Property(x => x.KiinteistoverotettuVuosi).HasColumnName("KIIKiinteistoverotettuVuosi");
			this.Property(x => x.Kortteli).HasColumnName("KIIKortteli");
      //this.Property(x => x.Kunta).HasColumnName("KIIKunta");
			this.Property(x => x.KuntaId).HasColumnName("KIIKuntaId");
			this.Property(x => x.Kuntanumero).HasColumnName("KIIKuntanumero");
			this.Property(x => x.Kyla).HasColumnName("KIIKyla");
			this.Property(x => x.KylaId).HasColumnName("KIIKylaId");
			this.Property(x => x.Kylanumero).HasColumnName("KIIKylanumero");
			this.Property(x => x.LiiketoiminnanTarveId).HasColumnName("KIILiiketoiminnanTarveId");
			this.Property(x => x.Luoja).HasColumnName("KIILuoja");
			this.Property(x => x.Luotu).HasColumnName("KIILuotu");
			this.Property(x => x.MaaId).HasColumnName("KIIMaaId");
			this.Property(x => x.MaapintaAla).HasColumnName("KIIMaapintaAla");
			this.Property(x => x.MaaraAla).HasColumnName("KIIMaaraAla");
			this.Property(x => x.MaaraAlaTarkenneId).HasColumnName("KIIMaaraAlaTarkenneId");
			this.Property(x => x.Omistusosuus).HasColumnName("KIIOmistusosuus");
			this.Property(x => x.OmistusosuusTotal).HasColumnName("KIIOmistusosuusTotal");
			this.Property(x => x.Paivitetty).HasColumnName("KIIPaivitetty");
			this.Property(x => x.Paivittaja).HasColumnName("KIIPaivittaja");
			this.Property(x => x.PintaAla).HasColumnName("KIIPintaAla");
			this.Property(x => x.Postinumero).HasColumnName("KIIPostinumero");
			this.Property(x => x.Postitoimipaikka).HasColumnName("KIIPostitoimipaikka");
			this.Property(x => x.Rasitteet).HasColumnName("KIIRasitteet");
			this.Property(x => x.Rekisterinumero).HasColumnName("KIIRekisterinumero");
			this.Property(x => x.SaantoId).HasColumnName("KIISaantoId");
			this.Property(x => x.TahoId).HasColumnName("KIITahoId");
			this.Property(x => x.Tontti).HasColumnName("KIITontti");
			this.Property(x => x.VesipintaAla).HasColumnName("KIIVesipintaAla");

      this.HasOptional(x => x.Taho).WithMany(y => y.Kiinteistot).HasForeignKey(f => f.TahoId);

      this.HasOptional(x => x.Maa).WithMany().HasForeignKey(f => f.MaaId);
      this.HasOptional(x => x.Kunta).WithMany().HasForeignKey(f => f.KuntaId);
      this.HasOptional(x => x.MaaraAlaTarkenne).WithMany().HasForeignKey(f => f.MaaraAlaTarkenneId);
      this.HasOptional(x => x.LiiketoiminnanTarve).WithMany().HasForeignKey(f => f.LiiketoiminnanTarveId);
      this.HasOptional(x => x.Saanto).WithMany().HasForeignKey(f => f.SaantoId);
		
		}
  }
}
