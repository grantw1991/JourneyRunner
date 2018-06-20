namespace Life.JourneyRunner.Models.MSM
{
    public class NarcoticsDetails
    {
        public int NumberOfPintsAWeek { get; set; }
        public int NumberOfGlassesOfWineAWeek { get; set; }
        public int NumberOfSpiritsAWeek { get; set; }
        public int NumberOfAlcoholicDrinksPerWeek { get; set; }
        public bool HasBeenAdvisedToLowerAlcoholIntake { get; set; }
        public bool HasUsedRecreationalDrugsInLast10Years { get; set; }
    }
}
