using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopimusrekisteri.DAL_CF.EntityHandlers
{
    public class InspectPreviousValuesEventArgs<T> : EventArgs
    {
        public InspectPreviousValuesEventArgs()
        {
            this.RestoreCurrentValues = true;
        }

        public T Entity { get; set; }

        public DbPropertyValues CurrentValues { get; set; }

        public bool RestoreCurrentValues { get; set; }

    }
}
