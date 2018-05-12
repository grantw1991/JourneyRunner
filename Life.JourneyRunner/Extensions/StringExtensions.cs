namespace Life.JourneyRunner.Extensions
{
    public static class StringExtensions
    {
        public static string ToYesNo(this bool value)
        {
            return value ? "yes" : "no";
        }

        public static string ToBit(this bool value)
        {
            return value ? "0" : "1";
        }
    }
}
