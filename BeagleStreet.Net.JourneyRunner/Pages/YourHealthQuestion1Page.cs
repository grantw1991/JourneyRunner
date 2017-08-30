using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion1Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC10_Answers_{Utilities.ReturnFormattedDecision(personDetails.IsHIVPositive)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC11_Answers_{Utilities.ReturnFormattedDecision(personDetails.IsDiabetic)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC12_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasHeartCondition)}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC13_Answers_{Utilities.ReturnFormattedDecision(personDetails.HasStroke)}']");
            
            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);

            if (!personDetails.IsHIVPositive && !personDetails.HasHeartCondition && !personDetails.HasStroke)
                return;

            if (personDetails.IsHIVPositive)
            {
                browser.SelectValueFromDropdown("#Sections_0_Questions_HIV_Answers_Select", personDetails.HIVCondition.ToString().ToLower());
            }

            if (personDetails.HasHeartCondition)
            {
                var details = personDetails.HeartConditionDetails;

                details.HeartConditions.ToList().ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeLv2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(details.GetValueFromEnum(condition))).Click();
                });
            }

            if (personDetails.HasStroke)
            {
                var details = personDetails.StrokeConditionDetails;

                details.StrokeConditions.ToList().ForEach(condition =>
                {
                    browser.ClickElementWithCss("#questionCodeSSH_2 .selectize-control");
                    browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
                    browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(details.GetValueFromEnum(condition))).Click();
                });
            }

            browser.ClickElementWithCss("#INC13-answer");
            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
