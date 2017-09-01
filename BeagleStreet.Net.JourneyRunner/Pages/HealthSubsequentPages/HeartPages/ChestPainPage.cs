using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class ChestPainPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var chestPainDetails = personDetails.HeartConditionDetails.ChestPainDetails;
            browser.ClickElementWithCss($"[for='Sections_0_Questions_HRUKCPR1_Answers_{chestPainDetails.AwaitingResults.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!chestPainDetails.AwaitingResults)
            {
                browser.SelectTextFromDropdown("#Sections_0_Questions_HRUKCPR2_Answers_Select", chestPainDetails.YearsSinceMedicalAdvice.GetDescription());
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);

                browser.ClickElementWithCss($"[for='Sections_0_Questions_HRUKCPR3_Answers_{chestPainDetails.HadAbnormalResults.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
