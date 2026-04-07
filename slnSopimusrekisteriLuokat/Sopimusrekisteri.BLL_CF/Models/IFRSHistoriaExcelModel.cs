using System;

namespace Sopimusrekisteri.BLL_CF.Models
{
    public class IFRSHistoriaExcelModel
    {

        public int Id { get; set; }
        public DateTime Pvm { get; set; }
        public DateTime Luotu { get; set; }
        public string Luoja { get; set; }
        public string Nimi { get; set; }

    }
}
