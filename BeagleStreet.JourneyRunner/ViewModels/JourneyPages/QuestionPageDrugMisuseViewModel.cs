using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageDrugMisuseViewModel : PageBaseViewModel
    {
        private ObservableCollection<string> _drugs;
        private string _drugsText;

        public override int PageId => 8;
        public override string Name => $"{ActivePerson.PersonNumber}) Drugs";

        public override string Title => $"Person {ActivePerson.PersonNumber} Drug Misuse";

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override bool HasStateChanged => false;

        public override PageBaseViewModel NextPage => HandleNextPage();

        public string DrugsText
        {
            get => _drugsText;
            set => SetProperty(ref _drugsText, value);
        }

        public ObservableCollection<string> Drugs
        {
            get => _drugs;
            set => SetProperty(ref _drugs, value);
        }

        public QuestionPageDrugMisuseViewModel()
        {
            Drugs = new ObservableCollection<string>();
        }

        private PageBaseViewModel HandleNextPage()
        {
            PopulateDrugsList();

            if (Journey.Person1Details.IsRegularDrinker)
            {
                return new QuestionPageAlcoholViewModel();
            }

            return new QuestionPageFutureTravelViewModel();
        }

        private void PopulateDrugsList()
        {
            Drugs = new ObservableCollection<string>();

            if (string.IsNullOrEmpty(DrugsText))
                return;

            foreach (var drug in DrugsText.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList())
            {
                Drugs.Add(drug);
            }
        }
    }
}
