using System.ComponentModel;

namespace Life.JourneyRunner.Models
{
    public class BloodPressureDetails : IValidator
    {
        public enum BloodPressureDescription
        {
            [Description("It was a one-off raised reading. Check with GP was normal, no treatment or follow-up needed.")]
            OneOffReading,
            [Description("Normal")]
            Normal,
            [Description("Slightly higher than normal")]
            SlightlyHigherThanNormal,
            [Description("High or resistant high blood pressure")]
            High
        }

        public int MonthsSinceFirstDiagnosed { get; set; }
        public int MonthsSinceCheckedByDoctor { get; set; }
        public bool HasAbnormalHeartProblems { get; set; }
        public bool HasKidneyProblems { get; set; }
        public bool HasRaisedCholesterol { get; set; }
        public BloodPressureDescription BloodPressureReading { get; set; }

        public bool IsModelStateValid()
        {
            throw new System.NotImplementedException();
        }
    }
}