using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using BeagleStreet.Net.JourneyRunner.Models;
using BeagleStreet.Net.JourneyRunner.Views;
using BeagleStreet.Net.JourneyRunner.WpfHelpers;
using BeagleStreet.Test.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BeagleStreet.Net.JourneyRunner.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IBrowser _browser;
        private IWebDriver _driver;
        private readonly BackgroundWorker _backgroundWorker;
        private readonly ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        private readonly IWindowService _windowService;

        private bool _isPause = true;
        private string _pauseButtonText;
        private string _selectedEnvironment;
        private string _selectedBrand;
        private string _journeyBaseUrl; 

        public ICommand LaunchJourneyCommand { get; set; }
        public ICommand PauseJourneyCommand { get; set; }
        public ICommand GoForwardCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand StopJourneyCommand { get; set; }
        public ICommand AddJourneyCommand { get; set; }

        public string SelectedBrowser { get; set; } = "Chrome";
        public Journey SelectedJourney { get; set; }

        public string SelectedEnvironment
        {
            get => _selectedEnvironment;
            set
            {
                if (SetProperty(ref _selectedEnvironment, value))
                {
                    JourneyBaseUrl = Utilities.GenerateJourneyUrl(SelectedEnvironment, SelectedBrand);
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
                    JourneyBaseUrl = Utilities.GenerateJourneyUrl(SelectedEnvironment, SelectedBrand);
                }
            }
        }

        public string JourneyBaseUrl
        {
            get => _journeyBaseUrl;
            set => SetProperty(ref _journeyBaseUrl, value);
        }

        public string PauseButtonText
        {
            get => _pauseButtonText;
            set => SetProperty(ref _pauseButtonText, value);
        }

        public ObservableCollection<Journey> Journeys { get; set; }
        public List<string> Environments { get; set; }
        public List<string> Brands { get; set; }

        public MainViewModel()
        {
            LaunchJourneyCommand = new RelayCommand(Launch);
            StopJourneyCommand = new RelayCommand(() => _driver.Quit());
            PauseJourneyCommand = new RelayCommand(Pause);

            GoBackCommand = new RelayCommand(() => _driver.Navigate().Back());
            GoForwardCommand = new RelayCommand(() => _driver.Navigate().Forward());

            AddJourneyCommand = new RelayCommand(AddJourney);

            PopulateDefaultEnvironments();
            PopulateBrands();
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
                Journeys.Add(new Journey{Name = "poopoo"});
            }
        }

        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            JourneyRunner.RunApplication(_browser, _pauseEvent, SelectedJourney);

            //_driver.Quit();
        }

        private void PopulateDefaultEnvironments()
        {
            Environments = new List<string> { "LIVE", "INT","REG" };
            SelectedEnvironment = Environments.First();
        }

        private void PopulateBrands()
        {
            Brands = new List<string>{ "Beagle Street", "Budget", "Virgin Money" };
            SelectedBrand = Brands.First();
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
            _driver.Url = JourneyBaseUrl;
            _browser = new WebDriverBrowser(_driver);
        }

        private void Launch()
        {
            InitialiseBrowser();
            _backgroundWorker.RunWorkerAsync();
        }

        private void PopulateJourneys()
        {
            //Journeys = new ObservableCollection<Journey>(JourneySerializer.DeserializeJourniesFromFiles());

            Journeys = new ObservableCollection<Journey>
            {
                Journey.TestSingleMaleApplication(),
                Journey.TestSingleApplication(), 
                Journey.TestJointApplication()
            };

            SelectedJourney = Journeys.FirstOrDefault();
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
