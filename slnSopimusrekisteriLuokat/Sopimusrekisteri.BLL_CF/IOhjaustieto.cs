using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public interface IOhjaustieto : IEditable
  {

    int Id { get; set; }
    string Nimi { get; set; }
    
  }
}
