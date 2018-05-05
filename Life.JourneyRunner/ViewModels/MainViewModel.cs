using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.Models.BGL;
using Life.JourneyRunner.ViewModels.JourneyPages;
using Life.JourneyRunner.Views;
using Life.JourneyRunner.WpfHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Life.JourneyRunner.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Class level variables 

        private IBrowser _browser;
        private IWebDriver _driver;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private readonly IWindowService _windowService;
        
        private string _selectedEnvironment;
        private string _selectedBrand;
        private string _journeyBaseUrl;
        private bool _isJourneyRunning;
        private string _interviewId;
        private string _interviewToken;
        private string _selectedApplication;
        private bool _showBGLJourneys;

        public ICommand GoForwardCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand StopJourneyCommand { get; set; }
        public ICommand AddJourneyCommand { get; set; }
        public ICommand ViewJourneyCommand { get; set; }
        public ICommand DeleteJourneyCommand { get; set; }
        public ICommand RunOrPauseJourneyCommand { get; set; }

        public string SelectedBrowser { get; set; }
        public Journey SelectedJourney { get; set; }
        public Models.MSM.Journey SelectedMsmJourney { get; set; }

        public bool ShowBGLJourneys
        {
            get => _showBGLJourneys;
            set => SetProperty(ref _showBGLJourneys, value);
        }

        public string SelectedApplication
        {
            get => _selectedApplication;
            set
            {
                if (SetProperty(ref _selectedApplication, value))
                {
                    ShowBGLJourneys = SelectedApplication == "BGL (Curiosity)";
                    JourneyBaseUrl = UrlGenerator.GenerateBaseUrl(SelectedApplication, SelectedEnvironment, SelectedBrand);
                }
            }
        }

        public string SelectedEnvironment
        {
            get => _selectedEnvironment;
            set
            {
                if (SetProperty(ref _selectedEnvironment, value))
                {
                    JourneyBaseUrl = UrlGenerator.GenerateBaseUrl(SelectedApplication, SelectedEnvironment, SelectedBrand);
                }
            }
        }

        public string SelectedBrand
        {
            get => _selectedBrand;
            set
            {
                if (SetProperty(ref _selectedBrand, value))
                {
                    JourneyBaseUrl = UrlGenerator.GenerateBaseUrl(SelectedApplication, SelectedEnvironment, SelectedBrand);
                }
            }
        }

        public bool IsJourneyRunning
        {
            get => _isJourneyRunning;
            set => SetProperty(ref _isJourneyRunning, value);
        }

        public string JourneyBaseUrl
        {
            get => _journeyBaseUrl;
            set => SetProperty(ref _journeyBaseUrl, value);
        }

        public string InterviewId
        {
            get => _interviewId;
            set => SetProperty(ref _interviewId, value);
        }

        public string InterviewToken
        {
            get => _interviewToken;
            set => SetProperty(ref _interviewToken, value);
        }

        public ObservableCollection<Journey> Journeys { get; set; }
        public ObservableCollection<Models.MSM.Journey> MsmJourneys { get; set; }
        public List<string> Applications { get; set; }
        public List<string> Environments { get; set; }
        public List<string> Brands { get; set; }
        public List<string> Browsers { get; set; }

        #endregion

        public MainViewModel()
        {
            StopJourneyCommand = new RelayCommand(Stop);
            RunOrPauseJourneyCommand = new RelayCommand(RunOrPause);

            GoBackCommand = new RelayCommand(() => _driver.Navigate().Back());
            GoForwardCommand = new RelayCommand(() => _driver.Navigate().Forward());

            AddJourneyCommand = new RelayCommand(AddJourney);
            ViewJourneyCommand = new RelayCommand(ViewJourney);
            DeleteJourneyCommand = new RelayCommand(DeleteJourney);

            PopulateBrowsers();
            PopulateDefaultApplications();
            PopulateDefaultEnvironments();
            PopulateBrands();
            PopulateJourneys();

            _windowService = new WindowService();
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += BackgroundWorkerOnDoWork;
        }

        private bool _isPaused;

        private void Pause()
        {
            if (!IsJourneyRunning)
                return;

            if (!_isPaused)
                _pauseEvent.Reset();
            else
                _pauseEvent.Set();
            
            _isPaused = !_isPaused;
        }

        private void Stop()
        {
            IsJourneyRunning = false;
            _driver.Quit();
        }

        private void RunOrPause()
        {
            if (IsJourneyRunning)
                Pause();
            else
                Launch();
        }

        private void AddJourney()
        {
            var journeyBuilderViewModel = new JourneyBuilderViewModel();
            if (_windowService.ShowDialog<JourneyBuilderWindow>(journeyBuilderViewModel) == true)
            {
                Journeys.Add(JourneyBaseViewModel.Journey);
            }
        }

        private void DeleteJourney()
        {
            try
            {
                if (MessageBox.Show($"Are you sure you want to delete the journey '{SelectedJourney.Name}'", "Deleting Journey",
                        MessageBoxButton.YesNoCancel, MessageBoxImage.Question) != MessageBoxResult.Yes) return;
                
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\journeys\\" + SelectedJourney.Name + ".json";

                if (!File.Exists(path))
                    return;

                File.Delete(path);
                Journeys.Remove(SelectedJourney);
                SelectedJourney = Journeys.Any() ? Journeys.First() : null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failed to delete journey", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewJourney()
        {
            var journeyBuilderViewModel = new JourneyBuilderViewModel(SelectedJourney);
            if (_windowService.ShowDialog<JourneyBuilderWindow>(journeyBuilderViewModel) == true)
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\journeys\\" + SelectedJourney.Name + ".json";
                File.Open(path, FileMode.Open, FileAccess.ReadWrite);
            }
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            IJourneyRunner journeyRunner;

            if (SelectedApplication != "MSM (Buy Now)")
            {
                journeyRunner = new JourneyRunner(_browser, _pauseEvent, SelectedJourney);
            }
            else
            {
                journeyRunner = new MoneySupermarketJourneyRunner(_browser, _pauseEvent, Models.MSM.Journey.CreateDefaultJourney());
            }

            var runApplicationTask = Task.Factory.StartNew(() => journeyRunner.RunApplication());
            var populateInterviewDataTask = Task.Factory.StartNew(PopulateJourneyData);

            Task.WaitAll(runApplicationTask, populateInterviewDataTask);

            IsJourneyRunning = false;
        }

        private void PopulateJourneyData()
        {
            var interviewTokenCookie = _driver.Manage().Cookies.AllCookies.ToList().First(cookie => cookie.Name == "InterviewToken"); 

            InterviewToken = interviewTokenCookie != null ? interviewTokenCookie.Value : "-";
            InterviewId = _browser.GetText("#appId");
        }

        private void PopulateDefaultApplications()
        {
            Applications = new List<string> { "BGL (Curiosity)", "MSM (Buy Now)" };
            SelectedApplication = Applications.First();
        }

        private void PopulateDefaultEnvironments()
        {
            Environments = new List<string> { "LIVE", "INT", "UAT", "REG" };
            SelectedEnvironment = Environments.First();
        }

        private void PopulateBrands()
        {
            Brands = new List<string>{ "Beagle Street", "Budget", "Virgin Money", "Money Supermarket" };
            SelectedBrand = Brands.First();
        }

        private void PopulateBrowsers()
        {
            Browsers = new List<string> { "Chrome", "Firefox", "IE" };
            SelectedBrowser = Browsers.First();
        }

        private void InitialiseBrowser()
        {
            switch (SelectedBrowser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "IE":
                    _driver = new InternetExplorerDriver("C:\\Program Files\\internet explorer", new InternetExplorerOptions{ IgnoreZoomLevel = true});
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
                    break;
            }

            _driver.Manage().Window.Maximize();
            _driver.Url = JourneyBaseUrl;

            _browser = new JourneyBrowser(_driver);
        }

        private void Launch()
        {
            IsJourneyRunning = true;
            InitialiseBrowser();
            _backgroundWorker.RunWorkerAsync();
        }

        private void PopulateJourneys()
        {
            Journeys = new ObservableCollection<Journey>(JourneySerializer.DeserializeBGLJourniesFromFiles().OrderBy(journey => journey.Name));
            MsmJourneys = new ObservableCollection<Models.MSM.Journey>(JourneySerializer.DeserializeMSMJourniesFromFiles().OrderBy(journey => journey.Name));
            
            SelectedJourney = Journeys.FirstOrDefault();
            SelectedMsmJourney = MsmJourneys.FirstOrDefault();
        }
    }
}
