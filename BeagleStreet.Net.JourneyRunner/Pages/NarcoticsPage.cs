using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class NarcoticsPage
    {
        public void Run(IBrowser browser, ManualResetEvent pausEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Question_INC1_1_{personDetails.IsSmoker.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_INC1_2_{personDetails.HasUsedRecreationalInLast5Years.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_INC1_3_{personDetails.IsRegularDrinker.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pausEvent.WaitOne(Timeout.Infinite);

            if (personDetails.IsSmoker)
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_Tob0_Answers_{personDetails.SmokerDetails.IsNicotineOnly.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pausEvent.WaitOne(Timeout.Infinite);

                if (!personDetails.SmokerDetails.IsNicotineOnly)
                {
                    browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", personDetails.SmokerDetails.NumberOfCigarettesADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_2__Answer", personDetails.SmokerDetails.NumberOfCigarsADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_3__Answer", personDetails.SmokerDetails.NumberOfPanatelasADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_4__Answer", personDetails.SmokerDetails.NumberOfGramsOfPipeTobacco.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_5__Answer", personDetails.SmokerDetails.NumberOfGramsOfChewingTobacco.ToString());
                    browser.ClickElementWithCss("#nextPageButton");
                    pausEvent.WaitOne(Timeout.Infinite);
                }
            }
        }
    }
}
