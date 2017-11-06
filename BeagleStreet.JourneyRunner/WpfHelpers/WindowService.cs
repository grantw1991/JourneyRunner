using System.Windows;

namespace BeagleStreet.JourneyRunner.WpfHelpers
{
    class WindowService : IWindowService
    {
        private static Window CreateWindow<T>() where T : Window, new()
        {
            var window = new T();

            if (!Equals(Application.Current.MainWindow, window))
                window.Owner = Application.Current.MainWindow;
            return window;
        }

        public void Show<T>(object context) where T : Window, new()
        {
            var window = CreateWindow<T>();
            window.DataContext = context;
            window.Show();
        }

        public void Show<T>() where T : Window, new()
        {
            var window = CreateWindow<T>();
            window.Show();
        }

        public bool? ShowDialog<T>(object context) where T : Window, new()
        {
            var window = CreateWindow<T>();
            window.DataContext = context;
            return window.ShowDialog();
        }

        public bool? ShowDialog<T>() where T : Window, new()
        {
            var window = CreateWindow<T>();
            return window.ShowDialog();
        }
    }
}
