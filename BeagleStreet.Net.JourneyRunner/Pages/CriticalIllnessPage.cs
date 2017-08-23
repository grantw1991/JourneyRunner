using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class CriticalIllnessPage
    {
        private const string IncludeCriticalIllnessButton = "ValidAnswers_yes";
        private const string DoNotIncludeCriticalIllnessButton = "ValidAnswers_no";
        private const string NextButtonId = "nextPageButton";

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, bool includeCriticalIllness, int criticalIllnessAmount)
        {
            var selectedItem = includeCriticalIllness ? IncludeCriticalIllnessButton : DoNotIncludeCriticalIllnessButton;

            driver.FindElement(By.ClassName(selectedItem)).Click();

            if (includeCriticalIllness)
            {
                var criticalIllnessBox = driver.FindElement(By.Id("CriticalIllnessAmount"));
                criticalIllnessBox.Clear();
                criticalIllnessBox.SendKeys(criticalIllnessAmount.ToString());
            }

            driver.FindElement(By.Id(NextButtonId)).Click();
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
