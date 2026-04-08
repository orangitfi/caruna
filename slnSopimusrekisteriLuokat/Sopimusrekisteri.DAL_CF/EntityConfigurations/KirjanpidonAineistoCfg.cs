using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KirjanpidonAineistoCfg : EntityTypeConfiguration<KirjanpidonAineisto>
  {
		public KirjanpidonAineistoCfg()
		{

			this.ToTable("KirjanpidonAineisto");
			this.HasKey(x => x.batch_id);
			this.Property(x => x.application_id).HasColumnName("application_id");
			this.Property(x => x.batch_id).HasColumnName("batch_id");
			this.Property(x => x.check_sum).HasColumnName("check_sum");
			this.Property(x => x.org_id).HasColumnName("org_id");
			this.Property(x => x.record_type).HasColumnName("record_type");

		}
  }
}
