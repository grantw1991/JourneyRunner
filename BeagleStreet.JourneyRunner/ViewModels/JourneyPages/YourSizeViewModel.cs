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
        public override string Name
        {
            get => "Your size";
            set { }
        }

        public override string Title
        {
            get => "Person 1 size";
            set { }
        }

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
                ActivePerson.Height.Feet = Feet;
            }
        }

        public int Inches
        {
            get => _inches;
            set
            {
                SetProperty(ref _inches, value);
                ActivePerson.Height.Inches = Inches;
            }
        }

        public int Stone
        {
            get => _stone;
            set
            {
                SetProperty(ref _stone, value);
                ActivePerson.Weight.Stone = Stone;
            }
        }

        public int Pounds
        {
            get => _pounds;
            set
            {
                SetProperty(ref _pounds, value);
                ActivePerson.Weight.Pounds = Pounds;
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                SetProperty(ref _size, value);

                if (ActivePerson.Gender == GenderPage.Gender.Male)
                    ActivePerson.InchesInWaistSize = Size;
                else
                    ActivePerson.DressSize = Size;
            }
        }

        public string SizeDisplayText
        {
            get => _sizeDisplayText;
            set => SetProperty(ref _sizeDisplayText, value);
        }

        public YourSizeViewModel()
        {
            ActivePerson.Height = new Height();
            ActivePerson.Weight = new Weight();

            SizeDisplayText = ActivePerson.Gender == GenderPage.Gender.Male ? "Waist size:" : "Dress size:";
        }
    }
}
