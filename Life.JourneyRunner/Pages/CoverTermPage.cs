using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class CoverTermPage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.SelectValueFromDropdown("#CoverTermList", journey.CoverDuration.ToString());
            browser.ClickElementWithCss("#nextPageButton");

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
