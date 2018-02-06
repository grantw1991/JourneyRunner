using System;
using System.Collections.Generic;
using System.Linq;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class YourDetailsViewModel : PageBaseViewModel
    {
        private string _firstName;
        private string _addressLine1;
        private string _postcode;
        private string _phoneNumber;
        private string _password;
        private string _surname;
        private string _emailAddress;
        private List<string> _titles;
        private string _selectedTitle;
        private bool _isEmailChecked;
        private bool _isPhoneChecked;
        private bool _isLetterChecked;

        public override int PageId => 4;
        public override string Name => $"{ActivePerson.PersonNumber}) Contact Details";

        public override string Title => $"Person {ActivePerson.PersonNumber} Contact Details";

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPage1ViewModel();
        public override bool HasStateChanged { get; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
                ActivePerson.FirstName = FirstName;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                SetProperty(ref _surname, value);
                ActivePerson.Surname = Surname;
            }
        }

        public string SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                SetProperty(ref _selectedTitle, value);
                ActivePerson.Title = (PersonDetails.TitleType)Enum.Parse(typeof(PersonDetails.TitleType), SelectedTitle);
            }
        }

        public List<string> Titles
        {
            get => _titles;
            set => SetProperty(ref _titles, value);
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                SetProperty(ref _emailAddress, value);
                ActivePerson.EmailAddress = EmailAddress;
            }
        }

        public string AddressLine1
        {
            get => _addressLine1;
            set
            {
                SetProperty(ref _addressLine1, value);
                ActivePerson.DoorNumber = AddressLine1;
            }
        }

        public string Postcode
        {
            get => _postcode;
            set
            {
                SetProperty(ref _postcode, value);
                ActivePerson.Postcode = Postcode;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                SetProperty(ref _phoneNumber, value);
                ActivePerson.PhoneNumber = PhoneNumber;
            }
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsEmailChecked
        {
            get => _isEmailChecked;
            set => SetProperty(ref _isEmailChecked, value);
        }

        public bool IsPhoneChecked
        {
            get => _isPhoneChecked;
            set => SetProperty(ref _isPhoneChecked, value);
        }

        public bool IsLetterChecked
        {
            get => _isLetterChecked;
            set => SetProperty(ref _isLetterChecked, value);
        }

        public YourDetailsViewModel()
        {
            Titles = Journey.Person1Details.Gender == GenderPage.Gender.Male ? new List<string> { "Mr", "Dr" } : new List<string> { "Mrs", "Miss", "Ms", "Dr" };

            SelectedTitle = Titles.First();
        }
    }
}
