using Sopimusrekisteri.BLL_CF.Class;
using System;

namespace Sopimusrekisteri.BLL_CF.Models
{
    [Serializable]
    public class IFRSLaskenta
    {
        public const int IFRS_Oletus_Vuodet = 35;

        public IFRSKausi Kausi { get; set; }
        public DateTime Pvm { get; set; }
        public DateTime? Alkaa { get; set; }
        public DateTime? Paattyy { get; set; }
        public int? LaskuttajaId { get; set; }
        public string Laskuttaja { get; set; }
        public bool IFRS { get; set; }
        public int Sopimusnumero { get; set; }
        public int? KorvauslaskelmaId { get; set; }
        public int? YhtioId { get; set; }
        public string Yhtio { get; set; }
        public int? VuokratyyppiId { get; set; }
        public string Vuokratyyppi { get; set; }
        public int? MaksunSuoritusId { get; set; }
        public string MaksunSuoritus { get; set; }
        public bool? MaksetaanAlv { get; set; }

        // vanhat
        public decimal? VanhaVuokra { get; set; }
        public decimal? VanhaKorko { get; set; }
        public decimal? VanhaKorkoProsentti => VanhaKorko / 100m;
        public decimal? VanhaVuodet { get; set; }
        public decimal? VanhaNykyarvo => 
            VanhaVuokra.HasValue && VanhaKorkoProsentti.HasValue && VanhaVuodet.HasValue ? 
            -MathUtils.Nykyarvo(VanhaKorkoProsentti.Value, VanhaVuodet.Value - Kausi.KaudenKoko, VanhaVuokra.Value) + VanhaVuokra.Value:
            null as decimal?;

        // uudet
        public decimal UusiVuokra { get; set; }
        public decimal UusiKorko { get; set; }
        public decimal UusiKorkoProsentti => UusiKorko / 100m;
        public decimal UusiVuodet => !Paattyy.HasValue ? IFRS_Oletus_Vuodet : (decimal)(Alkaa.HasValue && Alkaa.Value > Pvm ? Paattyy.Value - Alkaa.Value : Paattyy.Value - Pvm).Days / 365m;
        public decimal UusiNykyarvo => -MathUtils.Nykyarvo(UusiKorkoProsentti, UusiVuodet - Kausi.KaudenKoko, UusiVuokra) + UusiVuokra;


        public decimal NykyarvoMuutos => VanhaNykyarvo.HasValue ? UusiNykyarvo - VanhaNykyarvo.Value : 0;

        public decimal? GroupKorko => Min0(VanhaNykyarvo.HasValue ? (VanhaNykyarvo.Value - UusiVuokra + NykyarvoMuutos) * UusiKorkoProsentti : null as decimal?);
        public decimal? GroupPoisto => VanhaAssets.HasValue ? (UusiVuodet == 0 ? 0 : (VanhaAssets.Value + NykyarvoMuutos) / UusiVuodet) : null as decimal?;

        public decimal? VanhaAssets { get; set; }
        public decimal UusiAssets => Min0(VanhaAssets.HasValue ? VanhaAssets.Value + NykyarvoMuutos - (GroupPoisto ?? 0) : UusiNykyarvo - (GroupPoisto ?? 0));

        private decimal? Min0(decimal? arvo)
        {
            if (arvo.HasValue && arvo.Value < 0)
                return 0;

            return arvo;
        }

        private decimal Min0(decimal arvo)
        {
            if (arvo < 0)
                return 0;

            return arvo;
        }

    }
}
