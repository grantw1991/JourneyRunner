namespace Life.JourneyRunner
{
    public class UrlGenerator
    {
        public static string GenerateBaseUrl(string environment, string brand)
        {
            if (environment == "INT" || environment == "REG")
            {
                return brand == "Beagle Street"
                    ? $"http://pbo-lifedevap01:8010/BS-{environment}/"
                    : $"http://pbo-lifedevap01:8010/BS-{environment}-{brand}/";
            }

            if (environment == "UAT")
            {
                return $"https://testltd.doodleinsurance.co.uk/{brand}";
            }

            if (brand == "Beagle Street")
            {
                return "https://quotes.beaglestreet.com/Z011";
            }

            if (brand == "Virgin Money")
            {
                return "https://life.virginmoney.com/z018";
            }

            return "https://life.budgetinsurance.com/ZB11";
        }
    }
}
