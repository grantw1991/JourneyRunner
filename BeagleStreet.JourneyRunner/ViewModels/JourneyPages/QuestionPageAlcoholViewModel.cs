namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class QuestionPageAlcoholViewModel : PageBaseViewModel
    {
        private int _pintsOfBeer;
        private int _glassesOfWine;
        private int _shots;

        public override int PageId => 9;
        public override string Name
        {
            get => "Alcohol Intake";
            set { }
        }

        public override string Title
        {
            get => "Alcohol Intake";
            set { }
        }

        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageFutureTravelViewModel();
        public override bool HasStateChanged { get; }

        public int PintsOfBeer
        {
            get => _pintsOfBeer;
            set
            {
                SetProperty(ref _pintsOfBeer, value);
                //Journey.Person1Details.
            }
        }

        public int GlassesOfWine
        {
            get => _glassesOfWine;
            set
            {
                SetProperty(ref _glassesOfWine, value);
                //Journey.Person1Details.
            }
        }

        public int Shots
        { 
            get => _shots;
            set
            {
                SetProperty(ref _shots, value);
                //Journey.Person1Details.
            }
        }
    }
}
