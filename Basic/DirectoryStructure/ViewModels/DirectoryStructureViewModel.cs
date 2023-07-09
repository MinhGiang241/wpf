using System.Collections.ObjectModel;
using System.Linq;

namespace WpfBasic
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public DirectoryStructureViewModel()
        {
            var children = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(d => new DirectoryItemViewModel(d.FullPath, d.Type))); ;
        }

        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }


    }
}
