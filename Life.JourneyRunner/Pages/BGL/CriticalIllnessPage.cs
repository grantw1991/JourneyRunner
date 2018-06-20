using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class CriticalIllnessPage : ISitePage
    {
        private const string IncludeCriticalIllnessButton = ".ValidAnswers_yes";
        private const string DoNotIncludeCriticalIllnessButton = ".ValidAnswers_no";
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            var selectedItem = journey.RequiresCriticalIllness ? IncludeCriticalIllnessButton : DoNotIncludeCriticalIllnessButton;

            browser.ClickElementWithCss(selectedItem);

            if (journey.RequiresCriticalIllness)
            {
                var criticalIllnessBox = browser.FindElement("#CriticalIllnessAmount");
                criticalIllnessBox.Clear();
                criticalIllnessBox.SendKeys(journey.CriticalIllnessAmount.ToString());
            }

            browser.ClickElementWithCss(NextButtonId);
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
