using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class SmokerPage
    {
        private const string IsSmokerButton = "ValidAnswers_yes";
        private const string NotSmokerButton = "ValidAnswers_no";
        private const string NextButtonId = "nextPageButton";

        public SmokerPage(IWebDriver driver, bool isSmoker)
        {
            var selectedItem = isSmoker ? IsSmokerButton : NotSmokerButton;

            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id(NextButtonId)).Click();
        }

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, bool isSmoker)
        {
            var selectedItem = isSmoker ? IsSmokerButton : NotSmokerButton;

            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id(NextButtonId)).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
