using Ninject.Modules;

namespace BeagleStreet.Net.JourneyRunner.Dependency.Modules
{
    public class JourneyModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IJourneyRunner>().To<JourneyRunner>();
        }
    }
}
