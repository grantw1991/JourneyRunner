using System;
using System.Threading;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class DateOfBirthPage
    {
        public DateOfBirthPage(IWebDriver driver, DateTime dateOfBirth)
        {
            driver.FindElement(By.Id("Answer")).SendKeys(dateOfBirth.ToString("dd/MM/yyyy"));
            driver.FindElement(By.Id("nextPageButton")).Click();
        }

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, DateTime dateOfBirth)
        {
            driver.FindElement(By.Id("Answer")).SendKeys(dateOfBirth.ToString("dd/MM/yyyy"));
            driver.FindElement(By.Id("nextPageButton")).Click();

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
