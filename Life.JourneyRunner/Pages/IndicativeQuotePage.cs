using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class IndicativeQuotePage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            browser.ClickElementWithCss("#nextPageButton");

        }
    }
}
