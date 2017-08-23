using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class CoverTermPage
    {
        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, int years)
        {
            driver.FindElement(By.Id("CoverTermList")).SendKeys(years.ToString());
            driver.FindElement(By.Id("nextPageButton")).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
