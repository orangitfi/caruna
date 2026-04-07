using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopimusrekisteri.BLL_CF;
using System.Transactions;
using KT.Utils;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
  public class IFSPaymentHandler : EntityHandlerBase<IFSPayment>
  {

    public IFSPaymentHandler(KiltaDataContext dataContext)
      : base(dataContext)
    {
    }

    public override void SaveEntity(IFSPayment entity)
    {

      base.SaveEntity(entity);

    }

    public void UpdatePayments(IEnumerable<IFSPayment> payments)
    {

      List<IFSPayment> newPayments = new List<IFSPayment>();

      foreach (IFSPayment payment in payments)
      {
        if (!this.DataContext.IFSPayments.Any(x => x.InvoiceNo == payment.InvoiceNo && x.Sequence == payment.Sequence))
          newPayments.Add(payment);
      }

      using (TransactionScope scope = new TransactionScope())
      {

        this.SaveEntityRange(newPayments);

        foreach (IFSPayment payment in newPayments)
        {

          int maksuId = DataUtils.ParseInt(payment.InvoiceNo);

          if (maksuId > 0)
          {

            Maksu maksu = this.DataContext.Maksut.SingleOrDefault(x => x.Id == maksuId);

            if (maksu != null)
            {

              maksu.IfsMaksupvm = payment.PaymentDate;
              maksu.IfsLaskunro = payment.IfsInvoiceNo;

            }

          }

        }

        this.DataContext.SaveChanges();

        scope.Complete();
      }

    }

    public override IFSPayment LoadEntity(object id)
    {
      return this.DataContext.IFSPayments.Single(x => x.Id == (int)id);
    }

    public override bool IsNewEntity(IFSPayment entity)
    {
      return entity.Id == 0;
    }

  }
}
