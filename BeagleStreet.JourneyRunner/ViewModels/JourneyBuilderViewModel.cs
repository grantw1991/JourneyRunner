using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BeagleStreet.JourneyRunner.Models;
using BeagleStreet.JourneyRunner.Pages;
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
            Journey = new Journey { Person1Details = new PersonDetails { PersonNumber = 1 }, Person2Details = new PersonDetails { PersonNumber = 2 } };
            ActivePerson = Journey.Person1Details;
            OkCommand = new RelayCommand(SaveJourney);
            NextPageCommand = new RelayCommand(HandleNextPage);
            PreviousPageCommand = new RelayCommand(HandlePreviousPage);
            PageCollection = new List<PageBaseViewModel>();
            Pages = new ObservableCollection<PageBaseViewModel> { new WhoViewModel() };
            PageCollection.Add(Pages.First());
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

            if (Journey.SingleOrJoint == WhoPage.SingleOrJoint.Joint && Pages.Count(p => p.PageId == SelectedPage.PageId) == 1 && SelectedPage.PageRequiresJointInput)
            {
                // if the journey is joint and the pages collection contains one page of the same type then add it. 
                ActivePerson = Journey.Person2Details;
                var instance = (PageBaseViewModel)Activator.CreateInstance(SelectedPage.GetType());
                PageCollection.Add(instance);
                Pages.Add(instance);
                SelectedPage = Pages.Last();
            }
            else if (Pages.All(p => p.PageId != SelectedPage.NextPage.PageId))
            {
                // if the pages collection does not contain the next page then add it.
                ActivePerson = Journey.Person1Details;
                PageCollection.Add(SelectedPage.NextPage);
                Pages.Add(SelectedPage.NextPage);
                SelectedPage = Pages.Last(page => page.Name == SelectedPage.NextPage.Name);
            }
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
