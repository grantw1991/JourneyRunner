using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion4Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_NQ_INC23_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadKidneyOrBladderSymptoms)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC24_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadDepression)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC25_Answers_{Utilities.ReturnFormattedDecision(personDetails.HadDoubleVision)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC26_Answers_{Utilities.ReturnFormattedDecision(personDetails.AdvisedToLowerAlcoholIntake)}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
