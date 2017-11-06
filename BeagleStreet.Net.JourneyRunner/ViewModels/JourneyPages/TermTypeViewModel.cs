using BeagleStreet.Net.JourneyRunner.Pages;

namespace BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages
{
    public class TermTypeViewModel : PageBaseViewModel
    {
        private TermTypePage.TermType _termType;

        public override string Name => "Term";
        public override string Title => "Term Type";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => null;

        public TermTypePage.TermType TermType
        {
            get => _termType;
            set
            {
                SetProperty(ref _termType, value);
                Journey.TermType = TermType;
            }
        }
    }
}
