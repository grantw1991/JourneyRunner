using System;
using System.Collections.Generic;
using BeagleStreet.JourneyRunner.Pages;
using BeagleStreet.JourneyRunner.WpfHelpers;

namespace BeagleStreet.JourneyRunner.Models
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

        public WhoPage.SingleOrJoint SingleOrJoint { get; set; }
        public TermTypePage.TermType TermType { get; set; }
        public int CoverAmount { get; set; }
        public int CoverDuration { get; set; }
        public bool RequiresCriticalIllness { get; set; }
        public int CriticalIllnessAmount { get; set; }
        public PersonDetails Person1Details { get; set; }
        public PersonDetails Person2Details { get; set; }

        public static Journey TestSingleMaleApplication()
        {
            return new Journey
            {
                Name = "Single - china",
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
                    Gender = GenderPage.Gender.Male,
                    IsSmoker = true,
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
                    InchesInWaistSize = 36,
                    HasUsedRecreationalInLast5Years = false,
                    IsRegularDrinker = false,
                    SmokerDetails = new SmokerDetails
                    {
                        IsNicotineOnly = false,
                        NumberOfCigarettesADay = 5,
                        NumberOfCigarsADay = 2,
                        NumberOfGramsOfChewingTobacco = 3,
                        NumberOfGramsOfPipeTobacco = 4,
                        NumberOfPanatelasADay = 7
                    },
                    IntendToLiveOutsideOfUkInNext2Years = true, 
                    IsAwaitingAnyMedicalTest = false,
                    AnySymptomsInLast3Months = false,
                    BeenUnderInvestigationForTreatment = false,
                    IsPermanentUKResident = true,
                    WillCoverValueExceed750k = false,
                    IsHIVPositive = true,
                    HIVCondition = PersonDetails.ConditionType.Hepatitis,
                    IsDiabetic = true,
                    HasHeartCondition = false,
                    HasStroke = true,
                    HasLivedInAfricaInLast2Years = true,
                    TravelInfo = new TravelInfo
                    {
                        Country = "Croatia",
                        KnowsWhichCountryTheyWillTravelTo = true,
                        IntendToLiveInCountrySelected = true,
                    },
                    HeartConditionDetails = new HeartConditionDetails
                    {
                        HeartConditions = new List<HeartConditionDetails.HeartConditionType>
                        {
                            HeartConditionDetails.HeartConditionType.ChestPain
                        },
                        ChestPainDetails = new ChestPainDetails
                        {
                            AwaitingResults = false,
                            YearsSinceMedicalAdvice = ChestPainDetails.YearsSinceAdvice.MoreThanTwo,
                            HadAbnormalResults = true
                        }
                    },
                    StrokeConditionDetails = new StrokeConditionDetails
                    {
                        StrokeConditions = new List<StrokeConditionDetails.StrokeConditionType>
                        {
                            StrokeConditionDetails.StrokeConditionType.SubarachnoidHaemorrhage
                        },
                        TransientIschaemicAttackDetails = new TransientIschaemicAttackDetails { MonthsSinceFirstDiagnosed = 2}
                    }
                }
            };
        }

        public static Journey TestSingleMaleApplication1()
        {
            return new Journey
            {
                Name = "Single - china",
                Description = "Single application",
                CoverDuration = 10,
                SingleOrJoint = WhoPage.SingleOrJoint.Single,
                TermType = TermTypePage.TermType.Decreasing,
                CoverAmount = 250000,
                RequiresCriticalIllness = false,
                CriticalIllnessAmount = 10000,

                Person1Details = new PersonDetails
                {
                    DateOfBirth = new DateTime(1991, 11, 25),
                    Gender = GenderPage.Gender.Male,
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
                    InchesInWaistSize = 36
                }
            };
        }

        public static Journey TestSingleMaleChinaApplication()
        {
            return new Journey
            {
                Name = "Single - china",
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
                    Gender = GenderPage.Gender.Male,
                    IsSmoker = true,
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
                    InchesInWaistSize = 36,
                    HasUsedRecreationalInLast5Years = false,
                    IsRegularDrinker = false,
                    SmokerDetails = new SmokerDetails
                    {
                        IsNicotineOnly = false,
                        NumberOfCigarettesADay = 5,
                        NumberOfCigarsADay = 2,
                        NumberOfGramsOfChewingTobacco = 3,
                        NumberOfGramsOfPipeTobacco = 4,
                        NumberOfPanatelasADay = 7
                    },
                    IntendToLiveOutsideOfUkInNext2Years = true, 
                    TravelInfo = new TravelInfo
                    {
                        KnowsWhichCountryTheyWillTravelTo = true,
                        Country = "China"
                    }
                }
            };
        }

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
                    IsSmoker = true,
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

        public static Journey TestSingleIllMaleApplication()
        {
            return new Journey
            {
                Name = "Ill bloke",
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
                    IsSmoker = true,
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
                    HasUsedRecreationalInLast5Years = true,
                    IsRegularDrinker = true, 
                    IsPermanentUKResident = true,
                    PintsOfBeer = 1,
                    GlassesOfWine = 2,
                    NumberOfShots = 3,
                    DaysSinceCannabisIntake = 25,
                    WasItLessThan5YearsSinceHeroin = true,
                    HasRequiredProfessionalCareForDrugs = true,
                    HadTreatmentOnHeart = true,
                    HadAsthma = true,
                    HadAnyLiverDisorder = true,
                    LiverDisorder = "Liver disorder",
                    AsthmaDisorder = "Asthma",
                    HeartDisorder = "Coronary artery disease",
                    IsHIVPositive = true,
                    IsDiabetic = true,
                    IsGestationalDiabetes = true,
                    HasHeartCondition = true,
                    HasStroke = true,
                    HasCancer = true,
                    HasMultipleSclerosis = true,
                    HasMentalIllness = true,
                    CancerTypes = new List<string>{ "Cancer" },
                    MultipleSclerosisConditions = new List<string>{ "Brain disorder" },
                    WaitingForCancerTreatment = false,
                    MalignantTumorOrGrowth = false,
                    DurationSinceGrowthDiagnosis = "5",
                    CurrentlyOnTreatmentForTheTumour = false,
                    DurationSinceTumorTreatment = "more",
                    StrokeConditionDetails = new StrokeConditionDetails
                    {
                        StrokeConditions = new List<StrokeConditionDetails.StrokeConditionType>
                        {
                            StrokeConditionDetails.StrokeConditionType.BrainBleed
                        },
                        TransientIschaemicAttackDetails = new TransientIschaemicAttackDetails { MonthsSinceFirstDiagnosed = 2 }
                    },
                    HeartConditionDetails = new HeartConditionDetails
                    {
                        HeartConditions = new List<HeartConditionDetails.HeartConditionType>
                        {
                            HeartConditionDetails.HeartConditionType.ChestPain 
                        },
                        ChestPainDetails = new ChestPainDetails
                        {
                            AwaitingResults = false,
                            YearsSinceMedicalAdvice = ChestPainDetails.YearsSinceAdvice.MoreThanTwo,
                            HadAbnormalResults = true
                        },
                    },
                    Drugs = new List<string>
                    {
                       "Cannabis"
                    },
                    HivDetails = new HIVDetails
                    {
                        TestedPositiveForHepatitisBOrC = false,
                        CurrentlyReceivingTherapy = true,
                        ReceivingTreatmentFor24WeeksOrMore = false
                    },
                    HasConditionHadNoOnGoingTreatment = true,
                    SmokerDetails = new SmokerDetails
                    {
                        IsNicotineOnly = false,
                        NumberOfCigarettesADay = 1,
                        NumberOfCigarsADay = 2,
                        NumberOfPanatelasADay = 3,
                        NumberOfGramsOfPipeTobacco = 4,
                        NumberOfGramsOfChewingTobacco = 5
                    }
                }
            };
        }
    }
}
