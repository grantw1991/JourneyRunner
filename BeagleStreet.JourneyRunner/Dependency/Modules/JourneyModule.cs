using Ninject.Modules;

namespace BeagleStreet.JourneyRunner.Dependency.Modules
{
    public class JourneyModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IJourneyRunner>().To<JourneyRunner>();
        }
    }
}
