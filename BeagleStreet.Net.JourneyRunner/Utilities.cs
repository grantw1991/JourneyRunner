namespace BeagleStreet.Net.JourneyRunner
{
    public class Utilities
    {
        public static string GenerateJourneyUrl(string environment, string brand)
        {
            // this need refactoring!!!


            if (environment == "INT" || environment == "REG")
            {
                return brand == "Beagle Street"
                    ? $"http://pbo-lifedevap01:801​0/BS-{environment}"
                    : $"http://pbo-lifedevap01:801​0/BS-{environment}-{brand}";
            }

            if (brand == "Beagle Street")
            {
                return "https://quotes.beaglestreet.com/Z011";
            }

            if (brand == "Virgin Money")
            {
                return "https://life.virginmoney.com/z018";
            }

            return "https://life.budgetinsurance.com/ZB11​";
        }

        public static string ReturnFormattedDecision(bool value)
        {
            return value ? "yes" : "no";
        }
    }
}
