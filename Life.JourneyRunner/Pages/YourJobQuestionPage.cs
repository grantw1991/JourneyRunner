using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class YourJobQuestionPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss("[for='Sections_0__Questions_0__Answers_none']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
