namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealth4ViewModel : PageBaseViewModel
    {
        private bool _hadKidneyOrBladderSymptoms;
        private bool _hadDepression;
        private bool _hadDoubleVision;
        private bool _advisedToLowerAlcoholIntake;
        
        public override int PageId => 15;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health 4";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageHealth5ViewModel();
        public override bool HasStateChanged { get; }


        public bool HadKidneyOrBladderSymptoms
        {
            get => _hadKidneyOrBladderSymptoms;
            set
            {
                SetProperty(ref _hadKidneyOrBladderSymptoms, value);
                ActivePerson.HadKidneyOrBladderSymptoms = _hadKidneyOrBladderSymptoms;
            }
        }

        public bool HadDepression
        {
            get => _hadDepression;
            set
            {
                SetProperty(ref _hadDepression, value);
                ActivePerson.HadDepression = HadDepression;
            }
        }

        public bool HadDoubleVision
        {
            get => _hadDoubleVision;
            set
            {
                SetProperty(ref _hadDoubleVision, value);
                ActivePerson.HadDoubleVision = HadDoubleVision;
            }
        }

        public bool AdvisedToLowerAlcoholIntake
        {
            get => _advisedToLowerAlcoholIntake;
            set
            {
                SetProperty(ref _advisedToLowerAlcoholIntake, value);
                ActivePerson.AdvisedToLowerAlcoholIntake = AdvisedToLowerAlcoholIntake;
            }
        }
    }
}
