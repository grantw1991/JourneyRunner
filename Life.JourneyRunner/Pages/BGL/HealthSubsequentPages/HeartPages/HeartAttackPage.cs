using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.HeartPages
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
