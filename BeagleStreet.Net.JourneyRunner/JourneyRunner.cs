using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.Pages;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner
{
    public class JourneyRunner
    {
        public static void RunApplication(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            new WhoPage().Run(browser, pauseEvent, journey);

            HandleUserDetails(browser, pauseEvent, journey.Person1Details);

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                HandleUserDetails(browser, pauseEvent, journey.Person2Details);
            }

            new TermTypePage().Run(browser, pauseEvent, journey);
            new CoverAmountPage().Run(browser, pauseEvent, journey);
            new CoverTermPage().Run(browser, pauseEvent, journey);
            new CriticalIllnessPage().Run(browser, pauseEvent, journey);
            new YourDetailsPage().Run(browser, pauseEvent, journey);
            new IndicativeQuotePage().Run(browser, pauseEvent, journey);
            new PasswordPage().Run(browser, pauseEvent, journey);
            new QuestionPage1().Run(browser, pauseEvent, journey);

            HandleUserQuestionSets(browser, pauseEvent, journey.Person1Details);

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                HandleUserQuestionSets(browser, pauseEvent, journey.Person2Details);
            }

            new ReviewPage().Run(browser, pauseEvent, journey);
        }

        private static void HandleUserDetails(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            new GenderPage().Run(browser, pauseEvent, personDetails);
            new DateOfBirthPage().Run(browser, pauseEvent, personDetails);
            new SmokerPage().Run(browser, pauseEvent, personDetails);
        }

        private static void HandleUserQuestionSets(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails details)
        {
            new YourSizePage().Run(browser, pauseEvent, details);
            new NarcoticsPage().Run(browser, pauseEvent, details);
            new YourLocationPage().Run(browser, pauseEvent, details);
            new YourHealthQuestion1Page().Run(browser, pauseEvent, details);
            new YourHealthQuestion2Page().Run(browser, pauseEvent, details);
            new YourHealthQuestion3Page().Run(browser, pauseEvent, details);
            new YourHealthQuestion4Page().Run(browser, pauseEvent, details);
            new YourHealthQuestion5Page().Run(browser, pauseEvent, details);
            new YourHealthQuestion6Page().Run(browser, pauseEvent, details);
            new YourFamilyQuestionPage().Run(browser, pauseEvent, details);
            new YourJobQuestionPage().Run(browser, pauseEvent, details);
        }
    }
}
