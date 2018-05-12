using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.MSM;
using Life.JourneyRunner.Pages.BGL;

namespace Life.JourneyRunner.Pages.MSM
{
    public class HealthPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Models.MSM.Journey journey)
        {
            HandlePersonDetails(browser, journey.Person1Details, true);

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                HandlePersonDetails(browser, journey.Person2Details, false);
            }
            
            browser.ClickElementWithCss("#btnSubmitUmeForm");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }

        private void HandlePersonDetails(IBrowser browser, PersonDetails personDetails, bool isMainApplicant)
        {
            var personNumber = isMainApplicant ? "0" : "1";

            browser.ClickElementWithCss($"[for='{personNumber}_BP_LIPID_CHEST_{personDetails.HealthDetails.HasRaisedBloodPressure.ToBit()}_{personDetails.HealthDetails.HasRaisedBloodPressure.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_DIABETES_{personDetails.HealthDetails.HasDiabetes.ToBit()}_{personDetails.HealthDetails.HasDiabetes.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_MENTAL_MINOR_{personDetails.HealthDetails.HasMentalIllness.ToBit()}_{personDetails.HealthDetails.HasMentalIllness.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_LUNG_{personDetails.HealthDetails.HasAsthma.ToBit()}_{personDetails.HealthDetails.HasAsthma.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_BOWEL_{personDetails.HealthDetails.HasBowelCondition.ToBit()}_{personDetails.HealthDetails.HasBowelCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_KIDNEY_FEMALE_{personDetails.HealthDetails.HasKidneyCondition.ToBit()}_{personDetails.HealthDetails.HasKidneyCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_LIVER_{personDetails.HealthDetails.HasLiverCondition.ToBit()}_{personDetails.HealthDetails.HasLiverCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_NEURO_{personDetails.HealthDetails.HasNeuroCondition.ToBit()}_{personDetails.HealthDetails.HasNeuroCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_HEARING_VISION_{personDetails.HealthDetails.HasHearingCondition.ToBit()}_{personDetails.HealthDetails.HasHearingCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_NEURO_SYMPTOMS_{personDetails.HealthDetails.HasNeuroSymptoms.ToBit()}_{personDetails.HealthDetails.HasNeuroSymptoms.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_MENTAL_SERIOUS_{personDetails.HealthDetails.HasMentalIssue.ToBit()}_{personDetails.HealthDetails.HasMentalIssue.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_CANCER_{personDetails.HealthDetails.HasCancer.ToBit()}_{personDetails.HealthDetails.HasCancer.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_HEART_{personDetails.HealthDetails.HasHeartCondition.ToBit()}_{personDetails.HealthDetails.HasHeartCondition.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_STROKE_{personDetails.HealthDetails.HasHadStoke.ToBit()}_{personDetails.HealthDetails.HasHadStoke.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_HIV_HEP_{personDetails.HealthDetails.HasHadHIV.ToBit()}_{personDetails.HealthDetails.HasHadHIV.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_TREATMENT_{personDetails.HealthDetails.HasBeenPerscribedMedication.ToBit()}_{personDetails.HealthDetails.HasBeenPerscribedMedication.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_ONGOING_REVIEWS_{personDetails.HealthDetails.HasBeenToHospitalFollowUp.ToBit()}_{personDetails.HealthDetails.HasBeenToHospitalFollowUp.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_INVESTIGATIONS_{personDetails.HealthDetails.HasBeenReferredToSpecialist.ToBit()}_{personDetails.HealthDetails.HasBeenReferredToSpecialist.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_SYMPTOMS_{personDetails.HealthDetails.HadAnyOtherSymptoms.ToBit()}_{personDetails.HealthDetails.HadAnyOtherSymptoms.ToYesNo().ToUpper()}']");
        }
    }
}
