using System;
using System.Linq;
using System.Threading;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Extensions;
using Life.JourneyRunner.Models.BGL;

namespace Life.JourneyRunner.Pages.BGL
{
    public class YourHealthQuestion3Page
    {
        public void Run(IBrowser browser, ManualResetEvent manualResetEvent, PersonDetails personDetails)
        {
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC20_Answers_{personDetails.HadTreatmentOnHeart.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC21_Answers_{personDetails.HadAsthma.ToYesNo()}']");
            browser.ClickElementWithCss($"[for='Sections_0_Questions_INC22_Answers_{personDetails.HadAnyLiverDisorder.ToYesNo()}']");

            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);

            if (!personDetails.HadTreatmentOnHeart && !personDetails.HadAsthma && !personDetails.HadAnyLiverDisorder)
                return;

            if (personDetails.HadTreatmentOnHeart)
            {
                browser.ClickElementWithCss("#questionCodeNQ1_INC20 .selectize-control");
                browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(500));
                browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(personDetails.HeartDisorder)).Click();
                browser.ClickElementWithCss("#questionCodeNQ1_INC20");
            }

            if (personDetails.HadAsthma)
            {
                browser.ClickElementWithCss("#questionCodeNQ1_INC21 .selectize-control");
                browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(500));
                browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(personDetails.AsthmaDisorder)).Click();
                browser.ClickElementWithCss("#questionCodeNQ1_INC21");
            }

            if (personDetails.HadAnyLiverDisorder)
            {
                browser.ClickElementWithCss("#questionCodeNQ1_INC22 .selectize-control");
                browser.WaitForJQueryProcessing(TimeSpan.FromSeconds(500));
                browser.FindElements(".selectize-dropdown-content div").Single(x => x.Text.Contains(personDetails.LiverDisorder)).Click();
                browser.ClickElementWithCss("#questionCodeNQ1_INC22");
            }
            
            browser.ClickElementWithCss("#nextPageButton");
            manualResetEvent.WaitOne(Timeout.Infinite);

            if (personDetails.HeartDisorder == "Coronary artery disease")
            {
                browser.ClickElementWithCss("[for=Sections_0_Questions_HRUKCAD1_Answers_yes]");
                browser.ClickElementWithCss("#nextPageButton");
                manualResetEvent.WaitOne(Timeout.Infinite);
            }

            if (personDetails.AsthmaDisorder == "Asthma")
            {
                browser.ClickElementWithCss("[for=Sections_0_Questions_ASTH1_Answers_yes]");
                browser.ClickElementWithCss("#nextPageButton");
                manualResetEvent.WaitOne(Timeout.Infinite);
            }
        }
    }
}
