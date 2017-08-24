using System.Windows.Input;
using BeagleStreet.Net.JourneyRunner.WpfHelpers;

namespace BeagleStreet.Net.JourneyRunner.ViewModels
{
    public class JourneyBuilderViewModel : BindableBase
    {
        private bool? _dialogResult;

        public bool? DialogResult
        {
            get => _dialogResult;
            set => SetProperty(ref _dialogResult, value);
        }

        public ICommand OkCommand { get; set; }

        public JourneyBuilderViewModel()
        {
            OkCommand = new RelayCommand(() => DialogResult = true);
        }
    }
}
