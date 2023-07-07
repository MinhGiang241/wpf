using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };


                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                this.FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 1 && item.Items[0] != null) return;
            item.Items.Clear();
            var fullPath = (string)item.Tag;

            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch { }

            directories.ForEach(dirPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(dirPath),
                    Tag = dirPath
                };

                subItem.Items.Add(null);
                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });



        }

        private object GetFileFolderName(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath)) return string.Empty;

            var normalizedPath = dirPath.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0) return dirPath;

            return dirPath.Substring(lastIndex + 1);
        }
    }


}
