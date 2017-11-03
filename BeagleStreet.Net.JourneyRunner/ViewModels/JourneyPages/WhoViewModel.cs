using BeagleStreet.Net.JourneyRunner.Pages;

namespace BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages
{
    public class WhoViewModel : PageBaseViewModel
    {
        private WhoPage.SingleOrJoint _handleIsSingleOrJoint;

        public override string Name => "Who";

        public string SingleOrJoint { get; set; }

        public WhoPage.SingleOrJoint HandleSingleOrJoint
        {
            get => _handleIsSingleOrJoint;
            set
            {
                SetProperty(ref _handleIsSingleOrJoint, value);
                Journey.SingleOrJoint = HandleSingleOrJoint;
            }
        }
    }
}
