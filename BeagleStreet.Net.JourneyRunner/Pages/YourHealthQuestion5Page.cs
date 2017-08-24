using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion5Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC29_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasEyeSymptoms)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC30_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadLumpOrGrowth)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC31_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadColitis)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC32_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadBloodCondition)}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
