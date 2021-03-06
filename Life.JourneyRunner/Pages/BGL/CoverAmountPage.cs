﻿using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class CoverAmountPage : ISitePage
    {
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.EnterTextIntoElement("#AssuredAmount", journey.CoverAmount.ToString());
            browser.ClickElementWithCss(NextButtonId);

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
