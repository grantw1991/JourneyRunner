namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealth5ViewModel : PageBaseViewModel
    {
        private bool _hasEyeSymptoms;
        private bool _hadLumpOrGrowth;
        private bool _hadColitis;
        private bool _hadBloodCondition;

        public override int PageId => 16;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health 5";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageHealth6ViewModel();
        public override bool HasStateChanged { get; }
        
        public bool HasEyeSymptoms
        {
            get => _hasEyeSymptoms;
            set
            {
                SetProperty(ref _hasEyeSymptoms, value);
                ActivePerson.HasEyeSymptoms = _hasEyeSymptoms;
            }
        }

        public bool HadLumpOrGrowth
        {
            get => _hadLumpOrGrowth;
            set
            {
                SetProperty(ref _hadLumpOrGrowth, value);
                ActivePerson.HadDepression = HadLumpOrGrowth;
            }
        }

        public bool HadColitis
        {
            get => _hadColitis;
            set
            {
                SetProperty(ref _hadColitis, value);
                ActivePerson.HadLumpOrGrowth = HadColitis;
            }
        }

        public bool HadBloodCondition
        {
            get => _hadBloodCondition;
            set
            {
                SetProperty(ref _hadBloodCondition, value);
                ActivePerson.HadBloodCondition = _hadBloodCondition;
            }
        }
    }
}
