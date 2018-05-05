namespace Life.JourneyRunner
{
    public class UrlGenerator
    {
        public static string GenerateBaseUrl(string application, string environment, string brand)
        {
            if (application == "BGL (Curiosity)")
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

                return brand == "Virgin Money" ? "https://life.virginmoney.com/z018" : "https://life.budgetinsurance.com/ZB11";
            }

            return "https://www.moneysupermarket.com/life-insurance/enquiry/#no";
        }
    }
}
