﻿using System.Threading;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages.HealthSubsequentPages.StrokePages
{
    public class TransientIschaemicAttackPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#Sections_0__Questions_0__Answer", personDetails.StrokeConditionDetails.TransientIschaemicAttackDetails.MonthsSinceFirstDiagnosed.ToString());
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}