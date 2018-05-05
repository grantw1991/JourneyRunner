namespace Life.JourneyRunner.Models.BGL
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