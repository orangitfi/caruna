using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class IFSPayment : IEditable
  {
    public int Id { get; private set; }
    public string Sequence { get; set; }
    public string PaymentReference { get; set; }
    public DateTime PaymentDate { get; set; }
    public string InvoiceNo { get; set; }
    public string IfsInvoiceNo { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public string Luoja { get; set; }
    public DateTime Luotu { get; set; }
    public string Paivittaja { get; set; }
    public DateTime? Paivitetty { get; set; }

    #region Metodit

    public override bool Equals(object obj)
    {
      var tmp = obj as IFSPayment;
      if (tmp == null) return false;
      return tmp.Id == Id;
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public override string ToString()
    {
      return Id.ToString();
    }

    #endregion

  }
}
