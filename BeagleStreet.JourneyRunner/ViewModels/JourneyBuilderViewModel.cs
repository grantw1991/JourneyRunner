using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.ViewModels.JourneyPages;
using BeagleStreet.JourneyRunner.WpfHelpers;

namespace BeagleStreet.JourneyRunner.ViewModels
{
    public class JourneyBuilderViewModel : JourneyBaseViewModel
    {
        private bool? _dialogResult;
        private ObservableCollection<PageBaseViewModel> _pages;
        private PageBaseViewModel _selectedPage;
        private string _journeyName; 

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

        public string JourneyName
        {
            get => _journeyName;
            set
            {
                SetProperty(ref _journeyName, value);
                Journey.Name = JourneyName;
            } 
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
            SelectedPage = Pages[Pages.IndexOf(SelectedPage) - 1];
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
            if (string.IsNullOrEmpty(Journey.Name))
            {
                MessageBox.Show("A name for the journey must be provided", "Empty journey name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            JourneySerializer.SerializeJourneyToFile(Journey);
            DialogResult = true;
        }
    }
}
