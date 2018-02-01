namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageNarcoticsViewModel : PageBaseViewModel
    {
        private bool _hasUsedTabacco;
        private bool _hasUsedDrugs;
        private bool _drinksAlcoholRegularly;

        public override int PageId => 7;
        public override string Name => "Narcotics";
        public override string Title => "Narcotics";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => HandleNextPage();
        public override bool HasStateChanged { get; }

        public bool HasUsedTabacco
        {
            get => _hasUsedTabacco;
            set
            {
                SetProperty(ref _hasUsedTabacco, value);
                Journey.Person1Details.IsSmoker = HasUsedTabacco;
            }
        }

        public bool HasUsedDrugs
        {
            get => _hasUsedDrugs;
            set
            {
                SetProperty(ref _hasUsedDrugs, value);
                Journey.Person1Details.HasUsedRecreationalInLast5Years = HasUsedDrugs;
            }
        }

        public bool DrinksAlcoholRegularly
        {
            get => _drinksAlcoholRegularly;
            set
            {
                SetProperty(ref _drinksAlcoholRegularly, value);
                Journey.Person1Details.IsRegularDrinker = DrinksAlcoholRegularly;
            }
        }

        public QuestionPageNarcoticsViewModel()
        {
            HasUsedTabacco = Journey.Person1Details.IsSmoker;
        }

        private PageBaseViewModel HandleNextPage()
        {
            if (Journey.Person1Details.IsSmoker)
            {
                return new QuestionPageTabaccoInfoViewModel();
            }

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
