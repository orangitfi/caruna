using System;

namespace Sopimusrekisteri.BLL_CF
{

  public interface IEditable
  {

    DateTime? Paivitetty { get; set; }
    string Paivittaja { get; set; }
    DateTime Luotu { get; set; }
    string Luoja { get; set; }

  }
  
}
