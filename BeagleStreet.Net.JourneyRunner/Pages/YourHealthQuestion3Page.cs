using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion3Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC20_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadTreatmentOnHeart)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC21_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadAsthma)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC22_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadAnyLiverDisorder)}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
