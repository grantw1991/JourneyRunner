namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageTabaccoInfoViewModel : PageBaseViewModel
    {
        private bool _isNicotineReplacement;

        public override int PageId => 8;
        public override string Name => "Smoker Info";
        public override string Title => "Smoker Info";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => HandleNextPage();
        public override bool HasStateChanged { get; }

        public bool IsNicotineReplacement
        {
            get => _isNicotineReplacement;
            set
            {
                SetProperty(ref _isNicotineReplacement, value);
                Journey.Person1Details.SmokerDetails.IsNicotineOnly = IsNicotineReplacement;
            }
        }

        private PageBaseViewModel HandleNextPage()
        {
            if (Journey.Person1Details.HasUsedRecreationalInLast5Years)
            {
                return new QuestionPageDrugMisuseViewModel();
            }

            if (Journey.Person1Details.IsRegularDrinker)
            {
                return new QuestionPageAlcoholViewModel();
            }

            return new QuestionPageFutureTravelViewModel();
        }
    }
}
