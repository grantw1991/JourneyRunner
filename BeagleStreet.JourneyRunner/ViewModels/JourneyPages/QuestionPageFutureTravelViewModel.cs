namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageFutureTravelViewModel : PageBaseViewModel
    {
        public override string Name => "Future Travel";
        public override string Title => "Future Travel";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage { get; }
    }
}
