namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageFutureTravelViewModel : PageBaseViewModel
    {
        public override int PageId => 10;
        public override string Name => "Future Travel";
        public override string Title => "Future Travel";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage { get; }
        public override bool HasStateChanged { get; }
    }
}
