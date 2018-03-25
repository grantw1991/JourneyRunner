using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class PasswordPage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.EnterTextIntoElement("#Password", "P@55w0rd");
            browser.EnterTextIntoElement("#PasswordConfirmation", "P@55w0rd");

            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
