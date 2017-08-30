using System.Threading;
using System.Windows;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.Pages;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner
{
    public class JourneyRunner : IJourneyRunner
    {
        private readonly IBrowser _browser;
        private readonly ManualResetEvent _pauseEvent;
        private readonly Journey _journey;

        public JourneyRunner(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            _browser = browser;
            _pauseEvent = pauseEvent;
            _journey = journey;
        }

        public void RunApplication()
        {
            try
            {
                new WhoPage().Run(_browser, _pauseEvent, _journey);
                HandleUserDetails();
                new TermTypePage().Run(_browser, _pauseEvent, _journey);
                new CoverAmountPage().Run(_browser, _pauseEvent, _journey);
                new CoverTermPage().Run(_browser, _pauseEvent, _journey);
                new CriticalIllnessPage().Run(_browser, _pauseEvent, _journey);
                new YourDetailsPage().Run(_browser, _pauseEvent, _journey);
                new IndicativeQuotePage().Run(_browser, _pauseEvent, _journey);
                new PasswordPage().Run(_browser, _pauseEvent, _journey);
                new QuestionPage1().Run(_browser, _pauseEvent, _journey);
                HandleUserQuestionSets();
                new ReviewPage().Run(_browser, _pauseEvent, _journey);
            }
            catch (ElementNotFoundException e)
            {
                MessageBox.Show(e.Message, $"Element not found on page {_browser.PageTitle}", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void HandleUserDetails()
        {
            ProcessUserDetails(_journey.Person1Details);

            if (_journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                ProcessUserDetails(_journey.Person2Details);
            }
        }

        private void ProcessUserDetails(PersonDetails personDetails)
        {
            new GenderPage().Run(_browser, _pauseEvent, personDetails);
            new DateOfBirthPage().Run(_browser, _pauseEvent, personDetails);
            new SmokerPage().Run(_browser, _pauseEvent, personDetails);
        }

        private void HandleUserQuestionSets()
        {
            ProcessUserQuestionSets(_journey.Person1Details);

            if (_journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                ProcessUserQuestionSets(_journey.Person2Details);
            }
        }

        private void ProcessUserQuestionSets(PersonDetails personDetails)
        {
            new YourSizePage().Run(_browser, _pauseEvent, personDetails);
            new NarcoticsPage().Run(_browser, _pauseEvent, personDetails);
            new YourLocationPage().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion1Page().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion2Page().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion3Page().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion4Page().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion5Page().Run(_browser, _pauseEvent, personDetails);
            new YourHealthQuestion6Page().Run(_browser, _pauseEvent, personDetails);
            new YourFamilyQuestionPage().Run(_browser, _pauseEvent, personDetails);
            new YourJobQuestionPage().Run(_browser, _pauseEvent, personDetails);
        }
    }
}
