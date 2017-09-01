﻿using System.Threading;
using BeagleStreet.Net.JourneyRunner.Extensions;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class QuestionPage1
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Question_LBQ2_A1_{personDetails.WillCoverValueExceed750k.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ3_A1_{personDetails.IsPermanentUKResident.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ4_A1_{personDetails.IsAwaitingAnyMedicalTest.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ5_A1_{personDetails.IsDueToUndergoMedicalInvestigation.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ7_A1_{personDetails.AnySymptomsInLast3Months.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
