using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class ReviewPage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
