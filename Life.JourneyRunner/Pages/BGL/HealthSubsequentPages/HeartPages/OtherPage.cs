using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL.HealthSubsequentPages.HeartPages
{
    public class OtherPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss(".selectize-control");
            browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(5000));
            browser.FindElements(".selectize-dropdown-content div").ToList()[4].Click();
            browser.ClickElementWithCss("#Lv2-answer");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
