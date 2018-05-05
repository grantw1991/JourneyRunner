using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class IndicativeQuotePage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            browser.ClickElementWithCss("#nextPageButton");

        }
    }
}
