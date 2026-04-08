using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF
{
  public class Kayttooikeustiedot
  {

    public Kayttooikeustiedot(string username)
    {
      this.Username = username;
    }

    public string Username { get; private set; }

    public KayttooikeusTaso Taso { get; set; }

  }
}
