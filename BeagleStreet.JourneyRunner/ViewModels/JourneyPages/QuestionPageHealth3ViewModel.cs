using System.Collections.Generic;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealth3ViewModel : PageBaseViewModel
    {
        private bool _hasHadLiverDisorder;
        private bool _hasHadAsthma;
        private bool _hasHeartProblem;
        private string _liverDisorder;
        private string _asthmaDisorder;
        private string _heartProblem;

        public override int PageId => 13;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health 3";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageHealth4ViewModel();
        public override bool HasStateChanged { get; }

        public bool HasHadLiverDisorder
        {
            get => _hasHadLiverDisorder;
            set
            {
                SetProperty(ref _hasHadLiverDisorder, value);
                ActivePerson.HadAnyLiverDisorder = HasHadLiverDisorder;
            }
        }

        public bool HasHadAsthma
        {
            get => _hasHadAsthma;
            set
            {
                SetProperty(ref _hasHadAsthma, value);
                ActivePerson.HadAsthma = HasHadAsthma;
            }
        }

        public bool HasHeartProblem
        {
            get => _hasHeartProblem;
            set
            {
                SetProperty(ref _hasHeartProblem, value);
                ActivePerson.HadTreatmentOnHeart = HasHeartProblem;
            }
        }

        public List<string> HeartProblems { get; set; }

        public List<string> LiverDisorders { get; set; }

        public List<string> AsthmaDisorders { get; set; }

        public string HeartProblem
        {
            get => _heartProblem;
            set => SetProperty(ref _heartProblem, value);
        }

        public string LiverDisorder
        {
            get => _liverDisorder;
            set => SetProperty(ref _liverDisorder, value);
        }

        public string AsthmaDisorder
        {
            get => _asthmaDisorder;
            set => SetProperty(ref _asthmaDisorder, value);
        }

        public QuestionPageHealth3ViewModel()
        {
            HeartProblems = new List<string>
            {
                "Brain disorder",
                "Cerebral palsy",
                "Chronic fatigue syndrome",
                "Down's syndrome",
                "Epilepsy",
                "Multiple sclerosis",
                "Neuralgia",
                "Optic neuritis",
                "Paralysis",
                "Other"
            };

            LiverDisorders = new List<string>
            {
                "Breast cancer",
                "Cancer",
                "Freckle",
                "Growth",
                "Hodgkin's disease",
                "Leukaemia",
                "Lump",
                "Mole",
                "Prostate tumour",
                "Other"
            };

            AsthmaDisorders = new List<string>
            {
                "Breast cancer",
                "Cancer",
                "Freckle",
                "Growth",
                "Hodgkin's disease",
                "Leukaemia",
                "Lump",
                "Mole",
                "Prostate tumour",
                "Other"
            };
        }
    }
}
