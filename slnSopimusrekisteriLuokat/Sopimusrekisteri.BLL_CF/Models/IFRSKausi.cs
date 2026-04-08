using System;
using System.Collections.Generic;
using System.Linq;

namespace Sopimusrekisteri.BLL_CF.Models
{
    [Serializable]
    public class IFRSKausi
    {
        public IFRSKausi()
        {
            Laskenta = new Dictionary<int, IFRSLaskenta>();
            YhteensaVuokratyypeittain = new List<IFRSYhteensaVuokratyypeittain>();
            YhteenvetoVuokratyypeittain = new List<IFRSLaskentaYhteenveto>();
        }

        public string Id { get; set; }
        public string HtmlId => "ifrs-kausi-" + Id;
        public string Lahde { get; set; }
        public bool HaettuKausi { get; set; }

        public DateTime Pvm { get; set; }

        public IFRSKausi EdellinenKausi { get; set; }

        /// <summary>
        /// Sisältää kaikki FAS & IFRS16 merkatut. FAS ei pitäisi olla mukana IFRS laskennassa mutta lasketaan kuitenkin, jos niitä tarvitsee FAS maturiteetin laskennassa
        /// </summary>
        public Dictionary<int, IFRSLaskenta> Laskenta { get; set; }

        /// <summary>
        /// Sisältää kaikki FAS & IFRS16 merkatut, joilla ei korvauslaskelmaa. FAS ei pitäisi olla mukana IFRS laskennassa mutta lasketaan kuitenkin, jos niitä tarvitsee FAS maturiteetin laskennassa
        /// </summary>
        public IEnumerable<IFRSLaskenta> LaskentaEiKorvauslaskelmaa { get; set; }

        /// <summary>
        /// Sisältää vain IFRS16-merkatut
        /// </summary>
        public IEnumerable<IFRSLaskenta> IFRSLaskenta => Laskenta.Select(x => x.Value).Where(x => x.IFRS);

        /// <summary>
        /// Sisältää vain IFRS16-merkatut (ei korvauslaskelmaa)
        /// </summary>
        public IEnumerable<IFRSLaskenta> IFRSLaskentaEiKorvauslaskelmaa => LaskentaEiKorvauslaskelmaa.Where(x => x.IFRS);

        public IEnumerable<IFRSYhteensaVuokratyypeittain> YhteensaVuokratyypeittain { get; set; }
        public IFRSYhteensaVuokratyypeittain Yhteensa { get; set; }

        public IEnumerable<IFRSLaskentaYhteenveto> YhteenvetoVuokratyypeittain { get; set; }
        public IFRSLaskentaYhteenveto Yhteenveto { get; set; }


        /// <summary>
        /// Kauden koko vuosissa. Käytännössä kaikki kaudet ovat 1v, paitsi viimeinen kausi jos hakuehtona ei ole vuoden viimeinen päivä
        /// </summary>
        public decimal KaudenKoko
        {
            get
            {
                if (EdellinenKausi == null)
                    return 1; // 1 vuosi

                if (EdellinenKausi.Pvm.AddYears(1).Date == Pvm.Date)
                    return 1; // 1 vuosi

                // lasketaan kauden koko
                return (Pvm - EdellinenKausi.Pvm).Days / 365m;
            }
        }

        public override bool Equals(object obj)
        {
            return Id == (obj as IFRSKausi).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
