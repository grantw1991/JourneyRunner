using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class YourHealthQuestion6Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC34_Answers_{personDetails.HadGout.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC35_Answers_{personDetails.BeenPerscribedTreatment.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC36_Answers_{personDetails.BeenUnderInvestigationForTreatment.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
