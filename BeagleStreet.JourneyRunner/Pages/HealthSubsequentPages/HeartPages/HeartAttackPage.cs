using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class HeartAttackPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var heartAttackDetails = personDetails.HeartConditionDetails.HeartAttackDetails;
            browser.SelectTextFromDropdown("#Sections_0_Questions_HAR2_Answers_Select", heartAttackDetails.YearsSinceAttackValue.GetDescription());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
