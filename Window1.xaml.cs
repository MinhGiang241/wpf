using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WpfBasic
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();
        }

        public ICommand ExpandCommand { get; set; }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

        }

    }
}


