using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class SmokerPage
    {
        private const string IsSmokerButton = ".ValidAnswers_yes";
        private const string NotSmokerButton = ".ValidAnswers_no";
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var selectedItem = personDetails.IsSmoker ? IsSmokerButton : NotSmokerButton;

            browser.ClickElementWithCss(selectedItem);;
            browser.ClickElementWithCss(NextButtonId);

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
