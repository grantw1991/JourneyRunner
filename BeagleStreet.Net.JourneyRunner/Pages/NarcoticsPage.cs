using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class NarcoticsPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Question_INC1_1_{Utilities.ReturnFormattedDecision(personDetails.IsSmoker)}']");
            browser.ClickElementWithCss($"[for='Question_INC1_2_{Utilities.ReturnFormattedDecision(personDetails.HasUsedRecreationalInLast5Years)}']");
            browser.ClickElementWithCss($"[for='Question_INC1_3_{Utilities.ReturnFormattedDecision(personDetails.IsRegularDrinker)}']");
            browser.ClickElementWithCss("#nextPageButton");


            if (personDetails.IsSmoker)
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_Tob0_Answers_{Utilities.ReturnFormattedDecision(personDetails.SmokerDetails.IsNicotineOnly)}']");
                browser.ClickElementWithCss("#nextPageButton");

                if (!personDetails.SmokerDetails.IsNicotineOnly)
                {
                    browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", personDetails.SmokerDetails.NumberOfCigarettesADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_2__Answer", personDetails.SmokerDetails.NumberOfCigarsADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_3__Answer", personDetails.SmokerDetails.NumberOfPanatelasADay.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_4__Answer", personDetails.SmokerDetails.NumberOfGramsOfPipeTobacco.ToString());
                    browser.EnterTextIntoElement("#Sections_0__Questions_5__Answer", personDetails.SmokerDetails.NumberOfGramsOfChewingTobacco.ToString());
                    browser.ClickElementWithCss("#nextPageButton");
                }
            }
        }
    }
}
