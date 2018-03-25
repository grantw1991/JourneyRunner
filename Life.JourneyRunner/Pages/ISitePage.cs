using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    interface ISitePage
    {
        void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey);
    }
}
