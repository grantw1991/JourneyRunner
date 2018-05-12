using System;
using System.Collections.Generic;
using Life.JourneyRunner.Pages.BGL;
using Life.JourneyRunner.Pages.MSM;
using NUnit.Framework;

namespace Life.JourneyRunner.Models.MSM
{
    public class PersonDetails
    {
        public enum TitleType
        {
            Mr,
            Mrs,
            Ms,
            Miss,
            Dr
        }

        public enum MaritalType
        {
            Married,
            Single,
            CommonLaw,
            Cohabiting,
            Divorced,
            Separated,
            Widowed
        }

        public TitleType Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string DoorNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }
        public GenderPage.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public string PhoneNumber { get; set; }
        public int DressSize { get; set; }
        public int InchesInWaistSize { get; set; }
        public MaritalType MaritalStatus { get; set; }
        public Size Size { get; set; }
        public SmokerDetails SmokerDetails { get; set; }
        public List<string> Conditions { get; set; }
        public List<string> LifestyleJobs { get; set; }
        public bool RidesAMotorbike { get; set; } 
        public bool HasBeenBannedFromDrivingInLast5Years { get; set; }
        public string TravelledOutsideOfUk { get; set; }
        public bool HasLifePlanWithAnotherInsuranceCompany { get; set; }
        public bool HasCriticalIllnessPlanWithAnotherInsuranceCompany { get; set; }
        public NarcoticsDetails NarcoticsDetails { get; set; }
        public string JobTitle { get; set; }
        public HealthDetails HealthDetails { get; set; }
    }
}
