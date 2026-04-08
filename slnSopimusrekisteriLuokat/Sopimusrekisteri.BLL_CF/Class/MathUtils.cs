using Microsoft.VisualBasic;
using System;

namespace Sopimusrekisteri.BLL_CF.Class
{
    public static class MathUtils
    {

        public static decimal Nykyarvo(decimal korko, decimal vuodet, decimal vuokra)
        {
            return (decimal)Financial.PV(
                    decimal.ToDouble(korko),
                    decimal.ToDouble(vuodet),
                    decimal.ToDouble(vuokra));
        }

    }
}
