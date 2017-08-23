using System;
using System.Threading;
using BeagleStreet.Net.JourneyRunner.Pages;
using OpenQA.Selenium;

namespace BeagleStreet.Net.JourneyRunner.Models
{
    public class Journey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public WhoPage.SingleOrJoint SingleOrJoint { get; set; }
        public GenderPage.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public TermTypePage.TermType TermType { get; set; }
        public int CoverAmount { get; set; }
        public int CoverDuration { get; set; }
        public bool RequiresCriticalIllness { get; set; }
        public int CriticalIllnessAmount { get; set; }

        public static void Run(IWebDriver driver, ManualResetEvent pauseEvent, Journey journey)
        {
            WhoPage.Run(driver, pauseEvent, journey.SingleOrJoint);
            GenderPage.Run(driver, pauseEvent, journey.Gender);
            DateOfBirthPage.Run(driver, pauseEvent, journey.DateOfBirth);
            SmokerPage.Run(driver, pauseEvent, journey.IsSmoker);
            TermTypePage.Run(driver, pauseEvent, journey.TermType);
            CoverAmountPage.Run(driver, pauseEvent, journey.CoverAmount);
            CoverTermPage.Run(driver, pauseEvent, journey.CoverDuration);
            CriticalIllnessPage.Run(driver, pauseEvent, journey.RequiresCriticalIllness, journey.CriticalIllnessAmount);
            YourDetailsPage.Run(driver, pauseEvent);
            IndicativeQuotePage.Run(driver, pauseEvent);
            PasswordPage.Run(driver, pauseEvent);
        }
    }
}
