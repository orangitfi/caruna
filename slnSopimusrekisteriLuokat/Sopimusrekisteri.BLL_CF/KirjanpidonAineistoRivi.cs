using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class KirjanpidonAineistoRivi
  {
		#region Propertyt

		public string record_type {get; set;}
		public int batch_id {get; private set;}
		public string org_id {get; set;}
		public string source {get; set;}
		public decimal document_number {get; set;}
		public string document_category {get; set;}
		public DateTime gl_date {get; set;}
		public string company {get; set;}
		public string response {get; set;}
		public string account {get; set;}
		public string project {get; set;}
		public string invcost {get; set;}
		public string partner {get; set;}
		public string product {get; set;}
		public string customer {get; set;}
		public string country {get; set;}
		public string contract {get; set;}
		public string purpose {get; set;}
		public string @as {get; set;}
		public string taxper {get; set;}
		public string abc {get; set;}
		public string local1 {get; set;}
		public string local2 {get; set;}
		public string currency_code {get; set;}
		public string conversion_type {get; set;}
		public decimal currency_rate {get; set;}
		public DateTime conversion_date {get; set;}
		public decimal debet_sum {get; set;}
		public decimal credit_sum {get; set;}
		public decimal stat_amount {get; set;}
		public string description {get; set;}
		public string gldata_attribute1 {get; set;}
		public string gldata_attribute2 {get; set;}
		public string gldata_attribute3 {get; set;}
		public string gldata_attribute4 {get; set;}
		public string gldata_attribute5 {get; set;}
		public string gldata_attribute6 {get; set;}
		public string gldata_attribute7 {get; set;}
		public string gldata_attribute8 {get; set;}
		public string gldata_attribute9 {get; set;}
		public string gldata_attribute10 {get; set;}
		public string flex_build_flag {get; set;}
		public string tax_code {get; set;}

		#endregion

		#region Entiteettiviittaukset

		public virtual Maksuaineisto batch_ {get; set;}

		#endregion

		#region Metodit

    //public override bool Equals(object obj)
    //{
    //  var tmp = obj as KirjanpidonAineistoRivi;
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
