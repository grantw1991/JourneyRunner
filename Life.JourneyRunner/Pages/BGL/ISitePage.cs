using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    interface ISitePage
    {
        void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey);
    }
}
