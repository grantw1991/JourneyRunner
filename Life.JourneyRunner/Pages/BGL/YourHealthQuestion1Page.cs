using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;
using Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.HeartPages;
using Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.StrokePages;

namespace Life.JourneyRunner.Pages.BGL
{
    public class YourHealthQuestion1Page
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC10_Answers_{personDetails.IsHIVPositive.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC11_Answers_{personDetails.IsDiabetic.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC12_Answers_{personDetails.HasHeartCondition.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC13_Answers_{personDetails.HasStroke.ToYesNo()}']");
            
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!personDetails.IsHIVPositive && !personDetails.HasHeartCondition && !personDetails.HasStroke)
                return;

            if (personDetails.IsHIVPositive)
            {
                browser.SelectValueFromDropdown("#Sections_0_Questions_HIV_Answers_Select", personDetails.HIVCondition.ToString().ToLower());
            }

            if (personDetails.IsDiabetic)
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_INC11a_Answers_{personDetails.IsGestationalDiabetes.ToYesNo()}']");
            }

            if (personDetails.HasHeartCondition)
            {
                var details = personDetails.HeartConditionDetails;

                details.HeartConditions.ToList().ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeLv2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(condition.GetDescription())).Click();
                });
            }

            if (personDetails.HasStroke)
            {
                var details = personDetails.StrokeConditionDetails;

                details.StrokeConditions.ToList().ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeSSH_2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(condition.GetDescription())).Click();
                });
            }

            browser.ClickElementWithCss("#appId");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            HandleSubsequentHIVPages(browser, pauseEvent, personDetails);
            HandleSubsequentDiabetesConditionPages(browser, pauseEvent, personDetails);
            HandleSubsequentHeartConditionPages(browser, pauseEvent, personDetails);
            HandleSubsequentStrokeConditionPages(browser, pauseEvent, personDetails);
        }

        private void HandleSubsequentHIVPages(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            if (!personDetails.IsHIVPositive)
                return;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIV2_Answers_{personDetails.HivDetails.TestedPositiveForHepatitisBOrC.ToYesNo()}']");

            if (!personDetails.HivDetails.TestedPositiveForHepatitisBOrC)
            {
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIV3_Answers_{personDetails.HivDetails.CurrentlyReceivingTherapy.ToYesNo()}']");

            if (personDetails.HivDetails.CurrentlyReceivingTherapy)
            {
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HIV4_Answers_{personDetails.HivDetails.ReceivingTreatmentFor24WeeksOrMore.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }

        private void HandleSubsequentDiabetesConditionPages(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            if (!personDetails.IsDiabetic || !personDetails.IsGestationalDiabetes)
                return;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_GD2_Answers_{personDetails.HeartStrokeOrKidneyProblems.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!personDetails.HeartStrokeOrKidneyProblems)
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_GD3_Answers_{personDetails.HasConditionHadNoOnGoingTreatment.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }
        }

        private void HandleSubsequentHeartConditionPages(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            if (!personDetails.HasHeartCondition || personDetails.HeartConditionDetails.HeartConditions == null || !personDetails.HeartConditionDetails.HeartConditions.Any())
                return;

            foreach (var heartCondition in personDetails.HeartConditionDetails.HeartConditions)
            {
                switch (heartCondition)
                {
                    case HeartConditionDetails.HeartConditionType.Angina:
                        new AnginaPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.ChestPain:
                        new ChestPainPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.CoronaryArteryDisease:
                        new CoronaryHeartDiseasePage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.HeartAttack:
                        new HeartAttackPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.HeartRhythmDisorder:
                    case HeartConditionDetails.HeartConditionType.IrregularHeartbeat:
                        new HeartRhythmDisorderPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.HeartValveDisorder:
                        new HeartValveDisorderPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.Other:
                        new OtherPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case HeartConditionDetails.HeartConditionType.RaisedBloodPressure:
                        new BloodPressurePage().Run(browser, pauseEvent, personDetails);
                        break;
                }
            }
        }

        private void HandleSubsequentStrokeConditionPages(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            if (!personDetails.HasStroke || personDetails.StrokeConditionDetails.StrokeConditions == null || !personDetails.StrokeConditionDetails.StrokeConditions.Any())
                return;

            foreach (var strokeCondition in personDetails.StrokeConditionDetails.StrokeConditions)
            {
                switch (strokeCondition)
                {
                    case StrokeConditionDetails.StrokeConditionType.BrainBleed:
                    case StrokeConditionDetails.StrokeConditionType.BrainHaemorrhage:
                    case StrokeConditionDetails.StrokeConditionType.CerebralHaemorrhage:
                    case StrokeConditionDetails.StrokeConditionType.CerebrovascularAccident:
                    case StrokeConditionDetails.StrokeConditionType.NarrowingOfArteries:
                    case StrokeConditionDetails.StrokeConditionType.TransientIschaemicAttack:
                    case StrokeConditionDetails.StrokeConditionType.Stroke:
                    case StrokeConditionDetails.StrokeConditionType.SubarachnoidHaemorrhage:
                        new TransientIschaemicAttackPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case StrokeConditionDetails.StrokeConditionType.BrainInjury:
                        new BrainInjuryPage().Run(browser, pauseEvent, personDetails);
                        break;
                    case StrokeConditionDetails.StrokeConditionType.HeadInjury:
                        new HeadInjuryPage().Run(browser, pauseEvent, personDetails);
                        break;
                }
            }
        }
    }
}
