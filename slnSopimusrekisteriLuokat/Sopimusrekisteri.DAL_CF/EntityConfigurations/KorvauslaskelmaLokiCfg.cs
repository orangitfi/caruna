using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KorvauslaskelmaLokiCfg : EntityTypeConfiguration<KorvauslaskelmaLoki>
  {
    public KorvauslaskelmaLokiCfg()
    {

      this.ToTable("KorvauslaskelmaLoki");
      this.HasKey(x => x.Id);

      this.Property(x => x.Id).HasColumnName("KLLId");
      this.Property(x => x.KorvauslaskelmaId).HasColumnName("KLLKorvauslaskelmaId");
      this.Property(x => x.StatusId).HasColumnName("KLLStatusId");
      this.Property(x => x.Luotu).HasColumnName("KLLLuotu");
      this.Property(x => x.Luoja).HasColumnName("KLLLuoja");

      this.Ignore(x => x.Paivittaja);
      this.Ignore(x => x.Paivitetty);

      this.HasRequired(x => x.Korvauslaskelma).WithMany(x => x.Historia).HasForeignKey(x => x.KorvauslaskelmaId);
      this.HasOptional(x => x.Status).WithMany().HasForeignKey(x => x.StatusId);

    }
  }
}