using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion3Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC20_Answers_{personDetails.HadTreatmentOnHeart.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC21_Answers_{personDetails.HadAsthma.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC22_Answers_{personDetails.HadAnyLiverDisorder.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
