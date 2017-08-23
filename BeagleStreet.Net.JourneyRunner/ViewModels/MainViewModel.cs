using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.Pages;
using BeagleStreet.Net.JourneyRunner.Views;
using BeagleStreet.Net.JourneyRunner.WpfHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Environment = BeagleStreet.Net.JourneyRunner.Models.Environment;

namespace BeagleStreet.Net.JourneyRunner.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IWebDriver _driver;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private readonly IWindowService _windowService;

        private bool _isPause = true;
        private string _pauseButtonText;

        public ICommand LaunchJourneyCommand { get; set; }
        public ICommand PauseJourneyCommand { get; set; }
        public ICommand GoForwardCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand StopJourneyCommand { get; set; }
        public ICommand AddJourneyCommand { get; set; }

        public string SelectedBrowser { get; set; } = "Chrome";
        public Journey SelectedJourney { get; set; }
        public Environment SelectedEnvironment { get; set; }

        public string PauseButtonText
        {
            get => _pauseButtonText;
            set => SetProperty(ref _pauseButtonText, value);
        }

        public List<Journey> Journeys { get; set; }
        public List<Environment> Environments { get; set; }

        public MainViewModel()
        {
            LaunchJourneyCommand = new RelayCommand(Launch);
            StopJourneyCommand = new RelayCommand(() => _driver.Quit());
            PauseJourneyCommand = new RelayCommand(Pause);

            GoBackCommand = new RelayCommand(() => _driver.Navigate().Back());
            GoForwardCommand = new RelayCommand(() => _driver.Navigate().Forward());

            AddJourneyCommand = new RelayCommand(AddJourney);

            PopulateDefaultEnvironments();
            PopulateJourneys();

            _windowService = new WindowService();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
        }

        private void AddJourney()
        {
            var journeyBuilderViewModel = new JourneyBuilderViewModel();
            if (_windowService.ShowDialog<JourneyBuilderWindow>(journeyBuilderViewModel) == true)
            {

            }
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            Journey.Run(_driver, _pauseEvent, SelectedJourney);

            //_driver.Quit();
        }

        private void PopulateDefaultEnvironments()
        {
            Environments = new List<Environment>
            {
                new Environment { Name = "INT", BaseUrl = "http://pbo-lifedevap01:8010/BS-INT/" },
                new Environment { Name = "REG", BaseUrl = "http://pbo-lifedevap01:8010/BS-REG/" },
                new Environment { Name = "LIVE", BaseUrl = "https://quotes.beaglestreet.com/Z011" }
            };

            SelectedEnvironment = Environments.First();
        }

        private void InitialiseBrowser()
        {
            switch (SelectedBrowser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
            }

            _driver.Manage().Window.Maximize();
            _driver.Url = SelectedEnvironment.BaseUrl;
        }

        private void Launch()
        {
            InitialiseBrowser();

            _backgroundWorker.RunWorkerAsync();
        }

        private void PopulateJourneys()
        {
            Journeys = new List<Journey>
            {
                new Journey
                {
                    Name = "Tester",
                    Description = "Single application smoker",
                    CoverDuration = 10,
                    DateOfBirth = new DateTime(1991, 11, 25),
                    SingleOrJoint = WhoPage.SingleOrJoint.Single,
                    TermType = TermTypePage.TermType.Decreasing,
                    Gender = GenderPage.Gender.Female,
                    CoverAmount = 100000,
                    RequiresCriticalIllness = true,
                    CriticalIllnessAmount = 10000,
                    IsSmoker = true
                }
            };

            SelectedJourney = Journeys.First();
        }
        
        private void Pause()
        {
            if (_isPause)
            {
                _pauseEvent.Reset();
                PauseButtonText = "Resume";
            }
            else
            {
                _pauseEvent.Set();
                PauseButtonText = "Pause";
            }

            _isPause = !_isPause;
        }
    }
}
