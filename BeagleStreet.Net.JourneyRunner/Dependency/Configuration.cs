using System.Collections.Generic;
using BeagleStreet.Net.JourneyRunner.Dependency.Modules;
using Ninject;
using Ninject.Modules;

namespace BeagleStreet.Net.JourneyRunner.Dependency
{
    public class Configuration : NinjectModule
    {
        public override void Load()
        {
            IKernel kernel = new StandardKernel();

            kernel.Load(new List<INinjectModule>
            {
                new JourneyModule()
            });
        }
    }
}