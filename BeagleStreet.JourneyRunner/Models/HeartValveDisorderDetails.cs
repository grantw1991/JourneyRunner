using System.ComponentModel;

namespace BeagleStreet.JourneyRunner.Models
{
    public class HeartValveDisorderDetails
    {
        public enum OtherIllness
        {
            [Description("Yes")]
            Yes,
            [Description("None of the above")]
            None,
            [Description("Don't know")]
            DontKnow
        }

        public bool HasBeenInvestigated { get; set; }
        public bool IsConnectedToAnotherCondition { get; set; }
        public OtherIllness IsRelatedToOtherIllness { get; set; }
    }
}