using System;
using System.Collections.Generic;
using Life.JourneyRunner.Pages.BGL;

namespace Life.JourneyRunner.Models.MSM
{
    public class PersonDetails
    {
        public enum TitleType
        {
            Mr,
            Mrs,
            Ms,
            Miss,
            Dr
        }

        public TitleType Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string DoorNumber { get; set; }
        public string Postcode { get; set; }
        public GenderPage.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsSmoker { get; set; }
        public string PhoneNumber { get; set; }
        public int DressSize { get; set; }
        public int InchesInWaistSize { get; set; }
    }
}
