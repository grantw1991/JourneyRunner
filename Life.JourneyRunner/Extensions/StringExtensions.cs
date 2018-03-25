namespace Life.JourneyRunner.Extensions
{
    public static class StringExtensions
    {
        public static string ToYesNo(this bool value)
        {
            return value ? "yes" : "no";
        }
    }
}
