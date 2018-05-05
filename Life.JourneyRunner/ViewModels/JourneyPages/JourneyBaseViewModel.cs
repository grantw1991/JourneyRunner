using System.Collections.Generic;
using Life.JourneyRunner.Models;
using Life.JourneyRunner.Models.BGL;
using Life.JourneyRunner.WpfHelpers;

namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class JourneyBaseViewModel : BindableBase
    {
        public static Journey Journey { get; set; }

        public static PersonDetails ActivePerson { get; set; }

        public static List<PageBaseViewModel> PageCollection { get; set; }
    }
}
