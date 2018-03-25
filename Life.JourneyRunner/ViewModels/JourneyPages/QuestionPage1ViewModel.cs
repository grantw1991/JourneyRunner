namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPage1ViewModel : PageBaseViewModel
    {
        private bool _willCoverValueExceed750K;
        private bool _isPermanentUkResident;
        private bool _isAwaitingAnyMedicalTest;
        private bool _isDueToUndergoMedicalInvestigation;
        private bool _anySymptomsInLast3Months;

        public override int PageId => 5;
        public override string Name => $"{ActivePerson.PersonNumber}) Question 1 Page";

        public override string Title => $"Person {ActivePerson.PersonNumber} Question 1 Page";

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new YourSizeViewModel();
        public override bool HasStateChanged { get; }

        public bool WillCoverValueExceed750K
        {
            get => _willCoverValueExceed750K;
            set
            {
                SetProperty(ref _willCoverValueExceed750K, value);
                ActivePerson.WillCoverValueExceed750k = WillCoverValueExceed750K;
            }
        }

        public bool IsPermanentUkResident
        {
            get => _isPermanentUkResident;
            set
            {
                SetProperty(ref _isPermanentUkResident, value);
                ActivePerson.IsPermanentUKResident = IsPermanentUkResident;
            }
        }

        public bool IsAwaitingAnyMedicalTest
        {
            get => _isAwaitingAnyMedicalTest;
            set
            {
                SetProperty(ref _isAwaitingAnyMedicalTest, value);
                ActivePerson.IsAwaitingAnyMedicalTest = IsAwaitingAnyMedicalTest;
            }
        }

        public bool IsDueToUndergoMedicalInvestigation
        {
            get => _isDueToUndergoMedicalInvestigation;
            set
            {
                SetProperty(ref _isDueToUndergoMedicalInvestigation, value);
                ActivePerson.IsDueToUndergoMedicalInvestigation = IsDueToUndergoMedicalInvestigation;
            }
        }

        public bool AnySymptomsInLast3Months
        {
            get => _anySymptomsInLast3Months;
            set
            {
                SetProperty(ref _anySymptomsInLast3Months, value);
                ActivePerson.AnySymptomsInLast3Months = AnySymptomsInLast3Months;
            }
        }
    }
}
