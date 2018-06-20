using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
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

            if (!personDetails.HasCancer && !personDetails.HasMultipleSclerosis)
                return;

            if (personDetails.HasCancer)
            {
                personDetails.CancerTypes.ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeCLHD_2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(condition)).Click();
                });
            }

            if (personDetails.HasMultipleSclerosis)
            {
                personDetails.MultipleSclerosisConditions.ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeMSONP_2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(condition)).Click();
                });
            }

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);

            if (personDetails.HasCancer)
            {
                browser.ClickElementWithCss($"[for='Sections_0_Questions_TUMOUR1_Answers_{personDetails.WaitingForCancerTreatment.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");
                manualResetEvent.WaitOne(Timeout.Infinite);

                if (!personDetails.WaitingForCancerTreatment)
                {
                    browser.ClickElementWithCss($"[for='Sections_0_Questions_TUMOUR2_Answers_{personDetails.MalignantTumorOrGrowth.ToYesNo()}']");
                    browser.ClickElementWithCss("#nextPageButton");
                    manualResetEvent.WaitOne(Timeout.Infinite);

                    if (!personDetails.MalignantTumorOrGrowth)
                    {
                        browser.SelectValueFromDropdown("#Sections_0_Questions_TUMOUR3_Answers_Select", personDetails.DurationSinceGrowthDiagnosis);
                        browser.ClickElementWithCss("#nextPageButton");
                        manualResetEvent.WaitOne(Timeout.Infinite);

                        if (personDetails.DurationSinceGrowthDiagnosis == "5")
                        {
                            browser.ClickElementWithCss($"[for='Sections_0_Questions_TUMOUR4_Answers_{personDetails.CurrentlyOnTreatmentForTheTumour.ToYesNo()}']");
                            browser.ClickElementWithCss("#nextPageButton");
                            manualResetEvent.WaitOne(Timeout.Infinite);

                            if (!personDetails.CurrentlyOnTreatmentForTheTumour)
                            {
                                browser.SelectValueFromDropdown("#Sections_0_Questions_TUMOUR5_Answers_Select", personDetails.DurationSinceTumorTreatment);
                                browser.ClickElementWithCss("#nextPageButton");
                                manualResetEvent.WaitOne(Timeout.Infinite);
                            }
                        }
                    }
                }
            }
        }
    }
}
