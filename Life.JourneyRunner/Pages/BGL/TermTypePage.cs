using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class TermTypePage : ISitePage
    {
        public enum TermType
        {
            Level,
            Decreasing
        }

        private const string DecreasingTermButton = ".ValidAnswers_decreasing";
        private const string LevelTermButton = ".ValidAnswers_level";
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            var selectedItem = journey.TermType == TermType.Decreasing ? DecreasingTermButton : LevelTermButton;
            browser.ClickElementWithCss(selectedItem);
            browser.ClickElementWithCss(NextButtonId);

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
