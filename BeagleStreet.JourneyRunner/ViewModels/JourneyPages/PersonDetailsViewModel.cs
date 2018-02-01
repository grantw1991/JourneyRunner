﻿using System;
using System.Linq;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class PersonDetailsViewModel : PageBaseViewModel
    { 
        private GenderPage.Gender _handleMaleOrFemale;
        private DateTime _selectedDateOfBirth;
        private bool _smokerStatus;

        public override int PageId => 2;
        public override string Name => "Person Details";
        public override string Title => "Person Details";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => HandleNextPage();

        public override bool HasStateChanged { get; }

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
        }

        private PageBaseViewModel HandleNextPage()
        {
            if (Journey.SingleOrJoint == WhoPage.SingleOrJoint.Single || PageCollection.Any(c => c.PageId == PageId))
            {
                return new TermDetailsViewModel();
            }

            return new PersonDetailsViewModel();
        }
    }
}
