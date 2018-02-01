using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.Pages;

namespace BeagleStreet.JourneyRunner.ViewModels.JourneyPages
{
    public class YourSizeViewModel : PageBaseViewModel
    {
        private int _feet;
        private int _inches;
        private int _stone;
        private int _pounds;
        private string _sizeDisplayText;
        private int _size;

        public override int PageId => 6;
        public override string Name => "Your size";
        public override string Title => "Person 1 size";
        public override bool IsValid => true;
        public override bool PageRequiresJointInput => true;
        public override PageBaseViewModel NextPage => new QuestionPageNarcoticsViewModel();
        public override bool HasStateChanged { get; }

        public int Feet
        {
            get => _feet;
            set
            {
                SetProperty(ref _feet, value);
                Journey.Person1Details.Height.Feet = Feet;
            }
        }

        public int Inches
        {
            get => _inches;
            set
            {
                SetProperty(ref _inches, value);
                Journey.Person1Details.Height.Inches = Inches;
            }
        }

        public int Stone
        {
            get => _stone;
            set
            {
                SetProperty(ref _stone, value);
                Journey.Person1Details.Weight.Stone = Stone;
            }
        }

        public int Pounds
        {
            get => _pounds;
            set
            {
                SetProperty(ref _pounds, value);
                Journey.Person1Details.Weight.Pounds = Pounds;
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                SetProperty(ref _size, value);

                if (Journey.Person1Details.Gender == GenderPage.Gender.Male)
                    Journey.Person1Details.InchesInWaistSize = Size;
                else
                    Journey.Person1Details.DressSize = Size;
            }
        }

        public string SizeDisplayText
        {
            get => _sizeDisplayText;
            set => SetProperty(ref _sizeDisplayText, value);
        }

        public YourSizeViewModel()
        {
            Journey.Person1Details.Height = new Height();
            Journey.Person1Details.Weight = new Weight();

            SizeDisplayText = Journey.Person1Details.Gender == GenderPage.Gender.Male ? "Waist size:" : "Dress size:";
        }
    }
}
