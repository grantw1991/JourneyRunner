using System.ComponentModel;

namespace Life.JourneyRunner.Models
{
    public class ChestPainDetails 
    {
        public enum YearsSinceAdvice
        {
            [Description("2 years or less")]
            TwoOrLess,
            [Description("More than 2 years")]
            MoreThanTwo
        }

        public bool AwaitingResults { get; set; }
        public YearsSinceAdvice YearsSinceMedicalAdvice { get; set; }
        public bool HadAbnormalResults { get; set; }
    }
}