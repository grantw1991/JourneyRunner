using System;
using Life.JourneyRunner.Pages.BGL;
using Life.JourneyRunner.WpfHelpers;

namespace Life.JourneyRunner.Models.MSM
{
    public class Journey : BindableBase
    {
        private string _description;

        public string Name { get; set; }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public DateTime LastModified { get; set; }
        public string JourneyType { get; set; }
        public WhoPage.SingleOrJoint SingleOrJoint { get; set; }
        public TermTypePage.TermType TermType { get; set; }
        public int CoverAmount { get; set; }
        public int CoverDuration { get; set; }
        public bool RequiresCriticalIllness { get; set; }
        public int CriticalIllnessAmount { get; set; }
        public bool ContactViaEmail { get; set; }
        public bool ContactViaText { get; set; }
        public bool ContactViaPhone { get; set; }
        public PersonDetails Person1Details { get; set; }
        public PersonDetails Person2Details { get; set; }
        
        public static Journey CreateDefaultJourney()
        {
            var journey = new Journey
            {
                CoverAmount = 100000,
                CoverDuration = 25,
                RequiresCriticalIllness = true,
                SingleOrJoint = WhoPage.SingleOrJoint.Joint,
                Name = "bacon",
                ContactViaEmail = true,
                ContactViaPhone = true,
                ContactViaText = true,
                Person1Details = new PersonDetails
                {
                    Title = PersonDetails.TitleType.Miss,
                    FirstName = "grant",
                    Surname = "wright",
                    DateOfBirth = new DateTime(1991, 11, 25),
                    IsSmoker = true,
                    Postcode = "pe28gy",
                    EmailAddress = "grant@egg.com",
                    PhoneNumber = "01234567890"
                },
                Person2Details = new PersonDetails
                {
                    Title = PersonDetails.TitleType.Mr,
                    FirstName = "dave",
                    Surname = "smith",
                    DateOfBirth = new DateTime(1991, 12, 26),
                    IsSmoker = true
                }
            };

            JourneySerializer.SerializeJourneyToFile(journey);

            return journey;
        }
    }
}
