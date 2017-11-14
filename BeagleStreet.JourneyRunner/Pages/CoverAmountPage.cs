﻿using System.Threading;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages
{
    public class CoverAmountPage : ISitePage
    {
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.ClickElementWithCss(".cover-amount__item");
            browser.ClickElementWithCss(NextButtonId);

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}