using System.ComponentModel;

namespace Life.JourneyRunner.Models
{
    public class HeadInjuryDetails : IValidator
    {
        public enum SinceLastSustainedInjury
        {
            [Description("3 years or less")]
            ThreeYearsOrLess,
            [Description("More than 3 years")]
            MoreThanThreeYears
        }

        public bool IsAwaitingTests { get; set; }
        public int MonthsSinceFirstSymptom { get; set; }
        public bool HasFullyRecorvered { get; set; }
        public bool OnAnyOtherTreatment { get; set; }
        public bool WasInAComa { get; set; }
        public SinceLastSustainedInjury LastSustainedInjury { get; set; }

        public bool IsModelStateValid()
        {
            return !IsAwaitingTests || MonthsSinceFirstSymptom > -1;
        }
    }
}
