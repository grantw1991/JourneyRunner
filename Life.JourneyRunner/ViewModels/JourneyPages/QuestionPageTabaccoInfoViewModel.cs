namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageTabaccoInfoViewModel : PageBaseViewModel
    {
        private bool _isNicotineReplacement;

        public override int PageId => 8;
        public override string Name => $"{ActivePerson.PersonNumber}) Smoker Info";

        public override string Title => $"Person {ActivePerson.PersonNumber} Smoker Info";

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
                ActivePerson.SmokerDetails.IsNicotineOnly = IsNicotineReplacement;
            }
        }

        private PageBaseViewModel HandleNextPage()
        {
            if (ActivePerson.HasUsedRecreationalInLast5Years)
            {
                return new QuestionPageDrugMisuseViewModel();
            }

            if (ActivePerson.IsRegularDrinker)
            {
                return new QuestionPageAlcoholViewModel();
            }

            return new QuestionPageFutureTravelViewModel();
        }
    }
}
