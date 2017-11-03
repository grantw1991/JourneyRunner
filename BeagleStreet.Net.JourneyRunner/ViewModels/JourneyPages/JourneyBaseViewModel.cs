using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.WpfHelpers;

namespace BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class JourneyBaseViewModel : BindableBase
    {
        public static Journey Journey { get; set; }
    }
}
