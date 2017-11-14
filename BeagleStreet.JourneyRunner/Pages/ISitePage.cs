﻿using System.Threading;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.JourneyRunner.Pages
{
    interface ISitePage
    {
        void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey);
    }
}