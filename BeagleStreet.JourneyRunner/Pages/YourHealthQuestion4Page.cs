using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages
{
    public class YourHealthQuestion4Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_NQ_INC23_Answers_{personDetails.HadKidneyOrBladderSymptoms.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC24_Answers_{personDetails.HadDepression.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC25_Answers_{personDetails.HadDoubleVision.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC26_Answers_{personDetails.AdvisedToLowerAlcoholIntake.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
