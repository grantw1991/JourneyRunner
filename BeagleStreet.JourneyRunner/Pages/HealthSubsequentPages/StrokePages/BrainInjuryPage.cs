using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages.HealthSubsequentPages.StrokePages
{
    public class BrainInjuryPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var brainInjuryDetails = personDetails.StrokeConditionDetails.BrainInjuryDetails;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIR1_Answers_{brainInjuryDetails.IsAwaitingTests.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (brainInjuryDetails.IsAwaitingTests)
            {
                return;
            }

            browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", brainInjuryDetails.MonthsSinceSymptoms.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
