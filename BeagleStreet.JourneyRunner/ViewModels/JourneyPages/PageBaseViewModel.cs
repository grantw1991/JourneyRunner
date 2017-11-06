namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class PageBaseViewModel : JourneyBaseViewModel
    {
        public abstract string Name { get; }

        public abstract string Title { get; } 

        public abstract bool IsValid { get; }

        public abstract PageBaseViewModel NextPage { get; }
    }
}
