﻿using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourHealthQuestion5Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC29_Answers_{personDetails.HasEyeSymptoms.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC30_Answers_{personDetails.HadLumpOrGrowth.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC31_Answers_{personDetails.HadColitis.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC32_Answers_{personDetails.HadBloodCondition.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
