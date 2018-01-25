using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageTabaccoInfoViewModel : PageBaseViewModel
    {
        private bool _isNicotineReplacement;

        public override string Name => "Smoker Info";
        public override string Title => "Smoker Info";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => new QuestionPageFutureTravelViewModel();
        
        public bool IsNicotineReplacement
        {
            get => _isNicotineReplacement;
            set
            {
                SetProperty(ref _isNicotineReplacement, value);
                Journey.Person1Details.SmokerDetails.IsNicotineOnly = IsNicotineReplacement;
            }
        }
    }
}
