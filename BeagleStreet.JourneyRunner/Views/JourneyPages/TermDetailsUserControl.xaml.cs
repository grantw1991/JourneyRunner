using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeagleStreet.JourneyRunner.Views.JourneyPages
{
    public partial class TermDetailsUserControl : UserControl
    {
        public TermDetailsUserControl()
        {
            InitializeComponent(); 
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
