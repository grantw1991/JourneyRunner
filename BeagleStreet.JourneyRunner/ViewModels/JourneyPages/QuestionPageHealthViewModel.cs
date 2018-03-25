using System.Collections.Generic;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageHealthViewModel : PageBaseViewModel
    {
        private bool _hasHadHIV;
        private bool _hasHadDiabetes;
        private bool _hasHadHeartCondition;
        private bool _hasHadStroke;
        private string _aid;
        private string _heartCondition;
        private string _headInjury;

        public override int PageId => 11;
        public override string Name => $"Person {ActivePerson.PersonNumber} Health";
        public override string Title => "About your health";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageHealth2ViewModel();
        public override bool HasStateChanged { get; }

         public bool HasHadHIV 
         {
            get => _hasHadHIV;
             set
             {
                SetProperty(ref _hasHadHIV, value);
                 ActivePerson.IsHIVPositive = HasHadHIV;
             }
         }

         public bool HasHadDiabetes
         {
            get => _hasHadDiabetes;
             set
             {
                SetProperty(ref _hasHadDiabetes, value);
                 ActivePerson.IsDiabetic = HasHadDiabetes;
             }
         }

         public bool HasHadHeartCondition
         {
            get => _hasHadHeartCondition;
             set
             {
                SetProperty(ref _hasHadHeartCondition, value);
                 ActivePerson.HasHeartCondition = HasHadHeartCondition;
             } 
         }

         public bool HasHadStroke
         {
            get => _hasHadStroke;
             set
             {
                SetProperty(ref _hasHadStroke, value);
                 ActivePerson.HasStroke = HasHadStroke;
             } 
         }

        public List<string> Aids { get; set; }

        public List<string> HeartConditions { get; set; }

        public List<string> HeadInjuries { get; set; }

        public string Aid
        {
            get => _aid;
            set => SetProperty(ref _aid, value);
        }

        public string HeartCondition
        {
            get => _heartCondition;
            set => SetProperty(ref _heartCondition, value);
        }

        public string HeadInjury
        {
            get => _headInjury;
            set => SetProperty(ref _headInjury, value);
        }

        public QuestionPageHealthViewModel()
        {
            Aids = new List<string>
            {
                "HIV",
                "Hepetitus B or C only",
                "Awaiting the results of such a test"
            };

            HeartConditions = new List<string>
            {
                "Angina",
                "Cardiomyopathy",
                "Chest pain",
                "Coronary artery disease",
                "Heart attack",
                "Heart rhythm disorder",
                "Heart valve disorder",
                "Irregular heartbeat",
                "Raised blood pressure",
                "Raised cholesterol",
                "Other"
            };

            HeadInjuries = new List<string>
            {
                "Brain bleed",
                "Brain haemorrhage",
                "Cerebral haemorrhage",
                "cerebrovascular accident",
                "brain injury",
                "narrowing of the arteries",
                "stroke",
                "subarachnoid haemorrhage",
                "transient ischaemic attack",
                "Other"
            };
        }
    }
}
