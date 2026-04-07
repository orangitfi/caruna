using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class KirjanpidonAineisto
  {
		#region Propertyt

		public string record_type {get; set;}
		public int batch_id {get; private set;}
		public string application_id {get; set;}
		public string org_id {get; set;}
		public decimal check_sum {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Maksuaineisto batch_ {get; set;}

		#endregion

		#region Metodit

    //public override bool Equals(object obj)
    //{
    //  var tmp = obj as KirjanpidonAineisto;
    //  if (tmp == null) return false;
    //  return tmp.Id == Id;
    //}

    //public override int GetHashCode()
    //{
    //  return Id.GetHashCode();
    //}

    //public override string ToString()
    //{
    //  return Id.ToString();
    //}

		#endregion
  }
}
