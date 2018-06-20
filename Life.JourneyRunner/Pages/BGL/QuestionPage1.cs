using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class QuestionPage1
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.ClickElementWithCss($"[for='Question_LBQ2_A1_{journey.Person1Details.WillCoverValueExceed750k.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ3_A1_{journey.Person1Details.IsPermanentUKResident.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ4_A1_{journey.Person1Details.IsAwaitingAnyMedicalTest.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ5_A1_{journey.Person1Details.IsDueToUndergoMedicalInvestigation.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Question_LBQ7_A1_{journey.Person1Details.AnySymptomsInLast3Months.ToYesNo()}']");

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                browser.ClickElementWithCss($"[for='Question_LBQ2_A2_{journey.Person2Details.WillCoverValueExceed750k.ToYesNo()}']");
                browser.ClickElementWithCss($"[for='Question_LBQ3_A2_{journey.Person2Details.IsPermanentUKResident.ToYesNo()}']");
                browser.ClickElementWithCss($"[for='Question_LBQ4_A2_{journey.Person2Details.IsAwaitingAnyMedicalTest.ToYesNo()}']");
                browser.ClickElementWithCss($"[for='Question_LBQ5_A2_{journey.Person2Details.IsDueToUndergoMedicalInvestigation.ToYesNo()}']");
                browser.ClickElementWithCss($"[for='Question_LBQ7_A2_{journey.Person2Details.AnySymptomsInLast3Months.ToYesNo()}']");
            }

            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
