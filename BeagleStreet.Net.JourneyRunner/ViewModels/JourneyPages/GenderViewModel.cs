using BeagleStreet.Net.JourneyRunner.Models;

namespace BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages
{
    public class GenderViewModel : PageBaseViewModel
    {
        public override string Name => "Gender";

        public GenderViewModel()
        {
            Journey.Description = "snakes on a plane";
        }
    }
}
