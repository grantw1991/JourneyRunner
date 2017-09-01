﻿using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class HeartValveDisorderPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var heartDetails = personDetails.HeartConditionDetails.HeartValveDisorderDetails;
            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTV2_Answers_{heartDetails.HasBeenInvestigated.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!heartDetails.HasBeenInvestigated)
                return;

            browser.ClickElementWithCss($"[for='Sections_0_Questions_HEARTV3_Answers_{heartDetails.IsConnectedToAnotherCondition.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!heartDetails.IsConnectedToAnotherCondition)
                return;

            browser.SelectTextFromDropdown("#Sections_0_Questions_HEARTV4_Answers_Select", heartDetails.IsRelatedToOtherIllness.GetDescription());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
