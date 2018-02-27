using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
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

                var questionNumber = chestPainDetails.YearsSinceMedicalAdvice == ChestPainDetails.YearsSinceAdvice.MoreThanTwo ? "4" : "3";

                browser.ClickElementWithCss($"[for='Sections_0_Questions_HRUKCPR{questionNumber}_Answers_{chestPainDetails.HadAbnormalResults.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
