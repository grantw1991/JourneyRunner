using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class PasswordPage : ISitePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            browser.EnterTextIntoElement("#Password", "P@55w0rd");
            browser.EnterTextIntoElement("#PasswordConfirmation", "P@55w0rd");

            browser.ClickElementWithCss("#nextPageButton");
        }
    }
}
