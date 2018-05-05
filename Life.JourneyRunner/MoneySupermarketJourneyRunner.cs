using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.MSM;
using Life.JourneyRunner.Pages.MSM;

namespace Life.JourneyRunner
{
    public class MoneySupermarketJourneyRunner : IJourneyRunner
    {
        private readonly IBrowser _browser;
        private readonly ManualResetEvent _pauseEvent;
        private readonly Journey _journey;

        public MoneySupermarketJourneyRunner(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            _browser = browser;
            _pauseEvent = pauseEvent;
            _journey = journey;
        }

        public void RunApplication()
        {
            new EnquiryPage().Run(_browser, _pauseEvent, _journey);
        }
    }
}
