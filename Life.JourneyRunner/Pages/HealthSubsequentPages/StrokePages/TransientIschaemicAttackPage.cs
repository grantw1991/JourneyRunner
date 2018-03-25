using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages.HealthSubsequentPages.StrokePages
{
    public class TransientIschaemicAttackPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#Sections_0__Questions_0__Answer", personDetails.StrokeConditionDetails.TransientIschaemicAttackDetails.MonthsSinceFirstDiagnosed.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
