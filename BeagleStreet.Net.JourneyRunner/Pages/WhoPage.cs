using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class WhoPage
    {
        public enum SingleOrJoint
        {
            Single,
            Joint
        }

        private const string JustMeButton = "ValidAnswers_just";
        private const string MeAndAPartnerButton = "ValidAnswers_me";
        private const string NextButtonId = "nextPageButton";

        public static void Run(IWebDriver driver, ManualResetEvent manualResetEvent, SingleOrJoint singleOrJoint)
        {
            var selectedItem = singleOrJoint == SingleOrJoint.Single ? JustMeButton : MeAndAPartnerButton;

            driver.FindElement(By.ClassName(selectedItem)).Click();
            driver.FindElement(By.Id(NextButtonId)).Click();
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
