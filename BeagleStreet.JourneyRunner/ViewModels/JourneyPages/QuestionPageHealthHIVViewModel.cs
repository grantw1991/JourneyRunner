namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealthHIVViewModel : PageBaseViewModel
    {
        public override int PageId { get; }
        public override string Name { get; }
        public override string Title { get; }
        public override bool IsValid { get; }
        public override bool PageRequiresJointInput { get; }
        public override PageBaseViewModel NextPage { get; }
        public override bool HasStateChanged { get; }
    }
}
