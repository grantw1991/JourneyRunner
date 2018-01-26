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

        public override string Name => "Contact Details";
        public override string Title => "Contact Details";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => new QuestionPage1ViewModel();

        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
                Journey.Person1Details.FirstName = FirstName;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                SetProperty(ref _surname, value);
                Journey.Person1Details.Surname = Surname;
            }
        }

        public string SelectedTitle
        {
            get => _selectedTitle;
            set
            {
                SetProperty(ref _selectedTitle, value);
                Journey.Person1Details.Title = (PersonDetails.TitleType)Enum.Parse(typeof(PersonDetails.TitleType), SelectedTitle);
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
                Journey.Person1Details.EmailAddress = EmailAddress;
            }
        }

        public string AddressLine1
        {
            get => _addressLine1;
            set
            {
                SetProperty(ref _addressLine1, value);
                Journey.Person1Details.DoorNumber = AddressLine1;
            }
        }

        public string Postcode
        {
            get => _postcode;
            set
            {
                SetProperty(ref _postcode, value);
                Journey.Person1Details.Postcode = Postcode;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                SetProperty(ref _phoneNumber, value);
                Journey.Person1Details.PhoneNumber = PhoneNumber;
            }
        }

        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public bool IsEmailChecked
        {
            get => _isEmailChecked;
            set { SetProperty(ref _isEmailChecked, value); }
        }

        public bool IsPhoneChecked
        {
            get => _isPhoneChecked;
            set { SetProperty(ref _isPhoneChecked, value); }
        }

        public bool IsLetterChecked
        {
            get => _isLetterChecked;
            set { SetProperty(ref _isLetterChecked, value); }
        }

        public YourDetailsViewModel()
        {
            Titles = Journey.Person1Details.Gender == GenderPage.Gender.Male ? new List<string> { "Mr", "Dr" } : new List<string> { "Mrs", "Miss", "Ms", "Dr" };

            SelectedTitle = Titles.First();
        }
    }
}
