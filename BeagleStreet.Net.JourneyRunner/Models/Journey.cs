using System;
using System.Threading;
using BeagleStreet.Net.JourneyRunner.Pages;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Models
{
    public class Journey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }

        public WhoPage.SingleOrJoint SingleOrJoint { get; set; }
        public TermTypePage.TermType TermType { get; set; }
        public int CoverAmount { get; set; }
        public int CoverDuration { get; set; }
        public bool RequiresCriticalIllness { get; set; }
        public int CriticalIllnessAmount { get; set; }
        public PersonDetails Person1Details { get; set; }
        public PersonDetails Person2Details { get; set; }

       public static Journey TestSingleApplication()
        {
            return new Journey
            {
                Name = "Single tester",
                Description = "Single application",
                CoverDuration = 10,
                SingleOrJoint = WhoPage.SingleOrJoint.Single,
                TermType = TermTypePage.TermType.Decreasing,
                CoverAmount = 100000,
                RequiresCriticalIllness = true,
                CriticalIllnessAmount = 10000,

                Person1Details = new PersonDetails
                {
                    DateOfBirth = new DateTime(1991, 11, 25),
                    Gender = GenderPage.Gender.Female,
                    IsSmoker = false,
                    DoorNumber = "3",
                    EmailAddress = $"grant{new Random().Next(9999999)}@egg.com",
                    FirstName = "Wright",
                    Postcode = "pe28gy",
                    Surname = "wright",
                    Title = PersonDetails.TitleType.Dr,
                    PhoneNumber = "01023456789",
                    Weight = new Weight
                    {
                        Stone = 10,
                        Pounds = 5
                    },
                    Height = new Height
                    {
                        Feet = 5,
                        Inches = 7
                    },
                    DressSize = 6,
                    HasUsedRecreationalInLast5Years = false,
                    IsRegularDrinker = false,
                }
            };
        }

        public static Journey TestJointApplication()
        {
            return new Journey
            {
                Name = "Joint Tester",
                Description = "Joint application",
                CoverDuration = 10,
                SingleOrJoint = WhoPage.SingleOrJoint.Joint,
                TermType = TermTypePage.TermType.Decreasing,
                CoverAmount = 100000,
                RequiresCriticalIllness = true,
                CriticalIllnessAmount = 10000,

                Person1Details = new PersonDetails
                {
                    DateOfBirth = new DateTime(1991, 11, 25),
                    Gender = GenderPage.Gender.Female,
                    IsSmoker = false,
                    DoorNumber = "3",
                    EmailAddress = $"grant{new Random().Next(9999999)}@egg.com",
                    FirstName = "Wright",
                    Postcode = "pe28gy",
                    Surname = "wright",
                    Title = PersonDetails.TitleType.Dr,
                    PhoneNumber = "01023456789",
                    Weight = new Weight
                    {
                        Stone = 10,
                        Pounds = 5
                    },
                    Height = new Height
                    {
                        Feet = 5,
                        Inches = 7
                    },
                    DressSize = 6,
                    HasUsedRecreationalInLast5Years = false,
                    IsRegularDrinker = false,
                },
                Person2Details = new PersonDetails
                {
                    DateOfBirth = new DateTime(1981, 04, 22),
                    Gender = GenderPage.Gender.Male,
                    IsSmoker = false,
                    DoorNumber = "3",
                    EmailAddress = $"pizza{new Random().Next(9999999)}@egg.com",
                    FirstName = "Wright",
                    Postcode = "pe28gy",
                    Surname = "wright",
                    Title = PersonDetails.TitleType.Dr,
                    PhoneNumber = "01023456789",
                    Weight = new Weight
                    {
                        Stone = 10,
                        Pounds = 5
                    },
                    Height = new Height
                    {
                        Feet = 5,
                        Inches = 7
                    },
                    DressSize = 6,
                    HasUsedRecreationalInLast5Years = false,
                    IsRegularDrinker = false,
                }
            };
        }
    }
}
