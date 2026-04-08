using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class KirjanpidonAineistoRiviCfg : EntityTypeConfiguration<KirjanpidonAineistoRivi>
  {
		public KirjanpidonAineistoRiviCfg()
		{

			this.ToTable("KirjanpidonAineistoRivi");
			this.HasKey(x => x.batch_id);
			this.Property(x => x.abc).HasColumnName("abc");
			this.Property(x => x.account).HasColumnName("account");
			this.Property(x => x.@as).HasColumnName("as");
			this.Property(x => x.batch_id).HasColumnName("batch_id");
			this.Property(x => x.company).HasColumnName("company");
			this.Property(x => x.contract).HasColumnName("contract");
			this.Property(x => x.conversion_date).HasColumnName("conversion_date");
			this.Property(x => x.conversion_type).HasColumnName("conversion_type");
			this.Property(x => x.country).HasColumnName("country");
			this.Property(x => x.credit_sum).HasColumnName("credit_sum");
			this.Property(x => x.currency_code).HasColumnName("currency_code");
			this.Property(x => x.currency_rate).HasColumnName("currency_rate");
			this.Property(x => x.customer).HasColumnName("customer");
			this.Property(x => x.debet_sum).HasColumnName("debet_sum");
			this.Property(x => x.description).HasColumnName("description");
			this.Property(x => x.document_category).HasColumnName("document_category");
			this.Property(x => x.document_number).HasColumnName("document_number");
			this.Property(x => x.flex_build_flag).HasColumnName("flex_build_flag");
			this.Property(x => x.gl_date).HasColumnName("gl_date");
			this.Property(x => x.gldata_attribute1).HasColumnName("gldata_attribute1");
			this.Property(x => x.gldata_attribute10).HasColumnName("gldata_attribute10");
			this.Property(x => x.gldata_attribute2).HasColumnName("gldata_attribute2");
			this.Property(x => x.gldata_attribute3).HasColumnName("gldata_attribute3");
			this.Property(x => x.gldata_attribute4).HasColumnName("gldata_attribute4");
			this.Property(x => x.gldata_attribute5).HasColumnName("gldata_attribute5");
			this.Property(x => x.gldata_attribute6).HasColumnName("gldata_attribute6");
			this.Property(x => x.gldata_attribute7).HasColumnName("gldata_attribute7");
			this.Property(x => x.gldata_attribute8).HasColumnName("gldata_attribute8");
			this.Property(x => x.gldata_attribute9).HasColumnName("gldata_attribute9");
			this.Property(x => x.invcost).HasColumnName("invcost");
			this.Property(x => x.local1).HasColumnName("local1");
			this.Property(x => x.local2).HasColumnName("local2");
			this.Property(x => x.org_id).HasColumnName("org_id");
			this.Property(x => x.partner).HasColumnName("partner");
			this.Property(x => x.product).HasColumnName("product");
			this.Property(x => x.project).HasColumnName("project");
			this.Property(x => x.purpose).HasColumnName("purpose");
			this.Property(x => x.record_type).HasColumnName("record_type");
			this.Property(x => x.response).HasColumnName("response");
			this.Property(x => x.source).HasColumnName("source");
			this.Property(x => x.stat_amount).HasColumnName("stat_amount");
			this.Property(x => x.tax_code).HasColumnName("tax_code");
			this.Property(x => x.taxper).HasColumnName("taxper");

		}
  }
}
