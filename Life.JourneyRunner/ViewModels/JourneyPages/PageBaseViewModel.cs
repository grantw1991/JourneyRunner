namespace Life.JourneyRunner.ViewModels.JourneyPages
{
    public abstract class PageBaseViewModel : JourneyBaseViewModel
    {
        public abstract int PageId { get; }

        public abstract string Name { get; }

        public abstract string Title { get; } 

        public abstract bool IsValid { get; }

        public abstract bool PageRequiresJointInput { get; }

        public abstract PageBaseViewModel NextPage { get; }
        
        public abstract bool HasStateChanged { get; }
    }
}
