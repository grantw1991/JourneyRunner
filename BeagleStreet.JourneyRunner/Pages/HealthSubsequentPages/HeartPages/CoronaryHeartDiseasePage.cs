using System.Threading;
using BeagleStreet.JourneyRunner.Extensions;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages.HealthSubsequentPages.HeartPages
{
    public class CoronaryHeartDiseasePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var coronaryArteryDisease = personDetails.HeartConditionDetails.CoronaryArteryDetails;
            browser.ClickElementWithCss($"[for='Sections_0_Questions_HRUKCAD1_Answers_{coronaryArteryDisease.HasAbnormalBloodSugar.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);

            if (!coronaryArteryDisease.HasAbnormalBloodSugar)
            {
                browser.EnterTextIntoElement("#Sections_0__Questions_1__Answer", coronaryArteryDisease.MonthsSinceFirstSymptom.ToString());
                browser.ClickElementWithCss("#nextPageButton");
                pauseEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
