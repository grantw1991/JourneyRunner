using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class DateOfBirthPage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#Answer", personDetails.DateOfBirth.ToString("dd/MM/yyyy"));
            browser.ClickElementWithCss("#nextPageButton");

            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
