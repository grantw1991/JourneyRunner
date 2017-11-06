﻿using BeagleStreet.Net.JourneyRunner.Pages;

namespace BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages
{
    public class WhoViewModel : PageBaseViewModel
    {
        private WhoPage.SingleOrJoint _handleIsSingleOrJoint;

        public override string Name => "Who";
        public override bool IsValid => true;
        public override string Title => "Person Details";
        public override PageBaseViewModel NextPage => new PersonDetailsViewModel();
        
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
