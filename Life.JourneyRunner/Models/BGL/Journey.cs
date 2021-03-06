﻿using System;
using Life.JourneyRunner.Pages.BGL;
using Life.JourneyRunner.WpfHelpers;

namespace Life.JourneyRunner.Models.BGL
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
        public PersonDetails Person1Details { get; set; }
        public PersonDetails Person2Details { get; set; }
    }
}
