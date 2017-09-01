namespace BeagleStreet.Net.JourneyRunner.Models
{
    public class AnginaDetails : IValidator
    {
        public int MonthsAgoSinceSymptoms { get; set; }

        public bool IsModelStateValid()
        {
            return MonthsAgoSinceSymptoms > 0;
        }
    }
}