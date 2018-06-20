using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.HeartPages
{
    public class AnginaPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#Sections_0__Questions_0__Answer", personDetails.HeartConditionDetails.AnginaDetails.MonthsAgoSinceSymptoms.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
