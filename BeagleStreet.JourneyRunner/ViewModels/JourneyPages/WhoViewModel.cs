﻿using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class WhoViewModel : PageBaseViewModel
    {
        private WhoPage.SingleOrJoint _handleIsSingleOrJoint;

        public override int PageId => 1;
        public override string Name
        {
            get => "Who";
            set { }
        }

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => false;
        public override string Title
        {
            get => "Person Details";
            set { }
        }

        public override PageBaseViewModel NextPage => new PersonDetailsViewModel();
        public override bool HasStateChanged { get; }

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
