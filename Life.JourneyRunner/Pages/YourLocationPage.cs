using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models;

namespace Life.JourneyRunner.Pages
{
    public class YourLocationPage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_1_Questions_INC7_Answers_{personDetails.HasLivedInAfricaInLast2Years.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_1_Questions_INC8_Answers_{personDetails.IntendToLiveOutsideOfUkInNext2Years.ToYesNo()}']");
            browser.ClickElementWithCss("#nextPageButton");

            if (personDetails.IntendToLiveOutsideOfUkInNext2Years)
            {
                browser.ClickElementWithCss($"[for='Sections_1_Questions_INC8_1_Answers_{personDetails.TravelInfo.KnowsWhichCountryTheyWillTravelTo.ToYesNo()}']");
                browser.ClickElementWithCss("#nextPageButton");

                if (personDetails.TravelInfo.KnowsWhichCountryTheyWillTravelTo)
                {
                    browser.ClickElementWithCss("[type='text']");
                    browser.FindElements(".option").Skip(TravelInfo.GetIndexOfCountry(personDetails.TravelInfo.Country)).First().Click();
                    browser.ClickElementWithCss("#INC8_1-answer");
                    browser.ClickElementWithCss("#nextPageButton");

                    browser.ClickElementWithCss($"[for='Sections_0_Questions_Grp1_1_Answers_{personDetails.TravelInfo.IntendToLiveInCountrySelected.ToYesNo()}']");
                    browser.ClickElementWithCss("#nextPageButton");
                }
            }
            
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
