using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
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

            if (personDetails.HasUsedRecreationalInLast5Years)
            {
                personDetails.Drugs.ForEach(drug =>
                {
                    browser.ClickElementWithCss("#questionCodeDMR2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(drug)).Click();
                });

                browser.ClickElementWithCss(".sessioncamhidetext");

                if (personDetails.Drugs.Any())
                {
                    browser.ClickElementWithCss("#nextPageButton");
                    pausEvent.WaitOne(Timeout.Infinite);
                }

                if (personDetails.Drugs.Contains("Cannabis"))
                {
                    browser.EnterTextIntoElement("#Sections_1__Questions_0__Answer", personDetails.DaysSinceCannabisIntake.ToString());
                }

                if (personDetails.Drugs.Contains("Ecstasy, Speed, Cocaine, LSD") || 
                    personDetails.Drugs.Contains("Sedatives, Stimulants, Tranquilizers") || 
                    personDetails.Drugs.Contains("Anabolic Steroids"))
                {
                    browser.ClickElementWithCss($"#Sections_2_Questions_DM2_Answers_{personDetails.HasRequiredProfessionalCareForDrugs.ToYesNo()}");
                }

                if (personDetails.Drugs.Contains("Heroin, Methadone, Morphine"))
                {
                    browser.SelectValueFromDropdown("#Sections_3_Questions_DM5_Answers_Select", personDetails.WasItLessThan5YearsSinceHeroin ? "less" : "5");
                }

                browser.ClickElementWithCss("#nextPageButton");
                pausEvent.WaitOne(Timeout.Infinite);
            }

            if (personDetails.IsRegularDrinker)
            {
                browser.EnterTextIntoElement("#Sections_1__Questions_0__Answer", personDetails.PintsOfBeer.ToString());
                browser.EnterTextIntoElement("#Sections_1__Questions_1__Answer", personDetails.GlassesOfWine.ToString());
                browser.EnterTextIntoElement("#Sections_1__Questions_2__Answer", personDetails.NumberOfShots.ToString());
                browser.ClickElementWithCss("#nextPageButton");
                pausEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
