using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class GenderPage
    {
        public enum Gender
        {
            Male,
            Female
        }

        private const string male = "ValidAnswers_male";
        private const string female = "ValidAnswers_female";

        public GenderPage(IWebDriver driver, Gender gender)
        {
            var selectedItem = gender == Gender.Female ? female : male;

            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id("nextPageButton")).Click();
        }

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, Gender gender)
        {
            var selectedItem = gender == Gender.Female ? female : male;

            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id("nextPageButton")).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
