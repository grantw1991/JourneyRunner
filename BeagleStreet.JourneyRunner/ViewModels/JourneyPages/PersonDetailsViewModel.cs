using System;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class PersonDetailsViewModel : PageBaseViewModel
    { 
        private GenderPage.Gender _handleMaleOrFemale;
        private DateTime _selectedDateOfBirth;
        private bool _smokerStatus;

        public override string Name => "Person Details";
        public override string Title => "Person Details";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage { get; }
        
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

        public PersonDetailsViewModel()
        {
            SelectedDateOfBirth = DateTime.Now.AddYears(-30);

            if (Journey.SingleOrJoint == WhoPage.SingleOrJoint.Single)
            {
                NextPage = new TermDetailsViewModel();
            }
            else
            {
                NextPage = new PersonDetails2ViewModel();
            }
        }
    }
}
