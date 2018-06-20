using System.Threading;
using BeagleStreet.Test.Support;

namespace Life.JourneyRunner.Pages.MSM
{
    public class AdditionalQuestionsPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent)
        {
            browser.ClickElementWithCss("[for='0_OccGeneral_WhichInd_9_NONE_OF']");
            Thread.Sleep(500);
            browser.ClickElementWithCss("#Occupation_0_0_Done");
        }
    }
}
