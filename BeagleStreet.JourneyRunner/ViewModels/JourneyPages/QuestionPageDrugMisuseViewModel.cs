using System.Collections.ObjectModel;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageDrugMisuseViewModel : PageBaseViewModel
    {
        private ObservableCollection<string> _drugs;

        public override string Name => "Drugs";
        public override string Title => "Drug Misuse";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => HandleNextPage();

        public ObservableCollection<string> Drugs
        {
            get => _drugs;
            set
            {
                SetProperty(ref _drugs, value);
                //Journey.Person1Details
            }
        }

        public QuestionPageDrugMisuseViewModel()
        {
            Drugs = new ObservableCollection<string>();
        }

        private PageBaseViewModel HandleNextPage()
        {
            if (Journey.Person1Details.IsRegularDrinker)
            {
                return new QuestionPageAlcoholViewModel();
            }

            return new QuestionPageFutureTravelViewModel();
        }
    }
}
