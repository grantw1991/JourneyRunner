using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.Pages;
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
        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }

        public JourneyBuilderViewModel()
        {
            Journey = new Journey { Person1Details = new PersonDetails() };
            OkCommand = new RelayCommand(SaveJourney);
            NextPageCommand = new RelayCommand(HandleNextPage);
            PreviousPageCommand = new RelayCommand(HandlePreviousPage);

            Pages = new ObservableCollection<PageBaseViewModel> { new WhoViewModel() };
            
            SelectedPage = Pages.First();
        }

        private void HandlePreviousPage()
        {
            SelectedPageIndex--;
        }

        private void HandleNextPage()
        {
            if (!SelectedPage.IsValid)
            {
                // show error message
                return;
            }

            if (Pages.All(page => page.Name != SelectedPage.NextPage.Name))
            {
                Pages.Add(SelectedPage.NextPage);
            }

            SelectedPage = Pages.Single(page => page.Name == SelectedPage.NextPage.Name);
        }

        private void SaveJourney()
        {
            Journey.Name = "foobar";
            var egg = Journey.TermType;
            DialogResult = true;
        }
    }
}
