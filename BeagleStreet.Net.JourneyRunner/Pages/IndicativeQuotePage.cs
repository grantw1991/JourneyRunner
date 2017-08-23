using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class IndicativeQuotePage
    {
        public static void Run(IWebDriver driver, ManualResetEvent manualResetEvent)
        {
            driver.FindElement(By.Id("nextPageButton")).Click();
        }
    }
}
