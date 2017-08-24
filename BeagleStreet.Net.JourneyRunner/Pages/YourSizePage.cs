using System.Threading;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Test.Support;

namespace BeagleStreet.Net.JourneyRunner.Pages
{
    public class YourSizePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#HeightInFeet", personDetails.Height.Feet.ToString());
            browser.EnterTextIntoElement("#HeightInInches", personDetails.Height.Inches.ToString());
            browser.EnterTextIntoElement("#WeightInStones", personDetails.Weight.Stone.ToString());
            browser.EnterTextIntoElement("#WeightInPounds", personDetails.Weight.Pounds.ToString());
            browser.EnterTextIntoElement("#Size", personDetails.DressSize.ToString());

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
