using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageFutureTravelViewModel : PageBaseViewModel
    {
        private bool _moreThanThreeMonthsInAfrica;
        private bool _moreThanThreeMonthsOutsideUK;
        private bool _userKnowsWhichCountries;
        private ObservableCollection<string> _countries;
        private string _countriesText;

        public override int PageId => 10;
        public override string Name => $"{ActivePerson.PersonNumber}) Future Travel";

        public override string Title => $"Person {ActivePerson.PersonNumber} Future Travel";

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;

        public override PageBaseViewModel NextPage
        {
            get
            {
                PopulateCountriesList();
                return new QuestionPageHealthViewModel();
            }
        } 

        public override bool HasStateChanged { get; }

        public bool MoreThanThreeMonthsInAfrica
        {
            get => _moreThanThreeMonthsInAfrica;
            set => SetProperty(ref _moreThanThreeMonthsInAfrica, value);
        }

        public bool MoreThanThreeMonthsOutsideUK
        {
            get => _moreThanThreeMonthsOutsideUK;
            set => SetProperty(ref _moreThanThreeMonthsOutsideUK, value);
        }

        public bool UserKnowsWhichCountries
        {
            get => _userKnowsWhichCountries;
            set => SetProperty(ref _userKnowsWhichCountries, value);
        }

        public string CountriesText
        {
            get => _countriesText;
            set => SetProperty(ref _countriesText, value);
        }

        public ObservableCollection<string> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        private void PopulateCountriesList()
        {
            Countries = new ObservableCollection<string>();

            if (string.IsNullOrEmpty(CountriesText))
                return;

            foreach (var country in CountriesText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList())
            {
                Countries.Add(country);
            }
        }
    }
}
