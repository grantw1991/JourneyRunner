using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
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
