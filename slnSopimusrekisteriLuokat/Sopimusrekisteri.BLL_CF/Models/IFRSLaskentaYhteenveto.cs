using System;

namespace Sopimusrekisteri.BLL_CF.Models
{
    [Serializable]
    public class IFRSLaskentaYhteenveto
    {
        public string Vuokratyyppi { get; set; }
        public int? VuokratyyppiId { get; set; }

        public decimal? Assets { get; set; } // Right of use asset, debit
        public decimal? Leasing { get; set; } // Leasingvelka, credit
        public decimal? Retained { get; set; } // Retained earnings

        public decimal? GroupKorkoPositiivinen { get; set; } // Group korko, debit
        public decimal? GroupKorkoNegatiivinen { get; set; } // Leasingvelka, credit

        public decimal? GroupPoistoPositiivinen { get; set; } // Group poisto, debit
        public decimal? GroupPoistoNegatiivinen { get; set; } // Right of use asset, credit

        public decimal? GroupVuokraPositiivinen { get; set; } // Leasingvelka, debit
        public decimal? GroupVuokraNegatiivinen { get; set; } // Group vuokra, credit

        public decimal? NykyarvoMuutosPositiivinen { get; set; } // Right of use asset, debit
        public decimal? NykyarvoMuutosNegatiivinen { get; set; } // Leasingvelka, credit

        public decimal? TarkistusAssets { get; set; } // Right of use asset
        public decimal? TarkistusLeasing { get; set; } // Leasingvelka
        public decimal? TarkistusRetained { get; set; } // Tulosvaikutus + retained

    }
}
