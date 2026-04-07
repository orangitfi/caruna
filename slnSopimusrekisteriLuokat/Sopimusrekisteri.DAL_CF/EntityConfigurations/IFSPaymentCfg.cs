using System.Data.Entity.ModelConfiguration;
using Sopimusrekisteri.BLL_CF;

namespace Sopimusrekisteri.DAL_CF.EntityConfigurations
{
  public class IFSPaymentCfg : EntityTypeConfiguration<IFSPayment>
  {

    public IFSPaymentCfg()
    {

      this.ToTable("IFSPayment");

      this.HasKey(x => x.Id);
      this.Property(x => x.Amount).HasColumnName("IPAmount");
      this.Property(x => x.Id).HasColumnName("IPId");
      this.Property(x => x.IfsInvoiceNo).HasColumnName("IPIfsInvoiceNo");
      this.Property(x => x.InvoiceNo).HasColumnName("IPInvoiceNo");
      this.Property(x => x.Luoja).HasColumnName("IPLuoja");
      this.Property(x => x.Luotu).HasColumnName("IPLuotu");
      this.Property(x => x.Name).HasColumnName("IPName");
      this.Property(x => x.Paivitetty).HasColumnName("IPPaivitetty");
      this.Property(x => x.Paivittaja).HasColumnName("IPPaivittaja");
      this.Property(x => x.PaymentDate).HasColumnName("IPPaymentDate");
      this.Property(x => x.PaymentReference).HasColumnName("IPPaymentReference");
      this.Property(x => x.Sequence).HasColumnName("IPSequence");

    }

  }
}
