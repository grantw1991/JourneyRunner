using System;
using Life.JourneyRunner.Pages.BGL;
using Life.JourneyRunner.WpfHelpers;

namespace Life.JourneyRunner.Models.MSM
{
    public class Journey : BindableBase
    {
        private string _description;

        public string Name { get; set; }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public DateTime LastModified { get; set; }
        public string JourneyType { get; set; }
        public WhoPage.SingleOrJoint SingleOrJoint { get; set; }
        public TermTypePage.TermType TermType { get; set; }
        public int CoverAmount { get; set; }
        public int CoverDuration { get; set; }
        public bool RequiresCriticalIllness { get; set; }
        public int CriticalIllnessAmount { get; set; }
        public bool ContactViaEmail { get; set; }
        public bool ContactViaText { get; set; }
        public bool ContactViaPhone { get; set; }
        public PersonDetails Person1Details { get; set; }
        public PersonDetails Person2Details { get; set; }
        
        public static Journey CreateDefaultJourney()
        {
            var journey = new Journey
            {
                CoverAmount = 100000,
                CoverDuration = 25,
                RequiresCriticalIllness = true,
                SingleOrJoint = WhoPage.SingleOrJoint.Joint,
                Name = "Joint tester",
                ContactViaEmail = true,
                ContactViaPhone = true,
                ContactViaText = true,
                JourneyType = "MSM",
                Person1Details = new PersonDetails
                {
                    Title = PersonDetails.TitleType.Miss,
                    FirstName = "grant",
                    Surname = "wright",
                    Gender = GenderPage.Gender.Female,
                    DateOfBirth = new DateTime(1991, 11, 25),
                    IsSmoker = true,
                    HouseNumber = "3",
                    Postcode = "pe28gy",
                    EmailAddress = "grant@egg.com",
                    PhoneNumber = "01234567890",
                    MaritalStatus = PersonDetails.MaritalType.Married,
                    Size = new Size
                    {
                        HeightInFeet = 6,
                        HeightInInches = 1,
                        WeightInStone = 14,
                        WeightInPounds = 1
                    },
                    SmokerDetails = new SmokerDetails
                    {
                        NumberOfCigarettesADay = 2,
                        NumberOfCigarsADay = 1,
                        NumberOfOtherTobaccoDay = 1,
                        UsedAnyOtherReplacementProductsWithinLastYear = true,
                        LastDateSmoked = new DateTime(2018, 05, 08)
                    },
                    RidesAMotorbike = true,
                    JobTitle = "Software Engineer",
                    NarcoticsDetails = new NarcoticsDetails
                    {
                        HasBeenAdvisedToLowerAlcoholIntake = true,
                        HasUsedRecreationalDrugsInLast10Years = true,
                        NumberOfAlcoholicDrinksPerWeek = 1,
                        NumberOfGlassesOfWineAWeek = 2,
                        NumberOfPintsAWeek = 3,
                        NumberOfSpiritsAWeek = 4
                    },
                    HealthDetails = new HealthDetails()
                },
                Person2Details = new PersonDetails
                {
                    Title = PersonDetails.TitleType.Mr,
                    FirstName = "dave",
                    Gender = GenderPage.Gender.Male,
                    Surname = "smith",
                    DateOfBirth = new DateTime(1991, 12, 26),
                    IsSmoker = false,
                    MaritalStatus = PersonDetails.MaritalType.Married,
                    JobTitle = "Accountant",
                    HasLifePlanWithAnotherInsuranceCompany = false,
                    HasCriticalIllnessPlanWithAnotherInsuranceCompany = false,
                    NarcoticsDetails = new NarcoticsDetails
                    {
                        NumberOfAlcoholicDrinksPerWeek = 0,
                        NumberOfGlassesOfWineAWeek = 0,
                        NumberOfSpiritsAWeek = 0,
                        NumberOfPintsAWeek = 0,
                        HasBeenAdvisedToLowerAlcoholIntake = false,
                        HasUsedRecreationalDrugsInLast10Years = false
                    },
                    Size = new Size
                    {
                        HeightInFeet = 5,
                        HeightInInches = 2,
                        WeightInStone = 13,
                        WeightInPounds = 2
                    },
                    HealthDetails = new HealthDetails()
                }
            };

            var single = new Journey
            {
                CoverAmount = 100000,
                CoverDuration = 25,
                RequiresCriticalIllness = true,
                SingleOrJoint = WhoPage.SingleOrJoint.Single,
                Name = "single tester",
                ContactViaEmail = true,
                ContactViaPhone = true,
                ContactViaText = true,
                JourneyType = "MSM",
                Person1Details = new PersonDetails
                {
                    Title = PersonDetails.TitleType.Mr,
                    FirstName = "dave",
                    Surname = "stained",
                    Gender = GenderPage.Gender.Male,
                    DateOfBirth = new DateTime(1991, 11, 25),
                    IsSmoker = true,
                    HouseNumber = "3",
                    Postcode = "pe26ys",
                    EmailAddress = "bacon@egg.com",
                    PhoneNumber = "01234567890",
                    MaritalStatus = PersonDetails.MaritalType.Married,
                    Size = new Size
                    {
                        HeightInFeet = 6,
                        HeightInInches = 1,
                        WeightInStone = 14,
                        WeightInPounds = 1
                    },
                    SmokerDetails = new SmokerDetails
                    {
                        NumberOfCigarettesADay = 2,
                        NumberOfCigarsADay = 1,
                        NumberOfOtherTobaccoDay = 1,
                        UsedAnyOtherReplacementProductsWithinLastYear = true,
                        LastDateSmoked = new DateTime(2018, 05, 08)
                    },
                    RidesAMotorbike = true,
                    JobTitle = "Software Engineer",
                    NarcoticsDetails = new NarcoticsDetails
                    {
                        HasBeenAdvisedToLowerAlcoholIntake = true,
                        HasUsedRecreationalDrugsInLast10Years = true,
                        NumberOfAlcoholicDrinksPerWeek = 1,
                        NumberOfGlassesOfWineAWeek = 2,
                        NumberOfPintsAWeek = 3,
                        NumberOfSpiritsAWeek = 4
                    },
                    HealthDetails = new HealthDetails()
                }
            };

            JourneySerializer.SerializeJourneyToFile(journey);
            JourneySerializer.SerializeJourneyToFile(single);

            return journey;
        }
    }
}
