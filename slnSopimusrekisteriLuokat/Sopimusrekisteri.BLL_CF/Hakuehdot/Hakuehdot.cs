using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.BLL_CF.Hakuehdot
{
    public abstract class Hakuehdot
    {

        public Hakuehdot() : base()
        {
        }

        public IEnumerable<string> IncludePaths { get; set; }

    }

    public abstract class Hakuehdot<T> : Hakuehdot where T : class
    {

        public Hakuehdot() : base()
        {
        }

        public System.Linq.Expressions.Expression<Func<T, bool>> Suodatusfunktio { get; set; }

    }
}
