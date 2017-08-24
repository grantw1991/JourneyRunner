using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    interface ISitePage
    {
        void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey);
    }
}
