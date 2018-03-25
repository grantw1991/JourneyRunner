using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
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
