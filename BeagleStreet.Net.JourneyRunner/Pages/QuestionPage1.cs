using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class QuestionPage1 : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.ClickElementWithCss("[for='Question_LBQ2_A1_no']");
            browser.ClickElementWithCss("[for='Question_LBQ3_A1_yes']");
            browser.ClickElementWithCss("[for='Question_LBQ4_A1_no']");
            browser.ClickElementWithCss("[for='Question_LBQ5_A1_no']");
            browser.ClickElementWithCss("[for='Question_LBQ7_A1_no']");

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                browser.ClickElementWithCss("[for='Question_LBQ2_A2_no']");
                browser.ClickElementWithCss("[for='Question_LBQ3_A2_yes']");
                browser.ClickElementWithCss("[for='Question_LBQ4_A2_no']");
                browser.ClickElementWithCss("[for='Question_LBQ5_A2_no']");
                browser.ClickElementWithCss("[for='Question_LBQ7_A2_no']");
            }

            browser.ClickElementWithCss("#nextPageButton");

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
