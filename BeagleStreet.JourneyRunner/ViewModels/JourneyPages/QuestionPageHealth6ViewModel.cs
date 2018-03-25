namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealth6ViewModel : PageBaseViewModel
    {
        /*
         *
         *personDetails.HadGout
         *personDetails.BeenPerscribedTreatment
         *personDetails.BeenUnderInvestigationForTreatment
         */


        private bool _hadGout;
        private bool _beenPerscribedTreatment;
        private bool _beenUnderInvestigationForTreatment;

        public override int PageId => 16;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health 5";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => null;
        public override bool HasStateChanged { get; }
        
        public bool HadGout
        {
            get => _hadGout;
            set
            {
                SetProperty(ref _hadGout, value);
                ActivePerson.HadGout = _hadGout;
            }
        }

        public bool BeenPerscribedTreatment
        {
            get => _beenPerscribedTreatment;
            set
            {
                SetProperty(ref _beenPerscribedTreatment, value);
                ActivePerson.HadDepression = BeenPerscribedTreatment;
            }
        }

        public bool BeenUnderInvestigationForTreatment
        {
            get => _beenUnderInvestigationForTreatment;
            set
            {
                SetProperty(ref _beenUnderInvestigationForTreatment, value);
                ActivePerson.HadLumpOrGrowth = BeenUnderInvestigationForTreatment;
            }
        }
    }
}
