using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class BloodPressurePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var bloodPressureDetails = personDetails.HeartConditionDetails.BloodPressureDetails;

            browser.EnterTextIntoElement("#Sections_0__Questions_0__Answer", bloodPressureDetails.MonthsSinceFirstDiagnosed.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", bloodPressureDetails.MonthsSinceCheckedByDoctor.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (browser.ElementIsVisible($"[for='Sections_0_Questions_HYPERT3_Answers_{bloodPressureDetails.HasAbnormalHeartProblems.ToYesNo()}']"))
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_HYPERT3_Answers_{bloodPressureDetails.HasAbnormalHeartProblems.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            if (browser.ElementIsVisible($"[for='Sections_0_Questions_HYPERT4_Answers_{bloodPressureDetails.HasKidneyProblems.ToYesNo()}']"))
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_HYPERT4_Answers_{bloodPressureDetails.HasKidneyProblems.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            if (browser.ElementIsVisible($"[for='Sections_0_Questions_HYPERT6_Answers_{bloodPressureDetails.HasRaisedCholesterol.ToYesNo()}']"))
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_HYPERT6_Answers_{bloodPressureDetails.HasRaisedCholesterol.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            if (browser.ElementIsVisible("#Sections_0_Questions_HYPERT7_Answers_Select"))
            {
                browser.SelectTextFromDropdown("#Sections_0_Questions_HYPERT7_Answers_Select", bloodPressureDetails.BloodPressureReading.GetDescription());
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
