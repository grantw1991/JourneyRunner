using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class YourDetailsPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            var css = browser.FindElement("#PD2_Select") != null ? "#PD2_Select" : "#PD2a_Select";

            browser.SelectValueFromDropdown(css, journey.Person1Details.Title.ToString().ToLower());
            browser.EnterTextIntoElement("#FirstName", journey.Person1Details.FirstName);
            browser.EnterTextIntoElement("#Surname", journey.Person1Details.Surname);

            browser.EnterTextIntoElement("#EmailAddress", journey.Person1Details.EmailAddress);
            browser.EnterTextIntoElement("#AddressLine1", journey.Person1Details.DoorNumber);
            browser.EnterTextIntoElement("#PostCode", journey.Person1Details.Postcode);
            browser.ClickElementWithCss("#findAddressLink");

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                browser.SelectValueFromDropdown("#PD20a_Select", journey.Person2Details.Title.ToString().ToLower());
                browser.EnterTextIntoElement("#PartnerFirstName", journey.Person2Details.FirstName);
                browser.EnterTextIntoElement("#PartnerSurname", journey.Person2Details.Surname);
                browser.EnterTextIntoElement("#PartnerEmailAddress", journey.Person2Details.EmailAddress);
            }

            browser.EnterTextIntoElement("#PhoneNumber", journey.Person1Details.PhoneNumber);

            if (browser.ElementIsVisible(".Contact_email"))
            {
                browser.ClickElementWithCss(".Contact_email");
                browser.ClickElementWithCss(".Contact_telephone");
                browser.ClickElementWithCss(".Contact_post");
            }

            browser.ClickElementWithCss("#nextPageButton");

            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
