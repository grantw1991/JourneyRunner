using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourLocationPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_1_Questions_INC7_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasLivedInAfricaInLast2Years)}']");
            browser.ClickElementWithCss($"[for='Sections_1_Questions_INC8_Answers_{Utilities.ReturnFormattedDecision(personDetails.IntendToLiveOutsideOfUkInNext2Years)}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
