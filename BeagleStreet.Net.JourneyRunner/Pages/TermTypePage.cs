using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class TermTypePage
    {
        public enum TermType
        {
            Level,
            Decreasing
        }

        private const string DecreasingTermButton = "ValidAnswers_decreasing";
        private const string LevelTermButton = "ValidAnswers_level";
        private const string NextButtonId = "nextPageButton";

        public TermTypePage(IWebDriver driver, TermType termType)
        {
            var selectedItem = termType == TermType.Decreasing ? DecreasingTermButton : LevelTermButton;
            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id(NextButtonId)).Click();
        }

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, TermType termType)
        {
            var selectedItem = termType == TermType.Decreasing ? DecreasingTermButton : LevelTermButton;
            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id(NextButtonId)).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
