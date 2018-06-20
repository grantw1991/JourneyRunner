using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.MSM;
using Life.JourneyRunner.Pages.BGL;

namespace Life.JourneyRunner.Pages.MSM
{
    public class LifestylePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            HandlePersonDetails(browser, journey.Person1Details, true);

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                HandlePersonDetails(browser, journey.Person2Details, false);
            }

            browser.ExecuteJavaScript<string>("window.scrollTo(0,document.querySelector('body').scrollHeight); return '';");
            Thread.Sleep(7000);
            browser.ClickElementWithCss("#btnSubmitUmeForm");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }

        private void HandlePersonDetails(IBrowser browser, PersonDetails personDetails, bool isMainApplicant)
        {
            var personNumber = isMainApplicant ? "0" : "1";

            browser.EnterTextIntoElement($"#ImperialHeightFeet_{personNumber}", personDetails.Size.HeightInFeet.ToString());
            browser.EnterTextIntoElement($"#ImperialHeightInches_{personNumber}", personDetails.Size.HeightInInches.ToString());
            browser.EnterTextIntoElement($"#ImperialWeightStone_{personNumber}", personDetails.Size.WeightInStone.ToString());
            browser.EnterTextIntoElement($"#ImperialWeightPounds_{personNumber}", personDetails.Size.WeightInPounds.ToString());

            if (personDetails.IsSmoker)
            {
                browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Key_Info__Questions_2__Answer", personDetails.SmokerDetails.NumberOfCigarettesADay.ToString());
                browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Key_Info__Questions_3__Answer", personDetails.SmokerDetails.NumberOfCigarsADay.ToString());
                browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Key_Info__Questions_4__Answer", personDetails.SmokerDetails.NumberOfOtherTobaccoDay.ToString());
                //browser.ClickElementWithCss($"[for='{personNumber}_Tobacco_Patches_{personDetails.SmokerDetails.UsedAnyOtherReplacementProductsWithinLastYear.ToBit()}_{personDetails.SmokerDetails.UsedAnyOtherReplacementProductsWithinLastYear.ToYesNo().ToUpper()}']");
                browser.ClickElementWithCss($"[for='{personNumber}_Tobacco_Patches_1_NO']");

                //if (personDetails.SmokerDetails.UsedAnyOtherReplacementProductsWithinLastYear)
                //{
                //    var smokingDate = personDetails.SmokerDetails.LastDateSmoked == DateTime.MinValue ? DateTime.Now : personDetails.SmokerDetails.LastDateSmoked;
                //    Thread.Sleep(5000);
                //    browser.ExecuteJavaScript<string>($"document.getElementById('{personNumber}_Tobacco_ExWhen_mm').value = '{smokingDate.Month}';" +
                //                                      $"document.getElementById('{personNumber}_Tobacco_ExWhen_yyyy').value = '{smokingDate:yyyy}'; return '';");
                //}
            }
            else
            {
                browser.ClickElementWithCss($"[for='{personNumber}_NON_SMOKER_STATUS_0_LIFE_LONG']");
            }

            browser.EnterTextIntoElement($"[data-umeoptionlistdiv='{personNumber}_OCCUPATION_Options']", personDetails.JobTitle);
            Thread.Sleep(500);
            browser.ClickElementByXPath($"//*[@id='{personNumber}_OCCUPATION_Options']/div[3]/div[3]/div/ol/li[1]");
            
            browser.ClickElementWithCss($"[for='{personNumber}_FAMILY_HISTORY_CI_IP_TPD_9_NONE_OF']"); 
            browser.ClickElementWithCss($"[for='{personNumber}_PURSUITS_6_NONE_OF']");
            browser.ClickElementWithCss($"[for='{personNumber}_MOTOR_BIKE_{personDetails.RidesAMotorbike.ToBit()}_{personDetails.RidesAMotorbike.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_DRIVING_BAN_{personDetails.HasBeenBannedFromDrivingInLast5Years.ToBit()}_{personDetails.HasBeenBannedFromDrivingInLast5Years.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_TRAVEL_2_NEITHER']");
            browser.ClickElementWithCss($"[for='{personNumber}_EXISTING_COVER_LIFE_{personDetails.HasLifePlanWithAnotherInsuranceCompany.ToBit()}_{personDetails.HasLifePlanWithAnotherInsuranceCompany.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_EXISTING_COVER_CI_{personDetails.HasCriticalIllnessPlanWithAnotherInsuranceCompany.ToBit()}_{personDetails.HasCriticalIllnessPlanWithAnotherInsuranceCompany.ToYesNo().ToUpper()}']");
            browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Alcohol_Drugs__Questions_0__Answer", personDetails.NarcoticsDetails.NumberOfPintsAWeek.ToString());
            browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Alcohol_Drugs__Questions_1__Answer", personDetails.NarcoticsDetails.NumberOfGlassesOfWineAWeek.ToString());
            browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Alcohol_Drugs__Questions_2__Answer", personDetails.NarcoticsDetails.NumberOfSpiritsAWeek.ToString());
            browser.EnterTextIntoElement($"#Applicants_{personNumber}__Lines_Alcohol_Drugs__Questions_3__Answer", personDetails.NarcoticsDetails.NumberOfAlcoholicDrinksPerWeek.ToString());
            browser.ClickElementWithCss($"[for='{personNumber}_ALCOHOL_ADVICE_{personDetails.NarcoticsDetails.HasBeenAdvisedToLowerAlcoholIntake.ToBit()}_{personDetails.NarcoticsDetails.HasBeenAdvisedToLowerAlcoholIntake.ToYesNo().ToUpper()}']");
            browser.ClickElementWithCss($"[for='{personNumber}_DRUGS_{personDetails.NarcoticsDetails.HasUsedRecreationalDrugsInLast10Years.ToBit()}_{personDetails.NarcoticsDetails.HasUsedRecreationalDrugsInLast10Years.ToYesNo().ToUpper()}']");
        }
    }
}
