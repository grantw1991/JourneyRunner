using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageFutureTravelViewModel : PageBaseViewModel
    {
        public override string Name { get; }
        public override string Title { get; }
        public override bool IsValid { get; }
        public override PageBaseViewModel NextPage { get; }
    }
}
