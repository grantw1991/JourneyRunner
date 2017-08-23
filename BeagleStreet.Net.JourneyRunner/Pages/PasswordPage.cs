using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class PasswordPage
    {
        public static void Run(IWebDriver driver, ManualResetEvent manualResetEvent)
        {
            driver.FindElement(By.Id("Password")).SendKeys("P@55w0rd");
            driver.FindElement(By.Id("PasswordConfirmation")).SendKeys("P@55w0rd");

            driver.FindElement(By.Id("nextPageButton")).Click();
        }
    }
}
