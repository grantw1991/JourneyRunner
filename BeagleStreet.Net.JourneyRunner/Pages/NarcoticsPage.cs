using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class NarcoticsPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Question_INC1_1_{Utilities.ReturnFormattedDecision(personDetails.IsSmoker)}']");
            browser.ClickElementWithCss($"[for='Question_INC1_2_{Utilities.ReturnFormattedDecision(personDetails.HasUsedRecreationalInLast5Years)}']");
            browser.ClickElementWithCss($"[for='Question_INC1_3_{Utilities.ReturnFormattedDecision(personDetails.IsRegularDrinker)}']");
            browser.ClickElementWithCss("#nextPageButton");
        }
    }
}
