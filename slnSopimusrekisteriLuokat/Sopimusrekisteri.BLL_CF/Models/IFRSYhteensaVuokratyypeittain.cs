using System;

namespace Sopimusrekisteri.BLL_CF.Models
{
    [Serializable]
    public class IFRSYhteensaVuokratyypeittain
    {

        public int? VuokratyyppiId { get; set; }
        public string Nimi { get; set; }

        // vanhat
        public decimal? VanhaVuokra { get; set; }
        public decimal? VanhaNykyarvo { get; set; }

        // uudet
        public decimal UusiVuokra { get; set; }
        public decimal UusiNykyarvo { get; set; }

        public decimal NykyarvoMuutos { get; set; }

        public decimal? GroupKorko { get; set; }
        public decimal? GroupPoisto { get; set; }

        public decimal? Assets { get; set; }

    }
}
