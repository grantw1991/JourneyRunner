using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class YourSizePage
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.EnterTextIntoElement("#HeightInFeet", personDetails.Height.Feet.ToString());
            browser.EnterTextIntoElement("#HeightInInches", personDetails.Height.Inches.ToString());
            browser.EnterTextIntoElement("#WeightInStones", personDetails.Weight.Stone.ToString());
            browser.EnterTextIntoElement("#WeightInPounds", personDetails.Weight.Pounds.ToString());
            browser.EnterTextIntoElement("#Size", personDetails.Gender == GenderPage.Gender.Male ? personDetails.InchesInWaistSize.ToString() : personDetails.DressSize.ToString());

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);
        }
    }
}
