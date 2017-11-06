using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages
{
    public class YourHealthQuestion2Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_1_Answers_{personDetails.HasCancer.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_2_Answers_{personDetails.HasMultipleSclerosis.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC4_3_Answers_{personDetails.HasMentalIllness.ToYesNo()}']");


            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
