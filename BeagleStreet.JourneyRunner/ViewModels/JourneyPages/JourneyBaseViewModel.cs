using System.Collections.Generic;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.WpfHelpers;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class JourneyBaseViewModel : BindableBase
    {
        public static Journey Journey { get; set; }

        public static PersonDetails ActivePerson { get; set; }

        public static List<PageBaseViewModel> PageCollection { get; set; }
    }
}
