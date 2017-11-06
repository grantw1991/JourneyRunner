using System.ComponentModel;

namespace BeagleStreet.JourneyRunner.Models
{
    public class HeartRhythmDisorderDetails
    {
        public enum PalpitationType
        {
            [Description("yes")]
            Yes,
            [Description("no")]
            No,
            [Description("dont")]
            DontKnow
        }

        public bool HasHeartDisorderBeenInvestigated { get; set; }
        public bool WasOnDrugTreatment { get; set; }
        public PalpitationType WasDueToPalpitations { get; set; }
        public bool HadFollowUpCheckUp { get; set; }
        public bool IsNowSymptomFree { get; set; }
    }
}