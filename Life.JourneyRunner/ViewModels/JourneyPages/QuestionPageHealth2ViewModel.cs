using System.Collections.Generic;

namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealth2ViewModel : PageBaseViewModel
    {
        private bool _hasHadCancer;
        private bool _hasNervousSystemDisorder;
        private bool _hasMentalIllness;
        private string _nervousSystemDisorder;
        private string _cancer;

        public override int PageId => 12;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health 2";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => HandleNextPage();
        public override bool HasStateChanged { get; }

        public bool HasHadCancer
        {
            get => _hasHadCancer;
            set => SetProperty(ref _hasHadCancer, value);
        }

        public bool HasNervousSystemDisorder
        {
            get => _hasNervousSystemDisorder;
            set => SetProperty(ref _hasNervousSystemDisorder, value);
        }

        public bool HasMentalIllness
        {
            get => _hasMentalIllness;
            set => SetProperty(ref _hasMentalIllness, value);
        }

        public List<string> NervousSystemDisorders { get; set; }

        public List<string> Cancers { get; set; }

        public string Cancer
        {
            get => _cancer;
            set => SetProperty(ref _cancer, value);
        }

        public string NervousSystemDisorder
        {
            get => _nervousSystemDisorder;
            set => SetProperty(ref _nervousSystemDisorder, value);
        }

        public QuestionPageHealth2ViewModel()
        {
            NervousSystemDisorders = new List<string>
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

            Cancers = new List<string>
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

        private PageBaseViewModel HandleNextPage()
        {
            if (HasHadCancer)
            {
                return new QuestionPageHealthHIVViewModel();
            }

            return new QuestionPageHealth3ViewModel();
        }

    }
}
