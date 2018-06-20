using Life.JourneyRunner.Pages.BGL;

namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class TermDetailsViewModel : PageBaseViewModel
    {
        private TermTypePage.TermType _termType;
        private int _coverAmount;
        private int _coverTerm;
        private int _criticalIllnessAmount; 
        private bool _requiresCriticallIllness;

        public override int PageId => 3;

        public override string Name => $"{ActivePerson.PersonNumber}) Term";

        public override string Title => "Term Type";

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => false;
        public override PageBaseViewModel NextPage => new YourDetailsViewModel();
        public override bool HasStateChanged { get; }

        public TermTypePage.TermType TermType
        {
            get => _termType;
            set
            {
                SetProperty(ref _termType, value);
                Journey.TermType = TermType;
            }
        }

        public int CoverAmount
        {
            get => _coverAmount;
            set
            {
                SetProperty(ref _coverAmount, value);
                Journey.CoverAmount = CoverAmount;
            } 
        }

        public int CoverTerm
        {
            get => _coverTerm;
            set
            {
                SetProperty(ref _coverTerm, value);
                Journey.CoverDuration = CoverTerm;
            }
        }

        public int CriticalIllnessAmount
        {
            get => _criticalIllnessAmount;
            set
            {
                SetProperty(ref _criticalIllnessAmount, value);
                Journey.CriticalIllnessAmount = _criticalIllnessAmount;
            }
        }

        public bool RequiresCriticalIllness
        {
            get => _requiresCriticallIllness;
            set
            {
                SetProperty(ref _requiresCriticallIllness, value);
                Journey.RequiresCriticalIllness = _requiresCriticallIllness;
            }
        }
    }
}
