using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class WhoPage : ISitePage
    {
        public enum SingleOrJoint
        {
            Single,
            Joint
        }

        private const string JustMeButton = ".ValidAnswers_just";
        private const string MeAndAPartnerButton = ".ValidAnswers_me";
        private const string NextButtonId = "#nextPageButton";

        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            var selectedItem = journey.SingleOrJoint == SingleOrJoint.Single ? JustMeButton : MeAndAPartnerButton;
            
            browser.ClickElementWithCss(selectedItem);
            browser.ClickElementWithCss(NextButtonId);
            
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
