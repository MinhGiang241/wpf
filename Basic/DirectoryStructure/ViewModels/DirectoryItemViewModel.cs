

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfBasic
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            ExpandedCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.Type = type;

            ClearChildren();
        }

        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath);
            }

        }

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }

            set
            {

                if (value == true) Expand();
                else ClearChildren();

            }
        }

        private void Expand()
        {
            if (Type == DirectoryItemType.File) return;

            var children = DirectoryStructure.GetDirectoryContents(this.FullPath).Select((content) => new DirectoryItemViewModel(content.FullPath, content.Type));
            this.Children = new ObservableCollection<DirectoryItemViewModel>(children);
        }

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            if (Type != DirectoryItemType.File) Children.Add(null);
        }

        public ICommand ExpandedCommand { get; set; }
    }
}
