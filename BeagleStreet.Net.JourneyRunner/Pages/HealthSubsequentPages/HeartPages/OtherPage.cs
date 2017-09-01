using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
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
