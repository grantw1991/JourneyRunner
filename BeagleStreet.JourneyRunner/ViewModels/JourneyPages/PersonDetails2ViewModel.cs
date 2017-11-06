using System;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class PersonDetails2ViewModel : PageBaseViewModel
    {
        private GenderPage.Gender _handleMaleOrFemale;
        private DateTime _selectedDateOfBirth;
        private bool _smokerStatus;

        public override string Name => "Person Details 2";
        public override string Title => "Second Person Details";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => new TermTypeViewModel();

        public GenderPage.Gender HandleMaleOrFemale
        {
            get => _handleMaleOrFemale;
            set
            {
                SetProperty(ref _handleMaleOrFemale, value);
                Journey.Person1Details.Gender = HandleMaleOrFemale;
            }
        }

        public bool SmokerStatus
        {
            get => _smokerStatus;
            set
            {
                SetProperty(ref _smokerStatus, value);
                Journey.Person1Details.IsSmoker = SmokerStatus;
            }
        }

        public DateTime SelectedDateOfBirth
        {
            get => _selectedDateOfBirth;
            set
            {
                SetProperty(ref _selectedDateOfBirth, value);
                Journey.Person1Details.DateOfBirth = SelectedDateOfBirth;
            }
        }

        public PersonDetails2ViewModel()
        {
            SelectedDateOfBirth = DateTime.Now.AddYears(-30);
        }
    }
}
