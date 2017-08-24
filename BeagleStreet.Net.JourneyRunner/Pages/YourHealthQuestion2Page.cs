using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion2Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_1_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasCancer)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_2_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasMultipleSclerosis)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_3_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasMentalIllness)}']");


            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
