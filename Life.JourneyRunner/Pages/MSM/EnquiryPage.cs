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
            
            browser.EnterTextIntoElement("#Enquiry_PostCode", journey.Person1Details.Postcode);
            browser.EnterTextIntoElement("#Enquiry_EmailAddress", journey.Person1Details.EmailAddress);
            browser.EnterTextIntoElement("#Enquiry_EmailAddress2", journey.Person1Details.EmailAddress);
            browser.EnterTextIntoElement("#Enquiry_PhoneNumber", journey.Person1Details.PhoneNumber);

            if(!journey.ContactViaEmail)
                browser.ClickElementWithCss("[for='Enquiry_ContactByEmail']");

            if(journey.ContactViaText)
                browser.ClickElementWithCss("[for='Enquiry_ContactByText']");

            if(journey.ContactViaPhone)
                browser.ClickElementWithCss("[for='Enquiry_ContactByPhone']");

            browser.ClickElementWithCss("#btnSeeResults");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }

        private void HandlePersonDetails(IBrowser browser, PersonDetails personDetails, bool isMainApplicant)
        {
            var personNumber = isMainApplicant ? "1" : "2";
            var personType = isMainApplicant ? "Main" : "Second";

            browser.SelectTextFromDropdown($"#Enquiry_{personType}ApplicantTitle", personDetails.Title.ToString());
            browser.EnterTextIntoElement($"#Enquiry_{personType}ApplicantFirstName", personDetails.FirstName);
            browser.EnterTextIntoElement($"#Enquiry_{personType}ApplicantLastName", personDetails.Surname);
            browser.EnterTextIntoElement($"#dob-{personNumber}-dd", personDetails.DateOfBirth.ToString("dd"));
            browser.EnterTextIntoElement($"#dob-{personNumber}-mm", personDetails.DateOfBirth.ToString("MM"));
            browser.EnterTextIntoElement($"#dob-{personNumber}-yyyy", personDetails.DateOfBirth.ToString("yyyy"));
            browser.ClickElementWithCss($"[for='a{personNumber}-tobacco-{personDetails.IsSmoker.ToYesNo()}']");
        }
    }
}
