using System;
using System.Collections.Generic;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.Models
{
    public class PersonDetails
    {
        public enum ConditionType
        {
            HIV, 
            Hepatitis,
            Awaiting
        }

        public enum TitleType
        {
            Mr,
            Mrs,
            Ms,
            Miss,
            Dr
        }

        public TitleType Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string DoorNumber { get; set; }
        public string Postcode { get; set; }
        public GenderPage.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public string PhoneNumber { get; set; }
        public List<Question> Questions { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public int DressSize { get; set; }
        public int InchesInWaistSize { get; set; }
        public bool IsRegularDrinker { get; set; }
        public bool HasUsedRecreationalInLast5Years { get; set; }
        public bool HasLivedInAfricaInLast2Years { get; set; }
        public bool IntendToLiveOutsideOfUkInNext2Years { get; set; }
        public bool IsDiabetic { get; set; }
        public bool HasHeartCondition { get; set; }
        public bool HasStroke { get; set; }
        public bool IsHIVPositive { get; set; }
        public ConditionType HIVCondition { get; set; }
        public bool HasCancer { get; set; }
        public bool HasMultipleSclerosis { get; set; }
        public bool HasMentalIllness { get; set; }
        public bool HadTreatmentOnHeart { get; set; }
        public bool HadAsthma { get; set; }
        public bool HadAnyLiverDisorder { get; set; }
        public bool HadKidneyOrBladderSymptoms { get; set; }
        public bool HadDepression { get; set; }
        public bool HadDoubleVision { get; set; }
        public bool AdvisedToLowerAlcoholIntake { get; set; }
        public bool HasEyeSymptoms { get; set; }
        public bool HadLumpOrGrowth { get; set; }
        public bool HadColitis { get; set; }
        public bool HadBloodCondition { get; set; }
        public bool HadGout { get; set; }
        public bool BeenPerscribedTreatment { get; set; }
        public bool BeenUnderInvestigationForTreatment { get; set; }
        public SmokerDetails SmokerDetails { get; set; }
        public TravelInfo TravelInfo { get; set; }
        public HeartConditionDetails HeartConditionDetails { get; set; }
        public StrokeConditionDetails StrokeConditionDetails { get; set; }
        public bool IsAwaitingAnyMedicalTest { get; set; }
        public bool IsDueToUndergoMedicalInvestigation { get; set; }
        public bool AnySymptomsInLast3Months { get; set; }
        public bool WillCoverValueExceed750k { get; set; }
        public bool IsPermanentUKResident { get; set; }
        public int PersonNumber { get; set; }
    }
}
