namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPage1ViewModel : PageBaseViewModel
    {
        private bool _willCoverValueExceed750K;
        private bool _isPermanentUkResident;
        private bool _isAwaitingAnyMedicalTest;
        private bool _isDueToUndergoMedicalInvestigation;
        private bool _anySymptomsInLast3Months;  

        public override string Name => "Question 1 Page";
        public override string Title => "Question 1 Page";
        public override bool IsValid => true;
        public override PageBaseViewModel NextPage => new YourSizeViewModel();

        public bool WillCoverValueExceed750K
        {
            get => _willCoverValueExceed750K;
            set
            {
                SetProperty(ref _willCoverValueExceed750K, value);
                Journey.Person1Details.WillCoverValueExceed750k = WillCoverValueExceed750K;
            }
        }

        public bool IsPermanentUkResident
        {
            get => _isPermanentUkResident;
            set
            {
                SetProperty(ref _isPermanentUkResident, value);
                Journey.Person1Details.IsPermanentUKResident = IsPermanentUkResident;
            }
        }

        public bool IsAwaitingAnyMedicalTest
        {
            get => _isAwaitingAnyMedicalTest;
            set
            {
                SetProperty(ref _isAwaitingAnyMedicalTest, value);
                Journey.Person1Details.IsAwaitingAnyMedicalTest = IsAwaitingAnyMedicalTest;
            }
        }

        public bool IsDueToUndergoMedicalInvestigation
        {
            get => _isDueToUndergoMedicalInvestigation;
            set
            {
                SetProperty(ref _isDueToUndergoMedicalInvestigation, value);
                Journey.Person1Details.IsDueToUndergoMedicalInvestigation = IsDueToUndergoMedicalInvestigation;
            }
        }

        public bool AnySymptomsInLast3Months
        {
            get => _anySymptomsInLast3Months;
            set
            {
                SetProperty(ref _anySymptomsInLast3Months, value);
                Journey.Person1Details.AnySymptomsInLast3Months = AnySymptomsInLast3Months;
            }
        }
    }
}
