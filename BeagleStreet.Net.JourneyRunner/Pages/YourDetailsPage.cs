using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourDetailsPage
    {
        public static void Run(IWebDriver driver, ManualResetEvent manualResetEvent)
        {
            driver.FindElement(By.Id("PD2a_Select")).SendKeys("Mrs");
            driver.FindElement(By.Id("FirstName")).SendKeys("Grant");
            driver.FindElement(By.Id("Surname")).SendKeys("Grant");

            driver.FindElement(By.Id("EmailAddress")).SendKeys("Grant@rg.com");
            driver.FindElement(By.Id("AddressLine1")).SendKeys("3");
            driver.FindElement(By.Id("PostCode")).SendKeys("pe28gy");
            driver.FindElement(By.Id("findAddressLink")).Click();

            driver.FindElement(By.Id("PhoneNumber")).SendKeys("0123456789");

            driver.FindElement(By.ClassName("Contact_email")).Click();
            driver.FindElement(By.ClassName("Contact_telephone")).Click();
            driver.FindElement(By.ClassName("Contact_post")).Click();

            driver.FindElement(By.Id("nextPageButton")).Click();

            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
