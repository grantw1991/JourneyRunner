﻿using System.Threading;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages
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