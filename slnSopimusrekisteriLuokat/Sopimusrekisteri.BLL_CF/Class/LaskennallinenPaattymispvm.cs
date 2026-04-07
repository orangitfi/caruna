using System;

namespace Sopimusrekisteri.BLL_CF.Class
{
    public class LaskennallinenPaattymispvm
    {

        public DateTime Nyt { get; set; }
        public DateTime? Paattyy { get; set; }
        public DateTime? Irtisanottu { get; set; }
        public DateTime? Alkaa { get; set; }
        public int? Jatkoaika { get; set; }
        public int? Irtisanomisaika { get; set; }

        public LaskennallinenPaattymispvm()
        {
            Nyt = DateTime.Now.Date;
        }

        public DateTime? Value => LaskePaattymispvm();

        private DateTime? LaskePaattymispvm()
        {
            if (!Irtisanomisaika.HasValue && ((Alkaa.HasValue && Irtisanottu.HasValue) || (!Alkaa.HasValue && !Paattyy.HasValue && Irtisanottu.HasValue)))
                return Irtisanottu?.AddYears(1);

            if (!Paattyy.HasValue)
                return Irtisanottu?.AddMonths(Irtisanomisaika ?? 0) ?? DateTime.MaxValue.Date;

            if (Jatkoaika.GetValueOrDefault(0) <= 0)
                return Paattyy;

            var laskennallinen = Paattyy.Value;
            while (laskennallinen < Nyt)
            {
                try
                {
                    laskennallinen = laskennallinen.AddMonths(Jatkoaika.Value);

                    if (laskennallinen > (Irtisanottu?.AddMonths(Irtisanomisaika ?? 0)).GetValueOrDefault(DateTime.MaxValue.Date))
                        return laskennallinen;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    return DateTime.MaxValue.Date;
                }
            }

            return laskennallinen;
        }
    }
}
