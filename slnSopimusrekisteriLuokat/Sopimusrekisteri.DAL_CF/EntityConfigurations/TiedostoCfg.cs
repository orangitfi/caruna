using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
    public class TiedostoCfg : EntityTypeConfiguration<Tiedosto>
    {
        public TiedostoCfg()
        {

            this.ToTable("Tiedosto");
            this.HasKey(x => x.Id);
            this.Property(x => x.ArkistointiTunniste).HasColumnName("TIEArkistointiTunniste");
            this.Property(x => x.ArkistonSijaintiId).HasColumnName("TIEArkistonSijaintiId");
            this.Property(x => x.Asiakirjatarkenne).HasColumnName("TIEAsiakirjatarkenne");
            this.Property(x => x.DocumentID).HasColumnName("TIEDocumentID");
            this.Property(x => x.Id).HasColumnName("TIEId");
            this.Property(x => x.Info).HasColumnName("TIEInfo");
            this.Property(x => x.Luoja).HasColumnName("TIELuoja");
            this.Property(x => x.Luotu).HasColumnName("TIELuotu");
            this.Property(x => x.Paivitetty).HasColumnName("TIEPaivitetty");
            this.Property(x => x.Paivittaja).HasColumnName("TIEPaivittaja");
            this.Property(x => x.Selite).HasColumnName("TIESelite");
            this.Property(x => x.SharePointId).HasColumnName("TIESharePointId");
            this.Property(x => x.Sivuja).HasColumnName("TIESivuja");
            this.Property(x => x.SopimusFormaattiId).HasColumnName("TIESopimusFormaattiId");
            this.Property(x => x.SopimusId).HasColumnName("TIESopimusId");
            this.Property(x => x.TiedostoLahdeId).HasColumnName("TIETiedostoLahdeId");
            this.Property(x => x.TiedostoNimi).HasColumnName("TIETiedostoNimi");
            this.Property(x => x.URL).HasColumnName("TIEURL");
            this.Property(x => x.MFilesObject).HasColumnName("TIEMFilesObject");
            this.Property(x => x.MFilesId).HasColumnName("TIEMFilesId");
            this.Property(x => x.MFilesType).HasColumnName("TIEMFilesType");
            this.Property(x => x.MFilesVault).HasColumnName("TIEMFilesVault");

            this.HasRequired(x => x.Sopimus).WithMany(y => y.Tiedostot).HasForeignKey(f => f.SopimusId);

        }
    }
}
