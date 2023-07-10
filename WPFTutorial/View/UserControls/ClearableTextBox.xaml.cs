using System.Windows;
using System.Windows.Controls;

namespace WPFTutorial.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClearableTextBox.xaml
    /// </summary>
    public partial class ClearableTextBox : UserControl
    {
        public ClearableTextBox()
        {
            InitializeComponent();
        }

        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }
            set { placeholder = value; }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            tbPlaceholder.Visibility = Visibility.Hidden;
        }
        private void txtInput_Changed(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) tbPlaceholder.Visibility = Visibility.Visible;
        }
    }
}
