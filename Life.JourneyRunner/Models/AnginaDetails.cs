namespace Life.JourneyRunner.Models
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