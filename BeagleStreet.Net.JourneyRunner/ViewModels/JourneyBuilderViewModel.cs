using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.ViewModels.JourneyPages;
using BeagleStreet.Net.JourneyRunner.WpfHelpers;

namespace BeagleStreet.Net.JourneyRunner.ViewModels
{
    public class JourneyBuilderViewModel : JourneyBaseViewModel
    {
        private bool? _dialogResult;
        private ObservableCollection<PageBaseViewModel> _pages;
        private int _selectedPageIndex;
        private PageBaseViewModel _selectedPage;

        public bool? DialogResult
        {
            get => _dialogResult;
            set => SetProperty(ref _dialogResult, value);
        }

        public ObservableCollection<PageBaseViewModel> Pages
        {
            get => _pages;
            set => SetProperty(ref _pages, value);
        }

        public PageBaseViewModel SelectedPage
        {
            get => _selectedPage;
            set => SetProperty(ref _selectedPage, value);
        }

        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set => SetProperty(ref _selectedPageIndex, value);
        }

        public ICommand OkCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand PreviousCommand { get; set; }

        public JourneyBuilderViewModel()
        {
            Journey = new Journey();
            OkCommand = new RelayCommand(SaveJourney);
            NextCommand = new RelayCommand(HandleNextPage);
            PreviousCommand = new RelayCommand(HandlePreviousPage);

            Pages = new ObservableCollection<PageBaseViewModel>
            {
                new WhoViewModel(),
                new GenderViewModel()
            };

            SelectedPage = Pages.First();
            SelectedPageIndex = 0;
        }

        private void HandlePreviousPage()
        {
            SelectedPageIndex--;
        }

        private void HandleNextPage()
        {
            SelectedPageIndex++;
        }

        private void SaveJourney()
        {
            Journey.Name = "foobar";

            DialogResult = true;
        }
    }
}
