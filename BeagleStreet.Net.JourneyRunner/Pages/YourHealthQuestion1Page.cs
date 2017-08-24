using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion1Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC10_Answers_{Utilities.ReturnFormattedDecision(personDetails.IsHIVPositive)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC11_Answers_{Utilities.ReturnFormattedDecision(personDetails.IsDiabetic)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC12_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasHeartCondition)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC13_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasStroke)}']");
            

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
