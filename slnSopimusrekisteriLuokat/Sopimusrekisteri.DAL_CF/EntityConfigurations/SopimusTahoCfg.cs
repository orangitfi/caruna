using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
    public class SopimusTahoCfg : EntityTypeConfiguration<SopimusTaho>
    {
        public SopimusTahoCfg()
        {

            this.ToTable("Sopimus_Taho");
            this.HasKey(x => x.Id);
            this.Property(x => x.AsiakastyyppiId).HasColumnName("SOTAsiakastyyppiId");
            this.Property(x => x.DFRooliId).HasColumnName("SOTDFRooliId");
            this.Property(x => x.Id).HasColumnName("SOTId");
            this.Property(x => x.Luoja).HasColumnName("SOTLuoja");
            this.Property(x => x.Luotu).HasColumnName("SOTLuotu");
            this.Property(x => x.Paivitetty).HasColumnName("SOTPaivitetty");
            this.Property(x => x.Paivittaja).HasColumnName("SOTPaivittaja");
            this.Property(x => x.SopimusId).HasColumnName("SOTSopimusId");
            this.Property(x => x.TahoId).HasColumnName("SOTTahoId");
            this.Property(x => x.TulostetaanSopimukseen).HasColumnName("SOTTulostetaanSopimukseen");

            this.HasRequired(x => x.Sopimus).WithMany(y => y.Asiakkaat).HasForeignKey(f => f.SopimusId);
            this.HasRequired(x => x.Taho).WithMany().HasForeignKey(f => f.TahoId);
            this.HasOptional(x => x.DFRooli).WithMany().HasForeignKey(f => f.DFRooliId);

        }
    }
}
