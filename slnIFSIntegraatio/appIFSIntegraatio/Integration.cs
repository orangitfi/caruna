using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appIFSIntegraatio.IFS;
using Sopimusrekisteri.BLL_CF;
using Sopimusrekisteri.DAL_CF;
using Sopimusrekisteri.DAL_CF.EntityHandlers;
using appIFSIntegraatio.Utils;
using KT.Utils;
using System.IO;

namespace appIFSIntegraatio
{
  public class Integration
  {

    private KiltaDataContext _dataContext;

        public void UpdatePaymentdata()
        {
            IServiceClient client;

            if (Config.TestMode)
                client = new TestClient();
            else if (Config.FileMode)
                client = new FileClient();
            else
                client = new ServiceClient();

            string response = client.GetPaymentdata(Config.PaymentdataServiceUrl, Config.PaymentdataServiceUsername, Config.PaymentdataServicePassword);

            if (!string.IsNullOrEmpty(response))
            {

                SelectResponse paymentData = PaymentdataParser.ParseResponse(response);

                IEnumerable<IFSPayment> payments = GetPayments(paymentData);

                if (payments.Count() > 0)
                {
                    IFSPaymentHandler paymentHandler = new IFSPaymentHandler(this.DataContext);

                    paymentHandler.UpdatePayments(payments);
                }
             

            }

            if (Config.FileMode && !string.IsNullOrEmpty(response))
                FiledataArchive(Config.FiledataPath);
        }

    public IEnumerable<IFSPayment> GetPayments(SelectResponse paymentdata)
    {

      List<IFSPayment> payments = new List<IFSPayment>();
      IFSPayment payment;

      foreach (SelectResponseSelectResult selectResult in paymentdata.Items)
      {

        if (selectResult.C_CONCORDIA_PAYMENTSRECORDSELECT == null) continue;

        foreach (SelectResponseSelectResultC_CONCORDIA_PAYMENTSRECORDSELECT paymentRecord in selectResult.C_CONCORDIA_PAYMENTSRECORDSELECT)
        {

          if (this.ValidatePayment(paymentRecord))
          {

            payment = new IFSPayment();

            payment.Sequence = paymentRecord.SEQUENCE;
            payment.PaymentReference = paymentRecord.PAYMENT_REFERENCE;
            payment.PaymentDate = DateTime.Parse(paymentRecord.PAYMENT_DATE);
            payment.InvoiceNo = paymentRecord.INVOICE_NO;
            payment.IfsInvoiceNo = paymentRecord.IFS_INVOICE_NO;
            payment.Name = paymentRecord.NAME;
            payment.Amount = Data.ParseDecimal(paymentRecord.AMOUNT);
            payments.Add(payment);

          }

        }

      }

      return payments;

    }

    private bool ValidatePayment(SelectResponseSelectResultC_CONCORDIA_PAYMENTSRECORDSELECT payment)
    {

      if (!Data.IsValidDateTime(payment.PAYMENT_DATE))
      {

        Logging.LogWarning(string.Format("Maksu {0}: Epävalidi päivämäärä ({1})", payment.INVOICE_NO, payment.PAYMENT_DATE));

        return false;
      }

      if (!Data.IsValidDecimal(payment.AMOUNT))
      {

        Logging.LogWarning(string.Format("Maksu {0}: Epävalidi summa ({1})", payment.INVOICE_NO, payment.AMOUNT));

        return false;
      }

      return true;

    }

    private KiltaDataContext DataContext
    {
      get
      {
        if (this._dataContext == null)
          this._dataContext = new KiltaDataContext(Config.ConnectionString, new Kayttooikeustiedot(Config.Username));

        return this._dataContext;
      }
    }

        private bool FiledataArchive(string file)
        {
            //Kopiodaan tiedosto Arkistokansioon               
            try
            {
                string datePart = "." + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss");
                string archievedfile = file + datePart;
                File.Copy(file, archievedfile, true);
                File.Move(archievedfile, Config.FiledataArchivePath + Config.Filedata + datePart);
                File.Delete(file);
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogException(ex);
                return false;
            }
        }

    }
}
