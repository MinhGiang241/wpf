using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Winform = System.Windows.Forms;

namespace WPFTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();
            lvEntries.Items.Add("a");
            lvEntries.Items.Add("a");
            lvEntries.Items.Add("a");
            lvEntries.Items.Add("a");

        }

        private string boundText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                OnPropertyChanged();
            }
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "Set code value";
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtEntry.Text == null || txtEntry.Text == "") return;
            lvEntries.Items.Add(txtEntry.Text);
            txtEntry.Text = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // int index = lvEntries.SelectedIndex;
            var items = lvEntries.SelectedItems;

            var result = MessageBox.Show($"Are you sure want to delete {items.Count} items", "Sure?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                foreach (var item in new ArrayList(items))
                {
                    lvEntries.Items.Remove(item);
                }
            }



        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lvEntries.Items.Clear();
        }
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Filter = "C# Source File | *.csv ; *.png ; *.jpg";
            //fileDialog.Multiselect = true;
            //bool? sucess = fileDialog.ShowDialog();

            //if (sucess == true)
            //{
            //    var path = fileDialog.FileNames.OfType<string>().ToList();
            //    var fileName = fileDialog.SafeFileNames.OfType<string>().ToList();

            //    tbInfo.Text = string.Join(", ", fileName);
            //}
            //else
            //{

            //}

            Winform.FolderBrowserDialog dialog = new Winform.FolderBrowserDialog();
            dialog.InitialDirectory = "C:\\Users\\minhg\\Downloads\\Video";
            Winform.DialogResult result = dialog.ShowDialog();
            if (result == Winform.DialogResult.OK)
            {
                string folder = dialog.SelectedPath;
            }
            else
            {

            }



            //MessageBox.Show("ssss");            //MessageBox.Show("ssss");
        }
    }



}

