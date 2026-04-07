using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class MaksuTiliointiCfg : EntityTypeConfiguration<MaksuTiliointi>
  {
		public MaksuTiliointiCfg()
		{

      this.ToTable("Maksu_Tiliointi");

      this.HasKey(x => x.Id);
      this.Property(x => x.AlvOsuus).HasColumnName("MTLAlvOsuus");
      this.Property(x => x.Id).HasColumnName("MTLId");
      this.Property(x => x.InvCost).HasColumnName("MTLInvCost");
      this.Property(x => x.Kirjanpidontili).HasColumnName("MTLKirjanpidontili");
      this.Property(x => x.Kustannuspaikka).HasColumnName("MTLKustannuspaikka");
      this.Property(x => x.Local1).HasColumnName("MTLLocal1");
      this.Property(x => x.Luoja).HasColumnName("MTLLuoja");
      this.Property(x => x.Luotu).HasColumnName("MTLLuotu");
      this.Property(x => x.MaksuId).HasColumnName("MTLMaksuId");
      this.Property(x => x.Projektinro).HasColumnName("MTLProjektinro");
      this.Property(x => x.Purpose).HasColumnName("MTLPurpose");
      this.Property(x => x.Regulation).HasColumnName("MTLRegulation");
      this.Property(x => x.Summa).HasColumnName("MTLSumma");
      this.Property(x => x.SummaIlmanAlv).HasColumnName("MTLSummaIlmanAlv");
      this.Property(x => x.Category).HasColumnName("MTLCategory");

      this.HasRequired(x => x.Maksu).WithMany(y => y.Tilioinnit).HasForeignKey(f => f.MaksuId);

    }
  }
}
