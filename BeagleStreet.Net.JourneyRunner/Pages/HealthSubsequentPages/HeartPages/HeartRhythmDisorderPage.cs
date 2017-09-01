using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class HeartRhythmDisorderPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var heart = personDetails.HeartConditionDetails.HeartRhythmDisorderDetails;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTR1_Answers_{heart.HasHeartDisorderBeenInvestigated.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!heart.HasHeartDisorderBeenInvestigated)
            {
                return;
            }
               

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTR2_Answers_{heart.WasOnDrugTreatment.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (heart.WasOnDrugTreatment)
            {
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTR3_Answers_{heart.WasDueToPalpitations.GetDescription()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (heart.WasDueToPalpitations != HeartRhythmDisorderDetails.PalpitationType.Yes)
            { 
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTR4_Answers_{heart.HadFollowUpCheckUp.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (heart.HadFollowUpCheckUp)
            {
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTR5_Answers_{heart.IsNowSymptomFree.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
