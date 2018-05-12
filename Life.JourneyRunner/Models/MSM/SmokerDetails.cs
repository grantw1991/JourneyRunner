using System;

namespace Life.JourneyRunner.Models.MSM
{
    public class SmokerDetails
    {
        public int NumberOfCigarettesADay { get; set; }
        public int NumberOfCigarsADay { get; set; }
        public int NumberOfOtherTobaccoDay { get; set; }
        public bool UsedAnyOtherReplacementProductsWithinLastYear { get; set; }
        public DateTime LastDateSmoked { get; set; }
    }
}
