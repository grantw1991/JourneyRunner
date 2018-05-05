using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.StrokePages
{
    public class HeadInjuryPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var headInjuryDetails = personDetails.StrokeConditionDetails.HeadInjuryDetails;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIR1_Answers_{headInjuryDetails.IsAwaitingTests.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (headInjuryDetails.IsAwaitingTests)
            {
                return;
            }

            browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", headInjuryDetails.MonthsSinceFirstSymptom.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (browser.ElementIsVisible($"for='Sections_0_Questions_HIR3_Answers_{headInjuryDetails.HasFullyRecorvered.ToYesNo()}']"))
            {
                browser.ClickElementWithCss($"for='Sections_0_Questions_HIR3_Answers_{headInjuryDetails.HasFullyRecorvered.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            if (!browser.ElementIsVisible($"[for='Sections_0_Questions_HIR3_Answers_{headInjuryDetails.HasFullyRecorvered.ToYesNo()}']"))
            {
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIR3_Answers_{headInjuryDetails.HasFullyRecorvered.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!browser.ElementIsVisible($"[for='Sections_0_Questions_HIR4_Answers_{headInjuryDetails.OnAnyOtherTreatment.ToYesNo()}']"))
            {
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIR4_Answers_{headInjuryDetails.OnAnyOtherTreatment.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!browser.ElementIsVisible($"[for='Sections_0_Questions_HIR5_Answers_{headInjuryDetails.WasInAComa.ToYesNo()}']"))
            {
                return;
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIR5_Answers_{headInjuryDetails.WasInAComa.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!browser.ElementIsVisible("#Sections_0_Questions_HIR6_Answers_Select"))
            {
                return;
            }

            browser.SelectTextFromDropdown("#Sections_0_Questions_HIR6_Answers_Select", headInjuryDetails.LastSustainedInjury.GetDescription());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
