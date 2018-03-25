namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageNarcoticsViewModel : PageBaseViewModel
    {
        private bool _hasUsedTabacco;
        private bool _hasUsedDrugs;
        private bool _drinksAlcoholRegularly;

        public override int PageId => 7;
        public override string Name => $"{ActivePerson.PersonNumber}) Narcotics";

        public override string Title => $"Person {ActivePerson.PersonNumber} Narcotics";

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
                ActivePerson.IsSmoker = HasUsedTabacco;
            }
        }

        public bool HasUsedDrugs
        {
            get => _hasUsedDrugs;
            set
            {
                SetProperty(ref _hasUsedDrugs, value);
                ActivePerson.HasUsedRecreationalInLast5Years = HasUsedDrugs;
            }
        }

        public bool DrinksAlcoholRegularly
        {
            get => _drinksAlcoholRegularly;
            set
            {
                SetProperty(ref _drinksAlcoholRegularly, value);
                ActivePerson.IsRegularDrinker = DrinksAlcoholRegularly;
            }
        }

        public QuestionPageNarcoticsViewModel()
        {
            HasUsedTabacco = ActivePerson.IsSmoker;
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
