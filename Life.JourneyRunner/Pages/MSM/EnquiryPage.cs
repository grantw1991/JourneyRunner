using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.MSM;
using Life.JourneyRunner.Pages.BGL;

namespace Life.JourneyRunner.Pages.MSM
{
    public class EnquiryPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Models.MSM.Journey journey)
        {
            browser.EnterTextIntoElement("#Enquiry_FormattedCoverAmount", journey.CoverAmount.ToString());
            browser.EnterTextIntoElement("#Enquiry_FormattedCoverTerm", journey.CoverDuration.ToString());
            browser.ClickElementWithCss($"[for='cic-{journey.RequiresCriticalIllness.ToYesNo()}']");

            browser.ClickElementWithCss(journey.SingleOrJoint == WhoPage.SingleOrJoint.Single ? "[for='second-applicant-no']" : "[for='second-applicant-yes']");

            HandlePersonDetails(browser, journey.Person1Details, true);

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                HandlePersonDetails(browser, journey.Person2Details, false);
            }
            
            browser.ClickElementWithCss("[for='Enquiry_ConsentToUseData']");
            Thread.Sleep(500);
            browser.ClickElementWithCss("#btnSeeResults");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }

        private void HandlePersonDetails(IBrowser browser, PersonDetails personDetails, bool isMainApplicant)
        {
            var personNumber = isMainApplicant ? "1" : "2";
            var personType = isMainApplicant ? "Main" : "Second";

            browser.ClickElementWithCss($"[for='applicant-{personNumber}-title-{personDetails.Title.ToString().ToLower()}']");
            browser.EnterTextIntoElement($"#Enquiry_{personType}ApplicantFirstName", personDetails.FirstName);
            browser.EnterTextIntoElement($"#Enquiry_{personType}ApplicantLastName", personDetails.Surname);
            browser.ClickElementWithCss($"[for='applicant-{personNumber}-gender-{personDetails.Gender.ToString().Substring(0, 1).ToLower()}']");
            browser.ClickElementWithCss($"[for='applicant-{personNumber}-maritalstatus-{personDetails.MaritalStatus.ToString().ToLower()}']");
            browser.EnterTextIntoElement($"#dob-{personNumber}-dd", personDetails.DateOfBirth.ToString("dd"));
            browser.EnterTextIntoElement($"#dob-{personNumber}-mm", personDetails.DateOfBirth.ToString("MM"));
            browser.EnterTextIntoElement($"#dob-{personNumber}-yyyy", personDetails.DateOfBirth.ToString("yyyy"));

            if (personNumber == "1")
            {
                browser.EnterTextIntoElement("#Enquiry_HouseNum", personDetails.HouseNumber);
                browser.EnterTextIntoElement("#Enquiry_PostCode", personDetails.Postcode);
                browser.ClickElementWithCss("#Enquiry_FindAddress");

                if (browser.ElementIsVisible("#Enquiry_FullAddressSelect"))
                {
                    browser.SelectValueFromDropdown("#Enquiry_FullAddressSelect", "0");
                }
            }

            browser.ClickElementWithCss($"[for='a{personNumber}-tobacco-{personDetails.IsSmoker.ToYesNo()}']");
        }
    }
}
