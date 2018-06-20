using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class PasswordPage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent pauseEvent, Journey journey)
        {
            browser.EnterTextIntoElement("#Password", "P@55w0rd");

            if (browser.FindElement("#PasswordConfirmation") != null)
            {
                browser.EnterTextIntoElement("#PasswordConfirmation", "P@55w0rd");
            }

            browser.ClickElementWithCss("#nextPageButton");
            pauseEvent.WaitOne(Timeout.Infinite);
        }
    }
}
