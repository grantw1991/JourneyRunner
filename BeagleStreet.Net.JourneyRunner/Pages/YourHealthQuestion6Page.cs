using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion6Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC34_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadGout)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC35_Answers_{Utilities.ReturnFormattedDecision(personDetails.BeenPerscribedTreatment)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC36_Answers_{Utilities.ReturnFormattedDecision(personDetails.BeenUnderInvestigationForTreatment)}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
