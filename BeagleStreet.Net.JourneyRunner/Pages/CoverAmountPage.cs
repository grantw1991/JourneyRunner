using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class CoverAmountPage
    {
        private const string NextButtonId = "nextPageButton";

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, int amount)
        {
            driver.FindElements(By.ClassName("cover-amount__item")).First().Click();
            driver.FindElement(By.Id(NextButtonId)).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
