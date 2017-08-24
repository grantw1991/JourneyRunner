﻿using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourDetailsPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, Journey journey)
        {
            browser.SelectValueFromDropdown("#PD2a_Select", journey.Person1Details.Title.ToString().ToLower());
            browser.EnterTextIntoElement("#FirstName", journey.Person1Details.FirstName);
            browser.EnterTextIntoElement("#Surname", journey.Person1Details.Surname);

            browser.EnterTextIntoElement("#EmailAddress", journey.Person1Details.EmailAddress);
            browser.EnterTextIntoElement("#AddressLine1", journey.Person1Details.DoorNumber);
            browser.EnterTextIntoElement("#PostCode", journey.Person1Details.Postcode);
            browser.ClickElementWithCss("#findAddressLink");

            browser.EnterTextIntoElement("#PhoneNumber", journey.Person1Details.PhoneNumber);

            if (browser.ElementIsVisible(".Contact_email"))
            {
                browser.ClickElementWithCss(".Contact_email");
                browser.ClickElementWithCss(".Contact_telephone");
                browser.ClickElementWithCss(".Contact_post");
            }

            if (journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint)
            {
                browser.SelectValueFromDropdown("#PD20a_Select", journey.Person1Details.Title.ToString().ToLower());
                browser.EnterTextIntoElement("#PartnerFirstName", journey.Person1Details.FirstName);
                browser.EnterTextIntoElement("#PartnerSurname", journey.Person1Details.Surname);
                browser.EnterTextIntoElement("#PartnerEmailAddress", journey.Person1Details.EmailAddress);
            }

            browser.ClickElementWithCss("#nextPageButton");

            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
