using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class PcsSummaryRaporttiCfg : EntityTypeConfiguration<PcsSummaryRaportti>
  {

    public PcsSummaryRaporttiCfg()
    {

      this.ToTable("PcsSummaryRaportti");
      this.HasKey(x => x.Id);
      this.Property(x => x.Id).HasColumnName("PSRId");
      this.Property(x => x.ProjectNo).HasColumnName("PSRProjectno");
      this.Property(x => x.Name).HasColumnName("PSRName");
      this.Property(x => x.TypeOfProject).HasColumnName("PSRTypeOfProject");
      this.Property(x => x.Type).HasColumnName("PSRType");
      this.Property(x => x.Category).HasColumnName("PSRCategory");
      this.Property(x => x.Owner).HasColumnName("PSROwner");
      this.Property(x => x.Concession).HasColumnName("PSRConcession");
      this.Property(x => x.CertDate).HasColumnName("PSRCertDate");
      this.Property(x => x.FieldWorkStartedA).HasColumnName("PSRFieldWorkStartedA");
      this.Property(x => x.ProjectClosedA).HasColumnName("PSRProjectClosedA");
      this.Property(x => x.Era).HasColumnName("PSREra");
      this.Property(x => x.Luoja).HasColumnName("PSRLuoja");
      this.Property(x => x.Luotu).HasColumnName("PSRLuotu");

    }

  }
}
