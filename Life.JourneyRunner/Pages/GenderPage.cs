using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class GenderPage
    {
        public enum Gender
        {
            Male,
            Female
        }

        private const string male = ".ValidAnswers_male";
        private const string female = ".ValidAnswers_female";

        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            var selectedItem = personDetails.Gender == Gender.Female ? female : male;

            browser.ClickElementWithCss(selectedItem);
            browser.ClickElementWithCss("#nextPageButton");

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
