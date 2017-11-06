using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.WpfHelpers;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class JourneyBaseViewModel : BindableBase
    {
        public static Journey Journey { get; set; }
    }
}
