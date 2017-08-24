using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
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
