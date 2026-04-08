using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Taho : IEditable
  {
    #region Propertyt

    public int Id { get; set; }
    public TahoTyypit? TyyppiId { get; set; }
    public string Sukunimi { get; set; }
    public string EdellinenSukunimi { get; set; }
    public string Etunimi { get; set; }
    public string Nimitarkenne { get; set; }
    public Organisaatiotyypit? OrganisaationTyyppiId { get; set; }
    public string Ytunnus { get; set; }
    public string Lisaosoite { get; set; }
    public string Postitusosoite { get; set; }
    public string Postituspostinro { get; set; }
    public string Postituspostitmp { get; set; }
    public int? MaaId { get; set; }
    public string Tilinumero { get; set; }
    public string Puhelin { get; set; }
    public string Email { get; set; }
    public bool AlvVelvollinen { get; set; }
    public DateTime? Passivointipvm { get; set; }
    public int? PassivoinninsyyId { get; set; }
    public bool Aktiivi { get; set; }
    public string Info { get; set; }
    public string Paivittaja { get; set; }
    public DateTime? Paivitetty { get; set; }
    public DateTime Luotu { get; set; }
    public string Luoja { get; set; }
    public int? KuntaId { get; set; }
    public string BicKoodiMuu { get; set; }
    public int? BicKoodiId { get; set; }
    public string KirjanpidonYritystunniste { get; set; }
    public string KirjanpidonProjektitunniste { get; set; }
    public string Concession { get; set; }

    public string Nimi
    {
      get
      {
        if (this.TyyppiId == TahoTyypit.Organisaatio)
          return (this.Sukunimi + " " + this.Nimitarkenne).Trim();
        else
          return (this.Etunimi + " " + this.Sukunimi).Trim();
      }
    }

    public string Bic
    {
      get
      {
        if (this.BicKoodi != null)
          return this.BicKoodi.Koodi;

        return this.BicKoodiMuu;
      }
    }

    #endregion

    #region Entiteettiviittaukset

    public virtual TahoTyyppi Tyyppi { get; set; }
    public virtual OrganisaationTyyppi OrganisaationTyyppi { get; set; }
    public virtual Maa Maa { get; set; }
    public virtual PassivoinninSyy Passivoinninsyy { get; set; }
    public virtual Kunta Kunta { get; set; }
    public virtual BicKoodi BicKoodi { get; set; }
    public virtual ICollection<Kiinteisto> Kiinteistot { get; set; }

    #endregion

    #region Metodit

    public override bool Equals(object obj)
    {
      var tmp = obj as Taho;
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
